using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerPatientRageQuit : AdviceTrigger
	{
		private int _dayOfRageQuit;

		private bool _patientJustRageQuit;

		private bool _quitUnhappy;

		private string _topComplaints;

		private int _daysInHospital;

		private string _waitingFor;

		private bool _waitingForFurtherDiagnosis;

		[InspectorMargin(8)]
		[InspectorHeader("Patient Rage Quit")]
		[InspectorTooltip("The number of days for which we care about a rage quit")]
		[SerializeField]
		private int _numDaysAfterRageQuit = 4;

		[SerializeField]
		private LocalisedString _rageQuitWaitingMessage;

		[SerializeField]
		private LocalisedString _rageQuitFurtherDiagnosisMessage;

		[SerializeField]
		private LocalisedString _rageQuitZeroHappinessMessage;

		[SerializeField]
		private LocalisedString _rageQuitNoComplaintsMessage;

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
					_topComplaints = _rageQuitNoComplaintsMessage.Translation;
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

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			string message = (_quitUnhappy ? LocalisedString.Replace(_rageQuitZeroHappinessMessage.Translation, new SubPair[2]
			{
				new SubPair("{[COMPLAINTS]}", _topComplaints),
				new SubPair("{[DAYS]}", _daysInHospital)
			}) : ((!_waitingForFurtherDiagnosis) ? LocalisedString.Replace(_rageQuitWaitingMessage.Translation, new SubPair[1]
			{
				new SubPair("{[ROOM]}", _waitingFor)
			}) : _rageQuitFurtherDiagnosisMessage.Translation));
			result.Message = message;
			return result;
		}

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!_patientJustRageQuit)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (Level.TimelineManager.TotalGameDaysPassed - _dayOfRageQuit <= _numDaysAfterRageQuit)
			{
				return Advisor.PriorityLevel.VeryHigh;
			}
			_patientJustRageQuit = false;
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
