Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing


Public Class frmproductlists

    Private Sub frmproductlists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prodrecord()
        dataprod.AlternatingRowsDefaultCellStyle = dataprod.RowsDefaultCellStyle

        Dim selectedCategoryID As Integer = CInt(frmproduct.categorycbx.SelectedValue)
        Dim selectedUnitID As Integer = CInt(frmproduct.unitcbx.SelectedValue)

    End Sub

 Sub prodrecord()
        Dim i As Integer = 0
        dataprod.Rows.Clear()

        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()

            Dim query As String = "SELECT p.id, p.barcode, p.item_des, p.price, p.costprice, p.imagepath, " &
                                  "c.Category AS Category, u.unit AS Unit " &
                                  "FROM tblproduct AS p " &
                                  "INNER JOIN tblcategory AS c ON p.cid = c.catID " &
                                  "INNER JOIN tblunit AS u ON p.uid = u.unitID"
            cmd = New SqlClient.SqlCommand(query, con)
            dr = cmd.ExecuteReader()

            While dr.Read()
                i += 1

                Dim img As Image = Nothing
                If Not IsDBNull(dr("imagepath")) AndAlso dr("imagepath") IsNot Nothing Then
                    Try
                        Dim imgData As Byte() = DirectCast(dr("imagepath"), Byte())
                        If imgData.Length > 0 Then img = ByteArrayToImage(imgData)
                    Catch ex As Exception
                        img = Nothing ' Default image
                    End Try
                End If

                Dim barcode As String = If(IsDBNull(dr("barcode")), String.Empty, dr("barcode").ToString())
                Dim itemDes As String = If(IsDBNull(dr("item_des")), String.Empty, dr("item_des").ToString())
                Dim category As String = If(IsDBNull(dr("Category")), String.Empty, dr("Category").ToString())
                Dim unit As String = If(IsDBNull(dr("unit")), String.Empty, dr("unit").ToString())
                Dim costprice As String = If(IsDBNull(dr("costprice")), "0.00", Convert.ToDecimal(dr("costprice")).ToString("#,##0.00"))
                Dim price As String = If(IsDBNull(dr("price")), "0.00", Convert.ToDecimal(dr("price")).ToString("#,##0.00"))

                dataprod.Rows.Add(i, dr("id").ToString(), img, barcode, itemDes, category, unit, costprice, price)
            End While

            For Each r As DataGridViewRow In dataprod.Rows
                r.Height = 40
            Next

            rc1.Text = "Record Found: (" & dataprod.RowCount & ")"
        Catch ex As Exception
            MsgBox("Error: " & ex.Message & vbCrLf & "Stack Trace: " & ex.StackTrace, vbCritical)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub





    Private Function ByteArrayToImage(ByVal byteArray As Byte()) As Image
        ' Check if byteArray is valid and has data
        If byteArray Is Nothing OrElse byteArray.Length = 0 Then
            Return Nothing
        End If

        Try
            Using ms As New MemoryStream(byteArray)
                Dim originalImage As System.Drawing.Image = System.Drawing.Image.FromStream(ms)

                ' Resize the image to specific dimensions, e.g., 100x130 pixels
                Dim resizedImage As New Bitmap(100, 130) ' Adjust the width and height as needed
                Using g As Graphics = Graphics.FromImage(resizedImage)
                    g.DrawImage(originalImage, 0, 0, 100, 130) ' Draw the image at specified size
                End Using

                Return resizedImage
            End Using
        Catch ex As ArgumentException
            ' Handle invalid image format
            Return Nothing
        End Try
    End Function


    Private Sub frmproductlists_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        With frmproduct
            .txtbarcode.Clear()
            .txtsales.Clear()
            .itemdes.Clear()

            .PictureBox1.Image = Nothing

            .btnsave.Visible = True
            .btnupdate.Visible = False
        End With
    End Sub

    Private Sub btnew_Click(sender As Object, e As EventArgs) Handles btnew.Click
        Dim frm As New frmproduct()
        frm.ActiveControl = frm.txtbarcode ' Set focus to txtbarcode
        frm.btnsave.Visible = True
        frm.ShowDialog()
    End Sub


    Sub SearchBarcode()
        Try
            Dim i As Integer = 0
            dataprod.Rows.Clear() ' Clear existing rows in DataGridView

            ' Open database connection
            If con.State = ConnectionState.Closed Then con.Open()

            ' Define query
            Dim query As String = "SELECT p.id, p.imagepath, p.barcode, p.item_des, " &
                                  "c.Category, u.unit, p.costprice, p.price " &
                                  "FROM tblproduct AS p " &
                                  "INNER JOIN tblcategory AS c ON p.cid = c.catID " &
                                  "INNER JOIN tblunit AS u ON p.uid = u.unitID " &
                                  "WHERE p.barcode LIKE @barcode or p.item_des LIKE @item_des"


            ' Create SQL command and parameters
            cmd = New SqlClient.SqlCommand(query, con)
            cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = "%" & Productsearch.Text.Trim() & "%"
            cmd.Parameters.Add("@item_des", SqlDbType.VarChar).Value = "%" & Productsearch.Text.Trim() & "%"

            ' Execute reader
            dr = cmd.ExecuteReader()

            ' Process data
            While dr.Read()
                i += 1


                Dim img As Image = Nothing
                If Not IsDBNull(dr("imagepath")) AndAlso dr("imagepath") IsNot Nothing Then
                    Try
                        Dim imgData As Byte() = DirectCast(dr("imagepath"), Byte())
                        If imgData.Length > 0 Then img = ByteArrayToImage(imgData)
                    Catch ex As Exception
                        img = Nothing ' Default image
                    End Try
                End If

                ' Handle costPrice and price
                Dim costPrice As Decimal = If(IsDBNull(dr("costprice")), 0, Convert.ToDecimal(dr("costprice")))
                Dim price As Decimal = If(IsDBNull(dr("price")), 0, Convert.ToDecimal(dr("price")))

                ' Add row to DataGridView
                dataprod.Rows.Add(i,
                                      dr("id").ToString(),
                                      img,
                                      dr("barcode").ToString(),
                                      dr("item_des").ToString(),
                                      dr("Category").ToString(),
                                      dr("unit").ToString(),
                                      costPrice.ToString("C2"),
                                      price.ToString("C2"))


            End While


            ' Adjust row height and auto-size columns
            For Each r As DataGridViewRow In dataprod.Rows
                r.Height = 40
            Next
            dataprod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            dr.Close()

        Catch ex As Exception
            ' Display error message
            MsgBox("Error: {ex.Message}", vbCritical, "Search Error")
        Finally
            ' Ensure connection is closed
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    'Private Sub Productsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles Productsearch.KeyDown
    '    SearchBarcode()

    'End Sub

    Private Sub ClearControls()
        ' Clear TextBox controls
        frmproduct.txtbarcode.Clear()
        frmproduct.itemdes.Clear()
        frmproduct.txtcost.Clear()
        frmproduct.txtsales.Clear()

        ' Clear ComboBox controls
        frmproduct.categorycbx.SelectedIndex = -1
        frmproduct.unitcbx.SelectedIndex = -1

        ' Clear PictureBox controls
        frmproduct.PictureBox1.Image = Nothing
        frmproduct.picbarcode.Text = String.Empty

        ' Clear any other controls if needed
        ' frmproduct.txtgeneric.Clear()
        ' frmproduct.brandcbx.SelectedIndex = -1
    End Sub


    'Private Sub PopulateCategoryAndUnitComboboxes()
    '    Try
    '        ' Open connection
    '        If con.State = ConnectionState.Closed Then
    '            con.Open()
    '        End If

    '        ' Populate Category Combobox
    '        cmd = New SqlCommand("SELECT catID, Category FROM tblcategory", con)
    '        Dim categoryReader As SqlDataReader = cmd.ExecuteReader()
    '        Dim categoryTable As New DataTable()
    '        categoryTable.Load(categoryReader)
    '        frmproduct.categorycbx.DataSource = categoryTable
    '        frmproduct.categorycbx.DisplayMember = "Category"  ' Display the name
    '        frmproduct.categorycbx.ValueMember = "catID"      ' Use the ID for the value
    '        categoryReader.Close()

    '        ' Populate Unit Combobox
    '        cmd = New SqlCommand("SELECT unitID, unit FROM tblunit", con)
    '        Dim unitReader As SqlDataReader = cmd.ExecuteReader()
    '        Dim unitTable As New DataTable()
    '        unitTable.Load(unitReader)
    '        frmproduct.unitcbx.DataSource = unitTable
    '        frmproduct.unitcbx.DisplayMember = "unit"  ' Display the name
    '        frmproduct.unitcbx.ValueMember = "unitID" ' Use the ID for the value
    '        unitReader.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub
    Private Sub FetchAndDisplayUserData(userId As Integer)
        ' Clear existing data in the controls
        ClearControls()

        Try
            ' Ensure the connection is closed before opening
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()

            ' Corrected query to fetch all user details with proper column names
            cmd = New SqlCommand("SELECT us.barcode, us.item_des, c.Category, u.unit, us.imagepath, us.barcode_image, us.costprice, us.cid, us.uid, us.price " & _
                                 "FROM tblproduct AS us " & _
                                 "INNER JOIN tblcategory AS c ON us.cid = c.catID " & _
                                 "INNER JOIN tblunit AS u ON us.uid = u.unitID " & _
                                 "WHERE us.id = @id", con)
            cmd.Parameters.AddWithValue("@id", userId)

            ' Execute the query and read the data
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                With frmproduct
                    ' Set the form controls with values from the database
                    .txtbarcode.Text = dr("barcode").ToString()
                    .itemdes.Text = dr("item_des").ToString()

                    ' Populate category and unit ComboBoxes
                    If frmproduct.categorycbx.Items.Count > 0 Then
                        .categorycbx.SelectedValue = dr("cid") ' Use catID to set the selected value
                    End If
                    If frmproduct.unitcbx.Items.Count > 0 Then
                        .unitcbx.SelectedValue = dr("uid") ' Use unitID to set the selected value
                    End If

                    ' Fetch selected category and unit IDs after assigning the value to ComboBoxes
                    Dim selectedCategoryID As Integer = CInt(frmproduct.categorycbx.SelectedValue)
                    Dim selectedUnitID As Integer = CInt(frmproduct.unitcbx.SelectedValue)

                    ' Display the selected IDs or use them in your logic
                    MessageBox.Show("Selected Category ID: " & selectedCategoryID)
                    MessageBox.Show("Selected Unit ID: " & selectedUnitID)

                    ' Set other form fields
                    .PictureBox1.Text = dr("imagepath").ToString()
                    .picbarcode.Text = dr("barcode_image").ToString()
                    .txtcost.Text = dr("costprice").ToString()
                    .txtsales.Text = dr("price").ToString()

                    ' Load image if available
                    If Not IsDBNull(dr("imagepath")) Then
                        Dim imgData As Byte() = DirectCast(dr("imagepath"), Byte())
                        Dim img As Image = ByteArrayToImage(imgData)
                        .PictureBox1.Image = img
                    Else
                        .PictureBox1.Image = Nothing ' Default or placeholder image
                    End If
                End With
            End If

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub




Private Sub dataprod_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataprod.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim colname As String = dataprod.Columns(e.ColumnIndex).Name

        If colname = "Edit" Then

            ' Get the product ID (assumed to be in the 1st column or change according to your column structure)
            Dim productId As Integer = Convert.ToInt32(dataprod.Rows(e.RowIndex).Cells(1).Value)

            ' Call FetchAndDisplayUserData to populate frmproduct with the selected product data
            FetchAndDisplayUserData(productId)

            ' Make the buttons visible for updating
            With frmproduct
                .btnupdate.Visible = True
                .btnsave.Visible = False
            End With

            ' Show the form
            frmproduct.ShowDialog()

        ElseIf colname = "Delete" Then
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cmd = New SqlCommand("DELETE FROM tblproduct WHERE id = @id", con)
                cmd.Parameters.AddWithValue("@id", dataprod.Rows(e.RowIndex).Cells(1).Value.ToString())
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Record has been successfully deleted.", vbInformation)
                prodrecord() ' Refresh the product records
            End If
        End If
    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Productsearch_TextChanged(sender As Object, e As EventArgs) Handles Productsearch.TextChanged
        SearchBarcode()

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class