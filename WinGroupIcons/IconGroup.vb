''' <summary>
''' アイコングループ
''' </summary>
Public Class IconGroup
    ''' <summary>
    ''' アイコンリスト
    ''' </summary>
    Public ReadOnly Property Items As New List(Of IconInfo)

    ''' <summary>
    ''' 最小値を取得
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MinX As Integer
        Get
            Return Me.Items.Min(Function(item) item.X)
        End Get
    End Property

    ''' <summary>
    ''' 追加
    ''' </summary>
    ''' <param name="instance">Iconインスタンス</param>
    Public Sub Add(ByRef instance As IconInfo)
        Me.Items.Add(instance)
    End Sub

    ''' <summary>
    ''' 最小値Xの移動
    ''' </summary>
    ''' <param name="x"></param>
    Public Sub setMinX(ByVal x As Integer)
        Dim icons = Me.Items.OrderBy(Function(item) item.X).ToList()

        For index = 0 To icons.Count - 1
            icons(index).X = x
            x += IconInfo.WIDTH
        Next
    End Sub

    ''' <summary>
    ''' グループの作成
    ''' </summary>
    ''' <param name="target">対象オブジェクト</param>
    ''' <returns>グループインスタンス</returns>
    Public Shared Function Create(ByRef target As IconInfo) As IconGroup
        Dim instance = New IconGroup()
        instance.Add(target)

        Return instance
    End Function
End Class
