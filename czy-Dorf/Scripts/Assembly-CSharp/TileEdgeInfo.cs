using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class TileEdgeInfo
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<SegmentEdgeInfo, bool> _003C_003E9__11_0;

		public static Func<SegmentEdgeInfo, bool> _003C_003E9__11_1;

		public static Func<SegmentEdgeInfo, GroupType> _003C_003E9__11_2;

		public static Func<SegmentEdgeInfo, HybridSegment> _003C_003E9__13_0;

		public static Func<HybridSegment, bool> _003C_003E9__13_1;

		internal bool _003CGetEdgeTypes_003Eb__11_0(SegmentEdgeInfo x)
		{
			return x.hybridSegment;
		}

		internal bool _003CGetEdgeTypes_003Eb__11_1(SegmentEdgeInfo x)
		{
			return x.hybridSegment == null;
		}

		internal GroupType _003CGetEdgeTypes_003Eb__11_2(SegmentEdgeInfo x)
		{
			return x.groupType;
		}

		internal HybridSegment _003CGetHybridSegments_003Eb__13_0(SegmentEdgeInfo x)
		{
			return x.hybridSegment;
		}

		internal bool _003CGetHybridSegments_003Eb__13_1(HybridSegment x)
		{
			return x != null;
		}
	}

	private List<SegmentEdgeInfo> _003CsegmentEdges_003Ek__BackingField = new List<SegmentEdgeInfo>();

	private Dictionary<GroupType, SegmentEdgeInfo> _003CedgeInfoByGroupType_003Ek__BackingField = new Dictionary<GroupType, SegmentEdgeInfo>();

	public List<SegmentEdgeInfo> segmentEdges => _003CsegmentEdges_003Ek__BackingField;

	public Dictionary<GroupType, SegmentEdgeInfo> edgeInfoByGroupType => _003CedgeInfoByGroupType_003Ek__BackingField;

	public void AddElementGroupSegment(ElementGroupSegment segment)
	{
		SegmentEdgeInfo segmentEdgeInfo = new SegmentEdgeInfo(segment);
		segmentEdges.Add(segmentEdgeInfo);
		edgeInfoByGroupType.Add(segmentEdgeInfo.groupType, segmentEdgeInfo);
	}

	public void UpdateElementGroup(ElementGroup newElementGroup)
	{
		edgeInfoByGroupType[newElementGroup.GroupType].elementGroup = newElementGroup;
	}

	public ElementGroup GetElementGroup(GroupType groupType = null)
	{
		if (segmentEdges.Count == 0)
		{
			return null;
		}
		if (groupType != null && edgeInfoByGroupType.ContainsKey(groupType))
		{
			return edgeInfoByGroupType[groupType].elementGroup;
		}
		return segmentEdges[0].elementGroup;
	}

	public List<GroupType> GetEdgeTypes(TileEdgeType edgeType = TileEdgeType.Any)
	{
		List<SegmentEdgeInfo> source = new List<SegmentEdgeInfo>(segmentEdges);
		switch (edgeType)
		{
		case TileEdgeType.Hybrid:
			source = Enumerable.ToList(Enumerable.Where(source, (SegmentEdgeInfo x) => x.hybridSegment));
			break;
		case TileEdgeType.NonHybrid:
			source = Enumerable.ToList(Enumerable.Where(source, (SegmentEdgeInfo x) => x.hybridSegment == null));
			break;
		}
		return Enumerable.ToList(Enumerable.Select(source, (SegmentEdgeInfo x) => x.groupType));
	}

	public ElementGroupSegment GetElementGroupSegment(GroupType groupType)
	{
		if (segmentEdges.Count == 0)
		{
			return null;
		}
		if (groupType != null && edgeInfoByGroupType.ContainsKey(groupType))
		{
			return edgeInfoByGroupType[groupType].elementGroupSegment;
		}
		return segmentEdges[0].elementGroupSegment;
	}

	public List<HybridSegment> GetHybridSegments()
	{
		return Enumerable.ToList(Enumerable.Where(Enumerable.Select(segmentEdges, (SegmentEdgeInfo x) => x.hybridSegment), (HybridSegment x) => x != null));
	}
}
