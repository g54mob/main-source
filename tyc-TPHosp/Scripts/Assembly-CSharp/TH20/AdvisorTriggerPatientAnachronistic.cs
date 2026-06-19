using System;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientAnachronistic : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerPatientAnachronisticDefinition _definition;

		[SerializeField]
		private bool _messageSet;

		[SerializeField]
		private string _text;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private int _dayOfPatientAnachronistic;

		[DontSave]
		private GameObject _interestPoint;

		public AdvisorTriggerPatientAnachronistic(AdvisorTriggerPatientAnachronisticDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
		}

		public override void OnUnregister()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
		}

		private void OnPatientSpawned(Patient patient)
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
			int num = Level.TimelineManager.TotalGameDaysPassed - _dayOfPatientAnachronistic;
			if ((float)num <= _definition.MessageDelay)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if ((float)num <= _definition.MessageDelay + _definition.MessageLifetime)
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
			AnachronisticManager anachronisticManager = Level.CharacterManager.GetAnachronisticManager();
			if (anachronisticManager != null && anachronisticManager.Config._hasTimeTunnel && patient.GetComponent<AnachronisticTreatmentComponent>() != null && Level.GameplayStatsTracker.GetNumberOfPatientsAnachronistic() <= _definition.NumMessages)
			{
				_icon = _definition.MessageIcon;
				_text = _definition.MessageLocalised.Translation;
				_messageSet = true;
				_dayOfPatientAnachronistic = Level.TimelineManager.TotalGameDaysPassed;
				_interestPoint = patient.GetCameraTrackObject();
			}
		}
	}
}
