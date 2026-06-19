using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventPatientSentHome : HospitalEvent, IHospitalEventReputation, IHospitalEventPatient
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}

			private void OnPatientSentHome(Patient patient)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventPatientSentHome
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					PatientName = patient.CharacterName,
					ReputationModifier = patient.Illness._reputationPatientWaitTooLong
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
			return ScriptLocalization.HospitalEvent.PatientSentHome_CS.Replace("{[PATIENT]}", PatientName.GetCharacterName());
		}

		public float GetReputationValue()
		{
			return ReputationModifier;
		}

		public CharacterName GetPatientName()
		{
			return PatientName;
		}
	}
}
