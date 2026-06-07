using Unity.Mathematics;

namespace Pathfinding
{
	public struct IntBounds
	{
		public int3 min;

		public int3 max;

		public int3 size => max - min;

		public int volume
		{
			get
			{
				int3 int5 = size;
				return int5.x * int5.y * int5.z;
			}
		}

		public IntBounds(int xmin, int ymin, int zmin, int xmax, int ymax, int zmax)
		{
			min = new int3(xmin, ymin, zmin);
			max = new int3(xmax, ymax, zmax);
		}

		public IntBounds(int3 min, int3 max)
		{
			this.min = min;
			this.max = max;
		}

		public static IntBounds Intersection(IntBounds a, IntBounds b)
		{
			return new IntBounds(math.max(a.min, b.min), math.min(a.max, b.max));
		}

		public IntBounds Offset(int3 offset)
		{
			return new IntBounds(min + offset, max + offset);
		}

		public bool Contains(IntBounds other)
		{
			return math.all((other.min >= min) & (other.max <= max));
		}

		public override string ToString()
		{
			return "(" + min.ToString() + " <= x < " + max.ToString() + ")";
		}

		public override bool Equals(object _b)
		{
			IntBounds intBounds = (IntBounds)_b;
			return this == intBounds;
		}

		public override int GetHashCode()
		{
			return min.GetHashCode() ^ (max.GetHashCode() << 2);
		}

		public static bool operator ==(IntBounds a, IntBounds b)
		{
			return math.all((a.min == b.min) & (a.max == b.max));
		}

		public static bool operator !=(IntBounds a, IntBounds b)
		{
			return !(a == b);
		}
	}
}
