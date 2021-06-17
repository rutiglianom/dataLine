// Matthew Rutigliano
// 4 May 2021
// Revision History: createHetCollection, retrieveAll, queryAll, resetAll written 5/2/21

// Program overview:
// A heterogeneous collection of dataLines, dataMirrors, and dataInserts is created
// The entire contents of each object's internal array are printed using retrieve
// The results of each object being queried for a value are shown
// Retrieve is called with a bad value on each object to trigger a state change to inactive
// Each object is reset, with the results being shown
// This is repeated three times to provoke permanent deactivation
// Each object is queried one more time to provoke insert values changing
// Half of each object's contents are printed again to observe this

using System;

namespace P3
{
    class Program
    {
        static void Main(string[] args)
        {
            int ARR_SIZE = 5;

            dataLine[] dataArr = createHetCollection(ARR_SIZE);

            retrieveAll(dataArr, 100, true);

            queryAll(dataArr, 1);

            for(int i=0; i<3; i++)
            {
                retrieveAll(dataArr, -5, false);
                resetAll(dataArr);
            }

            queryAll(dataArr, 7);

            retrieveAll(dataArr, 4, true);

        }

        static dataLine[] createHetCollection(int arrsize)
        {
            dataLine[] dataArr = new dataLine[arrsize * 3];
            int[] inputArr = null;
            for (int i = 0; i < dataArr.Length; i += 3)
            {
                inputArr = new int[] { i, i + 1, i + 2 };
                dataArr[i] = new dataLine(inputArr);
                dataArr[i + 1] = new dataMirror(inputArr);
                dataArr[i + 2] = new dataInsert(inputArr);
            }
            return dataArr;
        }

        static void retrieveAll(dataLine[] arr, int val, bool printResults)
        {
            int[] results = null;
            Console.WriteLine($"Retrieving contents of each object with y={val}:");
            for (int i=0; i<arr.Length; i++)
            {
                results = arr[i].retrieve(val);
                if (printResults)
                {
                    Console.Write($"{i}: ");
                    if (results != null)
                    {
                        foreach (int x in results)
                            Console.Write($"{x}, ");
                    }
                    else
                        Console.Write("Null result");
                    Console.WriteLine();
                }
            }
        }

        static void queryAll(dataLine[] arr, int val)
        {
            bool result = false;
            Console.WriteLine($"Querying each object with y={val}");
            for (int i = 0; i < arr.Length; i++)
            {
                result = arr[i].query(val);
                Console.WriteLine($"{i}: {result}");
            }
        }

        static void resetAll(dataLine[] arr)
        {
            Console.WriteLine($"Resetting all objects in inactive state");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i} state: {arr[i].State}    ");
                if (!arr[i].State)
                    Console.Write($"State after reset: {arr[i].reset()}");
                Console.WriteLine();
            }
        }
    }
}
