using System;

namespace NSMedieval
{
	[Serializable]
	public struct Vec3Long
	{
		public long x;

		public long y;

		public long z;

		public Vec3Long(long x, long y, long z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public override string ToString()
		{
			return $"({x}, {y}, {z})";
		}
	}
}
