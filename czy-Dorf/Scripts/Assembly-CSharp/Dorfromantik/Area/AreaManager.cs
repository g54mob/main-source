using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.Area
{
	public class AreaManager : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<List<AreaSlot>, bool> _003C_003E9__26_0;

			public static Func<AreaSlot, bool> _003C_003E9__26_1;

			internal bool _003CClearPreviewAreas_003Eb__26_0(List<AreaSlot> x)
			{
				return x != null;
			}

			internal bool _003CClearPreviewAreas_003Eb__26_1(AreaSlot x)
			{
				return x != null;
			}
		}

		private sealed class _003C_003Ec__DisplayClass31_0
		{
			public Area area;

			internal bool _003CPickPreviewAreaAsPlayable_003Eb__0(KeyValuePair<List<AreaSlot>, Area> x)
			{
				return x.Value == area;
			}
		}

		[SerializeField]
		private AreaGenerator areaGenerator;

		[SerializeField]
		private PreviewAreaGenerator previewAreaGenerator;

		[SerializeField]
		private List<Area> localPlayableAreas;

		[SerializeField]
		private List<Area> localPreviewAreas;

		private Material defaultAreaSlotMaterial;

		private Area _003CGlobalPlayableArea_003Ek__BackingField;

		private Area _003CGlobalPreviewArea_003Ek__BackingField;

		[SerializeField]
		private List<AreaSlot> segmentOfAreaSlots;

		internal Area GlobalPlayableArea
		{
			get
			{
				return _003CGlobalPlayableArea_003Ek__BackingField;
			}
			private set
			{
				_003CGlobalPlayableArea_003Ek__BackingField = value;
			}
		}

		internal Area GlobalPreviewArea
		{
			get
			{
				return _003CGlobalPreviewArea_003Ek__BackingField;
			}
			private set
			{
				_003CGlobalPreviewArea_003Ek__BackingField = value;
			}
		}

		internal List<Area> LocalPlayableAreas
		{
			get
			{
				return localPlayableAreas;
			}
			private set
			{
				localPlayableAreas = value;
			}
		}

		internal List<Area> LocalPreviewAreas
		{
			get
			{
				return localPreviewAreas;
			}
			private set
			{
				localPreviewAreas = value;
			}
		}

		public event Action<List<AreaSlot>> OnPreviewAreaPickedAsPlayable;

		private void Awake()
		{
			localPlayableAreas = new List<Area>();
			localPreviewAreas = new List<Area>();
			if (areaGenerator == null)
			{
				areaGenerator = GetComponent<AreaGenerator>();
			}
			if (previewAreaGenerator == null)
			{
				previewAreaGenerator = GetComponent<PreviewAreaGenerator>();
			}
		}

		internal AreaSlot GetAreaSlotFromGridPos(Vector2Int gridPos, AreaType areaType = AreaType.Playable, Area area = null)
		{
			Area area2 = area;
			if (area2 == null)
			{
				area2 = GlobalPlayableArea;
				if (areaType == AreaType.Preview)
				{
					area2 = GlobalPreviewArea;
				}
			}
			foreach (AreaSlot areaSlot in area2.AreaSlots)
			{
				if (areaSlot.GridPos == gridPos)
				{
					return areaSlot;
				}
			}
			return null;
		}

		internal void PlaceTileOnArea(Tile tile)
		{
			AreaSlot areaSlotFromGridPos = GetAreaSlotFromGridPos(tile.GridPos);
			areaSlotFromGridPos.placedTile = tile;
			areaSlotFromGridPos.LocalArea.AddPlacedTile(tile);
			if (areaSlotFromGridPos.LocalArea.Type == AreaType.Playable)
			{
				GlobalPlayableArea.AddPlacedTile(tile);
			}
		}

		internal void CreatePreviewAreas(Area completedArea)
		{
			if (completedArea != null)
			{
				completedArea.OnAreaCompletion -= CreatePreviewAreas;
			}
			ClearPreviewAreas();
			previewAreaGenerator.CreatePreviewAreas(GlobalPlayableArea);
			GlobalPlayableArea.ClearOutline();
			RedrawAreaOutlines();
		}

		private void ClearPreviewAreas()
		{
			List<Area> list = new List<Area>(LocalPreviewAreas);
			if (!Enumerable.Any(list))
			{
				return;
			}
			foreach (List<AreaSlot> item in Enumerable.Where(previewAreaGenerator.segmentByEdgeAreaSlot.Values, (List<AreaSlot> x) => x != null))
			{
				foreach (AreaSlot item2 in Enumerable.Where(item, (AreaSlot x) => x != null))
				{
					item2.GetComponentInChildren<Renderer>().sharedMaterial = areaGenerator.defaultAreaSlotMaterial;
				}
			}
			foreach (Area item3 in list)
			{
				item3.ClearOutline();
				LocalPreviewAreas.Remove(item3);
				item3.Terminate(shouldDestroyAreaSlots: true, shouldDestroyAreaSignpost: true);
			}
			previewAreaGenerator.TerminateAllAreaSignposts();
			GlobalPreviewArea.AreaSlots.Clear();
			GlobalPreviewArea.EdgeAreaSlots.Clear();
			LocalPreviewAreas.Clear();
		}

		internal void RememberLocalArea(Area areaToRemember)
		{
			if (areaToRemember.Scope == AreaScope.Local)
			{
				switch (areaToRemember.Type)
				{
				case AreaType.Playable:
					AddAreaToList(areaToRemember, ref localPlayableAreas);
					areaToRemember.OnAreaCompletion += CreatePreviewAreas;
					break;
				case AreaType.Preview:
					AddAreaToList(areaToRemember, ref localPreviewAreas);
					break;
				}
			}
		}

		internal void ForgetLocalArea(Area areaToForget)
		{
			if (areaToForget.Scope == AreaScope.Local)
			{
				switch (areaToForget.Type)
				{
				case AreaType.Playable:
					RemoveAreaFromList(areaToForget, ref localPlayableAreas);
					areaToForget.OnAreaCompletion -= CreatePreviewAreas;
					break;
				case AreaType.Preview:
					RemoveAreaFromList(areaToForget, ref localPreviewAreas);
					break;
				}
			}
		}

		internal void SetupInitialAreas()
		{
			areaGenerator.GenerateInitialAreas();
			RedrawAreaOutlines();
		}

		internal void InitializeGlobalAreas(Area globalPlayableArea, Area globalPreviewArea)
		{
			GlobalPlayableArea = globalPlayableArea;
			GlobalPreviewArea = globalPreviewArea;
		}

		internal void PickPreviewAreaAsPlayable(Area area)
		{
			_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass31_0();
			CS_0024_003C_003E8__locals12.area = area;
			if (CS_0024_003C_003E8__locals12.area.Type == AreaType.Playable)
			{
				return;
			}
			ForgetLocalArea(CS_0024_003C_003E8__locals12.area);
			CS_0024_003C_003E8__locals12.area.Type = AreaType.Playable;
			RememberLocalArea(CS_0024_003C_003E8__locals12.area);
			CS_0024_003C_003E8__locals12.area.name = string.Format("{0} {1} {2} #{3}", CS_0024_003C_003E8__locals12.area.Scope, CS_0024_003C_003E8__locals12.area.Type, "Area", LocalPlayableAreas.Count);
			foreach (AreaSlot areaSlot in CS_0024_003C_003E8__locals12.area.AreaSlots)
			{
				if (areaSlot.Type != AreaType.Playable)
				{
					areaSlot.Type = AreaType.Playable;
					areaSlot.IsTilePlacable = true;
					areaSlot.globalArea = GlobalPlayableArea;
					areaSlot.GetComponentInChildren<Renderer>().sharedMaterial = areaGenerator.defaultAreaSlotMaterial;
					if (!GlobalPlayableArea.AreaSlots.Contains(areaSlot))
					{
						GlobalPlayableArea.AddAreaSlot(areaSlot);
					}
				}
			}
			segmentOfAreaSlots = Enumerable.FirstOrDefault(previewAreaGenerator.areasBySegment, (KeyValuePair<List<AreaSlot>, Area> x) => x.Value == CS_0024_003C_003E8__locals12.area).Key;
			this.OnPreviewAreaPickedAsPlayable?.Invoke(segmentOfAreaSlots);
			ClearPreviewAreas();
			foreach (AreaSlot edgeAreaSlot in CS_0024_003C_003E8__locals12.area.EdgeAreaSlots)
			{
				AreaSlot[] allNeighborAreaSlots = GetAllNeighborAreaSlots(edgeAreaSlot);
				edgeAreaSlot.UpdateNeighborList(allNeighborAreaSlots);
			}
			CS_0024_003C_003E8__locals12.area.ClearOutline();
			RedrawAreaOutlines();
		}

		internal AreaSlot[] GetAllNeighborAreaSlots(AreaSlot areaSlot)
		{
			AreaSlot[] array = new AreaSlot[6];
			Vector2Int[] array2 = GridCalculator.NeighborDirections(areaSlot.GridPos);
			for (int i = 0; i < 6; i++)
			{
				Vector2Int gridPos = areaSlot.GridPos + array2[i];
				AreaSlot areaSlotFromGridPos = GetAreaSlotFromGridPos(gridPos);
				if (areaSlotFromGridPos == null)
				{
					areaSlotFromGridPos = GetAreaSlotFromGridPos(gridPos, AreaType.Preview);
				}
				array[i] = areaSlotFromGridPos;
			}
			return array;
		}

		private void AddAreaToList(Area area, ref List<Area> list)
		{
			if (!list.Contains(area))
			{
				list.Add(area);
			}
			else
			{
				Debug.LogError($"The area ({area} - {area.Type}) is already added to {list}!");
			}
		}

		private void RemoveAreaFromList(Area area, ref List<Area> list)
		{
			if (list.Contains(area))
			{
				list.Remove(area);
			}
			else
			{
				Debug.LogError($"{list} does not contain the area ({area} - {area.Type}), which it is trying to remove!");
			}
		}

		private void RedrawAreaOutlines()
		{
			GlobalPlayableArea.ClearOutline();
			if (Enumerable.Any(LocalPreviewAreas))
			{
				foreach (Area localPreviewArea in LocalPreviewAreas)
				{
					localPreviewArea.DrawOutline();
				}
				return;
			}
			GlobalPlayableArea.DrawOutline();
		}
	}
}
