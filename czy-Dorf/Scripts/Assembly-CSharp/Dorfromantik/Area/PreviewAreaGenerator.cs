using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.Area
{
	public class PreviewAreaGenerator : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<AreaSlot, AreaSlot> _003C_003E9__12_0;

			public static Func<AreaSlot, List<AreaSlot>> _003C_003E9__12_1;

			public static Func<KeyValuePair<AreaSlot, List<AreaSlot>>, bool> _003C_003E9__12_2;

			public static Func<KeyValuePair<AreaSlot, List<AreaSlot>>, AreaSlot> _003C_003E9__12_3;

			public static Func<AreaSlot, bool> _003C_003E9__13_1;

			public static Func<List<AreaSlot>, int> _003C_003E9__18_0;

			internal AreaSlot _003CSplitEdgeAreaSlotsIntoSegments_003Eb__12_0(AreaSlot areaSlot)
			{
				return areaSlot;
			}

			internal List<AreaSlot> _003CSplitEdgeAreaSlotsIntoSegments_003Eb__12_1(AreaSlot segment)
			{
				return null;
			}

			internal bool _003CSplitEdgeAreaSlotsIntoSegments_003Eb__12_2(KeyValuePair<AreaSlot, List<AreaSlot>> x)
			{
				return x.Value == null;
			}

			internal AreaSlot _003CSplitEdgeAreaSlotsIntoSegments_003Eb__12_3(KeyValuePair<AreaSlot, List<AreaSlot>> pair)
			{
				return pair.Key;
			}

			internal bool _003CCreateNewSegment_003Eb__13_1(AreaSlot x)
			{
				return x != null;
			}

			internal int _003CGetTotalCountOfEdgeAreaSlotsInSegment_003Eb__18_0(List<AreaSlot> segment)
			{
				return segment.Count;
			}
		}

		private sealed class _003C_003Ec__DisplayClass13_0
		{
			public List<AreaSlot> finalEdgeAreaSlotSegment;

			public Predicate<AreaSlot> _003C_003E9__0;

			internal bool _003CCreateNewSegment_003Eb__0(AreaSlot x)
			{
				_003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass13_1();
				CS_0024_003C_003E8__locals2.x = x;
				return Enumerable.Any(finalEdgeAreaSlotSegment, (AreaSlot y) => y == CS_0024_003C_003E8__locals2.x);
			}
		}

		private sealed class _003C_003Ec__DisplayClass13_1
		{
			public AreaSlot x;

			internal bool _003CCreateNewSegment_003Eb__2(AreaSlot y)
			{
				return y == x;
			}
		}

		[SerializeField]
		private AreaSpawnBehavior defaultPreviewSpawnBehavior;

		[SerializeField]
		private AreaManager areaManager;

		[SerializeField]
		private AreaGenerator areaGenerator;

		[SerializeField]
		private AreaSignpost areaSignpostPrefab;

		private AreaSpawnBehavior spawnBehavior;

		private List<AreaSlot> initialEdgeAreaSlots = new List<AreaSlot>();

		private List<AreaSlot> leftoverAreaSlots = new List<AreaSlot>();

		internal Dictionary<List<AreaSlot>, Area> areasBySegment = new Dictionary<List<AreaSlot>, Area>();

		internal Dictionary<Area, AreaSignpost> areasignpostsByArea = new Dictionary<Area, AreaSignpost>();

		internal Dictionary<AreaSlot, List<AreaSlot>> segmentByEdgeAreaSlot = new Dictionary<AreaSlot, List<AreaSlot>>();

		public void Awake()
		{
			if (areaGenerator == null)
			{
				areaGenerator = GetComponent<AreaGenerator>();
			}
			if (areaManager == null)
			{
				areaManager = GetComponent<AreaManager>();
			}
		}

		internal List<Area> CreatePreviewAreas(Area area, AreaSpawnBehavior spawnBehavior = null)
		{
			this.spawnBehavior = ((spawnBehavior == null) ? defaultPreviewSpawnBehavior : spawnBehavior);
			List<List<AreaSlot>> edgeAreaSlotSegments = SplitEdgeAreaSlotsIntoSegments(area);
			areasBySegment = areaGenerator.CreatePreviewAreas(this.spawnBehavior, edgeAreaSlotSegments);
			SetupAreaSignposts();
			return Enumerable.ToList(areasBySegment.Values);
		}

		private List<List<AreaSlot>> SplitEdgeAreaSlotsIntoSegments(Area area, AreaSlot initialEdgeAreaSlot = null)
		{
			segmentByEdgeAreaSlot = Enumerable.ToDictionary(area.EdgeAreaSlots, (AreaSlot areaSlot) => areaSlot, (AreaSlot segment) => (List<AreaSlot>)null);
			initialEdgeAreaSlots.Clear();
			leftoverAreaSlots.Clear();
			List<List<AreaSlot>> list = new List<List<AreaSlot>>();
			int x = spawnBehavior.edgeAreaSlotSegmentCountMinMax.x;
			int y = spawnBehavior.edgeAreaSlotSegmentCountMinMax.y;
			if (initialEdgeAreaSlot == null)
			{
				initialEdgeAreaSlot = area.EdgeAreaSlots[UnityEngine.Random.Range(0, area.EdgeAreaSlots.Count - 1)];
			}
			initialEdgeAreaSlots.Add(initialEdgeAreaSlot);
			int num = 0;
			while (GetTotalCountOfEdgeAreaSlotsInSegment(list) < area.EdgeAreaSlots.Count && num < 100)
			{
				num++;
				int num2 = UnityEngine.Random.Range(x, y);
				int num3 = area.EdgeAreaSlots.Count - GetTotalCountOfEdgeAreaSlotsInSegment(list);
				if (num3 < x)
				{
					List<AreaSlot> edgeAreaSlots = Enumerable.ToList(Enumerable.Select(Enumerable.Where(segmentByEdgeAreaSlot, (KeyValuePair<AreaSlot, List<AreaSlot>> keyValuePair) => keyValuePair.Value == null), (KeyValuePair<AreaSlot, List<AreaSlot>> pair) => pair.Key));
					AddEdgeAreaSlotsToNearestSegment(edgeAreaSlots);
					continue;
				}
				if (num3 < num2)
				{
					num2 = num3;
				}
				List<AreaSlot> list2 = CreateNewSegment(num2);
				if (list2 != null)
				{
					list.Add(list2);
				}
				if (initialEdgeAreaSlots.Count == 0)
				{
					AreaSlot randomAvailableInitialEdgeAreaSlot = GetRandomAvailableInitialEdgeAreaSlot(list);
					if (!(randomAvailableInitialEdgeAreaSlot != null))
					{
						break;
					}
					initialEdgeAreaSlots.Add(randomAvailableInitialEdgeAreaSlot);
				}
			}
			return list;
		}

		private List<AreaSlot> CreateNewSegment(int segmentSize)
		{
			_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass13_0();
			CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment = new List<AreaSlot>();
			List<AreaSlot> list = new List<AreaSlot>(initialEdgeAreaSlots);
			foreach (AreaSlot initialEdgeAreaSlot in initialEdgeAreaSlots)
			{
				List<AreaSlot> collection = new List<AreaSlot> { initialEdgeAreaSlot };
				CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment = new List<AreaSlot>(collection);
				int num = 1;
				while (CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count < segmentSize + 1 && num < 100)
				{
					num++;
					collection = new List<AreaSlot>(CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment);
					foreach (AreaSlot item in collection)
					{
						if (segmentByEdgeAreaSlot[item] != null)
						{
							continue;
						}
						foreach (AreaSlot item2 in Enumerable.Where(Enumerable.ToList(GetAllAvailableEdgeAreaSlotNeighbors(item)), (AreaSlot x) => x != null))
						{
							if (CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count < segmentSize)
							{
								CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Add(item2);
								if (segmentByEdgeAreaSlot.ContainsKey(item))
								{
									segmentByEdgeAreaSlot[item] = CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment;
								}
								if (leftoverAreaSlots.Contains(item2))
								{
									leftoverAreaSlots.Remove(item2);
								}
								if (CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count >= segmentSize)
								{
									break;
								}
							}
							else
							{
								list.Add(item2);
							}
						}
						if (CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count >= segmentSize)
						{
							break;
						}
					}
					if (collection.Count == CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count)
					{
						break;
					}
				}
				if (CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count != segmentSize)
				{
					if (CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count > segmentSize)
					{
						Debug.LogError($"The amount of area slots in this segment ({CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment.Count}) should never be more than the predefined segment size ({segmentSize})!");
					}
					leftoverAreaSlots.AddRange(CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment);
					leftoverAreaSlots = Enumerable.ToList(Enumerable.Distinct(leftoverAreaSlots));
					list.RemoveAll(delegate(AreaSlot x)
					{
						_003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass13_1();
						CS_0024_003C_003E8__locals22.x = x;
						return Enumerable.Any(CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment, (AreaSlot y) => y == CS_0024_003C_003E8__locals22.x);
					});
					CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment = null;
					continue;
				}
				foreach (AreaSlot item3 in CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment)
				{
					segmentByEdgeAreaSlot[item3] = CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment;
					if (list.Contains(item3))
					{
						list.Remove(item3);
					}
				}
			}
			initialEdgeAreaSlots = list;
			return CS_0024_003C_003E8__locals21.finalEdgeAreaSlotSegment;
		}

		private void AddEdgeAreaSlotsToNearestSegment(List<AreaSlot> edgeAreaSlots)
		{
			foreach (AreaSlot edgeAreaSlot in edgeAreaSlots)
			{
				AreaSlot[] allEdgeAreaSlotNeighbors = GetAllEdgeAreaSlotNeighbors(edgeAreaSlot);
				foreach (AreaSlot areaSlot in allEdgeAreaSlotNeighbors)
				{
					if (!(areaSlot == null) && segmentByEdgeAreaSlot[areaSlot] != null)
					{
						segmentByEdgeAreaSlot[edgeAreaSlot] = segmentByEdgeAreaSlot[areaSlot];
						segmentByEdgeAreaSlot[areaSlot].Add(edgeAreaSlot);
					}
				}
			}
		}

		private AreaSlot[] GetAllEdgeAreaSlotNeighbors(AreaSlot areaSlot)
		{
			AreaSlot[] array = new AreaSlot[6];
			areaSlot.NeighborsInLocalArea.CopyTo(array, 0);
			for (int i = 0; i < array.Length; i++)
			{
				if (!(array[i] == null) && (!array[i].IsLocalEdgeAreaSlot || !segmentByEdgeAreaSlot.ContainsKey(array[i])))
				{
					array[i] = null;
				}
			}
			return array;
		}

		private AreaSlot[] GetAllAvailableEdgeAreaSlotNeighbors(AreaSlot areaSlot)
		{
			AreaSlot[] allEdgeAreaSlotNeighbors = GetAllEdgeAreaSlotNeighbors(areaSlot);
			for (int i = 0; i < allEdgeAreaSlotNeighbors.Length; i++)
			{
				if (!(allEdgeAreaSlotNeighbors[i] == null) && (segmentByEdgeAreaSlot[allEdgeAreaSlotNeighbors[i]] != null || leftoverAreaSlots.Contains(allEdgeAreaSlotNeighbors[i])))
				{
					allEdgeAreaSlotNeighbors[i] = null;
				}
			}
			return allEdgeAreaSlotNeighbors;
		}

		private AreaSlot GetRandomAvailableInitialEdgeAreaSlot(List<List<AreaSlot>> segmentOfAreaSlots)
		{
			foreach (KeyValuePair<AreaSlot, List<AreaSlot>> item in segmentByEdgeAreaSlot)
			{
				if (item.Value == null && !leftoverAreaSlots.Contains(item.Key))
				{
					return item.Key;
				}
			}
			return null;
		}

		private int GetTotalCountOfEdgeAreaSlotsInSegment(List<List<AreaSlot>> segmentOfAreaSlots)
		{
			return Enumerable.Sum(segmentOfAreaSlots, (List<AreaSlot> segment) => segment.Count);
		}

		private void SetupAreaSignposts()
		{
			foreach (KeyValuePair<List<AreaSlot>, Area> item in areasBySegment)
			{
				Vector3 position = GridCalculator.GridToWorldPos(item.Key[UnityEngine.Random.Range(0, Enumerable.Count(item.Key))].GridPos);
				AreaSignpost areaSignpost = UnityEngine.Object.Instantiate(areaSignpostPrefab, position, Quaternion.identity);
				areaSignpost.name = "AreaSignpost - " + item.Value.name;
				areaSignpost.Initialize(item.Value, areaManager);
				areaSignpost.GetComponentInChildren<Renderer>().sharedMaterial = item.Value.previewMaterial;
				areasignpostsByArea.Add(item.Value, areaSignpost);
				item.Value.areaSignpost = areaSignpost;
			}
		}

		internal void TerminateAllAreaSignposts()
		{
			AreaSignpost[] array = UnityEngine.Object.FindObjectsOfType<AreaSignpost>();
			if (Enumerable.Any(array))
			{
				AreaSignpost[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Terminate();
				}
				areasignpostsByArea.Clear();
			}
		}
	}
}
