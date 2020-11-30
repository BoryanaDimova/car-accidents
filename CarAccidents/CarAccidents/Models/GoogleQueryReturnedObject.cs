using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAccidents.Models
{
    public class GoogleQueryReturnedObject
    {
        public string id { get; set; }
        public Int64 value { get; set; }
        public string stateName { get; set; }
    }
}