using System;
namespace OutlinerDetection.Infrastructure.BusinessLogic
{
    public interface IOutlinerDetectorFactory
    {
        IOutlinerDetector GetOutlinerDetector();
    }
}
