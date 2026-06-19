using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventReceptionCheckIn : HospitalEvent, IHospitalEventPatient, IHospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffCheckCharacterIn = (Action<Staff, Character>)Delegate.Combine(characterEvents.OnStaffCheckCharacterIn, new Action<Staff, Character>(OnStaffCheckCharacterIn));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffCheckCharacterIn = (Action<Staff, Character>)Delegate.Remove(characterEvents.OnStaffCheckCharacterIn, new Action<Staff, Character>(OnStaffCheckCharacterIn));
			}

			private void OnStaffCheckCharacterIn(Staff staff, Character character)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventReceptionCheckIn
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					StaffName = staff.CharacterName,
					CharacterName = character.CharacterName
				});
			}
		}

		public CharacterName StaffName;

		public CharacterName CharacterName;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.ReceptionCheckIn_CS, new SubPair[2]
			{
				new SubPair("{[STAFF]}", StaffName.GetCharacterName()),
				new SubPair("{[NAME]}", CharacterName.GetCharacterName())
			});
		}

		public CharacterName GetPatientName()
		{
			return CharacterName;
		}

		public float GetDiagnosisValue()
		{
			return 0f;
		}

		public Sprite GetDiagnosisSprite()
		{
			return GetEventIcon();
		}

		public CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
