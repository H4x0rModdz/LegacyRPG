using LegacyRPG.Domain.Models;
using LegacyRPG.Infrastructure.SqlServer;
using Microsoft.Data.SqlClient;

namespace LegacyRPG.Infrastructure
{
    public class SqlServerDb
    {
        private readonly string _connectionString;

        public SqlServerDb() => _connectionString = ConfigurationHelper.GetConnectionString();

        public void CreateDatabase()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                            IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'LegacyRPG')
                            BEGIN
                                CREATE DATABASE LegacyRPG;
                            END";

                        command.ExecuteNonQuery();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                            USE LegacyRPG;

                            CREATE TABLE IF NOT EXISTS Players (
                                Id INT PRIMARY KEY IDENTITY,
                                Name NVARCHAR(100),
                                IsAlive BIT,
                                Health INT,
                                Attack INT,
                                Defense INT,
                                Level INT,
                                Experience INT,
                                Class NVARCHAR(100),
                                Gold INT,
                                MaxHealth INT,
                                MaxMana INT,
                                Mana INT
                            );";

                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Database created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
            }
        }

         public void InsertPlayer(Player player)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                            INSERT INTO Players (Name, IsAlive, Health, Attack, Defense, Level, Experience, Class, Gold, MaxHealth, MaxMana, Mana)
                            VALUES (@Name, @IsAlive, @Health, @Attack, @Defense, @Level, @Experience, @Class, @Gold, @MaxHealth, @MaxMana, @Mana);";

                        command.Parameters.AddWithValue("@Name", player.Name);
                        command.Parameters.AddWithValue("@IsAlive", player.IsAlive);
                        command.Parameters.AddWithValue("@Health", player.Health);
                        command.Parameters.AddWithValue("@Attack", player.Attack);
                        command.Parameters.AddWithValue("@Defense", player.Defense);
                        command.Parameters.AddWithValue("@Level", player.Level);
                        command.Parameters.AddWithValue("@Experience", player.Experience);
                        command.Parameters.AddWithValue("@Class", player.Class);
                        command.Parameters.AddWithValue("@Gold", player.Gold);
                        command.Parameters.AddWithValue("@MaxHealth", player.MaxHealth);
                        command.Parameters.AddWithValue("@MaxMana", player.MaxMana);
                        command.Parameters.AddWithValue("@Mana", player.Mana);

                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Player added to the database successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding player to the database: {ex.Message}");
            }
        }

        public void DeletePlayer(int playerId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Players WHERE Id = @PlayerId";
                        command.Parameters.AddWithValue("@PlayerId", playerId);
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Player deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting player: {ex.Message}");
            }
        }
    }
}