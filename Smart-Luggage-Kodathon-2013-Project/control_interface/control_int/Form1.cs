using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace control_int
{
    public partial class Form1 : Form
    {
        byte[] buffer = new byte[5];
        
        public Form1()
        {
            InitializeComponent();
            buffer[0] = 0;
            buffer[1] = 0;
            buffer[2] = 0;
            buffer[3] = 0;
            buffer[4] = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*
              if (e.KeyCode == Keys.Up)
            {
                buffer[0] = 1;
                label1.Text = "up";
            }
            else {
                buffer[0] = 0;
            }
              if (e.KeyCode == Keys.Right)
              {
                  buffer[1] = 1;
                  label1.Text = "right";
              }
              else
              {
                  buffer[1] = 0;
              }
              if (e.KeyCode == Keys.Left)
              {
                  buffer[2] = 1;
                  label1.Text = "left";
              }
              else
              {
                  buffer[2] = 0;
              }
              if (e.KeyCode == Keys.Down)
              {
                  buffer[3] = 1;
                  label1.Text = "Down";
              }
              else
              {
                  buffer[3] = 0;
              }
              if (e.KeyCode == Keys.Space)
              {
                  buffer[4] = 1;
                  label1.Text = "Stop";
              }
              else
              {
                  buffer[4] = 0;
              }
              arduino.Write(buffer,0,5);
            */
            if (e.KeyCode == Keys.Up)
            {
                buffer[0] = 1;
                label1.Text = "up";
            }
                /*
            else {
                buffer[0] = 0;
            }
                 * */
              if (e.KeyCode == Keys.Right)
              {
                  buffer[1] = 1;
                  label1.Text = "right";
              }
                  /*
              else
              {
                  buffer[1] = 0;
              }
                   * */
              if (e.KeyCode == Keys.Left)
              {
                  buffer[2] = 1;
                  label1.Text = "left";
              }
                  /*
              else
              {
                  buffer[2] = 0;
              }
                   * */
              if (e.KeyCode == Keys.Down)
              {
                  buffer[3] = 1;
                  label1.Text = "Down";
              }
                  /*
              else
              {
                  buffer[3] = 0;
              }
                   * *//*
              if (e.KeyCode == Keys.Space)
              {
                  buffer[4] = 1;
                  label1.Text = "Stop";
              }
              else
              {
                  buffer[4] = 0;
              }
                */
              arduino.Write(buffer,0,5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (arduino.IsOpen == false) {
                arduino.Open();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                buffer[0] = 0;
                label1.Text = "up";
            }
            /*
            else {
                buffer[0] = 0;
            }
             * */
            if (e.KeyCode == Keys.Right)
            {
                buffer[1] = 0;
                label1.Text = "right";
            }
            /*
        else
        {
            buffer[1] = 0;
        }
             * */
            if (e.KeyCode == Keys.Left)
            {
                buffer[2] = 0;
                label1.Text = "left";
            }
            /*
        else
        {
            buffer[2] = 0;
        }
             * */
            if (e.KeyCode == Keys.Down)
            {
                buffer[3] = 0;
                label1.Text = "Down";
            }
            /*
        else
        {
            buffer[3] = 0;
        }
             * */
            /*
   if (e.KeyCode == Keys.Space)
   {
       buffer[4] = 1;
       label1.Text = "Stop";
   }
   else
   {
       buffer[4] = 0;
   }
     */
            arduino.Write(buffer, 0, 5);
        
        }

    }
    }