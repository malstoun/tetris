using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tetris
{
    public sealed class myCanvas : Control
    {
        public byte[,] background = new byte[20, 10];
        public byte[,] matrix = new byte[20, 10];


        public myCanvas()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.Visible = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle);

            for (int i = 0; i <= 420; i += 21)
                e.Graphics.DrawLine(Pens.White, 0, i, 211, i); // Горизонтальные линии
            for (int i = 0; i <= 211; i += 21)
                e.Graphics.DrawLine(Pens.White, i, 0, i, 421); // Вертикальные линии

            DrawBackground(e);
            DrawFigures(e);
            //base.OnPaint(e);
        }

        private void DrawBackground(PaintEventArgs e)
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (background[i, j] != 0)
                    {
                        switch (background[i, j])
                        {
                            case 1:
                                e.Graphics.FillRectangle(Brushes.Red, j * 21, i * 21, 22, 22);
                                break;
                            case 2:
                                e.Graphics.FillRectangle(Brushes.White, j * 21, i * 21, 22, 22);
                                break;
                            case 3:
                                e.Graphics.FillRectangle(Brushes.Yellow, j * 21, i * 21, 22, 22);
                                break;
                            case 4:
                                e.Graphics.FillRectangle(Brushes.Orange, j * 21, i * 21, 22, 22);
                                break;
                        }
                    }
                }
        }

        private void DrawFigures(PaintEventArgs e)
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        switch (matrix[i, j])
                        {
                            case 1:
                                e.Graphics.FillRectangle(Brushes.Red, j * 21, i * 21, 22, 22);
                                break;
                            case 2:
                                e.Graphics.FillRectangle(Brushes.White, j * 21, i * 21, 22, 22);
                                break;
                            case 3:
                                e.Graphics.FillRectangle(Brushes.Yellow, j * 21, i * 21, 22, 22);
                                break;
                            case 4:
                                e.Graphics.FillRectangle(Brushes.Orange, j * 21, i * 21, 22, 22);
                                break;
                        }
                    }
                }
        }
    }
}
