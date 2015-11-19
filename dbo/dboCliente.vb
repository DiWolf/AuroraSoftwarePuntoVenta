Imports System.Windows.Forms
Imports entidades
Imports MySql.Data.MySqlClient

Public Class dboCliente

    Dim conexion As Conexion
    Dim cmd As MySqlCommand
    Dim dtr As MySqlDataReader

    'Leer todos 
    Public Function Leer(ByVal id As Integer) As List(Of Cliente)
        Dim listacliente As List(Of Cliente) = New List(Of Cliente)
        conexion = New Conexion
        Try
            If id = 0 Then
                cmd = New MySqlCommand("CALL spSelectCliente();", conexion.Conectar)
            Else
                cmd = New MySqlCommand("SELECT * FROM Cliente WHERE id=@id", conexion.Conectar)
            End If
            cmd.Parameters.AddWithValue("@id", id).Direction = ParameterDirection.Input

            dtr = cmd.ExecuteReader
            While dtr.Read
                Dim lista As Cliente = New Cliente
                lista.Id = dtr.GetInt32(0)
                lista.Nombre = dtr.GetString(1)
                lista.Rfc = dtr.GetString(2)
                lista.Direccion = If(dtr.IsDBNull(3), String.Empty, dtr.GetString(3))
                lista.NoExterior = If(dtr.IsDBNull(4), String.Empty, dtr.GetString(4))
                lista.NoInterior = If(dtr.IsDBNull(5), String.Empty, dtr.GetString(5))
                lista.Colonia = If(dtr.IsDBNull(6), String.Empty, dtr.GetString(6))
                lista.Municipio = If(dtr.IsDBNull(7), String.Empty, dtr.GetString(7))
                lista.Ciudad = If(dtr.IsDBNull(8), String.Empty, dtr.GetString(8))
                lista.Estado = If(dtr.IsDBNull(9), String.Empty, dtr.GetString(9))
                lista.Pais = If(dtr.IsDBNull(10), String.Empty, dtr.GetString(10))
                lista.CodigoPostal = If(dtr.IsDBNull(11), String.Empty, dtr.GetString(11))
                lista.Telefono = If(dtr.IsDBNull(12), String.Empty, dtr.GetString(12))
                lista.Celular = If(dtr.IsDBNull(13), String.Empty, dtr.GetString(13))
                lista.CorreoElectronico = If(dtr.IsDBNull(14), String.Empty, dtr.GetString(14))
                listacliente.Add(lista)
            End While
        Catch ex As Exception
            Debug.Write(ex.ToString)
        Finally
            conexion.Conectar()
        End Try
        Return listacliente
    End Function


    'Leer solo por rfc 

    'Nuevo/Edición 
    Public Function NuevoEdicion(ByVal cliente As Cliente) As DialogResult
        conexion = New Conexion
        Dim msg As String
        Try
            If cliente.Id = 0 Then
                'aquí caes si es nuevo cliente 
                cmd = New MySqlCommand("CALL spAltaCliente(@Nombre,@Rfc,@Direccion,@NoExterior,@NoInterior,@Colonia,@Municipio,@Ciudad,@Estado,@Pais,@CodigoPostal, " &
                                "@Telefono,@Celular,@CorreoElectronico)", conexion.Conectar)
                msg = "Se agregó la información al sistema."
            Else
                'aquí caes si es edición de datos
                cmd = New MySqlCommand("CALL spEditaCliente(@Id,@Nombre,@Rfc,@Direccion,@NoExterior,@NoInterior,@Colonia,@Municipio,@Ciudad,@Estado,@Pais,@CodigoPostal," &
                                "@Telefono,@Celular,@CorreoElectronico)", conexion.Conectar)
                msg = "Se actualizó la información exitosamente."
            End If
            cmd.Parameters.AddWithValue("@Id", cliente.Id).Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre).Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("@Rfc", cliente.Rfc).Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion).Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("@NoExterior", cliente.NoExterior).Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("@NoInterior", cliente.NoInterior).Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("@Colonia", cliente.Colonia)
            cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio)
            cmd.Parameters.AddWithValue("@Ciudad", cliente.Ciudad)
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado)
            cmd.Parameters.AddWithValue("@Pais", cliente.Pais)
            cmd.Parameters.AddWithValue("@CodigoPostal", cliente.CodigoPostal)
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            cmd.Parameters.AddWithValue("@Celular", cliente.Celular)
            cmd.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico)
            cmd.ExecuteNonQuery()
            Return MessageBox.Show(msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Return MessageBox.Show("Se a producido una excepción: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Conectar()
        End Try
    End Function

    'Borrado 
    Public Function Borrar(ByVal id As Integer) As DialogResult
        conexion = New Conexion()
        Try
            cmd = New MySqlCommand("call spEliminaCliente(@id)", conexion.Conectar)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
            Return MessageBox.Show("La información se eliminó correctamente del sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Return MessageBox.Show("Se a producido una excepción: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Conectar()
        End Try
    End Function

End Class
