using System.Collections.Generic;
using CTS.Core;

namespace CTS
{
	public class RoomTypeGoal : BaseSpecificRoomTypeNumericalGoal
	{
		public RoomTypeGoal(Quest quest, int entryID, string variableName, string targetVariableName, params NavigationArea[] navigationAreas)
			: base(quest, entryID, variableName, targetVariableName, navigationAreas)
		{
		}

		public override void StopObserving()
		{
			RoomAssingationMenu.OnRoomAssignationChanged -= OnRoomAssignationChanged;
			ConstructionSystem.OnConstructionGenerated -= OnConstructionGenerated;
		}

		public override void StartObserving()
		{
			RoomAssingationMenu.OnRoomAssignationChanged += OnRoomAssignationChanged;
			ConstructionSystem.OnConstructionGenerated += OnConstructionGenerated;
			CheckRooms();
		}

		private void OnConstructionGenerated(int arg1, int arg2, int arg3)
		{
			CheckRooms();
		}

		private void OnRoomAssignationChanged(RoomBuilding room)
		{
			CheckRooms();
		}

		private void CheckRooms()
		{
			int num = 0;
			foreach (BuildingRoomContainer roomManager in MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers)
			{
				foreach (KeyValuePair<int, RoomBuilding> generatedRoom in roomManager.GeneratedRooms)
				{
					if (base.RoomTypes.Contains(generatedRoom.Value.NavArea))
					{
						num++;
					}
				}
			}
			SetGoalVariable(num);
		}
	}
}
