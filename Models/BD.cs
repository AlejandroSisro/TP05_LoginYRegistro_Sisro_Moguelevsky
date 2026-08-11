using Microsoft.Data.SqlClient;
using Dapper;
// Hecho con copilot, con modificaciones nuestras.
namespace TPs.Models;

public class BD
{
    private string _connectionString = @"Server=.;Database=Cine;User Id=alumno;Password=123456;TrustServerCertificate=True;";

    public List<Usuario> ObtenerTodosLosUsuarios()
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario";
            return connection.Query<Usuario>(query).ToList();
        }
    }

    public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT * FROM Usuario 
                             WHERE nombreUsuario = @pNombreUsuario";
            return connection.QueryFirstOrDefault<Usuario>(query, new { pNombreUsuario = nombreUsuario });
        }
    }

    public bool ValidarCredenciales(string nombreUsuario, string contraseña)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT * FROM Usuario 
                             WHERE nombreUsuario = @pNombreUsuario 
                             AND contraseña = @pContraseña";
            var usuario = connection.QueryFirstOrDefault<Usuario>(query, new { pNombreUsuario = nombreUsuario, pContraseña = contraseña });
            return usuario != null;
        }
    }

    public void RegistrarUsuario(Usuario usuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"INSERT INTO Usuario 
                             (nombreUsuario, nombre, apellido, tipoUsuario, contraseña) 
                             VALUES 
                             (@pNombreUsuario, @pNombre, @pApellido, @pTipoUsuario, @pContraseña)";
            
            connection.Execute(query, new
            {
                pNombreUsuario = usuario.nombreUsuario,
                pNombre = usuario.nombre,
                pApellido = usuario.apellido,
                pTipoUsuario = usuario.tipoUsuario,
                pContraseña = usuario.contraseña
            });
        }
    }

    public void ActualizarUsuario(Usuario usuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"UPDATE Usuario 
                             SET nombre = @pNombre,
                                 apellido = @pApellido,
                                 tipoUsuario = @pTipoUsuario,
                                 contraseña = @pContraseña
                             WHERE nombreUsuario = @pNombreUsuario";
            
            connection.Execute(query, new
            {
                pNombreUsuario = usuario.nombreUsuario,
                pNombre = usuario.nombre,
                pApellido = usuario.apellido,
                pTipoUsuario = usuario.tipoUsuario,
                pContraseña = usuario.contraseña
            });
        }
    }

    public void EliminarUsuario(string nombreUsuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"DELETE FROM Usuario 
                             WHERE nombreUsuario = @pNombreUsuario";
            connection.Execute(query, new { pNombreUsuario = nombreUsuario });
        }
    }
}
