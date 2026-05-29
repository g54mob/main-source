using System;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

public class BuildingRoomContainer : MonoBehaviour
{
	[SerializeField]
	private RoomBuilding _roomPrefab;

	[SerializeField]
	private Transform _roomsContainer;

	[SerializeField]
	[NavArea(false)]
	private int _exteriorNavigationArea;

	private Dictionary<int, RoomBuilding> _generatedRooms = new Dictionary<int, RoomBuilding>();

	private List<int> _roomsToDestroy = new List<int>();

	private List<int> _modifiedRooms = new List<int>();

	public ConstructionGrid Grid;

	private int? _nextFreeIndex;

	public ReadOnlyDictionary<int, RoomBuilding> GeneratedRooms => _generatedRooms;

	public bool IsVisible { get; private set; }

	public int NextFreeIndex
	{
		get
		{
			if (!_nextFreeIndex.HasValue)
			{
				_nextFreeIndex = 0;
				while (_generatedRooms.ContainsKey(_nextFreeIndex.Value))
				{
					_nextFreeIndex++;
				}
			}
			return _nextFreeIndex.Value;
		}
	}

	public event Action<bool> ChangedVisibility;

	private void Awake()
	{
		CreateNewRoom().NavArea = _exteriorNavigationArea;
	}

	public void AddModifiedRoomIndex(int index)
	{
		if (!_modifiedRooms.Contains(index))
		{
			_modifiedRooms.Add(index);
		}
	}

	public void SetAssignationArray(int[] array)
	{
		if (array == null)
		{
			return;
		}
		SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
		int num = 0;
		foreach (int key in _generatedRooms.Keys)
		{
			sortedDictionary.Add(key, array[num]);
			num++;
			if (num >= array.Length)
			{
				break;
			}
		}
		foreach (int key2 in sortedDictionary.Keys)
		{
			_generatedRooms[key2].NavArea = sortedDictionary[key2];
		}
	}

	public int[] GetAssignationArray()
	{
		int[] array = new int[_generatedRooms.Count];
		int num = 0;
		SortedDictionary<int, RoomBuilding> sortedDictionary = new SortedDictionary<int, RoomBuilding>(_generatedRooms);
		foreach (int key in sortedDictionary.Keys)
		{
			array[num] = sortedDictionary[key].NavArea.Area;
			num++;
		}
		return array;
	}

	public void UpdatedAllRoom()
	{
		foreach (KeyValuePair<int, RoomBuilding> generatedRoom in _generatedRooms)
		{
			generatedRoom.Deconstruct(out var _, out var value);
			value.RoomUpdated();
		}
	}

	public void UpdateRooms()
	{
		foreach (int modifiedRoom in _modifiedRooms)
		{
			if (_generatedRooms.ContainsKey(modifiedRoom))
			{
				_generatedRooms[modifiedRoom].RoomUpdated();
			}
		}
		_modifiedRooms.Clear();
		foreach (var (item, roomBuilding2) in _generatedRooms)
		{
			if (roomBuilding2 != null && roomBuilding2.EmptyRoomContent())
			{
				_roomsToDestroy.Add(item);
			}
		}
		if (_roomsToDestroy.Count != 0)
		{
			while (_roomsToDestroy.Count > 0)
			{
				RoomBuilding room = _generatedRooms[_roomsToDestroy[0]];
				DestroyRoom(room);
				_roomsToDestroy.RemoveAt(0);
			}
		}
	}

	[Button(null, EButtonEnableMode.Always)]
	public RoomBuilding CreateNewRoom()
	{
		return CreateNewRoomWithIndex(NextFreeIndex);
	}

	public RoomBuilding CreateNewRoomWithIndex(int index)
	{
		if (_generatedRooms.ContainsKey(index))
		{
			throw new Exception($"Cannot create room with index {index} as it already exists");
		}
		RoomBuilding roomBuilding = CTSFactory.Instantiate(_roomPrefab, base.transform, instantiateInWorldSpace: false, true);
		int num = 0;
		foreach (var (num3, _) in _generatedRooms)
		{
			if (index < num3)
			{
				break;
			}
			num++;
		}
		roomBuilding.transform.SetSiblingIndex(num);
		roomBuilding.RoomIndex = index;
		roomBuilding.gameObject.name = "Room - " + index.ToString("D3");
		roomBuilding.Initialize(this);
		_generatedRooms[roomBuilding.RoomIndex] = roomBuilding;
		_nextFreeIndex = null;
		return roomBuilding;
	}

	public bool DestroyRoom(RoomBuilding room)
	{
		if (room.RoomIndex == 0)
		{
			return false;
		}
		_generatedRooms.Remove(room.RoomIndex);
		_nextFreeIndex = null;
		UnityEngine.Object.Destroy(room.gameObject);
		return true;
	}

	public void ForceNavmeshRebake()
	{
		foreach (int key in _generatedRooms.Keys)
		{
			_generatedRooms[key].RoomUpdated();
		}
	}

	public bool DestroyRoomByIndex(int index)
	{
		if (!_generatedRooms.ContainsKey(index))
		{
			return false;
		}
		return DestroyRoom(_generatedRooms[index]);
	}

	public RoomBuilding GetRoomByIndex(int index)
	{
		if (!_generatedRooms.ContainsKey(index))
		{
			return null;
		}
		return _generatedRooms[index];
	}

	public bool ExistRoomInIndex(int index)
	{
		return _generatedRooms.ContainsKey(index);
	}

	public bool MergeRoom(int firstIndex, int secondIndex)
	{
		if (!_generatedRooms.ContainsKey(firstIndex))
		{
			return false;
		}
		if (!_generatedRooms.ContainsKey(secondIndex))
		{
			return false;
		}
		if (firstIndex == secondIndex)
		{
			return false;
		}
		int key = ((firstIndex < secondIndex) ? firstIndex : secondIndex);
		int key2 = ((firstIndex > secondIndex) ? firstIndex : secondIndex);
		_generatedRooms[key].MergeOtherRoomToThis(_generatedRooms[key2]);
		_nextFreeIndex = null;
		return DestroyRoom(_generatedRooms[key2]);
	}

	public void ChangeVisibility(bool visible)
	{
		if (IsVisible == visible)
		{
			return;
		}
		IsVisible = visible;
		foreach (KeyValuePair<int, RoomBuilding> generatedRoom in _generatedRooms)
		{
			generatedRoom.Value.ChangeVisibility(visible);
		}
		this.ChangedVisibility?.Invoke(visible);
	}

	public EAccess CheckAccessibleToExterior()
	{
		if (_generatedRooms.Count <= 1)
		{
			return EAccess.Empty;
		}
		bool flag = false;
		foreach (int key in _generatedRooms.Keys)
		{
			if (key != 0)
			{
				switch (_generatedRooms[key].CheckIfCanAccessToExterior())
				{
				case EAccess.Inaccessible:
					return EAccess.Inaccessible;
				case EAccess.WrongAccess:
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			return EAccess.Accessible;
		}
		return EAccess.WrongAccess;
	}
}
