using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerPatientTimeTunnel : AdviceTrigger
	{
		private bool _messageSet;

		private string _text;

		private Sprite _icon;

		private int _dayOfTimeTunnel;

		[InspectorMargin(8)]
		[InspectorHeader("Patient Time Tunnel")]
		[InspectorTooltip("The number of days for which we care about a time tunnel")]
		[SerializeField]
		private int _numDaysAfterTimeTunnel = 4;

		[InspectorTooltip("The total number of messages that will be fired, 0 = always active")]
		[SerializeField]
		private int _numMessages = 1;

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
		}

		public override void OnUnregister()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
		}

		private void OnPatientTimeTunnel(Patient patient)
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
			if (Level.TimelineManager.TotalGameDaysPassed - _dayOfTimeTunnel <= _numDaysAfterTimeTunnel)
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
			if (Level.GameplayStatsTracker.GetNumberOfTimeTunnels() <= _numMessages)
			{
				_icon = MessageIcon;
				_text = MessageLocalised.Translation;
				_messageSet = true;
			}
			_dayOfTimeTunnel = Level.TimelineManager.TotalGameDaysPassed;
		}
	}
}
