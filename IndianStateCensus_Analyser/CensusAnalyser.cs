using System;
using System.Collections.Generic;
using IndianStateCensus_Analyser.POCO;


namespace IndianStateCensus_Analyser.DTO
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA,
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
