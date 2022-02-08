using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpAsyncAwait
{
    internal class PostDTO
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<string> ToStringList()
        {
            List<string> outList = new();
            outList.Add(UserId.ToString());
            outList.Add(Id.ToString());
            outList.Add(Title);
            outList.Add(Body);

            return outList;
        }

    }
}
