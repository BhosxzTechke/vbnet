﻿Public Class frmstaffboard

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub frmstaffboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With frmdashboard
            .Opacity = 0
            .TopLevel = False
            Panel3.Controls.Add(frmdashboard)
            .BringToFront()
            .Show()
        End With

        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.Sizable

        Timer1.Start()

    End Sub

    Private Sub btnsales_Click(sender As Object, e As EventArgs) Handles btnsales.Click
        ' FORM NI Supplier staff
        With frmstaffsupplier
            .Opacity = 0
            .TopLevel = False
            Panel3.Controls.Add(frmstaffsupplier)
            .BringToFront()
            .Show()

        End With
    End Sub

    Private Sub btnproduct_Click(sender As Object, e As EventArgs) Handles btnproduct.Click
        ' FORM NI PRODUCT
        With frmproductlists
            .Opacity = 0
            .TopLevel = False
            Panel3.Controls.Add(frmproductlists)
            .prodrecord()
            .BringToFront()
            .Show()

        End With
    End Sub

    Private Sub btnsadjust_Click(sender As Object, e As EventArgs) Handles btnsadjust.Click
        With frmstockadjustment
            .ShowDialog()

        End With
    End Sub

    Private Sub btnrecords_Click(sender As Object, e As EventArgs) Handles btnrecords.Click
        With frmrecordstaff
            '.stockinventory()
            '.CriticalStock()
            .ShowDialog()

        End With
    End Sub

    Private Sub Guna2ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Guna2ContextMenuStrip1.Opening
        ' Check the current color mode and update the menu item text
        'Command1ToolStripMenuItem.Text = "System Lock"
        Command2ToolStripMenuItem.Text = "Change Password"
        AToolStripMenuItem.Text = "Logout"
    End Sub

    Private Sub btnew_Click(sender As Object, e As EventArgs) Handles btnew.Click
        Guna2ContextMenuStrip1.Show(btnew, 0, btnew.Height)
    End Sub

    Private Sub AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AToolStripMenuItem.Click
        loginform.Show()
        Me.Dispose()


    End Sub

    Private Sub lbluser_Click(sender As Object, e As EventArgs) Handles lbluser.Click

    End Sub

    Private Sub Command2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Command2ToolStripMenuItem.Click
        With frmchangepass
            .ShowDialog()
        End With
    End Sub

    Private Sub toolstripmaint_Click(sender As Object, e As EventArgs) Handles toolstripmaint.Click

        'FORM NI maintanance
        With frmmaintenance
            .ShowDialog()

        End With



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnmaint.Click
        'FORM NI maintanance
        With frmmaintenance
            .ShowDialog()

        End With

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Now.ToLongDateString
        lbltime.Text = Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub lbldate_Click(sender As Object, e As EventArgs) Handles lbldate.Click

    End Sub

    Private Sub lbltime_Click(sender As Object, e As EventArgs) Handles lbltime.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnpos.Click
        With cashier
            .ShowDialog()
        End With

    End Sub



    Private Sub Panel3_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class