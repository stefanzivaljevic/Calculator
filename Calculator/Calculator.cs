using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private bool _isFirstCall = true;    //polje kojim proveravamo da li je isti taster pritisnut vise od jedanput
        private bool _isWordFormat = false;  //polje kojim proveravamo da li su na mestu za prikazivanje rezultata ispisane reci ili brojevi
        private string _lastInput ="0";      //poslednji unos kojim omogucavamo ponovnu konverziju iz slova u brojeve prilikom ponovnog pritiska na dugme
        private double _firstNumber = 0;     //polje koje cuva prvi broj prilikom operacija
        private double _secondNumber = 0;    //polje koje cuva drugi broj prilikom operacija
        private double _result = -1;         //polje koje cuva rezultat operacija
        private string _operation = "";      //polje koje ukazuje koja se operacija izvodi
        private bool _resetOutput = false;   //polje koje nam govori da li se unos ponovo pokrece ili ne

        private readonly SortedList _upTo20;          //lista brojeva do 20
        private readonly SortedList _dozens;          //lista desetina
        private readonly SortedList _hundreds;        //lista stotina


        public Calculator()
        {
            InitializeComponent();
            _upTo20 = new SortedList();
            _dozens = new SortedList();
            _hundreds = new SortedList();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";

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

        private void button2_Click(object sender, EventArgs e)      //dugme "0"
        {
            if(textBox1.Text.Length < 16)
            {
                if (textBox1.Text != "0")
                {
                    textBox1.Text += "0";
                }
                if (_resetOutput == true)
                {
                    textBox1.Text = "0";
                    _resetOutput = false;
                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }
        private void button8_Click(object sender, EventArgs e)          //dugme "1"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "1";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "1";
                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)          //dugme "2"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "2";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "2";

                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)          //dugme "3"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "3";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "3";
                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)         //dugme "4"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "4";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "4";

                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)         //dugme "5"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "5";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "5";

                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)          //dugme "6"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "6";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "6";

                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button16_Click(object sender, EventArgs e)     //dugme "7"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "7";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "7";

                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)     //dugme "8"
        {
            if(textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))   //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "8";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "8";

                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)     //dugme "9"
        {
            if (textBox1.Text.Length < 16 || textBox1.Text.Any(char.IsLetter))  //najveci broj koji korisnik moze da unese mora biti manji/veci od ±10 bilijardi; u polju se moze naci vise od 16 karaktera prilikom ispisivanja brojeva recima, te proveravamo da li su u textbox-u slova
            {
                if (textBox1.Text == "0" || _resetOutput == true)
                {
                    textBox1.Text = "9";
                    _resetOutput = false;
                }
                else
                {
                    textBox1.Text += "9";
                }
                _isWordFormat = false;
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)         //dugme "C"
        {
            textBox1.Text = "0";
            _result = -1;
            _firstNumber = 0;
            _secondNumber = 0;
            _isWordFormat = false;
            button_Click(sender, e);
        }

        private void button18_Click(object sender, EventArgs e)         //dugme "⇚"
        {
            if (_isWordFormat == true || textBox1.Text.Any(char.IsLetter))           //ukoliko su ispisane reci, pozvati dugme "C"
            {
                button14_Click(sender, e);
                _isWordFormat = false;
            }
            else
            {
                switch (textBox1.Text.Length)
                {
                    case 0:
                        textBox1.Text = "0";
                        break;
                    case 1:
                        textBox1.Text = "0";
                        break;
                    case 2:
                        if (Convert.ToDouble(textBox1.Text) < 0)
                        {
                            textBox1.Text = "0";
                        }
                        else
                        {
                            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                        }
                        break;
                    default:
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                        break;
                }
            }
            button_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)          //dugme "+"
        {
            if (_isWordFormat == true)           //ukoliko su ispisane reci...
            {
                textBox1.Text = _lastInput;      //...za operaciju iskoristiti poslednji unos.
                _isWordFormat = false;
            }
            button3_Click(sender, e);           //pozivanje operacije "="
            _operation = "+";
            button_Click(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)         //dugme "-"
        {
            if (_isWordFormat == true)           //ukoliko su ispisane reci...
            {
                textBox1.Text = _lastInput;      //...za operaciju iskoristiti poslednji unos.
                _isWordFormat = false;
            }
            button3_Click(sender, e);           //pozivanje operacije "="
            _operation = "-";
        }

        private void button17_Click(object sender, EventArgs e)     //dugme "x"
        {
            if (_isWordFormat == true)
            {
                textBox1.Text = _lastInput;
                _isWordFormat = false;
            }
            button3_Click(sender, e);
            _operation = "*";

            button_Click(sender, e);
        }

        private void button19_Click(object sender, EventArgs e)     //dugme "÷"
        {
            if (_isWordFormat == true)
            {
                textBox1.Text = _lastInput;
                _isWordFormat = false;
            }
            button3_Click(sender, e);
            _operation = "/";

            button_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)          //dugme "="
        {
            if (_isWordFormat == true)           //ukoliko su ispisane reci...
            {
                textBox1.Text = _lastInput;      //...za operaciju iskoristiti poslednji unos.
                _isWordFormat = false;
            }
            if (_firstNumber == 0)               //ukoliko nije uneta prva vrednost za operaciju
            {
                _firstNumber = Convert.ToDouble(textBox1.Text);
                textBox1.Text = _firstNumber.ToString();
                _resetOutput = true;
                _isFirstCall = false;
            }
            else                                //ukoliko je prva vrednost dodeljena
            {
                if (_isFirstCall)                
                {
                    _secondNumber = Convert.ToDouble(textBox1.Text);
                    if (_operation == "+")
                    {
                        _result = _firstNumber + _secondNumber;
                    }
                    if (_operation == "-")
                    {
                        _result = _firstNumber - _secondNumber;
                    }
                    if (_operation == "*")
                    {
                        _result = _firstNumber * _secondNumber;
                    }
                    if (_operation == "/")
                    {
                        _result = _firstNumber / _secondNumber;
                    }

                    if(_result % 1 != 0)                     //ukoliko je rezultat decimalni zapis...
                    {
                        _result = Math.Round(_result, 2);     //...zaokruzujemo rezultat na dve decimale
                    }

                    _firstNumber = _result;
                    textBox1.Text = _result.ToString();
                    _result = 0;
                    _resetOutput = true;
                    _isFirstCall = false;
                }
            }
            button_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)      //dugme "±"
        {
            if (_isWordFormat == true)
            {
                if(Convert.ToDouble(_lastInput) < 0)                 //ukoliko je poslednji unos negativan
                {
                    textBox1.Text = _lastInput.Substring(1);         //uklanjamo "-"
                }
                if(Convert.ToDouble(_lastInput) > 0)                 //ukoliko je poslednji unos pozitivan
                {
                    textBox1.Text = "-" + _lastInput;                //dodajemo "-"
                }
                _lastInput = textBox1.Text;
                if (textBox1.Text.Any(char.IsLetter))               //ukoliko su ispisane reci...
                {
                    button14_Click(sender, e);                      //...pozivamo dugme "C"
                }
                else
                {
                    _isWordFormat = false;
                }
            }
            else
            {
                if (Convert.ToDouble(textBox1.Text) > 0)            //ukoliko je trenutni unos veci od 0...
                {
                    textBox1.Text = textBox1.Text.Insert(0, "-");   //...dodajemo "-" 

                }
                else
                {
                    if (Convert.ToDouble(textBox1.Text) < 0)        //ukoliko je trenutni unos manji od 0...
                    {
                        textBox1.Text = textBox1.Text.Substring(1); //uklanjamo "-"
                    }
                }
            }
            if (_result == 0)                                        //ukoliko je poslednja operacija bila "="
            {
                _firstNumber = Convert.ToDouble(textBox1.Text);
            }

            button_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)      //dugme "."
        {
            if (!textBox1.Text.Contains('.') )
            {
                if(_resetOutput == false)
                {
                    textBox1.Text += ".";
                }
                else
                {
                    textBox1.Text = "0.";
                }
            }
            else
            {
                if(_resetOutput == true)
                {
                    textBox1.Text = "0.";
                }
            }
            _resetOutput = false;

            button_Click(sender, e);
        }

        private void button20_Click(object sender, EventArgs e)     //taster "1⇄A"
        {
            if (textBox1.Text.Any(char.IsDigit))        //ukoliko su prikazani brojevi
            {
                _lastInput = textBox1.Text;              //cuvamo trenutnu vrednost 
            }

            if (_isWordFormat)                           //ukoliko su prikazane reci...
            {
                textBox1.Text = _lastInput;              //prikazati poslednju vrednost u brojevima
                _isWordFormat = false;
            }
            else
            {
                textBox1.Text = DigitToWord(Convert.ToDouble(textBox1.Text));
            }

            button_Click(sender, e);
        }

        private void button23_Click(object sender, EventArgs e) //taster "CE"
        {
            textBox1.Text = "0";
            if(_result == 0)                                     //Petljom saznajemo da li smo taster CE kliknuli pre ili nakon što smo pozvali operaciju "=".
            {
                _firstNumber = _secondNumber;
            }
            button_Click(sender, e);
        }

        private void button22_Click(object sender, EventArgs e)     //dugme "x²"
        {
            if (_isWordFormat == true)                               //ukoliko su prikazane reci
            {
                _result = Math.Pow(Convert.ToDouble(_lastInput), 2);
                _isWordFormat = false;
            }
            else
            {
                if (_firstNumber == 0)
                {
                    _result = Math.Pow(Convert.ToDouble(textBox1.Text), 2);
                }
                else
                {
                    _secondNumber = Convert.ToDouble(textBox1.Text);
                    _result = Math.Pow(_secondNumber, 2);
                    
                }
            }
            textBox1.Text = _result.ToString();

            button_Click(sender, e);
        }

        private void button24_Click(object sender, EventArgs e)     //dugme "√"
        {
            if (_isWordFormat == true)
            {
                _result = Math.Sqrt(Convert.ToDouble(_lastInput));
                _isWordFormat = false;
            }
            else
            {
                if (_firstNumber == 0)
                {
                    
                    _result = Math.Sqrt(Convert.ToDouble(textBox1.Text));
                }
                else
                {
                    _secondNumber = Convert.ToDouble(textBox1.Text);
                    _result = Math.Sqrt(_secondNumber);
                }
            }
            if (_result % 1 != 0)                    //ukoliko je broj decimalni zapis
            {
                _result = Math.Round(_result, 2);     //zaokruziti decimalni zapis na dve decimale
            }
            textBox1.Text = _result.ToString();

            button_Click(sender, e);
        }

        public string DigitToWord(double number)
        {
            string word="";     //promenljiva koju metoda vraca i na kraju ispisuje.

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
                        _isWordFormat = true;
                        _resetOutput = true;
                        return "nula ";
                    }
                    if (number < 0)
                    {
                        return "minus " + DigitToWord(Math.Abs(number));
                    }

                    if (number % 1 != 0)    //Ukoliko je broj decimalan...
                    {
                        decimal numberDec = Convert.ToDecimal(number);
                        word += DigitToWord(Math.Floor(number)) + "zapeta "; //...u konverziju prosledjujemo deo broja do zapete, a zatim i decimalni deo broja nakon sto ga prethodno pretovirmo u celi broj.

                        decimal decimalPart = Convert.ToDecimal(Math.Round(numberDec - Math.Floor(numberDec), numberDec.ToString().Length - 2)); //izdvajanje decimale
                        if (decimalPart.ToString().StartsWith('0'))     //proveravamo da li decimala pocinje sa 0.
                        {
                            foreach(var i in decimalPart.ToString().Substring(2))  //proveravamo koliko ima nula do nekog drugog broja.
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

                        word += DigitToWord(Convert.ToDouble(decimalPart.ToString().Substring(2))); //prosledjivanje decimalnog dela broja u konverziju.
                    }
                    else
                    {
                        if (Math.Floor(number / 1000000000000000) > 0)      //proveravamo da li je broj reda velicine bilijarda.
                        {
                            word += DigitToWord(Math.Floor(number / 1000000000000000));

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
                            word += DigitToWord(Math.Floor(number / 1000000000000));
                            if (Math.Floor(number / 1000000000000) % 10 == 1)   //ukoliko unos pocinje sa 1
                            {
                                if(word == "jedan ")                            //ukoliko je unos takodje i prvi unos
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
                            word += DigitToWord(Math.Floor(number / 1000000000));
                            if (Math.Floor(number / 1000000000) % 10 == 1)      //ukoliko unos pocinje sa 1
                            {
                                if(word == "jedan ")                            //ukoliko je unos takodje i prvi unos
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
                            word += DigitToWord(Math.Floor(number / 1000000));

                            if(Math.Floor(number / 1000000) % 10 == 1)              //proveravamo da li unos pocinje sa 1
                            {
                                if(word == "jedan ")                                //ukoliko je unos takodje i prvi unos
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
                            word += DigitToWord(Math.Floor(number / 1000));

                            if(Math.Floor(number / 1000) % 10 == 1)                 //ukoliko je unos 1
                            {
                                if(word == "jedan "){                               //ukoliko je unos takodje i prvi unos
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
            catch(Exception)
            {
                word = "Uneta cifra ne može biti konvertovana. ";
            }
            _isWordFormat = true;
            _resetOutput = true;
            return word;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(sender == button20)              //ukoliko kliknemo na taster za konverziju brojeva u slova, smanjujemo font na 10
            {
                textBox1.Font = new Font("Consolas", 10, FontStyle.Bold);
            }
            else
            {
                textBox1.Font = new Font("Consolas", 18, FontStyle.Bold);
            }
        }

    }
}
