''' <summary>
''' アイコングループリスト
''' </summary>
Public Class IconGroups
    ''' <summary>
    ''' アイコングループ
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Items As New List(Of IconGroup)

    ''' <summary>
    ''' 追加
    ''' </summary>
    ''' <param name="instance">グループインスタンス</param>
    Public Sub Add(ByRef instance As IconGroup)
        Me.Items.Add(instance)
    End Sub

    ''' <summary>
    ''' アイコンの移動
    ''' </summary>
    ''' <param name="target"></param>
    Public Sub Move(ByVal target As IconInfo)
        Dim groups = Me.Items.Where(Function(item) item.MinX > target.X).OrderBy(Function(item) item.MinX).ToList()

        target.X = CInt(target.X / IconInfo.WIDTH) * IconInfo.WIDTH + 30

        Dim x = target.X + IconInfo.WIDTH
        For index = 0 To groups.Count - 1
            groups(index).setMinX(x)
            x += +IconInfo.WIDTH
        Next

        ' アイコンの並び直し
        Me.refresh()
    End Sub

    ''' <summary>
    ''' アイコンの更新
    ''' </summary>
    Private Sub refresh()
        Dim groups = Me.Items.OrderBy(Function(item) item.MinX).ToList()

        Dim X = 30
        For index = 0 To groups.Count - 1
            groups(index).setMinX(X)
            X += +IconInfo.WIDTH
        Next
    End Sub
End Class
