using System;
using System.Collections.Generic;
using Dorfromantik;

[Serializable]
public class SegmentData001 : SegmentData
{
	public string groupType;

	public string segmentType;

	public int segmentRotation;

	public static Dictionary<string, GroupTypeId> GroupTypeIdByName = new Dictionary<string, GroupTypeId>
	{
		{
			"Agriculture",
			GroupTypeId.Agriculture
		},
		{
			"Forest",
			GroupTypeId.Forest
		},
		{
			"Village",
			GroupTypeId.Village
		},
		{
			"Water",
			GroupTypeId.Water
		},
		{
			"Train",
			GroupTypeId.TrainTracks
		}
	};

	public static Dictionary<string, SegmentTypeId> SegmentTypeIdByName = new Dictionary<string, SegmentTypeId>
	{
		{
			"0_SegmentType_1A",
			SegmentTypeId.SegmentType1A
		},
		{
			"1_SegmentType_2A",
			SegmentTypeId.SegmentType2A
		},
		{
			"2_SegmentType_2B",
			SegmentTypeId.SegmentType2B
		},
		{
			"3_SegmentType_2C",
			SegmentTypeId.SegmentType2C
		},
		{
			"4_SegmentType_3A",
			SegmentTypeId.SegmentType3A
		},
		{
			"5_SegmentType_3B",
			SegmentTypeId.SegmentType3B
		},
		{
			"6_SegmentType_3C",
			SegmentTypeId.SegmentType3C
		},
		{
			"7_SegmentType_3D",
			SegmentTypeId.SegmentType3D
		},
		{
			"8_SegmentType_4A",
			SegmentTypeId.SegmentType4A
		},
		{
			"9_SegmentType_4B",
			SegmentTypeId.SegmentType4B
		},
		{
			"10_SegmentType_4C",
			SegmentTypeId.SegmentType4C
		},
		{
			"11_SegmentType_5A",
			SegmentTypeId.SegmentType5A
		},
		{
			"12_SegmentType_6A",
			SegmentTypeId.SegmentType6A
		}
	};

	public SegmentData001()
	{
		version = 1;
	}

	public SegmentData001(ElementGroupSegment segment)
	{
		version = 1;
		groupType = segment.GroupType.name;
		segmentType = segment.SegmentType.name;
		segmentRotation = segment.RotationIndex;
	}
}
