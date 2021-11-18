using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = File.ReadLines(args[0]).ToList();
            List<string> outputList = new List<string>();

            foreach (var outside in GetKCombs(inputList, 2))
            {
                string sentence = string.Empty;
                foreach (var inner in outside)
                {
                    foreach (var @char in inner)
                    {
                        sentence += @char;
                    }
                    sentence += " - ";
                }
                outputList.Add(sentence);
            }

            File.WriteAllLines(args[1], outputList);
        }

        static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
