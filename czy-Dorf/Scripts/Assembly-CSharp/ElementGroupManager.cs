using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementGroupManager : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public CountTarget countTarget;

		public ElementType elementType;

		internal int _003CGetGroupCountByCondition_003Eg__ReferenceCount_007C1(ElementGroup x)
		{
			if (countTarget != CountTarget.Segments)
			{
				return x.ElementCount(elementType);
			}
			return x.Segments.Count;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ElementGroup, bool> _003C_003E9__27_0;

		internal bool _003CGetGroupCountByCondition_003Eb__27_0(ElementGroup x)
		{
			if (x.Valid)
			{
				return !x.PreviewClosed;
			}
			return false;
		}
	}

	private Dictionary<GroupType, List<ElementGroup>> allGroups;

	[SerializeField]
	private ElementGroupCreator elementGroupCreator;

	[SerializeField]
	private RewardSystem rewardSystem;

	public event Action<ElementGroup> OnGroupChanged;

	public event Action<ElementGroup, bool> OnGroupClosed;

	public event Action<ElementGroup> OnGroupRemoved;

	public event Action<ElementGroup> OnGroupAdded;

	private void Debug_AllElementGroups(GroupType type)
	{
		Debug.Log(ListHelper.ListDebugString(allGroups[type]));
	}

	private void Awake()
	{
		allGroups = new Dictionary<GroupType, List<ElementGroup>>();
	}

	public void CreateGroupsForTile(Tile newTile)
	{
		foreach (ElementGroupSegment allElementGroupSegment in newTile.AllElementGroupSegments)
		{
			ElementGroup newGroup = CreateGroup(allElementGroupSegment);
			foreach (int edge in allElementGroupSegment.Edges)
			{
				newTile.UpdateGroup(edge, newGroup);
			}
		}
	}

	private ElementGroup CreateGroup(ElementGroupSegment segment)
	{
		ElementGroup elementGroup = elementGroupCreator.CreateGroup(segment);
		if (!allGroups.ContainsKey(elementGroup.GroupType))
		{
			allGroups.Add(elementGroup.GroupType, new List<ElementGroup>());
		}
		allGroups[elementGroup.GroupType].Add(elementGroup);
		elementGroup.OnGroupClosed += CloseGroup;
		elementGroup.OnSegmentAdded += UpdateGroup;
		elementGroup.OnSegmentRemoved += UpdateGroup;
		elementGroup.OnAllSegmentsRemoved += RemoveGroup;
		UpdateGroup(elementGroup);
		this.OnGroupAdded?.Invoke(elementGroup);
		return elementGroup;
	}

	private void RemoveGroup(ElementGroup groupToRemove)
	{
		if ((bool)groupToRemove)
		{
			groupToRemove.OnGroupClosed -= CloseGroup;
			groupToRemove.OnSegmentAdded -= UpdateGroup;
			groupToRemove.OnSegmentRemoved -= UpdateGroup;
			groupToRemove.OnAllSegmentsRemoved -= RemoveGroup;
			groupToRemove.IsAboutToBeRemoved = true;
			allGroups[groupToRemove.GroupType].Remove(groupToRemove);
			UpdateGroup(groupToRemove);
			this.OnGroupRemoved?.Invoke(groupToRemove);
			UnityEngine.Object.Destroy(groupToRemove.gameObject);
		}
	}

	private void OnDestroy()
	{
		foreach (KeyValuePair<GroupType, List<ElementGroup>> allGroup in allGroups)
		{
			foreach (ElementGroup item in allGroup.Value)
			{
				item.OnGroupClosed -= CloseGroup;
				item.OnSegmentAdded -= UpdateGroup;
				item.OnSegmentRemoved -= UpdateGroup;
				item.OnAllSegmentsRemoved -= RemoveGroup;
			}
		}
	}

	public void CombineWithNeighborGroups(Tile newTile)
	{
		foreach (ElementGroupSegment allElementGroupSegment in newTile.AllElementGroupSegments)
		{
			ElementGroup elementGroup = newTile.GetElementGroup(allElementGroupSegment.Edges[0], Space.Self, allElementGroupSegment.GroupType);
			foreach (int edge in allElementGroupSegment.Edges)
			{
				int num = GridCalculator.RotatedDirection(edge, newTile.RotationIndex);
				Tile neighbor = newTile.GetNeighbor(num, Space.World);
				if ((bool)neighbor)
				{
					ElementGroup elementGroup2 = neighbor.GetElementGroup((num + 3) % 6, Space.World, allElementGroupSegment.GroupType);
					if (!(elementGroup2 == null) && !(elementGroup2.GroupType != elementGroup.GroupType) && !(elementGroup == elementGroup2))
					{
						elementGroup2.AddGroup(elementGroup);
						RemoveGroup(elementGroup);
						elementGroup = elementGroup2;
					}
				}
			}
			elementGroup.PlacementInitialization();
		}
	}

	public void Remove(Tile tileToRemove)
	{
		foreach (ElementGroupSegment allElementGroupSegment in tileToRemove.AllElementGroupSegments)
		{
			ElementGroup elementGroup = tileToRemove.GetElementGroup(allElementGroupSegment.Edges[0], Space.Self, allElementGroupSegment.GroupType);
			if (elementGroup.Segments.Count == 1)
			{
				continue;
			}
			elementGroup.IsAboutToBeRemoved = true;
			Dictionary<ElementGroupSegment, int> dictionary = new Dictionary<ElementGroupSegment, int>();
			int num = 0;
			foreach (ElementGroupSegment segment in elementGroup.Segments)
			{
				dictionary.Add(segment, -1);
				if (segment.Tile == tileToRemove)
				{
					dictionary[segment] = num;
					num++;
				}
			}
			List<ElementGroupSegment> neighborSegments = allElementGroupSegment.GetNeighborSegments();
			foreach (ElementGroupSegment item in neighborSegments)
			{
				num = (dictionary[item] = num + 1);
			}
			RecursivelyAddToGroups(neighborSegments, dictionary);
			Dictionary<int, List<ElementGroupSegment>> dictionary2 = new Dictionary<int, List<ElementGroupSegment>>();
			foreach (KeyValuePair<ElementGroupSegment, int> item2 in dictionary)
			{
				if (!dictionary2.ContainsKey(item2.Value))
				{
					dictionary2.Add(item2.Value, new List<ElementGroupSegment>());
				}
				dictionary2[item2.Value].Add(item2.Key);
			}
			if (dictionary2.Count <= 1)
			{
				continue;
			}
			Dictionary<ElementGroupSegment, ElementGroup> dictionary3 = new Dictionary<ElementGroupSegment, ElementGroup>();
			List<ElementGroup> list = new List<ElementGroup>();
			foreach (KeyValuePair<int, List<ElementGroupSegment>> item3 in dictionary2)
			{
				List<ElementGroupSegment> value = item3.Value;
				ElementGroup elementGroup2 = CreateGroup(value[0]);
				for (int i = 1; i < value.Count; i++)
				{
					elementGroup2.AddSegment(value[i], updateOpenEdgeCount: false);
				}
				for (int j = 0; j < value.Count; j++)
				{
					dictionary3.Add(value[j], elementGroup2);
				}
				list.Add(elementGroup2);
				elementGroup2.UpdateOpenEdgeCount();
				elementGroup2.highlighted = elementGroup.highlighted;
			}
			elementGroup.Split(list, dictionary3);
			RemoveGroup(elementGroup);
		}
	}

	private void RecursivelyAddToGroups(List<ElementGroupSegment> initialSearchSegments, Dictionary<ElementGroupSegment, int> groupIndexBySegment)
	{
		List<ElementGroupSegment> list = new List<ElementGroupSegment>(initialSearchSegments);
		List<ElementGroupSegment> list2 = new List<ElementGroupSegment>();
		int num = 0;
		while (list.Count > 0 && num < 10000)
		{
			foreach (ElementGroupSegment item in list)
			{
				num++;
				foreach (ElementGroupSegment neighborSegment in item.GetNeighborSegments())
				{
					if (!groupIndexBySegment.ContainsKey(neighborSegment))
					{
						Debug.LogError($"no groupBySegment entry for {neighborSegment}, checking from {item}");
						Debug.Break();
					}
					if (groupIndexBySegment[neighborSegment] == groupIndexBySegment[item])
					{
						continue;
					}
					if (groupIndexBySegment[neighborSegment] == -1)
					{
						groupIndexBySegment[neighborSegment] = groupIndexBySegment[item];
						list2.Add(neighborSegment);
					}
					else
					{
						if (groupIndexBySegment[neighborSegment] == groupIndexBySegment[item])
						{
							continue;
						}
						int num2 = groupIndexBySegment[item];
						int value = groupIndexBySegment[neighborSegment];
						foreach (ElementGroupSegment item2 in Enumerable.ToList(groupIndexBySegment.Keys))
						{
							if (groupIndexBySegment[item2] == num2)
							{
								groupIndexBySegment[item2] = value;
							}
						}
					}
				}
			}
			list = new List<ElementGroupSegment>(list2);
			list2.Clear();
		}
		if (num >= 10000)
		{
			Debug.LogError("Endless Loop!");
		}
	}

	private void UpdateGroup(ElementGroup elementGroup)
	{
		this.OnGroupChanged?.Invoke(elementGroup);
	}

	private void CloseGroup(ElementGroup group, bool closed)
	{
		this.OnGroupClosed?.Invoke(group, closed);
		if (closed && group.Segments.Count > 1 && rewardSystem.Configuration.rewardCompletedGroups)
		{
			int score = Mathf.RoundToInt(Mathf.Pow(group.Segments.Count - 1, rewardSystem.Configuration.groupCompletionScorePow) * rewardSystem.Configuration.groupScoreMultiplier);
			rewardSystem.AddScoreAtPosition(score, group.MedianPosition, ScoreFxType.Normal);
		}
	}

	public List<ElementGroup> GetGroupsByType(GroupType groupType)
	{
		return allGroups[groupType];
	}

	public int GetGroupCountByCondition(GroupType groupType, ElementType elementType, EqualityComparison equalityComparer, CountTarget countTarget, int seed = -1, List<ElementGroup> excludedGroups = null, bool countClosedGroups = false)
	{
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals5.countTarget = countTarget;
		CS_0024_003C_003E8__locals5.elementType = elementType;
		if (!allGroups.ContainsKey(groupType))
		{
			return 0;
		}
		if (allGroups[groupType].Count == 0)
		{
			return 0;
		}
		List<ElementGroup> list = allGroups[groupType];
		if (!countClosedGroups)
		{
			list = Enumerable.ToList(Enumerable.Where(allGroups[groupType], (ElementGroup elementGroup) => elementGroup.Valid && !elementGroup.PreviewClosed));
		}
		if (excludedGroups != null)
		{
			foreach (ElementGroup excludedGroup in excludedGroups)
			{
				list.Remove(excludedGroup);
			}
		}
		if (list.Count == 0)
		{
			return 0;
		}
		if (seed != -1)
		{
			UnityEngine.Random.InitState(seed);
		}
		List<ElementGroup> list2 = Enumerable.ToList(Enumerable.OrderByDescending(list, (ElementGroup elementGroup) => (CS_0024_003C_003E8__locals5.countTarget != CountTarget.Segments) ? elementGroup.ElementCount(CS_0024_003C_003E8__locals5.elementType) : elementGroup.Segments.Count));
		ElementGroup x;
		if (equalityComparer == EqualityComparison.Exactly)
		{
			list2 = Enumerable.ToList(Enumerable.Take(list2, 4));
			x = list2[UnityEngine.Random.Range(0, list2.Count)];
		}
		else
		{
			x = list2[0];
		}
		if (seed != -1)
		{
			Randomizer.RandomizeSeed();
		}
		return CS_0024_003C_003E8__locals5._003CGetGroupCountByCondition_003Eg__ReferenceCount_007C1(x);
	}

	public void Clear()
	{
		foreach (KeyValuePair<GroupType, List<ElementGroup>> allGroup in allGroups)
		{
			foreach (ElementGroup item in allGroup.Value)
			{
				item.SetValid(valid: false);
			}
		}
	}
}
