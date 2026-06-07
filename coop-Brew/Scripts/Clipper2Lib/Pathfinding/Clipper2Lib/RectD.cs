namespace Pathfinding.Clipper2Lib
{
	public struct RectD
	{
		public double left;

		public double top;

		public double right;

		public double bottom;

		public double Width
		{
			readonly get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Height
		{
			readonly get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public RectD(double l, double t, double r, double b)
		{
			left = 0.0;
			top = 0.0;
			right = 0.0;
			bottom = 0.0;
		}

		public RectD(RectD rec)
		{
			left = 0.0;
			top = 0.0;
			right = 0.0;
			bottom = 0.0;
		}

		public RectD(bool isValid)
		{
			left = 0.0;
			top = 0.0;
			right = 0.0;
			bottom = 0.0;
		}

		public readonly bool IsEmpty()
		{
			return false;
		}

		public readonly PointD MidPoint()
		{
			return default(PointD);
		}

		public readonly bool Contains(PointD pt)
		{
			return false;
		}

		public readonly bool Contains(RectD rec)
		{
			return false;
		}

		public readonly bool Intersects(RectD rec)
		{
			return false;
		}

		public readonly PathD AsPath()
		{
			return null;
		}
	}
}
