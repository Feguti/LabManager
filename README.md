# Lab Manager


# How to run
- If running for the first time or running to add information to the database:
````
$ dotnet run -- Computer New 1 16 'Intel core I7'
````
The information to run depends on what you want to add to the database. '1' '16' and 'Intel core I7 are the parameters that you inform to the program.

- If running to list all the informations in the data base: 
````
$ dotnet run -- Computer List
````

# How to import
 - Importing the necessary library to use the database:
````
$ dotnet add package Microsoft.Data.Sqlite
````
