Option Explicit On
Option Strict On


Public Class MainForm

    ''' <summary>
    '''   When a letter key is pressed, change the displayed letter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z) Then
            LetterLabel.Text = StrConv(Chr(e.KeyCode), VbStrConv.Uppercase)
        End If
    End Sub
End Class
