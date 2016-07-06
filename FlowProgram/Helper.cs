﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowProgram
{
    public static class Helper
    {
        public enum Edges
        {
            All,
            Top,
            Bottom
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius = 0, Edges edge = Edges.All)
        {            
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius, edge))
            {
                graphics.DrawPath(pen, path);
            }
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius = 0, Edges edge = Edges.All)
        {
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius, edge))
            {
                graphics.FillPath(brush, path);
            }
        }

        public static Point Mul(this Point A, Point B)
        {
            return new Point(A.X * B.X, A.Y * B.Y);
        }

        public static Point Mul(this Point A, int B)
        {
            return new Point(A.X * B, A.Y * B);
        }

        public static Point Sub(this Point A, Point B)
        {
            return new Point(A.X - B.X, A.Y - B.Y);
        }

        public static Point Add(this Point A, Point B)
        {
            return new Point(A.X + B.X, A.Y + B.Y);
        }

        public static Size Sub(this Size A, Size B)
        {
            return new Size(A.Width - B.Width, A.Height- B.Height);
        }

        public static Size Add(this Size A, Size B)
        {
            return new Size(A.Width + B.Width, A.Height + B.Height);
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius = 0, Edges edge = Edges.All)
        {            
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            switch (edge)
            {
                case Edges.All:
                    // top left arc  
                    path.AddArc(arc, 180, 90);

                    // top right arc  
                    arc.X = bounds.Right - diameter;
                    path.AddArc(arc, 270, 90);

                    // bottom right arc
                    arc.Y = bounds.Bottom - diameter;
                    path.AddArc(arc, 0, 90);

                    // bottom left arc
                    arc.X = bounds.Left;
                    path.AddArc(arc, 90, 90);
                    break;
                case Edges.Top:
                    // top left arc 
                    path.AddArc(arc, 180, 90);

                    // top right arc
                    arc.X = bounds.Right - diameter;
                    path.AddArc(arc, 270, 90);

                    path.AddRectangle(new Rectangle(bounds.Location.Add(new Point (0, radius)), bounds.Size.Sub(new Size(0, radius))));

                    break;
                case Edges.Bottom:
                    // bottom right arc
                    arc.Y = bounds.Bottom - diameter;
                    path.AddArc(arc, 0, 90);

                    // bottom left arc
                    arc.X = bounds.Left;
                    path.AddArc(arc, 90, 90);
                    break;
                default:
                    break;
            }
            
            path.CloseFigure();
            return path;
        }
    }
}