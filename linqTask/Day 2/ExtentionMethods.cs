namespace Day_2;

public static class CustomExtentionMethods
{
    // Where

    public static IEnumerable<T> CWhere<T>(this IEnumerable<T>Source, Func<T, bool> predicate)
    {
        List<T> MyNums = new List<T>();

        foreach (var num in Source)
        {
            if (predicate(num))
            {
                MyNums.Add(num);
            }

        }
        return MyNums;
    }

    // WhereWithIndex

    public static IEnumerable<T> CWhereWithIndex<T>(this IEnumerable<T> Source, Func<T, bool> predicate , int Index)
    {
        List<T> MyNums = new List<T>();

        int Counter = 0;

        foreach (var num in Source)
        {
            if (predicate(num)&&Counter < Index)
            {
                MyNums.Add(num);
                Counter++;
            }
            else if (Counter >= Index)
            {
                break;
            }

        }
        return MyNums;
    }

    // Select

    public static IEnumerable<T> CSelect<Source, T>(this IEnumerable<Source> source, Func<Source, T> selector)
    {
        List<T> MyNums = new List<T>();


        foreach (var item in source)
        {
             MyNums.Add(selector(item)); 
        }

        return MyNums;
    }

    // SelectWithIndex

    public static IEnumerable<T> CSelectWithIndex<Source, T>(this IEnumerable<Source> source, Func<Source, T> selector, int Index)
    {
        List<T> MyNums = new List<T>();

        int Counter = 0;

        foreach (var item in source)
        {
            if (Counter >= Index)
            {
                break;
            }
            MyNums.Add(selector(item));
            Counter++;
        }

        return MyNums;
    }

    //  Take
    public static IEnumerable<T> CTake<T>(this IEnumerable<T> source, int count)
    {
        List<T> MyNums = new List<T>();

        int Counter = 0;

        foreach (var item in source)
        {
            if (Counter >= count)
            {
                break;
            }
            MyNums.Add(item);
            Counter++;
        }

        return MyNums;
    }


    // Skip 

    public static IEnumerable<T> CSkip<T>(this IEnumerable<T> source, int count)
    {
        List<T> MyNums = new List<T>();

        int Counter = 0;

        foreach (var item in source)
        {
           if(Counter >= count)
           {
               MyNums.Add(item);
           }
           Counter++;
        }

        return MyNums;

    }

    // TakeLast 

    public static IEnumerable<T> CTakeLast<T>(this IEnumerable<T> source, int count)
    {    
        List<T> MyNums = new List<T>();

        int length = source.Count();

        int counter = 0;


        foreach (var item in source)
        {
            if ((length - counter) <= count)
            {
                 MyNums.Add(item);
            }
            counter++;
        }

        return MyNums;


    }

    // SkipLast
    public static IEnumerable<T> CSkipLast<T>(this IEnumerable<T> source, int count)
    {
        List<T> MyNums = new List<T>();
        
        int length = source.Count();

        int counter = 0;


        foreach (var item in source)
        {
            if ((length - counter) > count)
            {
                MyNums.Add(item);
            }
            counter++;
        }

        return MyNums;
    }

    // Chunk

    public static IEnumerable<T[]> CChunk<T>(this IEnumerable<T> source, int size)
    {
 
        List<T[]> part = new List<T[]>();  

        List<T> FinalResult = new List<T>(size);   

        foreach (var item in source)
        {
            FinalResult.Add(item);
            if (FinalResult.Count == size)
            {
                part.Add(FinalResult.ToArray()); 
                FinalResult.Clear();               
            }
        }

        return part;
    }


    // TakeWhile
    public static IEnumerable<T> CTakeWhile<T>(this IEnumerable<T> source,Func<T,bool> predicate)
    {
        List<T> MyNums = new List<T>();

     

        foreach (var item in source)
        {
            if (predicate(item)) 
            {
                MyNums.Add(item);
            };

        }

        return MyNums;
    }

     // SkipWhile
    public static IEnumerable<T> CSkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        List<T> MyNums = new List<T>();



        foreach (var item in source)
        {
            if (predicate(item))
            {
               continue;
            };
            MyNums.Add(item);

        }

        return MyNums;
    }

    // First
    public static T CFirst<T>(this IEnumerable<T> source)
    {

        foreach (var item in source)
        {
            return item;
        }

        throw new Exception("Sequence contains no elements.");
    }

    // Last
    public static T CLast<T>(this IEnumerable<T> source)
    {

        int length = source.Count();

        int counter = 0;

        T last = default(T);

        foreach (var item in source)
        {
            if (counter == length)
            {
                last =  item;
                break;
            }

            counter++;
        }

        return last;
    }

    // FirstOrDefault
    public static T CFirstOrDefault<T>(this IEnumerable<T> source)
    {
        T first = default(T);

        foreach (var item in source)
        {
            return item;
        }

        return first;

    }

    // LastOrDefault
    public static T CLastOrDefault<T>(this IEnumerable<T> source)
    {

        int length = source.Count();

        int counter = 0;

        T last = default(T);

        foreach (var item in source)
        {
            if (counter == length)
            {
                return item;
                
            }

            counter++;
        }

        return last;
    }

    // Single
    public static T CSingle<T>(this IEnumerable<T> source)
    {

        T single = default(T);
        bool found = false;

        foreach (var item in source)
        {
            if (found)
            {
                throw new Exception("Sequence contains more than one element.");
            }
            single = item;
            found = true;
        }

       
        return single;
    }

    // SingleOrDefault
    public static T CSingleOrDefault<T>(this IEnumerable<T> source)
    {

        T single = default(T);

        bool found = false;

        foreach (var item in source)
        {
            if (found)
            {
                throw new Exception("Sequence contains more than one element.");
            }
            single = item;
            found = true;
        }

        return single;  
    }

    // Distinct
    public static List<T> CDistinct<T>(this IEnumerable<T> source)
    {

        List<T> result = new List<T>();

        foreach (var item in source)
        {
            if (!result.Contains(item))  
            {
               result.Add(item);
            }
        }

        return result;
    }

}