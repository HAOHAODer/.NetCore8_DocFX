using Microsoft.EntityFrameworkCore;

namespace MyApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}