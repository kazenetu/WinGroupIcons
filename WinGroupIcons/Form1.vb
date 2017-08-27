Imports System.Linq

Public Class Form1

    Private iconCount As Integer = 0

    Private iconGroups As New IconGroups()

    ''' <summary>
    ''' ラベルのマウスイベントを追加
    ''' </summary>
    ''' <param name="target"></param>
    Private Sub setHandler(target As Label)
        AddHandler target.MouseDown, AddressOf Label_MouseDown
        AddHandler target.MouseMove, AddressOf Label_MouseMove
        AddHandler target.MouseUp, AddressOf Label_MouseUp

    End Sub

    ''' <summary>
    ''' ラベル マウスクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label_MouseDown(sender As Object, e As MouseEventArgs)
        Dim target As Label = DirectCast(sender, Label)

        If e.Button = MouseButtons.Right Then
            Me.iconGroups.Remove(target.Tag)
            Me.Controls.Remove(target)

            Me.drawLines()
        Else
            target.BringToFront()
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
        target.Left += e.X
        target.BackColor = Color.FromArgb(64, Color.Red)
    End Sub

    ''' <summary>
    ''' ラベル マウスアップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label_MouseUp(sender As Object, e As MouseEventArgs)
        If Not e.Button = MouseButtons.Left Then
            Return
        End If

        Dim target As Label = DirectCast(sender, Label)
        iconGroups.Move(target.Tag)

        target.BackColor = Color.FromArgb(255, Color.SkyBlue)

        Me.drawLines()
    End Sub

    ''' <summary>
    ''' アイコンの追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub addIcon_Click(sender As Object, e As EventArgs) Handles addIcon.Click

        ' 一番右端を選択
        Dim iconX As Integer = 0
        For Each control In Me.Controls
            If TypeOf control Is Label Then
                Dim labelInstance = DirectCast(control, Label)
                If iconX < labelInstance.Location.X Then
                    iconX = labelInstance.Location.X
                End If
            End If
        Next
        If iconX > 0 Then
            iconX += IconInfo.WIDTH
        End If

        Dim newLabel As New Label()

        iconCount += 1

        newLabel.Left = iconX + 30
        newLabel.Top = 100
        newLabel.Margin = New Padding(30, 30, 0, 0)
        newLabel.Width = 60
        newLabel.Height = 60
        newLabel.BackColor = Color.SkyBlue
        newLabel.ForeColor = Color.White
        newLabel.Text = String.Format("icon     {0}", iconCount)
        setHandler(newLabel)

        Me.Controls.Add(newLabel)

        ' アイコンの登録
        Me.iconGroups.Add(IconGroup.Create(IconInfo.Create(newLabel)))
        iconGroups.Move(newLabel.Tag)

        Me.drawLines()
    End Sub

    ''' <summary>
    ''' グループ線の描画
    ''' </summary>
    Private Sub drawLines()
        ' グルーピング クリア
        Using gr As Graphics = Me.CreateGraphics()
            gr.FillRectangle(New SolidBrush(Me.BackColor), New RectangleF(0, 0, Me.Width, Me.Height))
        End Using

        ' 描画
        Dim p As New Pen(Color.Black, 3)
        Using gr As Graphics = Me.CreateGraphics()

            For Each group In Me.iconGroups.Items
                If group.Items.Count >= 2 Then
                    Dim icons = group.Items.OrderBy(Function(item) item.X).ToList()
                    Dim startPos As New Point(icons(0).X, icons(0).Y + 30)
                    Dim endPos As New Point()

                    For index = 1 To icons.Count - 1
                        endPos.X = icons(index).X
                        endPos.Y = icons(index).Y + 30

                        gr.DrawLine(p, startPos, endPos)

                        startPos = endPos

                    Next
                End If
            Next
        End Using
    End Sub

End Class
