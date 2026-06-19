using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventMachineUpgradeStarted : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemRequestUpgrade, new Action<RoomItem>(OnRoomItemRequestUpgrade));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemRequestUpgrade, new Action<RoomItem>(OnRoomItemRequestUpgrade));
			}

			private void OnRoomItemRequestUpgrade(RoomItem roomItem)
			{
				RoomItemUpgradeDefinition nextUpgrade = roomItem.Definition.GetNextUpgrade(roomItem.UpgradeLevel);
				_level.HospitalEventLog.AddEvent(new HospitalEventMachineUpgradeStarted
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					ItemDefinition = roomItem.Definition,
					UpgradeLevel = roomItem.UpgradeLevel,
					Money = ((nextUpgrade != null) ? (-nextUpgrade.Cost) : 0)
				});
			}
		}

		public IRoomItemDefinition ItemDefinition;

		public int UpgradeLevel;

		public int Money;

		public override Sprite GetEventIcon()
		{
			return ItemDefinition.GetIcon();
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.MachineUpgradeStarted_CS.Replace("{[ITEM]}", ItemDefinition.GetLocalisedName(UpgradeLevel));
		}

		public int GetFinanceValue()
		{
			return Money;
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
