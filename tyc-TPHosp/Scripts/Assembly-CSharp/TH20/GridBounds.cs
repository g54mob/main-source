using System.Diagnostics;

namespace TH20
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public struct GridBounds
	{
		public GridCoord Min;

		public GridCoord Max;

		public GridCoord Center => Min + (Max - Min) / 2;

		private string DebuggerDisplay => $"Min: ({Min.X}, {Min.Y}), Max: ({Max.X}, {Max.Y})";

		public GridBounds(int minX, int minY, int maxX, int maxY)
		{
			Min.X = minX;
			Min.Y = minY;
			Max.X = maxX;
			Max.Y = maxY;
		}

		public void Grow(int amount)
		{
			Min.X -= amount;
			Min.Y -= amount;
			Max.X += amount;
			Max.Y += amount;
		}

		public bool IsInBounds(GridCoord coord)
		{
			return IsInBounds(coord, this);
		}

		public static GridBounds operator +(GridBounds lhs, GridCoord rhs)
		{
			GridBounds result = lhs;
			result.Min += rhs;
			result.Max += rhs;
			return result;
		}

		public static GridBounds operator -(GridBounds lhs, GridCoord rhs)
		{
			GridBounds result = lhs;
			result.Min -= rhs;
			result.Max -= rhs;
			return result;
		}

		public static GridBounds operator |(GridBounds lhs, GridBounds rhs)
		{
			GridBounds result = default(GridBounds);
			result.Min.X = ((lhs.Min.X > rhs.Min.X) ? rhs.Min.X : lhs.Min.X);
			result.Min.Y = ((lhs.Min.Y > rhs.Min.Y) ? rhs.Min.Y : lhs.Min.Y);
			result.Max.X = ((lhs.Max.X < rhs.Max.X) ? rhs.Max.X : lhs.Max.X);
			result.Max.Y = ((lhs.Max.Y < rhs.Max.Y) ? rhs.Max.Y : lhs.Max.Y);
			return result;
		}

		public static bool IsInBounds(GridCoord coord, GridBounds bounds)
		{
			if (coord.X >= bounds.Min.X && coord.Y >= bounds.Min.Y && coord.X <= bounds.Max.X)
			{
				return coord.Y <= bounds.Max.Y;
			}
			return false;
		}

		public static GridCoord ClampToBounds(GridCoord coord, GridBounds bounds)
		{
			return new GridCoord(MathUtils.Clamp(coord.X, bounds.Min.X, bounds.Max.X), MathUtils.Clamp(coord.Y, bounds.Min.Y, bounds.Max.Y));
		}

		public void Encapsulate(GridCoord coord)
		{
			if (coord.X < Min.X)
			{
				Min.X = coord.X;
			}
			if (coord.X > Max.X)
			{
				Max.X = coord.X;
			}
			if (coord.Y < Min.Y)
			{
				Min.Y = coord.Y;
			}
			if (coord.Y > Max.Y)
			{
				Max.Y = coord.Y;
			}
		}

		public override string ToString()
		{
			return DebuggerDisplay;
		}

		public bool Intersects(GridBounds bounds)
		{
			if (Min.X <= bounds.Max.X && Max.X >= bounds.Min.X)
			{
				if (Min.Y <= bounds.Max.Y)
				{
					return Max.Y >= bounds.Min.Y;
				}
				return false;
			}
			return false;
		}
	}
}
