using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpAsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var tasksList = new List<Task<PostDTO>>();

            for (int i = 4; i <= 13; i++)
            {
                tasksList.Add(GetPostByIdViaHTTPAsync(i));
            }

            await Task.WhenAll(tasksList);

            foreach (var item in tasksList)
            {
                PostFileWriter.Write(item.Result);
            }

        }

        private static async Task<PostDTO> GetPostByIdViaHTTPAsync(int postId)
        {
            var uri = new Uri("https://jsonplaceholder.typicode.com/posts/" + postId);
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            using var client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync(uri);
                var post = JsonSerializer.Deserialize<PostDTO>(response, jsonOptions);
                Console.WriteLine($"Post id: {postId}");//для отладки и визуализации выполнения
                return post;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
