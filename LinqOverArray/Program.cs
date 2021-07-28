using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Linq query");
            QueryOverString();
            QueryOverStringWithExtensionMethod();
            QueryOverIntegers();
            ImmediateExecution();

            Console.ReadLine();
        }

        private static void ImmediateExecution()
        {
            Console.WriteLine("fun with ImmediateExecution");
            int[] myIntegers = { 20, 3, 2, 4, 40, 15, 1, 8, 18 };
            //returning result as int[]
            int[] subsetAsArray = (from i in myIntegers where i < 10 select i).ToArray();//or ToArray<int>
            //returning result as a list<int>
            List<int> subsetAsList = (from i in myIntegers where i < 10 select i).ToList();//or ToList<int>



        }

        private static void QueryOverIntegers()
        {
            Console.WriteLine("fun with QueryOverIntegers");
            int[] myIntegers = { 20, 3, 2, 4, 40, 15, 1, 8, 18 };
            //implicit typing
            var subset = from i in myIntegers where i < 10  select i;

            //print the subset 
            // linq query executed here

            foreach(var n in subset)
            {
                Console.WriteLine("{0} < 10", n);

            }

            // do some modification
            myIntegers[0] = 6;

            //linq query executed again
            Console.WriteLine("After modification");
            foreach (var n in subset)
            {
                Console.WriteLine("{0} < 10", n);

            }
        }

        static void QueryOverString()
        {
            //assume we have array of strings
            string[] currJwVideos = new string[] { "Lot Wife 1", "Prodigal Son", "True Love 2", "Hezekiah" };

            //build a QUERY expression to find the item in the array
            //that have an embedded space
            IEnumerable<string> subset = from v in currJwVideos
                                         where v.Contains(" ")
                                         orderby v
                                         select v;
            //print out the result
            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}",s);
            }
        }

     static void   QueryOverStringWithExtensionMethod()
        {
            Console.WriteLine("fun with QueryOverStringWithExtensionMethod");
            //assume we have array of strings
            string[] currJwVideos = new string[] { "Lot Wife 1", "Prodigal Son", "True Love 2", "Hezekiah" };

            //build a QUERY expression to find the item in the array
            //that have an embedded space
            IEnumerable<string> subset = currJwVideos.Where(v => v.Contains("1")).OrderBy(v => v).Select(v => v);

            //print out the result
            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }

     }

    }
}
