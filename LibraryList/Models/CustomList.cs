using System;
using System.Collections;
using System.Collections.Generic;
using CustomExceptions.Exceptions;

namespace LibraryList.Models
{
    public class CustomList<T> : IEnumerable<T>
    {
        public T[] list;
        private static int _count;
        private int _capacity;
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value > 0)
                {
                    _capacity = value;
                }
                throw new CapacityNumberWrong("Capacity value is not correctly");
            }
        }

        public CustomList()
        {

            list = new T[0];
        }

        public CustomList(int capacity)
        {
            _capacity = capacity;
            list = new T[capacity];
        }

        /// <summary>
        /// Adds an element to a array.
        /// </summary>
        /// <param name="item">Type the item you want to add</param>
        public void Add(T item)
        {
            Array.Resize(ref list, list.Length + 1);
            list[^1] = item;
            _count++;
            if (_count == _capacity)
            {
                _capacity *= 2;
                Array.Resize(ref list, _capacity);
            }
        }

        /// <summary>
        /// Deletes the array element according to the inserted element
        /// </summary>
        /// <param name="items">Enter the item you want to delete</param>
        /// <returns>If it finds the item, it deletes it and returns <b>true</b>, if it does not find it, it return <b>false</b> </returns>
        public void Remove(T items)
        {
            int index = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(items))
                {
                    index = i;
                }
            }
            for (int i = index; i < list.Length; i++)
            {
                if (i + 1 < list.Length)
                {
                    list[i] = list[i + 1];
                }
            }
            Array.Resize(ref list, list.Length - 1);
        }

        /// <summary>
        /// Deletes the array element according to the index you entered
        /// </summary>
        /// <param name="index">Enter the index of the item you want to delete</param>
        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                throw new IndexNumberWrong("The index cannot be negative.");
            }
            for (int i = 0; i < list.Length; i++)
            {
                for (int z = 0; z < list.Length - i - 1; z++)
                {
                    T a = list[index + 1];
                    list[index] = a;
                }
            }
        }

        /// <summary>
        /// Array writes in reverse
        /// </summary>
        public void Reverse()
        {
            Array.Reverse<T>(list);
        }


        /// <summary>
        /// The array writes in reverse, but according to the index and counter we entered
        /// </summary>
        /// <param name="index">The array is reversed from the <b>index</b> you entered</param>
        /// <param name="count">According to the counter you entered, the array will be inverted up to that counter</param>
        public void Reverse(int index, int count)
        {
            if (index < 0 && count < 0)
            {
                throw new IndexNumberWrong("The index cannot be negative.");
            }
            Array.Reverse(list, index, count);
        }

        /// <summary>
        /// Displays the index of the array you entered
        /// </summary>
        /// <param name="item">Enter the elemt of the index you want</param>
        /// <returns>Returns the index of the array you entered</returns>
        public int IndexOF(T item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Displays the index of the array you entered, but starts last one
        /// </summary>
        /// <param name="item">Enter the elemt of the index you want</param>
        /// <returns>Returns the index of the array you entered</returns>
        public int LastIndexOF(T item)
        {
            for (int i = list.Length - 1; i >= 0; i--)
            {
                if (list[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// Cleans Array elements
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = default(T);
            }

        }

        /// <summary>
        /// Gets or sets the element at the specifield index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Returns the index element we entered</returns>
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        /// <summary>
        /// Checks for an element in the array
        /// </summary>
        /// <param name="item">Enter the item you want to check</param>
        /// <returns>Returns true if true, false if not</returns>
        public bool Contains(T item)
        {
            for (int i = list.Length - 1; i >= 0; i--)
            {
                if (list[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">Delegate that defines the conditions of the elements tosearch for.</param>
        /// <returns>Containing all the elements that match the
        //conditions defined by the specified predicate, if found; otherwise, an empty</returns>
        public T CustomFind(Predicate<T> match)
        {
            if (match == null)
            {
                throw new Exception();
            }

            for (int i = 0; i < list.Length; i++)
            {
                if (match(list[i]))
                {
                    return list[i];
                }
            }
            return default(T);
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">Delegate that defines the conditions of the elements tosearch for</param>
        /// <returns>CustomList<T></returns>
        public CustomList<T> CustomFindAll(Predicate<T> match)
        {

            CustomList<T> listAd = new CustomList<T>();
            for (int i = 0; i < list.Length; i++)
            {
                if (match(list[i]))
                {
                    listAd.Add(list[i]);
                }
            }
            return listAd;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T elm in list)
            {
                yield return elm;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
