﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmproduct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmproduct))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtcost = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ckbarcode = New System.Windows.Forms.CheckBox()
        Me.txtsales = New Guna.UI2.WinForms.Guna2TextBox()
        Me.unitcbx = New System.Windows.Forms.ComboBox()
        Me.categorycbx = New System.Windows.Forms.ComboBox()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.picbarcode = New System.Windows.Forms.PictureBox()
        Me.unitid = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.itemdes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.labelprice = New System.Windows.Forms.Label()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.labelcateg = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.lblbarcode = New System.Windows.Forms.Label()
        Me.lblclass = New System.Windows.Forms.Label()
        Me.btnsave = New Guna.UI2.WinForms.Guna2Button()
        Me.btnupdate = New Guna.UI2.WinForms.Guna2Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.picbarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.ResizeForm = False
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtcost)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.ckbarcode)
        Me.Panel1.Controls.Add(Me.txtsales)
        Me.Panel1.Controls.Add(Me.unitcbx)
        Me.Panel1.Controls.Add(Me.categorycbx)
        Me.Panel1.Controls.Add(Me.txtbarcode)
        Me.Panel1.Controls.Add(Me.picbarcode)
        Me.Panel1.Controls.Add(Me.unitid)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.itemdes)
        Me.Panel1.Controls.Add(Me.labelprice)
        Me.Panel1.Controls.Add(Me.Guna2Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.labelcateg)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblid)
        Me.Panel1.Controls.Add(Me.lblbarcode)
        Me.Panel1.Controls.Add(Me.lblclass)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.btnupdate)
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 532)
        Me.Panel1.TabIndex = 0
        '
        'txtcost
        '
        Me.txtcost.BackColor = System.Drawing.Color.Transparent
        Me.txtcost.BorderColor = System.Drawing.Color.Gray
        Me.txtcost.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcost.DefaultText = ""
        Me.txtcost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtcost.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtcost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcost.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcost.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcost.Location = New System.Drawing.Point(157, 315)
        Me.txtcost.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcost.Name = "txtcost"
        Me.txtcost.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtcost.PlaceholderText = ""
        Me.txtcost.SelectedText = ""
        Me.txtcost.Size = New System.Drawing.Size(346, 33)
        Me.txtcost.TabIndex = 96
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(15, 330)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 18)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Cost Price:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(314, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(189, 34)
        Me.Button1.TabIndex = 94
        Me.Button1.Text = "Generate barcode"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ckbarcode
        '
        Me.ckbarcode.AutoSize = True
        Me.ckbarcode.Location = New System.Drawing.Point(561, 9)
        Me.ckbarcode.Name = "ckbarcode"
        Me.ckbarcode.Size = New System.Drawing.Size(178, 22)
        Me.ckbarcode.TabIndex = 91
        Me.ckbarcode.Text = "Saving Barcode Image"
        Me.ckbarcode.UseVisualStyleBackColor = True
        '
        'txtsales
        '
        Me.txtsales.BackColor = System.Drawing.Color.Transparent
        Me.txtsales.BorderColor = System.Drawing.Color.Gray
        Me.txtsales.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtsales.DefaultText = ""
        Me.txtsales.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtsales.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtsales.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtsales.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtsales.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtsales.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtsales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtsales.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtsales.Location = New System.Drawing.Point(157, 385)
        Me.txtsales.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtsales.Name = "txtsales"
        Me.txtsales.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtsales.PlaceholderText = ""
        Me.txtsales.SelectedText = ""
        Me.txtsales.Size = New System.Drawing.Size(346, 33)
        Me.txtsales.TabIndex = 90
        '
        'unitcbx
        '
        Me.unitcbx.FormattingEnabled = True
        Me.unitcbx.Location = New System.Drawing.Point(157, 258)
        Me.unitcbx.Name = "unitcbx"
        Me.unitcbx.Size = New System.Drawing.Size(346, 26)
        Me.unitcbx.TabIndex = 89
        '
        'categorycbx
        '
        Me.categorycbx.FormattingEnabled = True
        Me.categorycbx.Location = New System.Drawing.Point(157, 201)
        Me.categorycbx.Name = "categorycbx"
        Me.categorycbx.Size = New System.Drawing.Size(346, 26)
        Me.categorycbx.TabIndex = 87
        '
        'txtbarcode
        '
        Me.txtbarcode.Location = New System.Drawing.Point(157, 83)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(346, 24)
        Me.txtbarcode.TabIndex = 75
        '
        'picbarcode
        '
        Me.picbarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picbarcode.Location = New System.Drawing.Point(561, 37)
        Me.picbarcode.Name = "picbarcode"
        Me.picbarcode.Size = New System.Drawing.Size(308, 160)
        Me.picbarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picbarcode.TabIndex = 74
        Me.picbarcode.TabStop = False
        '
        'unitid
        '
        Me.unitid.AutoSize = True
        Me.unitid.Location = New System.Drawing.Point(131, 261)
        Me.unitid.Name = "unitid"
        Me.unitid.Size = New System.Drawing.Size(0, 18)
        Me.unitid.TabIndex = 73
        Me.unitid.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 266)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 18)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Unit:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 18)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Item Description:"
        '
        'itemdes
        '
        Me.itemdes.BackColor = System.Drawing.Color.Transparent
        Me.itemdes.BorderColor = System.Drawing.Color.Gray
        Me.itemdes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.itemdes.DefaultText = ""
        Me.itemdes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.itemdes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.itemdes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.itemdes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.itemdes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.itemdes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.itemdes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.itemdes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.itemdes.Location = New System.Drawing.Point(157, 114)
        Me.itemdes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.itemdes.Name = "itemdes"
        Me.itemdes.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.itemdes.PlaceholderText = "e.g., ""Paracetamol (Biogesic) 500mg "
        Me.itemdes.SelectedText = ""
        Me.itemdes.Size = New System.Drawing.Size(346, 50)
        Me.itemdes.TabIndex = 69
        '
        'labelprice
        '
        Me.labelprice.AutoSize = True
        Me.labelprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelprice.ForeColor = System.Drawing.Color.Black
        Me.labelprice.Location = New System.Drawing.Point(15, 393)
        Me.labelprice.Name = "labelprice"
        Me.labelprice.Size = New System.Drawing.Size(87, 18)
        Me.labelprice.TabIndex = 68
        Me.labelprice.Text = "Sales Price:"
        '
        'Guna2Button1
        '
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.FillColor = System.Drawing.Color.Brown
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(561, 421)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(308, 27)
        Me.Guna2Button1.TabIndex = 66
        Me.Guna2Button1.Text = "SELECT PHOTO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(107, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Entry"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(561, 203)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(308, 212)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 65
        Me.PictureBox1.TabStop = False
        '
        'labelcateg
        '
        Me.labelcateg.AutoSize = True
        Me.labelcateg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelcateg.ForeColor = System.Drawing.Color.Black
        Me.labelcateg.Location = New System.Drawing.Point(15, 209)
        Me.labelcateg.Name = "labelcateg"
        Me.labelcateg.Size = New System.Drawing.Size(116, 18)
        Me.labelcateg.TabIndex = 27
        Me.labelcateg.Text = "Category Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Barcode:"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.BackColor = System.Drawing.Color.Transparent
        Me.lblid.Location = New System.Drawing.Point(15, 43)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 18)
        Me.lblid.TabIndex = 20
        Me.lblid.Visible = False
        '
        'lblbarcode
        '
        Me.lblbarcode.AutoSize = True
        Me.lblbarcode.Location = New System.Drawing.Point(104, 88)
        Me.lblbarcode.Name = "lblbarcode"
        Me.lblbarcode.Size = New System.Drawing.Size(0, 18)
        Me.lblbarcode.TabIndex = 18
        '
        'lblclass
        '
        Me.lblclass.AutoSize = True
        Me.lblclass.Location = New System.Drawing.Point(137, 208)
        Me.lblclass.Name = "lblclass"
        Me.lblclass.Size = New System.Drawing.Size(0, 18)
        Me.lblclass.TabIndex = 12
        Me.lblclass.Visible = False
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
        Me.btnsave.Location = New System.Drawing.Point(783, 505)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(115, 27)
        Me.btnsave.TabIndex = 7
        Me.btnsave.Text = "SUBMIT"
        '
        'btnupdate
        '
        Me.btnupdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnupdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnupdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnupdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnupdate.FillColor = System.Drawing.Color.Teal
        Me.btnupdate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnupdate.ForeColor = System.Drawing.Color.White
        Me.btnupdate.Location = New System.Drawing.Point(784, 505)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(115, 27)
        Me.btnupdate.TabIndex = 9
        Me.btnupdate.Text = "UPDATE"
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(865, -2)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(34, 26)
        Me.Button10.TabIndex = 97
        Me.Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button10.UseVisualStyleBackColor = True
        '
        'frmproduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(898, 559)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmproduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmproduct"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picbarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnupdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblclass As System.Windows.Forms.Label
    Friend WithEvents lblbarcode As System.Windows.Forms.Label
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents labelcateg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents itemdes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents labelprice As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents unitid As System.Windows.Forms.Label
    Friend WithEvents picbarcode As System.Windows.Forms.PictureBox
    Friend WithEvents txtbarcode As System.Windows.Forms.TextBox
    Friend WithEvents btnsave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtsales As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents unitcbx As System.Windows.Forms.ComboBox
    Friend WithEvents categorycbx As System.Windows.Forms.ComboBox
    Friend WithEvents ckbarcode As System.Windows.Forms.CheckBox
    Public WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtcost As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
End Class
