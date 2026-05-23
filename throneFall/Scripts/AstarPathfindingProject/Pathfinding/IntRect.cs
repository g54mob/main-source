using System;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public struct IntRect
	{
		public int xmin;

		public int ymin;

		public int xmax;

		public int ymax;

		public Int2 Min => new Int2(xmin, ymin);

		public Int2 Max => new Int2(xmax, ymax);

		public int Width => xmax - xmin + 1;

		public int Height => ymax - ymin + 1;

		public int Area => Width * Height;

		public IntRect(int xmin, int ymin, int xmax, int ymax)
		{
			this.xmin = xmin;
			this.xmax = xmax;
			this.ymin = ymin;
			this.ymax = ymax;
		}

		public bool Contains(int x, int y)
		{
			if (x >= xmin && y >= ymin && x <= xmax)
			{
				return y <= ymax;
			}
			return false;
		}

		public bool Contains(IntRect other)
		{
			if (xmin <= other.xmin && xmax >= other.xmax && ymin <= other.ymin)
			{
				return ymax >= other.ymax;
			}
			return false;
		}

		public bool IsValid()
		{
			if (xmin <= xmax)
			{
				return ymin <= ymax;
			}
			return false;
		}

		public static bool operator ==(IntRect a, IntRect b)
		{
			if (a.xmin == b.xmin && a.xmax == b.xmax && a.ymin == b.ymin)
			{
				return a.ymax == b.ymax;
			}
			return false;
		}

		public static bool operator !=(IntRect a, IntRect b)
		{
			if (a.xmin == b.xmin && a.xmax == b.xmax && a.ymin == b.ymin)
			{
				return a.ymax != b.ymax;
			}
			return true;
		}

		public static explicit operator Rect(IntRect r)
		{
			return new Rect(r.xmin, r.ymin, r.Width, r.Height);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is IntRect intRect))
			{
				return false;
			}
			if (xmin == intRect.xmin && xmax == intRect.xmax && ymin == intRect.ymin)
			{
				return ymax == intRect.ymax;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (xmin * 131071) ^ (xmax * 3571) ^ (ymin * 3109) ^ (ymax * 7);
		}

		public static IntRect Intersection(IntRect a, IntRect b)
		{
			return new IntRect(Math.Max(a.xmin, b.xmin), Math.Max(a.ymin, b.ymin), Math.Min(a.xmax, b.xmax), Math.Min(a.ymax, b.ymax));
		}

		public static bool Intersects(IntRect a, IntRect b)
		{
			if (a.xmin <= b.xmax && a.ymin <= b.ymax && a.xmax >= b.xmin)
			{
				return a.ymax >= b.ymin;
			}
			return false;
		}

		public static IntRect Union(IntRect a, IntRect b)
		{
			return new IntRect(Math.Min(a.xmin, b.xmin), Math.Min(a.ymin, b.ymin), Math.Max(a.xmax, b.xmax), Math.Max(a.ymax, b.ymax));
		}

		public static IntRect Exclude(IntRect a, IntRect b)
		{
			if (!b.IsValid() || !a.IsValid())
			{
				return a;
			}
			IntRect intRect = Intersection(a, b);
			if (!intRect.IsValid())
			{
				return a;
			}
			if (a.xmin == intRect.xmin && a.xmax == intRect.xmax)
			{
				if (a.ymin == intRect.ymin)
				{
					a.ymin = intRect.ymax + 1;
					return a;
				}
				if (a.ymax == intRect.ymax)
				{
					a.ymax = intRect.ymin - 1;
					return a;
				}
				throw new ArgumentException("B splits A into two disjoint parts");
			}
			if (a.ymin == intRect.ymin && a.ymax == intRect.ymax)
			{
				if (a.xmin == intRect.xmin)
				{
					a.xmin = intRect.xmax + 1;
					return a;
				}
				if (a.xmax == intRect.xmax)
				{
					a.xmax = intRect.xmin - 1;
					return a;
				}
				throw new ArgumentException("B splits A into two disjoint parts");
			}
			throw new ArgumentException("B covers either a corner of A, or does not touch the edges of A at all");
		}

		public IntRect ExpandToContain(int x, int y)
		{
			return new IntRect(Math.Min(xmin, x), Math.Min(ymin, y), Math.Max(xmax, x), Math.Max(ymax, y));
		}

		public IntRect Offset(Int2 offset)
		{
			return new IntRect(xmin + offset.x, ymin + offset.y, xmax + offset.x, ymax + offset.y);
		}

		public IntRect Expand(int range)
		{
			return new IntRect(xmin - range, ymin - range, xmax + range, ymax + range);
		}

		public override string ToString()
		{
			return "[x: " + xmin + "..." + xmax + ", y: " + ymin + "..." + ymax + "]";
		}
	}
}
