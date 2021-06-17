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
            DozensList = new SortedList();

            DozensList.Add(1, "deset");
            DozensList.Add(2, "dvadeset");
            DozensList.Add(3, "trideset");
            DozensList.Add(4, "četrdeset");
            DozensList.Add(5, "pedeset");
            DozensList.Add(6, "šezdeset");
            DozensList.Add(7, "sedamdeset");
            DozensList.Add(8, "osamdeset");
            DozensList.Add(9, "devedeset");
        }
    }
}
