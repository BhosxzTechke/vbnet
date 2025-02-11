<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmchangepass
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmchangepass))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.struserrs = New System.Windows.Forms.Label()
        Me.oldpassword = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.newpass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtold = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtconfpass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btncancel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnsave = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.struserrs)
        Me.Panel2.Controls.Add(Me.oldpassword)
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.newpass)
        Me.Panel2.Controls.Add(Me.txtold)
        Me.Panel2.Location = New System.Drawing.Point(-5, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(496, 214)
        Me.Panel2.TabIndex = 2
        '
        'struserrs
        '
        Me.struserrs.AutoSize = True
        Me.struserrs.Location = New System.Drawing.Point(292, 22)
        Me.struserrs.Name = "struserrs"
        Me.struserrs.Size = New System.Drawing.Size(51, 17)
        Me.struserrs.TabIndex = 15
        Me.struserrs.Text = "Label2"
        Me.struserrs.Visible = False
        '
        'oldpassword
        '
        Me.oldpassword.AutoSize = True
        Me.oldpassword.Location = New System.Drawing.Point(359, 22)
        Me.oldpassword.Name = "oldpassword"
        Me.oldpassword.Size = New System.Drawing.Size(51, 17)
        Me.oldpassword.TabIndex = 14
        Me.oldpassword.Text = "Label2"
        Me.oldpassword.Visible = False
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(762, 3)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(38, 29)
        Me.Button10.TabIndex = 13
        Me.Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button10.UseVisualStyleBackColor = True
        '
        'newpass
        '
        Me.newpass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.newpass.DefaultText = ""
        Me.newpass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.newpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.newpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.newpass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.newpass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.newpass.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.newpass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.newpass.IconLeft = CType(resources.GetObject("newpass.IconLeft"), System.Drawing.Image)
        Me.newpass.Location = New System.Drawing.Point(30, 96)
        Me.newpass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.newpass.Name = "newpass"
        Me.newpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.newpass.PlaceholderText = "New Password"
        Me.newpass.SelectedText = ""
        Me.newpass.Size = New System.Drawing.Size(434, 32)
        Me.newpass.TabIndex = 4
        '
        'txtold
        '
        Me.txtold.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtold.DefaultText = ""
        Me.txtold.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtold.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtold.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtold.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtold.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtold.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtold.IconLeft = CType(resources.GetObject("txtold.IconLeft"), System.Drawing.Image)
        Me.txtold.Location = New System.Drawing.Point(30, 66)
        Me.txtold.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtold.Name = "txtold"
        Me.txtold.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtold.PlaceholderText = "Old password"
        Me.txtold.SelectedText = ""
        Me.txtold.Size = New System.Drawing.Size(434, 32)
        Me.txtold.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Change Password"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(453, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 29)
        Me.Button1.TabIndex = 14
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtconfpass
        '
        Me.txtconfpass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtconfpass.DefaultText = ""
        Me.txtconfpass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtconfpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtconfpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtconfpass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtconfpass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtconfpass.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtconfpass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtconfpass.IconLeft = CType(resources.GetObject("txtconfpass.IconLeft"), System.Drawing.Image)
        Me.txtconfpass.Location = New System.Drawing.Point(25, 163)
        Me.txtconfpass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtconfpass.Name = "txtconfpass"
        Me.txtconfpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtconfpass.PlaceholderText = "Confirm New Password"
        Me.txtconfpass.SelectedText = ""
        Me.txtconfpass.Size = New System.Drawing.Size(434, 32)
        Me.txtconfpass.TabIndex = 5
        '
        'btncancel
        '
        Me.btncancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btncancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btncancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btncancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btncancel.FillColor = System.Drawing.Color.Teal
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btncancel.ForeColor = System.Drawing.Color.White
        Me.btncancel.Location = New System.Drawing.Point(344, 201)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(115, 27)
        Me.btncancel.TabIndex = 11
        Me.btncancel.Text = "Cancel"
        '
        'btnsave
        '
        Me.btnsave.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnsave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnsave.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnsave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnsave.FillColor = System.Drawing.Color.Teal
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnsave.ForeColor = System.Drawing.Color.White
        Me.btnsave.Location = New System.Drawing.Point(223, 201)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(115, 27)
        Me.btnsave.TabIndex = 10
        Me.btnsave.Text = "Save"
        '
        'frmchangepass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(489, 247)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.txtconfpass)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmchangepass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmchangepass"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtconfpass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents newpass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtold As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btncancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnsave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents oldpassword As System.Windows.Forms.Label
    Friend WithEvents struserrs As System.Windows.Forms.Label
End Class
