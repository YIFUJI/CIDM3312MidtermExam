using System;

namespace exam
{
    public class Book
    {
        public int BookID {get; set;}  //PRMARY KEY

        public string BookTitle {get; set;}

        public string Publisher {get; set;}

        public string PublisherDate {get; set;}

        public string BookPages {get; set;}

        public int AuthorID {get ; set;} //FOREIGN KEY
        
        public override string ToString()
        {
            return this.BookID + "_" + this.BookTitle + "Publisher is" + this.Publisher;
        }
        
    }
}