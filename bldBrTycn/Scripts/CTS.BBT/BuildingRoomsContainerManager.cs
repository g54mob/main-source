using System;
using System.Collections;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

public class BuildingRoomsContainerManager : MonoSingleton<BuildingRoomsContainerManager>
{
	private List<BuildingRoomContainer> _roomManagers = new List<BuildingRoomContainer>();

	private int _currentStage;

	private int _cachedTotalCells;

	public BuildingRoomContainer CurrentRoomManager
	{
		get
		{
			if (_roomManagers == null)
			{
				return null;
			}
			return _roomManagers[CurrentStage];
		}
	}

	public int RoomContainerCount => _roomManagers.Count;

	public ReadOnlyList<BuildingRoomContainer> RoomManagers => _roomManagers;

	public int CurrentStage
	{
		get
		{
			return _currentStage;
		}
		set
		{
			if (value != _currentStage)
			{
				_currentStage = value;
				BuildingRoomsContainerManager.OnStageChanged?.Invoke(_currentStage);
			}
		}
	}

	public BuildingRoomContainer CurrentContainer => _roomManagers[CurrentStage];

	public int TotalCellsInBar => _cachedTotalCells;

	[field: ShowNonSerializedField]
	public EAccess AllRoomHaveExteriorAccess { get; private set; }

	public static event Action<int> OnStageChanged;

	public static event Action<int> OnCellsCountChanged;

	public static event Action<EAccess> OnAccessToExteriorChanged;

	private void Start()
	{
		UpdatedAllRoomManager();
		StartCoroutine(CheckAccesssDelayed());
		RoomBuilding.OnRoomUpdated += UpdateTotalCells;
		SurfaceObjectPaintingSystem.OnPaintingUpdated += OnPaintingUpdated;
		UpdateTotalCells();
	}

	private void OnPaintingUpdated(int roomID)
	{
		if (!(CurrentRoomManager == null) && CurrentRoomManager.GeneratedRooms.ContainsKey(roomID))
		{
			CurrentRoomManager.GeneratedRooms[roomID].CheckStyle();
		}
	}

	private void OnDisable()
	{
	}

	private IEnumerator CheckAccesssDelayed()
	{
		yield return Coroutines.WaitForSecondsUnscaled(0.2f);
		OnAccessCheck();
	}

	public void ClearRoomList()
	{
		_roomManagers.Clear();
	}

	public void AddToRoomList(BuildingRoomContainer roomManager)
	{
		for (int i = 0; i < _roomManagers.Count; i++)
		{
			if (roomManager.transform.position.y - _roomManagers[i].transform.position.y < 0f)
			{
				_roomManagers.Insert(i, roomManager);
				roomManager.UpdatedAllRoom();
				return;
			}
		}
		_roomManagers.Add(roomManager);
		roomManager.UpdatedAllRoom();
	}

	public void UpdatedAllRoomManager()
	{
		for (int i = 0; i < _roomManagers.Count; i++)
		{
			_roomManagers[i].UpdatedAllRoom();
		}
	}

	public BuildingRoomContainer GetRoomContainerAt(int index)
	{
		if (index < 0 || index >= _roomManagers.Count)
		{
			return null;
		}
		return _roomManagers[index];
	}

	public void ForceNavmeshRebake()
	{
		for (int i = 0; i < _roomManagers.Count; i++)
		{
			_roomManagers[i].ForceNavmeshRebake();
		}
	}

	[Button(null, EButtonEnableMode.Always)]
	private void TestCanAccessToExterior()
	{
		OnAccessCheck();
		Debug.Log("Acces : " + AllRoomHaveExteriorAccess);
	}

	private EAccess CheckIfCanAccessToExterior()
	{
		if (RoomContainerCount <= 0)
		{
			return EAccess.Empty;
		}
		EAccess eAccess = EAccess.Empty;
		foreach (BuildingRoomContainer roomManager in _roomManagers)
		{
			switch (roomManager.CheckAccessibleToExterior())
			{
			case EAccess.Inaccessible:
				return EAccess.Inaccessible;
			case EAccess.WrongAccess:
				if (eAccess == EAccess.Empty || eAccess == EAccess.Accessible)
				{
					eAccess = EAccess.WrongAccess;
				}
				break;
			case EAccess.Accessible:
				if (eAccess == EAccess.Empty)
				{
					eAccess = EAccess.Accessible;
				}
				break;
			}
		}
		return eAccess;
	}

	private void OnAccessCheck()
	{
		BuildableLinks.UpdateAll();
		EAccess allRoomHaveExteriorAccess = CheckIfCanAccessToExterior();
		AllRoomHaveExteriorAccess = allRoomHaveExteriorAccess;
		BuildingRoomsContainerManager.OnAccessToExteriorChanged?.Invoke(AllRoomHaveExteriorAccess);
	}

	private void UpdateTotalCells(RoomBuilding room = null)
	{
		_cachedTotalCells = CalculateTotalCells();
		BuildingRoomsContainerManager.OnCellsCountChanged?.Invoke(_cachedTotalCells);
	}

	private int CalculateTotalCells()
	{
		int num = 0;
		if (CurrentContainer.GeneratedRooms.Count <= 1)
		{
			return 0;
		}
		foreach (int key in CurrentContainer.GeneratedRooms.Keys)
		{
			if (key != 0)
			{
				num += CurrentContainer.GeneratedRooms[key].FloorTiles.Count;
			}
		}
		return num;
	}

	protected override void SingletonAwake()
	{
		BuildableElement.Destroyed += BuildableElement_Changed;
		BuildablePlacementSystem.OnBuildablePlaced += BuildableElement_Changed;
		NavMeshRebuilder.NavMeshRebuilt += NavMeshRebuilder_NavMeshRebuilt;
	}

	private void NavMeshRebuilder_NavMeshRebuilt(NavMeshRebuildInfo obj)
	{
		OnAccessCheck();
	}

	private void BuildableElement_Changed(BuildableElement obj)
	{
		OnAccessCheck();
	}

	private void Room_Changed(RoomBuilding obj)
	{
		OnAccessCheck();
	}

	public int GetContainerIndex(BuildingRoomContainer container)
	{
		return _roomManagers.IndexOf(container);
	}

	protected override void OnSingletonDestroy()
	{
		NavMeshRebuilder.NavMeshRebuilt -= NavMeshRebuilder_NavMeshRebuilt;
		SurfaceObjectPaintingSystem.OnPaintingUpdated -= OnPaintingUpdated;
		RoomBuilding.OnRoomUpdated -= UpdateTotalCells;
		BuildableElement.Destroyed -= BuildableElement_Changed;
		BuildablePlacementSystem.OnBuildablePlaced -= BuildableElement_Changed;
	}
}
