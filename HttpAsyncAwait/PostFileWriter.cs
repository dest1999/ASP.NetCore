using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpAsyncAwait
{
    internal class PostFileWriter
    {
        private static string fileName = "result.txt";
        private PostFileWriter()
        {
            
        }

        public static void Write(PostDTO post)
        {
            File.AppendAllLines(fileName, post.ToStringList());
            File.AppendAllText(fileName, "\n");
        }
    }
}
