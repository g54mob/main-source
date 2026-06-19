using System;

namespace TH20
{
	public class NotificationDiagnosisDecision : NotificationMessage
	{
		private readonly Patient _patient;

		public NotificationDiagnosisDecision(NotificationMessages.Definition definition, Patient patient)
			: base(definition, patient.Level)
		{
			_patient = patient;
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.DiagnosisDecision);
			_level.StatusIconManager.ShowStatusIcon(patient, StatusIcon.Type.DecisionRequired);
		}

		protected override void RegisterEvents()
		{
			base.RegisterEvents();
			_delegate = OnDiagnosisDecision;
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)System.Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)System.Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientLeftHospital));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientSentHome = (Action<Patient>)System.Delegate.Combine(characterEvents2.OnPatientSentHome, new Action<Patient>(OnPatientLeftHospital));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientRageQuit = (Action<Patient>)System.Delegate.Combine(characterEvents3.OnPatientRageQuit, new Action<Patient>(OnPatientLeftHospital));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnPatientLeftHospital = (Action<Patient>)System.Delegate.Combine(characterEvents4.OnPatientLeftHospital, new Action<Patient>(OnPatientLeftHospital));
		}

		protected override void UnregisterEvents()
		{
			base.UnregisterEvents();
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)System.Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)System.Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientLeftHospital));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientSentHome = (Action<Patient>)System.Delegate.Remove(characterEvents2.OnPatientSentHome, new Action<Patient>(OnPatientLeftHospital));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientRageQuit = (Action<Patient>)System.Delegate.Remove(characterEvents3.OnPatientRageQuit, new Action<Patient>(OnPatientLeftHospital));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnPatientLeftHospital = (Action<Patient>)System.Delegate.Remove(characterEvents4.OnPatientLeftHospital, new Action<Patient>(OnPatientLeftHospital));
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			if (_patient.GetRemainingDiagnosisRooms().Contains(room.Definition._type))
			{
				_level.Notifications.Remove(this);
			}
		}

		private void OnPatientLeftHospital(Patient patientLeft)
		{
			if (_patient == patientLeft)
			{
				_level.Notifications.Remove(this);
			}
		}

		private void OnDiagnosisDecision(int choice)
		{
			switch (choice)
			{
			case 0:
				_patient.SendHome();
				break;
			case 1:
				_patient.WaitForDiagnosisRoomToBeBuilt(GameAlgorithms.Config.PatientWaitForNewRoomTime);
				break;
			case 2:
				_patient.SendToTreatmentRoom(_patient.Illness.GetTreatmentRoom(_patient, _level.ResearchManager), immediately: false);
				break;
			}
		}

		public override string GetMessageText()
		{
			return base.Definition.GetTextStringForGender(_patient.Gender).Replace("{[NAME]}", _patient.Name).Replace("{[CERTAINTY]}", StringUtils.FormatPercentageValue(_patient.DiagnosisCertainty / 100f));
		}

		public override Character GetCharacter()
		{
			return _patient;
		}
	}
}
