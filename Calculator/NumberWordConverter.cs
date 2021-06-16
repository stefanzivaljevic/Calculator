using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class NumberWordConverter
    {
        private readonly SortedList _upTo20;          //lista brojeva do 20
        private readonly SortedList _dozens;          //lista desetina
        private readonly SortedList _hundreds;        //lista stotina

        public NumberWordConverter()
        {
            _upTo20 = new SortedList();
            _dozens = new SortedList();
            _hundreds = new SortedList();

            _upTo20.Add(1, "jedan");
            _upTo20.Add(2, "dva");
            _upTo20.Add(3, "tri");
            _upTo20.Add(4, "četiri");
            _upTo20.Add(5, "pet");
            _upTo20.Add(6, "šest");
            _upTo20.Add(7, "sedam");
            _upTo20.Add(8, "osam");
            _upTo20.Add(9, "devet");
            _upTo20.Add(10, "deset");
            _upTo20.Add(11, "jedanaest");
            _upTo20.Add(12, "dvanaest");
            _upTo20.Add(13, "trinaest");
            _upTo20.Add(14, "četrnaest");
            _upTo20.Add(15, "petnaest");
            _upTo20.Add(16, "šesnaest");
            _upTo20.Add(17, "sedamnaest");
            _upTo20.Add(18, "osamnaest");
            _upTo20.Add(19, "devetnaest");

            _dozens.Add(2, "dvadeset");
            _dozens.Add(3, "trideset");
            _dozens.Add(4, "četrdeset");
            _dozens.Add(5, "pedeset");
            _dozens.Add(6, "šezdeset");
            _dozens.Add(7, "sedamdeset");
            _dozens.Add(8, "osamdeset");
            _dozens.Add(9, "devedeset");

            _hundreds.Add(1, "sto");
            _hundreds.Add(2, "dvesta");
            _hundreds.Add(3, "trista");
            _hundreds.Add(4, "četiristo");
            _hundreds.Add(5, "petsto");
            _hundreds.Add(6, "šeststo");
            _hundreds.Add(7, "sedamsto");
            _hundreds.Add(8, "osamsto");
            _hundreds.Add(9, "devetsto");
        }

        public string Convert(double number)
        {
            string word = "";     //promenljiva koju metoda vraca i na kraju ispisuje.

            try
            {
                if (number > 9999999999999999 || number < -9999999999999999)    //postavljeni limit za unos je ±10 bilijardi.
                {
                    word = "Ne možete uneti broj veći/manji od ±9,999,999,999,999,999";
                }
                else
                {
                    if (number == 0)
                    {
                        return "nula ";
                    }
                    if (number < 0)
                    {
                        return "minus " + Convert(Math.Abs(number));
                    }

                    if (number % 1 != 0)    //Ukoliko je broj decimalan...
                    {
                        decimal numberDec = System.Convert.ToDecimal(number);
                        word += Convert(Math.Floor(number)) + "zapeta "; //...u konverziju prosledjujemo deo broja do zapete, a zatim i decimalni deo broja nakon sto ga prethodno pretovirmo u celi broj.

                        decimal decimalPart = System.Convert.ToDecimal(Math.Round(numberDec - Math.Floor(numberDec), numberDec.ToString().Length - 2)); //izdvajanje decimale
                        if (decimalPart.ToString().StartsWith('0'))     //proveravamo da li decimala pocinje sa 0.
                        {
                            foreach (var i in decimalPart.ToString().Substring(2))  //proveravamo koliko ima nula do nekog drugog broja.
                            {
                                if (i == '0')
                                {
                                    word += "nula ";
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        word += Convert(System.Convert.ToDouble(decimalPart.ToString().Substring(2))); //prosledjivanje decimalnog dela broja u konverziju.
                    }
                    else
                    {
                        if (Math.Floor(number / 1000000000000000) > 0)      //proveravamo da li je broj reda velicine bilijarda.
                        {
                            word += Convert(Math.Floor(number / 1000000000000000));

                            if (Math.Floor(number / 1000000000000000) == 1) //ukoliko unos pocinje sa 1
                            {
                                word = word.Substring(6);                   //iz stringa izbacujemo rec "jedan"
                                word += "bilijarda ";
                            }
                            if (Math.Floor(number / 1000000000000000) > 1 && Math.Floor(number / 1000000000000000) < 5) //ukoliko unos pocinje brojevima izmedju 1 i 5 
                            {
                                if (Math.Floor(number / 1000000000000000) == 2) //ukoliko unos pocinje brojem dva
                                {
                                    StringBuilder sb = new StringBuilder(word);
                                    sb[3] = 'e';
                                    word = sb.ToString();                       //rec "dva" izmenjujemo u "dve" 
                                }
                                word += "bilijarde ";                           //dodajemo "bilijarde"
                            }
                            if (Math.Floor(number / 1000000000000000) >= 5)     //ukoliko unos pocinje brojem 5 ili vecim, dodajemo "bilijardi"
                            {
                                word += "bilijardi ";
                            }

                            number = number % 1000000000000000;                 //broj umanjujemo za prvu cifru ili izlazimo iz metode ukoliko je rezultat operacije "0".
                        }

                        if (Math.Floor(number / 1000000000000) > 0)             //proveravamo da li je broj reda velicine bilion.
                        {
                            word += Convert(Math.Floor(number / 1000000000000));
                            if (Math.Floor(number / 1000000000000) % 10 == 1)   //ukoliko unos pocinje sa 1
                            {
                                if (word == "jedan ")                            //ukoliko je unos takodje i prvi unos
                                {
                                    word = word.Substring(6);                   //izbacujemo rec "jedan "
                                }
                                word += "bilion ";
                            }
                            else
                            {
                                word += "biliona ";
                            }
                            number = number % 1000000000000;                    //broj umanjujemo za prvu cifru ili izlazimo iz metode ukoliko je rezultat operacije "0".
                        }

                        if (Math.Floor(number / 1000000000) > 0)                //proveravamo da li je broj reda velicine milijarda.
                        {
                            word += Convert(Math.Floor(number / 1000000000));
                            if (Math.Floor(number / 1000000000) % 10 == 1)      //ukoliko unos pocinje sa 1
                            {
                                if (word == "jedan ")                            //ukoliko je unos takodje i prvi unos
                                {
                                    word = word.Substring(6);                   //izbacujemo rec "jedan "
                                    word += "milijarda ";
                                }
                                else
                                {
                                    word += "milijarda ";
                                    word = word.Replace("jedan milijarda ", "jedna milijarda ");
                                }
                            }
                            if (Math.Floor(number / 1000000000) % 10 >= 2 && Math.Floor(number / 1000000000) % 10 <= 4) //ukoliko je unos izmedju 2 i 4
                            {
                                word += "milijarde ";
                                if (Math.Floor(number / 1000000000) % 10 == 2)      //ukoliko je unos 2...
                                {
                                    word = word.Replace("dva milijarde ", "dve milijarde ");    //...rec "dva" izmenjujemo u "dve"
                                }
                            }
                            if (Math.Floor(number / 1000000000) % 10 >= 5 || Math.Floor(number / 1000000000) % 10 == 0) //ukoliko je unos 0 ili 5 i vise
                            {
                                word += "milijardi ";
                            }
                            number = number % 1000000000;                           //broj umanjujemo za prvu cifru ili izlazimo iz metode ukoliko je rezultat operacije "0".
                        }

                        if (Math.Floor(number / 1000000) > 0)                       //proveravamo da li je broj reda velicine milion.
                        {
                            word += Convert(Math.Floor(number / 1000000));

                            if (Math.Floor(number / 1000000) % 10 == 1)              //proveravamo da li unos pocinje sa 1
                            {
                                if (word == "jedan ")                                //ukoliko je unos takodje i prvi unos
                                {
                                    word = word.Substring(6);                       //izbacujemo rec "jedan "
                                }
                                word += "milion ";
                            }
                            else
                            {
                                word += "miliona ";
                            }
                            number = number % 1000000;                              //broj umanjujemo za prvu cifru ili izlazimo iz metode ukoliko je rezultat operacije "0".
                        }

                        if (Math.Floor(number / 1000) > 0)                          //proveravamo da li je broj reda velicine milion.
                        {
                            word += Convert(Math.Floor(number / 1000));

                            if (Math.Floor(number / 1000) % 10 == 1)                 //ukoliko je unos 1
                            {
                                if (word == "jedan ")
                                {                               //ukoliko je unos takodje i prvi unos
                                    word = "hiljadu ";
                                }
                                else
                                {
                                    word += "hiljada ";
                                    word = word.Replace("jedan hiljada ", "jedna hiljada ");
                                }
                            }
                            else
                            {
                                if (Math.Floor(number / 1000) % 10 == 0 || Math.Floor(number / 1000) % 10 >= 5) //ukoliko je unos 0 ili 5 ili vise
                                {
                                    word += "hiljada ";
                                }
                                else                                                //ukoliko je unos izmedju 2 i 4
                                {
                                    word += "hiljade ";
                                    if (Math.Floor(number / 1000) % 10 == 2)
                                    {
                                        word = word.Replace("dva hiljade ", "dve hiljade ");
                                    }
                                }
                            }
                            number = number % 1000;                                 //broj umanjujemo za prvu cifru ili izlazimo iz metode ukoliko je rezultat operacije "0".
                        }

                        if (Math.Floor(number / 100) > 0)                           //ukoliko je unos reda velicine stotina
                        {
                            double tempNumber = Math.Floor(number / 100);
                            foreach (DictionaryEntry n in _hundreds)                 //prolazimo kroz listu naziva za stotine i pronalazimo odgovarajuci naziv za unetu stotinu
                            {
                                if (int.Parse(n.Key.ToString()) == tempNumber)
                                {
                                    word += n.Value.ToString() + " ";
                                    break;
                                }
                            }
                            number = number % 100;                                  //broj umanjujemo za prvu cifru ili izlazimo iz metode ukoliko je rezultat operacije "0".
                        }

                        if (number > 0)                                             //ukoliko je unos veci od 0
                        {
                            if (number < 20)                                        //ukoliko je unos manji od 20
                            {
                                double tempNumber = Math.Floor(number);
                                foreach (DictionaryEntry n in _upTo20)               //prolazimo kroz listu naziva za brojeve do 20 i pronalazimo odgovarajuci naziv za uneti broj
                                {
                                    if (int.Parse(n.Key.ToString()) == tempNumber)
                                    {
                                        word += n.Value + " ";
                                        break;
                                    }
                                }
                            }
                            else                                                    //ukoliko je broj veci od 20
                            {
                                double tempNumber = Math.Floor(number / 10);
                                foreach (DictionaryEntry n in _dozens)               //prolazimo kroz listu naziva za desetine i pronalazimo odgovarajuci naziv za uneti broj
                                {
                                    if (int.Parse(n.Key.ToString()) == tempNumber)
                                    {
                                        word += n.Value + " ";
                                        break;
                                    }
                                }
                                tempNumber = Math.Floor(number % 10);
                                foreach (DictionaryEntry n in _upTo20)               //prolazimo kroz listu naziva za brojeve do 20 i pronalazimo odgovarajuci naziv za preostali broj
                                {
                                    if (int.Parse(n.Key.ToString()) == tempNumber)
                                    {
                                        word += n.Value + " ";
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                word = "Uneta cifra ne može biti konvertovana. ";
            }
            return word;
        }
    }
}
