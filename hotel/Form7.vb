Imports System.Data.Odbc
Public Class Form7
    Dim lm As Integer
    Dim hrg, subtotl, hrgakh, byr, diskon, hrgdisk, byrkedai, ln As Double
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()
        cm = New OdbcCommand("select namakamar from kamar where idkamar='" + ComboBox1.Text + "'", kon)
        TextBox2.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
        koneksi()
        cm = New OdbcCommand("select harga from kamar where idkamar='" + ComboBox1.Text + "'", kon)
        TextBox3.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
    End Sub
    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kombo1()
        kombo2()
        kombo3()
        SetListViewColumn()
    End Sub
    Sub kombo1()
        koneksi()
        cm = New OdbcCommand("select * from kamar", kon)
        rd = cm.ExecuteReader
        ComboBox1.Items.Clear()
        While rd.Read
            ComboBox1.Items.Add(rd.GetValue(0))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Sub kombo2()
        koneksi()
        cm = New OdbcCommand("select * from disk", kon)
        rd = cm.ExecuteReader
        ComboBox2.Items.Clear()
        While rd.Read
            ComboBox2.Items.Add(rd.GetValue(1))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Sub kombo3()
        koneksi()
        cm = New OdbcCommand("select * from kedai", kon)
        rd = cm.ExecuteReader
        ComboBox3.Items.Clear()
        While rd.Read
            ComboBox3.Items.Add(rd.GetValue(0))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        ComboBox1.Text = "Pilih"
        ComboBox2.Text = "Pilih"
        ComboBox3.Text = "Pilih"
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ListView1.Items.Clear()
    End Sub
    Private Sub SetListViewColumn()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Id Kamar", 85, HorizontalAlignment.Center)
            .Columns.Add("Nama Kamar", 125, HorizontalAlignment.Center)
            .Columns.Add("Harga Kamar", 105, HorizontalAlignment.Right)
            .Columns.Add("Lama", 55, HorizontalAlignment.Center)
            .Columns.Add("Harga Diskon", 105, HorizontalAlignment.Right)
            .Columns.Add("Harga Kedai", 105, HorizontalAlignment.Right)
            .Columns.Add("Lain", 105, HorizontalAlignment.Right)
            .Columns.Add("SubTotal", 105, HorizontalAlignment.Right)
        End With
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        hrg = Val(TextBox3.Text)
        diskon = Val(ComboBox2.Text)
        hrgdisk = diskon * hrg / 100
        TextBox5.Text = hrgdisk
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        koneksi()
        cm = New OdbcCommand("select bayarkedai from kedai where idkedai='" + ComboBox3.Text + "'", kon)
        TextBox6.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        lm = Val(TextBox4.Text)
        hrgdisk = Val(TextBox5.Text)
        hrg = Val(TextBox3.Text)
        hrgakh = hrg - hrgdisk
        byr = lm * hrgakh
    End Sub
    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        byrkedai = Val(TextBox6.Text)
        ln = Val(TextBox7.Text)
        subtotl = byr + byrkedai + ln
        TextBox8.Text = subtotl
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim add As Boolean = False
        Dim i As Integer
        For i = 0 To ListView1.Items.Count - 1
            If (ListView1.Items.Item(i).SubItems(0).Text).ToString = ComboBox1.Text.ToUpper Then
                ListView1.Items.Item(i).SubItems(1).Text = TextBox2.Text
                ListView1.Items.Item(i).SubItems(2).Text = Val(TextBox3.Text)
                ListView1.Items.Item(i).SubItems(3).Text += CInt(TextBox4.Text)
                ListView1.Items.Item(i).SubItems(4).Text = Val(TextBox5.Text)
                ListView1.Items.Item(i).SubItems(5).Text = Val(TextBox6.Text)
                ListView1.Items.Item(i).SubItems(6).Text = Val(TextBox7.Text)
                ListView1.Items.Item(i).SubItems(7).Text = Val(TextBox8.Text)
                Dim total As Double
                For a As Integer = 0 To ListView1.Items.Count - 1
                    total += CDbl(ListView1.Items(a).SubItems(7).Text).ToString
                Next
                TextBox9.Text = Val(total)
                ComboBox1.Text = "Pilih"
                ComboBox2.Text = "Pilih"
                ComboBox3.Text = "Pilih"
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                ComboBox1.Focus()
                add = True
            Else
                add = False
            End If
        Next
        If add = False Then
            Dim MyItem As New ListViewItem(ComboBox1.Text.ToUpper)
            MyItem.SubItems.Add(TextBox2.Text)
            MyItem.SubItems.Add(TextBox3.Text)
            MyItem.SubItems.Add(CDbl(TextBox4.Text))
            MyItem.SubItems.Add(TextBox5.Text)
            MyItem.SubItems.Add(TextBox6.Text)
            MyItem.SubItems.Add(TextBox7.Text)
            MyItem.SubItems.Add(TextBox8.Text)
            ListView1.Items.Add(MyItem)
            Dim total As Double
            For a As Integer = 0 To ListView1.Items.Count - 1
                total += CDbl(ListView1.Items(a).SubItems(7).Text).ToString
            Next
            TextBox9.Text = Val(total)
            ComboBox1.Text = "Pilih"
            ComboBox2.Text = "Pilih"
            ComboBox3.Text = "Pilih"
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            ComboBox1.Focus()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        koneksi()
        If Not TextBox1.TextLength = 0 Then
            For i As Integer = 0 To ListView1.Items.Count - 1
                cm = New OdbcCommand("insert into grup(notrans,idkamar,namakamar,lama,harga,hargadiskon,kedai,lain,subtotal,total) values('" & TextBox1.Text & "','" & ListView1.Items(i).SubItems(0).Text.ToString & "','" & ListView1.Items(i).SubItems(1).Text.ToString & "','" & CInt(ListView1.Items(i).SubItems(3).Text.ToString) & "','" & CDbl(ListView1.Items(i).SubItems(2).Text.ToString) & "','" & CDbl(ListView1.Items(i).SubItems(4).Text.ToString) & "','" & CDbl(ListView1.Items(i).SubItems(5).Text.ToString) & "','" & CDbl(ListView1.Items(i).SubItems(6).Text.ToString) & "','" & CDbl(ListView1.Items(i).SubItems(7).Text.ToString) & "','" & Val(TextBox9.Text) & "')", kon)
                cm.ExecuteNonQuery()
            Next i
        End If
        kon.Close()
        bersih()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Hide()
        Form8.Show()
    End Sub
End Class