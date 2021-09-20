using System;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace OutlinerDetection.Model
{
    public class PriceData
    {
        [Name("Date")]
        [Format("dd/MM/yyyy")]
        public DateTime Date { get; set; }

        [Name("Price")]
        public decimal Price { get; set; }

    }
}
