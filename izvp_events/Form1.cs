using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izvp_events
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Game game;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Нова гра");
            panel2.Visible = false;
            panel1.Visible = true;
            label1.Text = "";
            label2.Text = "Всього паличок залишилось: 10";
            game = new Game(10,true);
            game.withdraw += addToHistory;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Нова гра");

            label1.Text = "";
            panel2.Visible = false;
            panel1.Visible = true;
            game = new Game(10, false);
            game.withdraw += addToHistory;
            computerTurn();
        }
        private void computerTurn()
        {
            if (!game.withdrawSticks(new Random().Next(3)+1))
            {
                panel1.Visible = false;
                panel2.Visible = true;
                if (!game.IsUserFirst)
                {
                    label1.Text = "Ви програли";
                }
                else
                {
                    label1.Text = "Ви перемогли";
                }
            }
            label2.Text = "Всього паличок залишилось: " + game.Sticks;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            if(game.withdrawSticks(3))
            {
                computerTurn();
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
                if (!game.IsUserFirst)
                {
                    label1.Text = "Ви програли";
                }
                else
                {
                    label1.Text = "Ви перемогли";
                }
            }
            label2.Text = "Всього паличок залишилось: "+game.Sticks;
        }
        private static void addToHistory(string message)
        {
            Console.WriteLine(message);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (game.withdrawSticks(2))
            {
                computerTurn();
            }
            else
            {
                panel2.Visible = true;
                panel1.Visible = false;
                if (!game.IsUserFirst)
                {
                    label1.Text = "Ви програли";
                }
                else
                {
                    label1.Text = "Ви перемогли";
                }
            }
            label2.Text = "Всього паличок залишилось: " + game.Sticks;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (game.withdrawSticks(1))
            {
                computerTurn();
            }
            else
            {
                panel2.Visible = true;
                panel1.Visible = false;
                if (!game.IsUserFirst)
                {
                    label1.Text = "Ви програли";
                }
                else
                {
                    label1.Text = "Ви перемогли";
                }
            }
            label2.Text = "Всього паличок залишилось: " + game.Sticks;
        }
    }
}
