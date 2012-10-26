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
        const int figureHeight = 20;
        const int figureWidth = 20;
        byte[,] matrix = new byte[10, 20];


        public myCanvas()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            matrix[3, 5] = 255;
            matrix[3, 4] = 255;

            this.Visible = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle);

            for (int i = 0; i <= 420; i += 21)
                e.Graphics.DrawLine(Pens.White, 0, i, 211, i);
            for (int i = 0; i <= 211; i += 21)
                e.Graphics.DrawLine(Pens.White, i, 0, i, 421);

            DrawFigures(e);
            //base.OnPaint(e);
        }

        private void DrawFigures(PaintEventArgs e)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 20; j++)
                {
                    if (matrix[i, j] != 0)
                        e.Graphics.FillRectangle(Brushes.Red, i * 21, j * 21, 22, 22);
                }


        }
    }
}
