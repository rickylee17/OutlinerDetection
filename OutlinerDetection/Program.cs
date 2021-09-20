using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using OutlinerDetection.Infrastructure.BusinessLogic;

namespace OutlinerDetection
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            //Console.WriteLine(Environment.CurrentDirectory);

            //Validate args
            if (!ValidateArgs(args))
                return;

            serviceProvider.GetService<Start>().Run(args);

        }


        private static bool ValidateArgs(string[] args)
        {
            if (args.Count() == 0)
                return true;

            else if (args.Count() != 2)
            {
                Console.WriteLine("This command accpet 0 or 2 arguments");
                return false;
            }
            else if (!decimal.TryParse(args[0], out _))
            {
                Console.WriteLine("Deviation should be decmial");
                return false;
            }
            else if (!int.TryParse(args[1], out _))
            {
                Console.WriteLine("Average count should be decmial");
                return false;
            }

            return true;
        }

    }

    public class Start
    {
        private const decimal defaultDeviate = 0.05m;
        private const int defaultPastCount = 10;

        private IOutlinerDetectorFactory _outlinerDectorFactory;

        public Start(IOutlinerDetectorFactory outerlinerDetectorFactory)
        {
            _outlinerDectorFactory = outerlinerDetectorFactory;
        }

        public void Run(String[] args)
        {

            var dector = _outlinerDectorFactory.GetOutlinerDetector();
            var param = new DectorParam()
            {
                Deviate = args.GetUpperBound(0) == 1 ? decimal.Parse(args[0]) : defaultDeviate,
                PastCount = args.GetUpperBound(0) == 1 ? int.Parse(args[1]) : defaultPastCount
            };

            dector.Process(param);

        }
    }
}
