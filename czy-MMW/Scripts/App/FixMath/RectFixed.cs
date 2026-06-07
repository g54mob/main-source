using UnityEngine;

namespace FixMath
{
	public struct RectFixed
	{
		public Fix64 x;

		public Fix64 y;

		public Fix64 width;

		public Fix64 height;

		public Vector3Fixed Position
		{
			get
			{
				return new Vector3Fixed(x, y);
			}
			set
			{
				x = value.x;
				y = value.y;
			}
		}

		public Vector3Fixed Center
		{
			get
			{
				return new Vector3Fixed(x + width / Fix64Consts.Two, y + height / Fix64Consts.Two);
			}
			set
			{
				x = value.x - width / Fix64Consts.Two;
				y = value.y - height / Fix64Consts.Two;
			}
		}

		public Vector3Fixed Min
		{
			get
			{
				return new Vector3Fixed(xMin, yMin);
			}
			set
			{
				xMin = value.x;
				yMin = value.y;
			}
		}

		public Vector3Fixed Max
		{
			get
			{
				return new Vector3Fixed(xMax, yMax);
			}
			set
			{
				xMax = value.x;
				yMax = value.y;
			}
		}

		public Vector3Fixed Size
		{
			get
			{
				return new Vector3Fixed(width, height);
			}
			set
			{
				width = value.x;
				height = value.y;
			}
		}

		public Fix64 xMin
		{
			get
			{
				return x;
			}
			set
			{
				Fix64 fix = xMax;
				x = value;
				width = fix - x;
			}
		}

		public Fix64 yMin
		{
			get
			{
				return y;
			}
			set
			{
				Fix64 fix = yMax;
				y = value;
				height = fix - y;
			}
		}

		public Fix64 xMax
		{
			get
			{
				return width + x;
			}
			set
			{
				width = value - x;
			}
		}

		public Fix64 yMax
		{
			get
			{
				return height + y;
			}
			set
			{
				height = value - y;
			}
		}

		public RectFixed(Fix64 x, Fix64 y, Fix64 width, Fix64 height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public RectFixed(Vector3Fixed position, Vector3Fixed size)
		{
			x = position.x;
			y = position.y;
			width = size.x;
			height = size.y;
		}

		public RectFixed(RectFixed source)
		{
			x = source.xMin;
			y = source.yMin;
			width = source.width;
			height = source.height;
		}

		public static bool operator !=(RectFixed lhs, RectFixed rhs)
		{
			if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.width == rhs.width && lhs.height == rhs.height)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(RectFixed lhs, RectFixed rhs)
		{
			if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.width == rhs.width && lhs.height == rhs.height)
			{
				return true;
			}
			return false;
		}

		public static RectFixed MinMaxRect(Fix64 xmin, Fix64 ymin, Fix64 xmax, Fix64 ymax)
		{
			return new RectFixed(xmin, ymin, xmax - xmin, ymax - ymin);
		}

		public void Set(Fix64 x, Fix64 y, Fix64 width, Fix64 height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public override string ToString()
		{
			return $"(x:{x:F2}, y:{y:F2}, width:{width:F2}, height:{height:F2})";
		}

		public bool Contains(Vector2Int point)
		{
			if ((Fix64)point.x >= xMin && (Fix64)point.x <= xMax && (Fix64)point.y >= yMin)
			{
				return (Fix64)point.y <= yMax;
			}
			return false;
		}

		private static RectFixed OrderMinMax(RectFixed rect)
		{
			if (rect.xMin > rect.xMax)
			{
				Fix64 fix = rect.xMin;
				rect.xMin = rect.xMax;
				rect.xMax = fix;
			}
			if (rect.yMin > rect.yMax)
			{
				Fix64 fix2 = rect.yMin;
				rect.yMin = rect.yMax;
				rect.yMax = fix2;
			}
			return rect;
		}

		public bool Overlaps(RectFixed other)
		{
			if (other.xMax > xMin && other.xMin < xMax && other.yMax > yMin && other.yMin < yMax)
			{
				return true;
			}
			return false;
		}

		public static Vector3Fixed NormalizedToPoint(RectFixed rectangle, Vector3Fixed normalizedRectCoordinates)
		{
			return new Vector3Fixed(Fix64.Lerp(rectangle.x, rectangle.xMax, normalizedRectCoordinates.x), Fix64.Lerp(rectangle.y, rectangle.yMax, normalizedRectCoordinates.y));
		}

		public override int GetHashCode()
		{
			return x.GetHashCode() ^ (width.GetHashCode() << 2) ^ (y.GetHashCode() >> 2) ^ (height.GetHashCode() >> 1);
		}

		public override bool Equals(object other)
		{
			if (!(other is RectFixed rectFixed))
			{
				return false;
			}
			if (x.Equals(rectFixed.x) && y.Equals(rectFixed.y) && width.Equals(rectFixed.width))
			{
				return height.Equals(rectFixed.height);
			}
			return false;
		}
	}
}
