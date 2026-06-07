using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	public struct Rect64
	{
		public long left;

		public long top;

		public long right;

		public long bottom;

		public long Width
		{
			readonly get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long Height
		{
			readonly get
			{
				return 0L;
			}
			set
			{
			}
		}

		public Rect64(long l, long t, long r, long b)
		{
			left = 0L;
			top = 0L;
			right = 0L;
			bottom = 0L;
		}

		public Rect64(bool isValid)
		{
			left = 0L;
			top = 0L;
			right = 0L;
			bottom = 0L;
		}

		public Rect64(Rect64 rec)
		{
			left = 0L;
			top = 0L;
			right = 0L;
			bottom = 0L;
		}

		public readonly bool IsEmpty()
		{
			return false;
		}

		public readonly bool IsValid()
		{
			return false;
		}

		public readonly Point64 MidPoint()
		{
			return default(Point64);
		}

		public readonly bool Contains(Point64 pt)
		{
			return false;
		}

		public readonly bool Contains(Rect64 rec)
		{
			return false;
		}

		public readonly bool Intersects(Rect64 rec)
		{
			return false;
		}

		public readonly List<Point64> AsPath()
		{
			return null;
		}
	}
}
