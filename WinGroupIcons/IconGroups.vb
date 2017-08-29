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
    ''' 削除
    ''' </summary>
    ''' <param name="instance">アイコンインスタンス</param>
    Public Sub Remove(ByVal instance As IconInfo)
        ' 移動元のグループを取得
        Dim srcGroups = Me.Items.Where(Function(group) group.Items.Contains(instance))
        If Not srcGroups.Any() Then
            Return
        End If
        Dim srcGroup = srcGroups.First()

        ' アイコンの削除
        srcGroup.Remove(instance)

        ' 空のグループは削除
        Me.removeEmptyGroups()
    End Sub

    ''' <summary>
    ''' アイコンの移動
    ''' </summary>
    ''' <param name="target">移動したアイコン</param>
    Public Sub Move(ByVal target As IconInfo)

        If Me.isMerge(target) Then
            ' アイコンのグルーピング
            For Each group In Me.Items
                If group.isHit(target) Then
                    Me.groupMove(target, group)
                End If
            Next

            ' 空のグループは削除
            Me.removeEmptyGroups()
        Else
            ' アイコンの入れ替え
            Dim targetPos As New Point(target.X, 30)
            Dim groups = Me.Items.Where(Function(item) item.MinX > target.X OrElse item.Rect.Contains(targetPos)).OrderBy(Function(item) item.MinX).ToList()

            target.X = CInt(target.X / IconInfo.WIDTH) * IconInfo.WIDTH + 30

            Dim x = target.X + IconInfo.WIDTH
            For index = 0 To groups.Count - 1
                groups(index).setMinX(x)
                x += IconInfo.WIDTH
            Next
        End If

        ' アイコンの並び直し
        Me.refresh()
    End Sub

    ''' <summary>
    ''' グループの解除
    ''' </summary>
    ''' <param name="target">解除するアイコン</param>
    Public Sub Reset(ByVal target As IconInfo)

        If target.group.Items.Count <= 1 Then
            Return
        End If

        target.group.Remove(target)

        Dim group As New IconGroup()
        group.Add(target)
        Me.Items.Add(group)

        ' アイコンの並び直し
        Me.refresh()
    End Sub

    ''' <summary>
    ''' マージするか否か
    ''' </summary>
    ''' <param name="target">移動したアイコン</param>
    ''' <returns>True:マージ</returns>
    Private Function isMerge(ByVal target As IconInfo) As Boolean

        For Each group In Me.Items
            If group.isHit(target) Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' アイコングループの移動
    ''' </summary>
    ''' <param name="srcIcon">対象のアイコン</param>
    ''' <param name="descGroup">移動先のグループ</param>
    Private Sub groupMove(ByVal srcIcon As IconInfo, ByVal descGroup As IconGroup)

        ' 移動元のグループを取得
        Dim srcGroups = Me.Items.Where(Function(group) group.Items.Contains(srcIcon))
        If Not srcGroups.Any() Then
            Return
        End If
        Dim srcGroup = srcGroups.First()

        ' アイコンの移動
        srcGroup.Remove(srcIcon)
        descGroup.Add(srcIcon)
    End Sub

    ''' <summary>
    ''' アイコンのないグループを削除する
    ''' </summary>
    Private Sub removeEmptyGroups()
        ' 空のグループは削除
        Dim groups = Me.Items.ToList()
        For index = 0 To groups.Count - 1
            If Not groups(index).Items.Any() Then
                Me.Items.Remove(groups(index))
            End If
        Next
    End Sub

    ''' <summary>
    ''' アイコンの更新
    ''' </summary>
    Private Sub refresh()
        Dim groups = Me.Items.OrderBy(Function(item) item.MinX).ToList()

        Dim X = 30
        For index = 0 To groups.Count - 1
            groups(index).setMinX(X)
            X = groups(index).Items.Max(Function(item) item.X) + IconInfo.WIDTH
        Next
    End Sub
End Class
