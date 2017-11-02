Imports System.Data.Odbc
Public Class Form2
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        da = New OdbcDataAdapter("select * from pelanggan", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "pelanggan")
        DataGridView1.DataSource = (ds.Tables("pelanggan"))
        kon.Close()
    End Sub
    Sub tutup(ByVal akt As Boolean)
        TextBox1.Enabled = akt
        TextBox2.Enabled = akt
        TextBox3.Enabled = akt
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tutup(True)
        TextBox1.Focus()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        koneksi()
        cm = New OdbcCommand("insert into pelanggan(idpelanggan,namapelanggan,alamat) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Insert Gagal")
        End If
        kon.Close()
        Form2_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        koneksi()
        cm = New OdbcCommand("update pelanggan set namapelanggan='" + TextBox2.Text + "',alamat='" + TextBox3.Text + "' where idpelanggan='" + TextBox1.Text + "'", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Update Gagal")
        End If
        kon.Close()
        Form2_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        koneksi()
        cm = New OdbcCommand("delete from pelanggan where idpelanggan='" + TextBox1.Text + "'", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Delete Gagal")
        End If
        kon.Close()
        Form2_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
End Class