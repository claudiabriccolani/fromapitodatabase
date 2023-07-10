using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProgettoGetClaudiaBriccolani
{
    public class PostSaverClass
    { 
            public async Task PostSaver()
            {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                if (response.IsSuccessStatusCode)
                {
                    
                    var json = await response.Content.ReadAsStringAsync();
                    var posts = JsonSerializer.Deserialize<List<PostModel>>(json);

                    using (var connection = new SqlConnection("Server=DESKTOP-1N1690E;Database=ProjectDatabase;Integrated Security=true"))
                    {
                        await connection.OpenAsync();
                        foreach (var postModel in posts)
                        {
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = "INSERT INTO POST (userid, id, title, body) VALUES (@userid, @id, @title, @body)";
                                command.Parameters.AddWithValue("@userid", postModel.userid);
                                command.Parameters.AddWithValue("@id", postModel.id);
                                command.Parameters.AddWithValue("@title", postModel.title);
                                command.Parameters.AddWithValue("@body", postModel.body);
                                await command.ExecuteNonQueryAsync();
                            }
                        }
                    }

                    Console.WriteLine("Post scaricati e salvati con successo!");
                }
                else
                {
                    Console.WriteLine("Download non riuscito dall'API.");
                }
            }
            }



        }
    }

