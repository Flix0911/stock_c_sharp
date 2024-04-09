using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        // return task will be called at the end of the function
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _context.Stocks.ToListAsync();
            // this is .nets version of map ~ immutable list/array

            var stockDto = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        // build out the controller endpoint
        [HttpPost]
        // need frombody because it is going to be sync in json ~ passing in the actual body of http
        // create the request portion of the DTO
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
           await _context.Stocks.AddAsync(stockModel);
           await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        // lets make a put
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null)
            {
                return NotFound();
            }
            // where our updates will happen
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            // will send changes to db
            await _context.SaveChangesAsync();

            // use StockDto to return the whole object back
            return Ok(stockModel.ToStockDto());
        }

        // DELETE
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel =  await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);

            await _context.SaveChangesAsync();

            // do a delete, nocontent is success (204)
            return NoContent();
        }

    }
}