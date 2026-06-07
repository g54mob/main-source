using System;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtBoundsL
	{
		public long minX;

		public long minY;

		public long minZ;

		public long maxX;

		public long maxY;

		public long maxZ;

		public SgtBoundsL Double => default(SgtBoundsL);

		public long SizeX => 0L;

		public long SizeY => 0L;

		public long SizeZ => 0L;

		public SgtRectL RectZY => default(SgtRectL);

		public SgtRectL RectXZ => default(SgtRectL);

		public SgtRectL RectXY => default(SgtRectL);

		public SgtBoundsL(long x, long y, long z, long size)
		{
			minX = 0L;
			minY = 0L;
			minZ = 0L;
			maxX = 0L;
			maxY = 0L;
			maxZ = 0L;
		}

		public SgtBoundsL(long newMinX, long newMinY, long newMinZ, long newMaxX, long newMaxY, long newMaxZ)
		{
			minX = 0L;
			minY = 0L;
			minZ = 0L;
			maxX = 0L;
			maxY = 0L;
			maxZ = 0L;
		}

		public void ClampTo(SgtBoundsL other)
		{
		}

		public bool Contains(SgtVector3L xyz)
		{
			return false;
		}

		public bool Contains(long x, long y, long z)
		{
			return false;
		}

		public bool IsInsideX(long x)
		{
			return false;
		}

		public bool IsInsideY(long y)
		{
			return false;
		}

		public bool IsInsideZ(long z)
		{
			return false;
		}

		public void Clear()
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(SgtBoundsL a, SgtBoundsL b)
		{
			return false;
		}

		public static bool operator !=(SgtBoundsL a, SgtBoundsL b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
