using Google.Cloud.BigQuery.V2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1;
using Google.Apis.Services;
using System.IO;

namespace CarAccidents.Google
{
    public class GoogleDbService
    {
        private const string KEY_FILE_PATH = "E:/Документи/Университет/Projects/BigData/CarAccidents/CarAccidents/key.json";
        private const string PROJECT_ID = "dataflix-public-datasets";
        private const string DATASET_ID = "traffic_safety";
        private const string ACCIDENTS_TABLE_ID = "accident";
        private const string FACTOR_TABLE_ID = "factor";
        private BigQueryClient _client;

        public BigQueryClient client
        {
            get {
                if (_client == null){
                    var credential = GoogleCredential.FromFile(KEY_FILE_PATH);
                    this._client = BigQueryClient.Create("car-accidents-6ede7", credential);
                }

                return this._client; }
            private set { }
        }

        public BigQueryResults getAccidentsByStateAndYear(string year)
        {
            string queryYear = year != null? $"WHERE YEAR={year}" : "";
            BigQueryTable table = client.GetTable(PROJECT_ID, DATASET_ID, ACCIDENTS_TABLE_ID);
            var sql = $"SELECT STATE AS state, COUNT(STATE) AS accidents_count FROM {table} {queryYear} GROUP BY STATE ORDER BY COUNT(STATE) DESC";

            var results = client.ExecuteQuery(sql, parameters: null);

            return results;
        }
       // SELECT COUNT(MFACTOR), MFACTOR FROM `dataflix-public-datasets.traffic_safety.factor` GROUP BY MFACTOR
        public BigQueryResults getAccidentsFactors()
        {
            BigQueryTable table = client.GetTable(PROJECT_ID, DATASET_ID, FACTOR_TABLE_ID);
            var sql = $"SELECT MFACTOR AS factor, COUNT(MFACTOR) AS accidents_count FROM {table} WHERE MFACTOR NOT IN ('None', 'Not Reported', 'Unknown') GROUP BY MFACTOR";

            var results = client.ExecuteQuery(sql, parameters: null);

            return results;
        }
        //SELECT STATE, COUNT(WEATHER) AS Accidents_Count, WEATHER FROM `dataflix-public-datasets.traffic_safety.accident` GROUP BY WEATHER, STATE  ORDER BY STATE 
    }
}