using Unity.Mathematics;

namespace Pathfinding
{
	public struct IntBounds
	{
		public int3 min;

		public int3 max;

		public int3 size => default(int3);

		public int volume => 0;

		public IntBounds(int xmin, int ymin, int zmin, int xmax, int ymax, int zmax)
		{
			min = default(int3);
			max = default(int3);
		}

		public IntBounds(int3 min, int3 max)
		{
			this.min = default(int3);
			this.max = default(int3);
		}

		public static IntBounds Intersection(IntBounds a, IntBounds b)
		{
			return default(IntBounds);
		}

		public static bool Intersects(IntBounds a, IntBounds b)
		{
			return false;
		}

		public IntBounds Offset(int3 offset)
		{
			return default(IntBounds);
		}

		public bool Contains(IntBounds other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object _b)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(IntBounds a, IntBounds b)
		{
			return false;
		}

		public static bool operator !=(IntBounds a, IntBounds b)
		{
			return false;
		}
	}
}
