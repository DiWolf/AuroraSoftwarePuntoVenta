Public Class Form1
    Private Sub ButtonItemClientes_Click(sender As Object, e As EventArgs) Handles ButtonItemClientes.Click
        FrmClientes.MdiParent = Me
        FrmClientes.Show()
    End Sub
End Class
