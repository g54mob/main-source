using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventMachineExploded : HospitalEvent
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
			}

			private void OnRoomItemExploded(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventMachineExploded
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_itemDefinition = roomItem.Definition,
					_upgradeLevel = roomItem.UpgradeLevel
				});
			}
		}

		private IRoomItemDefinition _itemDefinition;

		private int _upgradeLevel;

		public override Sprite GetEventIcon()
		{
			return _itemDefinition.GetIcon(_upgradeLevel);
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.MachineExploded_CS.Replace("{[ITEM]}", _itemDefinition.GetLocalisedName(_upgradeLevel));
		}
	}
}
