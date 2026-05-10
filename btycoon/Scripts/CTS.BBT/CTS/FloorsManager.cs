using System;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class FloorsManager : MonoSingleton<FloorsManager>
	{
		[SerializeField]
		private int _startingFloor;

		[ShowNonSerializedField]
		private int _currentFloor;

		[field: SerializeField]
		public Floor[] Floors { get; private set; }

		[field: SerializeField]
		public bool Debug { get; private set; }

		public static Floor CurrentFloor { get; private set; }

		public Floor this[int p_index] => Floors[p_index];

		public static event Action<Floor> ChangingFloor;

		public IEnumerable<Room> Rooms()
		{
			Floor[] floors = Floors;
			foreach (Floor floor in floors)
			{
				Room[] rooms = floor.Rooms;
				for (int j = 0; j < rooms.Length; j++)
				{
					yield return rooms[j];
				}
			}
		}

		protected override void SingletonAwake()
		{
			MonoSingleton<BuildingRoomsContainerManager>.Instance.ClearRoomList();
			for (int i = 0; i < Floors.Length; i++)
			{
				BuildingRoomContainer componentInChildren = Floors[i].GetComponentInChildren<BuildingRoomContainer>();
				MonoSingleton<BuildingRoomsContainerManager>.Instance.AddToRoomList(componentInChildren);
			}
			MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentStage = _startingFloor;
		}

		public bool TryGetRoom(int floorId, string roomKey, out Room outRoom)
		{
			outRoom = null;
			if (!floorId.IsCorrectArrayIndex(Floors))
			{
				return false;
			}
			return Floors[floorId].TryGetRoom(roomKey, out outRoom);
		}

		private void Start()
		{
			if (Floors.Length == 0)
			{
				Floors = GetFloorComponents();
			}
			for (int i = 0; i < Floors.Length; i++)
			{
				Floors[i].AssignID(i);
			}
			if (!_startingFloor.IsCorrectArrayIndex(Floors))
			{
				UnityEngine.Debug.LogError("Wrong starting floor.", base.gameObject);
				return;
			}
			_currentFloor = _startingFloor;
			CurrentFloor = Floors[_currentFloor];
			FloorsManager.ChangingFloor?.Invoke(CurrentFloor);
			FurnitureShop.FurnitureShopStatusChanged += SetGridVisibility;
			FloorChangeInputsObserver.NextFloorInputPressed += NextFloor;
			FloorChangeInputsObserver.PreviousFloorInputPressed += PreviousFloor;
			Room.AnyRoomChange += OnRoomStatusChanged;
		}

		private Floor[] GetFloorComponents()
		{
			SortedList<float, Floor> sortedList = new SortedList<float, Floor>();
			foreach (Transform child in base.transform.GetChildren())
			{
				if (child.TryGetComponent<Floor>(out var component))
				{
					sortedList.Add(component.transform.position.y, component);
				}
			}
			return sortedList.Values.ToArray();
		}

		protected override void OnSingletonDestroy()
		{
			FurnitureShop.FurnitureShopStatusChanged -= SetGridVisibility;
			FloorChangeInputsObserver.NextFloorInputPressed -= NextFloor;
			FloorChangeInputsObserver.PreviousFloorInputPressed -= PreviousFloor;
			Room.AnyRoomChange -= OnRoomStatusChanged;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void PopulateFloors()
		{
			Floors = GetComponentsInChildren<Floor>();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void PreviousFloor()
		{
			if (_currentFloor > 0)
			{
				ChangeCurrentFloor(_currentFloor - 1);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void NextFloor()
		{
			if (_currentFloor < Floors.Length - 1)
			{
				ChangeCurrentFloor(_currentFloor + 1);
			}
		}

		public void ChangeCurrentFloor(int p_index)
		{
			if (Floors.Length >= p_index)
			{
				MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentStage = p_index;
				FloorsManager.ChangingFloor?.Invoke(Floors[p_index]);
				_currentFloor = p_index;
				CurrentFloor = Floors[_currentFloor];
				MonoSingleton<MainCamera>.Instance.SetHeight(CurrentFloor.transform.position.y);
			}
		}

		public void SetGridVisibility(bool p_visible)
		{
			CurrentFloor.SetFloorGridVisibility(p_visible);
		}

		public static int GetNearestFloorIndex(float yPosition)
		{
			for (int num = MonoSingleton<FloorsManager>.Instance.Floors.Length - 1; num >= 0; num--)
			{
				if (yPosition >= MonoSingleton<FloorsManager>.Instance.Floors[num].GetHeight() - 0.5f)
				{
					return num;
				}
			}
			return 0;
		}

		public static float GetFloorHeight(int p_floorIndex)
		{
			p_floorIndex = Math.Clamp(p_floorIndex, 0, MonoSingleton<FloorsManager>.Instance.Floors.Length - 1);
			return MonoSingleton<FloorsManager>.Instance.Floors[p_floorIndex].GetHeight();
		}

		public static float GetNearestFloorHeight(float p_yPosition)
		{
			float num = 20f;
			for (int num2 = MonoSingleton<FloorsManager>.Instance.Floors.Length - 1; num2 >= 0; num2--)
			{
				num = MonoSingleton<FloorsManager>.Instance.Floors[num2].GetHeight();
				if (p_yPosition >= num - 0.01f)
				{
					return num;
				}
			}
			return num;
		}

		private void OnRoomStatusChanged()
		{
		}
	}
}
