using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	[Serializable]
	public class SegmentFitConstellation
	{
		public List<SegmentFitData> segments = new List<SegmentFitData>();

		public List<int> unavailableEdges = new List<int>();

		public List<int> intersectionEdges = new List<int>();

		public GroupTypeId groupType;

		public SegmentFitConstellation()
		{
		}

		public SegmentFitConstellation(SegmentFitConstellation constellationToCopy)
		{
			segments = new List<SegmentFitData>(constellationToCopy.segments);
			unavailableEdges = new List<int>(constellationToCopy.unavailableEdges);
			intersectionEdges = new List<int>(constellationToCopy.intersectionEdges);
		}

		public void AddSegment(SegmentFitData newSegment)
		{
			segments.Add(newSegment);
			unavailableEdges.AddRange(newSegment.occupiedEdges);
			intersectionEdges.AddRange(newSegment.occupiedEdges);
		}
	}
}
