
using LibraryList.Models;
using System;
using System.Collections.Generic;

namespace LibraryList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> ct = new CustomList<int>();

            //Custom list add
            ct.Add(10);
            ct.Add(21);
            ct.Add(20);
            ct.Add(25);
            ct.Add(37);
            ct.Add(30);
            ct.Add(10);
            //Custom list remove
            ct.Remove(25);
            //Custom list remove at
            ct.RemoveAt(3);
            //foreach (var item in ct)
            //{
            //    Console.WriteLine(item);
            //}
            //CustomList Find
            int result = ct.CustomFind(n => n % 2 == 0);
            //Console.WriteLine(result);

            //CustomList<int> list = ct.CustomFindAll(x => x == 10);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }
}
