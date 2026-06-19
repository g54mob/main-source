using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffBreakEnd : HospitalEvent, IHospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffAssignedJob = (Action<Room, Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffAssignedJob, new Action<Room, Staff, Job, bool>(OnStaffAssignedJob));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffAssignedJob = (Action<Room, Staff, Job, bool>)Delegate.Remove(characterEvents.OnStaffAssignedJob, new Action<Room, Staff, Job, bool>(OnStaffAssignedJob));
			}

			private void OnStaffAssignedJob(Room room, Staff staff, Job job, bool wasOnBreak)
			{
				if (wasOnBreak)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventStaffBreakEnd
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						StaffName = staff.CharacterName
					});
				}
			}
		}

		public CharacterName StaffName;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffBreakEnd_CS.Replace("{[STAFF]}", StaffName.GetCharacterName());
		}

		public CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
