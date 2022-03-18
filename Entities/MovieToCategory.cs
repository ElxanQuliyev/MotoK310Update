using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MovieToCategory:BaseEntity
    {
        //XMan - Dram,Fantastic
        //Z= Dram,Romantic

        //Dram -Xmen,Z,X
        //Romantic - Xmen,A,B
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
