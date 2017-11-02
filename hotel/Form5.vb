Imports System.Data.Odbc
Public Class Form5
    Dim lm As Integer
    Dim hrg, subtotl, diskon, hrgdisk, byrkedai, totl As Double
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        da = New OdbcDataAdapter("select * from transaksi", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "transaksi")
        DataGridView1.DataSource = (ds.Tables("transaksi"))
        kon.Close()
        kombo1()
        kombo2()
        kombo3()
        kombo4()
    End Sub
    Sub kombo1()
        koneksi()
        cm = New OdbcCommand("select * from pelanggan", kon)
        rd = cm.ExecuteReader
        ComboBox1.Items.Clear()
        While rd.Read
            ComboBox1.Items.Add(rd.GetValue(1))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Sub kombo2()
        koneksi()
        cm = New OdbcCommand("select * from kamar", kon)
        rd = cm.ExecuteReader
        ComboBox2.Items.Clear()
        While rd.Read
            ComboBox2.Items.Add(rd.GetValue(0))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Sub kombo3()
        koneksi()
        cm = New OdbcCommand("select * from disk", kon)
        rd = cm.ExecuteReader
        ComboBox3.Items.Clear()
        While rd.Read
            ComboBox3.Items.Add(rd.GetValue(1))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Sub kombo4()
        koneksi()
        cm = New OdbcCommand("select * from kedai", kon)
        rd = cm.ExecuteReader
        ComboBox4.Items.Clear()
        While rd.Read
            ComboBox4.Items.Add(rd.GetValue(0))
        End While
        rd.Close()
        kon.Close()
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        koneksi()
        cm = New OdbcCommand("select namakamar from kamar where idkamar='" + ComboBox2.Text + "'", kon)
        TextBox2.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
        koneksi()
        cm = New OdbcCommand("select harga from kamar where idkamar='" + ComboBox2.Text + "'", kon)
        TextBox4.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        lm = Val(TextBox3.Text)
        hrg = Val(TextBox4.Text)
        subtotl = lm * hrg
        TextBox5.Text = subtotl
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        diskon = Val(ComboBox3.Text)
        hrgdisk = diskon * subtotl / 100
        TextBox6.Text = hrgdisk
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        koneksi()
        cm = New OdbcCommand("select bayarkedai from kedai where idkedai='" + ComboBox4.Text + "'", kon)
        TextBox7.Text = cm.ExecuteScalar
        rd.Close()
        kon.Close()
    End Sub
    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        totl = (subtotl - hrgdisk) + Val(TextBox7.Text) + Val(TextBox8.Text)
        TextBox9.Text = totl
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        koneksi()
        cm = New OdbcCommand("insert into transaksi(nokuitansi,namapelanggan,idkamar,namakamar,tanggalmasuk,tanggalkeluar,lama,harga,subtotal,hargadiskon,kedai,lain,total) values('" + TextBox1.Text + "','" + ComboBox1.Text + "','" + ComboBox2.Text + "','" + TextBox2.Text + "','" + DateTimePicker1.Value + "','" + DateTimePicker2.Value + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "')", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Insert Gagal")
        End If
        kon.Close()
        Form5_Load(sender, e)
        bersih()
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        ComboBox1.Text = "Pilih"
        ComboBox2.Text = "Pilih"
        ComboBox3.Text = "Pilih"
        ComboBox4.Text = "Pilih"
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Hide()
        Form6.Show()
    End Sub
End Class