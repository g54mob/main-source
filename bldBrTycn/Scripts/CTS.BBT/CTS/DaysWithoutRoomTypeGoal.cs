using System.Collections.Generic;
using CTS.Core;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DaysWithoutRoomTypeGoal : BaseSpecificRoomTypeNumericalGoal
	{
		public DaysWithoutRoomTypeGoal(Quest quest, int entryID, string variableName, string targetVariableName, params NavigationArea[] navigationAreas)
			: base(quest, entryID, variableName, targetVariableName, navigationAreas)
		{
		}

		public override void StopObserving()
		{
			CalendarHandlers.NewDay -= OnNewDay;
		}

		public override void StartObserving()
		{
			CalendarHandlers.NewDay += OnNewDay;
			RoomAssingationMenu.OnRoomAssignationChanged += OnRoomAssignationChanged;
		}

		private void OnRoomAssignationChanged(RoomBuilding room)
		{
			if (QuestLog.GetQuestEntryState(base.QuestName, base.EntryID) == QuestState.Active && base.RoomTypes.Contains(room.NavArea))
			{
				SetGoalVariable(0);
			}
		}

		private void OnNewDay()
		{
			if (CheckRooms())
			{
				AddToGoalVariable(1);
			}
			else if (QuestLog.GetQuestEntryState(base.QuestName, base.EntryID) == QuestState.Active)
			{
				SetGoalVariable(0);
			}
		}

		private bool CheckRooms()
		{
			foreach (BuildingRoomContainer roomManager in MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers)
			{
				foreach (KeyValuePair<int, RoomBuilding> generatedRoom in roomManager.GeneratedRooms)
				{
					if (base.RoomTypes.Contains(generatedRoom.Value.NavArea))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
