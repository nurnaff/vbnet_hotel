Imports System.Data.Odbc
Public Class Form10
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Hide()
        Form9.Show()
    End Sub
    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        da = New OdbcDataAdapter("select * from kedai,cafe where kedai.idkedai=cafe.idkedai", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "DataTable1")
        Dim a As New CrystalReport3
        CrystalReportViewer1.ReportSource = a
        a.SetDataSource(ds)
        kon.Close()
    End Sub
End Class