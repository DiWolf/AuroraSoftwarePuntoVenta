Imports dbo
Imports entidades

Public Class FrmClientes
    Dim dbo As dboCliente
    Dim cliente As Cliente = New Cliente
    Dim id As Integer
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargarDatos()
    End Sub
    Private Sub ButtonItemNuevoCliente_Click(sender As Object, e As EventArgs) Handles ButtonItemNuevoCliente.Click
        Dim frmGestion As FrmGestionCliente = New FrmGestionCliente
        frmGestion.ShowDialog()
    End Sub

    Private Sub CargarDatos()
        dbo = New dboCliente
        DataGridViewXCliente.DataSource = dbo.Leer(0)
    End Sub

    'Editar Informacion 
    Private Sub Editar(id As Integer)
        For Each cliente In dbo.Leer(id)
            FrmGestionCliente.LabelId.Text = cliente.Id.ToString
            FrmGestionCliente.txtNombre.Text = cliente.Nombre
            FrmGestionCliente.txtRfc.Text = cliente.Rfc
            FrmGestionCliente.txtDireccion.Text = cliente.Direccion
            FrmGestionCliente.txtNoExterior.Text = cliente.NoExterior
            FrmGestionCliente.txtNoInterior.Text = cliente.NoInterior
            FrmGestionCliente.txtColonia.Text = cliente.Colonia
            FrmGestionCliente.txtMunicipio.Text = cliente.Municipio
            FrmGestionCliente.txtCiudad.Text = cliente.Ciudad
            FrmGestionCliente.txtEstado.Text = cliente.Estado
            FrmGestionCliente.txtPais.Text = cliente.Pais
            FrmGestionCliente.txtCodigoPostal.Text = cliente.CodigoPostal
            FrmGestionCliente.txtTelefono.Text = cliente.Telefono
            FrmGestionCliente.txtCelular.Text = cliente.Celular
            FrmGestionCliente.txtEmail.Text = cliente.CorreoElectronico
        Next

        FrmGestionCliente.ShowDialog()
    End Sub

    Private Sub ButtonItemEditarCliente_Click(sender As Object, e As EventArgs) Handles ButtonItemEditarCliente.Click
        Editar(id)

    End Sub

    Private Sub DataGridViewXCliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewXCliente.CellClick
        Try
            id = Convert.ToInt32(DataGridViewXCliente.Rows(e.RowIndex).Cells(0).Value.ToString())
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonItemEliminarCliente_Click(sender As Object, e As EventArgs) Handles ButtonItemEliminarCliente.Click
        Dim var As DialogResult
        var = MessageBox.Show("¿Realmente deseas eliminar el registro: " & id & " del sistema?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        dbo = New dboCliente
        If var = DialogResult.Yes Then
            dbo.Borrar(id)
        End If
    End Sub
End Class