Imports System.Linq

Public Class Form1

    Private iconCount As Integer = 0

    ''' <summary>
    ''' ラベルのマウスイベントを追加
    ''' </summary>
    ''' <param name="target"></param>
    Private Sub setHandler(target As Label)
        AddHandler target.MouseDown, AddressOf Label_MouseDown
        AddHandler target.MouseMove, AddressOf Label_MouseMove

    End Sub

    ''' <summary>
    ''' ラベル マウスクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label_MouseDown(sender As Object, e As MouseEventArgs)
        Dim target As Label = DirectCast(sender, Label)

        If e.Button = MouseButtons.Right Then
            Me.Controls.Remove(target)
        Else
            target.Tag = e.Location
        End If
    End Sub

    ''' <summary>
    ''' ラベル マウスドラッグ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label_MouseMove(sender As Object, e As MouseEventArgs)
        If Not e.Button = MouseButtons.Left Then
            Return
        End If

        Dim target As Label = DirectCast(sender, Label)
        Dim basePoint As Point = DirectCast(target.Tag, Point)
        target.Left = CInt((target.Left + e.Location.X - basePoint.X) / 50) * 50
        target.Top = CInt((target.Top + e.Location.Y - basePoint.Y) / 50) * 50
    End Sub

    ''' <summary>
    ''' アイコンの追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub addIcon_Click(sender As Object, e As EventArgs) Handles addIcon.Click
        Dim newLabel As New Label()

        iconCount += 1

        newLabel.Width = 60
        newLabel.Height = 60
        newLabel.BackColor = Color.Black
        newLabel.ForeColor = Color.White
        newLabel.Text = String.Format("icon     {0}", iconCount)
        setHandler(newLabel)

        Me.Controls.Add(newLabel)
    End Sub
End Class
