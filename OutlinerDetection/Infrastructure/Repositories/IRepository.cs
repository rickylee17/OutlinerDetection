using System;
using System.Collections.Generic;
using OutlinerDetection.Model;

namespace OutlinerDetection.Infrastructure.Repositories
{
    public interface IRepository
    {
        //Read all price data into the list
        IEnumerable<PriceData> ReadAllPriceData();

        //Read the Next
        PriceData ReadNextPriceData();

        //Write the result back file
        void WriteResult(PriceData data);
    }
}
