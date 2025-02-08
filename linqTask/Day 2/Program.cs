using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Day_2
{
    internal class Program
    {
        /*
                    Where 
                    Indexed where
                    Select
                    Indexed Select
                    Skip
                    Take
                    Skip last
                    Take last
                    Chunk
                    Takewhile
                    Skip while
                    First
                    Last
                    First or default
                    Last or default
                   
                    Single
                    Single or default
                    Distinct


               **     OrderBy 
               **     OrderBy descending
         
         
                   
                    
         */
        static void Main(string[] args)
        {
            List<int> Numbers = [1, 2, 3, 4, 5, 6, 7, 8,9];


            var squares = Numbers.CSkipWhile(x=>x>=3);

            foreach (var num in squares)
            {
               Console.WriteLine(num);
            }

        }
    }
}
