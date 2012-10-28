﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Timer timeRefrash;
        Figure fig;
        bool flag;

        public Form1()
        {
            InitializeComponent();

            flag = false;

            timeRefrash = new Timer();
            timeRefrash.Interval = 500;
            timeRefrash.Tick += new EventHandler(timeRefrash_Tick);
            timeRefrash.Start();
        }

        void timeRefrash_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                fig = null;
                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 10; j++)
                        this.myCanvas1.background[i, j] += this.myCanvas1.matrix[i, j];
                delLine();
                flag = false;
            }
            if (fig == null)
            {
                createFig();

                if (!canStep())
                {
                    figToCanv();
                    figureStep();
                }
            }
            else
            {
                if (!canStep())
                {
                    for (int i = 0; i < 20; i++)
                        for (int j = 0; j < 10; j++)
                            this.myCanvas1.matrix[i, j] = 0;
                    figToCanv();
                    figureStep();
                }
            }

            this.myCanvas1.Refresh();
        }

        private void createFig()
        {
            Random rand = new Random();
            int rn = rand.Next(0, 4);
            //int rn = 0;
            switch (rn)
            {
                case 0:
                    fig = new Line();
                    break;
                case 1:
                    fig = new Square();
                    break;
                case 2:
                    fig = new Crane();
                    break;
                case 3:
                    fig = new Lightning();
                    break;
            }
        }

        private void figureStep()
        {
            fig.pt.Y += 1;
        }

        private void figToCanv()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (fig.map[i, j])
                    {
                        if ((i + fig.pt.Y > -1) && (i + fig.pt.Y < 20))
                            if ((j + fig.pt.X > -1) && (j + fig.pt.X < 10))
                                this.myCanvas1.matrix[i + fig.pt.Y, j + fig.pt.X] = fig.Color;
                    }
                }
            }
        }

        private bool canStep()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (fig.map[i, j])
                    {
                        if ((i + fig.pt.Y > -1) && (i + fig.pt.Y < 20))
                            if (this.myCanvas1.background[i + fig.pt.Y, j + fig.pt.X] != 0)
                                flag = true;
                            else
                                continue;
                        else
                            flag = true;
                    }
                }
                if (flag)
                    break;
            }
            return flag;
        }

        private void delLine()
        {
            bool flag1;
            for (int i = 19; i >= 0; i--)
            {
                flag1 = false;
                for (int j = 0; j < 10; j++)
                {
                    if (this.myCanvas1.background[i, j] == 0)
                        flag1 = true;
                }

                if (flag1)
                    break;

                for (int k = i; k > 0; k--)
                    for (int m = 0; m < 10; m++)
                        this.myCanvas1.background[k, m] = this.myCanvas1.background[k - 1, m];

                for (int m = 0; m < 10; m++)
                    this.myCanvas1.background[0, m] = 0;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fig != null)
            {
                fig.Rotate();
                this.myCanvas1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte flagLocal = 0;
            bool flag1 = false;
            if (fig != null)
            {
                if (this.myCanvas1.background[fig.pt.Y, fig.pt.X-1] != 0)
                    return;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                        if (fig.map[j, i])
                        {
                            flagLocal = (byte)i;
                            flag1 = true;
                        }
                    if (flag1)
                        break;
                }


                if (fig.pt.X - 1 < -flagLocal)
                    return;

                fig.pt.X--;
                for (int j = 0; j < 20; j++)
                    for (int k = 0; k < 10; k++)
                        this.myCanvas1.matrix[j, k] = 0;
                figToCanv();
                this.myCanvas1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte flagLocal = 0;
            bool flag1 = false;
            if (fig != null)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 0; j < 4; j++)
                        if (fig.map[j, i])
                        {
                            flagLocal = (byte)(Math.Abs(i - 3));
                            flag1 = true;
                        }
                    if (flag1)
                        break;
                }

                if (!((fig.pt.X + 4 + 1) <= (flagLocal + 10)))
                    return;

                fig.pt.X++;
                for (int j = 0; j < 20; j++)
                    for (int k = 0; k < 10; k++)
                        this.myCanvas1.matrix[j, k] = 0;
                figToCanv();
                this.myCanvas1.Refresh();

            }
        }
    }
}
