using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventRoomSold : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			}

			private void OnRoomDeleted(Room room)
			{
				if (!room.Definition.IsHospitalOrBay && !room.Definition.IsHospitalUnbuilt)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventRoomSold
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_roomDefinition = room.Definition,
						_userSpecifiedRoomName = room.GetUserSpecifiedName(),
						_cost = GameAlgorithms.CalculateSellCostOfRoom(room.FloorPlan)
					});
				}
			}
		}

		private string _userSpecifiedRoomName;

		private RoomDefinition _roomDefinition;

		private int _cost;

		public override Sprite GetEventIcon()
		{
			return _roomDefinition._icon;
		}

		public override string GetDescription()
		{
			string newValue = ((!string.IsNullOrEmpty(_userSpecifiedRoomName)) ? _userSpecifiedRoomName : ((_roomDefinition != null) ? _roomDefinition.GetLocalisedName() : "???"));
			return ScriptLocalization.HospitalEvent.RoomSold_CS.Replace("{[ROOM]}", newValue);
		}

		public int GetFinanceValue()
		{
			return _cost;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}
	}
}
