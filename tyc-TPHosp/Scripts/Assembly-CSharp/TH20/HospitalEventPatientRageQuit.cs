using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class HospitalEventPatientRageQuit : HospitalEvent, IHospitalEventReputation, IHospitalEventPatient
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public LocalisedString WaitingMessage;

			public LocalisedString FurtherDiagnosisMessage;

			public LocalisedString ZeroHappinessMessage;

			public LocalisedString NoComplaintsMessage;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			}

			private void OnPatientRageQuit(Patient patient)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventPatientRageQuit(_level.TimelineManager.CurrentGameDate, this, patient));
			}
		}

		private CharacterName _patientName;

		private float _reputationModifier;

		private bool _quitUnhappy;

		private string _topComplaints;

		private string _waitingFor;

		private bool _waitingForFurtherDiagnosis;

		public HospitalEventPatientRageQuit(GameDate date, Config config, Patient patient)
		{
			Date = date;
			_config = config;
			_patientName = patient.CharacterName;
			_reputationModifier = patient.Illness._reputationPatientRageQuit;
			if (patient.Happiness != null && patient.Happiness.Value() <= 0f)
			{
				List<string> topComplaints = patient.GetComponent<CharacterHappinessComponent>().GetTopComplaints(3);
				if (topComplaints.Count != 0)
				{
					_topComplaints = GameStringUtils.MakeStringFromList(topComplaints);
				}
				else
				{
					_topComplaints = config.NoComplaintsMessage.Translation;
				}
				_quitUnhappy = true;
				return;
			}
			if (patient.WasWaitingForRoom != RoomDefinition.Type.Invalid)
			{
				RoomDefinition definitionFromType = RoomAlgorithms.GetDefinitionFromType(patient.Level, patient.WasWaitingForRoom);
				if (definitionFromType != null)
				{
					_waitingFor = definitionFromType.GetLocalisedName();
				}
				_waitingForFurtherDiagnosis = patient.WaitingForFurtherDiagnosis || definitionFromType == null;
			}
			_quitUnhappy = false;
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			if (_quitUnhappy)
			{
				return LocalisedString.Replace(((Config)_config).ZeroHappinessMessage.Translation, new SubPair[2]
				{
					new SubPair("{[NAME]}", _patientName.GetCharacterName()),
					new SubPair("{[COMPLAINTS]}", _topComplaints)
				});
			}
			if (_waitingForFurtherDiagnosis)
			{
				return LocalisedString.Replace(((Config)_config).FurtherDiagnosisMessage.Translation, "{[NAME]}", _patientName.GetCharacterName());
			}
			return LocalisedString.Replace(((Config)_config).WaitingMessage.Translation, new SubPair[2]
			{
				new SubPair("{[NAME]}", _patientName.GetCharacterName()),
				new SubPair("{[ROOM]}", _waitingFor)
			});
		}

		public float GetReputationValue()
		{
			return _reputationModifier;
		}

		public CharacterName GetPatientName()
		{
			return _patientName;
		}
	}
}
