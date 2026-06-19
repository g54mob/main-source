using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventRoomBuilt : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			}

			private void OnRoomBuiltEvent(Room room, int cost)
			{
				if (cost != 0 && !room.Definition.IsHospitalOrBay && !room.Definition.IsHospitalUnbuilt)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventRoomBuilt
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_roomDefinition = room.Definition,
						_cost = -cost
					});
				}
			}
		}

		private RoomDefinition _roomDefinition;

		private int _cost;

		public override Sprite GetEventIcon()
		{
			return _roomDefinition._icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.RoomBuilt_CS.Replace("{[ROOM]}", _roomDefinition.GetLocalisedName());
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
