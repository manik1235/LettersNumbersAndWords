﻿Option Explicit On
Option Strict On


Public Class MainForm

    ''' <summary>
    '''   When a letter key is pressed, change the displayed letter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ChangeLetterOrColor(e)

        My.Computer.Audio.Stop()

        Dim PlayStringBase As String
        Dim PlayStringName As String
        Dim PlayStringExtension As String = ".wav"
        Dim PlayStringFull As String

        PlayStringBase = "C:\Users\andre\Documents\Visual Studio 2017\Projects\LettersNumbersAndWords\LettersNumbersAndWords\Assets\Audio\"

        PlayStringName = StrConv(Chr(e.KeyCode), VbStrConv.Uppercase)

        PlayStringFull = PlayStringBase & PlayStringName & PlayStringExtension

        My.Computer.Audio.Play(PlayStringFull, AudioPlayMode.Background)

    End Sub

    Private Sub ChangeLetterOrColor(e As KeyEventArgs)
        If (e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z) Or (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) Then
            ' If it's a letter or a number, and the label isn't currenlty displaying it, update the lable
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
