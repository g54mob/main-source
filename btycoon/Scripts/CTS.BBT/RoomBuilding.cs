using System;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class RoomBuilding : CTSBehaviour
{
	private readonly List<BuildingFloor> _floorTiles = new List<BuildingFloor>();

	private readonly List<BuildingWall> _wallTiles = new List<BuildingWall>();

	[InjectScope(EGetScope.Children)]
	[SerializeField]
	[Inject(false)]
	private NavMeshRebuilder _navMeshRebuilder;

	private static NavMeshPath _dummyPath;

	[field: SerializeField]
	public Transform FloorContainer { get; private set; }

	[field: SerializeField]
	public Transform WallsContainer { get; private set; }

	public ReadOnlyList<BuildingFloor> FloorTiles => new ReadOnlyList<BuildingFloor>(_floorTiles);

	public ReadOnlyList<BuildingWall> WallTiles => new ReadOnlyList<BuildingWall>(_wallTiles);

	public bool IsVisible { get; private set; }

	[field: SerializeField]
	[field: NaughtyAttributes.ReadOnly]
	public BuildingRoomContainer Container { get; private set; }

	public NavigationArea NavArea
	{
		get
		{
			return _navMeshRebuilder.Area;
		}
		set
		{
			_navMeshRebuilder.Area = value;
		}
	}

	public int RoomIndex { get; set; }

	public int GetTotalInteriorCells
	{
		get
		{
			int num = 0;
			foreach (BuildingFloor floorTile in FloorTiles)
			{
				if (floorTile.PaintMaterial.HasValue)
				{
					num++;
				}
			}
			return num;
		}
	}

	public float GetTotalStyleValue
	{
		get
		{
			float num = 0f;
			foreach (BuildingFloor floorTile in FloorTiles)
			{
				if (floorTile.PaintMaterial.HasValue)
				{
					num += (float)MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[floorTile.PaintMaterial.Value].PurchasePrice;
				}
			}
			foreach (BuildingWall wallTile in WallTiles)
			{
				if (wallTile.PaintMaterial.HasValue)
				{
					num += (float)MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[wallTile.PaintMaterial.Value].PurchasePrice;
				}
			}
			return num;
		}
	}

	public float GetTotalStylePrestige
	{
		get
		{
			float num = 0f;
			foreach (BuildingFloor floorTile in FloorTiles)
			{
				if (floorTile.PaintMaterial.HasValue)
				{
					num += MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[floorTile.PaintMaterial.Value].PrestigeValue;
				}
			}
			foreach (BuildingWall wallTile in WallTiles)
			{
				if (wallTile.PaintMaterial.HasValue)
				{
					num += MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[wallTile.PaintMaterial.Value].PrestigeValue;
				}
			}
			return num;
		}
	}

	public static event Action<RoomBuilding> OnRoomCreated;

	public static event Action<RoomBuilding> OnRoomDestroyed;

	public static event Action<RoomBuilding> OnRoomUpdated;

	public static event Action<RoomBuilding, RoomStyleInformation> OnRoomStyleChanged;

	public event Action Updated;

	public event Action Destroyed;

	public event Action<bool> ChangingVisibility;

	public static NavMeshPath GetDummyPath()
	{
		return _dummyPath ?? (_dummyPath = new NavMeshPath());
	}

	public void Initialize(BuildingRoomContainer container)
	{
		Container = container;
		IsVisible = container.IsVisible;
	}

	private void Start()
	{
		_navMeshRebuilder.RebuildNavMesh();
		RoomBuilding.OnRoomCreated?.Invoke(this);
		CheckStyle();
	}

	public void CheckStyle()
	{
		RoomStyleInformation arg = new RoomStyleInformation
		{
			WallsStyles = new Dictionary<EBarStyle, int>(),
			FloosStyles = new Dictionary<EBarStyle, int>()
		};
		for (int i = 0; i < _wallTiles.Count; i++)
		{
			if (_wallTiles[i].PaintMaterial.HasValue)
			{
				EBarStyle style = MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[_wallTiles[i].PaintMaterial.Value].Style;
				if (!arg.WallsStyles.ContainsKey(style))
				{
					arg.WallsStyles.Add(style, 0);
				}
				arg.WallsStyles[style]++;
			}
		}
		for (int j = 0; j < _floorTiles.Count; j++)
		{
			if (_floorTiles[j].PaintMaterial.HasValue)
			{
				EBarStyle style = MonoSingleton<SurfaceObjectPaintingSystem>.Instance.FloorMaterialsSOs[_floorTiles[j].PaintMaterial.Value].Style;
				if (!arg.FloosStyles.ContainsKey(style))
				{
					arg.FloosStyles.Add(style, 0);
				}
				arg.FloosStyles[style]++;
			}
		}
		RoomBuilding.OnRoomStyleChanged?.Invoke(this, arg);
	}

	public void AddFloorTile(BuildingFloor floor)
	{
		if (!_floorTiles.Contains(floor))
		{
			_floorTiles.Add(floor);
		}
	}

	public void RemoveFloorTile(BuildingFloor floor)
	{
		_floorTiles.Remove(floor);
	}

	public void AddWallTile(BuildingWall wall)
	{
		if (!_wallTiles.Contains(wall))
		{
			_wallTiles.Add(wall);
		}
	}

	public void RemoveWallTile(BuildingWall wall)
	{
		_wallTiles.Remove(wall);
	}

	private void OnDestroy()
	{
		if (base.gameObject.scene.isLoaded)
		{
			RoomStyleInformation arg = new RoomStyleInformation
			{
				WallsStyles = new Dictionary<EBarStyle, int>(),
				FloosStyles = new Dictionary<EBarStyle, int>()
			};
			RoomBuilding.OnRoomStyleChanged?.Invoke(this, arg);
			RoomBuilding.OnRoomDestroyed?.Invoke(this);
			this.Destroyed?.Invoke();
		}
	}

	public void RoomUpdated()
	{
		_navMeshRebuilder.RebuildNavMesh();
		CheckStyle();
		RoomBuilding.OnRoomUpdated?.Invoke(this);
		this.Updated?.Invoke();
	}

	public EAccess CheckIfCanAccessToExterior()
	{
		if (_wallTiles.Count <= 0)
		{
			return EAccess.Inaccessible;
		}
		if (!MonoSingleton<ConstructionParams>.InstanceExists())
		{
			return EAccess.Inaccessible;
		}
		Vector3 position = EntranceResolver.ExitNavMeshCheck.position;
		NavMeshPath dummyPath = GetDummyPath();
		if (!MonoSingleton<ConstructionParams>.Instance.ExitMasks.TryGetValue(NavArea, out var value))
		{
			return EAccess.Inaccessible;
		}
		bool flag = false;
		foreach (BuildingWall wallTile in _wallTiles)
		{
			bool flag2;
			switch (wallTile.LinkedCell?.BuildableElement?.BuildableType)
			{
			case BuildableElementSO.EBuildableType.Door:
			case BuildableElementSO.EBuildableType.Arch:
				flag2 = true;
				break;
			default:
				flag2 = false;
				break;
			}
			if (flag2)
			{
				flag = true;
				if (NavMesh.CalculatePath(wallTile.LinkedCell.transform.position, position, value, dummyPath) && dummyPath.status == NavMeshPathStatus.PathComplete)
				{
					return EAccess.Accessible;
				}
			}
		}
		if (!flag)
		{
			return EAccess.Inaccessible;
		}
		return EAccess.WrongAccess;
	}

	public void MergeOtherRoomToThis(RoomBuilding otherRoom)
	{
		while (otherRoom.FloorContainer.childCount > 0)
		{
			if (otherRoom.FloorContainer.GetChild(0).gameObject.TryGetComponent<BuildingFloor>(out var component))
			{
				component.LinkedCell.BuildedSectorID = RoomIndex;
				component.LinkedRoom = this;
				component.LinkedCell.InteriorState = ((RoomIndex != 0) ? ConstructionCell.EInteriorState.IsInterior : ConstructionCell.EInteriorState.None);
			}
		}
		while (otherRoom.WallsContainer.childCount > 0)
		{
			if (otherRoom.WallsContainer.GetChild(0).gameObject.TryGetComponent<BuildingWall>(out var component2))
			{
				component2.LinkedCell.BuildedSectorID = RoomIndex;
				component2.LinkedCell.InteriorState = ((RoomIndex != 0) ? ConstructionCell.EInteriorState.IsInterior : ConstructionCell.EInteriorState.None);
				component2.LinkedRoom = this;
			}
		}
		for (int i = 0; i < WallsContainer.childCount; i++)
		{
			WallsContainer.GetChild(i).GetComponent<BuildingWall>().LinkedCell.RefreshBuildable(canDestroy: true);
		}
		RoomUpdated();
	}

	public bool EmptyRoomContent()
	{
		if (FloorContainer.childCount == 0)
		{
			return WallsContainer.childCount == 0;
		}
		return false;
	}

	public int SelectWalls(int neighborCellIndex, bool unselect)
	{
		List<SelectableWall> list = new List<SelectableWall>();
		if (WallsContainer == null)
		{
			Debug.LogWarning("No Wall Container Founded room : " + base.gameObject.name);
			return 0;
		}
		for (int i = 0; i < WallsContainer.childCount; i++)
		{
			if (!WallsContainer.GetChild(i).gameObject.TryGetComponent<BuildingWall>(out var component))
			{
				continue;
			}
			ConstructionCell neighborCell = component.GetNeighborCell();
			if (neighborCell != null && neighborCell.BuildedSectorID == neighborCellIndex && component.TryGetComponent<SelectableWall>(out var component2))
			{
				list.Add(component2);
				if (neighborCell.GetOppositeWallFromWall(component).TryGetComponent<SelectableWall>(out var component3))
				{
					list.Add(component3);
				}
			}
		}
		if (unselect)
		{
			MonoSingleton<WallSelectionManager>.Instance.RemoveSelectable(list.ToArray());
		}
		else
		{
			MonoSingleton<WallSelectionManager>.Instance.AddSelectable(list.ToArray());
		}
		return list.Count;
	}

	public static bool TryGetRoomAt(Vector3 position, out RoomBuilding room)
	{
		room = null;
		if (!Physics.Raycast(position + Vector3.up * 0.5f, layerMask: 1 << LayerMask.NameToLayer("Floor"), direction: Vector3.down, hitInfo: out var hitInfo, maxDistance: 2f) || !hitInfo.collider.TryGetComponent<BuildingFloor>(out var component))
		{
			if (!MonoSingleton<BuildingRoomsContainerManager>.InstanceExists())
			{
				return room;
			}
			foreach (BuildingRoomContainer roomManager in MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers)
			{
				if (position.y - roomManager.transform.position.y + 2.2f < 0f)
				{
					room = roomManager.GetRoomByIndex(0);
					return room;
				}
			}
			if (MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers.Count > 0)
			{
				room = MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers[^1].GetRoomByIndex(0);
			}
			return room;
		}
		room = component.LinkedRoom;
		return true;
	}

	public void ChangeVisibility(bool visible)
	{
		IsVisible = visible;
		this.ChangingVisibility?.Invoke(visible);
	}

	[Button(null, EButtonEnableMode.Always)]
	private void TestAddChild()
	{
		new GameObject().transform.SetParent(base.transform);
	}

	public bool CheckSpace()
	{
		foreach (BuildingFloor floorTile in _floorTiles)
		{
			if (!floorTile.LinkedCell.LinkedGrid.CheckCellEnvironnement(floorTile.LinkedCell.Coordinate.x, floorTile.LinkedCell.Coordinate.y, floorTile.LinkedCell.CurrentSectorID))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsInOnePiece()
	{
		Dictionary<Vector2Int, BuildingFloor> dictionary = new Dictionary<Vector2Int, BuildingFloor>();
		BuildingFloor buildingFloor = null;
		foreach (BuildingFloor floorTile in _floorTiles)
		{
			if (!floorTile.LinkedCell.HasTempSector)
			{
				if (buildingFloor == null)
				{
					buildingFloor = floorTile;
				}
				else
				{
					dictionary.Add(floorTile.LinkedCell.Coordinate, floorTile);
				}
			}
		}
		if (buildingFloor == null)
		{
			return true;
		}
		Dictionary<Vector2Int, BuildingFloor> dictionary2 = new Dictionary<Vector2Int, BuildingFloor>();
		dictionary2.Add(buildingFloor.LinkedCell.Coordinate, buildingFloor);
		while (dictionary2.Count > 0)
		{
			foreach (Vector2Int key in new Dictionary<Vector2Int, BuildingFloor>(dictionary2).Keys)
			{
				dictionary2.Remove(key);
				if (dictionary.ContainsKey(key + Vector2Int.up) && !dictionary[key + Vector2Int.up].LinkedCell.HasTempSector)
				{
					dictionary2.Add(key + Vector2Int.up, dictionary[key + Vector2Int.up]);
					dictionary.Remove(key + Vector2Int.up);
				}
				if (dictionary.ContainsKey(key + Vector2Int.down) && !dictionary[key + Vector2Int.down].LinkedCell.HasTempSector)
				{
					dictionary2.Add(key + Vector2Int.down, dictionary[key + Vector2Int.down]);
					dictionary.Remove(key + Vector2Int.down);
				}
				if (dictionary.ContainsKey(key + Vector2Int.left) && !dictionary[key + Vector2Int.left].LinkedCell.HasTempSector)
				{
					dictionary2.Add(key + Vector2Int.left, dictionary[key + Vector2Int.left]);
					dictionary.Remove(key + Vector2Int.left);
				}
				if (dictionary.ContainsKey(key + Vector2Int.right) && !dictionary[key + Vector2Int.right].LinkedCell.HasTempSector)
				{
					dictionary2.Add(key + Vector2Int.right, dictionary[key + Vector2Int.right]);
					dictionary.Remove(key + Vector2Int.right);
				}
			}
		}
		if (dictionary.Count > 0)
		{
			return false;
		}
		return true;
	}
}
