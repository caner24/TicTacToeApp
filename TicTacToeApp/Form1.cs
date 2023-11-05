using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeApp
{
    public partial class Form1 : Form
    {
        private int btnIndex;
        private int agentNumbers;
        private Random randomChoices_O = new Random();
        private List<Button> enabledButtons = new List<Button>();
        private List<Button> buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Text = "";
                    enabledButtons.Add(button);
                    buttons.Add(button);
                    button.Click += Button_Click;

                }
            }
        }
        private void ResetForm()
        {
            lblMinimax.Text = "0";
            lblMinimaxO.Text = "0";
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Text = "";
                    button.Enabled = true;
                    enabledButtons.Add(button);
                    buttons.Add(button);
                    button.Click += Button_Click;
                }

            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (enabledButtons.Count > 0)
            {
                Button btn = (sender as Button);
                if (btn.Enabled == true)
                {
                    btn.Text = "X";
                    btn.Enabled = false;
                    btnIndex = enabledButtons.IndexOf(btn);
                    enabledButtons.Remove(btn);
                    int number2 = buttons.IndexOf(btn);

                    if (enabledButtons.Count > 0)
                    {
                        Button selectedButton = new Button();
                        bool isOk = false;
                        while (!isOk)
                        {
                            int randomIndex = randomChoices_O.Next(0, enabledButtons.Count);
                            selectedButton = enabledButtons[randomIndex];
                            if (selectedButton.Enabled == true)
                            {
                                selectedButton.Text = "O";
                                selectedButton.Enabled = false;
                                enabledButtons.Remove(selectedButton);
                                isOk = true;
                            }
                        }
                        int number = buttons.IndexOf(selectedButton);
                        yanYanaDurum_O(number);

                    }
                    yanyanaVeAltAltaDurum_X(number2);
                    caprazDurum_X(number2);
                    caprazDurum_O(number2);
                }


            }
        }
        void caprazDurum_X(int number)
        {
            if (number == 8 || number == 4 || number == 0)
            {
                if ((buttons[4].Text == "X" && buttons[8].Text == "X") || (buttons[4].Text == "X" && buttons[0].Text == "X") || (buttons[0].Text == "X" && buttons[8].Text == "X"))
                {
                    if (buttons[4].Text != "O" && buttons[8].Text != "O" && buttons[0].Text != "O")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                }
                if (buttons[8].Text == "X" && buttons[4].Text == "X" && buttons[0].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
            }
            else if (number == 2 || number == 6 || number == 4)
            {
                if ((buttons[4].Text == "X" && buttons[6].Text == "X") || (buttons[4].Text == "X" && buttons[2].Text == "X") || (buttons[2].Text == "X" && buttons[6].Text == "X"))
                {
                    if (buttons[2].Text != "O" && buttons[6].Text != "O" && buttons[4].Text != "O")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                }
                if (buttons[2].Text == "X" && buttons[6].Text == "X" && buttons[4].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
            }
        }

        void caprazDurum_O(int number)
        {
            if (number == 8 || number == 4 || number == 0)
            {
                if ((buttons[4].Text == "O" && buttons[8].Text == "O") || (buttons[4].Text == "O" && buttons[0].Text == "O") || (buttons[0].Text == "O" && buttons[8].Text == "O"))
                {
                    if (buttons[4].Text != "X" && buttons[8].Text != "X" && buttons[0].Text != "X")
                        lblMinimaxO.Text = "1";
                    else
                        lblMinimaxO.Text = "0";
                }
                if (buttons[8].Text == "O" && buttons[4].Text == "O" && buttons[0].Text == "O")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
            }
            else if (number == 2 || number == 6 || number == 4)
            {
                if ((buttons[4].Text == "O" && buttons[6].Text == "O") || (buttons[4].Text == "O" && buttons[2].Text == "O") || (buttons[2].Text == "O" && buttons[6].Text == "O"))
                {
                    if (buttons[2].Text != "X" && buttons[6].Text != "X" && buttons[4].Text != "X")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                }
                if (buttons[2].Text == "O" && buttons[6].Text == "O" && buttons[4].Text == "O")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
            }
        }

        void yanYanaDurum_O(int number2)
        {
            if (number2 != 0 && number2 != 8 && number2 != 5 && number2 != 3 && number2 != 6 && number2 != 2)
            {
                if (buttons[number2].Text == "O" && buttons[number2 - 1].Text == "O" || buttons[number2 + 1].Text == "O")
                {
                    if (buttons[number2 - 1].Text != "X" && buttons[number2 + 1].Text != "X")
                        lblMinimaxO.Text = "1";
                    else
                        lblMinimaxO.Text = "0";
                }
                else if ((buttons[7].Text == "O" && buttons[4].Text == "O") || (buttons[7].Text == "O" && buttons[1].Text == "O") || (buttons[4].Text == "O" && buttons[1].Text == "O"))
                    if (buttons[7].Text != "X" && buttons[4].Text != "X" && buttons[1].Text != "O")
                        lblMinimaxO.Text = "1";
                    else
                        lblMinimaxO.Text = "0";
                else
                {
                    lblMinimaxO.Text = "0";
                }
                if (buttons[number2 - 1].Text == "O" && buttons[number2 + 1].Text == "O")
                {
                    MessageBox.Show("Sayi Kaybedildi");
                }
                else if (buttons[7].Text == "O" && buttons[4].Text == "O" && buttons[1].Text == "O")
                {
                    MessageBox.Show("Sayi Kaybedildi");
                }
            }
            else if (number2 == 0 || number2 == 3 || number2 == 6)
            {
                if (buttons[number2].Text == "O" && buttons[number2 + 1].Text == "O" || buttons[number2 + 2].Text == "O")
                {
                    if (buttons[number2 + 1].Text != "X" && buttons[number2 + 2].Text != "X")
                        lblMinimaxO.Text = "1";
                    else
                        lblMinimaxO.Text = "0";
                }
                else if ((buttons[0].Text == "O" && buttons[3].Text == "O") || (buttons[3].Text == "O" && buttons[6].Text == "O") || (buttons[0].Text == "O" && buttons[6].Text == "O"))
                    if (buttons[0].Text != "X" && buttons[3].Text != "X" && buttons[6].Text != "X")
                        lblMinimaxO.Text = "1";
                    else
                        lblMinimaxO.Text = "0";
                else
                {
                    lblMinimaxO.Text = "0";
                }

                if (buttons[number2 + 1].Text == "O" && buttons[number2 + 2].Text == "O")
                {
                    MessageBox.Show("Sayi Kaybedildi");
                }
                else if (buttons[0].Text == "O" && buttons[3].Text == "O" && buttons[6].Text == "O")
                {
                    MessageBox.Show("Sayi Kaybedildi");
                }

            }
            else if (number2 == 8 || number2 == 5 || number2 == 2)
            {
                if (buttons[number2].Text == "O" && buttons[number2 - 1].Text == "O" || buttons[number2 - 2].Text == "O")
                {
                    if (buttons[number2 - 1].Text != "X" && buttons[number2 - 2].Text != "X")
                        lblMinimaxO.Text = "1";

                    else
                        lblMinimaxO.Text = "0";
                }
                else if ((buttons[8].Text == "O" && buttons[5].Text == "O") || (buttons[5].Text == "O" && buttons[2].Text == "O") || (buttons[8].Text == "O" && buttons[2].Text == "O"))
                    if (buttons[8].Text != "X" && buttons[5].Text != "X" && buttons[2].Text != "X")
                        lblMinimaxO.Text = "1";
                    else
                        lblMinimaxO.Text = "0";
                else
                {
                    lblMinimaxO.Text = "0";
                }
                if (buttons[number2 - 1].Text == "O" && buttons[number2 - 2].Text == "O")
                {
                    MessageBox.Show("Sayi Kaybedildi");
                }
                else if (buttons[8].Text == "O" && buttons[5].Text == "O" && buttons[2].Text == "O")
                {
                    MessageBox.Show("Sayi Kaybedildi");
                }

            }
        }

        void yanyanaVeAltAltaDurum_X(int number2)
        {
            if (number2 != 0 && number2 != 8 && number2 != 5 && number2 != 3 && number2 != 6 && number2 != 2)
            {
                if (buttons[number2].Text == "X" && buttons[number2 - 1].Text == "X" || buttons[number2 + 1].Text == "X")
                {
                    if (buttons[number2 - 1].Text != "O" && buttons[number2 + 1].Text != "O")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                }
                else if ((buttons[7].Text == "X" && buttons[4].Text == "X") || (buttons[7].Text == "X" && buttons[1].Text == "X") || (buttons[4].Text == "X" && buttons[1].Text == "X"))
                    if (buttons[7].Text != "O" && buttons[4].Text != "O" && buttons[1].Text != "O")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                else
                {
                    lblMinimax.Text = "0";
                }
                if (buttons[number2 - 1].Text == "X" && buttons[number2 + 1].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
                else if (buttons[7].Text == "X" && buttons[4].Text == "X" && buttons[1].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
            }
            else if (number2 == 0 || number2 == 3 || number2 == 6)
            {
                if (buttons[number2].Text == "X" && buttons[number2 + 1].Text == "X" || buttons[number2 + 2].Text == "X")
                {
                    if (buttons[number2 + 1].Text != "O" && buttons[number2 + 2].Text != "O")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                }
                else if ((buttons[0].Text == "X" && buttons[3].Text == "X") || (buttons[3].Text == "X" && buttons[6].Text == "X") || (buttons[0].Text == "X" && buttons[6].Text == "X"))
                    if (buttons[0].Text != "O" && buttons[3].Text != "O" && buttons[6].Text != "O")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                else
                {
                    lblMinimax.Text = "0";
                }

                if (buttons[number2 + 1].Text == "X" && buttons[number2 + 2].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
                else if (buttons[0].Text == "X" && buttons[3].Text == "X" && buttons[6].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }

            }
            else if (number2 == 8 || number2 == 5 || number2 == 2)
            {
                if (buttons[number2].Text == "X" && buttons[number2 - 1].Text == "X" || buttons[number2 - 2].Text == "X")
                {
                    if (buttons[number2 - 1].Text != "O" && buttons[number2 - 2].Text != "O")
                        lblMinimax.Text = "1";

                    else
                        lblMinimax.Text = "0";
                }
                else if ((buttons[8].Text == "X" && buttons[5].Text == "X") || (buttons[5].Text == "X" && buttons[2].Text == "X") || (buttons[8].Text == "X" && buttons[2].Text == "X"))
                    if (buttons[8].Text != "O" && buttons[5].Text != "O" && buttons[2].Text != "O")
                        lblMinimax.Text = "1";
                    else
                        lblMinimax.Text = "0";
                else
                {
                    lblMinimax.Text = "0";
                }
                if (buttons[number2 - 1].Text == "X" && buttons[number2 - 2].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }
                else if (buttons[8].Text == "X" && buttons[5].Text == "X" && buttons[2].Text == "X")
                {
                    MessageBox.Show("Sayi Kazanildi");
                }

            }
        }


        private void label11_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
