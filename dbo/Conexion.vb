Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class Conexion

    Dim conexion As MySqlConnection

    Sub New()
        conexion = New MySqlConnection(connectionString:=ConfigurationManager.ConnectionStrings("aurora").ConnectionString)
    End Sub



    Public Function Conectar() As MySqlConnection
        If conexion.State = ConnectionState.Broken Or conexion.State = ConnectionState.Closed Then
            conexion.Open()
        Else
            conexion.Close()
        End If
        Return conexion
    End Function

End Class
