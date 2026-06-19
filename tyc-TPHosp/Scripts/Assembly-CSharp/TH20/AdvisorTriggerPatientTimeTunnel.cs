using System;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientTimeTunnel : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerPatientTimeTunnelDefinition _definition;

		[SerializeField]
		private bool _messageSet;

		[SerializeField]
		private string _text;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private int _dayOfTimeTunnel;

		[DontSave]
		private GameObject _interestPoint;

		public AdvisorTriggerPatientTimeTunnel(AdvisorTriggerPatientTimeTunnelDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

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

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!_messageSet)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if ((float)(Level.TimelineManager.TotalGameDaysPassed - _dayOfTimeTunnel) <= _definition.MessageLifetime)
			{
				return _definition.PriorityLevel;
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
			if (Level.GameplayStatsTracker.GetNumberOfTimeTunnels() <= _definition.NumMessages)
			{
				_icon = _definition.MessageIcon;
				_text = _definition.MessageLocalised.Translation;
				_messageSet = true;
			}
			_dayOfTimeTunnel = Level.TimelineManager.TotalGameDaysPassed;
			_interestPoint = patient.GetCameraTrackObject();
		}
	}
}
