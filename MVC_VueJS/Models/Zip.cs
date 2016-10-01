using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_VueJS.Models
{
    public class Zip
    {
        public int ZipCode { get; set; }
        public string Type { get; set; }
        public string PrimaryCity { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}