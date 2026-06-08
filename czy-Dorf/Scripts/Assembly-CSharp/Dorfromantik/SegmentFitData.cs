using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	[Serializable]
	public class SegmentFitData
	{
		public SegmentType segmentType;

		public int rotation;

		public List<int> occupiedEdges;
	}
}
