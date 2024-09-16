using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veiculosAPI.Models;

namespace veiculosAPI.Data
{
    public class VeiculoDataAccess
    {
        private readonly string _connectionString;

        public VeiculoDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Veiculo> GetAllVeiculos()
        {
            List<Veiculo> veiculos = new List<Veiculo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT VeiculoID, Marca, Modelo, AnoFabricacao, Preco FROM Veiculos";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    veiculos.Add(new Veiculo
                    {
                        VeiculoID = reader.GetInt32(0),
                        Marca = reader.GetString(1),
                        Modelo = reader.GetString(2),
                        AnoFabricacao = reader.GetInt32(3),
                        Preco = reader.GetDecimal(4)
                    });
                }
            }

            return veiculos;
        }

        public Veiculo GetVeiculoById(int id)
        {
            Veiculo veiculo = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT VeiculoID, Marca, Modelo, AnoFabricacao, Preco FROM Veiculos WHERE VeiculoID = @VeiculoID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VeiculoID", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    veiculo = new Veiculo
                    {
                        VeiculoID = reader.GetInt32(0),
                        Marca = reader.GetString(1),
                        Modelo = reader.GetString(2),
                        AnoFabricacao = reader.GetInt32(3),
                        Preco = reader.GetDecimal(4)
                    };
                }
            }

            return veiculo;
        }

        public void AddVeiculo(Veiculo veiculo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Veiculos (Marca, Modelo, AnoFabricacao, Preco) VALUES (@Marca, @Modelo, @AnoFabricacao, @Preco)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                command.Parameters.AddWithValue("@AnoFabricacao", veiculo.AnoFabricacao);
                command.Parameters.AddWithValue("@Preco", veiculo.Preco);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateVeiculo(Veiculo veiculo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Veiculos SET Marca = @Marca, Modelo = @Modelo, AnoFabricacao = @AnoFabricacao, Preco = @Preco WHERE VeiculoID = @VeiculoID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                command.Parameters.AddWithValue("@AnoFabricacao", veiculo.AnoFabricacao);
                command.Parameters.AddWithValue("@Preco", veiculo.Preco);
                command.Parameters.AddWithValue("@VeiculoID", veiculo.VeiculoID);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteVeiculo(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Veiculos WHERE VeiculoID = @VeiculoID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VeiculoID", id);

                command.ExecuteNonQuery();
            }
        }
    }
}