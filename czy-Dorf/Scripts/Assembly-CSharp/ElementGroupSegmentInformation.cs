using System;
using System.Collections.Generic;

[Serializable]
public class ElementGroupSegmentInformation
{
	public SegmentData002 segmentData;

	public int index;

	public List<int> occupiedEdges;

	public GroupType groupType;

	public SegmentType segmentType;

	public GroupType GroupType
	{
		get
		{
			return groupType;
		}
		set
		{
			segmentData.groupType = value.id;
			groupType = value;
		}
	}
}
