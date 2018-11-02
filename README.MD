Mid-Term Exam: LINQ and Entity Framework Core

The exam involved you executing the following activities utilzing LINQ to target Entity Framework Core. Please utilize whichever LINQ syntax that you are most comfortable with (Method or Query).

Preliminary Activities
1) Create a class called Book
2) Create a Class called Author
3) Ensure that a book keeps an Author as a Foreign Key (yes, I know this potentially limits a book to having one author, which okay given our limited time here).
4) Override the ToString method of each class so that we can specify what it looks like when you print a Book or Author to the console
5) Do all the setup required to use Entity Framework Core to connect to a SQLite database
6) Seed the database with the information required to make three books and two authors

Books and Authors: 

Title: Pro ASP.NET Core MVC 2 7th ed. Edition
Publisher: Apress
Publish Date: October 25, 2017
Author: Adam Freeman
Pages: 1017 

Title: Pro Angular 6 3rd Edition
Publisher: Apress
Publish Date: October 10, 2018
Author: Adam Freeman 
Pages: 776 

Title: Programming Microsoft Azure Service Fabric (Developer Reference) 2nd Edition
Publisher: Microsoft Press
Publish Date: May 25, 2018
Author: Haishi Bai
Pages: 528

NOTE: you may have to use a JOIN to answer several of the questions below 

Using the LINQ Where Method
1) In your program, connect to the database and show all records in the Books table, print this to the Console
2) In your program, connect to the database and show all records of Books Published by "APress"
3) In your program, connect to the database and show all records of Books whose author's first name is the shortest 

Using the LINQ Find Method
1) In your program, onnect to the database and find the first book by an author named "Adam" and print that record to the screen
2) In your program, onnect to the database and find the first book whose page count is greater than 1000

Using the LINQ OrderBy Method
1) Connect to the database and show all Books sorted by Author's last name
2) Connect to the database and show all Books sorted by book title descending

Using the LINQ GroupBy and OrderBy Methods
1) Connect to the database and show all Books Grouped by publisher
2) Connect to the database and show all Books Grouped by publisher and sorted by Author's last name

How to submit this work
Create or add to an existing repository at Github and push your final solution to that repository.  Please then submit the URL to your repo here.
Also, ZIP up the repo and submit here to this dropbox.

