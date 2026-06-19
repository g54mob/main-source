using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventPatientTimeTunnel : HospitalEvent, IHospitalEventReputation, IHospitalEventPatient, IHospitalEventDiagnosis
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			}

			private void OnPatientTimeTunnel(Patient patient)
			{
				bool patientWasCured = patient.ReasonForLeaving == Character.ReasonForLeavingHospital.Cured;
				_level.HospitalEventLog.AddEvent(new HospitalEventPatientTimeTunnel
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					PatientName = patient.CharacterName,
					ReputationModifier = patient.Illness.GetTreatmentReputationModifier(Treatment.Outcome.Unknown),
					PatientWasCured = patientWasCured
				});
			}
		}

		public CharacterName PatientName;

		public float ReputationModifier;

		public bool PatientWasCured;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			if (PatientWasCured)
			{
				return ScriptLocalization.HospitalEvent.PatientSentThroughTimeTreated_CS.Replace("{[PATIENT]}", PatientName.GetCharacterName());
			}
			return ScriptLocalization.HospitalEvent.PatientSentThroughTimeUntreated_CS.Replace("{[PATIENT]}", PatientName.GetCharacterName());
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
