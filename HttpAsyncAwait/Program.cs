using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HttpAsyncAwait
{
    internal class Program
    {
        private static CancellationTokenSource cancellationTokenSource = new(800); //значение достаточно мало, чтобы отработала только часть запросов
        static void Main(string[] args)
        {
            var tasksList = new List<Task<PostDTO>>();

            for (int i = 4; i <= 13; i++)
            {
                tasksList.Add(GetPostByIdViaHTTPAsync(i, cancellationTokenSource));
            }

            try
            {
                Task.WaitAll(tasksList.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var completedTasksOnly = tasksList.Where(task => task.Status == TaskStatus.RanToCompletion);
            foreach (var item in completedTasksOnly)
            {
                PostFileWriter.Write(item.Result);
            }

        }

        private static async Task<PostDTO> GetPostByIdViaHTTPAsync(int postId, CancellationTokenSource cancelTokenSource)
        {
            var uri = new Uri("https://jsonplaceholder.typicode.com/posts/" + postId);
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            using var client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync(uri, cancelTokenSource.Token);
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
