using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    public class Hundreds
    {
        public SortedList HundredsList { get; set; }

        public Hundreds()
        {
            HundredsList = new SortedList();

            HundredsList.Add(1, "sto");
            HundredsList.Add(2, "dvesta");
            HundredsList.Add(3, "trista");
            HundredsList.Add(4, "četiristo");
            HundredsList.Add(5, "petsto");
            HundredsList.Add(6, "šeststo");
            HundredsList.Add(7, "sedamsto");
            HundredsList.Add(8, "osamsto");
            HundredsList.Add(9, "devetsto");
        }
    }
}
