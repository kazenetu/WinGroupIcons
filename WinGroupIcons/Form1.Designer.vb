<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.addIcon = New System.Windows.Forms.Button()
        Me.ContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemSetGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemResetGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.ContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.addIcon)
        Me.Panel1.Location = New System.Drawing.Point(491, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(124, 191)
        Me.Panel1.TabIndex = 11
        '
        'addIcon
        '
        Me.addIcon.Location = New System.Drawing.Point(14, 3)
        Me.addIcon.Name = "addIcon"
        Me.addIcon.Size = New System.Drawing.Size(96, 23)
        Me.addIcon.TabIndex = 12
        Me.addIcon.Text = "アイコンの追加"
        Me.addIcon.UseVisualStyleBackColor = True
        '
        'ContextMenu
        '
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemCancel, Me.MenuItemRemove, Me.MenuItemSetGroup, Me.MenuItemResetGroup})
        Me.ContextMenu.Name = "ContextMenuStrip1"
        Me.ContextMenu.Size = New System.Drawing.Size(153, 114)
        '
        'MenuItemCancel
        '
        Me.MenuItemCancel.Name = "MenuItemCancel"
        Me.MenuItemCancel.Size = New System.Drawing.Size(152, 22)
        Me.MenuItemCancel.Text = "キャンセル"
        '
        'MenuItemRemove
        '
        Me.MenuItemRemove.Name = "MenuItemRemove"
        Me.MenuItemRemove.Size = New System.Drawing.Size(152, 22)
        Me.MenuItemRemove.Text = "削除"
        '
        'MenuItemSetGroup
        '
        Me.MenuItemSetGroup.Name = "MenuItemSetGroup"
        Me.MenuItemSetGroup.Size = New System.Drawing.Size(152, 22)
        Me.MenuItemSetGroup.Text = "グループ設定"
        '
        'MenuItemResetGroup
        '
        Me.MenuItemResetGroup.Name = "MenuItemResetGroup"
        Me.MenuItemResetGroup.Size = New System.Drawing.Size(152, 22)
        Me.MenuItemResetGroup.Text = "グループ解除"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 432)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents addIcon As Button
    Friend WithEvents ContextMenu As ContextMenuStrip
    Friend WithEvents MenuItemCancel As ToolStripMenuItem
    Friend WithEvents MenuItemRemove As ToolStripMenuItem
    Friend WithEvents MenuItemSetGroup As ToolStripMenuItem
    Friend WithEvents MenuItemResetGroup As ToolStripMenuItem
End Class
