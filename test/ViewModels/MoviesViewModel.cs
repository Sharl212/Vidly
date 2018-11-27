using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace test.ViewModels
{
    public class MoviesViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
    }
}