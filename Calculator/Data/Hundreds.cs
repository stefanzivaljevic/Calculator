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
            HundredsList = new SortedList
            {
                { 1, "sto" },
                { 2, "dvesta" },
                { 3, "trista" },
                { 4, "četiristo" },
                { 5, "petsto" },
                { 6, "šeststo" },
                { 7, "sedamsto" },
                { 8, "osamsto" },
                { 9, "devetsto" }
            };
        }
    }
}
