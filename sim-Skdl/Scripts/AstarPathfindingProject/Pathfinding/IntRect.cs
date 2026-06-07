using System;
using Pathfinding.Util;
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

		public Int2 Min => default(Int2);

		public Int2 Max => default(Int2);

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

		public IntRect ExpandToContain(int x, int y)
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

		public void DebugDraw(GraphTransform transform, Color color)
		{
		}
	}
}
