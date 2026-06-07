using System;
using System.Collections.Generic;
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

		public Vector2Int Min => default(Vector2Int);

		public Vector2Int Max => default(Vector2Int);

		public int Width => 0;

		public int Height => 0;

		public int Area => 0;

		public IntRect(int xmin, int ymin, int xmax, int ymax)
		{
			this.xmin = 0;
			this.ymin = 0;
			this.xmax = 0;
			this.ymax = 0;
		}

		public bool Contains(int x, int y)
		{
			return false;
		}

		public bool Contains(IntRect other)
		{
			return false;
		}

		public bool IsValid()
		{
			return false;
		}

		public static bool operator ==(IntRect a, IntRect b)
		{
			return false;
		}

		public static bool operator !=(IntRect a, IntRect b)
		{
			return false;
		}

		public static explicit operator Rect(IntRect r)
		{
			return default(Rect);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static IntRect Intersection(IntRect a, IntRect b)
		{
			return default(IntRect);
		}

		public static bool Intersects(IntRect a, IntRect b)
		{
			return false;
		}

		public static IntRect Union(IntRect a, IntRect b)
		{
			return default(IntRect);
		}

		public static IntRect Exclude(IntRect a, IntRect b)
		{
			return default(IntRect);
		}

		public IntRect ExpandToContain(int x, int y)
		{
			return default(IntRect);
		}

		public IntRect Offset(Vector2Int offset)
		{
			return default(IntRect);
		}

		public IntRect Expand(int range)
		{
			return default(IntRect);
		}

		public override string ToString()
		{
			return null;
		}

		public List<Vector2Int> GetInnerCoordinates()
		{
			return null;
		}
	}
}
