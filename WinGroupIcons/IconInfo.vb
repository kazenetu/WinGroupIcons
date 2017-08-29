''' <summary>
''' アイコン情報
''' </summary>
Public Class IconInfo

    Public Const WIDTH As Integer = 100

    ''' <summary>
    ''' 対象オブジェクト
    ''' </summary>
    Public ReadOnly Property tagetObject As Object

    ''' <summary>
    ''' 所属グループ
    ''' </summary>
    ''' <returns></returns>
    Public Property group As IconGroup = Nothing

    ''' <summary>
    ''' X位置
    ''' </summary>
    ''' <returns>X位置</returns>
    Public Property X As Integer
        Set(value As Integer)
            DirectCast(Me.tagetObject, Label).Left = value
        End Set
        Get
            Return DirectCast(Me.tagetObject, Label).Location.X
        End Get
    End Property

    ''' <summary>
    ''' Y位置
    ''' </summary>
    ''' <returns>Y位置</returns>
    Public ReadOnly Property Y As Integer
        Get
            Return DirectCast(Me.tagetObject, Label).Location.Y
        End Get
    End Property

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="target"></param>
    Public Sub New(ByVal target As Object)
        Me.tagetObject = target
    End Sub

    ''' <summary>
    ''' 指定した位置がアイコンの中か否か
    ''' </summary>
    ''' <param name="pos">指定した位置</param>
    ''' <returns>true:アイコンの中</returns>
    Public Function isHit(ByVal pos As Point) As Boolean
        Dim target = DirectCast(Me.tagetObject, Label)

        Dim rect As New Rectangle(target.Location, target.Size)

        Return rect.Contains(pos)
    End Function

    ''' <summary>
    ''' アイコンの追加
    ''' </summary>
    ''' <param name="target">対象オブジェクト</param>
    ''' <returns>アイコンインスタンス</returns>
    Public Shared Function Create(ByRef target As Label) As IconInfo
        Dim instance = New IconInfo(target)
        target.Tag = instance

        Return instance
    End Function
End Class
