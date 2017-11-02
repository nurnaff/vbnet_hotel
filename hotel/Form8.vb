Imports System.Data.Odbc
Public Class Form8
    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        da = New OdbcDataAdapter("select * from grup", kon)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "grup")
        Dim a As New CrystalReport2
        CrystalReportViewer1.ReportSource = a
        a.SetDataSource(ds)
        kon.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Hide()
        Form7.Show()
    End Sub
End Class