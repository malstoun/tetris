using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tetris
{
    class Figure
    {
        public Point pt; // ай ай ай, публично нехорошо делать, но лень иначе
        protected byte color;
        public bool[,] map;

        public Figure()
        {
            pt = new Point(3, -1);
            map = new bool[4, 4];
        }

        public void Rotate()
        {
            bool[,] map = new bool[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    map[3 - j, i] = this.map[i, j];
            this.map = map;
        }

        public byte Color
        {
            get
            {
                return color;
            }
        }
    }

    class Line : Figure
    {
        public Line()
        {
            color = 1;
            map[1, 0] = true;
            map[1, 1] = true;
            map[1, 2] = true;
            map[1, 3] = true;
        }
    }

    class Square : Figure
    {
        public Square()
        {
            color = 2;
            map[1, 1] = true;
            map[1, 2] = true;
            map[2, 1] = true;
            map[2, 2] = true;
        }
    }

    class Crane : Figure
    {
        public Crane()
        {
            color = 3;
            map[1, 2] = true;
            map[2, 0] = true;
            map[2, 1] = true;
            map[2, 2] = true;
        }
    }

    class Lightning : Figure
    {
        public Lightning()
        {
            color = 4;
            map[1, 0] = true;
            map[1, 1] = true;
            map[2, 1] = true;
            map[2, 2] = true;
        }
    }
}
