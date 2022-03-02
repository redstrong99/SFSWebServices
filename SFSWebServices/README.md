## Application Structure

Based on the test data structure, three data modal classes are created - CreditReport, Credit, and Tradeline. They are for storing the deserilized data from the test data.

An API controller is created for two web services - Service #1 and Service #2.

A CreditReport Service is created to retrieve the data from the remote data source. To decouple the dependency between the API controller and the CreditReport Service, an interface of CreditReport Service is created. This service is injected into the API controller through the constructor. This Dependency is registered in the ConfigServices method of the Startup class.



## How To Run the Application

Download the repository, install two packages if needed - NewtonSoft.Json and SwasdhBuckle.AspNetCore. Run the application and a Swagger page will be displayed. There are two endpoints under Report. /api/report/credit is for Service #1 and /api/report/dti is for Service #2. You can test both endpoints on the Swagger page.

 

