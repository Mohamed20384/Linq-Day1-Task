using System.Linq;
using System.Runtime.CompilerServices;

namespace LINQ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lst = new List<int>() { 2, 4, 6, 3, 9, 8 };

            var res = lst.mywhere<int>(a => a % 2 == 0);
            foreach (var I in res)
            {
                Console.WriteLine(I);
            }
            Console.WriteLine("");
            var resIWhere = lst.myIndexWhere<int>(a => a % 2 == 0, 3);
            foreach (var I in resIWhere)
            {
                Console.WriteLine(I);
            }
            Console.WriteLine("");
            var Chunkres = lst.myChunk<int>(3);
            foreach (var I in Chunkres)
            {
                foreach (var i in I)
                {
                    Console.WriteLine(i);

                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            var selectres = lst.mySelect<int, object>(a => new { id = a });

            foreach (var i in selectres)
            {
                Console.WriteLine(i);

            }
            Console.WriteLine("");
            var Indexselectres = lst.mySelect<int, int, object>((a, b) => new { b = a, id = b });

            foreach (var i in Indexselectres)
            {
                Console.WriteLine(i);

            }
            Console.WriteLine("");
            var myOrderByres = lst.myOrderBy<int, int>((a) => a);

            foreach (var i in myOrderByres)
            {
                Console.WriteLine(i);

            }
            Console.WriteLine();
            var myOrderByDesres = lst.myOrderByDes<int, int>((a) => a);

            foreach (var i in myOrderByDesres)
            {
                Console.WriteLine(i);


            }


        }

    }
    public static class LINQ
    {
        public static IEnumerable<T> mywhere<T>(this List<T> args, Predicate<T> con)
        {
            foreach (var I in args)
            {

                if (con(I))
                {
                    yield return I;
                }
            }
        }
        public static IEnumerable<T> myIndexWhere<T>(this List<T> args, Predicate<T> con, int size)
        {
            int count = 0;
            foreach (var I in args)
            {
                if (count++ <= size)
                {
                    if (con(I))
                    {

                        yield return I;
                    }
                }

            }
        }
        public static IEnumerable<Tresult> mySelect<T, Tresult>(this List<T> args, Func<T, Tresult> con)
        {

            foreach (var I in args)
            {
                yield return con(I);
            }
        }
        public static IEnumerable<Tres> mySelect<T, Tin, Tres>(this List<T> args, Func<int, T, Tres> con)
        {
            int x = 0;
            foreach (var I in args)
            {
                x++;
                yield return con(x, I);
            }
        }
        public static IEnumerable<T> myOrderBy<T, Tres>(this List<T> Source, Func<T, Tres> con) where Tres : IComparable
        {
            var lst = new List<T>(Source);
            for (int i = 0; i < lst.Count - 1; i++)
            {

                for (int j = 0; j < lst.Count - i - 1; j++)
                {
                    if (con(lst[j]).CompareTo(con(lst[j + 1])) > 0)
                    {

                        var temp = lst[j];
                        lst[j] = lst[j + 1];
                        lst[j + 1] = temp;
                    }
                }

            }
            foreach (var I in lst)
            {
                yield return I;
            }

        }
        public static IEnumerable<T> myOrderByDes<T, Tres>(this List<T> Source, Func<T, Tres> con) where Tres : IComparable
        {
            var lst = new List<T>(Source);
            for (int i = 0; i < lst.Count - 1; i++)
            {

                for (int j = 0; j < lst.Count - i - 1; j++)
                {
                    if (con(lst[j]).CompareTo(con(lst[j + 1])) < 0)
                    {

                        var temp = lst[j];
                        lst[j] = lst[j + 1];
                        lst[j + 1] = temp;
                    }
                }

            }
            foreach (var I in lst)
            {
                yield return I;
            }

        }

        public static IEnumerable<T> myTake<T>(this List<T> args, int size)
        {
            int count = 0;
            foreach (var I in args)
            {
                if (count++ <= size)
                {
                    yield return I;
                }

            }
        }
        public static IEnumerable<T> mySkip<T>(this List<T> args, int size)
        {
            int count = 0;
            foreach (var I in args)
            {
                if (count++ > size)
                {
                    yield return I;
                }

            }
        }
        public static IEnumerable<T> myTakeLast<T>(this List<T> args, int size)
        {
            int count = 0;
            args.Reverse();
            foreach (var I in args)
            {
                if (count++ <= size)
                {
                    yield return I;
                }

            }
        }
        public static IEnumerable<T> mySkipLast<T>(this List<T> args, int size)
        {
            int count = 0;
            args.Reverse();
            foreach (var I in args)
            {
                if (count++ > size)
                {
                    yield return I;
                }

            }
        }


        public static IEnumerable<T> myTakeWhile<T>(this List<T> args, Predicate<T> con)
        {
            int count = 0;
            foreach (var I in args)
            {


                if (!con(I))
                {

                    break;
                }
                yield return I;


            }
        }
        public static IEnumerable<T> mySkipWhile<T>(this List<T> args, Predicate<T> con)
        {
            int count = 0;
            foreach (var I in args)
            {
                int x = 0;

                if (con(I) && x == 0)
                {

                    continue;
                }
                else
                {
                    x++;
                    yield return I;
                }



            }
        }
        public static T mySingle<T>(this List<T> args, Predicate<T> con)
        {
            int count = 0;
            T val = default;
            if (args == null)
            {
                throw new ArgumentNullException("You have null Source");
            }
            foreach (T I in args)
            {

                if (con(I))
                {
                    count++;
                    val = I;
                }

            }
            if (count == 1)
            {

                return val;
            }
            else
            {
                throw new Exception("May not found or more one found");
            }
        }
        public static T mySingleorDefult<T>(this List<T> args, Predicate<T> con)
        {
            int count = 0;
            T val = default;

            foreach (T I in args)
            {

                if (con(I))
                {
                    count++;
                    val = I;
                }

            }
            if (count == 1 || count == 0)
            {

                return val;
            }
            else
            {
                throw new Exception("May not found or more one found");
            }
        }

        public static IEnumerable<T> myDistict<T>(this List<T> source)
        {
            var ls = new List<T>();

            foreach (var I in source)
            {
                foreach (var i in source)
                {
                    ls.Add(I);
                    if (i.Equals(I))
                    {
                        ls.Remove(I);
                    }
                }
            }

            return ls;
        }

        public static T myfirst<T>(this List<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("You have null source data");
            return source[0];
        }
        public static T mylast<T>(this List<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("You have null source data");
            return source[source.Count];
        }
        public static T myfirstorDefult<T>(this List<T> source)
        {
            if (source == null)
                return default;
            return source[0];
        }
        public static T mylastorDefult<T>(this List<T> source)
        {
            if (source == null)
                return default;
            return source[source.Count];
        }
        public static T[][] myChunk<T>(this List<T> source, int num)
        {
            int size = (int)Math.Ceiling((double)source.Count / num);
            T[][] my2Darr = new T[num][];
            var x = 0;
            for (int i = 0; i < num; i++)
            {

                var temp = new T[size];
                for (int c = 0; c < size; c++)
                {

                    temp[c] = source[c + x];
                }
                my2Darr[i] = temp;
                x += size;
            }
            return my2Darr;
        }
    }
}