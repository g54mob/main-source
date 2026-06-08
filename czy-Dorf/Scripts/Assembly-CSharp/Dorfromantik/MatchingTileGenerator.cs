using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik.CreativeMode;
using UnityEngine;

namespace Dorfromantik
{
	public class MatchingTileGenerator : ScriptableObject
	{
		private sealed class _003C_003Ec__DisplayClass14_0
		{
			public int edgeBlockedForAdaptiveSegments;

			public List<GroupTypeId> groupTypesToGenerateFor;

			public List<int> grassEdges;

			public Func<GroupTypeProbability, bool> _003C_003E9__2;

			public Func<int, bool> _003C_003E9__6;

			internal bool _003CGenerateFittingTile_003Eb__1(int x)
			{
				return x != edgeBlockedForAdaptiveSegments;
			}

			internal bool _003CGenerateFittingTile_003Eb__2(GroupTypeProbability x)
			{
				return groupTypesToGenerateFor.Contains(x.groupType);
			}

			internal bool _003CGenerateFittingTile_003Eb__6(int x)
			{
				return grassEdges.Contains(x);
			}
		}

		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<GroupTypeProbability, GroupTypeId> _003C_003E9__14_3;

			public static Func<GroupTypeProbability, float> _003C_003E9__14_4;

			public static Func<SegmentPresetInfo, SegmentType> _003C_003E9__14_0;

			public static Func<SegmentFitConstellation, bool> _003C_003E9__14_5;

			internal GroupTypeId _003CGenerateFittingTile_003Eb__14_3(GroupTypeProbability x)
			{
				return x.groupType;
			}

			internal float _003CGenerateFittingTile_003Eb__14_4(GroupTypeProbability x)
			{
				return x.probability;
			}

			internal SegmentType _003CGenerateFittingTile_003Eb__14_0(SegmentPresetInfo x)
			{
				return x.segmentType;
			}

			internal bool _003CGenerateFittingTile_003Eb__14_5(SegmentFitConstellation x)
			{
				return x.segments.Count == 1;
			}
		}

		[SerializeField]
		private bool assignRandomTypesToUndefinedEdges;

		[SerializeField]
		private bool assignAlreadyPresentTypesOnly = true;

		[SerializeField]
		private float emptyEdgeProbability;

		[SerializeField]
		private List<GroupTypeProbability> randomGroupTypeProbabilities;

		[SerializeField]
		private float hybridEdgeGrassProbability = 0.33f;

		[SerializeField]
		private TileGenerator tileGenerator;

		[SerializeField]
		private TileFactory tileFactory;

		[SerializeField]
		private ElementGroupSegmentAdaptor elementGroupSegmentAdaptor;

		[SerializeField]
		private Tile waterTrainStation;

		[SerializeField]
		private List<GroupType> allGroupTypes;

		[SerializeField]
		private List<SegmentFitConstellation> debug_segmentFits;

		private Dictionary<GroupTypeId, GroupType> groupTypeById;

		private Vector2Int posBlockedForAdaptiveTypes = Vector2Int.zero;

		private void Initialize()
		{
			groupTypeById = new Dictionary<GroupTypeId, GroupType>();
			foreach (GroupType allGroupType in allGroupTypes)
			{
				groupTypeById.Add(allGroupType.id, allGroupType);
			}
		}

