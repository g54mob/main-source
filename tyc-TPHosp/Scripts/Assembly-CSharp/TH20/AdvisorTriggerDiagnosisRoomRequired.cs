using System;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerDiagnosisRoomRequired : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerDiagnosisRoomRequiredDefinition _definition;

		[DontSave]
		private Patient _patientWaiting;

		public AdvisorTriggerDiagnosisRoomRequired(AdvisorTriggerDiagnosisRoomRequiredDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDiagnosisExhausted = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDiagnosisExhausted, new Action<Patient>(OnPatientDiagnosisExhausted));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientLeftHospital = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientLeftHospital, new Action<Patient>(OnPatientLeft));
		}

		public override void OnUnregister()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDiagnosisExhausted = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDiagnosisExhausted, new Action<Patient>(OnPatientDiagnosisExhausted));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientLeftHospital = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientLeftHospital, new Action<Patient>(OnPatientLeft));
			base.OnUnregister();
		}

		private void OnPatientDiagnosisExhausted(Patient patient)
		{
			if (!patient.FullyDiagnosed())
			{
				_patientWaiting = patient;
			}
		}

		private void OnPatientLeft(Patient patient)
		{
			if (_patientWaiting != null && _patientWaiting == patient)
			{
				_patientWaiting = null;
			}
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (_patientWaiting == null)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (_patientWaiting.FullyDiagnosed())
			{
				_patientWaiting = null;
				return Advisor.PriorityLevel.DontShow;
			}
			RoomDefinition.Type waitingForRoom = _patientWaiting.WaitingForRoom;
			if (GameAlgorithms.DoesHospitalHaveRoom(Level.WorldState, waitingForRoom))
			{
				_patientWaiting = null;
				return Advisor.PriorityLevel.DontShow;
			}
			return _definition.PriorityLevel;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			if (_patientWaiting != null)
			{
				result.CameraTrackObject = _patientWaiting.GetCameraTrackObject();
			}
			_patientWaiting = null;
			return result;
		}
	}
}
