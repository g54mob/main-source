using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public class ElementGroupSegmentAdaptor : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public List<int> occupiedTileEdges;

		public Func<int, bool> _003C_003E9__0;

		internal bool _003CRotationToFitOnTile_003Eb__0(int rotatedEdge)
		{
			return occupiedTileEdges.Contains(rotatedEdge);
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int givenEdge;

		internal bool _003CIsSegmentValid_003Eb__0(int x)
		{
			if (x != (givenEdge + 1) % 6)
			{
				return x == (givenEdge - 1 + 6) % 6;
			}
			return true;
		}
	}

	[SerializeField]
	private List<SegmentType> allSegmentTypes;

	private int debugCounter;

	public int RotationToFitOnTile(List<int> segmentEdgeConstellation, List<int> occupiedTileEdges)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals2.occupiedTileEdges = occupiedTileEdges;
		int result = -1;
		for (int i = 0; i < 12; i++)
		{
			if (!Enumerable.Any(GridCalculator.RotateDirections(segmentEdgeConstellation, i), (int rotatedEdge) => CS_0024_003C_003E8__locals2.occupiedTileEdges.Contains(rotatedEdge)))
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public static List<int> RotationsToFitOnTile(List<int> segmentEdges, List<int> occupiedTileEdges)
	{
		List<int> list = new List<int>();
		int num = ((occupiedTileEdges.Count > 0) ? Enumerable.Max(occupiedTileEdges) : 0);
		for (int i = 0; i < 6; i++)
		{
			if (!Enumerable.Any(GridCalculator.RotateDirections(segmentEdges, i + num), occupiedTileEdges.Contains))
			{
				list.Add((i + num) % 6);
			}
		}
		return list;
	}

	public List<SegmentFitConstellation> FittingSegmentConstellations(List<int> givenEdges, List<int> intersectionEdges, GroupTypeId groupType)
	{
		List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };
		foreach (int givenEdge in givenEdges)
		{
			list.Remove(givenEdge);
		}
		debugCounter = 0;
		return RecursivelyFindSegmentConstellations(new SegmentFitConstellation
		{
			unavailableEdges = list,
			intersectionEdges = intersectionEdges
		}, givenEdges, groupType);
	}

	private List<SegmentFitConstellation> RecursivelyFindSegmentConstellations(SegmentFitConstellation segmentFitConstellation, List<int> givenEdges, GroupTypeId groupType)
	{
		List<SegmentFitConstellation> list = new List<SegmentFitConstellation>();
		if (segmentFitConstellation.unavailableEdges.Count >= 6 || debugCounter > 1000)
		{
			list.Add(segmentFitConstellation);
			return list;
		}
		foreach (SegmentFitData item in FittingSegments(segmentFitConstellation.unavailableEdges, segmentFitConstellation.intersectionEdges))
		{
			debugCounter++;
			if (IsSegmentValid(item, givenEdges, groupType))
			{
				SegmentFitConstellation segmentFitConstellation2 = new SegmentFitConstellation(segmentFitConstellation);
				segmentFitConstellation2.AddSegment(item);
				list.AddRange(RecursivelyFindSegmentConstellations(segmentFitConstellation2, givenEdges, groupType));
			}
		}
		return list;
	}

	private bool IsSegmentValid(SegmentFitData checkSegment, List<int> givenEdges, GroupTypeId groupType)
	{
		using (List<int>.Enumerator enumerator = givenEdges.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass6_0();
				CS_0024_003C_003E8__locals4.givenEdge = enumerator.Current;
				if (groupType != GroupTypeId.TrainTracks && !checkSegment.occupiedEdges.Contains(CS_0024_003C_003E8__locals4.givenEdge) && Enumerable.Any(checkSegment.occupiedEdges, (int x) => x == (CS_0024_003C_003E8__locals4.givenEdge + 1) % 6 || x == (CS_0024_003C_003E8__locals4.givenEdge - 1 + 6) % 6))
				{
					return false;
				}
			}
		}
		return true;
	}

	public List<SegmentFitData> FittingSegments(List<int> unavailableEdges, List<int> intersectionEdges)
	{
		List<SegmentFitData> list = new List<SegmentFitData>();
		foreach (SegmentType allSegmentType in allSegmentTypes)
		{
			foreach (int item in RotationsToFitOnTile(allSegmentType.edges, unavailableEdges))
			{
				List<int> list2 = GridCalculator.RotateDirections(allSegmentType.edges, item);
				if (!IsIntersecting(list2, intersectionEdges))
				{
					list.Add(new SegmentFitData
					{
						segmentType = allSegmentType,
						rotation = item,
						occupiedEdges = list2
					});
					break;
				}
			}
		}
		return list;
	}

	private bool IsIntersecting(List<int> rotatedEdges, List<int> intersectionEdges)
	{
		if (rotatedEdges.Count <= 1 || intersectionEdges.Count <= 1)
		{
			return false;
		}
		int num = 0;
		bool flag = true;
		for (int i = 0; i < 6; i++)
		{
			int item = (rotatedEdges[0] + i) % 6;
			if (flag && intersectionEdges.Contains(item))
			{
				flag = false;
				num++;
			}
			else if (!flag && rotatedEdges.Contains(item))
			{
				flag = true;
			}
		}
		return num >= 2;
	}
}
