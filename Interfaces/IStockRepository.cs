using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;

// This is going to abstract our code away, DB call will go to the interface

namespace api.Interfaces
{
    public interface IStockRepository
    {
        // add a task
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id); //FirstOrDefault can be null
        // return a stock
        Task<Stock> CreateAsync(Stock stockModel);
        // Return type of stock
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        // Delete
        Task<Stock?> DeleteAsync(int id);
        // create method to check if there is a stock
        Task<bool> StockExists(int id);
    }
}