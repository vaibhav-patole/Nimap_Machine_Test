using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimap_Machine_Test.Models.Validation_Class
{
    public class Product_valid_Class
    {
       
        public int Product_id { get; set; }

        [Required]
        public string Product_Name { get; set; }

        public Nullable<int> Category_id { get; set; }

    }
}