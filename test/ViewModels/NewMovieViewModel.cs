using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace test.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null & Movie.Id == 0)
                {
                    return "New Movie";
                }
                else
                {
                    return "Edit Movie";
                }
            }
        }
    }
}