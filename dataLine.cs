// Matthew Rutigliano
// 4 May 2021
// Revision History: Data members, constructor, query, retrieve written 4/28/21
// reset written 4/29/21

// Class Invariant:
// dataLine object encapsulates integer array
// Integer array is supplied by client at object instantiation
// Not supplying an integer array will cause object to be created in permanent inactive state
// Supplying an integer array of length less than 1 will cause object to be created in permanent inactive state
// Calling query with value y will return a boolean indicating if y is in the array
// Calling retrieve with value z will return an array containing the first z values of the array
//     If z is greater than the length of the array, the contents of the  entire array will be returned
//     If z is less than 1, retrieve returns a null pointer, and the object is made inactive
// While inactive, query will always return false, and retrieve will return a null pointer
// Reset returns state to active (unless object was instantiated with no array or an array with length less than 1)
// State returns boolean indicating if object is active (true) or inactive (false)
// Client must track active state

// Interface Invariant:
// Client must track active state

using System;
using System.Collections.Generic;
using System.Text;

namespace P3
{
    public class dataLine
    {
        private bool state;
        protected int[] x;
        private const int MIN_LENGTH = 0;

        // Postcondition: Object may become inactive
        public dataLine(int[] arr = null)
        {
            x = arr;
            state = (x != null);
            if (state)
                state = x.Length > MIN_LENGTH;
        }

        public virtual bool query(int y)
        {
            if (state)
            {
                foreach (int val in x)
                {
                    if (val == y)
                        return true;
                }
            }
            return false;
        }

        // Postcondition: Object may become inactive
        public virtual int[] retrieve(int count = -1)
        {
            state = count > MIN_LENGTH;
            int[] subset = null;

            if (state)
            {
                int size = (count < x.Length) ? count : x.Length;
                subset = new int[size];
                for (int i = 0; i < size; i++)
                    subset[i] = x[i];
            }
            return subset;
        }

        // Postcondition: Object may become active
        public virtual bool reset()
        {
            state = x != null;
            return state;
        }

        public bool State
        {
            get => state;
        }
    }
}

// Implementation Invariant:
// State parameter controls query, retrieve
// Query, retrieve, reset are virtual to enable class extensions