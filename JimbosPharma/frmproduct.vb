Imports System.Data.SqlClient
Imports System.IO
Imports MessagingToolkit.Barcode


Public Class frmproduct
    Dim selectedBrandId As Integer
    Dim imagePath As String ' To store selected photo path

 


    Private Sub txtbarcode_TextChanged_1(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        Try

            If String.IsNullOrWhiteSpace(txtbarcode.Text) Then
                picbarcode.Image = Nothing
                Return
            End If



            Dim encoder As New BarcodeEncoder()
            encoder.IncludeLabel = True
            encoder.CustomLabel = txtbarcode.Text


            Dim barcodeImage As Bitmap = encoder.Encode(BarcodeFormat.Code128, txtbarcode.Text)

            picbarcode.Image = barcodeImage
        Catch ex As Exception

            picbarcode.Image = Nothing
            MsgBox("Error generating barcode: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtsales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsales.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnsave.PerformClick()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Sub clear()
        btnsave.Visible = True
        btnupdate.Visible = False
        txtbarcode.Focus()

        itemdes.Clear()
        txtbarcode.Clear()
        unitcbx.SelectedIndex = -1
        categorycbx.SelectedIndex = -1
        txtsales.Clear()
        txtcost.Clear()

        PictureBox1.Image = Nothing

    End Sub




    Private Function ValidateDuplicateEntry(query As String) As Boolean
        Try
            cmd = New SqlClient.SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@barcode", txtbarcode.Text.Trim()) ' 
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Return reader.HasRows ' Return true if the barcode exists
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical)
            Return False
        Finally
            con.Close()
        End Try
    End Function
  Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            ' Check if sales and cost values are numeric
            If Not IsNumeric(txtsales.Text) Or Not IsNumeric(txtcost.Text) Then
                MsgBox("Please enter valid numeric values for cost price and sales price.", vbExclamation)
                Return
            End If

            ' Check if the required fields are not empty
            If Walanglaman(txtbarcode) Then Return
            If Walanglaman(itemdes) Then Return
            If Walanglaman(txtsales) Then Return

            ' Validate barcode length (must be 13 digits)
            If txtbarcode.Text.Length <> 13 OrElse Not IsNumeric(txtbarcode.Text) Then
                MsgBox("Barcode must be a 13-digit numeric value.", vbExclamation)
                Return
            End If

            ' Validate for duplicate barcode entries
            If ValidateDuplicateEntry("SELECT * FROM tblproduct WHERE barcode = @barcode") Then
                MsgBox("A product with this barcode already exists.", vbExclamation)
                Return
            End If

            ' Confirm update action
            If MsgBox("Are you sure you want to update this product?", vbYesNo + vbQuestion) = vbNo Then
                Return
            End If

            ' Process barcode image if checkbox is checked
            Dim barcodeImageBytes As Byte() = Nothing
            If ckbarcode.Checked Then
                ' Generate and save the barcode image
                Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
                Dim barcodeImage As Bitmap = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code128, txtbarcode.Text))

                ' Save barcode image to a specific path
                Dim savePath As String = "C:\Users\danmi\OneDrive\Documents\Desktop\barcode product" ' Replace with your desired directory
                If Not Directory.Exists(savePath) Then
                    Directory.CreateDirectory(savePath) ' Create the directory if it doesn't exist
                End If
                Dim barcodeImagePath As String = Path.Combine(savePath, txtbarcode.Text & ".png")
                barcodeImage.Save(barcodeImagePath, System.Drawing.Imaging.ImageFormat.Png)

                ' Convert barcode image to byte array
                Using ms As New MemoryStream()
                    barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    barcodeImageBytes = ms.ToArray()
                End Using
            End If

            ' Convert product image to byte array (if provided)
            Dim imageBytes As Byte() = Nothing
            If Not String.IsNullOrEmpty(imagePath) Then
                imageBytes = File.ReadAllBytes(imagePath)
            End If

            ' Update product record in the database
            con.Open()
            Dim query As String = "UPDATE tblproduct SET barcode=@barcode, item_des=@item_des, price=@price, costprice=@costprice, barcode_image=@barcode_image, imagepath=@imagepath, uid=@uid WHERE id=@id"
            cmd = New SqlClient.SqlCommand(query, con)

            ' Set parameter values for the update
            With cmd
                .Parameters.AddWithValue("@barcode", txtbarcode.Text.Trim())
                .Parameters.AddWithValue("@item_des", itemdes.Text.Trim())

                ' Get the category and unit ID directly from the comboboxes or textboxes
                .Parameters.AddWithValue("@uid", If(String.IsNullOrWhiteSpace(unitid.Text), DBNull.Value, CInt(unitid.Text)))

                ' Convert sale price and cost price to Decimal
                Dim salePrice As Decimal
                If Decimal.TryParse(txtsales.Text.Replace("₱", "").Replace(",", "").Trim(), salePrice) Then
                    .Parameters.AddWithValue("@price", salePrice)
                Else
                    MessageBox.Show("Invalid sale price value. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    con.Close()
                    Exit Sub
                End If

                Dim costPrice As Decimal
                If Decimal.TryParse(txtcost.Text.Replace("₱", "").Replace(",", "").Trim(), costPrice) Then
                    .Parameters.AddWithValue("@costprice", costPrice)
                Else
                    MessageBox.Show("Invalid cost price value. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    con.Close()
                    Exit Sub
                End If

                .Parameters.Add("@barcode_image", SqlDbType.VarBinary).Value = If(barcodeImageBytes IsNot Nothing, barcodeImageBytes, DBNull.Value)
                .Parameters.Add("@imagepath", SqlDbType.VarBinary).Value = If(imageBytes IsNot Nothing, imageBytes, DBNull.Value)
                .Parameters.AddWithValue("@id", CInt(lblid.Text)) ' Assuming lblid contains the product ID to update
            End With

            ' Execute the update command
            cmd.ExecuteNonQuery()
            MsgBox("Record has been successfully updated.", vbInformation)
            con.Close()

            clear() ' Clear the form after update
            With frmproductlists
                .prodrecord() ' Refresh the product list
            End With
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical)
            If con.State = ConnectionState.Open Then
                con.Close() ' Close connection if open
            End If
        End Try
    End Sub



    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        openFileDialog.Title = "Select a Photo"

        If openFileDialog.ShowDialog = DialogResult.OK Then
            imagePath = openFileDialog.FileName

            PictureBox1.Image = Image.FromFile(imagePath)
        End If
    End Sub




    '                                                   FOR RETRIEVING IMAGE IN UPDATE
    Public Sub SetImageData(ByVal imageData As Byte())
        If imageData IsNot Nothing AndAlso imageData.Length > 0 Then
            Try
                Using ms As New MemoryStream(imageData)
                    PictureBox1.Image = Image.FromStream(ms)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading image: " & ex.Message)
                PictureBox1.Image = Nothing
            End Try
        Else

            PictureBox1.Image = Nothing
        End If
    End Sub




    'Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
    '    Try
    '        If MsgBox("Are you sure you want to update this Record?", vbYesNo + vbQuestion) = vbYes Then
    '            Dim imageBytes As Byte() = Nothing
    '            If Not String.IsNullOrEmpty(imagePath) Then
    '                imageBytes = File.ReadAllBytes(imagePath)
    '            End If



    '            Dim brandId, genericId, classId, formulId, dosId, unitIds As Integer

    '            If Not Integer.TryParse(lblbrand.Text, brandId) Then
    '                MsgBox("Brand ID is not a valid number.", vbExclamation)
    '                Exit Sub
    '            End If

    '            If Not Integer.TryParse(lblgeneric.Text, genericId) Then
    '                MsgBox("Generic ID is not a valid number.", vbExclamation)
    '                Exit Sub
    '            End If

    '            If Not Integer.TryParse(lblclass.Text, classId) Then
    '                MsgBox("Category ID is not a valid number.", vbExclamation)
    '                Exit Sub
    '            End If

    '            If Not Integer.TryParse(lblformul.Text, formulId) Then
    '                MsgBox("Formulation ID is not a valid number.", vbExclamation)
    '                Exit Sub
    '            End If

    '            If Not Integer.TryParse(lbldos.Text, dosId) Then
    '                MsgBox("Dosage ID is not a valid number.", vbExclamation)
    '                Exit Sub
    '            End If

    '            If Not Integer.TryParse(unitid.Text, unitIds) Then
    '                MsgBox("Unit ID is not a valid number.", vbExclamation)
    '                Exit Sub
    '            End If

    '            con.Open()
    '            cmd = New SqlClient.SqlCommand("UPDATE tblproduct SET barcode=@barcode, item_des=@item_des, bid=@bid, gid=@gid, cid=@cid, fid=@fid, did=@did, price=@price, imagepath=@imagepath, uid=@uid WHERE id=@id", con)

    '            With cmd
    '                .Parameters.AddWithValue("@barcode", txtbarcode.Text)
    '                .Parameters.AddWithValue("@item_des", itemdes.Text)
    '                .Parameters.AddWithValue("@bid", brandId)
    '                .Parameters.AddWithValue("@gid", genericId)
    '                .Parameters.AddWithValue("@cid", classId)
    '                .Parameters.AddWithValue("@fid", formulId)
    '                .Parameters.AddWithValue("@did", dosId)
    '                .Parameters.AddWithValue("@uid", unitIds)
    '                .Parameters.AddWithValue("@price", CDbl(txtprice.Text))
    '                .Parameters.AddWithValue("@id", CInt(lblid.Text))

    '                If imageBytes IsNot Nothing Then
    '                    .Parameters.Add("@imagepath", SqlDbType.VarBinary).Value = imageBytes
    '                Else
    '                    .Parameters.Add("@imagepath", SqlDbType.VarBinary).Value = DBNull.Value
    '                End If

    '                .ExecuteNonQuery()
    '            End With

    '            MsgBox("Product has been successfully updated.", vbInformation)
    '            con.Close()
    '            clear()

    '            With frmproductlist
    '                .prodrecord() ' for REFRESH
    '            End With
    '        End If

    '    Catch ex As Exception
    '        If con.State = ConnectionState.Open Then
    '            con.Close() ' Only close the connection if it is open
    '        End If
    '        MsgBox(ex.Message, vbCritical)
    '    End Try
    'End Sub



    'Private Sub txtqty_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        btnsave.PerformClick()
    '    End If
    'End Sub




    Private Sub SearchProductByBarcode(barcode As String)
        Dim query As String = "SELECT * FROM tblproduct WHERE barcode = @barcode"

        Using cmd As New SqlClient.SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@barcode", barcode)
            con.Open()

            Using reader As SqlClient.SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        ' KAPAG MERON NANG BARCODE SCANNER
                        itemdes.Text = reader("item_des").ToString()
                        txtsales.Text = reader("price").ToString()
                    End While
                Else
                    MsgBox("Product not found.", vbExclamation)
                End If
            End Using

            con.Close()
        End Using
    End Sub


    Private Function GenerateUniqueBarcode() As String
        Dim timestamp As String = DateTime.Now.ToString("yyyyMMddHHmmssfff")
        Dim random As New Random()

        ' Generate a 12-digit random number as a string
        Dim randomPart As String = ""
        For i As Integer = 1 To 12
            randomPart &= random.Next(0, 10).ToString()  ' Append a random digit (0-9)
        Next

        ' Calculate the check digit for EAN-13
        Dim checkDigit As Integer = CalculateEAN13CheckDigit(randomPart)

        ' Combine the random 12 digits with the check digit
        Dim uniqueBarcode As String = randomPart & checkDigit.ToString()

        Return uniqueBarcode
    End Function

    ' Function to calculate the check digit for EAN-13 barcode
    Private Function CalculateEAN13CheckDigit(barcodeWithoutCheckDigit As String) As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To barcodeWithoutCheckDigit.Length - 1
            Dim digit As Integer = Convert.ToInt32(barcodeWithoutCheckDigit(i).ToString())
            ' Odd positions (1, 3, 5, 7, 9, 11) are multiplied by 1, even positions by 3
            If i Mod 2 = 0 Then
                sum += digit
            Else
                sum += digit * 3
            End If
        Next

        ' Calculate the modulo 10 of the sum
        Dim mod10 As Integer = sum Mod 10

        ' If the modulo is 0, the check digit is 0, otherwise, the check digit is 10 - mod10
        If mod10 = 0 Then
            Return 0
        Else
            Return 10 - mod10
        End If
    End Function












    '                                           retrieving the id when we selecte in index

 
    Private Sub categorycbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles categorycbx.SelectedIndexChanged
        If categorycbx.SelectedIndex <> -1 Then
            Try
                con.Open()
                cmd = New SqlClient.SqlCommand("Select * from tblcategory where Category = @Category", con)
                cmd.Parameters.AddWithValue("@Category", categorycbx.SelectedItem.ToString())
                dr = cmd.ExecuteReader
                If dr.Read() Then
                    lblclass.Text = dr("catID").ToString()
                Else
                    lblclass.Text = String.Empty
                End If
            Catch ex As Exception
                ' Handle the exception, if needed
            Finally
                If dr IsNot Nothing Then dr.Close()
                If cmd IsNot Nothing Then cmd.Dispose() ' Dispose the command to release resources
                If con.State = ConnectionState.Open Then con.Close() ' Close the connection
            End Try
        End If
    End Sub


    Private Sub unitcbx_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles unitcbx.SelectedIndexChanged
        If unitcbx.SelectedIndex <> -1 Then
            Try
                con.Open()
                cmd = New SqlClient.SqlCommand("Select * from tblunit where unit = @unit", con)
                cmd.Parameters.AddWithValue("@unit", unitcbx.SelectedItem.ToString())
                dr = cmd.ExecuteReader
                If dr.Read() Then
                    unitid.Text = dr("unitID").ToString()
                Else
                    unitid.Text = String.Empty
                End If
            Catch ex As Exception
                ' Handle the exception, if needed
            Finally
                If dr IsNot Nothing Then dr.Close()
                If cmd IsNot Nothing Then cmd.Dispose() ' Dispose the command to release resources
                If con.State = ConnectionState.Open Then con.Close() ' Close the connection
            End Try
        End If
    End Sub





    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub




    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub



    Private Sub frmproduct_Load(sender As Object, e As EventArgs) Handles Me.Load
        dropdowncategory(Me)
        dropdownunit(Me)
        'txtbarcode.Text = GenerateUniqueBarcode() ' Generate a unique barcode if none is provided


        If String.IsNullOrWhiteSpace(txtcost.Text) Then
            txtcost.Text = "₱"
            txtcost.SelectionStart = txtcost.Text.Length ' Position cursor at the end
        End If

        If String.IsNullOrWhiteSpace(txtsales.Text) Then
            txtsales.Text = "₱"
            txtsales.SelectionStart = txtsales.Text.Length ' Position cursor at the end
        End If

        '                                           TO MAKE WHITE SPACE THE COMBOBOX
        categorycbx.SelectedIndex = -1
        unitcbx.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If String.IsNullOrWhiteSpace(txtbarcode.Text) Then
            txtbarcode.Text = GenerateUniqueBarcode()
        Else
            MsgBox("Barcode already exists in the TextBox.", vbInformation)
        End If
    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()

    End Sub

    Private Sub txtcost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcost.KeyPress
        ' Allow only digits, one decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "." AndAlso txtcost.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmproduct_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        ' Apply formatting when the textbox loses focus
        Dim value As Decimal
        If Decimal.TryParse(txtcost.Text.Replace("₱", "").Replace(",", "").Trim(), value) Then
            ' Format the text with the peso sign and two decimal places
            txtcost.Text = "₱" & value.ToString("#,##0.00")
        Else
            ' Clear the text if the input is invalid
            txtcost.Clear()
        End If

        If Decimal.TryParse(txtsales.Text.Replace("₱", "").Replace(",", "").Trim(), value) Then
            ' Format the text with the peso sign and two decimal places
            txtsales.Text = "₱" & value.ToString("#,##0.00")
        Else
            ' Clear the text if the input is invalid
            txtsales.Clear()
        End If
    End Sub


    Private Sub txtsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsales.KeyPress
        ' Allow only digits, one decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "." AndAlso txtsales.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If Not IsNumeric(txtsales.Text) Or Not IsNumeric(txtcost.Text) Then
                MsgBox("please enter valid numeric values for cost price and price.", vbExclamation)
                Return
            End If

            If Walanglaman(txtbarcode) Then Return
            If Walanglaman(itemdes) Then Return
            'If Walanglaman(brandcbx) Then Return
            'If Walanglaman(gencbx) Then Return
            'If Walanglaman(categorycbx) Then Return
            'If Walanglaman(formucbx) Then Return
            'If Walanglaman(dosagecbx) Then Return
            If Walanglaman(txtsales) Then Return
            'If Walanglaman(unitcbx) Then Return

            '' Ensure barcode is provided
            'If String.IsNullOrWhiteSpace(txtbarcode.Text) Then
            '    txtbarcode.Text = GenerateUniqueBarcode() ' Generate a unique barcode if none is provided
            'End If

            ' Validate barcode format
            If txtbarcode.Text.Length <> 13 OrElse Not IsNumeric(txtbarcode.Text) Then
                MsgBox("Barcode must be a 13-digit numeric value.", vbExclamation)
                Return
            End If

            ' Validate for duplicate barcode entries
            If ValidateDuplicateEntry("SELECT * FROM tblproduct WHERE barcode = @barcode") Then
                MsgBox("A product with this barcode already exists.", vbExclamation)
                Return
            End If

            ' Confirm save action
            If MsgBox("Are you sure you want to save this Product?", vbYesNo + vbQuestion) = MsgBoxResult.No Then Return




            ' Process barcode image only if the checkbox is checked
            Dim barcodeImageBytes As Byte() = Nothing
            If ckbarcode.Checked Then
                ' Generate and save the barcode image
                Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
                Dim barcodeImage As Bitmap = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code128, txtbarcode.Text))




                ' Save barcode image to a specific path
                Dim savePath As String = "C:\Users\danmi\OneDrive\Documents\Desktop\barcode product" ' Replace with your desired directory
                If Not Directory.Exists(savePath) Then
                    Directory.CreateDirectory(savePath) ' Create the directory if it doesn't exist
                End If
                Dim barcodeImagePath As String = Path.Combine(savePath, txtbarcode.Text & ".png")
                barcodeImage.Save(barcodeImagePath, System.Drawing.Imaging.ImageFormat.Png)



                ' Convert the barcode image to byte array for database storage
                Using ms As New MemoryStream()
                    barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    barcodeImageBytes = ms.ToArray()
                End Using
            End If



            ' Convert product image to byte array, or set to DBNull if imagePath is empty
            Dim imageBytes As Byte() = Nothing
            If Not String.IsNullOrEmpty(imagePath) Then
                imageBytes = File.ReadAllBytes(imagePath)
            End If

            ' Insert data into the database
            con.Open()
            Dim query As String = "INSERT INTO tblproduct (barcode, item_des, cid, price, costprice, barcode_image, imagepath, uid) " &
                                  "VALUES (@barcode, @item_des, @cid, @price, @costprice, @barcode_image, @imagepath, @uid)"
            cmd = New SqlClient.SqlCommand(query, con)

            ' Set parameter values
            With cmd
                .Parameters.AddWithValue("@barcode", txtbarcode.Text.Trim())
                .Parameters.AddWithValue("@item_des", itemdes.Text.Trim())
                .Parameters.AddWithValue("@cid", If(String.IsNullOrWhiteSpace(lblclass.Text), DBNull.Value, CInt(lblclass.Text)))

                ' Convert sale price and cost price to Decimal, removing any formatting
                Dim salePrice As Decimal
                If Decimal.TryParse(txtsales.Text.Replace("₱", "").Replace(",", "").Trim(), salePrice) Then
                    .Parameters.AddWithValue("@price", salePrice)
                Else
                    MessageBox.Show("Invalid sale price value. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    con.Close()
                    Exit Sub
                End If

                Dim costPrice As Decimal
                If Decimal.TryParse(txtcost.Text.Replace("₱", "").Replace(",", "").Trim(), costPrice) Then
                    .Parameters.AddWithValue("@costprice", costPrice)
                Else
                    MessageBox.Show("Invalid cost price value. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    con.Close()
                    Exit Sub
                End If

                .Parameters.Add("@barcode_image", SqlDbType.VarBinary).Value = If(barcodeImageBytes IsNot Nothing, barcodeImageBytes, DBNull.Value)
                .Parameters.Add("@imagepath", SqlDbType.VarBinary).Value = If(imageBytes IsNot Nothing, imageBytes, DBNull.Value)
                .Parameters.AddWithValue("@uid", If(String.IsNullOrWhiteSpace(unitid.Text), DBNull.Value, CInt(unitid.Text)))
            End With

            cmd.ExecuteNonQuery()
            MsgBox("Record has been successfully saved.", vbInformation)
            txtbarcode.Refresh()
            con.Close()

            clear()
            With frmproductlists
                .prodrecord()
            End With
            'Me.Close()




        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical)
            con.Close()
        End Try
    End Sub
End Class











'Private Sub txtbarcode_Leave(sender As Object, e As EventArgs) Handles txtbarcode.Leave

'    If String.IsNullOrWhiteSpace(txtbarcode.Text) Then

'        txtbarcode.BackColor = Color.LightCoral
'        MsgBox("Barcode field cannot be empty!", MsgBoxStyle.Exclamation)
'    Else

'        txtbarcode.BackColor = Color.White
'    End If
'End Sub










''                                                                                TEXT CHANGE IF WE TRACK IN QUERY

''Private Sub txtbrand_TextChanged(sender As Object, e As EventArgs) Handles txtbrand.TextChanged
''    If Not String.IsNullOrEmpty(txtbrand.Text) Then
''        Try
''            con.Open()
''            cmd = New SqlClient.SqlCommand("SELECT brandID FROM tblbrand WHERE brand = @brand", con)
''            cmd.Parameters.AddWithValue("@brand", txtbrand.Text)

''            dr = cmd.ExecuteReader()
''            If dr.Read() Then
''                lblbrand.Text = dr("brandID").ToString()
''            Else
''                lblbrand.Text = String.Empty ' Clear label if no match is found
''            End If
''        Catch ex As Exception
''            MessageBox.Show("Error retrieving brand ID: " & ex.Message)
''        Finally
''            If dr IsNot Nothing Then dr.Close()
''            If cmd IsNot Nothing Then cmd.Dispose()
''            If con.State = ConnectionState.Open Then con.Close()
''        End Try
''    Else
''        lblbrand.Text = String.Empty ' Clear label if text is empty
''    End If
''End Sub


'Private Sub txtgeneric_TextChanged(sender As Object, e As EventArgs) Handles txtgeneric.TextChanged

'    If Not String.IsNullOrEmpty(txtgeneric.Text) Then
'        Try
'            con.Open()
'            cmd = New SqlClient.SqlCommand("SELECT genericID FROM tblgeneric WHERE generic = @generic", con)
'            cmd.Parameters.AddWithValue("@generic", txtgeneric.Text)

'            dr = cmd.ExecuteReader()
'            If dr.Read() Then
'                lblgeneric.Text = dr("genericID").ToString()
'            Else
'                lblgeneric.Text = String.Empty ' Clear label if no match is found
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Error retrieving generic ID: " & ex.Message)
'        Finally
'            If dr IsNot Nothing Then dr.Close()
'            If cmd IsNot Nothing Then cmd.Dispose()
'            If con.State = ConnectionState.Open Then con.Close()
'        End Try
'    Else
'        lblgeneric.Text = String.Empty ' Clear label if text is empty
'    End If
'End Sub




'Private Sub txtdosage_TextChanged(sender As Object, e As EventArgs) Handles txtdosage.TextChanged

'    If Not String.IsNullOrEmpty(txtdosage.Text) Then
'        Try
'            con.Open()
'            cmd = New SqlClient.SqlCommand("SELECT dosageID FROM tbldosage WHERE Dosage = @Dosage", con)
'            cmd.Parameters.AddWithValue("@Dosage", txtdosage.Text)

'            dr = cmd.ExecuteReader()
'            If dr.Read() Then
'                lbldos.Text = dr("dosageID").ToString()
'            Else
'                lbldos.Text = String.Empty ' Clear label if no match is found
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Error retrieving Dosage ID: " & ex.Message)
'        Finally
'            If dr IsNot Nothing Then dr.Close()
'            If cmd IsNot Nothing Then cmd.Dispose()
'            If con.State = ConnectionState.Open Then con.Close()
'        End Try
'    Else
'        lbldos.Text = String.Empty ' Clear label if text is empty
'    End If
'End Sub


'Private Sub txtcategory_TextChanged(sender As Object, e As EventArgs) Handles txtcategory.TextChanged

'    If Not String.IsNullOrEmpty(txtcategory.Text) Then
'        Try
'            con.Open()
'            cmd = New SqlClient.SqlCommand("SELECT catID FROM tblcategory WHERE Category = @Category", con)
'            cmd.Parameters.AddWithValue("@Category", txtcategory.Text)

'            dr = cmd.ExecuteReader()
'            If dr.Read() Then
'                lblclass.Text = dr("catID").ToString()
'            Else
'                lblclass.Text = String.Empty ' Clear label if no match is found
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Error retrieving Category ID: " & ex.Message)
'        Finally
'            If dr IsNot Nothing Then dr.Close()
'            If cmd IsNot Nothing Then cmd.Dispose()
'            If con.State = ConnectionState.Open Then con.Close()
'        End Try
'    Else
'        lblclass.Text = String.Empty ' Clear label if text is empty
'    End If


'End Sub



'Private Sub txtformu_TextChanged(sender As Object, e As EventArgs) Handles txtformu.TextChanged

'    If Not String.IsNullOrEmpty(txtformu.Text) Then
'        Try
'            con.Open()
'            cmd = New SqlClient.SqlCommand("SELECT formID FROM tblformulations WHERE Formulations = @Formulations", con)
'            cmd.Parameters.AddWithValue("@Formulations", txtformu.Text)

'            dr = cmd.ExecuteReader()
'            If dr.Read() Then
'                lblformul.Text = dr("formID").ToString()
'            Else
'                lblformul.Text = String.Empty ' Clear label if no match is found
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Error retrieving form ID: " & ex.Message)
'        Finally
'            If dr IsNot Nothing Then dr.Close()
'            If cmd IsNot Nothing Then cmd.Dispose()
'            If con.State = ConnectionState.Open Then con.Close()
'        End Try
'    Else
'        lblformul.Text = String.Empty ' Clear label if text is empty
'    End If
'End Sub


'Private Sub txtunit_TextChanged(sender As Object, e As EventArgs) Handles txtunit.TextChanged

'    If Not String.IsNullOrEmpty(txtunit.Text) Then
'        Try
'            con.Open()
'            cmd = New SqlClient.SqlCommand("SELECT unitID FROM tblunit WHERE unit = @unit", con)
'            cmd.Parameters.AddWithValue("@unit", txtunit.Text)

'            dr = cmd.ExecuteReader()
'            If dr.Read() Then
'                unitid.Text = dr("unitID").ToString()
'            Else
'                unitid.Text = String.Empty ' Clear label if no match is found
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Error retrieving unit ID: " & ex.Message)
'        Finally
'            If dr IsNot Nothing Then dr.Close()
'            If cmd IsNot Nothing Then cmd.Dispose()
'            If con.State = ConnectionState.Open Then con.Close()
'        End Try
'    Else
'        unitid.Text = String.Empty ' Clear label if text is empty
'    End If
'End Sub
