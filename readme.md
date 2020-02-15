# ASP.NET Oracle Sample Project w/Web Service Functionality

This project is a continuation of [this ASP.NET Core Application](https://github.com/Razat94/OracleSampleProject).
Please note that this application was written in classic ASP.NET, 
and has a web service communicating with the front end of the website and an Oracle database.

## Requirements.
- Deploy this application by opening up the solution 'OracleDotNetProjectwithWebService.sln' on Visual Studio and running it.
- You will need to have access to an Oracle Database locally. The database must have a user "bms" with the password "abc".
- The user "bms" must have an "Employees" table. 
  This project contains the DDL file that contains information on how to create the database with the "addFirstName" stored procedure. 
  Look for the DDL File "exportedDDL.sql" in the root directory.
- This project contains the Nuget Package "Oracle.ManagedDataAccess". You wouldn't need to install it again.
- On my local machine, the webservice was found on the URL: "https://localhost:44393/WebService.asmx".
  The port number may be different on your local machine when you download it, but the web service page will still be the same.

#### Check out <a href = "./howtoaddawebserivce">this readme</a> to see how I was able to set up the web service.