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
            UpTo20List = new SortedList();

            UpTo20List.Add(1, "jedan");
            UpTo20List.Add(2, "dva");
            UpTo20List.Add(3, "tri");
            UpTo20List.Add(4, "četiri");
            UpTo20List.Add(5, "pet");
            UpTo20List.Add(6, "šest");
            UpTo20List.Add(7, "sedam");
            UpTo20List.Add(8, "osam");
            UpTo20List.Add(9, "devet");
            UpTo20List.Add(10, "deset");
            UpTo20List.Add(11, "jedanaest");
            UpTo20List.Add(12, "dvanaest");
            UpTo20List.Add(13, "trinaest");
            UpTo20List.Add(14, "četrnaest");
            UpTo20List.Add(15, "petnaest");
            UpTo20List.Add(16, "šesnaest");
            UpTo20List.Add(17, "sedamnaest");
            UpTo20List.Add(18, "osamnaest");
            UpTo20List.Add(19, "devetnaest");
        }
    }
}
