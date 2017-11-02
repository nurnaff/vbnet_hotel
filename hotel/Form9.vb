Imports System.Data.Odbc
Public Class Form9
    Dim hrg, byk, subtotl As Double
    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kombo1()
        kombo2()
        SetListViewColumn()
    End Sub
    Sub kombo1()
        koneksi()
        cm = New OdbcCommand("select * from pelanggan", kon)
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
        cm = New OdbcCommand("select * from menu", kon)
        rd = cm.ExecuteReader
        ComboBox2.Items.Clear()
        While rd.Read
            ComboBox2.Items.Add(rd.GetValue(0))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()
        cm = New OdbcCommand("select namapelanggan from pelanggan where idpelanggan='" + ComboBox1.Text + "'", kon)
        TextBox2.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        koneksi()
        cm = New OdbcCommand("select namamenu from menu where idmenu='" + ComboBox2.Text + "'", kon)
        TextBox3.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
        koneksi()
        cm = New OdbcCommand("select harga from menu where idmenu='" + ComboBox2.Text + "'", kon)
        TextBox7.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
    End Sub
    Private Sub SetListViewColumn()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Id Menu", 105, HorizontalAlignment.Center)
            .Columns.Add("Nama Menu", 175, HorizontalAlignment.Center)
            .Columns.Add("Harga", 125, HorizontalAlignment.Right)
            .Columns.Add("Banyak", 80, HorizontalAlignment.Center)
            .Columns.Add("SubTotal", 125, HorizontalAlignment.Right)
        End With
    End Sub
    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        hrg = Val(TextBox7.Text)
        byk = Val(TextBox8.Text)
        subtotl = hrg * byk
        TextBox4.Text = subtotl
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim add As Boolean = False
        Dim i As Integer
        For i = 0 To ListView1.Items.Count - 1
            If (ListView1.Items.Item(i).SubItems(0).Text).ToString = ComboBox2.Text.ToUpper Then
                ListView1.Items.Item(i).SubItems(1).Text = TextBox3.Text
                ListView1.Items.Item(i).SubItems(2).Text = Val(TextBox7.Text)
                ListView1.Items.Item(i).SubItems(3).Text += CInt(TextBox8.Text)
                ListView1.Items.Item(i).SubItems(4).Text = Val(TextBox4.Text)
                Dim total As Double
                For a As Integer = 0 To ListView1.Items.Count - 1
                    total += CDbl(ListView1.Items(a).SubItems(4).Text).ToString
                Next
                TextBox9.Text = Val(total)
                ComboBox2.Text = "Pilih"
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                ComboBox2.Focus()
                add = True
            Else
                add = False
            End If
        Next
        If add = False Then
            Dim MyItem As New ListViewItem(ComboBox2.Text.ToUpper)
            MyItem.SubItems.Add(TextBox3.Text)
            MyItem.SubItems.Add(TextBox7.Text)
            MyItem.SubItems.Add(CDbl(TextBox8.Text))
            MyItem.SubItems.Add(TextBox4.Text)
            ListView1.Items.Add(MyItem)
            Dim total As Double
            For a As Integer = 0 To ListView1.Items.Count - 1
                total += CDbl(ListView1.Items(a).SubItems(4).Text).ToString
            Next
            TextBox9.Text = Val(total)
            ComboBox2.Text = "Pilih"
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            ComboBox2.Focus()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        koneksi()
        If Not TextBox1.TextLength = 0 Then
            cm = New OdbcCommand("insert into kedai(idkedai,idpelanggan,tanggal,bayarkedai) values('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & DateTimePicker1.Value & "','" & TextBox9.Text & "')", kon)
            cm.ExecuteNonQuery()
            For i As Integer = 0 To ListView1.Items.Count - 1
                cm = New OdbcCommand("insert into cafe(idkedai,idmenu,namamenu,harga,banyak,subtotal) values('" & TextBox1.Text & "','" & ListView1.Items(i).SubItems(0).Text.ToString & "','" & ListView1.Items(i).SubItems(1).Text.ToString & "','" & CDbl(ListView1.Items(i).SubItems(2).Text.ToString) & "','" & CDbl(ListView1.Items(i).SubItems(3).Text.ToString) & "','" & CDbl(ListView1.Items(i).SubItems(4).Text.ToString) & "')", kon)
                cm.ExecuteNonQuery()
            Next i
        End If
        kon.Close()
        bersih()
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        ComboBox1.Text = "Pilih"
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = "Pilih"
        TextBox4.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ListView1.Items.Clear()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Hide()
        Form10.Show()
    End Sub
End Class