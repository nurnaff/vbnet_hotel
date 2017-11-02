Imports System.Data.Odbc
Public Class Form11
    Sub datagridview()
        koneksi()
        da = New OdbcDataAdapter("select * from menu", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "menu")
        DataGridView1.DataSource = (ds.Tables("menu"))
        kon.Close()
    End Sub
    Sub tampil()
        koneksi()
        da = New OdbcDataAdapter("select * from menu", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "menu")
        Dim a As New CrystalReport4
        CrystalReportViewer1.ReportSource = a
        a.SetDataSource(ds)
        kon.Close()
    End Sub
    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridview()
        tampil()
    End Sub
End Class