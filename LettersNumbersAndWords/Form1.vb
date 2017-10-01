Option Explicit On
Option Strict On


Public Class MainForm

    Dim SentanceString As String = ""


    ''' <summary>
    '''   When a letter key is pressed, change the displayed letter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ChangeLetterOrColor(e)

        AddNewLetterToFlow(e, LetterLabel)

        PlayLetterAudio(e)



    End Sub


    ''' <summary>
    '''   Add a letter label to the flow control. Adds in the current color and other properties
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="addLabel">The Label to add to the Flow Control.</param>
    Private Sub AddNewLetterToFlow(e As KeyEventArgs, ByVal addLabel As Label)
        ' Use overloads to handle other types?

        Dim newLabel As New Label

        With addLabel
            ' Copy over the relavent properties
            newLabel.Text = .Text
            newLabel.Font = .Font
            newLabel.ForeColor = .ForeColor
            newLabel.BackColor = .BackColor
            newLabel.Size = .Size
        End With

        ' Add the new letter to the sentance string as well
        AddNewLetterToSentance(newLabel.Text)


        FlowLayoutPanel1.Controls.Add(newLabel)


    End Sub

    ''' <summary>
    '''   Adds the new letter to the sentance string, and checks to see if it is a word that should be played
    ''' </summary>
    ''' <param name="text"></param>
    Private Sub AddNewLetterToSentance(text As String)
        SentanceString &= text

        dim ILoveArthurString As String = "I LOVE ARTHUR"
        Dim IString As String = "I"
        Dim LoveString As String = "LOVE"
        Dim ArthurString As String = "ARTHUR"


        If (Strings.Right(SentanceString, Len(LoveString)) = LoveString) Then
            'The right most part says "I"
            PlayWordAudio(LoveString)
        End If

    End Sub

    Private Shared Sub PlayWordAudio(PlayWord As String)
        My.Computer.Audio.Stop()

        Dim PlayStringBase As String = "C:\Users\andre\Documents\Visual Studio 2017\Projects\LettersNumbersAndWords\LettersNumbersAndWords\Assets\Audio\Words\"
        Dim PlayStringName As String
        Dim PlayStringExtension As String = ".wav"
        Dim PlayStringFull As String

        PlayStringName = PlayWord

        PlayStringFull = PlayStringBase & PlayStringName & PlayStringExtension

        Try
            My.Computer.Audio.Play(PlayStringFull, AudioPlayMode.Background)
        Catch ex As Exception

            Debug.Print("PlayWordAudio Exception: " & ex.Message)

            'Stop
        End Try
        Stop
    End Sub



    Private Shared Sub PlayLetterAudio(e As KeyEventArgs)
        My.Computer.Audio.Stop()

        Dim PlayStringBase As String = "C:\Users\andre\Documents\Visual Studio 2017\Projects\LettersNumbersAndWords\LettersNumbersAndWords\Assets\Audio\"
        Dim PlayStringName As String
        Dim PlayStringExtension As String = ".wav"
        Dim PlayStringFull As String

        PlayStringName = StrConv(Chr(e.KeyCode), VbStrConv.Uppercase)

        PlayStringFull = PlayStringBase & PlayStringName & PlayStringExtension

        Try
            My.Computer.Audio.Play(PlayStringFull, AudioPlayMode.Background)
        Catch ex As Exception

            Debug.Print("PlayLetterAudio Exception: " & ex.Message)

            'Stop
        End Try

    End Sub

    Private Sub ChangeLetterOrColor(e As KeyEventArgs)
        If (e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z) Or (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) Or (e.KeyCode = Keys.Space) Then
            ' If it's a letter or a number or a space, and the label isn't currenlty displaying it, update the label
            If ((StrConv(Chr(e.KeyCode), VbStrConv.Uppercase)) <> LetterLabel.Text) Then
                ' If the letter is different than the label, update it.
                LetterLabel.Text = StrConv(Chr(e.KeyCode), VbStrConv.Uppercase)
            End If
        Else
            ' If it's a non-letter key, change the colors
            Dim newRand As New Random

            Dim r As Integer = newRand.Next(0, 255)
            Dim g As Integer = newRand.Next(0, 255)
            Dim b As Integer = newRand.Next(0, 255)

            Dim newColor As New Color
            'Dim intColor As Integer
            'intColor = RGB(r, g, b)
            'newColor = intColor
            newColor = Color.FromArgb(r, g, b)

            LetterLabel.ForeColor = newColor

        End If
    End Sub
End Class
