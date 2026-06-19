using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventMachineUpgradeComplete : HospitalEvent, IHospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnRoomItemUpgradeComplete));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnRoomItemUpgradeComplete));
			}

			private void OnRoomItemUpgradeComplete(RoomItem roomItem, Staff staff)
			{
				if (staff != null)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventMachineUpgradeComplete
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						StaffName = staff.CharacterName,
						ItemDefinition = roomItem.Definition,
						UpgradeLevel = roomItem.UpgradeLevel
					});
				}
			}
		}

		public IRoomItemDefinition ItemDefinition;

		public int UpgradeLevel;

		public CharacterName StaffName;

		public override Sprite GetEventIcon()
		{
			return ItemDefinition.GetIcon();
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.MachineUpgradeComplete_CS, new SubPair[2]
			{
				new SubPair("{[ITEM]}", ItemDefinition.GetLocalisedName(UpgradeLevel)),
				new SubPair("{[STAFF]}", StaffName.GetCharacterName())
			});
		}

		public CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
