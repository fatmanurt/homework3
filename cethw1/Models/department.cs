
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace cethw1.Models
{
    public class department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<student> Books { get; set; }
        
    }
    
}
