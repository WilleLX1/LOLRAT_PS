param (
    [string]$Title = "TITLE_HERE",
    [string]$Message = "CONTENT_HERE"
)

# Display a message box with the provided title and message
Add-Type -AssemblyName PresentationFramework
[System.Windows.MessageBox]::Show($Message, $Title)
