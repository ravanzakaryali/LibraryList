
using LibraryList.Models;
using System;
using System.Collections.Generic;

namespace LibraryList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> my = new List<int>();

            my.Add(32);
            my.Add(43);
            var newList = my.FindAll(x => x == 32);
            //Console.WriteLine(my.FindAll(x => x == 32));
            //foreach (var item in newList)
            //{
            //    Console.WriteLine(item);
            //}

            CustomList<int> ct = new CustomList<int>();

            ct.Add(10);
            ct.Add(21);
            ct.Add(20);
            ct.Add(20);
            ct.Add(10);

            //Console.WriteLine(ct.Capacity);

            CustomList<int> list = ct.CustomFindAll(x => x == 10);
            //Console.WriteLine(ct.CustomFindAll(x => x == 10));
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //Predicate<int> Sum = n => n % 2   == 0;
            //Console.WriteLine(Sum(1));
        }
    }
}
