using System;
using System.Collections.Generic;

namespace Jobberwocky.TriangleNet.Geometry
{
	public class Rectangle
	{
		private double xmin;

		private double ymin;

		private double xmax;

		private double ymax;

		public double Left => xmin;

		public double Right => xmax;

		public double Bottom => ymin;

		public double Top => ymax;

		public Rectangle()
		{
			xmin = (ymin = double.MaxValue);
			xmax = (ymax = double.MinValue);
		}

		public void Expand(Point p)
		{
			xmin = Math.Min(xmin, p.x);
			ymin = Math.Min(ymin, p.y);
			xmax = Math.Max(xmax, p.x);
			ymax = Math.Max(ymax, p.y);
		}

		public void Expand(IEnumerable<Point> points)
		{
			foreach (Point point in points)
			{
				Expand(point);
			}
		}

		public void Expand(Rectangle other)
		{
			xmin = Math.Min(xmin, other.xmin);
			ymin = Math.Min(ymin, other.ymin);
			xmax = Math.Max(xmax, other.xmax);
			ymax = Math.Max(ymax, other.ymax);
		}

		public bool Contains(double x, double y)
		{
			return x >= xmin && x <= xmax && y >= ymin && y <= ymax;
		}

		public bool Contains(Point pt)
		{
			return Contains(pt.x, pt.y);
		}
	}
}
