using Microsoft.EntityFrameworkCore;

namespace MyApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        /// <summary>
        /// Returns a formatted string representation of the item.
        /// </summary>
        /// <returns>A string representing the item.</returns>
        public override string ToString()
        {
            return $"Item [Id={Id}, Name={Name}]";
        }

        /// <summary>
        /// Updates the name of the item.
        /// </summary>
        /// <param name="newName">The new name for the item.</param>
        public void UpdateName(string newName)
        {
            Name = newName;
        }

        /// <summary>
        /// Checks if the item is valid based on certain criteria.
        /// </summary>
        /// <returns>True if the item is valid; otherwise, false.</returns>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && Id > 0;
        }

        /// <summary>
        /// Creates a list of sample items.
        /// </summary>
        /// <returns>A list of sample items.</returns>
        public static List<Item> CreateSampleItems()
        {
            return new List<Item>
            {
                new Item { Id = 1, Name = "Sample Item 1" },
                new Item { Id = 2, Name = "Sample Item 2" },
                new Item { Id = 3, Name = "Sample Item 3" }
            };
        }
    }
}