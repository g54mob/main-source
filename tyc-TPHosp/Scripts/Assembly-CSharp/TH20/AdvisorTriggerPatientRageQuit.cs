using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientRageQuit : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerPatientRageQuitDefinition _definition;

		[SerializeField]
		private int _dayOfRageQuit;

		[SerializeField]
		private bool _patientJustRageQuit;

		[SerializeField]
		private bool _quitUnhappy;

		[SerializeField]
		private string _topComplaints;

		[SerializeField]
		private int _daysInHospital;

		[SerializeField]
		private string _waitingFor;

		[SerializeField]
		private bool _waitingForFurtherDiagnosis;

		[DontSave]
		private GameObject _interestPoint;

		public AdvisorTriggerPatientRageQuit(AdvisorTriggerPatientRageQuitDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
		}

		public override void OnUnregister()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
		}

		private void OnPatientRageQuit(Patient patient)
		{
			_patientJustRageQuit = true;
			_interestPoint = patient.GetCameraTrackObject();
			_dayOfRageQuit = Level.TimelineManager.TotalGameDaysPassed;
			if (patient.Happiness != null && patient.Happiness.Value() <= 0f)
			{
				List<string> topComplaints = patient.GetComponent<CharacterHappinessComponent>().GetTopComplaints(3);
				_daysInHospital = patient.DaysInHospital;
				if (topComplaints.Count != 0)
				{
					_topComplaints = GameStringUtils.MakeStringFromList(topComplaints);
				}
				else
				{
					_topComplaints = _definition.RageQuitNoComplaintsMessage.Translation;
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

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!_patientJustRageQuit)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (Level.TimelineManager.TotalGameDaysPassed - _dayOfRageQuit <= _definition.NumDaysAfterRageQuit)
			{
				return Advisor.PriorityLevel.VeryHigh;
			}
			_patientJustRageQuit = false;
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			string message = (_quitUnhappy ? LocalisedString.Replace(_definition.RageQuitZeroHappinessMessage.Translation, new SubPair[2]
			{
				new SubPair("{[COMPLAINTS]}", _topComplaints),
				new SubPair("{[DAYS]}", _daysInHospital)
			}) : ((!_waitingForFurtherDiagnosis) ? LocalisedString.Replace(_definition.RageQuitWaitingMessage.Translation, new SubPair[1]
			{
				new SubPair("{[ROOM]}", _waitingFor)
			}) : _definition.RageQuitFurtherDiagnosisMessage.Translation));
			result.Message = message;
			result.CameraTrackObject = _interestPoint;
			_patientJustRageQuit = false;
			return result;
		}
	}
}
