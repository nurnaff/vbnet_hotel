Imports System.Data.Odbc
Public Class Form6
    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        da = New OdbcDataAdapter("select * from transaksi", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "transaksi")
        Dim a As New CrystalReport1
        CrystalReportViewer1.ReportSource = a
        a.SetDataSource(ds)
        kon.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Hide()
        Form5.Show()
    End Sub
End Class