using System;
using System.Linq;
namespace OutlinerDetection.Infrastructure.BusinessLogic
{
    public interface IOutlinerDetector
    {
        void Process(DectorParam param);
    }
}
