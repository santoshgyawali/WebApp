using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        public String Name { get; set; }

       [Required]
        public Genre Genre { get; set; }
         [Required]
        public byte GenreId { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Range(1,20)]
        [Required]
        public byte NumberInStock { get; set; }
    }
}