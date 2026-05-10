using System;
using CTS;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ConstructionSystem : MonoSingleton<ConstructionSystem>
{
	[SerializeField]
	private LayerMask _constructableZoneLayer;

	[SerializeField]
	private LayerMask _wallLayer;

	[SerializeField]
	private LayerMask _floorLayer;

	[SerializeField]
	private LayerMask _buildableLayer;

	[SerializeField]
	private Transform _parentWalls;

	[SerializeField]
	private InputActionReference _buyAction;

	[SerializeField]
	private InputActionReference _clickRight;

	[SerializeField]
	private InputActionReference _clickLeft;

	[SerializeField]
	[BoxGroup("Cursors")]
	private CursorSO _destroyCursor;

	[SerializeField]
	[BoxGroup("Cursors")]
	private CursorSO _trowelAddCursor;

	[SerializeField]
	[BoxGroup("Cursors")]
	private CursorSO _trowelNewCursor;

	[SerializeField]
	[BoxGroup("Cursors")]
	private CursorSO _trowelRemoveCursor;

	private ConstructionCell _beginSelectionPosition;

	private ConstructionCell _endSelectionPosition;

	private BuyingData _cellBuyingValues;

	private static readonly StringKey _cursorKey = "ConstructionCursor";

	[ShowNonSerializedField]
	private ESelectionMode _currentSelectionMode;

	[ShowNonSerializedField]
	private EConstructionMode _currentMode;

	public ConstructionGrid CurrentGrid;

	[HideInInspector]
	public int CurrentWallToCreateCount;

	public ConstructionGrid[] Grids => ConstructionGrid.CurrentGrids.ToArray();

	public ConstrutionPriceSO ConstrutionPriceSO { get; private set; }

	[field: ShowNonSerializedField]
	public ECursorConstructionMode CursorConstructionMode { get; private set; }

	public EConstructionMode CurrentMode
	{
		get
		{
			return _currentMode;
		}
		set
		{
			_currentMode = value;
			ClearCurrentBuilded();
			switch (_currentMode)
			{
			case EConstructionMode.Construction:
				_endSelectionPosition = null;
				_beginSelectionPosition = null;
				break;
			case EConstructionMode.Destruction:
				_endSelectionPosition = null;
				_beginSelectionPosition = null;
				break;
			}
			ConstructionSystem.OnConstructionModeChanged?.Invoke();
		}
	}

	public Transform GetParentWall => _parentWalls;

	public int GetTotalPrestige => GetTotalSuperficy * ConstrutionPriceSO.SuperficyPrestige;

	public int GetTotalSuperficy
	{
		get
		{
			int num = 0;
			for (int i = 0; i < Grids.Length; i++)
			{
				num += Grids[i].GetTotalSuperficy;
			}
			return num;
		}
	}

	public int GetTotalInteriorCells
	{
		get
		{
			int num = 0;
			ConstructionGrid[] grids = Grids;
			foreach (ConstructionGrid constructionGrid in grids)
			{
				num += constructionGrid.GetTotalInteriorCells;
			}
			return num;
		}
	}

	public float GetTotalStyleValue
	{
		get
		{
			float num = 0f;
			ConstructionGrid[] grids = Grids;
			foreach (ConstructionGrid constructionGrid in grids)
			{
				num += constructionGrid.GetTotalStyleValue;
			}
			return num;
		}
	}

	public float GetTotalStylePrestige
	{
		get
		{
			float num = 0f;
			ConstructionGrid[] grids = Grids;
			foreach (ConstructionGrid constructionGrid in grids)
			{
				num += constructionGrid.GetTotalStylePrestige;
			}
			return num;
		}
	}

	[field: ShowNonSerializedField]
	public int CurrentCellConstructionIndex { get; private set; } = 1;

	public ConstructionCell SelectedCell { get; private set; }

	public static event Action<BuyingData, BuyingData> OnBuyingDataChanged;

	public static event Action BuyGeneratedCells;

	public static event Action<EConstructionMode> CellsBought;

	public static event Action<int> OnPrestigeChanged;

	public static event Action OnConstructionModeChanged;

	public static event Action<bool, RoomBuilding> OnSelectedRoomForRoomDestroyChanged;

	public static event Action<RoomBuilding, RoomBuilding> OnSelectedWallForRoomDestroyChanged;

	public static event Action<int, int, int> OnConstructionGenerated;

	protected override void SingletonAwake()
	{
		UI_ConstructionSystem.OnOpenBuildMode += OnOpenBuildMode;
		UI_ConstructionSystem.OnCloseBuildMode += OnCloseBuildMode;
		AbsMoneyHandlerBridge.MoneyAmountChanged += UpdateBuyableState;
		UI_DestructionMode.OnDestructionModeChanged += ClearCurrentBuilded;
		ConstrutionPriceSO = Addressables.LoadAssetAsync<ConstrutionPriceSO>("Assets/Scriptables/Buildables/ConstrutionPrice.asset").WaitForCompletion();
		if (ConstrutionPriceSO == null)
		{
			Debug.LogError("ConstrutionPriceSO Not Imported!");
		}
		_clickLeft.action.started += LeftStarted;
		_clickLeft.action.canceled += LeftFinish;
		_clickRight.action.started += RightStarted;
		_clickRight.action.canceled += RightPerfomd;
		RoomSelection.RoomSelected += RoomSelection_RoomSelected;
	}

	private void RightPerfomd(InputAction.CallbackContext obj)
	{
		OnRightClick(pressed: false);
	}

	private void RightStarted(InputAction.CallbackContext obj)
	{
		OnRightClick(pressed: true);
	}

	private void LeftFinish(InputAction.CallbackContext obj)
	{
		OnLeftClick(pressed: false);
	}

	private void LeftStarted(InputAction.CallbackContext obj)
	{
		OnLeftClick(pressed: true);
	}

	protected override void OnSingletonDestroy()
	{
		UI_ConstructionSystem.OnOpenBuildMode -= OnOpenBuildMode;
		UI_ConstructionSystem.OnCloseBuildMode -= OnCloseBuildMode;
		AbsMoneyHandlerBridge.MoneyAmountChanged -= UpdateBuyableState;
		UI_DestructionMode.OnDestructionModeChanged -= ClearCurrentBuilded;
		SetCursorVisual(null);
		OnCloseBuildMode();
		_clickLeft.action.started -= LeftStarted;
		_clickLeft.action.performed -= LeftFinish;
		_clickRight.action.started -= RightStarted;
		_clickRight.action.performed -= RightPerfomd;
		RoomSelection.RoomSelected -= RoomSelection_RoomSelected;
	}

	private void Update()
	{
		if (CurrentGrid == null || !CurrentGrid.ConstructionGridIsReady)
		{
			return;
		}
		if (MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable != null && MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable.BuildableType != BuildableElementSO.EBuildableType.Room)
		{
			MonoSingleton<BuildablePlacementSystem>.Instance.UpdateBuildableConstruction();
			return;
		}
		if (MonoSingleton<UI_PaintPanel>.Instance.CurrentSelectedSurface != null)
		{
			UpdatePaintMode();
		}
		else
		{
			UpdateBuild();
		}
		CreateBuyData();
	}

	private void RoomSelection_RoomSelected(RoomBuilding arg1, bool arg2)
	{
		if (CurrentMode == EConstructionMode.Destruction && MonoSingleton<UI_DestructionMode>.InstanceExists() && MonoSingleton<UI_DestructionMode>.Instance.CurrentMode == ESelectedDestructionMode.PerRoom)
		{
			ConstructionSystem.OnSelectedRoomForRoomDestroyChanged?.Invoke(arg2, arg1);
		}
	}

	private void UpdateBuyableState(int money)
	{
	}

	private void OnReleaseLeftClick()
	{
		SetCursorVisual(null);
		if (CurrentMode != EConstructionMode.None && !(CurrentGrid == null))
		{
			int interiorCreated;
			int arg = CurrentGrid.Generate(CurrentMode, out interiorCreated, refreshAll: false);
			if (interiorCreated != 0)
			{
				ConstructionSystem.BuyGeneratedCells?.Invoke();
				ConstructionSystem.CellsBought?.Invoke(CurrentMode);
				ConstructionSystem.OnPrestigeChanged?.Invoke(GetTotalPrestige);
				ConstructionSystem.OnConstructionGenerated?.Invoke(CurrentCellConstructionIndex, arg, interiorCreated);
			}
			ConstructionFeedback.ClearList();
		}
	}

	private void OnCloseBuildMode()
	{
		ClearCurrentBuilded();
		SetCursorVisual(null);
		CurrentGrid = null;
	}

	private void OnOpenBuildMode()
	{
		CurrentGrid = Grids[MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentStage];
	}

	public void OnCloseBuildModeFromEditor()
	{
		ClearCurrentBuilded();
		CurrentGrid?.SetActiveFromMapEditor(active: false);
		CurrentMode = EConstructionMode.None;
		CurrentGrid = null;
	}

	private void ClearCurrentBuilded()
	{
		MonoSingleton<BuildablePlacementSystem>.Instance.enabled = false;
		_cellBuyingValues.FloorsToBuild = 0;
		_cellBuyingValues.FloorsToDestroy = 0;
		_cellBuyingValues.WallsToBuild = 0;
		_cellBuyingValues.WallsToDestroy = 0;
		CurrentGrid?.SetWallToDestroy(null, out var _, out var _);
		CurrentGrid?.ClearTempZones();
		CurrentGrid?.GenerateFloorAndWallFromSelection();
		MonoSingleton<SurfaceObjectPaintingSystem>.Instance.ClearBuyPaint();
		ConstructionFeedback.ClearList();
		_beginSelectionPosition = null;
		_endSelectionPosition = null;
		SelectedCell = null;
	}

	private void OnRightClick(bool pressed)
	{
		if (pressed)
		{
			ClearCurrentBuilded();
		}
	}

	private void UpdatePaintMode()
	{
		MonoSingleton<SurfaceObjectPaintingSystem>.Instance.ClearBuyPaint();
		if (EventSystem.current.IsPointerOverGameObject())
		{
			MonoSingleton<SurfaceObjectPaintingSystem>.Instance.RefreshCostVisual();
			return;
		}
		bool flag = true;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100f, (MonoSingleton<SurfaceObjectPaintingSystem>.Instance.CurrentPaintingSurfaceType == ESurfaceType.Wall) ? _wallLayer : _floorLayer))
		{
			BuildingFloor component3;
			if (hitInfo.collider.TryGetComponent<BuildingWall>(out var component) && component.LinkedRoom.RoomIndex != 0)
			{
				if (MonoSingleton<UI_PaintPanel>.Instance.CurrentSurfacePaintingMode == ESurfacePaintingMode.OneSurface)
				{
					component.AppliqMaterial();
				}
				else if (MonoSingleton<UI_PaintPanel>.Instance.CurrentSurfacePaintingMode == ESurfacePaintingMode.Room)
				{
					RoomBuilding linkedRoom = component.LinkedRoom;
					for (int i = 0; i < linkedRoom.WallsContainer.childCount; i++)
					{
						if (linkedRoom.WallsContainer.GetChild(i).TryGetComponent<BuildingWall>(out var component2))
						{
							component2.AppliqMaterial();
						}
					}
				}
			}
			else if (hitInfo.collider.TryGetComponent<BuildingFloor>(out component3) && component3.LinkedRoom.RoomIndex != 0)
			{
				if (MonoSingleton<UI_PaintPanel>.Instance.CurrentSurfacePaintingMode == ESurfacePaintingMode.OneSurface)
				{
					component3.AppliqMaterial();
				}
				else
				{
					RoomBuilding linkedRoom2 = component3.LinkedRoom;
					for (int j = 0; j < linkedRoom2.FloorContainer.childCount; j++)
					{
						if (linkedRoom2.FloorContainer.GetChild(j).TryGetComponent<BuildingFloor>(out var component4))
						{
							component4.AppliqMaterial();
						}
					}
				}
			}
			flag = MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetCurrentMoney() >= MonoSingleton<SurfaceObjectPaintingSystem>.Instance.CurrentCost;
			if (flag && _buyAction.action.IsPressed())
			{
				MonoSingleton<SurfaceObjectPaintingSystem>.Instance.ConfirmBuyPaint();
			}
		}
		if (!flag)
		{
			ConstructionFeedback.AddToList(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.NotEnoughtMoney
			});
		}
		MonoSingleton<SurfaceObjectPaintingSystem>.Instance.RefreshCostVisual();
	}

	private void OnLeftClick(bool pressed)
	{
		SetCurrentMode(pressed, leftClick: true);
	}

	private void SetCurrentMode(bool pressed, bool leftClick)
	{
		if (!leftClick)
		{
			return;
		}
		if (pressed)
		{
			if (!WorldSelector.PointerIsOverUI)
			{
				_beginSelectionPosition = null;
				_endSelectionPosition = null;
				SelectedCell = null;
				_currentSelectionMode = ESelectionMode.Select;
				_currentSelectionMode = ESelectionMode.Select;
			}
		}
		else
		{
			_beginSelectionPosition = null;
			_endSelectionPosition = null;
			SelectedCell = null;
			OnReleaseLeftClick();
			_currentSelectionMode = ESelectionMode.None;
		}
	}

	private CursorSO ApplyCursor(ConstructionCell cell)
	{
		if (cell != null && CurrentMode == EConstructionMode.Construction)
		{
			if (cell.InteriorState != ConstructionCell.EInteriorState.None)
			{
				CursorConstructionMode = ECursorConstructionMode.Extension;
				return _trowelAddCursor;
			}
			CursorConstructionMode = ECursorConstructionMode.NewBuild;
			return _trowelNewCursor;
		}
		if (cell != null && CurrentMode == EConstructionMode.Destruction && cell.InteriorState != ConstructionCell.EInteriorState.None)
		{
			CursorConstructionMode = ECursorConstructionMode.Remove;
			return _trowelRemoveCursor;
		}
		CursorConstructionMode = ECursorConstructionMode.None;
		return null;
	}

	private void SetCursorVisual(ConstructionCell cell, bool isbuildable = false)
	{
		if (!MonoSingleton<CursorManager>.InstanceExists())
		{
			return;
		}
		if (isbuildable)
		{
			MonoSingleton<CursorManager>.Instance.AddCursorVisual(_cursorKey, _destroyCursor);
			return;
		}
		CursorSO cursorSO = ApplyCursor(cell);
		if ((object)cursorSO == null)
		{
			MonoSingleton<CursorManager>.Instance.RemoveCursorVisual(_cursorKey);
		}
		else
		{
			MonoSingleton<CursorManager>.Instance.AddCursorVisual(_cursorKey, cursorSO);
		}
	}

	private void UpdateBuild()
	{
		if (CurrentMode == EConstructionMode.Destruction && MonoSingleton<UI_DestructionMode>.Instance.CurrentMode == ESelectedDestructionMode.Wall)
		{
			if (!_clickLeft.action.WasPerformedThisFrame() || WorldSelector.PointerIsOverUI)
			{
				return;
			}
			RoomBuilding roomA2;
			RoomBuilding roomB2;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100f, _wallLayer) && hitInfo.collider.TryGetComponent<BuildingWall>(out var component) && component.LinkedCell.LinkedGrid == CurrentGrid && component.IsInterior)
			{
				if (CurrentGrid != null && CurrentGrid.SetWallToDestroy(component, out var roomA, out var roomB))
				{
					ConstructionSystem.OnSelectedWallForRoomDestroyChanged?.Invoke(roomA, roomB);
				}
			}
			else if (CurrentGrid == null || CurrentGrid.SetWallToDestroy(null, out roomA2, out roomB2))
			{
				ConstructionSystem.OnSelectedWallForRoomDestroyChanged?.Invoke(null, null);
			}
			return;
		}
		if (CurrentMode == EConstructionMode.Destruction && MonoSingleton<UI_DestructionMode>.Instance.CurrentMode == ESelectedDestructionMode.Standard && (object)_beginSelectionPosition == null)
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo2, 100f, _buildableLayer))
			{
				SetCursorVisual(null, isbuildable: true);
				if (hitInfo2.collider.TryGetComponent<BuildableElement>(out var component2))
				{
					if (_clickLeft.action.WasReleasedThisFrame())
					{
						MonoSingleton<BuildablePlacementSystem>.Instance.RemoveBuildable(component2);
						return;
					}
					MonoSingleton<BuildablePlacementSystem>.Instance.BuildableCursor.SetApparence(component2);
					MonoSingleton<BuildablePlacementSystem>.Instance.BuildableCursor.SetValidColor(validColor: false);
					MonoSingleton<BuildablePlacementSystem>.Instance.BuildableCursor.SetActive(active: true);
					MonoSingleton<BuildablePlacementSystem>.Instance.BuildableCursor.transform.position = component2.transform.position;
					MonoSingleton<BuildablePlacementSystem>.Instance.BuildableCursor.transform.rotation = component2.transform.rotation;
				}
				return;
			}
			MonoSingleton<BuildablePlacementSystem>.Instance.BuildableCursor.SetApparence(null);
			MonoSingleton<BuildablePlacementSystem>.Instance.BuildableCursor.SetActive(active: false);
		}
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo3, 100f, _constructableZoneLayer))
		{
			ConstructionCell cellFromMouse = CurrentGrid.GetCellFromMouse(hitInfo3.point);
			if (_currentSelectionMode != ESelectionMode.None && (object)cellFromMouse != null)
			{
				if ((object)_beginSelectionPosition == null)
				{
					_beginSelectionPosition = cellFromMouse;
					SelectedCell = cellFromMouse;
					if (CurrentMode == EConstructionMode.Construction)
					{
						if (SelectedCell.InteriorState == ConstructionCell.EInteriorState.IsInterior)
						{
							CurrentCellConstructionIndex = SelectedCell.CurrentSectorID;
						}
						else
						{
							CurrentCellConstructionIndex = MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.NextFreeIndex;
						}
					}
				}
				if (cellFromMouse.OverridableCell)
				{
					_endSelectionPosition = cellFromMouse;
				}
				if ((object)_endSelectionPosition != null && (CurrentMode != EConstructionMode.Destruction || MonoSingleton<UI_DestructionMode>.Instance.CurrentMode != ESelectedDestructionMode.PerRoom))
				{
					CurrentGrid?.AddZone(_beginSelectionPosition.transform.position, _endSelectionPosition.transform.position, CurrentMode);
				}
			}
			if (!_clickLeft.action.IsPressed())
			{
				SetCursorVisual(cellFromMouse);
			}
		}
		else if (!_clickLeft.action.IsPressed())
		{
			CurrentGrid?.SetToInvalide();
			SetCursorVisual(null);
		}
	}

	public void CreateSectorFromEditor(Vector2Int position, Vector2Int size, EConstructionMode modifiyMode)
	{
		CurrentGrid?.AddZoneFromEditor(position, size, modifiyMode);
	}

	public void ClearAllGrids()
	{
		for (int i = 0; i < Grids.Length; i++)
		{
			ClearGrid(i);
		}
	}

	public void ClearGrid(int grid)
	{
		Grids[grid]?.ClearGrid();
	}

	public void CreateGridFromEditor(int grid, CellSaveData[] cellData)
	{
		CurrentGrid = Grids[grid];
		CurrentGrid?.SetActiveFromMapEditor(active: true);
		CurrentGrid?.CreateGridFromEditor(cellData, grid);
		CurrentGrid?.SetActiveFromMapEditor(active: false);
		CurrentGrid = null;
	}

	public void OnGenerateFromEditor()
	{
		OnReleaseLeftClick();
	}

	private void CreateBuyData()
	{
		BuyingData? buyingData = null;
		if (CurrentGrid != null)
		{
			if (CurrentMode == EConstructionMode.Construction)
			{
				buyingData = CurrentGrid.GetCellToBuildCount;
			}
			else if (CurrentMode == EConstructionMode.Destruction)
			{
				buyingData = CurrentGrid.GetCellToDestroyCount;
			}
		}
		if (buyingData.HasValue)
		{
			_cellBuyingValues = buyingData.Value;
			ConstructionSystem.OnBuyingDataChanged?.Invoke(_cellBuyingValues, ConstrutionPriceSO.GetToBuyingData());
		}
	}

	public void RemoveEntireRoom(int index)
	{
		CurrentGrid?.RemoveEntireRoom(index);
		OnReleaseLeftClick();
		CurrentGrid?.Refresh();
		MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.ForceNavmeshRebake();
	}

	public void MergeRoom(RoomBuilding roomA, RoomBuilding roomB)
	{
		if (roomA == null || roomB == null)
		{
			return;
		}
		ConstructionGrid grid = roomA.Container.Grid;
		grid.ClearLocalRefreshCoordinates();
		foreach (BuildingFloor floorTile in roomA.FloorTiles)
		{
			grid.AddCellToLocalRefresh(floorTile.LinkedCell);
		}
		foreach (BuildingFloor floorTile2 in roomB.FloorTiles)
		{
			grid.AddCellToLocalRefresh(floorTile2.LinkedCell);
		}
		if (roomA.RoomIndex < roomB.RoomIndex)
		{
			if (roomA.RoomIndex == 0)
			{
				RemoveEntireRoom(roomB.RoomIndex);
			}
			else if (!MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.MergeRoom(roomA.RoomIndex, roomB.RoomIndex))
			{
				return;
			}
			roomA.RoomUpdated();
		}
		else
		{
			if (roomB.RoomIndex == 0)
			{
				RemoveEntireRoom(roomA.RoomIndex);
			}
			else if (!MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.MergeRoom(roomB.RoomIndex, roomA.RoomIndex))
			{
				return;
			}
			roomB.RoomUpdated();
		}
		OnReleaseLeftClick();
		CurrentGrid?.Refresh();
		MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.ForceNavmeshRebake();
	}
}
