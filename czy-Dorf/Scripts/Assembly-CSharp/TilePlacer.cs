using System;
using Dorfromantik;
using UnityEngine;

public class TilePlacer : MonoBehaviour
{
	[SerializeField]
	private World world;

	[SerializeField]
	private ElementGroupManager elementGroupManager;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private TileAdaptor tileAdaptor;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private TileFactory tileFactory;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private TileGenerator tileGenerator;

	[SerializeField]
	private BiomeManager biomeManager;

	private Tile _003CCurrentTile_003Ek__BackingField;

	private TileSlot _003CCurrentTileSlot_003Ek__BackingField;

	[SerializeField]
	private AudioClipOptions tilePlacementSound;

	[SerializeField]
	private AudioClipOptions tilePreviewSound;

	[SerializeField]
	private AudioClipOptions tileRotateSound;

	public Tile CurrentTile
	{
		get
		{
			return _003CCurrentTile_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentTile_003Ek__BackingField = value;
		}
	}

	public TileSlot CurrentTileSlot
	{
		get
		{
			return _003CCurrentTileSlot_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentTileSlot_003Ek__BackingField = value;
		}
	}

	public event Action<Tile> OnTileDestroyed;

	public event Action<bool> OnTileDiscarded;

	public event Action<Tile> OnNewPreviewTileSet;

	public event Action<int, bool> OnCurrentTileRotated;

	public event Action<TileSlot> OnCurrentTileMoved;

	public event Action OnLastTileSet;

	private void Start()
	{
		inputRouter.OnPlaceTile += PlaceCurrentTile;
		inputRouter.OnDeleteTile += DestroyTile;
		inputRouter.OnMovePreviewTile += ShowPreviewTileAt;
		inputRouter.OnRotatePreviewTile += RotatePreviewTile;
		inputRouter.OnDiscardCurrentTile += DiscardCurrentTile;
		PlaceInitialTiles();
	}

	public void DiscardCurrentTile(bool refillStack, bool initial)
	{
		if ((bool)CurrentTile)
		{
			CurrentTile.HighlightAdjacentGroups(newHighlight: false);
			world.RemoveTile(CurrentTile);
			CurrentTile.DestroyTile();
			CurrentTile = null;
			this.OnTileDiscarded?.Invoke(refillStack);
			if ((bool)CurrentTileSlot)
			{
				ShowPreviewTileAt(CurrentTileSlot);
			}
		}
	}

	public void RemoveCurrentTile()
	{
		if (!(CurrentTile == null))
		{
			CurrentTile.HighlightAdjacentGroups(newHighlight: false);
			world.RemoveTile(CurrentTile);
			CurrentTile.DestroyTile();
			CurrentTile = null;
		}
	}

	private void OnDestroy()
	{
		inputRouter.OnPlaceTile -= PlaceCurrentTile;
		inputRouter.OnDeleteTile -= DestroyTile;
		inputRouter.OnMovePreviewTile -= ShowPreviewTileAt;
		inputRouter.OnRotatePreviewTile -= RotatePreviewTile;
		inputRouter.OnDiscardCurrentTile -= DiscardCurrentTile;
	}

	private void PlaceInitialTiles()
	{
		Tile[] componentsInChildren = GetComponentsInChildren<Tile>();
		foreach (Tile tile in componentsInChildren)
		{
			if (tile.IsInitialTile)
			{
				PlaceTileDirectly(tile, GridCalculator.WorldToGridPos(tile.transform.position));
			}
		}
	}

	public void PlaceTileDirectly(Tile tileToPlaceDirectly, Vector2Int gridPos)
	{
		tileToPlaceDirectly.transform.position = GridCalculator.GridToWorldPos(gridPos);
		tileFactory.InitializePrebuiltTile(tileToPlaceDirectly);
		tileToPlaceDirectly.SetGridPos(gridPos);
		elementGroupManager.CreateGroupsForTile(tileToPlaceDirectly);
		tileToPlaceDirectly.BoardInitialization();
		world.AddTile(tileToPlaceDirectly, potentialBiomeChange: false);
		PlaceTile(tileToPlaceDirectly, gridPos, isPlacedByPlayer: false);
		biomeManager.ApplyBiome(tileToPlaceDirectly);
		SceneOrganizer.Instance.SortInContainer(tileToPlaceDirectly);
	}

	public void RotatePreviewTile(int amount)
	{
		RotatePreviewTile(amount, animate: true);
	}

	public void RotatePreviewTile(int amount, bool animate)
	{
		if (CurrentTile == null)
		{
			return;
		}
		if (amount == 0)
		{
			Debug.LogWarning($"attempting to rotate preview tile by 0, mouse wheel input: {Input.mouseScrollDelta.y}");
			return;
		}
		CurrentTile.HighlightAdjacentGroups(newHighlight: false);
		world.RemoveTile(CurrentTile);
		if (!CurrentTile.TileFitCanChangeOnRotate)
		{
			CurrentTile.Rotate(amount, animate);
		}
		else
		{
			int num = amount / Mathf.Abs(amount);
			CurrentTile.Rotate(num, animate);
			amount += tileAdaptor.RotateTileToFitInSlot(CurrentTile, CurrentTileSlot, num, animate);
		}
		world.AddTile(CurrentTile, potentialBiomeChange: false);
		CurrentTile.HighlightAdjacentGroups(newHighlight: true);
		this.OnCurrentTileRotated?.Invoke(amount, animate);
		rewardSystem.RotateTile(amount);
		AudioManager.Instance.PlaySoundAtPosition(tileRotateSound, CurrentTile.transform.position);
	}

