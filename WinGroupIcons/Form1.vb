﻿Imports System.Linq

Public Class Form1

    ''' <summary>
    ''' アイコンのユニークインデックス用
    ''' </summary>
    Private iconCount As Integer = 0

    ''' <summary>
    ''' アイコングループ管理クラス
    ''' </summary>
    Private iconGroups As New IconGroups()

    ''' <summary>
    ''' 選択中のアイコン
    ''' </summary>
    Private selectIcons As New List(Of IconInfo)

    ''' <summary>
    ''' ドラッグ中のアイコンの相対位置
    ''' </summary>
    Private selectIconPosition As Point

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
    ''' ラベルのマウスイベントを削除
    ''' </summary>
    ''' <param name="target">イベント削除対象</param>
    Private Sub resetHandler(target As Label)
        RemoveHandler target.MouseDown, AddressOf Label_MouseDown
        RemoveHandler target.MouseMove, AddressOf Label_MouseMove
        RemoveHandler target.MouseUp, AddressOf Label_MouseUp

    End Sub

    ''' <summary>
    ''' ラベル マウスクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label_MouseDown(sender As Object, e As MouseEventArgs)
        Dim target As Label = DirectCast(sender, Label)

        If e.Button = MouseButtons.Left Then
            If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                ' Ctrl+クリックで複数選択
                If Not Me.selectIcons.Contains(target.Tag) Then
                    Me.selectIcons.Add(target.Tag)
                End If

            Else

                ' 単一選択の場合、クリアしてから今回のアイコンを追加
                Me.selectIcons.Clear()
                Me.selectIcons.Add(target.Tag)
            End If
            target.BringToFront()

            ' ラベル設定
            Me.setLabels()

            ' 選択位置を保存
            Me.selectIconPosition = e.Location

        ElseIf e.Button = MouseButtons.Right Then

            ' 右クリックしたアイコンが追加されていない場合は追加する
            If Not Me.selectIcons.Contains(target.Tag) Then
                Me.selectIcons.Add(target.Tag)
            End If

            ' コンテキストメニューを表示
            Me.ContextMenu.Show(PointToScreen(target.Location + e.Location))

        End If

        ' グループ線を描画
        Me.drawLines()
    End Sub

    ''' <summary>
    ''' ラベル マウスドラッグ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label_MouseMove(sender As Object, e As MouseEventArgs)

        ' 左クリック以外であれば終了
        If Not e.Button = MouseButtons.Left Then
            Return
        End If

        ' ctrlによる複数選択であれば終了
        If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            Return
        End If

        ' アイコンの移動と背景色の変更
        Dim target As Label = DirectCast(sender, Label)
        target.Left += e.X - Me.selectIconPosition.X
        target.BackColor = Color.FromArgb(64, Color.Red)
    End Sub

    ''' <summary>
    ''' ラベル マウスアップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label_MouseUp(sender As Object, e As MouseEventArgs)

        ' 左クリック以外であれば終了
        If Not e.Button = MouseButtons.Left Then
            Return
        End If

        ' ctrlによる複数選択であれば終了
        If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            Return
        End If

        ' アイコングループの移動またはグループ設定
        Dim target As Label = DirectCast(sender, Label)
        iconGroups.Move(target.Tag)

        ' アイコンの背景色を通常に変更
        target.BackColor = Color.FromArgb(255, Color.SkyBlue)

        ' グループ線を描画
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
        'newLabel.Margin = New Padding(30, 30, 0, 0)
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

        ' グループ線を描画
        Me.drawLines()
    End Sub

    ''' <summary>
    ''' ラベル設定
    ''' </summary>
    Private Sub setLabels()
        For Each control In Me.Controls
            If TypeOf (control) Is Label Then
                If Me.selectIcons.Contains(control.tag) Then
                    control.BackColor = Color.FromArgb(255, Color.Beige)
                Else
                    control.BackColor = Color.SkyBlue
                End If
            End If
        Next
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

    ''' <summary>
    ''' メニューアイテムのクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ContextMenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ContextMenu.ItemClicked

        If e.ClickedItem Is Me.MenuItemCancel Then
            ' 選択キャンセル

            ' 選択アイコンをクリアする
            Me.selectIcons.Clear()

        ElseIf e.ClickedItem Is Me.MenuItemRemove Then

            ' 削除
            For Each selectItem In Me.selectIcons
                ' イベント削除
                Me.resetHandler(selectItem.tagetObject)

                ' アイコンの削除
                Me.iconGroups.Remove(selectItem)
                Me.Controls.Remove(selectItem.tagetObject)
            Next

        ElseIf e.ClickedItem Is Me.MenuItemSetGroup Then

            ' グループ設定
            ' 左端のグループにマージする
            Dim icons = Me.selectIcons.OrderBy(Function(item) item.X).ToList()
            If icons.Count >= 2 Then
                Dim ownerGroup = icons(0).group
                For index = 1 To icons.Count - 1
                    Me.iconGroups.SetGroup(icons(index), ownerGroup)
                Next
            End If

            ' 選択アイコンをクリアする
            Me.selectIcons.Clear()

        ElseIf e.ClickedItem Is Me.MenuItemResetGroup Then

            ' グループ解除
            For Each selectItem In Me.selectIcons
                Me.iconGroups.Reset(selectItem)
            Next

            ' 選択アイコンをクリアする
            Me.selectIcons.Clear()

        End If

        ' ラベル設定
        Me.setLabels()

        ' グループ線を描画
        Me.drawLines()
    End Sub
End Class
