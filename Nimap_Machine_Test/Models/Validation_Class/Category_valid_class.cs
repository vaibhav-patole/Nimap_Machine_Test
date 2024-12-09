using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimap_Machine_Test.Models.Validation_Class
{
    public class Category_valid_class
    {
        [Required] 
        public int Category_id { get; set; }

        [Required]
        public string Category_Name { get; set; }
    }
}