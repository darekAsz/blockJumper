using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermario
{
    public partial class Form1 : Form
    {

        private bool onBlock = false;
        private bool right;
        private bool left;
        private bool jump=false;
        private int speed = 30;
        private int force;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
          
            
            
            //collisions left/right
            if(player.Right > block.Left && player.Left < block.Right - player.Width/2  && player.Top>block.Top && player.Top<block.Bottom)
            {
                right = false;
            }
            if (player.Left < block.Right && player.Right > block.Left + player.Width / 2 && player.Bottom > block.Top && player.Top > block.Top && player.Top < block.Bottom)
            {
                left = false;
            }
            //collision top

            if ((player.Left + player.Width - 5 > block.Left) && (player.Right - player.Width + 5 < block.Right) && (player.Top + player.Height > block.Top) && (player.Top < block.Top))
            {
                player.Top = block.Top - player.Height;
                force = 0;
                jump = false;
                onBlock = true;
            }

            if (player.Left > block.Right || player.Right < block.Left) onBlock= false;
            

            //collision bottom
            if ((player.Left + player.Width - 5 > block.Left) && (player.Right - player.Width + 5 < block.Right) && 
                 (player.Top <= block.Bottom) && player.Bottom>block.Bottom)
            {
                player.Top = block.Bottom-1 ;
                force = 0;
                jump = false;
            }

            if (right == true)
            {
                player.Left += 5;
            }
            if(left == true) { player.Left -= 5; }

            if(jump == true)
            {
                
                if(force >0)player.Top -= force--;

            }

            if(player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height;
                jump = false;
            }
            else
            {
                if(onBlock==false)
                    player.Top += 10;  
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right) { right = true; }
            if (e.KeyCode == Keys.Left) { left = true; }
            if (e.KeyCode == Keys.Escape) { this.Close(); }

            if(jump != true)
            {

                if(e.KeyCode == Keys.Space)
                {
                    onBlock = false;
                    jump = true;
                    force = speed;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; }
            if (e.KeyCode == Keys.Left) { left = false; }

        }
    } 
}
