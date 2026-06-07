using System;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtVector3L
	{
		public long x;

		public long y;

		public long z;

		public SgtVector3L(long newX, long newY, long newZ)
		{
			x = 0L;
			y = 0L;
			z = 0L;
		}
	}
}
