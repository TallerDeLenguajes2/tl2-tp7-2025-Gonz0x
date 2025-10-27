using tl2_tp7_2025_Gonz0x.Models;
using Microsoft.Data.Sqlite;

namespace tl2_tp7_2025_Gonz0x.Repositorios.ProductosRepository
{
    public class ProductosRepository
    {
        private string cadenaConexion = "Data Source=Tienda.db";

        public void CrearProducto(Productos producto)
        {
            using var conexion = new SqliteConnection(cadenaConexion);
            conexion.Open();
            string sql = "INSERT INTO Productos(idProducto, Descripcion, Precio) VALUES(@idProducto, @Descripcion, @Precio)";
            using var comando = new SqliteCommand(sql, conexion);
            comando.Parameters.Add(new SqliteParameter("@idProducto", producto.idProducto));
            comando.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            comando.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            comando.ExecuteNonQuery();
        }
        
        public void ModificarProducto(int id, Productos producto)
        {
            using var conexion = new SqliteConnection(cadenaConexion);
            conexion.Open();
            string sql = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio WHERE idProducto = @idProducto";
            using var comando = new SqliteCommand(sql, conexion);
            comando.Parameters.Add(new SqliteParameter("@idProducto", id));
            comando.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            comando.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            comando.ExecuteNonQuery();
        }

        public List<Productos> ListarProductos()
        {
            var productos = new List<Productos>();
            using var conexion = new SqliteConnection(cadenaConexion);
            conexion.Open();
            string sql = "SELECT idProducto, Descripcion, Precio FROM Productos";
            using var comando = new SqliteCommand(sql, conexion);
            using SqliteDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var producto = new Productos
                {
                    idProducto = Convert.ToInt32(reader["idProducto"]),
                    Descripcion = reader["Descripcion"].ToString(), 
                    Precio = Convert.ToInt32(reader["Precio"])
                };
                productos.Add(producto);
            }
            return productos;
        }

        public Productos ObtenerProductoPorId(int id)
        {
            using var conexion = new SqliteConnection(cadenaConexion);
            conexion.Open();
            string sql = "SELECT idProducto, Descripcion, Precio FROM Productos WHERE idProducto = @idProducto";
            using var comando = new SqliteCommand(sql, conexion);
            comando.Parameters.Add(new SqliteParameter("@idProducto", id));
            using var lector = comando.ExecuteReader();
            if(lector.Read())
            {
                var Producto = new Productos
                {
                    idProducto = Convert.ToInt32(lector["idProducto"]),
                    Descripcion = lector["Descripcion"].ToString(),
                    Precio = Convert.ToInt32(lector["Precio"])
                };
                return Producto;
            }
            return null;
        }  

        public void EliminarProducto(int id)
        {
            using var conexion = new SqliteConnection(cadenaConexion);
            conexion.Open();
            string sql = "DELETE FROM Productos WHERE idProducto = @idProducto";
            using var comando = new SqliteCommand(sql, conexion);
            comando.Parameters.Add(new SqliteParameter("@idProducto", id));
            comando.ExecuteNonQuery();
        }
    }
}