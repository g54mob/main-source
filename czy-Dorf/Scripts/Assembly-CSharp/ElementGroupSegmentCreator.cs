using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class ElementGroupSegmentCreator : ScriptableObject
{
	public ElementGroupSegment[] fallbackSegmentPrefabs;

	private Dictionary<string, int> edgeConstellationToPrefabIndex = new Dictionary<string, int>
	{
		{ "0", 0 },
		{ "01", 1 },
		{ "02", 2 },
		{ "03", 3 },
		{ "012", 4 },
		{ "013", 5 },
		{ "014", 6 },
		{ "024", 7 },
		{ "0123", 8 },
		{ "0124", 9 },
		{ "0134", 10 },
		{ "01234", 11 },
		{ "012345", 12 }
	};

	[SerializeField]
	private List<SegmentType> allSegmentTypes;

	[SerializeField]
	private List<ElementGroupSegment> allElementGroupSegments;

	[SerializeField]
	private List<ElementGroupSegment> baseElementGroupSegments;

	private Dictionary<string, Dictionary<string, ElementGroupSegment>> segmentByGroupTypeAndSegmentType;

	private Dictionary<GroupTypeId, Dictionary<SegmentTypeId, ElementGroupSegment>> segmentByGroupTypeIdAndSegmentTypeId;

	private Dictionary<GroupTypeId, Dictionary<SegmentTypeId, ElementGroupSegment>> baseSegmentByGroupTypeIdAndSegmentTypeId = new Dictionary<GroupTypeId, Dictionary<SegmentTypeId, ElementGroupSegment>>();

	public void DetermineSegmentTypeAndRotationFromEdges(List<int> occupiedEdges, out SegmentTypeId segmentType, out int rotation)
	{
		int count = occupiedEdges.Count;
		rotation = 0;
		segmentType = SegmentTypeId.Undefined;
		if (count < 6)
		{
			int num = 0;
			int index = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < 12; i++)
			{
				if (occupiedEdges[num2] == i % 6)
				{
					if (num4 == 0)
					{
						num3 = num2;
					}
					num4++;
					num2 = (num2 + 1) % occupiedEdges.Count;
				}
				else
				{
					if (num4 > num)
					{
						num = num4;
						index = num3;
					}
					num4 = 0;
				}
			}
			rotation = occupiedEdges[index] % 6;
		}
		for (int j = 0; j < count; j++)
		{
			occupiedEdges[j] = (occupiedEdges[j] - rotation + 6) % 6;
		}
		List<int> list = new List<int>(occupiedEdges);
		list.Sort();
		string text = "";
		foreach (int item in list)
		{
			text += item;
		}
		if (text == "04")
		{
			text = "02";
			rotation = (rotation + 4) % 6;
		}
		if (!edgeConstellationToPrefabIndex.ContainsKey(text))
		{
			Debug.LogError("No prefab index found for edge constellation " + text);
		}
		else
		{
			segmentType = allSegmentTypes[edgeConstellationToPrefabIndex[text]].id;
		}
	}

	public ElementGroupSegment CreateSegment(SegmentData002 segmentInfo)
	{
		if (segmentByGroupTypeIdAndSegmentTypeId == null)
		{
			SetupSegmentDictionary();
		}
		if (baseSegmentByGroupTypeIdAndSegmentTypeId.ContainsKey(segmentInfo.groupType) && baseSegmentByGroupTypeIdAndSegmentTypeId[segmentInfo.groupType].ContainsKey(segmentInfo.segmentType))
		{
			return CreateMemoryOptimizedSegment(segmentInfo);
		}
		return Object.Instantiate(segmentByGroupTypeIdAndSegmentTypeId[segmentInfo.groupType][segmentInfo.segmentType], Vector3.zero, Quaternion.identity);
	}

	private ElementGroupSegment CreateMemoryOptimizedSegment(SegmentData002 segmentInfo)
	{
		ElementGroupSegment elementGroupSegment = Object.Instantiate(baseSegmentByGroupTypeIdAndSegmentTypeId[segmentInfo.groupType][segmentInfo.segmentType], Vector3.zero, Quaternion.identity);
		ElementGroupSegment referencePrefab = segmentByGroupTypeIdAndSegmentTypeId[segmentInfo.groupType][segmentInfo.segmentType];
		elementGroupSegment.InitializeDataFromReferencePrefab(referencePrefab);
		return elementGroupSegment;
	}

	private void SetupSegmentDictionary()
	{
		segmentByGroupTypeAndSegmentType = new Dictionary<string, Dictionary<string, ElementGroupSegment>>();
		segmentByGroupTypeIdAndSegmentTypeId = new Dictionary<GroupTypeId, Dictionary<SegmentTypeId, ElementGroupSegment>>();
		baseSegmentByGroupTypeIdAndSegmentTypeId.Clear();
		foreach (ElementGroupSegment allElementGroupSegment in allElementGroupSegments)
		{
			if (!(allElementGroupSegment.GroupType == null) && !(allElementGroupSegment.SegmentType == null))
			{
				if (!segmentByGroupTypeAndSegmentType.ContainsKey(allElementGroupSegment.GroupType.name))
				{
					segmentByGroupTypeAndSegmentType.Add(allElementGroupSegment.GroupType.name, new Dictionary<string, ElementGroupSegment>());
				}
				segmentByGroupTypeAndSegmentType[allElementGroupSegment.GroupType.name].Add(allElementGroupSegment.SegmentType.name, allElementGroupSegment);
				if (!segmentByGroupTypeIdAndSegmentTypeId.ContainsKey(allElementGroupSegment.GroupType.id))
				{
					segmentByGroupTypeIdAndSegmentTypeId.Add(allElementGroupSegment.GroupType.id, new Dictionary<SegmentTypeId, ElementGroupSegment>());
				}
				segmentByGroupTypeIdAndSegmentTypeId[allElementGroupSegment.GroupType.id].Add(allElementGroupSegment.SegmentType.id, allElementGroupSegment);
			}
		}
		foreach (ElementGroupSegment baseElementGroupSegment in baseElementGroupSegments)
		{
			if (!baseSegmentByGroupTypeIdAndSegmentTypeId.ContainsKey(baseElementGroupSegment.GroupType.id))
			{
				baseSegmentByGroupTypeIdAndSegmentTypeId.Add(baseElementGroupSegment.GroupType.id, new Dictionary<SegmentTypeId, ElementGroupSegment>());
			}
			baseSegmentByGroupTypeIdAndSegmentTypeId[baseElementGroupSegment.GroupType.id].Add(baseElementGroupSegment.SegmentType.id, baseElementGroupSegment);
		}
	}
}
