using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cethw1.Models
{
    public class student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int studentid { get; set; }
        public string email{ get; set; }
       

        public int departmentId { get; set; }
        public department department { get; set; }
    }
}
