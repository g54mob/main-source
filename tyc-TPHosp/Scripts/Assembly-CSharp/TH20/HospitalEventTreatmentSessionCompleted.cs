using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventTreatmentSessionCompleted : HospitalEvent, IHospitalEventFinance, IHospitalEventReputation, IHospitalEventTreatment, IHospitalEventPatient, IHospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite IconCured;

			public Sprite IconFailed;

			public Sprite IconDead;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			}

			private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventTreatmentSessionCompleted
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_patientName = patient.CharacterName,
					_staffName = staff.CharacterName,
					_roomDefinition = room.Definition,
					_userSpecifiedRoomName = room.GetUserSpecifiedName(),
					_moneyEarned = _level.FinanceManager.GetTreatmentCharge(patient.Illness, room.Definition, _level.ResearchManager),
					_outcome = patient.TreatmentOutcome,
					_breakdown = patient.TreatmentOutcomeBreakdown,
					_reputationModifier = patient.Illness.GetTreatmentReputationModifier(patient.TreatmentOutcome)
				});
			}
		}

		private RoomDefinition _roomDefinition;

		private CharacterName _patientName;

		private CharacterName _staffName;

		private int _moneyEarned;

		private Treatment.Outcome _outcome;

		private TreatmentCalculationBreakdown _breakdown;

		private float _reputationModifier;

		private string _userSpecifiedRoomName;

		public override Sprite GetEventIcon()
		{
			return _roomDefinition._icon;
		}

		public override string GetDescription()
		{
			string term = string.Empty;
			switch (_outcome)
			{
			case Treatment.Outcome.Cured:
				term = ScriptLocalization.HospitalEvent.TreatmentSessionCompleted_Cured_CS;
				break;
			case Treatment.Outcome.Ineffective:
				term = ScriptLocalization.HospitalEvent.TreatmentSessionCompleted_Ineffective_CS;
				break;
			case Treatment.Outcome.Death:
				term = ScriptLocalization.HospitalEvent.TreatmentSessionCompleted_Death_CS;
				break;
			}
			string replace = ((!string.IsNullOrEmpty(_userSpecifiedRoomName)) ? _userSpecifiedRoomName : ((_roomDefinition != null) ? _roomDefinition.GetLocalisedName() : "???"));
			return LocalisedString.Replace(term, new SubPair[3]
			{
				new SubPair("{[PATIENT]}", _patientName.GetCharacterName()),
				new SubPair("{[STAFF]}", _staffName.GetCharacterName()),
				new SubPair("{[ROOM]}", replace)
			});
		}

		public int GetFinanceValue()
		{
			return _moneyEarned;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}

		public float GetReputationValue()
		{
			return _reputationModifier;
		}

		public Sprite GetTreatmentSprite()
		{
			return _outcome switch
			{
				Treatment.Outcome.Cured => ((Config)_config).IconCured, 
				Treatment.Outcome.Ineffective => ((Config)_config).IconFailed, 
				Treatment.Outcome.Death => ((Config)_config).IconDead, 
				_ => null, 
			};
		}

		public TreatmentCalculationBreakdown GetTreatmenBreakdown()
		{
			return _breakdown;
		}

		public CharacterName GetPatientName()
		{
			return _patientName;
		}

		public CharacterName GetStaffName()
		{
			return _staffName;
		}
	}
}
