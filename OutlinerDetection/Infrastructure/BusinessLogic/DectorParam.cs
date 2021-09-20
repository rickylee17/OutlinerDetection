using System;
namespace OutlinerDetection.Infrastructure.BusinessLogic
{
    public class DectorParam
    {
        // A percentage of Deviation of the outliner to be dectected
        public decimal Deviate { get; set; }

        // Number of past record that used to consider the outliner
        public int PastCount { get; set; }
    }
}
