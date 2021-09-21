using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi
{
    public class StudentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 20 characters")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Surname should be between 2 and 20 characters")]
        public string Surname { get; set; }

        [Required]
        [RegularExpression("(M|W)", ErrorMessage = "Only E or W is allowed")]
        public char Gender { get; set; }
    }
}
