using System;
using System.Collections.Generic;
using System.Text;
using IndianStateCensus_Analyser;
using IndianStateCensus_Analyser.POCO;
using IndianStateCensus_Analyser.DTO;
using NUnit.Framework;
using static IndianStateCensus_Analyser.DTO.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class CensusDataTest
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string CensusCountPath = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\ActualCount.csv";
        static string fileNotFound = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\ActualCount_Wrong.csv";
        static string wrongFileType = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\ActualCount.txt";
        static string incorrectDelimeter = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\IncorrectDelimeter.csv";
        static string headerIncorrect = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\HeaderIncorect.csv";
        
        IndianStateCensus_Analyser.DTO.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        static string indianStateCodeHeader = "SrNo,State,Name,Tin,StateCode";
        static string statetPath= @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\ActualCensusData.csv"; 
        static string stateFileNotFound = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\ActualCensus_Wrong.csv";
        static string wrongStateFileType = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\ActualCensus.txt";
        static string incorrectStateDelimeter = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\IncorrectCensusDelimeter.csv";
        static string stateHeaderIncorrect = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\IndianStateCensusDemo\CensusAnalyserTest\CSVFILES\StateHeaderIncorect.csv";
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensus_Analyser.DTO.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// 1.1 Givens the indian census data file when reade then should return census data count.
        /// </summary>
        
        [Test]
        public void GivenIndianCensusDataFile_WhenReade_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, CensusCountPath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// 1.2 Givens the state census file then return custom exception.
        /// </summary>
        
        [Test]
        public void GivenStateCensusFileCorrect_ButTypeIncorrectReturn_Exception()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, fileNotFound, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }

        /// <summary>
        /// 1.3 Givens the state census file correct but type incorrect return exception.
        /// </summary>
        
        [Test]
        public void GivenStateCensusFile_ThenReturnCustomException_InvalidFileType()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongFileType, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }

        /// <summary>
        /// 1.4 Givens the state census file whencorrect but delimiter incorrect return exception.
        /// </summary>

        [Test]
        public void GivenStateCensus_FileWhencorrect_butDelimeterIncorrect_ReturnException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, incorrectDelimeter, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }

        /// <summary>
        /// 1.5 Givens the state census file whencorrect but Header incorrect return exception.
        /// </summary>

        [Test]
        public void GivenStateCensus_FileWhencorrect_butHeaderIncorrect_ReturnException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, headerIncorrect, indianStateCensusHeaders);
            }
            catch(CensusAnalyserException e)
            { 
                Assert.AreEqual("Incorrect header in Data", e.Message);    
            }
        }

        /// <summary>
        /// 2.1 Givens the indian State Code data file when reade then should return State data count.
        /// </summary>

        [Test]
        public void GivenIndianStateCodeDataFile_WhenReade_ThenShouldReturnStateDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, statetPath, indianStateCodeHeader);
            Assert.AreEqual(37, stateRecord.Count);
        }

        /// <summary>
        /// 2.2 Givens the state Code  file then return custom exception.
        /// </summary>

        [Test]
        public void GivenStateCodeFileCorrect_ButTypeIncorrectReturn_Exception()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, stateFileNotFound, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
    }
}
