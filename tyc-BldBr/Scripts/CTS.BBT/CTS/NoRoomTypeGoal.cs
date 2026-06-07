using System.Collections.Generic;
using System.Linq;
using CTS.Core;

namespace CTS
{
	public class NoRoomTypeGoal : QuestGoal
	{
		private List<NavigationArea> _roomTypes = new List<NavigationArea>();

		public NoRoomTypeGoal(Quest quest, int entryID, params NavigationArea[] navigationAreas)
			: base(quest, entryID)
		{
			_roomTypes = navigationAreas.ToList();
		}

		public override void StopObserving()
		{
			RoomAssingationMenu.OnRoomAssignationChanged -= OnRoomAssignationChanged;
		}

		public override void StartObserving()
		{
			RoomAssingationMenu.OnRoomAssignationChanged += OnRoomAssignationChanged;
			CheckRooms();
		}

		private void OnRoomAssignationChanged(RoomBuilding room)
		{
			if (_roomTypes.Contains(room.NavArea))
			{
				SetGoalState(success: false);
			}
			else
			{
				CheckRooms();
			}
		}

		private void CheckRooms()
		{
			foreach (BuildingRoomContainer roomManager in MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers)
			{
				foreach (KeyValuePair<int, RoomBuilding> generatedRoom in roomManager.GeneratedRooms)
				{
					if (_roomTypes.Contains(generatedRoom.Value.NavArea))
					{
						SetGoalState(success: false);
						return;
					}
				}
			}
			SetGoalState(success: true);
		}
	}
}
