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
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="target"></param>
    Public Sub New(ByVal target As Object)
        Me.tagetObject = target
    End Sub

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
