using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Tools
{
	public static class IntersectionHelper
	{
		public static void IntersectSegments(Point p0, Point p1, Point q0, Point q1, ref Point c0)
		{
			double num = p1.x - p0.x;
			double num2 = p1.y - p0.y;
			double num3 = q1.x - q0.x;
			double num4 = q1.y - q0.y;
			double num5 = p0.x - q0.x;
			double num6 = p0.y - q0.y;
			double num7 = num * num4 - num2 * num3;
			double num8 = (num3 * num6 - num4 * num5) / num7;
			c0.x = p0.X + num8 * num;
			c0.y = p0.Y + num8 * num2;
		}

		public static bool BoxRayIntersection(Rectangle rect, Point p0, Point p1, ref Point c1)
		{
			return BoxRayIntersection(rect, p0, p1.x - p0.x, p1.y - p0.y, ref c1);
		}

		public static bool BoxRayIntersection(Rectangle rect, Point p, double dx, double dy, ref Point c)
		{
			double x = p.X;
			double y = p.Y;
			double left = rect.Left;
			double right = rect.Right;
			double bottom = rect.Bottom;
			double top = rect.Top;
			if (x < left || x > right || y < bottom || y > top)
			{
				return false;
			}
			double num;
			double x2;
			double y2;
			if (dx < 0.0)
			{
				num = (left - x) / dx;
				x2 = left;
				y2 = y + num * dy;
			}
			else if (dx > 0.0)
			{
				num = (right - x) / dx;
				x2 = right;
				y2 = y + num * dy;
			}
			else
			{
				num = double.MaxValue;
				x2 = (y2 = 0.0);
			}
			double num2;
			double x3;
			double y3;
			if (dy < 0.0)
			{
				num2 = (bottom - y) / dy;
				x3 = x + num2 * dx;
				y3 = bottom;
			}
			else if (dy > 0.0)
			{
				num2 = (top - y) / dy;
				x3 = x + num2 * dx;
				y3 = top;
			}
			else
			{
				num2 = double.MaxValue;
				x3 = (y3 = 0.0);
			}
			if (num < num2)
			{
				c.x = x2;
				c.y = y2;
			}
			else
			{
				c.x = x3;
				c.y = y3;
			}
			return true;
		}
	}
}
