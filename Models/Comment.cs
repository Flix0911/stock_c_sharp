using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        // id of comment
        public int Id { get; set; }
        // title of comment
        public string Title { get; set; } = string.Empty;
        // content of comment
        public string Content { get; set; } = string.Empty;
        // date and time of when it is created
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        // will search through code and setup the relationship ~ .net core form it for us
        public int? StockId { get; set; }
        // Navigation property ~ will allow us to access and . into it later
        public Stock? Stock { get; set; }
    }
}