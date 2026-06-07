using System;
using UnityEngine;

namespace CTS
{
	public class Floor : MonoBehaviour
	{
		[field: SerializeField]
		public bool VisibleFloor { get; private set; }

		[field: SerializeField]
		public bool VisibleFloorGrid { get; private set; }

		public int FloorID { get; private set; } = -1;

		public Room[] Rooms { get; private set; }

		[field: SerializeField]
		public BuildingRoomContainer RoomContainer { get; private set; }

		public bool Activated
		{
			get
			{
				Room[] rooms = Rooms;
				for (int i = 0; i < rooms.Length; i++)
				{
					if (rooms[i].Active)
					{
						return true;
					}
				}
				return false;
			}
		}

		public event Action<bool> ChangingFloorVisibility;

		public event Action<bool> ChangingFloorGridVisibility;

		private void Awake()
		{
			Rooms = GetComponentsInChildren<Room>();
			RoomContainer = GetComponentInChildren<BuildingRoomContainer>();
			Room[] rooms = Rooms;
			for (int i = 0; i < rooms.Length; i++)
			{
				rooms[i].AssignFloor(this);
			}
			FloorsManager.ChangingFloor += SetFloorVisibility;
		}

		private void OnDisable()
		{
			FloorsManager.ChangingFloor -= SetFloorVisibility;
		}

		public float GetHeight()
		{
			return base.transform.position.y;
		}

		public void SetFloorVisibility(Floor p_floorToShow)
		{
			if (VisibleFloor != (p_floorToShow == this))
			{
				VisibleFloor = p_floorToShow == this;
				this.ChangingFloorVisibility?.Invoke(VisibleFloor);
				SetFloorGridVisibility(VisibleFloor && FurnitureShop.IsOpen);
				RoomContainer.ChangeVisibility(VisibleFloor);
			}
		}

		public void SetFloorGridVisibility(bool p_visible)
		{
			VisibleFloorGrid = p_visible;
			this.ChangingFloorGridVisibility?.Invoke(p_visible);
		}

		public void AssignID(int p_id)
		{
			FloorID = p_id;
		}

		public bool TryGetRoom(string roomKey, out Room outRoom)
		{
			Room[] rooms = Rooms;
			foreach (Room room in rooms)
			{
				if (room.Name == roomKey)
				{
					outRoom = room;
					return true;
				}
			}
			outRoom = null;
			return false;
		}

		public Vector3 GetClosestVerticeOnFloorGrid(Vector3 p_worldPosition)
		{
			float num = float.PositiveInfinity;
			Vector3 result = Vector3.zero;
			Room[] rooms = Rooms;
			foreach (Room room in rooms)
			{
				if (room.Available)
				{
					Vector3 closestVerticeOnRoomGrid = room.GetClosestVerticeOnRoomGrid(p_worldPosition);
					float sqrMagnitude = (p_worldPosition - closestVerticeOnRoomGrid).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						result = closestVerticeOnRoomGrid;
					}
				}
			}
			return result;
		}
	}
}
