using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stock
    {
        // int prop ~ 
        public int Id { get; set; }
        // str for stock symbol
        public string Symbol { get; set; } = string.Empty;
        // str for company
        public string CompanyName { get; set; } = string.Empty;
        // need to deal with money, 18 digits with 2 decimal spaces
        [Column(TypeName = "decimal(18,2)")]

        // input a decimal type
        public decimal Purchase { get; set; }
        // dividend
        public decimal LastDiv { get; set; }

        // industry
        public string Industry { get; set; } = string.Empty;

        // marketcap ~ long because it can be in the trillions
        public long MarketCap { get; set; }

        // work on 1 to many relationship
        public List<Comment> Comments { get; set; } = new 
    }
}