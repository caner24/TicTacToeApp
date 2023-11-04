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
        private int minimax;
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
                        if (number != 0 && number != 8)
                        {
                            if (number != 0 && number != 8 && number != 5 && number != 3 && number != 6)
                            {
                                if (buttons[number - 1].Text == "O" && buttons[number + 1].Text == "O")
                                {
                                    MessageBox.Show("Sayi Kaybedildi");
                                }
                            }
                            else if (number == 0 || number == 3 || number == 6)
                            {
                                if (buttons[number + 1].Text == "O" && buttons[number + 2].Text == "O")
                                {
                                    MessageBox.Show("Sayi Kaybedildi");
                                }
                            }
                            else if (number == 8 || number == 5 || number == 2)
                            {
                                if (buttons[number - 1].Text == "O" && buttons[number - 2].Text == "O")
                                {
                                    MessageBox.Show("Sayi Kaybedildi");
                                }
                            }
                        }

                    }
                }

                int number2 = buttons.IndexOf(btn);
                if (number2 != 0 && number2 != 8 && number2 != 5 && number2 != 3 && number2 != 6)
                {
                    if (buttons[number2].Text=="X" && buttons[number2 - 1].Text == "X" || buttons[number2 + 1].Text == "X" )
                    {
                        if (buttons[number2 - 1].Text != "O" && buttons[number2 + 1].Text != "O")
                        lblMinimax.Text = "1";
                        else
                            lblMinimax.Text = "0";
                    }
                    else
                    {
                        lblMinimax.Text = "0";
                    }
                    if (buttons[number2 - 1].Text == "X" && buttons[number2 + 1].Text == "X")
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
                    else
                    {
                        lblMinimax.Text = "0";
                    }
                    if (buttons[number2 + 1].Text == "X" && buttons[number2 + 2].Text == "X")
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
                    else
                    {
                        lblMinimax.Text = "0";
                    }
                    if (buttons[number2 - 1].Text == "X" && buttons[number2 - 2].Text == "X")
                    {
                        MessageBox.Show("Sayi Kazanildi");
                    }
                }
            }
        }


        private void ResetForm()
        {
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
        private void label11_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
