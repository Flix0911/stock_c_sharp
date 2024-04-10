using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Models;
using Npgsql.Replication;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            // Ensure that CreatedOn is set to UTC at the time of object creation
            DateTime utcNow = DateTime.UtcNow;

            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                CreatedOn = utcNow,
                StockId = stockId
            };
        }
    }
}