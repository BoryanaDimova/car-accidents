using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAccidents.Models
{
    public class MapModel
    {
        public List<GoogleQueryReturnedObject> ResultDataList { get; set; }

        public List<FactorsReturedObject> ResultFactorsList { get; set; }
    }
}