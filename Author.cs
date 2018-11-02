using System;

namespace exam
{
    public class Author
    {
        public int AuthorID {get; set;}  //PRMARY KEY

        public string AuthorFirstName {get; set;}

        public string AuthorLastName {get ; set;}

        public override string ToString()
        {
            return this.AuthorID + "_" + this.AuthorFirstName + this.AuthorLastName;
        }

    }
}