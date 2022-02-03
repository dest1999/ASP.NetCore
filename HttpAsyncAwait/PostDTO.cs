using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpAsyncAwait
{
    internal class PostDTO
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public List<string> ToStringList()
        {
            List<string> outList = new();
            outList.Add(userId.ToString());
            outList.Add(id.ToString());
            outList.Add(title);
            outList.Add(body);

            return outList;
        }

    }
}
