Imports System.Net.NetworkInformation
Imports Backuper
Imports Backuper.Form1

Public Class Connection

    Public Shared Sub Connection(dest As String)
        Try
            Dim pingSender As New Ping()
            Dim pingReply As PingReply = pingSender.Send(dest)

            If pingReply.Status = IPStatus.Success Then
                Connecter = "Connection: Connected to the internet ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.BadDestination Then
                Connecter = "Connection: Bad Destination ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.BadHeader Then
                Connecter = "Connection: Bad Header ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.BadOption Then
                Connecter = "Connection: Bad Option ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.BadRoute Then
                Connecter = "Connection: Bad Route ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.DestinationHostUnreachable Then
                Connecter = "Connection: Destination Host Unreachable ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.DestinationNetworkUnreachable Then
                Connecter = "Connection: Destination Network Unreachable ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.DestinationPortUnreachable Then
                Connecter = "Connection: Destination Port Unreachable ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.DestinationProhibited Then
                Connecter = "Connection: Destination Prohibited ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.DestinationProtocolUnreachable Then
                Connecter = "Connection: Destination Protocol Unreachable ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.DestinationScopeMismatch Then
                Connecter = "Connection: Destination Scope Mismatch ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.DestinationUnreachable Then
                Connecter = "Connection: Destination Unreachable ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.HardwareError Then
                Connecter = "Connection: Hardware Error ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.IcmpError Then
                Connecter = "Connection: Icmp Error ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.NoResources Then
                Connecter = "Connection: No Resources ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.PacketTooBig Then
                Connecter = "Connection: Packet Too Big ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.ParameterProblem Then
                Connecter = "Connection: Parameter Problem ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.SourceQuench Then
                Connecter = "Connection: Source Quench ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.TimedOut Then
                Connecter = "Connection: Timed Out ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.TimeExceeded Then
                Connecter = "Connection: Time Exceeded ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.TtlExpired Then
                Connecter = "Connection: Ttl Expired ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.TtlReassemblyTimeExceeded Then
                Connecter = "Connection: Ttl Reassembly Time Exceeded ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.Unknown Then
                Connecter = "Connection: Unknown ( " + dest + " ) [Click to check connection or website]"
            ElseIf pingReply.Status = IPStatus.UnrecognizedNextHeader Then
                Connecter = "Connection: Unrecognized Next Header ( " + dest + " ) [Click to check connection or website]"
            Else
                Connecter = "Connection: N/A ( " + dest + " ) [Click to check connection or website]"
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

End Class
