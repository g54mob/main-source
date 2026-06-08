using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.Area
{
	public class AreaGenerator : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<Tile, bool> _003C_003E9__10_0;

			public static Func<KeyValuePair<List<AreaSlot>, Area>, List<AreaSlot>> _003C_003E9__14_1;

			public static Func<KeyValuePair<List<AreaSlot>, Area>, Area> _003C_003E9__14_2;

			internal bool _003CGenerateInitialAreas_003Eb__10_0(Tile x)
			{
				return x.IsInitialTile;
			}

			internal List<AreaSlot> _003CCreatePreviewAreaSlots_003Eb__14_1(KeyValuePair<List<AreaSlot>, Area> item)
			{
				return item.Key;
			}

			internal Area _003CCreatePreviewAreaSlots_003Eb__14_2(KeyValuePair<List<AreaSlot>, Area> item)
			{
				return item.Value;
			}
		}

		private sealed class _003C_003Ec__DisplayClass14_0
		{
			public System.Random random;

			internal int _003CCreatePreviewAreaSlots_003Eb__0(KeyValuePair<List<AreaSlot>, Area> x)
			{
				return random.Next();
			}
		}

		[SerializeField]
		private AreaManager areaManager;

		[SerializeField]
		private AreaSlot areaSlotPrefab;

		[SerializeField]
		private PreviewAreaGenerator previewAreaGenerator;

		[SerializeField]
		private Area areaPrefab;

		[SerializeField]
		private AreaSpawnBehavior defaultAreaSpawnBehavior;

		[SerializeField]
		internal Material defaultAreaSlotMaterial;

		public Area DBG_nextAvailableArea;

		public Area DBG_areaToAdd;

		public List<Area> DBG_toSmallAreas;

		private void Awake()
		{
			if (areaManager == null)
			{
				areaManager = GetComponent<AreaManager>();
			}
			if (previewAreaGenerator == null)
			{
				previewAreaGenerator = GetComponent<PreviewAreaGenerator>();
			}
		}

		internal void GenerateInitialAreas()
		{
			Area globalPlayableArea = SetupArea(defaultAreaSpawnBehavior, AreaType.Playable, AreaScope.Global, "globalPlayableArea");
			Area area = SetupArea(defaultAreaSpawnBehavior, AreaType.Preview, AreaScope.Global, "globalPreviewArea");
			areaManager.InitializeGlobalAreas(globalPlayableArea, area);
			Area area2 = SetupArea(defaultAreaSpawnBehavior, AreaType.Playable, AreaScope.Local, "initialPlayableArea");
			foreach (Tile item in Enumerable.Where(UnityEngine.Object.FindObjectsOfType<Tile>(), (Tile x) => x.IsInitialTile))
			{
				Vector2Int gridPos = GridCalculator.WorldToGridPos(item.transform.position);
				SetupAreaSlot(area2, gridPos, defaultAreaSlotMaterial, isTilePlaced: true);
				area.AddPlacedTile(item);
				area2.AddPlacedTile(item);
			}
			CreateInitialAreaSlots(area2);
		}

		internal Dictionary<List<AreaSlot>, Area> CreatePreviewAreas(AreaSpawnBehavior spawnBehavior, List<List<AreaSlot>> edgeAreaSlotSegments)
		{
			Dictionary<List<AreaSlot>, Area> dictionary = new Dictionary<List<AreaSlot>, Area>();
			for (int i = 0; i < edgeAreaSlotSegments.Count; i++)
			{
				List<AreaSlot> key = edgeAreaSlotSegments[i];
				string gameObjectName = string.Format("{0} {1} {2} #{3}", AreaScope.Local, AreaType.Preview, "Area", i);
				Material material = new Material(defaultAreaSlotMaterial);
				Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.65f, 0.85f, 0.7f, 0.9f, 0.45f, 0.55f);
				material.color = color;
				Area value = SetupArea(spawnBehavior, AreaType.Preview, AreaScope.Local, gameObjectName, material);
				dictionary.Add(key, value);
			}
			CreatePreviewAreaSlots(dictionary, spawnBehavior);
			return dictionary;
		}

		private Area SetupArea(AreaSpawnBehavior spawnBehavior, AreaType areaType, AreaScope areaScope, string gameObjectName = null, Material previewMaterial = null)
		{
			if (previewMaterial == null)
			{
				previewMaterial = defaultAreaSlotMaterial;
			}
			Area area = UnityEngine.Object.Instantiate(areaPrefab, Vector3.zero, Quaternion.identity);
			int areaSlotCapacity = UnityEngine.Random.Range(spawnBehavior.tilesCountMinMax.x, spawnBehavior.tilesCountMinMax.y);
			area.Initialize(areaSlotCapacity, areaType, areaScope, spawnBehavior, previewMaterial, gameObjectName);
			SceneOrganizer.Instance.SortInContainer(area);
			areaManager.RememberLocalArea(area);
			return area;
		}

		private void CreateInitialAreaSlots(Area area)
		{
			for (int i = 0; i < area.SpawnBehavior.totalSpawnIterations; i++)
			{
				List<AreaSlot> placedEdgeAreaSlots = new List<AreaSlot>(area.EdgeAreaSlots);
				if (TrySpawnAreaSlotsAroundPlacedOnes(placedEdgeAreaSlots, area) && area.AreaSlots.Count >= area.AreaSlotCapacity)
				{
					break;
				}
			}
		}

		private void CreatePreviewAreaSlots(Dictionary<List<AreaSlot>, Area> areasBySegment, AreaSpawnBehavior spawnBehavior)
		{
			for (int i = 0; i < spawnBehavior.totalSpawnIterations; i++)
			{
				_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass14_0();
				List<List<AreaSlot>> list = Enumerable.ToList(areasBySegment.Keys);
				for (int num = list.Count - 1; num >= 0; num--)
				{
					Area area = areasBySegment[list[num]];
					List<AreaSlot> list2 = list[num];
					List<AreaSlot> placedEdgeAreaSlots = list2;
					if (i > 0)
					{
						placedEdgeAreaSlots = new List<AreaSlot>(area.EdgeAreaSlots);
					}
					if (!TrySpawnAreaSlotsAroundPlacedOnes(placedEdgeAreaSlots, area) && area.AreaSlots.Count < area.AreaSlotCapacity)
					{
						AddPreviewAreaToNextPreviewArea(area);
						areasBySegment.Remove(list2);
					}
				}
				CS_0024_003C_003E8__locals2.random = new System.Random();
				areasBySegment = Enumerable.ToDictionary(Enumerable.OrderBy(areasBySegment, (KeyValuePair<List<AreaSlot>, Area> x) => CS_0024_003C_003E8__locals2.random.Next()), (KeyValuePair<List<AreaSlot>, Area> item) => item.Key, (KeyValuePair<List<AreaSlot>, Area> item) => item.Value);
			}
		}

		private void AddPreviewAreaToNextPreviewArea(Area areaToAdd)
		{
			Debug.LogWarning(">>> TO SMALL:  " + areaToAdd.name + "! (try adding it to next preview area)");
			if (areaToAdd.Type != AreaType.Preview)
			{
				return;
			}
			Area area = null;
			foreach (AreaSlot edgeAreaSlot in areaToAdd.EdgeAreaSlots)
			{
				if (area != null)
				{
					break;
				}
				AreaSlot[] allNeighborAreaSlots = areaManager.GetAllNeighborAreaSlots(edgeAreaSlot);
				foreach (AreaSlot areaSlot in allNeighborAreaSlots)
				{
					if (areaSlot != null && areaSlot.LocalArea != null && areaSlot.LocalArea != areaToAdd && areaSlot.LocalArea.Type == AreaType.Preview)
					{
						Debug.LogWarning($">>> NEXT PREVIEW AREA FOUND! Will add {areaToAdd.name} to {areaSlot.LocalArea}");
						area = areaSlot.LocalArea;
						break;
					}
				}
				if (area != null)
				{
					break;
				}
			}
			DBG_nextAvailableArea = area;
			DBG_areaToAdd = areaToAdd;
			DBG_toSmallAreas.Add(areaToAdd);
			if (area != null)
			{
				areaToAdd.name += "_toSmall";
				foreach (AreaSlot areaSlot2 in areaToAdd.AreaSlots)
				{
					if (areaSlot2.Type != AreaType.Playable)
					{
						areaSlot2.GetComponentInChildren<Renderer>().sharedMaterial = area.previewMaterial;
						areaSlot2.LocalArea = area;
						area.AddAreaSlot(areaSlot2);
						areaToAdd.RemoveEdgeAreaSlot(areaSlot2);
						if (areaSlot2.IsLocalEdgeAreaSlot)
						{
							AreaSlot[] allNeighborAreaSlots2 = areaManager.GetAllNeighborAreaSlots(areaSlot2);
							areaSlot2.UpdateNeighborList(allNeighborAreaSlots2);
						}
					}
				}
				areaManager.ForgetLocalArea(areaToAdd);
				areaToAdd.Terminate(shouldDestroyAreaSlots: false, shouldDestroyAreaSignpost: true);
			}
			else
			{
				Debug.LogError("No available preview area was found to which the " + areaToAdd.name + " could have been added to! \n" + $"containing areaslots ({areaToAdd.AreaSlots.Count}): {ListHelper.ListDebugString(areaToAdd.AreaSlots)}");
			}
		}

		private bool TrySpawnAreaSlotsAroundPlacedOnes(List<AreaSlot> placedEdgeAreaSlots, Area localAreaToPopulate)
		{
			bool result = false;
			foreach (AreaSlot placedEdgeAreaSlot in placedEdgeAreaSlots)
			{
				AreaSlot[] allNeighborAreaSlots = areaManager.GetAllNeighborAreaSlots(placedEdgeAreaSlot);
				for (int i = 0; i < allNeighborAreaSlots.Length; i++)
				{
					if (allNeighborAreaSlots[i] != null)
					{
						continue;
					}
					Vector2Int? neighborGridPositionFromIndex = GridCalculator.GetNeighborGridPositionFromIndex(placedEdgeAreaSlot.GridPos, i);
					if (neighborGridPositionFromIndex.HasValue)
					{
						AreaSlot areaSlot = SetupAreaSlot(localAreaToPopulate, neighborGridPositionFromIndex.Value);
						result = true;
						if (areaSlot.LocalArea.AreaSlots.Count >= areaSlot.LocalArea.AreaSlotCapacity)
						{
							return true;
						}
					}
				}
			}
			return result;
		}

		private AreaSlot SetupAreaSlot(Area localArea, Vector2Int gridPos, Material material = null, bool isTilePlaced = false)
		{
			Vector3 position = GridCalculator.GridToWorldPos(gridPos);
			AreaSlot areaSlot = UnityEngine.Object.Instantiate(areaSlotPrefab, position, Quaternion.identity);
			areaSlot.name = $"AreaSlot {areaSlot.GridPos}";
			SceneOrganizer.Instance.SortInContainer(areaSlot);
			Area area = null;
			switch (localArea.Type)
			{
			case AreaType.Playable:
				area = areaManager.GlobalPlayableArea;
				areaManager.GlobalPlayableArea.AddAreaSlot(areaSlot);
				break;
			case AreaType.Preview:
				area = areaManager.GlobalPreviewArea;
				areaManager.GlobalPreviewArea.AddAreaSlot(areaSlot);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			areaSlot.InitializeAreaSlot(localArea, areaManager.GetAllNeighborAreaSlots(areaSlot), area, isTilePlaced);
			if (material == null)
			{
				material = areaSlot.LocalArea.previewMaterial;
			}
			areaSlot.GetComponentInChildren<Renderer>().sharedMaterial = material;
			return areaSlot;
		}
	}
}
