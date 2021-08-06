[![.NET CI](https://github.com/marysaray/eCommerceWebsiteExample/actions/workflows/dotnet.yml/badge.svg)](https://github.com/marysaray/eCommerceWebsiteExample/actions/workflows/dotnet.yml)

# eCommerce Website Example
Building a dynamic website while integrating a professional process to implement Front-End and Back-End development.

## Prerequisites
- [.NET Core 3.1](https://dotnet.microsoft.com/download/visual-studio-sdks)
- [Visual Studio](https://visualstudio.microsoft.com/) with ASP.NET and Web Dev workload
OR [Visual Studio Code](https://code.visualstudio.com/)

### IBM Cloud Education: [Resource](https://www.ibm.com/cloud/learn/continuous-integration#:~:text=The%20following%20are%20a%20few%20of%20the%20most,other%20parts%20of%20the%20software%20More%20items...%20)

    Continuous Integration
    
        In this guide, learn more about continuous integration, 
        a software development and DevOps practice in which each developer integrates
        their new code into the main branch of code at least once a day.

    What is continuous integration?

        Continuous integration is a software development process where developers
        integrate the new code they've written more frequently throughout the development cycle, 
        adding it to the code base at least once a day.
        Automated testing is done against each iteration of the build to identify integration issues earlier, 
        when they are easier to fix , which also helps avoid problems at the final merge for the release. 
        Overall, continuous integration helps streamline the build process,
        resulting in higher-quality software and more predictable delivery schedules.

*Default Pull-Request Workflow**

    Professional Process:
    
    1.) Make a new branch
    2.) Pick an issue to work on
    3.) Fix or Implement issue
    4.) Pull Request
    5.) Merge back into the main branch
    
*Use LibMan with ASP.NET Core in Visual Studio:*

Resource: https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-5.0

*Data-Driven Websites:* Productive Development with Entity Framework*


    ORM - Object Relational Mapping:
    
        PRO:
            * Modern database driven application development
            * Microsoft recommended approach
            * Microsoft's ADO.NET Entity Framework (EF) is free!
            * Abstraction
                * Utilize Object Oriented Programming (OOP) skills
                * Auto-parameterize queries to prevent SQL Injection attacks
            * Strong-Typing
                * Intellisense support and compile time checking
                * Less runtime errors
        CON:
            * Small performance overhead
                * However, good boost in productivity
            * Abstraction
                * Generated queries aren't always optimal
                * The database layer is sometimes ignored by developers
        
            
Resource: [Tutorial: Get started with EF Core in an ASP.NET MVC web app](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1)

    Enitity Framework (EF):
        
        - EF runs on the full .NET Framework
        - EF Core runs on .NET Core
        - EF and EF Core are extremely similar
        - Can be used with a variety of application types 
        - Fast development of ASP.NET Websites
        - Mainly for relational databases currently (EF Core 2.X)
        
*LINQ - **L**anguage **IN**tegrated **Q**uery:*
        
        - Query language built into C#
        - Compile time checking
        - Like SQL queries
        - LINQ can be used for:
            * XML
            * in-memory objects
            * databases
            * and more..
*Query Syntax vs. Method Syntax:*
    
    Query Syntax:
        
        List<Student> stuList = ( from student in studentDB
                                  where student.FirstName == "Mary"
                                  select student).ToList();
                                  
    Method Syntax:
    
        List<Student> stuList = studentDB 
                                .Students
                                .Where(s=>s.FirstName=="Mary")
                                .ToList()
*Development Approaches:*

    Code First:
    
        - Create a database from your classes (Empty Model template)
            - All tables will be created for you
            - Updates are done through code first migrations
        - Reverse engineer a database into classes (Reverse engineer database)
        
    Database First:
    
        - Use an existing database
        
    *Stick with the specific approach:
    
        - Database First:
            you must alter the database using SQL
            
        - Code First: 
            you must alter the database by changing your classes
            
Resource: [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1)
Reference for Design Patterns: [Architectural principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)

[Lambda expressions (C# reference)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)

[readonly (C# Reference)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly)

[IEnumerable<T> Interface](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-5.0)
    
### Bootstrap v4.6*
Tables:
[Documentation and examples for opt-in styling of tables (given their prevalent use in JavaScript plugins) with Bootstrap.](https://getbootstrap.com/docs/4.6/content/tables/)

Buttons:
[Use Bootstrap’s custom button styles for actions in forms, dialogs, and more with support for multiple sizes, states, and more.](https://getbootstrap.com/docs/4.6/components/buttons/)
