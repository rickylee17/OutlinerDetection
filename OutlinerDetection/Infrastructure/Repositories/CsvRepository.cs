using System;
using System.Collections.Generic;
using OutlinerDetection.Model;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace OutlinerDetection.Infrastructure.Repositories
{
    public class CsvRepository : IRepository, IDisposable
    {
        private string _readFilePath;
        private string _writeFilePath;
        private CsvReader _csvReader;
        private StreamReader _streamReader;

        public CsvRepository()
        {
            _readFilePath = Environment.CurrentDirectory + @"/Data/Outliers.csv";
            _writeFilePath = Environment.CurrentDirectory + @"/Data/Clean.csv";
            _streamReader = new StreamReader(_readFilePath);
            _csvReader = new CsvReader(_streamReader, CultureInfo.InvariantCulture);

            File.Delete(_writeFilePath);
        }

        public IEnumerable<PriceData> ReadAllPriceData()
        {
            return _csvReader.GetRecords<PriceData>();
        }

        public PriceData ReadNextPriceData()
        {
            if (_csvReader.Read())
                return _csvReader.GetRecord<PriceData>();
            else
                return null; 
        }

        public void WriteResult(PriceData data)
        {
            // write the header first if the file not exists
            if (!File.Exists(_writeFilePath))
            {
                using (var writer = new StreamWriter(_writeFilePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                { 
                    csv.WriteHeader<PriceData>();
                }
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = false
            };
            using (var stream = File.Open(_writeFilePath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecord(data);
                writer.WriteLine();
            }
        }

        public void Dispose()
        {
            _csvReader.Dispose();
            _streamReader.Dispose();
        }

    }

}
