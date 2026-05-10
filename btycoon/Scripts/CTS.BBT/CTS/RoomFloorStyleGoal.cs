using System.Collections.Generic;

namespace CTS
{
	public class RoomFloorStyleGoal : QuestGoal
	{
		private EBarStyle _style;

		private List<RoomBuilding> _rooms = new List<RoomBuilding>();

		public RoomFloorStyleGoal(Quest quest, int entryID, EBarStyle style)
			: base(quest, entryID)
		{
			_style = style;
		}

		public override void StopObserving()
		{
			RoomBuilding.OnRoomStyleChanged -= OnRoomStyleChanged;
		}

		public override void StartObserving()
		{
			RoomBuilding.OnRoomStyleChanged += OnRoomStyleChanged;
		}

		private void OnRoomStyleChanged(RoomBuilding room, RoomStyleInformation infos)
		{
			if (!infos.FloosStyles.ContainsKey(_style) || infos.FloosStyles.Count > 1)
			{
				_rooms.Remove(room);
			}
			else if (!_rooms.Contains(room))
			{
				_rooms.Add(room);
			}
			SetGoalState(_rooms.Count > 0);
		}
	}
}
