using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    public class UpTo20
    {
        public SortedList UpTo20List { get; set; }

        public UpTo20()
        {
            UpTo20List = new SortedList
            {
                { 1, "jedan" },
                { 2, "dva" },
                { 3, "tri" },
                { 4, "četiri" },
                { 5, "pet" },
                { 6, "šest" },
                { 7, "sedam" },
                { 8, "osam" },
                { 9, "devet" },
                { 10, "deset" },
                { 11, "jedanaest" },
                { 12, "dvanaest" },
                { 13, "trinaest" },
                { 14, "četrnaest" },
                { 15, "petnaest" },
                { 16, "šesnaest" },
                { 17, "sedamnaest" },
                { 18, "osamnaest" },
                { 19, "devetnaest" }
            };
        }
    }
}
