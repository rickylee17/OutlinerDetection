# OutlinerDetection

## Prerequisite
dotnet core 3.1 installed


## Syntax
dotnet OutlinerDetection.dll [Deviation factor] [Past Number of days]
[Deviation factor]
- Decimal, the factor of the deviation.
- Optional. If not supply the default value is 0.05
[Past Number of days]
- Integer, the number of days of data as the reference for finding outliner.
- Optional. If not supply the default value is 10

The command should either provide both parameter value or none of them

## UsageUsage
dotnet OutlinerDetection.dll
dotnet OutlinerDetection.dll 0.05 10
dotnet OutlinerDetection.dll 0.1 20


## Data and Result
The data file Outliners.csv should be put in the working directory \Data folder.
The result file Clean.csv will also be in the working directory \Data folder.
The outliner will be show in the console, e.g:

~~~
Outliner found on Date: 07/12/1990 00:00:00 Price: 124.855201
Last 10 days average: 106.64670405
~~~


## Technical notes
- This program use Dependency Injection (DI), with the start.cs to configure service for constructor injection.
- The IOuterlinerDector is defined as the interface for the outliner detector logic. The SimpleOutlinerDector implement this interface for a simple way to find out outliner.
- The OutlinerFactor is the factory for select different OutlinerDector. It can be further implement to select different OutlinerDector if other detector is developed.
- The IRepository is the interface for accessing data. The CsvRepository was developed to access CSV data. It make use of the library CsvHelper to read data to and write data from csv file. Other repository can be develop for different data source. We can simply change the service selection for IRepository in Starup.cs if we want to make use of other data source / repository.
