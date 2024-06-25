# AAPPowerbiAPI
API for PowerBI data from AAP
The repo is called MX Dotnet 

  

  

The Post FSI List is a Windows Task Scheduler task that runs 20:30 each day. 

Its action is to run the executable PostFSIList.exe 

  

MX Dotnet/Motornostix.MXAD/PostFSIList 

There are two modes: "default" and "full" 

The default mode sends only Open FSIs 

The full mode sends all FSIs 

  

Logic: 

Defines a class called FSIItem 

Runs a query and processes each row 

Creates a FSIItem from the data in each row and adds the item to List<FSIItem> 

Posts the List<FSIItem> to api  https://secure.motornostix.co.za/MXAPI/api/FSTask/PostFSIList 

MX Dotnet/Motornostix.API/MXAPI 

See https://motornostix.visualstudio.com/DefaultCollection/MX/_git/MX%20Dotnet?path=/Motornostix.API/MXAPI/Controllers/FSTaskController.cs 

Function 

public void PostFSIList(int datasourceid, [FromBody] List<FSIItem> items) 

  

https://motornostix.visualstudio.com/DefaultCollection/MX/_git/MX%20Dotnet?path=/Motornostix.API/MXAPI/Services/FSTaskService.cs 

Function 

public void PostFSIList(int DataSourceId, List<FSIItem> items) 

       

public class DivisionUpStatus 

{ 

public string DivisionName; 

public DateTime CaptureDate; 

public float Up; 

public float Total; 

public float Perc; 

} 

  

We need to define this class in both the app that sends the data, and the API that receives it. 

 

 

The program will need to be  able to take a date as parameter for the data to be selected.  If not given, default to yesterday's date.   This is because we will need to initially run it for back dates.  Also in case the scheduler/service is down, and we need to back fill data. 

 

The API will process the List<DivisionUpStatus> line by line and insert or update records in a table you  create in bi database 

 

The alternative is to replace the WHOLE table with new data as we do for the MHI and FSI data. See https://motornostix.visualstudio.com/DefaultCollection/MX/_git/MX%20Dotnet?path=/Motornostix.API/MXAPI/Services/BIService.cs 

  

from  /Motornostix.MXAD/PostFSIList/Program.cs function PostIssuesBIData 

  

The method creates a temporary file using bcp and uploads the whole file of data to API.  This is efficient and compressed. 
