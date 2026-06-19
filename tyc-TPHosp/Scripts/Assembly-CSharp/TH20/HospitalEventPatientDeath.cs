using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventPatientDeath : HospitalEvent, IHospitalEventReputation, IHospitalEventPatient, IHospitalEventDiagnosis
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			}

			private void OnPatientDied(Patient patient)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventPatientDeath
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					PatientName = patient.CharacterName,
					ReputationModifier = patient.Illness.GetTreatmentReputationModifier(Treatment.Outcome.Death)
				});
			}
		}

		public CharacterName PatientName;

		public float ReputationModifier;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.PatientDeath_CS.Replace("{[PATIENT]}", PatientName.GetCharacterName());
		}

		public float GetReputationValue()
		{
			return ReputationModifier;
		}

		public CharacterName GetPatientName()
		{
			return PatientName;
		}

		public float GetDiagnosisValue()
		{
			return 0f;
		}

		public Sprite GetDiagnosisSprite()
		{
			return GetEventIcon();
		}
	}
}
