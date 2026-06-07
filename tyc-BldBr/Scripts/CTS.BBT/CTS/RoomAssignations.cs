using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine.Pool;

namespace CTS
{
	public class RoomAssignations : CTSBehaviour
	{
		private readonly HashSet<RoomBuilding> _assignedRooms = new HashSet<RoomBuilding>();

		public ReadOnlyHashSet<RoomBuilding> AssignedRooms => _assignedRooms;

		public static event Action<RoomAssignations, RoomBuilding> AssignedRoomsChanged;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			RoomBuilding.OnRoomDestroyed += OnRoomDestroyed;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			RoomBuilding.OnRoomDestroyed -= OnRoomDestroyed;
		}

		private void OnRoomDestroyed(RoomBuilding room)
		{
			UnassignRoom(room);
		}

		public void AssignRoom(RoomBuilding room)
		{
			if (_assignedRooms.Add(room))
			{
				RoomAssignations.AssignedRoomsChanged?.Invoke(this, room);
			}
		}

		public void UnassignRoom(RoomBuilding room)
		{
			if (_assignedRooms.Remove(room))
			{
				RoomAssignations.AssignedRoomsChanged?.Invoke(this, room);
			}
		}

		public void UnassignAll()
		{
			if (_assignedRooms.Count <= 0)
			{
				return;
			}
			HashSet<RoomBuilding> hashSet = CollectionPool<HashSet<RoomBuilding>, RoomBuilding>.Get();
			foreach (RoomBuilding assignedRoom in _assignedRooms)
			{
				hashSet.Add(assignedRoom);
			}
			_assignedRooms.Clear();
			foreach (RoomBuilding item in hashSet)
			{
				RoomAssignations.AssignedRoomsChanged?.Invoke(this, item);
			}
		}

		public bool HasRoom(RoomBuilding room)
		{
			return _assignedRooms.Contains(room);
		}

		public bool CanUseRoom(RoomBuilding room)
		{
			if (_assignedRooms.Count <= 0)
			{
				return true;
			}
			return HasRoom(room);
		}
	}
}
