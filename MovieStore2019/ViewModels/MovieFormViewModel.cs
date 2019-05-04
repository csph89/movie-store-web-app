using MovieStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore2019.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0) //An uparxei hdh h tainia shmainei oti ginetai Edit.
                    return "Edit Movie";
                return "New Movie"; //Alliws shmainei oti eisagoume mia kainouria sth vash mas.
            }
        }

    }
}