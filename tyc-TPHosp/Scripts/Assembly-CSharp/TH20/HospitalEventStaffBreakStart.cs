using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffBreakStart : HospitalEvent, IHospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffTakeBreak = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffTakeBreak = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			}

			private void OnStaffTakeBreak(Staff staff)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventStaffBreakStart
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					StaffName = staff.CharacterName
				});
			}
		}

		public CharacterName StaffName;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffBreakStart_CS.Replace("{[STAFF]}", StaffName.GetCharacterName());
		}

		public CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
