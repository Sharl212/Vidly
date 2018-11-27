using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public byte Genre_Id { get; set; }
        public short NumberInStock { get; set; }
    }
}