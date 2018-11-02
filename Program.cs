using System;
using System.Collections.Generic;
using System.Linq;

namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeBooks();
            MakeAuthor();
        }

        static void MakeBooks()
        {
            using(var db = new AppDbContext())
            {
                try
                {

                    db.Database.EnsureCreated();

                    if(!db.Book.Any())
                    {
                        List<Book> Book = new List<Book>()
                        {
                            new Book()
                            {
                                BookTitle = "Pro ASP.NET Core MVC 2 7th ed. Edition",
                                Publisher = "Apress",
                                PublisherDate = "October 25, 2017",
                                AuthorID = 1,
                                BookPages = "1017"
                            },
                            new Book()
                            {
                                BookTitle = "Pro Angular 6 3rd Edition",
                                Publisher = "Apress",
                                PublisherDate = "October 10, 2018",
                                AuthorID = 2,
                                BookPages = "776 "
                            },
                            new Book()
                            {
                                BookTitle = "Programming Microsoft Azure Service Fabric (Developer Reference) 2nd Edition",
                                Publisher = "Microsoft Press",
                                PublisherDate = "May 25, 2018",
                                AuthorID = 3,
                                BookPages = "528"
                            },                        
                        };

                        db.Book.AddRange(Book);  

                        db.SaveChanges();                                              

                    }
                    else
                    {
                        //                  Using the LINQ Where method                //

                        //1.In your program, connect to the database and show all records in the Books table, print this to the Console
                        // var Book = db.Book.ToList();
                        // foreach(Book b in Book)
                        // {
                        //     Console.WriteLine(b);
                        // }

                         //2) In your program, connect to the database and show all records of Books Published by "APress"
                        //  var Book = db.Book.ToList();
                        //  var APress =Book.Where(b => b.Publisher == "APress");
                        // foreach(Book b in APress)
                        // {
                        //     Console.WriteLine(b);

                        //3) In your program, connect to the database and show all records of Books whose author's first name is the shortest
                        // var BookAuthorJoin = db.Book.Join
                        // (
                        //     db.Author,
                        //     b => b.AuthorID,
                        //     a => a.AuthorID,
                        //     (b,a) => new
                        //     {
                        //         BookTitle = b.BookTitle,
                        //         Publisher = b.Publisher,
                        //         PublishDate = b.PublisherDate,
                        //         BookPages = b.BookPages,
                        //         AuthorFirstName = a.AuthorFirstName,
                        //         AuthorLastName = a.AuthorLastName
                        //     }
                        // );
                        // var ShortestName =  BookAuthorJoin.Min (a => a.AuthorFirstName);
                        // var ShortestNameList = BookAuthorJoin.Where(a => a.AuthorFirstName == ShortestName);
                        // foreach(var b in ShortestNameList)
                        // {
                        //   Console.WriteLine(b);
                        // }




                        //                   Using the LINQ Find Method                //

                        //1) In your program, onnect to the database and find the first book by an author named "Adam" and print that record to the screen
                        // var BookAuthorJoin = db.Book.Join
                        // (
                        //      db.Author,
                        //      b => b.AuthorID,
                        //      a => a.AuthorID,
                        //      (b,a) => new
                        //     {
                        //         BookTitle = b.BookTitle,
                        //         Publisher = b.Publisher,
                        //         PublishDate = b.PublisherDate,
                        //         BookPages = b.BookPages,
                        //         AuthorFirstName = a.AuthorFirstName,
                        //         AuthorLastName = a.AuthorLastName
                        //     }
                        // )
                        // Console.WriteLine(BookAuthorJoin.Find(a => a.AuthorFirstName == "Adam"));

                        //2) In your program, onnect to the database and find the first book whose page count is greater than 1000
                        // var Books = db.Book.ToList();
                        // Console.WriteLine(Books.Find(p => p.BookPages > 1000 ));
                         

                        

                        //                 Using the LINQ OrderBy Method                  //

                        //1) Connect to the database and show all Books sorted by Author's last name
                        // var BookAuthorJoin = db.Book.Join
                        // (
                        //       db.Author,
                        //       b => b.AuthorID,
                        //       a => a.AuthorID,
                        //       (b,a) => new
                        //      {
                        //         BookTitle = b.BookTitle,
                        //         Publisher = b.Publisher,
                        //         PublishDate = b.PublisherDate,
                        //         BookPages = b.BookPages,
                        //         AuthorFirstName = a.AuthorFirstName,
                        //         AuthorLastName = a.AuthorLastName
                        //     }
                        // );
                        // var LstNameList = BookAuthorJoin.OrderBy (a => a.AuthorLastName);
                        // foreach(var b in SortNameList)
                        // {
                        //     Console.WriteLine(b);
                        // }

                        //2) Connect to the database and show all Books sorted by book title descending
                        // var Book = db.Book.ToList();
                        // var BookTitleDescending = Book.OrderByDescending(b =>b.BookTitle);
                        // foreach(Book b in BookTitleDescending)
                        // {
                        //      Console.WriteLine(b);
                        // }




                        //                Using the LINQ GroupBy and OrderBy Methods             //

                        //1) Connect to the database and show all Books Grouped by publisher
                        // var Book = db.Book.ToList();
                        // var GroupsByPublisher = Book.GroupBy (b =>b.Publisher);
                      
                        // foreach(var group in GroupsByPublisher)
                        // {
                        //     Console.WriteLine($"Group Publisher: {group.Key}");
                        //        foreach (var b in group)
                        //        {
                        //            Console.WriteLine(b);
                        //        }
                        // }

                        //2) Connect to the database and show all Books Grouped by publisher and sorted by Author's last name
                        var BookAuthorJoin = db.Book.Join
                        (
                                db.Author,
                                b => b.AuthorID,
                                a => a.AuthorID,
                                (b,a) => new
                            {
                                BookTitle = b.BookTitle,
                                Publisher = b.Publisher,
                                PublishDate = b.PublisherDate,
                                BookPages = b.BookPages,
                                AuthorFirstName = a.AuthorFirstName,
                                AuthorLastName = a.AuthorLastName
                            }
                        ).ToList();
                        var SortByLastName = BookAuthorJoin.OrderBy(a =>a.AuthorLastName);
                        var groupByBook = SortByLastName.GroupBy(b =>b.Publisher);
                        foreach(var group in groupByBook)
                        {
                            Console.WriteLine($"Publisher Group :{group.Key}");
                            foreach(var b in group)
                            {
                                Console.WriteLine(b);
                            }
                        }
                    }

                    if(!db.Author.Any())
                    {
                        List<Author> Author = new List<Author>()
                        {
                            new Author()
                            {
                                AuthorID = 1,
                                AuthorFirstName = "Adam",
                                AuthorLastName = "Freeman"
                            },
                            new Author()
                            {
                                AuthorID = 2,
                                AuthorFirstName = "Haishi",
                                AuthorLastName = "Bai"
                            },  
                        };

                        db.Author.AddRange(Author);  

                        db.SaveChanges();                                              

                    }

                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }

        static void MakeAuthor()
        {
            using(var db1 = new AppDbContext())
            {
                try
                {
                    db1.Database.EnsureCreated();

                    if(!db1.Author.Any())
                    {
                        List<Author> Author = new List<Author>()
                        {
                            new Author()
                            {
                                AuthorID = 1,
                                AuthorFirstName = "Adam",
                                AuthorLastName = "Freeman", 
                            }, 

                            new Author()
                            {
                                AuthorID = 2,
                                AuthorFirstName = "Haishi",
                                AuthorLastName = "Bai", 
                            }, 
                        };

                        db1.Author.AddRange(Author);

                        db1.SaveChanges();
                    }
                    else
                    {
                        var Author = db1.Author.ToList();
                        foreach(Author a in Author)
                        {
                            Console.WriteLine(a);
                        }
                    }
                
                }
                catch(Exception exp1)
                {
                Console.WriteLine(exp1.Message);
                }
            }
        }   
    }
}