		public Tile GenerateFittingTile(TileSlot targetTileSlot)
		{
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass14_0();
			if (groupTypeById == null || groupTypeById.Count == 0)
			{
				Initialize();
			}
			List<SegmentData002> list = new List<SegmentData002>();
			GroupType[] array = new GroupType[6];
			Dictionary<GroupTypeId, List<int>> dictionary = new Dictionary<GroupTypeId, List<int>>();
			List<int> list2 = new List<int>();
			CS_0024_003C_003E8__locals20.grassEdges = new List<int>();
			Vector2Int[] array2 = GridCalculator.NeighborDirections(targetTileSlot.GridPos);
			debug_segmentFits.Clear();
			CS_0024_003C_003E8__locals20.edgeBlockedForAdaptiveSegments = -1;
			Randomizer.RandomizeSeed();
			for (int i = 0; i < 6; i++)
			{
				List<GroupType> edgeTypes = targetTileSlot.GetEdgeTypes(i);
				GroupType groupType = ((edgeTypes.Count >= 1) ? edgeTypes[UnityEngine.Random.Range(0, edgeTypes.Count)] : null);
				if (targetTileSlot.GetEdgeTypes(i, TileEdgeType.Hybrid).Count > 0 && UnityEngine.Random.value <= hybridEdgeGrassProbability)
				{
					groupType = null;
				}
				if (groupType != null)
				{
					array[i] = groupType;
					if (!dictionary.ContainsKey(groupType.id))
					{
						dictionary.Add(groupType.id, new List<int>());
					}
					dictionary[groupType.id].Add(i);
				}
				else if (targetTileSlot.NeighborTiles[i] != null)
				{
					CS_0024_003C_003E8__locals20.grassEdges.Add(i);
				}
				else
				{
					list2.Add(i);
				}
				if (targetTileSlot.GridPos + array2[i] == posBlockedForAdaptiveTypes)
				{
					CS_0024_003C_003E8__locals20.edgeBlockedForAdaptiveSegments = i;
				}
			}
			if (dictionary.ContainsKey(GroupTypeId.Water) && dictionary[GroupTypeId.Water].Count == 1)
			{
				int num = dictionary[GroupTypeId.Water][0];
				int num2 = ((UnityEngine.Random.value >= 0.5f) ? 1 : (-1));
				int num3 = (num + num2 + 6) % 6;
				int num4 = (num - num2 + 6) % 6;
				List<int> list3 = list2;
				if (CS_0024_003C_003E8__locals20.edgeBlockedForAdaptiveSegments != -1)
				{
					list3 = Enumerable.ToList(Enumerable.Where(list2, (int x) => x != CS_0024_003C_003E8__locals20.edgeBlockedForAdaptiveSegments));
				}
				if (list3.Count > 0)
				{
					int item = list3[UnityEngine.Random.Range(0, list3.Count)];
					dictionary[GroupTypeId.Water].Add(item);
					list2.Remove(item);
				}
				else if (targetTileSlot.GetEdgeTypes(num, TileEdgeType.Hybrid).Count > 0)
				{
					dictionary.Remove(GroupTypeId.Water);
					CS_0024_003C_003E8__locals20.grassEdges.Add(num);
				}
				else if (array[num3] == null)
				{
					dictionary[GroupTypeId.Water].Add(num3);
					array[num3] = groupTypeById[GroupTypeId.Water];
				}
				else if (array[num4] == null)
				{
					dictionary[GroupTypeId.Water].Add(num4);
					array[num4] = groupTypeById[GroupTypeId.Water];
				}
				else if (!array[num3].constraining)
				{
					Debug.Log($"overwriting edge {num3} with water");
					dictionary[GroupTypeId.Water].Add(num3);
					dictionary[array[num3].id].Remove(num3);
					array[num3] = groupTypeById[GroupTypeId.Water];
					CS_0024_003C_003E8__locals20.grassEdges.Add(num3);
				}
				else
				{
					if (array[num4].constraining)
					{
						Debug.Log("both water neighbors are train tracks -> generate water train station");
						return tileGenerator.GenerateDuplicate(waterTrainStation);
					}
					Debug.Log($"overwriting edge {num4} with water");
					dictionary[GroupTypeId.Water].Add(num4);
					dictionary[array[num4].id].Remove(num4);
					array[num4] = groupTypeById[GroupTypeId.Water];
					CS_0024_003C_003E8__locals20.grassEdges.Add(num4);
				}
			}
			CS_0024_003C_003E8__locals20.groupTypesToGenerateFor = new List<GroupTypeId>(dictionary.Keys);
			if (assignRandomTypesToUndefinedEdges && (CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Count > 0 || !assignAlreadyPresentTypesOnly))
			{
				for (int num5 = list2.Count - 1; num5 >= 0; num5--)
				{
					if (!(UnityEngine.Random.value <= emptyEdgeProbability))
					{
						List<GroupTypeProbability> source = randomGroupTypeProbabilities;
						if (assignAlreadyPresentTypesOnly)
						{
							source = Enumerable.ToList(Enumerable.Where(source, (GroupTypeProbability x) => CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Contains(x.groupType)));
						}
						GroupTypeId groupTypeId = Randomizer.SelectWeightedRandom(Enumerable.ToDictionary(source, (GroupTypeProbability x) => x.groupType, (GroupTypeProbability x) => x.probability));
						if (!dictionary.ContainsKey(groupTypeId))
						{
							dictionary.Add(groupTypeId, new List<int>());
						}
						dictionary[groupTypeId].Add(list2[num5]);
						array[list2[num5]] = groupTypeById[groupTypeId];
						if (!CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Contains(groupTypeId))
						{
							CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Add(groupTypeId);
						}
						list2.RemoveAt(num5);
					}
				}
			}
			Enumerable.Select(tileGenerator.Configuration.allSegmentPresets, (SegmentPresetInfo x) => x.segmentType);
			List<int> list4 = new List<int>();
			for (int num6 = CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Count - 1; num6 >= 0; num6--)
			{
				GroupTypeId groupTypeId2 = GroupTypeId.Water;
				if (!CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Contains(GroupTypeId.Water))
				{
					groupTypeId2 = CS_0024_003C_003E8__locals20.groupTypesToGenerateFor[UnityEngine.Random.Range(0, CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Count)];
				}
				List<SegmentFitConstellation> list5 = elementGroupSegmentAdaptor.FittingSegmentConstellations(dictionary[groupTypeId2], list4, groupTypeId2);
				foreach (SegmentFitConstellation item2 in list5)
				{
					item2.groupType = groupTypeId2;
				}
				if (groupTypeId2 == GroupTypeId.Water)
				{
					list5 = Enumerable.ToList(Enumerable.Where(list5, (SegmentFitConstellation x) => x.segments.Count == 1));
				}
				foreach (SegmentFitData segment in list5[UnityEngine.Random.Range(0, list5.Count)].segments)
				{
					SegmentData002 segmentData = new SegmentData002
					{
						groupType = groupTypeId2,
						rotation = segment.rotation,
						segmentType = segment.segmentType.id
					};
					HybridSegmentVariant hybridSegmentVariant = groupTypeById[groupTypeId2].HybridSegmentForSegmentType(segment.segmentType);
					float value = UnityEngine.Random.value;
					if (hybridSegmentVariant != null && hybridSegmentVariant.hybridType != null && (value <= hybridSegmentVariant.hybridProbability || Enumerable.Any(segment.occupiedEdges, (int x) => CS_0024_003C_003E8__locals20.grassEdges.Contains(x))))
					{
						segmentData.segmentType = hybridSegmentVariant.hybridType.id;
					}
					list.Add(segmentData);
					if (segment.occupiedEdges.Count > 1)
					{
						list4.AddRange(segment.occupiedEdges);
					}
				}
				debug_segmentFits.AddRange(list5);
				CS_0024_003C_003E8__locals20.groupTypesToGenerateFor.Remove(groupTypeId2);
			}
			return tileFactory.CreateTile(tileGenerator.GenerateBaseTile(), list);
		}

		public void PreventAdaptiveSegmentsEndingOn(TileSlot targetTileSlot)
		{
			posBlockedForAdaptiveTypes = targetTileSlot.GridPos;
		}
	}
}
