using System;
using OutlinerDetection.Infrastructure.Repositories;

namespace OutlinerDetection.Infrastructure.BusinessLogic
{
    public class OutlinerDectorFactory : IOutlinerDetectorFactory
    {
        private IRepository _repository;

        public OutlinerDectorFactory(IRepository repository)
        {
            _repository = repository;
        }

        public IOutlinerDetector GetOutlinerDetector()
        {
            return new SimpleOutlinerDetector(_repository);
        }
    }
}
