using CarAccidents.Models;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAccidents.Google
{
    public class Service
    {
        GoogleDbService googleService = new GoogleDbService();

        public List<GoogleQueryReturnedObject> getMapData(string year)
        {
            BigQueryResults results = googleService.getAccidentsByStateAndYear(year);
     
            List<GoogleQueryReturnedObject> resultDataList = new List<GoogleQueryReturnedObject>();

            foreach (var row in results)
            {
                String state = (String)row["state"];
                Int64 accidents = (Int64) row["accidents_count"];
                resultDataList.Add(new GoogleQueryReturnedObject { id = usaStates[state], value = accidents, stateName = state });
            }

            return resultDataList;
        }

        public List<FactorsReturedObject> getAccidnetsFactors()
        {
            BigQueryResults results = googleService.getAccidentsFactors();

            List<FactorsReturedObject> resultDataList = new List<FactorsReturedObject>();

            foreach (var row in results)
            {
                String factor = (String)row["factor"];
                Int64 accidents = (Int64)row["accidents_count"];
                resultDataList.Add(new FactorsReturedObject { x = factor, value = accidents });
            }

            return resultDataList;
        }


        Dictionary<String, String> usaStates = new Dictionary<string, string>
        {
            { "Alabama", "US.AL" },
             { "Alaska", "US.AK" },
              { "Arizona", "US.AZ" },
                { "Arkansas", "US.AR" },
             { "California", "US.CA" },
              { "Colorado", "US.CO" },
                { "Connecticut", "US.CT" },
             { "Delaware", "US.DE" },
              { "District of Columbia", "US.DC" },
              { "Florida", "US.FL" },
                { "Georgia", "US.GA" },
             { "Hawaii", "US.HI" },
              { "Idaho", "US.ID" },
                { "Illinois", "US.IL" },
             { "Indiana", "US.IN" },
               { "Iowa", "US.IA" },
             { "Kansas", "US.KS" },
               { "Kentucky", "US.KY" },
             { "Louisiana", "US.LA" },
               { "Maine", "US.ME" },
             { "Maryland", "US.MD" },
               { "Massachusetts", "US.MA" },
             { "Michigan", "US.MI" },
               { "Minnesota", "US.MN" },
             { "Mississippi", "US.MS" },
               { "Missouri", "US.MO" },
             { "Montana", "US.MT" },
               { "Nebraska", "US.NE" },
             { "Nevada", "US.NV" },
               { "New Hampshire", "US.NH" },
             { "New Jersey", "US.NJ" },
               { "New Mexico", "US.NM" },
             { "New York", "US.NY" },
              { "North Carolina", "US.NC" },
              { "North Dakota", "US.ND" },
              { "Ohio", "US.OH" },
              { "Oklahoma", "US.OK" },
              { "Oregon", "US.OR" },
              { "Pennsylvania", "US.PA" },
              { "Puerto Rico", "US.PR" },
              { "Rhode Island", "US.RI" },
              { "South Carolina", "US.SC" },
              { "South Dakota", "US.SD" },
              { "Tennessee", "US.TN" },
               { "Texas", "US.TX" },
              { "Utah", "US.UT" },
              { "Vermont", "US.VT" },
            { "Virginia", "US.VA" },
              { "Washington", "US.WA" },
              { "West Virginia", "US.WV" },
                { "Wisconsin", "US.WI" },
                  { "Wyoming", "US.WY" }
        };
    }
}