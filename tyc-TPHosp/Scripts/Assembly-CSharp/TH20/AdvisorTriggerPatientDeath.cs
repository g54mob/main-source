using System;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientDeath : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerPatientDeathDefinition _definition;

		[SerializeField]
		private bool _messageSet;

		[SerializeField]
		private string _text;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private int _dayOfDeath;

		[DontSave]
		private GameObject _interestPoint;

		public AdvisorTriggerPatientDeath(AdvisorTriggerPatientDeathDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents2.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
		}

		public override void OnUnregister()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents2.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
		}

		private void OnPatientDied(Patient patient)
		{
			if (!_messageSet)
			{
				RecordData(patient, null, null);
			}
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
		{
			if (!_messageSet && patient.TreatmentOutcome != Treatment.Outcome.Cured)
			{
				RecordData(patient, staff, room);
			}
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!_messageSet)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (Level.TimelineManager.TotalGameDaysPassed - _dayOfDeath <= _definition.NumDaysAfterDeath)
			{
				return Advisor.PriorityLevel.VeryHigh;
			}
			_messageSet = false;
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Icon = _icon;
			result.Message = _text;
			result.CameraTrackObject = _interestPoint;
			_messageSet = false;
			return result;
		}

		private void RecordData(Patient patient, Staff staff, Room room)
		{
			if ((patient.Health != null && patient.Health.Value() <= 0f) || room == null)
			{
				AttributeFloat attribute = patient.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Hygiene);
				_icon = _definition.FatalIcon;
				if (attribute != null && attribute.Value() < patient.Definition.HygieneHealthModificationThreshold)
				{
					_text = _definition.HealthHygieneText.Translation;
				}
				else
				{
					_text = _definition.HealthOtherText.Translation;
				}
			}
			else
			{
				TreatmentCalculationBreakdown treatmentOutcomeBreakdown = patient.TreatmentOutcomeBreakdown;
				RoomItem roomItemWithUpgrades = RoomAlgorithms.GetRoomItemWithUpgrades(room);
				string localisedName = room.Definition.GetLocalisedName();
				_icon = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _definition.FatalIcon : _definition.IneffectiveIcon);
				if (treatmentOutcomeBreakdown.DiagnosisCertainty < Level.HospitalPolicy.DiagnosisCertainty)
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _definition.DiagnosisFatalText.Translation : _definition.DiagnosisIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, new SubPair[2]
					{
						new SubPair("{[ROOM]}", localisedName),
						new SubPair("{[DIAGNOSIS]}", StringUtils.FormatPercentageValue(treatmentOutcomeBreakdown.DiagnosisCertainty / 100f, prefixPlus: true))
					});
				}
				else if (treatmentOutcomeBreakdown.StaffSkill < _definition.StaffSkillThreshold && staff != null && Level.Metagame.HasUnlockedRoomOfType(RoomDefinition.Type.Training))
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _definition.StaffSkillFatalText.Translation : _definition.StaffSkillIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, new SubPair[2]
					{
						new SubPair("{[ROOM]}", localisedName),
						new SubPair("{[STAFF]}", staff.NameWithTitle)
					});
				}
				else if (roomItemWithUpgrades != null && Level.Metagame.HasUnlocked(roomItemWithUpgrades.Definition))
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _definition.UpgradeFatalText.Translation : _definition.UpgradeIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, new SubPair[2]
					{
						new SubPair("{[ROOM]}", localisedName),
						new SubPair("{[MACHINE]}", roomItemWithUpgrades.LocalisedName)
					});
				}
				else
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _definition.OtherFatalText.Translation : _definition.OtherIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, "{[ROOM]}", localisedName);
				}
			}
			_dayOfDeath = Level.TimelineManager.TotalGameDaysPassed;
			_interestPoint = patient.GetCameraTrackObject();
		}
	}
}
