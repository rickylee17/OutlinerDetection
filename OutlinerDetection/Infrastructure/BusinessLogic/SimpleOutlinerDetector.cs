using System;
using OutlinerDetection.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace OutlinerDetection.Infrastructure.BusinessLogic
{
    public class SimpleOutlinerDetector : IOutlinerDetector
    {
        private IRepository _repository;

        public SimpleOutlinerDetector(IRepository repository)
        {
            _repository = repository;
        }

        public void Process(DectorParam param)
        {
            Queue<decimal> PastValues = new Queue<decimal>();

            var data = _repository.ReadNextPriceData();
            while (data != null)
            {
                // Keep the stack with the correct no. of items to calculate the average
                if (PastValues.Count >= param.PastCount)
                    PastValues.Dequeue();
                PastValues.Enqueue(data.Price);

                // Compare the average with current item the
                var avg = PastValues.Average();
                if (Math.Abs(data.Price - avg) / avg > param.Deviate)
                {
                    // Output to console
                    Console.WriteLine($"Outliner found on Date: {data.Date} Price: {data.Price}" );
                    Console.WriteLine($"Last {param.PastCount} days average: {avg}");
                    Console.WriteLine();
                }
                else
                {
                    // write to result file
                    _repository.WriteResult(data);
                }

                data = _repository.ReadNextPriceData();
            }
        }
    }
}
