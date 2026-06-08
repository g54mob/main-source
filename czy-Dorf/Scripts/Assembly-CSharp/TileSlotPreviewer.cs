using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dorfromantik;
using Dorfromantik.Area;
using UnityEngine;

public class TileSlotPreviewer : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<TileSlot, bool> _003C_003E9__13_0;

		public static Func<TileSlot, bool> _003C_003E9__15_0;

		public static Func<AreaSlot, bool> _003C_003E9__28_0;

		public static Func<TileSlot, bool> _003C_003E9__37_0;

		internal bool _003Cget_InvalidTileSlots_003Eb__13_0(TileSlot x)
		{
			return !x.IsValid;
		}

		internal bool _003Cget_AllValidTileSlots_003Eb__15_0(TileSlot x)
		{
			return x.IsValid;
		}

		internal bool _003CUpdateEdgeTilesFromPlacedTile_003Eb__28_0(AreaSlot areaSlot)
		{
			return areaSlot.placedTile != null;
		}

		internal bool _003CGetRandomValidTileSlot_003Eb__37_0(TileSlot x)
		{
			return x.IsValid;
		}
	}

	private sealed class _003CDiscardCurrentTileAfterDelay_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TileSlotPreviewer _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CDiscardCurrentTileAfterDelay_003Ed__35(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			TileSlotPreviewer tileSlotPreviewer = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (!tileSlotPreviewer.highlightInvalidTileSlotsEvent.Active)
				{
					tileSlotPreviewer.highlightInvalidTileSlotsEvent.Begin();
				}
				_003C_003E2__current = new WaitForSeconds(0.5f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (tileSlotPreviewer.validTileSlotCount == 0 && OverwritingSingleton<GameSession>.Instance.GameMode.doesTriggerGameOver)
				{
					tileSlotPreviewer.tilePlacer.DiscardCurrentTile(refillStack: false, initial: false);
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private TileSlot tileSlotPrefab;

	[SerializeField]
	private World world;

	[SerializeField]
	private TilePlacer tilePlacer;

	[SerializeField]
	private AreaManager areaManager;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private RewardSystem rewardSystem;

	private Dictionary<Vector2Int, Tile> preplacedTiles = new Dictionary<Vector2Int, Tile>();

	private TutorialEvent_HighlightInvalidTileSlots highlightInvalidTileSlotsEvent;

	private BiomeManager biomeManager;

	private WorldBorder worldBorder;

	private Dictionary<Vector2Int, TileSlot> tileSlots;

	private int validTileSlotCount;

	public List<TileSlot> InvalidTileSlots => Enumerable.ToList(Enumerable.Where(tileSlots.Values, (TileSlot x) => !x.IsValid));

	public List<TileSlot> AllValidTileSlots => Enumerable.ToList(Enumerable.Where(tileSlots.Values, (TileSlot x) => x.IsValid));

	public List<TileSlot> AllTileSlots => Enumerable.ToList(tileSlots.Values);

	private void Awake()
	{
		tileSlots = new Dictionary<Vector2Int, TileSlot>();
		biomeManager = world.GetComponent<BiomeManager>();
		worldBorder = GetComponentInChildren<WorldBorder>();
		highlightInvalidTileSlotsEvent = GetComponentInChildren<TutorialEvent_HighlightInvalidTileSlots>();
		worldBorder.OnBorderSet += UpdateWorldBorder;
	}

	private void UpdateWorldBorder(int obj)
	{
		List<TileSlot> list = new List<TileSlot>();
		foreach (KeyValuePair<Vector2Int, TileSlot> tileSlot in tileSlots)
		{
			if ((bool)worldBorder && !worldBorder.IsWithinBorder(tileSlot.Key))
			{
				list.Add(tileSlot.Value);
			}
		}
		foreach (TileSlot item in list)
		{
			RemoveTileSlot(item.GridPos);
		}
	}

	private void OnEnable()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += UpdateEdgeTilesFromPlacedTile;
		tilePlacer.OnTileDestroyed += UpdateEdgeTilesFromDestroyedTile;
		tilePlacer.OnNewPreviewTileSet += UpdateTileSlotValidity;
		tilePlacer.OnLastTileSet += EnableAllTileSlots;
		inputRouter.OnToolEnabled += SwitchTool;
		OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup += CreateTileSlotAtOriginIfNoTileExists;
		if ((bool)areaManager)
		{
			areaManager.OnPreviewAreaPickedAsPlayable += UpdateEdgeTilesFromPlacedTile;
		}
	}

	private void SwitchTool(ToolId newTool, bool toolIsEnabled)
	{
		if (newTool == ToolId.MatchingTile && toolIsEnabled)
		{
			EnableAllTileSlots();
		}
		else
		{
			UpdateTileSlotValidity(tilePlacer.CurrentTile);
		}
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= UpdateEdgeTilesFromPlacedTile;
		tilePlacer.OnTileDestroyed -= UpdateEdgeTilesFromDestroyedTile;
		tilePlacer.OnNewPreviewTileSet -= UpdateTileSlotValidity;
		tilePlacer.OnLastTileSet -= EnableAllTileSlots;
		inputRouter.OnToolEnabled -= SwitchTool;
		if ((bool)OverwritingSingleton<GameSession>.Instance)
		{
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= CreateTileSlotAtOriginIfNoTileExists;
		}
		if ((bool)areaManager)
		{
			areaManager.OnPreviewAreaPickedAsPlayable -= UpdateEdgeTilesFromPlacedTile;
		}
		if ((bool)worldBorder)
		{
			worldBorder.OnBorderSet -= UpdateWorldBorder;
		}
		tileSlots.Clear();
	}

	private void CreateTileSlotAtOriginIfNoTileExists()
	{
		CreateTileSlotAtGridPosIfNoTileExists(Vector2Int.zero);
	}

	private void CreateTileSlotAtGridPosIfNoTileExists(Vector2Int gridPos)
	{
		if (world.TotalTileCount == 0)
		{
			TileSlot tileSlot = AddTileSlot(gridPos);
			if ((bool)tileSlot)
			{
				tileSlot.SetState(TileSlotState.Valid);
			}
		}
	}

	private void UpdateEdgeTilesFromPlacedTile(Tile newTile, bool advanceStack, bool createTileSlots)
	{
		if (tileSlots.ContainsKey(newTile.GridPos))
		{
			RemoveTileSlot(newTile.GridPos);
		}
		Vector2Int[] array = GridCalculator.NeighborDirections(newTile.GridPos);
		for (int i = 0; i < array.Length; i++)
		{
			Vector2Int vector2Int = newTile.GridPos + array[i];
			if (!tileSlots.ContainsKey(vector2Int))
			{
				if (world.GetTile(newTile.GridPos + array[i]) == null && createTileSlots)
				{
					TileSlot tileSlot = AddTileSlot(vector2Int);
					if ((bool)tileSlot && advanceStack)
					{
						tileSlot.AnimateSpawn(newTile);
					}
				}
			}
			else
			{
				tileSlots[vector2Int].AddNeighbor(newTile, i, preplacedTiles.ContainsKey(newTile.GridPos));
			}
		}
	}

	private void UpdateEdgeTilesFromPlacedTile(Tile newTile, bool advanceStack = true)
	{
		UpdateEdgeTilesFromPlacedTile(newTile, advanceStack, createTileSlots: true);
	}

	private void UpdateEdgeTilesFromPlacedTile(List<AreaSlot> areaSlots)
	{
		foreach (AreaSlot item in Enumerable.Where(areaSlots, (AreaSlot areaSlot) => areaSlot.placedTile != null))
		{
			UpdateEdgeTilesFromPlacedTile(item.placedTile);
		}
	}

	private void UpdateEdgeTilesFromDestroyedTile(Tile destroyedTile)
	{
		if (destroyedTile.ClosedEdgeCount > 0 && !tileSlots.ContainsKey(destroyedTile.GridPos))
		{
			AddTileSlot(destroyedTile.GridPos);
		}
		else
		{
			Debug.Log($"not adding tileSlot ad destroyed tile position because {destroyedTile.ClosedEdgeCount == 0} or {tileSlots.ContainsKey(destroyedTile.GridPos)}");
		}
		UpdateEdgeTilesFromRemovedTile(destroyedTile);
		CreateTileSlotAtGridPosIfNoTileExists(destroyedTile.GridPos);
	}

	private void UpdateEdgeTilesFromRemovedTile(Tile removedTile)
	{
		Vector2Int[] array = GridCalculator.NeighborDirections(removedTile.GridPos);
		for (int i = 0; i < array.Length; i++)
		{
			Vector2Int vector2Int = removedTile.GridPos + array[i];
			if (!tileSlots.ContainsKey(vector2Int))
			{
				continue;
			}
			tileSlots[vector2Int].RemoveNeighbor(removedTile, i);
			if (tileSlots[vector2Int].EmptyNeighborsExcludingPreplacedTiles == 6)
			{
				if (tileSlots[vector2Int] == tilePlacer.CurrentTileSlot)
				{
					tilePlacer.ShowPreviewTileAt(null);
				}
				RemoveTileSlot(vector2Int);
			}
		}
		UpdateTileSlotValidity(tilePlacer.CurrentTile);
	}

	private void RemoveTileSlot(Vector2Int gridPos)
	{
		UnityEngine.Object.Destroy(tileSlots[gridPos].gameObject);
		tileSlots.Remove(gridPos);
	}

	private TileSlot AddTileSlot(Vector2Int gridPos)
	{
		if ((bool)worldBorder && !worldBorder.IsWithinBorder(gridPos))
		{
			return null;
		}
		TileSlot tileSlot = CreateTileSlotAtGridPos(gridPos);
		Vector2Int[] array = GridCalculator.NeighborDirections(gridPos);
		for (int i = 0; i < array.Length; i++)
		{
			Vector2Int vector2Int = gridPos + array[i];
			Tile tile = world.GetTile(vector2Int);
			if (tile != null)
			{
				tileSlot.AddNeighbor(tile, (i + 3) % 6);
			}
			else if (preplacedTiles.ContainsKey(vector2Int))
			{
				tileSlot.AddNeighbor(preplacedTiles[vector2Int], (i + 3) % 6, isPreplacedTile: true);
			}
		}
		return tileSlot;
	}

	private TileSlot CreateTileSlotAtGridPos(Vector2Int gridPos)
	{
		TileSlot tileSlot = UnityEngine.Object.Instantiate(tileSlotPrefab, GridCalculator.GridToWorldPos(gridPos), Quaternion.identity, base.transform);
		tileSlots.Add(gridPos, tileSlot);
		tileSlot.name = $"TileSlot ({gridPos.x}|{gridPos.y})";
		tileSlot.Initialize(gridPos);
		return tileSlot;
	}

	public void UpdateTileSlotValidity(Tile newTile)
	{
		validTileSlotCount = 0;
		if (newTile == null || inputRouter.ActiveTool == ToolId.MatchingTile)
		{
			return;
		}
		foreach (TileSlot value in tileSlots.Values)
		{
			bool flag = TileFitter.TileFitsInSlotAnyRotation(newTile, value);
			value.SetState((!flag) ? TileSlotState.Invalid : TileSlotState.Valid);
			if (flag)
			{
				validTileSlotCount++;
			}
		}
		if (tileSlots.Count == 0 && OverwritingSingleton<GameSession>.Instance.GameMode.doesTriggerGameOver)
		{
			rewardSystem.GameOver(animate: true, setHighscore: true);
		}
		else if (validTileSlotCount == 0 && OverwritingSingleton<GameSession>.Instance.GameMode.doesTriggerGameOver)
		{
			StartCoroutine(DiscardCurrentTileAfterDelay());
		}
		else if (highlightInvalidTileSlotsEvent.Active)
		{
			highlightInvalidTileSlotsEvent.Finish();
		}
	}

	private IEnumerator DiscardCurrentTileAfterDelay()
	{
		return new _003CDiscardCurrentTileAfterDelay_003Ed__35(0)
		{
			_003C_003E4__this = this
		};
	}

	private void EnableAllTileSlots()
	{
		foreach (TileSlot value in tileSlots.Values)
		{
			value.SetState(TileSlotState.Valid);
		}
	}

	public TileSlot GetRandomValidTileSlot()
	{
		List<TileSlot> list = Enumerable.ToList(Enumerable.Where(tileSlots.Values, (TileSlot x) => x.IsValid));
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public void AddPreviewTile(QuestTile previewTile)
	{
		if (preplacedTiles.ContainsKey(previewTile.GridPos))
		{
			Debug.LogError($"tries to add duplicate preplaced tile at {previewTile.GridPos}", previewTile);
			Debug.LogError($"already occupied by {preplacedTiles[previewTile.GridPos]}", preplacedTiles[previewTile.GridPos]);
		}
		else
		{
			preplacedTiles.Add(previewTile.GridPos, previewTile);
		}
		UpdateEdgeTilesFromPlacedTile(previewTile, advanceStack: false, createTileSlots: false);
	}

	public void RemovePreviewTile(QuestTile previewTile)
	{
		if (!previewTile || !preplacedTiles.ContainsKey(previewTile.GridPos))
		{
			return;
		}
		Vector2Int[] array = GridCalculator.NeighborDirections(previewTile.GridPos);
		foreach (Vector2Int vector2Int in array)
		{
			Vector2Int key = previewTile.GridPos + vector2Int;
			if (tileSlots.ContainsKey(key))
			{
				tileSlots[key].RemovePreplacedTileNeighbor();
			}
		}
		preplacedTiles.Remove(previewTile.GridPos);
		if (!world.GetTile(previewTile.GridPos))
		{
			UpdateEdgeTilesFromRemovedTile(previewTile);
		}
	}

	public TileSlot GetTileSlot(Vector2Int gridPos)
	{
		if (!tileSlots.ContainsKey(gridPos))
		{
			return null;
		}
		return tileSlots[gridPos];
	}
}
