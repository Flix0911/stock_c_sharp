using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Stock
{
    public class StockDto
    {
        // int prop ~ 
        public int Id { get; set; }
        // str for stock symbol
        public string Symbol { get; set; } = string.Empty;
        // str for company
        public string CompanyName { get; set; } = string.Empty;

        // input a decimal type
        public decimal Purchase { get; set; }
        // dividend
        public decimal LastDiv { get; set; }

        // industry
        public string Industry { get; set; } = string.Empty;

        // marketcap ~ long because it can be in the trillions
        public long MarketCap { get; set; }

        // comments were previously here, but don't need them returned in the api
    }
}