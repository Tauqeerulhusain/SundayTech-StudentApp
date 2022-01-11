using System;
using System.Collections.Generic;

#nullable disable

namespace StudentDAL.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string Standard { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
