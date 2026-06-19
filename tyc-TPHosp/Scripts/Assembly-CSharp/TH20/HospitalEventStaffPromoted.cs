using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffPromoted : HospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			}

			private void OnStaffPromoted(Staff staff)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventStaffPromoted(staff, _level.TimelineManager.CurrentGameDate)
				{
					_config = this,
					StaffName = staff.CharacterName
				});
			}
		}

		public CharacterName StaffName;

		public HospitalEventStaffPromoted(Staff staff, GameDate expiryDate)
			: base(staff, expiryDate)
		{
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffPromoted_CS.Replace("{[STAFF]}", StaffName.GetCharacterName());
		}

		public override CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
