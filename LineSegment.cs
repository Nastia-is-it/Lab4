using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class LineSegment
    {
        private double start;
        private double end;

        public LineSegment(double x, double y)
        {
            start = x;
            end = y;
        }

        //public LineSegment(double value)
        //{
        //    start = value;
        //    end = value;
        //}

        public double Start
        {
            get 
            {
                return start;
            }
            set
            {
                start = value;
            }
        }

        public double End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }

        public bool InTheSegment(double value)
        {
            double min = Math.Min(start, end);
            double max = Math.Max(start, end);
            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double operator !(LineSegment segment)
        {
            return Math.Abs(segment.end - segment.start);
        }

        public static LineSegment operator ++(LineSegment segment)
        {
            segment.start += 1;
            segment.end += 1;
            return segment;
        }

        public static explicit operator int(LineSegment segment)
        {
            return (int)segment.start;
        }

        public static implicit operator double(LineSegment segment)
        {
            return segment.end;
        }
        public static LineSegment operator +(LineSegment segment, int d)
        {
            return new LineSegment(segment.start + d, segment.end + d);
        }

        public static LineSegment operator +(int d, LineSegment segment)
        {
            return segment + d;
        }
        public static bool operator <(LineSegment segment, int value)
        {
            return segment.InTheSegment(value);
        }

        public static bool operator >(LineSegment segment, int value)
        {
            return !segment.InTheSegment(value);
        }

        public override string ToString()
        {
            return "{" + start + "," + end + "}";
        }
    }
}
