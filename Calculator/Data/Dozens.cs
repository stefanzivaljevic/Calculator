using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    public class Dozens
    {
        public SortedList DozensList { get; set; }

        public Dozens()
        {
            DozensList = new SortedList
            {
                { 1, "deset" },
                { 2, "dvadeset" },
                { 3, "trideset" },
                { 4, "četrdeset" },
                { 5, "pedeset" },
                { 6, "šezdeset" },
                { 7, "sedamdeset" },
                { 8, "osamdeset" },
                { 9, "devedeset" }
            };
        }
    }
}
