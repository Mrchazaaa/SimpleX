using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SimpleX
{
    static class Tools
    {
        public static SolutionWindow parentWindow;

        public static float toAfloat<convertToAFloat>(convertToAFloat arg)
        {
            if (Convert.ToString(arg).Contains('/'))
            {
                return float.Parse(Convert.ToString(float.Parse((arg.ToString()).Split('/')[0]) / float.Parse((arg.ToString()).Split('/')[1])));
            }
            else
            {
                return float.Parse(Convert.ToString(arg));
            }
        }

        public static string simplify(string inputString)
        {
            inputString = inputString == "" ? "0" : inputString;

            try
            {

                if (Start.displayFrac)
                {
                    int numNeg = inputString.Count(x => x == '-');
                    bool neg = numNeg % 2 == 0 ? false : true;
                    inputString = new string(inputString.Where(x => x != '-').ToArray());

                    if (inputString.Contains('.') && !inputString.Contains('/'))
                    {
                        try
                        {
                            inputString = Convert.ToString(float.Parse(inputString) * float.Parse(Convert.ToString(Math.Pow(10, inputString.Length - (inputString.IndexOf('.') + 1))))) + "/" + Convert.ToString(Math.Pow(10, inputString.Length - (inputString.IndexOf('.') + 1)));
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("A number you have entered is too large or small to be used by this program");
                            return "0";
                        }
                    }
                    if (inputString.Contains('/'))
                    {
                        //Deal with other inputs
                        //Simplify
                        string[] num = new string[2];
                        num[0] = inputString.Split('/')[0];
                        num[1] = inputString.Split('/')[1];
                        if (num[0].Contains('.') && num[1].Contains('.'))
                        {
                            int mostDecimals = Convert.ToInt32(Math.Pow(10, num[0].Length - (num[0].IndexOf('.') + 1)) //This gets the number of decimals  
                                               >= Math.Pow(10, num[1].Length - (num[1].IndexOf('.') + 1))              //Of the divisions' component with the
                                               ? Math.Pow(10, num[0].Length - (num[0].IndexOf('.') + 1))               //largest number of decimals so that both
                                               : Math.Pow(10, num[1].Length - (num[1].IndexOf('.') + 1)));             //components can be multiplied by this into
                            num[0] = Multiplication(num[0], Convert.ToString(mostDecimals));                           //whole numbers
                            num[1] = Multiplication(num[1], Convert.ToString(mostDecimals));
                        }
                        if (num[0].Contains('.') || num[1].Contains('.'))
                        {
                            string num3 = num[0].Contains('.') ? num[0] : num[1];
                            num[num[0].Contains('.') ? 1 : 0] = Multiplication(num[num[0].Contains('.') ? 1 : 0], Convert.ToString(Math.Pow(10, num3.Length - (num3.IndexOf('.') + 1))));
                            num3 = Multiplication(num3, Convert.ToString(Math.Pow(10, num3.Length - (num3.IndexOf('.') + 1))));
                            num[num[0].Contains('.') ? 0 : 1] = num3;
                        }
                        if (num[0] == "0" || num[1] == "1")
                        {
                            inputString = num[0] == "0" ? "0" : num[0];
                        }
                        else
                        {
                            int gcd = GCD(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]));
                            num[0] = Convert.ToString(Convert.ToInt32(num[0]) / gcd);
                            num[1] = Convert.ToString(Convert.ToInt32(num[1]) / gcd);
                            inputString = num[0] + "/" + num[1];
                        }
                    }

                    return (neg ? "-" : "") + inputString;
                }
                else
                {
                    if (inputString.Contains('/'))
                    {
                        return Convert.ToString(float.Parse(inputString.Split('/')[0]) / float.Parse(inputString.Split('/')[1]));
                    }
                    return inputString;
                }
            }
            catch (System.FormatException) 
            {
                if (parentWindow != null)
                {
                    parentWindow.numError = true;
                }
                return "0";
            }
        }

        static int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }

        public static string Addition(object Obnum1, object Obnum2)
        {
            string returnVal;
            string num1 = Obnum1.ToString();
            string num2 = Obnum2.ToString();

            if (Start.displayFrac)
            {
                if (num1.Contains("/") && num2.Contains("/")) //Both numbers are fractions
                {
                    returnVal = Convert.ToString(toAfloat(Multiplication(num1.Split('/')[0], num2.Split('/')[1])) 
                                               + toAfloat(Multiplication(num2.Split('/')[0], num1.Split('/')[1]))
                                               ) + "/" + 
                                               Convert.ToString(Multiplication(num2.Split('/')[1], num1.Split('/')[1]));
                }
                else if (num1.Contains("/")) //Only first string is a fraction
                {
                    returnVal = Convert.ToString(toAfloat(num1.Split('/')[0]) 
                                              + (toAfloat(num2) * toAfloat(num1.Split('/')[1]))) 
                                              + "/" + num1.Split('/')[1];
                }
                else if (num2.Contains("/")) //Only second string is a fraction
                {
                    returnVal = Convert.ToString(toAfloat(num2.Split('/')[0]) 
                                              + (toAfloat(num1) * toAfloat(num2.Split('/')[1]))) 
                                              + "/" + num2.Split('/')[1];
                }
                else //No strings are fractions
                {
                    returnVal = Convert.ToString(float.Parse(num1) + float.Parse(num2));
                }

                if (returnVal.Contains('/')) //Need to indent a second if statement as the second if statement references returnVal as if it is contains ['/'] and if it does not then this would cause an error
                {
                    if (toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1]) == Math.Floor(toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1])))
                    {
                        return Convert.ToString(toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1]));
                    }
                }
            }
            else
            {
                return Convert.ToString(float.Parse(num1) + float.Parse(num2));
            }

            return simplify(returnVal); //simplify returned result
        }

        public static string Subtraction(object Obnum1, object Obnum2)
        {
            string num1 = Obnum1.ToString();
            string num2 = Obnum2.ToString();

            num2 = Multiplication("-1", num2);

            return Addition(num1, num2);
        }

        public static string Division(object Obnum1, object Obnum2)
        {
            string returnVal;

            string num1 = Obnum1.ToString();
            string num2 = Obnum2.ToString();

            if (Start.displayFrac)
            {
                if (num1.Contains("/") && num2.Contains("/"))
                {
                    returnVal = Convert.ToString(toAfloat(num1.Split('/')[0]) * toAfloat(num2.Split('/')[1])) + "/" + Convert.ToString(toAfloat(num1.Split('/')[1]) * toAfloat(num2.Split('/')[0]));
                    if (num1.Split('/')[1] == "0")
                    {
                        num1 = num1.Split('/')[0];
                    }
                    if (num2.Split('/')[1] == "0")
                    {
                        num2 = num2.Split('/')[0];
                    }
                }
                else if (num1.Contains("/"))
                {
                    returnVal = num1.Split('/')[0] + "/" + Convert.ToString(toAfloat(num1.Split('/')[1]) * toAfloat(num2));
                }
                else if (num2.Contains("/"))
                {
                    returnVal = Convert.ToString(toAfloat(num1) * toAfloat(num2.Split('/')[1])) + "/" + num2.Split('/')[0];
                }
                else 
                {
                    returnVal = Convert.ToString(float.Parse(num1)) + "/" + Convert.ToString(float.Parse(num2));
                }

                if (toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1]) == Math.Floor(toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1])))
                {
                    return Convert.ToString(toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1]));
                }
                else //Try to simplify to another fraction
                {
                    return simplify(returnVal);
                }
            }
            else
            {
                return Convert.ToString(float.Parse(num1) / float.Parse(num2));
            }
        }

        public static string Multiplication(object Obnum1, object Obnum2)
        {
            string returnVal;

            string num1 = Obnum1.ToString();
            string num2 = Obnum2.ToString();

            if (Start.displayFrac)
            {
                if (num1.Contains("/") && num2.Contains("/"))
                {
                    returnVal = Convert.ToString(toAfloat(num1.Split('/')[0]) * toAfloat(num2.Split('/')[0])) + "/" + Convert.ToString(toAfloat(num1.Split('/')[1]) * toAfloat(num2.Split('/')[1]));
                }
                else if (num1.Contains("/"))
                {
                    returnVal = Convert.ToString(toAfloat(num1.Split('/')[0]) * toAfloat(num2)) + "/" + num1.Split('/')[1];
                }
                else if (num2.Contains("/"))
                {
                    returnVal = Convert.ToString(toAfloat(num1) * toAfloat(num2.Split('/')[0])) + "/" + num2.Split('/')[1];
                }
                else
                {
                    returnVal = Convert.ToString(float.Parse(num1) * float.Parse(num2));
                }

                if (returnVal.Contains('/'))
                {
                    if (toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1]) == Math.Floor(toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1])))
                    {
                        return Convert.ToString(toAfloat(returnVal.Split('/')[0]) / toAfloat(returnVal.Split('/')[1]));
                    }
                }
            }
            else
            {
                return Convert.ToString(float.Parse(num1) * float.Parse(num2));
            }

            return returnVal;
        }
    }
}
