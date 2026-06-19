using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffFired : HospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			}

			private void OnStaffFired(Staff staff)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventStaffFired(staff, _level.TimelineManager.CurrentGameDate)
				{
					_config = this,
					StaffName = staff.CharacterName
				});
			}
		}

		public CharacterName StaffName;

		public HospitalEventStaffFired(Staff staff, GameDate expiryDate)
			: base(staff, expiryDate)
		{
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffFired_CS.Replace("{[STAFF]}", StaffName.GetCharacterName());
		}

		public override CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
