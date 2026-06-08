using System;

[Serializable]
public class SegmentEdgeInfo
{
	public GroupType groupType;

	public ElementGroupSegment elementGroupSegment;

	public ElementGroup elementGroup;

	public HybridSegment hybridSegment;

	public SegmentEdgeInfo(ElementGroupSegment segment)
	{
		elementGroupSegment = segment;
		groupType = segment.GroupType;
		hybridSegment = segment.HybridSegment;
	}
}
