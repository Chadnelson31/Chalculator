using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        List<string> userInput = new List<string>();
        List<string> tempOperator = new List<string>();
        string[] orderOfOperations = { "^2", "*", "/", "+", "-" };
        int count = 0, dec, plusCount, minusCount, divideCount, multiplyCount;
        string operatorTemp, squareRootString = Convert.ToString((char)0x221A);
        double tempTotal, totalHistory = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = Convert.ToString(totalHistory);
            label3.Text = "";
            label4.Text = "";
            label1.Text = Convert.ToString(userInput.Count);
            label2.Text = Convert.ToString(tempOperator.Count);
            for (int x = 0; x < userInput.Count; ++x)
                label3.Text += userInput[x] + " , ";
            for (int x = 0; x < tempOperator.Count; ++x)
                label4.Text += tempOperator[x] + " , ";
        }//end button1_Click

        public Form1()
        {
            InitializeComponent();
        }

        //Organizes operators into correct precedence
        /*private void orgranizeOperators()
        {
            if (multiplyCount > 0)
            {
                
            }
        }
        */

        //Clears the input lists
        private void clearLists()
        {
                userInput.RemoveRange(0, userInput.Count);
                tempOperator.RemoveRange(0, tempOperator.Count);
            count = 0;
            plusCount = 0;
            minusCount = 0;
            divideCount = 0;
            multiplyCount = 0;
            tempTotal = 0;
        }

        //Number event method
        private void number_Click(object sender, EventArgs e)
        {
            if (userInput.Count == 0)
                userInput.Add("");
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 1")
            {
                userInput[count] += "1";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 2")
            {
                userInput[count] += "2";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 3")
            {
                userInput[count] += "3";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 4")
            {
                userInput[count] += "4";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 5")
            {
                userInput[count] += "5";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 6")
            {
                userInput[count] += "6";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 7")
            {
                userInput[count] += "7";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 8")
            {
                userInput[count] += "8";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 9")
            {
                userInput[count] += "9";
                textBox1.Text = userInput[count];
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 0")
            {
                userInput[count] += "0";
                textBox1.Text = userInput[count];
            }
        }

        //Symbol event method
        private void symbol_Click(object sender, EventArgs e)
        {
            if (sender.ToString() == "System.Windows.Forms.Button, Text: .")
            {
                if (dec < 1)
                {
                    userInput[count] += ".";
                    textBox1.Text = userInput[count];
                    dec++;
                }
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: =")
            {
                    tempTotal = Convert.ToDouble(userInput[0]);
                for (int x = 0; x < count; ++x)
                {
                    switch (tempOperator[x])
                    {
                        case "+":
                            tempTotal +=
                                Convert.ToDouble(userInput[x + 1]);
                            break;
                        case "-":
                            tempTotal -=
                            Convert.ToDouble(userInput[x + 1]);
                            break;
                        case "*":
                            tempTotal *=
                            Convert.ToDouble(userInput[x + 1]);
                            break;
                        case "/":
                            tempTotal /=
                            Convert.ToDouble(userInput[x + 1]);
                            break;
                            /*case "^2":
                                tempTotal =
                                Convert.ToDouble(userInput[x]) * Convert.ToDouble(userInput[x]);
                                break;*/
                            /*case "221A":
                                break;*/
                    }// end switch

                    textBox1.Text = Convert.ToString(tempTotal);
                    totalHistory = tempTotal;
                }
                clearLists();
            }

            //second set of buttons
            if (sender.ToString() == "System.Windows.Forms.Button, Text: -")
            {
                if (totalHistory != 0 && userInput.Count == 0)
                {
                    userInput.Add("");
                    userInput[0] = Convert.ToString(totalHistory);
                }
                if (userInput[count] != "")
                {
                    userInput.Add("");
                    tempOperator.Add("");
                    tempOperator[count] = "-";
                    dec = 0;
                    ++count;
                    minusCount++;
                }
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: +")
            {
                if (totalHistory != 0 && userInput.Count == 0)
                {
                    userInput.Add("");
                    userInput[0] = Convert.ToString(totalHistory);
                }
                if (userInput[count] != "")
                {
                    userInput.Add("");
                    tempOperator.Add("");
                    tempOperator[count] = "+";
                    dec = 0;
                    ++count;
                    plusCount++;
                }
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: /")
            {
                if (totalHistory != 0 && userInput.Count == 0)
                {
                    userInput.Add("");
                    userInput[0] = Convert.ToString(totalHistory);
                }
                if (userInput[count] != "")
                {
                    userInput.Add("");
                    tempOperator.Add("");
                    tempOperator[count] = "/";
                    dec = 0;
                    ++count;
                    divideCount++;
                }
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: *")
            {
                if (totalHistory != 0 && userInput.Count == 0)
                {
                    userInput.Add("");
                    userInput[0] = Convert.ToString(totalHistory);
                }
                if (userInput[count] != "")
                {
                    userInput.Add("");
                    tempOperator.Add("");
                    tempOperator[count] = "*";
                    dec = 0;
                    ++count;
                    multiplyCount++;
                }
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: ^2")
            {
                if (totalHistory != 0 && userInput.Count == 0)
                {
                    userInput.Add("");
                    userInput[0] = Convert.ToString(totalHistory);
                }
                if (userInput[count] != "")
                {
                    userInput.Add("");
                    tempOperator.Add("");
                    tempOperator[count] = "^2";
                    dec = 0;
                    ++count;
                }
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: Clear")
            {
                clearLists();
                totalHistory = 0;
                textBox1.Text = "";
            }
            //square root
            /*if (sender.ToString() == "System.Windows.Forms.Button, Text: " + (char)0x221A)
            {
                userInput.Add("");
                tempOperator.Add("");
                tempOperator[count] = "221A";
                dec = 0;
                ++count;
            }*/
        }
    }
}
