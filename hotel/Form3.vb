Imports System.Data.Odbc
Public Class Form3
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        da = New OdbcDataAdapter("select * from disk", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "disk")
        DataGridView1.DataSource = (ds.Tables("disk"))
        kon.Close()
    End Sub
    Sub tutup(ByVal akt As Boolean)
        TextBox1.Enabled = akt
        TextBox2.Enabled = akt
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tutup(True)
        TextBox1.Focus()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        koneksi()
        cm = New OdbcCommand("insert into disk(id,disko) values('" + TextBox1.Text + "','" + TextBox2.Text + "')", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Insert Gagal")
        End If
        kon.Close()
        Form3_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        koneksi()
        cm = New OdbcCommand("update disk set disko='" + TextBox2.Text + "' where id='" + TextBox1.Text + "'", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Update Gagal")
        End If
        kon.Close()
        Form3_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        koneksi()
        cm = New OdbcCommand("delete from disk where id='" + TextBox1.Text + "'", kon)
        If cm.ExecuteNonQuery <= 0 Then
            MsgBox("Delete Gagal")
        End If
        kon.Close()
        Form3_Load(sender, e)
        bersih()
        tutup(False)
    End Sub
End Class