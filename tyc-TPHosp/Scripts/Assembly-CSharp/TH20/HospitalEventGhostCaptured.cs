using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventGhostCaptured : HospitalEvent, IHospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnGhostCaptured = (Action<Character, Staff>)Delegate.Combine(characterEvents.OnGhostCaptured, new Action<Character, Staff>(OnGhostCaptured));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnGhostCaptured = (Action<Character, Staff>)Delegate.Remove(characterEvents.OnGhostCaptured, new Action<Character, Staff>(OnGhostCaptured));
			}

			private void OnGhostCaptured(Character ghost, Staff staff)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventGhostCaptured
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					Icon = ghost.Definition._icon,
					GhostName = ghost.CharacterName,
					StaffName = staff.CharacterName
				});
			}
		}

		public Sprite Icon;

		public CharacterName GhostName;

		public CharacterName StaffName;

		public override Sprite GetEventIcon()
		{
			return Icon;
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.GhostCaptured_CS, new SubPair[2]
			{
				new SubPair("{[NAME]}", GhostName.GetCharacterName()),
				new SubPair("{[STAFF]}", StaffName.GetCharacterName())
			});
		}

		public CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
