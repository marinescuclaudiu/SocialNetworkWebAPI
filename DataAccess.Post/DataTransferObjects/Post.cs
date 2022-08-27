using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Post.DataTransferObjects
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }

    }
}
