using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffResigned : HospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffResigned, new Action<Staff>(OnStaffResigned));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffResigned, new Action<Staff>(OnStaffResigned));
			}

			private void OnStaffResigned(Staff staff)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventStaffResigned(staff, _level.TimelineManager.CurrentGameDate)
				{
					_config = this,
					StaffName = staff.CharacterName
				});
			}
		}

		public CharacterName StaffName;

		public HospitalEventStaffResigned(Staff staff, GameDate expiryDate)
			: base(staff, expiryDate)
		{
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffResigned_CS.Replace("{[STAFF]}", StaffName.GetCharacterName());
		}

		public override CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
