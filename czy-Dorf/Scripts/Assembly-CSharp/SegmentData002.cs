using System;
using Dorfromantik;

[Serializable]
public class SegmentData002 : SegmentData
{
	public GroupTypeId groupType;

	public SegmentTypeId segmentType;

	public int rotation;

	public SegmentData002()
	{
		version = 2;
	}

	public SegmentData002(ElementGroupSegment segment)
	{
		version = 2;
		groupType = segment.GroupType.id;
		segmentType = segment.SegmentType.id;
		rotation = segment.RotationIndex;
	}

	public SegmentData002(SegmentData001 oldSegment)
	{
		version = 2;
		groupType = SegmentData001.GroupTypeIdByName[oldSegment.groupType];
		segmentType = SegmentData001.SegmentTypeIdByName[oldSegment.segmentType];
		rotation = oldSegment.segmentRotation;
	}
}
