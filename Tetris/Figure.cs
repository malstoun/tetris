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
        Point position;
        protected string color;
        protected bool[,] map = new bool[4, 4];

        public Figure()
        {
            
        }

        public void Rotate()
        {
            bool[,] map = new bool[4,4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    map[3 - j, i] = this.map[i, j];
            this.map = map;
        }
    }

    class Line : Figure
    {
        public Line()
        {
            color = "red";
            map[0, 0] = true;
            map[1, 0] = true;
            map[2, 0] = true;
            map[3, 0] = true;
        }
    }

    class Square : Figure
    {
        public Square()
        {
            color = "white";
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
            color = "yellow";
            map[3, 0] = true;
            map[0, 1] = true;
            map[1, 1] = true;
            map[2, 1] = true;
            map[3, 0] = true;
        }
    }

    class Lightning : Figure
    {
        public Lightning()
        {
            color = "orange";
            map[0, 1] = true;
            map[1, 1] = true;
            map[1, 2] = true;
            map[2, 2] = true;
        }
    }
}
