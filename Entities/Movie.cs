using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Movie:BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; }=null!;
        public string? Imdb { get; set; }
        public string? PhotoUrl { get; set; }
        public string? VideoUrl { get; set; }
        public  virtual List<MovieToCategory> MovieToCategories { get; set; }
    }
}

//ovveride