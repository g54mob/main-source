namespace SpaceGraphicsToolkit
{
	public struct SgtRectL
	{
		public long minX;

		public long minY;

		public long maxX;

		public long maxY;

		public long SizeX => 0L;

		public long SizeY => 0L;

		public void ClampTo(SgtRectL other)
		{
		}

		public SgtRectL GetExpanded(long amount)
		{
			return default(SgtRectL);
		}

		public SgtRectL(long newMinX, long newMinY, long newMaxX, long newMaxY)
		{
			minX = 0L;
			minY = 0L;
			maxX = 0L;
			maxY = 0L;
		}

		public bool Contains(long x, long y)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void SwapX()
		{
		}

		public void SwapY()
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

		public static bool operator ==(SgtRectL a, SgtRectL b)
		{
			return false;
		}

		public static bool operator !=(SgtRectL a, SgtRectL b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
