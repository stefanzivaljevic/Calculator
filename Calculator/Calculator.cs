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
        private string _lastInput ="0";      //poslednji unos kojim omogucavamo ponovnu konverziju iz slova u brojeve prilikom ponovnog pritiska na dugme
        private double _firstNumber = 0;     //polje koje cuva prvi broj prilikom operacija
        private double _secondNumber = 0;    //polje koje cuva drugi broj prilikom operacija
        private double _result = -1;         //polje koje cuva rezultat operacija
        private string _operation = "";      //polje koje ukazuje koja se operacija izvodi
        private bool _resetOutput = false;   //polje koje nam govori da li se unos ponovo pokrece ili ne

        private readonly NumberWordConverter _converter;

        public Calculator(NumberWordConverter converter)
        {
            InitializeComponent();
            _converter = converter;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)      //taster "0"
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
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }
        private void button8_Click(object sender, EventArgs e)      //taster "1"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)      //taster "2"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)      //taster "3"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)     //taster "4"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)     //taster "5"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)      //taster "6"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button16_Click(object sender, EventArgs e)     //taster "7"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)     //taster "8"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)     //taster "9"
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
                
                _isFirstCall = true;
            }
            button_Click(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)     //taster "C"
        {
            textBox1.Text = "0";
            _result = -1;
            _firstNumber = 0;
            _secondNumber = 0;
            
            button_Click(sender, e);
        }

        private void button18_Click(object sender, EventArgs e)     //taster "⇚"
        {
            if (textBox1.Text.Any(char.IsLetter) || _resetOutput == true)           //ukoliko su ispisane reci ili je operacija zavrsena pozvati dugme "C"
            {
                button14_Click(sender, e);
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

        private void button6_Click(object sender, EventArgs e)      //taster "+"
        {
            if(textBox1.Text.Any(char.IsLetter) == true)           //ukoliko su ispisane reci...
            {
                textBox1.Text = _lastInput;      //...za operaciju iskoristiti poslednji unos.
                
            }
            button3_Click(sender, e);           //pozivanje operacije "="
            _operation = "+";
            button_Click(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)     //taster "-"
        {
            if(textBox1.Text.Any(char.IsLetter) == true)           //ukoliko su ispisane reci...
            {
                textBox1.Text = _lastInput;      //...za operaciju iskoristiti poslednji unos.
                
            }
            button3_Click(sender, e);           //pozivanje operacije "="
            _operation = "-";
        }

        private void button17_Click(object sender, EventArgs e)     //taster "x"
        {
            if(textBox1.Text.Any(char.IsLetter) == true)
            {
                textBox1.Text = _lastInput;
                
            }
            button3_Click(sender, e);
            _operation = "*";

            button_Click(sender, e);
        }

        private void button19_Click(object sender, EventArgs e)     //taster "÷"
        {
            if(textBox1.Text.Any(char.IsLetter) == true)
            {
                textBox1.Text = _lastInput;
                
            }
            button3_Click(sender, e);
            _operation = "/";

            button_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)      //taster "="
        {
            if(textBox1.Text.Any(char.IsLetter) == true)           //ukoliko su ispisane reci...
            {
                textBox1.Text = _lastInput;      //...za operaciju iskoristiti poslednji unos.
                
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

        private void button1_Click(object sender, EventArgs e)      //taster "±"
        {
            if(textBox1.Text.Any(char.IsLetter) == true)            //ukoliko su prikazane reci
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

        private void button4_Click(object sender, EventArgs e)      //taster "."
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

            if(textBox1.Text.Any(char.IsLetter))         //ukoliko su prikazane reci...
            {
                textBox1.Text = _lastInput;              //prikazati poslednju vrednost u brojevima
                
            }
            else
            {
                textBox1.Text = _converter.Convert(Convert.ToDouble(textBox1.Text));
                _resetOutput = true;
            }

            button_Click(sender, e);
        }

        private void button23_Click(object sender, EventArgs e)     //taster "CE"
        {
            textBox1.Text = "0";
            if(_result == 0)                                     //Petljom saznajemo da li smo taster CE kliknuli pre ili nakon što smo pozvali operaciju "=".
            {
                _firstNumber = _secondNumber;
            }
            button_Click(sender, e);
        }

        private void button22_Click(object sender, EventArgs e)     //taster "x²"
        {
            if(textBox1.Text.Any(char.IsLetter) == true)                               //ukoliko su prikazane reci
            {
                _result = Math.Pow(Convert.ToDouble(_lastInput), 2);
                
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

        private void button24_Click(object sender, EventArgs e)     //taster "√"
        {
            if(textBox1.Text.Any(char.IsLetter) == true)
            {
                _result = Math.Sqrt(Convert.ToDouble(_lastInput));
                
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

        private void button_Click(object sender, EventArgs e)       //taster koji pozivaju svi tasteri prilikom klika
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
