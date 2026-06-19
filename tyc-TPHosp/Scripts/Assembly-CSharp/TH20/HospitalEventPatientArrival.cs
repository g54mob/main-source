using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventPatientArrival : HospitalEvent, IHospitalEventPatient
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			}

			private void OnPatientSpawned(Patient patient)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventPatientArrival
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_icon = patient.Definition._icon,
					_patientName = patient.CharacterName
				});
			}
		}

		private Sprite _icon;

		private CharacterName _patientName;

		public override Sprite GetEventIcon()
		{
			return _icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.PatientArrival_CS.Replace("{[NAME]}", _patientName.GetCharacterName());
		}

		public CharacterName GetPatientName()
		{
			return _patientName;
		}
	}
}
