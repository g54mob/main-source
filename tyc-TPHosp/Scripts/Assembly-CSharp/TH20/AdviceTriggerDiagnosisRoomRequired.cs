using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerDiagnosisRoomRequired : AdviceTrigger
	{
		[DontSave]
		private Patient _patientWaiting;

		[InspectorMargin(8)]
		[InspectorHeader("Diagnosis Room Required")]
		[InspectorTooltip("The priority level of the message")]
		[SerializeField]
		private Advisor.PriorityLevel _priorityLevel = Advisor.PriorityLevel.High;

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

		public override Advisor.PriorityLevel GetMessagePriority()
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
			return _priorityLevel;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			_patientWaiting = null;
			return base.ConstructAdvisorMessage();
		}
	}
}
