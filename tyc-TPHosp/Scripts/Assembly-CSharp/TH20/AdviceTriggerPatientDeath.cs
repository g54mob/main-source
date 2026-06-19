using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerPatientDeath : AdviceTrigger
	{
		private bool _messageSet;

		private string _text;

		private Sprite _icon;

		private int _dayOfDeath;

		[InspectorMargin(8)]
		[InspectorHeader("Patient Death")]
		[InspectorTooltip("The number of days for which we care about a death")]
		[SerializeField]
		private int _numDaysAfterDeath = 4;

		[SerializeField]
		private float _staffSkillThreshold = 20f;

		[SerializeField]
		private Sprite _fatalIcon;

		[SerializeField]
		private Sprite _ineffectiveIcon;

		[SerializeField]
		private LocalisedString _healthOtherText;

		[SerializeField]
		private LocalisedString _healthHygieneText;

		[SerializeField]
		private LocalisedString _diagnosisFatalText;

		[SerializeField]
		private LocalisedString _diagnosisIneffectiveText;

		[SerializeField]
		private LocalisedString _staffSkillFatalText;

		[SerializeField]
		private LocalisedString _staffSkillIneffectiveText;

		[SerializeField]
		private LocalisedString _upgradeFatalText;

		[SerializeField]
		private LocalisedString _upgradeIneffectiveText;

		[SerializeField]
		private LocalisedString _otherFatalText;

		[SerializeField]
		private LocalisedString _otherIneffectiveText;

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

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!_messageSet)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (Level.TimelineManager.TotalGameDaysPassed - _dayOfDeath <= _numDaysAfterDeath)
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
			_messageSet = false;
			return result;
		}

		private void RecordData(Patient patient, Staff staff, Room room)
		{
			if ((patient.Health != null && patient.Health.Value() <= 0f) || room == null)
			{
				AttributeFloat attribute = patient.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Hygiene);
				_icon = _fatalIcon;
				if (attribute != null && attribute.Value() < patient.Definition.HygieneHealthModificationThreshold)
				{
					_text = _healthHygieneText.Translation;
				}
				else
				{
					_text = _healthOtherText.Translation;
				}
			}
			else
			{
				TreatmentCalculationBreakdown treatmentOutcomeBreakdown = patient.TreatmentOutcomeBreakdown;
				RoomItem roomItemWithUpgrades = RoomAlgorithms.GetRoomItemWithUpgrades(room);
				string localisedName = room.Definition.GetLocalisedName();
				_icon = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _fatalIcon : _ineffectiveIcon);
				if (treatmentOutcomeBreakdown.DiagnosisCertainty < Level.HospitalPolicy.DiagnosisCertainty)
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _diagnosisFatalText.Translation : _diagnosisIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, new SubPair[2]
					{
						new SubPair("{[ROOM]}", localisedName),
						new SubPair("{[DIAGNOSIS]}", StringUtils.FormatPercentageValue(treatmentOutcomeBreakdown.DiagnosisCertainty / 100f, prefixPlus: true))
					});
				}
				else if (treatmentOutcomeBreakdown.StaffSkill < _staffSkillThreshold && staff != null)
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _staffSkillFatalText.Translation : _staffSkillIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, new SubPair[2]
					{
						new SubPair("{[ROOM]}", localisedName),
						new SubPair("{[STAFF]}", staff.NameWithTitle)
					});
				}
				else if (roomItemWithUpgrades != null)
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _upgradeFatalText.Translation : _upgradeIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, new SubPair[2]
					{
						new SubPair("{[ROOM]}", localisedName),
						new SubPair("{[MACHINE]}", roomItemWithUpgrades.LocalisedName)
					});
				}
				else
				{
					_text = ((patient.TreatmentOutcome == Treatment.Outcome.Death) ? _otherFatalText.Translation : _otherIneffectiveText.Translation);
					_text = LocalisedString.Replace(_text, "{[ROOM]}", localisedName);
				}
			}
			_dayOfDeath = Level.TimelineManager.TotalGameDaysPassed;
		}
	}
}
