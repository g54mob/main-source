using System;
using System.Collections.Generic;

[Serializable]
public class AffectingAdaptiveSegment
{
	public AdaptiveSegment adaptiveSegment;

	public List<SegmentNeighborType> blockingStates;
}
