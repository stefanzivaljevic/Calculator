using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Calculator.Models;

namespace Calculator
{
    public class NumberWordConverter
    {
        private readonly UpTo20 _upTo20;        //lista brojeva do 20
        private readonly Dozens _dozens;        //lista desetina
        private readonly Hundreds _hundreds;    //lista stotina

        public NumberWordConverter(UpTo20 upTo20, Dozens dozens, Hundreds hundreds)
        {
            _upTo20 = upTo20;
            _dozens = dozens;
            _hundreds = hundreds;
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
                            foreach (DictionaryEntry n in _hundreds.HundredsList)                 //prolazimo kroz listu naziva za stotine i pronalazimo odgovarajuci naziv za unetu stotinu
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
                                foreach (DictionaryEntry n in _upTo20.UpTo20List)               //prolazimo kroz listu naziva za brojeve do 20 i pronalazimo odgovarajuci naziv za uneti broj
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
                                foreach (DictionaryEntry n in _dozens.DozensList)               //prolazimo kroz listu naziva za desetine i pronalazimo odgovarajuci naziv za uneti broj
                                {
                                    if (int.Parse(n.Key.ToString()) == tempNumber)
                                    {
                                        word += n.Value + " ";
                                        break;
                                    }
                                }
                                tempNumber = Math.Floor(number % 10);
                                foreach (DictionaryEntry n in _upTo20.UpTo20List)               //prolazimo kroz listu naziva za brojeve do 20 i pronalazimo odgovarajuci naziv za preostali broj
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
