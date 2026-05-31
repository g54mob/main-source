using System;
using System.Collections;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class ConstructionGrid : CTSBehaviour
{
	public static List<ConstructionGrid> CurrentGrids = new List<ConstructionGrid>();

	[SerializeField]
	private float _showSpeed = 200f;

	private ConstructionCell[,] _cellsGrid;

	private List<Vector2Int> _tempCellsPosition = new List<Vector2Int>();

	private int _lastBeginX;

	private int _lastBeginZ;

	private int _lastEndX;

	private int _lastEndZ;

	private BoxCollider _boxCollider;

	[SerializeField]
	private ConstructionCell[] _lockedCell;

	[SerializeField]
	private CellGroup[] _groupCell;

	[SerializeField]
	private GridFromTextureGeneration _gridFromTextureGeneration;

	[InjectScope(EGetScope.Singleton)]
	[Inject(false)]
	private ConstructionSystem _constructionSystem;

	[Inject(false)]
	private ConstructionParams _constructionParams;

	[Inject(false)]
	private BuildingRoomsContainerManager _floorsManager;

	private int _wallsToDestroyFromSelection;

	private int _floorToDestroyFromSelection;

	private Coroutine _showGridCoroutine;

	private Coroutine _showRoutine;

	private readonly List<Vector2Int> _modifiedCells = new List<Vector2Int>();

	private readonly List<Vector2Int> _localRefreshCoordinates = new List<Vector2Int>();

	[field: SerializeField]
	public BuildingRoomContainer RoomManager { get; private set; }

	[field: SerializeField]
	[field: FormerlySerializedAs("GridMaterial")]
	public Material FreeGridMaterial { get; private set; }

	[field: SerializeField]
	public Material UsedGridMaterial { get; private set; }

	[field: SerializeField]
	public GameObject PrevisualWallContainer { get; private set; }

	private int GridWidth => _cellsGrid.GetLength(0);

	private int GridHeight => _cellsGrid.GetLength(1);

	[field: SerializeField]
	public bool IsGroundFloor { get; private set; }

	[field: SerializeField]
	public bool IsUnderGround { get; private set; }

	[field: SerializeField]
	public Material ExteriorWallMaterial { get; private set; }

	public bool ConstructionGridIsReady { get; private set; }

	public Vector2Int GetGridSize => new Vector2Int(_cellsGrid.GetLength(0), _cellsGrid.GetLength(1));

	public BuyingData GetCellToBuildCount
	{
		get
		{
			BuyingData result = default(BuyingData);
			for (int i = 0; i < _tempCellsPosition.Count; i++)
			{
				result += _cellsGrid[_tempCellsPosition[i].x, _tempCellsPosition[i].y].CellBuildCost;
			}
			return result;
		}
	}

	public BuyingData GetCellToDestroyCount
	{
		get
		{
			BuyingData result = default(BuyingData);
			for (int i = 0; i < _tempCellsPosition.Count; i++)
			{
				result += _cellsGrid[_tempCellsPosition[i].x, _tempCellsPosition[i].y].CellDestroyCost;
			}
			result.WallsToDestroy += _wallsToDestroyFromSelection;
			result.FloorsToDestroy += _floorToDestroyFromSelection;
			result.FloorsToDestroy += MonoSingleton<UI_DestructionMode>.Instance.CurrentRoomDestroyCellCount;
			return result;
		}
	}

	public int GetTempZoneBuildCost => MonoSingleton<ConstructionSystem>.Instance.ConstrutionPriceSO.BuildFloorPrice * _tempCellsPosition.Count;

	public int GetTotalSuperficy
	{
		get
		{
			int num = 0;
			for (int i = 0; i < _cellsGrid.GetLength(0); i++)
			{
				for (int j = 0; j < _cellsGrid.GetLength(1); j++)
				{
					if ((object)_cellsGrid[i, j] != null)
					{
						num += ((_cellsGrid[i, j].BuildedSectorID != 0) ? 1 : 0);
					}
				}
			}
			return num;
		}
	}

	public int GetTotalInteriorCells
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, RoomBuilding> generatedRoom in RoomManager.GeneratedRooms)
			{
				num += generatedRoom.Value.GetTotalInteriorCells;
			}
			return num;
		}
	}

	public float GetTotalStyleValue
	{
		get
		{
			float num = 0f;
			foreach (KeyValuePair<int, RoomBuilding> generatedRoom in RoomManager.GeneratedRooms)
			{
				num += generatedRoom.Value.GetTotalStyleValue;
			}
			return num;
		}
	}

	public float GetTotalStylePrestige
	{
		get
		{
			float num = 0f;
			foreach (KeyValuePair<int, RoomBuilding> generatedRoom in RoomManager.GeneratedRooms)
			{
				num += generatedRoom.Value.GetTotalStylePrestige;
			}
			return num;
		}
	}

	public bool IsShowed { get; private set; }

	public static event Action OnBuildablePlaced;

	protected override void OnAwake()
	{
		CurrentGrids.Add(this);
		ConstructionGridIsReady = false;
		base.transform.rotation = Quaternion.identity;
		base.transform.localScale = Vector3.one;
		_boxCollider = GetComponent<BoxCollider>();
		_boxCollider.enabled = false;
		RoomManager.Grid = this;
	}

	private void Start()
	{
		LinkCells();
		ConstructionGridIsReady = true;
		UpdateCollider(GridWidth, GridHeight);
		_boxCollider.enabled = false;
		for (int i = 0; i < _lockedCell.Length; i++)
		{
			_lockedCell[i].OverridableCell = false;
		}
		for (int j = 0; j < _groupCell.Length; j++)
		{
			for (int k = 0; k < _groupCell[j].Group.Length; k++)
			{
				_groupCell[j].Group[k].HasGroupCell = j;
			}
		}
		if (_gridFromTextureGeneration != null)
		{
			SetGridCellsLockInfo(_gridFromTextureGeneration.GetMap());
		}
		ConstructionCell[,] cellsGrid = _cellsGrid;
		foreach (ConstructionCell constructionCell in cellsGrid)
		{
			if (constructionCell.HasFloorTile)
			{
				constructionCell.SpawnFloor(RoomManager.GetRoomByIndex(0));
			}
		}
		RoomManager.GetRoomByIndex(0).RoomUpdated();
	}

	private void OnDestroy()
	{
		CurrentGrids.Remove(this);
	}

	private void LinkCells()
	{
		GridSize componentInChildren = base.gameObject.GetComponentInChildren<GridSize>();
		if (componentInChildren == null)
		{
			return;
		}
		_cellsGrid = new ConstructionCell[componentInChildren.Width, componentInChildren.Height];
		ConstructionCell[] componentsInChildren = GetComponentsInChildren<ConstructionCell>(includeInactive: true);
		foreach (ConstructionCell constructionCell in componentsInChildren)
		{
			if ((bool)constructionCell.Floor && constructionCell.Floor.PaintMaterial.HasValue)
			{
				constructionCell.SetMaterial(UsedGridMaterial);
			}
			else
			{
				constructionCell.SetMaterial(FreeGridMaterial);
			}
			_cellsGrid[constructionCell.Coordinate.x, constructionCell.Coordinate.y] = constructionCell;
		}
	}

	public void GenerateGrid(int width, int height, ConstructionCell cellPrefab, float cellSize, Vector3 cellPositionOffset)
	{
		while (base.transform.childCount > 0)
		{
			UnityEngine.Object.DestroyImmediate(base.transform.GetChild(0).gameObject);
		}
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				ConstructionCell constructionCell = UnityEngine.Object.Instantiate(cellPrefab, base.transform.position + new Vector3((float)i * cellSize, 0f, (float)j * cellSize) + cellPositionOffset, Quaternion.identity, base.gameObject.transform);
				constructionCell.gameObject.SetActive(value: false);
				constructionCell.Coordinate = new Vector2Int(i, j);
			}
		}
		CreateGridSize(width, height);
		UpdateCollider(width, height);
	}

	public void SetGridCellsLockInfo(ETextureSurfaceType[,] valuesMap)
	{
		int length = valuesMap.GetLength(0);
		int length2 = valuesMap.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				ConstructionCell cell = GetCell(i, j);
				ETextureSurfaceType lhs = valuesMap[i, j];
				cell.setCellUnoveriadable = !lhs.HasFlagNonAlloc(ETextureSurfaceType.Constructable);
				cell.HasFloorTile = lhs.HasFlagNonAlloc(ETextureSurfaceType.End | ETextureSurfaceType.Constructable);
				cell.SetEnds(lhs.HasFlagNonAlloc(ETextureSurfaceType.EndPlusX), lhs.HasFlagNonAlloc(ETextureSurfaceType.EndMinusX), lhs.HasFlagNonAlloc(ETextureSurfaceType.EndPlusY), lhs.HasFlagNonAlloc(ETextureSurfaceType.EndMinusY));
			}
		}
	}

	private void CreateGridSize(int width, int height)
	{
		GridSize gridSize = base.gameObject.GetComponentInChildren<GridSize>();
		if (gridSize == null)
		{
			GameObject obj = new GameObject();
			obj.name = "Grid Size";
			obj.transform.SetParent(base.transform);
			gridSize = obj.AddComponent<GridSize>();
		}
		gridSize.Width = width;
		gridSize.Height = height;
	}

	[Button(null, EButtonEnableMode.Always)]
	private void UpdateCollider()
	{
		int width;
		int height;
		if (_cellsGrid == null)
		{
			GridSize componentInChildren = GetComponentInChildren<GridSize>(includeInactive: true);
			if ((object)componentInChildren == null)
			{
				Debug.LogException(new NullReferenceException("Can't find grid size"));
				return;
			}
			width = componentInChildren.Width;
			height = componentInChildren.Height;
		}
		else
		{
			width = GridWidth;
			height = GridHeight;
		}
		UpdateCollider(width, height);
	}

	private void UpdateCollider(int width, int height)
	{
		if (base.gameObject.TryGetComponent<BoxCollider>(out var component))
		{
			_boxCollider = component;
		}
		else
		{
			_boxCollider = base.gameObject.AddComponent<BoxCollider>();
		}
		_boxCollider.size = new Vector3(width, 0.025f, height);
		_boxCollider.center = new Vector3((float)width / 2f, 0.0125f, (float)height / 2f);
	}

	public void SetActiveFromMapEditor(bool active)
	{
		if (_cellsGrid == null)
		{
			LinkCells();
		}
		ShowCellsFromEditor(active);
	}

	[Button("Show Grid", EButtonEnableMode.Playmode)]
	private void ShowGrid()
	{
		ShowGridVisual(show: true);
	}

	[Button("Hide Grid", EButtonEnableMode.Playmode)]
	private void HideGrid()
	{
		ShowGridVisual(show: false);
	}

	public bool SetActive(bool active)
	{
		if (!_boxCollider)
		{
			return false;
		}
		_boxCollider.enabled = active;
		if (_cellsGrid == null)
		{
			LinkCells();
		}
		if (!active)
		{
			_lastBeginX = -1;
			_lastBeginZ = -1;
			_lastEndX = -1;
			_lastEndZ = -1;
			ClearTempZones();
		}
		ShowGridVisual(active);
		return true;
	}

	public void ShowGridVisual(bool show)
	{
		if (IsShowed != show)
		{
			IsShowed = show;
			if (_showRoutine != null)
			{
				StopCoroutine(_showRoutine);
			}
			_showRoutine = StartCoroutine(ShowGridCoroutine());
		}
	}

	private IEnumerator ShowGridCoroutine()
	{
		int i = 0;
		int count = 0;
		for (; i < GridWidth; i++)
		{
			int num = 0;
			while (num < GridHeight)
			{
				if (IsShowed)
				{
					_cellsGrid[i, num]?.Show();
				}
				else
				{
					_cellsGrid[i, num]?.Hide();
				}
				num++;
				count++;
			}
			if (count > 200)
			{
				count -= 200;
				yield return null;
			}
		}
		_showRoutine = null;
	}

	private void ShowCellsFromEditor(bool show)
	{
		for (int i = 0; i < GridWidth; i++)
		{
			for (int j = 0; j < GridHeight; j++)
			{
				_cellsGrid[i, j].gameObject.SetActive(show);
			}
		}
	}

	public void ClearGrid()
	{
		int childCount = MonoSingleton<ConstructionSystem>.Instance.GetParentWall.childCount;
		for (int i = 0; i < childCount; i++)
		{
			if (MonoSingleton<ConstructionSystem>.Instance.GetParentWall.GetChild(i).gameObject.TryGetComponent<BuildableElement>(out var component))
			{
				component.DestroyElement();
			}
		}
		ClearTempZones();
		for (int j = 0; j < _cellsGrid.GetLength(0); j++)
		{
			for (int k = 0; k < _cellsGrid.GetLength(1); k++)
			{
				if (_cellsGrid[j, k] != null)
				{
					GetCell(j, k).ClearCell();
				}
			}
		}
		GenerateFloorAndWallFromSelection();
		Generate(EConstructionMode.Destruction, out var _, refreshAll: false);
		MonoSingleton<ConstructionSystem>.Instance.OnCloseBuildModeFromEditor();
	}

	public void RemoveEntireRoom(int index)
	{
		int length = _cellsGrid.GetLength(0);
		int length2 = _cellsGrid.GetLength(1);
		_localRefreshCoordinates.Clear();
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				ConstructionCell constructionCell = _cellsGrid[i, j];
				if ((object)constructionCell == null || constructionCell.CurrentSectorID != index)
				{
					continue;
				}
				constructionCell.TempSectorID = 0;
				constructionCell.CurrentState = ConstructionCell.ECellState.ToDestroy;
				_tempCellsPosition.Add(new Vector2Int(i, j));
				for (int k = i - 1; k < i + 2; k++)
				{
					for (int l = j - 1; l < j + 2; l++)
					{
						if (k >= 0 && l >= 0 && k < GridWidth && l < GridHeight)
						{
							Vector2Int item = new Vector2Int(k, l);
							if (!_localRefreshCoordinates.Contains(item))
							{
								_localRefreshCoordinates.Add(item);
							}
						}
					}
				}
			}
		}
		GenerateFloorAndWallFromSelection();
	}

	public void CreateGridFromEditor(CellSaveData[] cellDatas, int gridId)
	{
		SortedDictionary<int, List<CellSaveData>> sortedDictionary = new SortedDictionary<int, List<CellSaveData>>();
		for (int i = 0; i < cellDatas.Length; i++)
		{
			CellSaveData item = cellDatas[i];
			if (!sortedDictionary.ContainsKey(item.roomID))
			{
				sortedDictionary.Add(item.roomID, new List<CellSaveData>());
			}
			sortedDictionary[item.roomID].Add(item);
		}
		foreach (int key in sortedDictionary.Keys)
		{
			if (key == 0)
			{
				continue;
			}
			MonoSingleton<BuildingRoomsContainerManager>.Instance.GetRoomContainerAt(gridId).CreateNewRoomWithIndex(key);
			foreach (CellSaveData item2 in sortedDictionary[key])
			{
				ConstructionCell[,] cellsGrid = _cellsGrid;
				Vector2Int position = item2.position;
				int x = position.x;
				position = item2.position;
				cellsGrid[x, position.y].LoadCellFromEditor(item2);
			}
		}
		Generate(EConstructionMode.Construction, out var _, refreshAll: true);
		foreach (int key2 in sortedDictionary.Keys)
		{
			for (int j = 0; j < sortedDictionary[key2].Count; j++)
			{
				try
				{
					_cellsGrid[sortedDictionary[key2][j].position.x, sortedDictionary[key2][j].position.y].LoadBuildables(sortedDictionary[key2][j]);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}

	public bool AddZone(Vector3 beginPoint, Vector3 endPoint, EConstructionMode mode)
	{
		beginPoint -= base.transform.position;
		endPoint -= base.transform.position;
		int num = Mathf.FloorToInt((beginPoint.x < endPoint.x) ? beginPoint.x : endPoint.x);
		int num2 = Mathf.FloorToInt((beginPoint.z < endPoint.z) ? beginPoint.z : endPoint.z);
		int num3 = Mathf.FloorToInt((beginPoint.x > endPoint.x) ? beginPoint.x : endPoint.x);
		int num4 = Mathf.FloorToInt((beginPoint.z > endPoint.z) ? beginPoint.z : endPoint.z);
		if (_lastBeginX == num && _lastBeginZ == num2 && _lastEndX == num3 && _lastEndZ == num4)
		{
			return false;
		}
		_lastBeginX = num;
		_lastBeginZ = num2;
		_lastEndX = num3;
		_lastEndZ = num4;
		ConstructionFeedback.ClearList();
		List<ConstructionFeedBackResult> list = new List<ConstructionFeedBackResult>();
		AddZone(num, num2, num3, num4, mode, list);
		if (list.Count > 0)
		{
			SetToInvalide(_tempCellsPosition);
		}
		foreach (ConstructionFeedBackResult item in list)
		{
			ConstructionFeedback.AddToList(item);
		}
		GenerateFloorAndWallFromSelection();
		return true;
	}

	private void AddZone(int xBegin, int zBegin, int xEnd, int zEnd, EConstructionMode mode, List<ConstructionFeedBackResult> feedbacks)
	{
		_localRefreshCoordinates.Clear();
		_localRefreshCoordinates.AddRange(_modifiedCells);
		_modifiedCells.Clear();
		ClearTempZones();
		for (int i = xBegin; i < xEnd + 1; i++)
		{
			for (int j = zBegin; j < zEnd + 1; j++)
			{
				if ((object)GetCell(i, j) != null)
				{
					EConstructionResult eConstructionResult = UpdateCell(i, j, mode);
					if (eConstructionResult != 0)
					{
						feedbacks.Add(new ConstructionFeedBackResult
						{
							ConstructionResult = eConstructionResult
						});
					}
				}
				else
				{
					SetToInvalide(_tempCellsPosition);
					feedbacks.Add(new ConstructionFeedBackResult
					{
						ConstructionResult = EConstructionResult.TooNear
					});
				}
			}
		}
		for (int k = xBegin - 1; k < xEnd + 2; k++)
		{
			for (int l = zBegin - 1; l < zEnd + 2; l++)
			{
				Vector2Int item = new Vector2Int(k, l);
				_modifiedCells.Add(item);
				if (!_localRefreshCoordinates.Contains(item))
				{
					_localRefreshCoordinates.Add(item);
				}
			}
		}
		List<int> list = CollectionPool<List<int>, int>.Get();
		if (!CheckSpace(list))
		{
			for (int m = 0; m < list.Count; m++)
			{
				if (list[m] == 0)
				{
					feedbacks.Add(new ConstructionFeedBackResult
					{
						ConstructionResult = EConstructionResult.TooNear
					});
				}
				else
				{
					feedbacks.Add(new ConstructionFeedBackResult
					{
						ConstructionResult = EConstructionResult.NoMinimumSize
					});
				}
			}
		}
		CollectionPool<List<int>, int>.Release(list);
		if (mode == EConstructionMode.Construction)
		{
			ValideResultForConstruction(_tempCellsPosition, _constructionSystem.CurrentCellConstructionIndex, feedbacks);
			return;
		}
		VerifiySpaceForDestruction(_tempCellsPosition, _constructionSystem.CurrentCellConstructionIndex, feedbacks);
		foreach (int key in _floorsManager.CurrentContainer.GeneratedRooms.Keys)
		{
			if (key != 0)
			{
				VerifiySpaceForDestruction(_tempCellsPosition, key, feedbacks);
			}
		}
		RoomBuilding roomByIndex = _floorsManager.CurrentRoomManager.GetRoomByIndex(_constructionSystem.CurrentCellConstructionIndex);
		if (roomByIndex != null && !roomByIndex.IsInOnePiece())
		{
			feedbacks.Add(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.HaveInvalideCells
			});
		}
	}

	[Obsolete]
	public void AddZone(Vector2Int[] positions, EConstructionMode mode)
	{
		ClearTempZones();
		for (int i = 0; i < positions.Length; i++)
		{
			UpdateCell(positions[i].x, positions[i].y, mode);
		}
		GenerateFloorAndWallFromSelection();
	}

	public void AddZoneFromEditor(Vector2Int position, Vector2Int size, EConstructionMode mode)
	{
		ClearTempZones();
		for (int i = position.x; i < position.x + size.x; i++)
		{
			for (int j = position.y; j < position.y + size.y; j++)
			{
				UpdateCell(i, j, mode);
			}
		}
		GenerateFloorAndWallFromSelection(refreshAll: true);
	}

	private void ValideResultForConstruction(List<Vector2Int> positions, int id, List<ConstructionFeedBackResult> feedbacks)
	{
		int cellCountWithThisID = GetCellCountWithThisID(id);
		foreach (Vector2Int position in positions)
		{
			IsValidCellForConstruction(_cellsGrid[position.x, position.y], id, cellCountWithThisID, feedbacks);
		}
		if (GetTempZoneBuildCost > MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetCurrentMoney())
		{
			feedbacks.Add(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.NotEnoughtMoney
			});
		}
	}

	private void IsValidCellForConstruction(ConstructionCell cell, int id, int idCount, List<ConstructionFeedBackResult> feedbacks)
	{
		if (cell.CurrentState == ConstructionCell.ECellState.Invalide)
		{
			feedbacks.Add(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.HaveInvalideCells
			});
		}
		if (!VerifySpaceByID(cell.Coordinate, id, _constructionParams.InteriorMinimumZoneLenght))
		{
			feedbacks.Add(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.NoMinimumSize
			});
		}
		if (idCount < _constructionParams.InteriorMinimumCellCount)
		{
			feedbacks.Add(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.NoMinimumCellCount,
				param = idCount
			});
		}
	}

	private void VerifiySpaceForDestruction(List<Vector2Int> positions, int id, List<ConstructionFeedBackResult> feedbacks)
	{
		int cellCountWithThisID = GetCellCountWithThisID(id);
		foreach (Vector2Int position in positions)
		{
			IsValidCellForDestruction(_cellsGrid[position.x, position.y], cellCountWithThisID, feedbacks);
		}
		List<ConstructionCell> list = CollectionPool<List<ConstructionCell>, ConstructionCell>.Get();
		GetCellsWithThisID(id, list);
		foreach (ConstructionCell item in list)
		{
			if (!VerifySpaceByID(item.Coordinate, id, _constructionParams.InteriorMinimumZoneLenght))
			{
				feedbacks.Add(new ConstructionFeedBackResult
				{
					ConstructionResult = EConstructionResult.NoMinimumSize
				});
				break;
			}
		}
		CollectionPool<List<ConstructionCell>, ConstructionCell>.Release(list);
	}

	private void IsValidCellForDestruction(ConstructionCell cell, int cellCount, List<ConstructionFeedBackResult> feedbacks)
	{
		if (cell.CurrentState == ConstructionCell.ECellState.Invalide || cell.InteriorState != ConstructionCell.EInteriorState.IsInterior)
		{
			feedbacks.Add(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.HaveInvalideCells
			});
		}
		if (cellCount < _constructionParams.InteriorMinimumCellCount && cellCount > 0)
		{
			feedbacks.Add(new ConstructionFeedBackResult
			{
				ConstructionResult = EConstructionResult.NoMinimumCellCount,
				param = cellCount
			});
		}
	}

	private bool CheckSpace(List<int> ids)
	{
		for (int i = 0; i < GridWidth; i++)
		{
			for (int j = 0; j < GridHeight; j++)
			{
				ConstructionCell cell = GetCell(i, j);
				if ((object)cell != null && !CheckCellEnvironnement(i, j, cell.CurrentSectorID) && !ids.Contains(cell.CurrentSectorID))
				{
					ids.Add(cell.CurrentSectorID);
				}
			}
		}
		if (ids.Count > 0)
		{
			return false;
		}
		return true;
	}

	public bool CheckCellEnvironnement(int x, int z, int id)
	{
		ConstructionCell cell = GetCell(x - 1, z);
		ConstructionCell cell2 = GetCell(x + 1, z);
		if ((object)cell != null && cell.CurrentSectorID != id && (object)cell2 != null && cell2.CurrentSectorID != id)
		{
			return false;
		}
		cell = GetCell(x, z - 1);
		cell2 = GetCell(x, z + 1);
		if ((object)cell != null && cell.CurrentSectorID != id && (object)cell2 != null)
		{
			return cell2.CurrentSectorID == id;
		}
		return true;
	}

	private int GetCellCountWithThisID(int id)
	{
		int num = 0;
		int length = _cellsGrid.GetLength(0);
		int length2 = _cellsGrid.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				ConstructionCell constructionCell = _cellsGrid[i, j];
				if ((object)constructionCell != null && constructionCell.CurrentSectorID == id)
				{
					num++;
				}
			}
		}
		return num;
	}

	private void GetCellsWithThisID(int id, List<ConstructionCell> cells)
	{
		int length = _cellsGrid.GetLength(0);
		int length2 = _cellsGrid.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				ConstructionCell constructionCell = _cellsGrid[i, j];
				if (constructionCell.CurrentSectorID == id)
				{
					cells.Add(constructionCell);
				}
			}
		}
	}

	private void SetToInvalide(List<Vector2Int> positions)
	{
		for (int i = 0; i < positions.Count; i++)
		{
			_cellsGrid[positions[i].x, positions[i].y].TempSectorID = null;
			_cellsGrid[positions[i].x, positions[i].y].CurrentState = ConstructionCell.ECellState.Invalide;
		}
	}

	private bool VerifySpaceByID(Vector2Int position, int id, int distance)
	{
		for (int i = 0; i < distance; i++)
		{
			for (int j = 0; j < distance; j++)
			{
				if (IsSameId(position + new Vector2Int(i - distance + 1, j - distance + 1), id, distance))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool IsSameId(Vector2Int position, int id, int distance)
	{
		for (int i = 0; i < distance; i++)
		{
			for (int j = 0; j < distance; j++)
			{
				ConstructionCell cell = GetCell(position + new Vector2Int(i, j));
				if ((object)cell == null)
				{
					return false;
				}
				if (cell.InteriorState == ConstructionCell.EInteriorState.None && cell.CurrentSectorID != id)
				{
					return false;
				}
			}
		}
		return true;
	}

	private EConstructionResult UpdateCell(int x, int z, EConstructionMode mode)
	{
		EConstructionResult result = (EConstructionResult)0;
		x = ((x <= 0) ? 1 : ((x >= GridWidth - 1) ? (GridWidth - 2) : x));
		z = ((z <= 0) ? 1 : ((z >= GridHeight - 1) ? (GridHeight - 2) : z));
		ConstructionCell constructionCell = _cellsGrid[x, z];
		if (!constructionCell.OverridableCell)
		{
			_tempCellsPosition.Add(new Vector2Int(x, z));
			constructionCell.CurrentState = ConstructionCell.ECellState.Invalide;
			return (EConstructionResult)0;
		}
		switch (mode)
		{
		case EConstructionMode.Construction:
			if (constructionCell.HasTempSector)
			{
				break;
			}
			if (constructionCell.InteriorState == ConstructionCell.EInteriorState.None)
			{
				if (constructionCell.CurrentSectorID != _constructionSystem.CurrentCellConstructionIndex)
				{
					constructionCell.TempSectorID = _constructionSystem.CurrentCellConstructionIndex;
					_tempCellsPosition.Add(new Vector2Int(x, z));
					constructionCell.InteriorState = ConstructionCell.EInteriorState.MarkAsInterior;
					constructionCell.CurrentState = ConstructionCell.ECellState.ToBuild;
				}
				else
				{
					_tempCellsPosition.Add(new Vector2Int(x, z));
					constructionCell.CurrentState = ConstructionCell.ECellState.Invalide;
					result = EConstructionResult.TooNear;
				}
			}
			_constructionSystem.SelectedCell.CurrentState = ConstructionCell.ECellState.ToBuild;
			break;
		case EConstructionMode.Destruction:
			if (!constructionCell.HasTempSector)
			{
				if (constructionCell.InteriorState == ConstructionCell.EInteriorState.IsInterior)
				{
					constructionCell.TempSectorID = 0;
					constructionCell.CurrentState = ConstructionCell.ECellState.ToDestroy;
					_tempCellsPosition.Add(new Vector2Int(x, z));
				}
				if ((object)_constructionSystem.SelectedCell != null)
				{
					_constructionSystem.SelectedCell.CurrentState = ConstructionCell.ECellState.ToDestroy;
				}
			}
			break;
		}
		return result;
	}

	public void SetToInvalide()
	{
		SetToInvalide(_tempCellsPosition);
		GenerateFloorAndWallFromSelection();
		_localRefreshCoordinates.Clear();
		_lastBeginX = -1;
		_lastBeginZ = -1;
		_lastEndX = -1;
		_lastEndZ = -1;
	}

	public void ClearTempZones()
	{
		while (_tempCellsPosition.Count > 0)
		{
			ConstructionCell constructionCell = _cellsGrid[_tempCellsPosition[0].x, _tempCellsPosition[0].y];
			if (constructionCell.InteriorState == ConstructionCell.EInteriorState.MarkAsInterior)
			{
				constructionCell.InteriorState = ConstructionCell.EInteriorState.None;
			}
			constructionCell.TempSectorID = null;
			constructionCell.CurrentState = ConstructionCell.ECellState.Default;
			_tempCellsPosition.RemoveAt(0);
			if ((object)_constructionSystem.SelectedCell != null)
			{
				_constructionSystem.SelectedCell.CurrentState = ConstructionCell.ECellState.Default;
			}
		}
	}

	public int Generate(EConstructionMode mode, out int interiorCreated, bool refreshAll)
	{
		RoomBuilding roomBuilding = null;
		roomBuilding = ((mode != EConstructionMode.Construction) ? _floorsManager.CurrentRoomManager.GetRoomByIndex(0) : _floorsManager.CurrentRoomManager.CreateNewRoom());
		int result = CreateSections(out interiorCreated);
		if (refreshAll)
		{
			GenerateWallsForEverything(PrevisualWallContainer, roomBuilding);
		}
		else
		{
			GenerateWallsOnCurrentSelection(PrevisualWallContainer, roomBuilding);
		}
		MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager?.UpdateRooms();
		MonoSingleton<ConstructionSystem>.Instance.CurrentWallToCreateCount = 0;
		ClearTempZones();
		return result;
	}

	public void GenerateFloorAndWallFromSelection(bool refreshAll = false)
	{
		if (refreshAll)
		{
			GenerateWallsForEverything(PrevisualWallContainer, null);
		}
		else
		{
			GenerateWallsOnCurrentSelection(PrevisualWallContainer, null);
		}
	}

	public void Refresh()
	{
		_wallsToDestroyFromSelection = 0;
		_floorToDestroyFromSelection = 0;
		GenerateFloorAndWallFromSelection();
		MonoSingleton<WallSelectionManager>.Instance.ClearSelectables();
	}

	private int CreateSections(out int interiorCreated)
	{
		int num = 0;
		interiorCreated = 0;
		for (int i = 0; i < GridWidth; i++)
		{
			for (int j = 0; j < GridHeight; j++)
			{
				ConstructionCell constructionCell = _cellsGrid[i, j];
				if ((object)constructionCell == null)
				{
					continue;
				}
				if (constructionCell.TempSectorID.HasValue && constructionCell.CurrentState != ConstructionCell.ECellState.Invalide)
				{
					bool flag = constructionCell.BuildedSectorID != constructionCell.TempSectorID.Value;
					if (!constructionCell.OverridableCell)
					{
						constructionCell.TempSectorID = null;
						continue;
					}
					if (constructionCell.BuildedSectorID != constructionCell.TempSectorID)
					{
						_floorsManager.CurrentRoomManager.AddModifiedRoomIndex(constructionCell.BuildedSectorID);
					}
					else if (constructionCell.TempSectorID == 0)
					{
						_floorsManager.CurrentRoomManager.AddModifiedRoomIndex(0);
					}
					_floorsManager.CurrentRoomManager.AddModifiedRoomIndex(GetNeighborCell(new Vector2Int(i, j), ERotationAngle.Nord).CurrentSectorID);
					_floorsManager.CurrentRoomManager.AddModifiedRoomIndex(GetNeighborCell(new Vector2Int(i, j), ERotationAngle.East).CurrentSectorID);
					_floorsManager.CurrentRoomManager.AddModifiedRoomIndex(GetNeighborCell(new Vector2Int(i, j), ERotationAngle.South).CurrentSectorID);
					_floorsManager.CurrentRoomManager.AddModifiedRoomIndex(GetNeighborCell(new Vector2Int(i, j), ERotationAngle.West).CurrentSectorID);
					constructionCell.BuildedSectorID = constructionCell.TempSectorID.Value;
					constructionCell.TempSectorID = null;
					if (constructionCell.CurrentState == ConstructionCell.ECellState.ToBuild)
					{
						if (constructionCell.InteriorState == ConstructionCell.EInteriorState.MarkAsInterior)
						{
							constructionCell.InteriorState = ConstructionCell.EInteriorState.IsInterior;
							if (flag)
							{
								interiorCreated++;
							}
						}
					}
					else if (constructionCell.CurrentState == ConstructionCell.ECellState.ToDestroy)
					{
						if (constructionCell.InteriorState == ConstructionCell.EInteriorState.IsInterior && flag)
						{
							interiorCreated--;
						}
						constructionCell.InteriorState = ConstructionCell.EInteriorState.None;
					}
					constructionCell.CurrentState = ConstructionCell.ECellState.Default;
					constructionCell.UpdateVisuals();
					if (flag)
					{
						num++;
					}
				}
				else
				{
					constructionCell.CurrentState = ConstructionCell.ECellState.Default;
				}
			}
		}
		return num;
	}

	public bool SetWallToDestroy(BuildingWall wall, out RoomBuilding roomA, out RoomBuilding roomB)
	{
		roomA = null;
		roomB = null;
		if (!MonoSingleton<WallSelectionManager>.InstanceExists())
		{
			return true;
		}
		WallSelectionManager instance = MonoSingleton<WallSelectionManager>.Instance;
		if ((object)wall != null && instance.ContaintSelectable(wall.GetComponent<SelectableWall>()))
		{
			return false;
		}
		if ((object)wall == null)
		{
			instance.ClearSelectables();
			_wallsToDestroyFromSelection = 0;
			_floorToDestroyFromSelection = 0;
			return true;
		}
		if (MonoSingleton<WallSelectionManager>.Instance.ContaintSelectable(wall.GetComponent<SelectableWall>()))
		{
			SetWallToDestroy(wall, toUnselect: true, out roomA, out roomB);
		}
		else if (MonoSingleton<WallSelectionManager>.Instance.GetSelectableCount() > 0)
		{
			SetWallToDestroy(MonoSingleton<WallSelectionManager>.Instance.GetFirstSelectable().GetComponent<BuildingWall>(), toUnselect: true, out roomA, out roomB);
			SetWallToDestroy(wall, toUnselect: false, out roomA, out roomB);
		}
		else
		{
			SetWallToDestroy(wall, toUnselect: false, out roomA, out roomB);
		}
		return true;
	}

	public void ClearLocalRefreshCoordinates()
	{
		_localRefreshCoordinates.Clear();
	}

	public void AddCellToLocalRefresh(ConstructionCell cell)
	{
		_localRefreshCoordinates.Add(cell.Coordinate);
	}

	private void SetWallToDestroy(BuildingWall wall, bool toUnselect, out RoomBuilding roomA, out RoomBuilding roomB)
	{
		roomA = null;
		roomB = null;
		ConstructionCell linkedCell = wall.LinkedCell;
		if (!(linkedCell != null))
		{
			return;
		}
		ConstructionCell neighborCell = GetNeighborCell(linkedCell.Coordinate, wall.RotationAngle);
		if (!toUnselect)
		{
			roomA = wall.LinkedRoom;
			roomB = neighborCell.LinkedRoom;
		}
		if (neighborCell != null)
		{
			int num = wall.LinkedRoom.SelectWalls(neighborCell.BuildedSectorID, toUnselect) / 2;
			_wallsToDestroyFromSelection += (toUnselect ? (-num) : num);
			if (linkedCell.CurrentSectorID == 0)
			{
				_floorToDestroyFromSelection += (toUnselect ? (-neighborCell.Floor.LinkedRoom.FloorContainer.childCount) : neighborCell.Floor.LinkedRoom.FloorContainer.childCount);
			}
			else if (neighborCell.CurrentSectorID == 0)
			{
				_floorToDestroyFromSelection += (toUnselect ? (-linkedCell.Floor.LinkedRoom.FloorContainer.childCount) : linkedCell.Floor.LinkedRoom.FloorContainer.childCount);
			}
		}
	}

	public bool TryGetNeighborCell(Vector2Int coordinate, ERotationAngle rotation, out ConstructionCell outCell)
	{
		int num = coordinate.x;
		int num2 = coordinate.y;
		switch (rotation)
		{
		case ERotationAngle.Nord:
			num2++;
			break;
		case ERotationAngle.East:
			num++;
			break;
		case ERotationAngle.South:
			num2--;
			break;
		case ERotationAngle.West:
			num--;
			break;
		default:
			num = -1;
			num2 = -1;
			break;
		}
		if (num < 0 || num >= _cellsGrid.GetLength(0))
		{
			outCell = null;
			return false;
		}
		if (num2 < 0 || num2 >= _cellsGrid.GetLength(1))
		{
			outCell = null;
			return false;
		}
		outCell = _cellsGrid[num, num2];
		return true;
	}

	public ConstructionCell GetNeighborCell(Vector2Int coordinate, ERotationAngle rotation)
	{
		return rotation switch
		{
			ERotationAngle.Nord => _cellsGrid[coordinate.x, coordinate.y + 1], 
			ERotationAngle.East => _cellsGrid[coordinate.x + 1, coordinate.y], 
			ERotationAngle.South => _cellsGrid[coordinate.x, coordinate.y - 1], 
			ERotationAngle.West => _cellsGrid[coordinate.x - 1, coordinate.y], 
			_ => null, 
		};
	}

	public ConstructionCell[] GetCells(Vector2Int start, Vector2Int end, bool limitOnly)
	{
		List<ConstructionCell> list = new List<ConstructionCell>();
		for (int i = start.x; i < end.x; i++)
		{
			for (int j = start.y; j < end.y; j++)
			{
				if (!limitOnly || ((i == start.x || i == end.x - 1) && (j == start.y || j == end.y - 1)))
				{
					list.Add(GetCell(i, j));
				}
			}
		}
		return list.ToArray();
	}

	public ConstructionCell[,] GetCellsDoubleArray(Vector2Int start, Vector2Int end)
	{
		ConstructionCell[,] array = new ConstructionCell[end.x - start.x, end.y - start.y];
		for (int i = start.x; i < end.x; i++)
		{
			for (int j = start.y; j < end.y; j++)
			{
				array[i - start.x, j - start.y] = GetCell(i, j);
			}
		}
		return array;
	}

	public ConstructionCell GetCell(Vector2Int coordinate)
	{
		return GetCell(coordinate.x, coordinate.y);
	}

	public ConstructionCell GetCell(int x, int z)
	{
		if (x < 0 || x >= _cellsGrid.GetLength(0))
		{
			return null;
		}
		if (z < 0 || z >= _cellsGrid.GetLength(1))
		{
			return null;
		}
		return _cellsGrid[x, z];
	}

	public ConstructionCell GetCellFromMouse(Vector3 point)
	{
		point -= base.transform.position;
		int x = Mathf.FloorToInt(point.x);
		int z = Mathf.FloorToInt(point.z);
		return GetCell(x, z);
	}

	private void GenerateWallsOnCurrentSelection(GameObject container, RoomBuilding room)
	{
		List<CellConstructionStruct> list = new List<CellConstructionStruct>();
		foreach (Vector2Int localRefreshCoordinate in _localRefreshCoordinates)
		{
			int x = localRefreshCoordinate.x;
			if (x < 0 || x >= GridWidth)
			{
				continue;
			}
			int y = localRefreshCoordinate.y;
			if (y < 0 || y >= GridHeight)
			{
				continue;
			}
			ConstructionCell constructionCell = _cellsGrid[x, y];
			if ((object)constructionCell != null)
			{
				EWallType? eWallTypeRelativeToRotation = GetEWallTypeRelativeToRotation(x, y, ERotationAngle.Nord, constructionCell.CurrentSectorID);
				if (eWallTypeRelativeToRotation.HasValue)
				{
					list.Add(new CellConstructionStruct(ERotationAngle.Nord, eWallTypeRelativeToRotation.Value));
				}
				EWallType? eWallTypeRelativeToRotation2 = GetEWallTypeRelativeToRotation(x, y, ERotationAngle.East, constructionCell.CurrentSectorID);
				if (eWallTypeRelativeToRotation2.HasValue)
				{
					list.Add(new CellConstructionStruct(ERotationAngle.East, eWallTypeRelativeToRotation2.Value));
				}
				EWallType? eWallTypeRelativeToRotation3 = GetEWallTypeRelativeToRotation(x, y, ERotationAngle.South, constructionCell.CurrentSectorID);
				if (eWallTypeRelativeToRotation3.HasValue)
				{
					list.Add(new CellConstructionStruct(ERotationAngle.South, eWallTypeRelativeToRotation3.Value));
				}
				EWallType? eWallTypeRelativeToRotation4 = GetEWallTypeRelativeToRotation(x, y, ERotationAngle.West, constructionCell.CurrentSectorID);
				if (eWallTypeRelativeToRotation4.HasValue)
				{
					list.Add(new CellConstructionStruct(ERotationAngle.West, eWallTypeRelativeToRotation4.Value));
				}
				constructionCell.UpdateWallsStruct(list, container, room);
				list.Clear();
			}
		}
	}

	public void GenerateWallsForEverything(GameObject container, RoomBuilding room)
	{
		List<CellConstructionStruct> list = new List<CellConstructionStruct>();
		for (int i = 0; i < GridWidth; i++)
		{
			for (int j = 0; j < GridHeight; j++)
			{
				ConstructionCell constructionCell = _cellsGrid[i, j];
				if ((object)constructionCell != null)
				{
					EWallType? eWallTypeRelativeToRotation = GetEWallTypeRelativeToRotation(i, j, ERotationAngle.Nord, constructionCell.CurrentSectorID);
					if (eWallTypeRelativeToRotation.HasValue)
					{
						list.Add(new CellConstructionStruct(ERotationAngle.Nord, eWallTypeRelativeToRotation.Value));
					}
					EWallType? eWallTypeRelativeToRotation2 = GetEWallTypeRelativeToRotation(i, j, ERotationAngle.East, constructionCell.CurrentSectorID);
					if (eWallTypeRelativeToRotation2.HasValue)
					{
						list.Add(new CellConstructionStruct(ERotationAngle.East, eWallTypeRelativeToRotation2.Value));
					}
					EWallType? eWallTypeRelativeToRotation3 = GetEWallTypeRelativeToRotation(i, j, ERotationAngle.South, constructionCell.CurrentSectorID);
					if (eWallTypeRelativeToRotation3.HasValue)
					{
						list.Add(new CellConstructionStruct(ERotationAngle.South, eWallTypeRelativeToRotation3.Value));
					}
					EWallType? eWallTypeRelativeToRotation4 = GetEWallTypeRelativeToRotation(i, j, ERotationAngle.West, constructionCell.CurrentSectorID);
					if (eWallTypeRelativeToRotation4.HasValue)
					{
						list.Add(new CellConstructionStruct(ERotationAngle.West, eWallTypeRelativeToRotation4.Value));
					}
					constructionCell.UpdateWallsStruct(list, container, room);
					list.Clear();
				}
			}
		}
	}

	private EWallType? GetEWallTypeRelativeToRotation(int x, int z, ERotationAngle direction, int sectionID)
	{
		switch (direction)
		{
		case ERotationAngle.Nord:
			if (z + 1 >= GridHeight)
			{
				return null;
			}
			break;
		case ERotationAngle.East:
			if (x + 1 >= GridWidth)
			{
				return null;
			}
			break;
		case ERotationAngle.South:
			if (z - 1 < 0)
			{
				return null;
			}
			break;
		case ERotationAngle.West:
			if (x - 1 < 0)
			{
				return null;
			}
			break;
		}
		bool flag = false;
		switch (direction)
		{
		case ERotationAngle.Nord:
			if ((object)_cellsGrid[x, z + 1] == null)
			{
				return null;
			}
			flag = _cellsGrid[x, z + 1].CurrentSectorID == sectionID || (_cellsGrid[x, z + 1].HasTempSector && _cellsGrid[x, z].CurrentSectorID == 0);
			break;
		case ERotationAngle.East:
			if ((object)_cellsGrid[x + 1, z] == null)
			{
				return null;
			}
			flag = _cellsGrid[x + 1, z].CurrentSectorID == sectionID || (_cellsGrid[x + 1, z].HasTempSector && _cellsGrid[x, z].CurrentSectorID == 0);
			break;
		case ERotationAngle.South:
			if ((object)_cellsGrid[x, z - 1] == null)
			{
				return null;
			}
			flag = _cellsGrid[x, z - 1].CurrentSectorID == sectionID || (_cellsGrid[x, z - 1].HasTempSector && _cellsGrid[x, z].CurrentSectorID == 0);
			break;
		case ERotationAngle.West:
			if ((object)_cellsGrid[x - 1, z] == null)
			{
				return null;
			}
			flag = _cellsGrid[x - 1, z].CurrentSectorID == sectionID || (_cellsGrid[x - 1, z].HasTempSector && _cellsGrid[x, z].CurrentSectorID == 0);
			break;
		}
		if (flag)
		{
			return null;
		}
		bool flag2 = false;
		switch (direction)
		{
		case ERotationAngle.Nord:
			if ((object)_cellsGrid[x + 1, z + 1] == null)
			{
				return null;
			}
			flag2 = x + 1 >= GridWidth || _cellsGrid[x + 1, z + 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.East:
			if ((object)_cellsGrid[x + 1, z - 1] == null)
			{
				return null;
			}
			flag2 = z - 1 < 0 || _cellsGrid[x + 1, z - 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.South:
			if ((object)_cellsGrid[x - 1, z - 1] == null)
			{
				return null;
			}
			flag2 = x - 1 < 0 || _cellsGrid[x - 1, z - 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.West:
			if ((object)_cellsGrid[x - 1, z + 1] == null)
			{
				return null;
			}
			flag2 = z + 1 >= GridHeight || _cellsGrid[x - 1, z + 1].CurrentSectorID != sectionID;
			break;
		}
		bool flag3 = false;
		switch (direction)
		{
		case ERotationAngle.Nord:
			if ((object)_cellsGrid[x - 1, z + 1] == null)
			{
				return null;
			}
			flag3 = x - 1 < 0 || _cellsGrid[x - 1, z + 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.East:
			if ((object)_cellsGrid[x + 1, z + 1] == null)
			{
				return null;
			}
			flag3 = z + 1 >= GridHeight || _cellsGrid[x + 1, z + 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.South:
			if ((object)_cellsGrid[x + 1, z - 1] == null)
			{
				return null;
			}
			flag3 = x + 1 >= GridWidth || _cellsGrid[x + 1, z - 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.West:
			if ((object)_cellsGrid[x - 1, z - 1] == null)
			{
				return null;
			}
			flag3 = z - 1 < 0 || _cellsGrid[x - 1, z - 1].CurrentSectorID != sectionID;
			break;
		}
		bool flag4 = false;
		switch (direction)
		{
		case ERotationAngle.Nord:
			if ((object)_cellsGrid[x + 1, z] == null)
			{
				return null;
			}
			flag4 = x + 1 >= GridWidth || _cellsGrid[x + 1, z].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.East:
			if ((object)_cellsGrid[x, z - 1] == null)
			{
				return null;
			}
			flag4 = z - 1 < 0 || _cellsGrid[x, z - 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.South:
			if ((object)_cellsGrid[x - 1, z] == null)
			{
				return null;
			}
			flag4 = x - 1 < 0 || _cellsGrid[x - 1, z].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.West:
			if ((object)_cellsGrid[x, z + 1] == null)
			{
				return null;
			}
			flag4 = z + 1 >= GridHeight || _cellsGrid[x, z + 1].CurrentSectorID != sectionID;
			break;
		}
		bool flag5 = false;
		switch (direction)
		{
		case ERotationAngle.Nord:
			if ((object)_cellsGrid[x - 1, z] == null)
			{
				return null;
			}
			flag5 = x - 1 < 0 || _cellsGrid[x - 1, z].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.East:
			if ((object)_cellsGrid[x, z + 1] == null)
			{
				return null;
			}
			flag5 = z + 1 >= GridHeight || _cellsGrid[x, z + 1].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.South:
			if ((object)_cellsGrid[x + 1, z] == null)
			{
				return null;
			}
			flag5 = x + 1 >= GridWidth || _cellsGrid[x + 1, z].CurrentSectorID != sectionID;
			break;
		case ERotationAngle.West:
			if ((object)_cellsGrid[x, z - 1] == null)
			{
				return null;
			}
			flag5 = z - 1 < 0 || _cellsGrid[x, z - 1].CurrentSectorID != sectionID;
			break;
		}
		if (flag3 && flag4 && !flag5)
		{
			return EWallType.LeftInteriorCorner;
		}
		if (flag2 && !flag4 && flag5)
		{
			return EWallType.RightInteriorCorner;
		}
		if (flag4 && !flag5)
		{
			return EWallType.RightSwiftCorner;
		}
		if (!flag4 && flag5)
		{
			return EWallType.LeftSwiftCorner;
		}
		if (flag4 && flag5)
		{
			return EWallType.InteriorCorner;
		}
		if (flag2 && flag3)
		{
			return EWallType.Simple;
		}
		if (!flag4 && !flag5)
		{
			if (flag2 && !flag3)
			{
				return EWallType.RightExteriorCorner;
			}
			if (flag3 && !flag2)
			{
				return EWallType.LeftExteriorCorner;
			}
			return EWallType.ExteriorCorner;
		}
		return null;
	}

	private void OnDrawGizmosSelected()
	{
		MonoSingleton<ConstructionParams>.TryGetInstance(out var _);
	}
}
