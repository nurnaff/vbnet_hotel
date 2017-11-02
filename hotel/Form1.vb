Imports System.Data.Odbc
Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        da = New OdbcDataAdapter("select * from kamar", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kamar")
        DataGridView1.DataSource = (ds.Tables("kamar"))
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
        cm = New OdbcCommand("insert into kamar(idkamar,namakamar,harga) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Insert Gagal")
        End If
        kon.Close()
        Form1_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        koneksi()
        cm = New OdbcCommand("update kamar set namakamar='" + TextBox2.Text + "',harga='" + TextBox3.Text + "' where idkamar='" + TextBox1.Text + "'", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Update Gagal")
        End If
        kon.Close()
        Form1_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        koneksi()
        cm = New OdbcCommand("delete from kamar where idkamar='" + TextBox1.Text + "'", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Delete Gagal")
        End If
        kon.Close()
        Form1_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
End Class