	public void PlaceCurrentTile(TileSlot targetSlot)
	{
		if ((bool)CurrentTile)
		{
			Tile currentTile = CurrentTile;
			currentTile.transform.position = targetSlot.transform.position;
			PlaceTile(currentTile, targetSlot.GridPos);
		}
	}

	private void PlaceTile(Tile newTile, Vector2Int gridPos, bool isPlacedByPlayer = true)
	{
		newTile.PlacementInitialization(gridPos);
		SceneOrganizer.Instance.SortInContainer(newTile);
		newTile.PlacementCompleted();
		if (isPlacedByPlayer)
		{
			rewardSystem.AddTilePlacementScore(newTile);
			AudioManager.Instance.PlaySoundAtPosition(tilePlacementSound, newTile.transform.position);
		}
		tilePlacementEventBroadcaster.BroadcastTilePlacedOnBoard(newTile, isPlacedByPlayer);
		tilePlacementEventBroadcaster.BroadcastTileUndoStored(newTile, isPlacedByPlayer);
		tilePlacementEventBroadcaster.BroadcastTilePlacedQuestProcessed(newTile, isPlacedByPlayer);
		tilePlacementEventBroadcaster.BroadcastTilePlacedFinalized(newTile, isPlacedByPlayer);
	}

	public void DestroyTile(Tile tileToDestroy)
	{
		world.RemoveTile(tileToDestroy);
		this.OnTileDestroyed?.Invoke(tileToDestroy);
		tileToDestroy.DestroyTile(animate: true);
	}

	public void ShowPreviewTileAt(TileSlot targetTileSlot)
	{
		CurrentTileSlot = targetTileSlot;
		if (!CurrentTile)
		{
			return;
		}
		CurrentTile.HighlightAdjacentGroups(newHighlight: false);
		world.RemoveTile(CurrentTile);
		if ((bool)targetTileSlot && targetTileSlot.IsValid && world.GetTile(targetTileSlot.GridPos) == null)
		{
			CurrentTile.transform.position = targetTileSlot.transform.position;
			CurrentTile.gameObject.SetActive(value: true);
			AudioManager.Instance.PlaySoundAtPosition(tilePreviewSound, CurrentTile.transform.position);
			if (CurrentTile.TileFitCanChangeOnRotate)
			{
				int arg = tileAdaptor.RotateTileToFitInSlot(CurrentTile, targetTileSlot);
				this.OnCurrentTileRotated?.Invoke(arg, arg2: true);
			}
			CurrentTile.SetGridPos(targetTileSlot.GridPos);
			world.AddTile(CurrentTile);
			CurrentTile.HighlightAdjacentGroups(newHighlight: true);
		}
		else
		{
			CurrentTile.gameObject.SetActive(value: false);
		}
		this.OnCurrentTileMoved?.Invoke(targetTileSlot);
	}

	public void SetCurrentTile(Tile newCurrentTile)
	{
		if (newCurrentTile == null)
		{
			if (CurrentTile != null)
			{
				CurrentTile.SetIsCurrentTile(newIsCurrentTile: false);
			}
			this.OnLastTileSet?.Invoke();
			CurrentTile = null;
		}
		else
		{
			CurrentTile = tileGenerator.GenerateDuplicate(newCurrentTile);
			CurrentTile.Initialize();
			elementGroupManager.CreateGroupsForTile(CurrentTile);
			CurrentTile.BoardInitialization();
			CurrentTile.SetIsCurrentTile(newIsCurrentTile: true);
			SceneOrganizer.Instance.SortInContainer(CurrentTile);
			this.OnNewPreviewTileSet?.Invoke(CurrentTile);
			questManager.ExpandAndCollapseQuests(newCurrentTile);
		}
	}

	public void UpdateTileSlotValidity()
	{
		if (CurrentTile != null)
		{
			this.OnNewPreviewTileSet?.Invoke(CurrentTile);
		}
	}

	public void RotatePreviewTileTo(int targetRotation, bool animate)
	{
		CurrentTile.HighlightAdjacentGroups(newHighlight: false);
		world.RemoveTile(CurrentTile);
		int num = targetRotation - CurrentTile.RotationIndex;
		CurrentTile.Rotate(num, animate);
		world.AddTile(CurrentTile, potentialBiomeChange: false);
		CurrentTile.HighlightAdjacentGroups(newHighlight: true);
		this.OnCurrentTileRotated?.Invoke(num, animate);
	}
}
