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
        Me.AaaaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BbbbToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.グループ設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.グループ解除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AaaaToolStripMenuItem, Me.BbbbToolStripMenuItem, Me.グループ設定ToolStripMenuItem, Me.グループ解除ToolStripMenuItem})
        Me.ContextMenu.Name = "ContextMenuStrip1"
        Me.ContextMenu.Size = New System.Drawing.Size(153, 114)
        '
        'AaaaToolStripMenuItem
        '
        Me.AaaaToolStripMenuItem.Name = "AaaaToolStripMenuItem"
        Me.AaaaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AaaaToolStripMenuItem.Text = "キャンセル"
        '
        'BbbbToolStripMenuItem
        '
        Me.BbbbToolStripMenuItem.Name = "BbbbToolStripMenuItem"
        Me.BbbbToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BbbbToolStripMenuItem.Text = "削除"
        '
        'グループ設定ToolStripMenuItem
        '
        Me.グループ設定ToolStripMenuItem.Name = "グループ設定ToolStripMenuItem"
        Me.グループ設定ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.グループ設定ToolStripMenuItem.Text = "グループ設定"
        '
        'グループ解除ToolStripMenuItem
        '
        Me.グループ解除ToolStripMenuItem.Name = "グループ解除ToolStripMenuItem"
        Me.グループ解除ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.グループ解除ToolStripMenuItem.Text = "グループ解除"
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
    Friend WithEvents AaaaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BbbbToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents グループ設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents グループ解除ToolStripMenuItem As ToolStripMenuItem
End Class
