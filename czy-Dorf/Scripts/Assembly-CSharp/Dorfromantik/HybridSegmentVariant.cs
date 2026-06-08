using System;

namespace Dorfromantik
{
	[Serializable]
	public class HybridSegmentVariant
	{
		public SegmentType originalType;

		public SegmentType hybridType;

		public float hybridProbability;
	}
}
