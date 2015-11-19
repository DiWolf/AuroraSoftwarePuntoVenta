Imports dbo
Imports entidades

Public Class FrmGestionCliente
    Dim dbo As dboCliente
    Dim cliente As Cliente = New Cliente
    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click
        dbo = New dboCliente()
        cliente.Id = Convert.ToInt32(LabelId.Text)
        cliente.Nombre = txtNombre.Text
        cliente.Rfc = txtRfc.Text
        cliente.Direccion = txtDireccion.Text
        cliente.NoExterior = txtNoExterior.Text
        cliente.NoInterior = txtNoInterior.Text
        cliente.Colonia = txtColonia.Text
        cliente.Municipio = txtMunicipio.Text
        cliente.Ciudad = txtCiudad.Text
        cliente.Estado = txtEstado.Text
        cliente.Pais = txtPais.Text
        cliente.CodigoPostal = txtCodigoPostal.Text
        cliente.Telefono = txtTelefono.Text
        cliente.Celular = txtCelular.Text
        cliente.CorreoElectronico = txtEmail.Text
        'pasamos lo datos a guardar 
        dbo.NuevoEdicion(cliente)
    End Sub
End Class