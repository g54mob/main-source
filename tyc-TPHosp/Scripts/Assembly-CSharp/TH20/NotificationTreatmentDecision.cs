using System;
using System.Text;
using I2.Loc;

namespace TH20
{
	public class NotificationTreatmentDecision : NotificationMessage
	{
		private readonly Patient _patient;

		private readonly RoomDefinition _requiredTreatmentRoom;

		public NotificationTreatmentDecision(NotificationMessages.Definition definition, Patient patient)
			: base(definition, patient.Level)
		{
			_patient = patient;
			_requiredTreatmentRoom = patient.Illness.GetTreatmentRoom(patient, _level.ResearchManager);
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.TreatmentDecision);
			_level.StatusIconManager.ShowStatusIcon(patient, StatusIcon.Type.DecisionRequired);
		}

		protected override void RegisterEvents()
		{
			base.RegisterEvents();
			_delegate = OnTreatmentDecision;
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
			if (room.Definition == _requiredTreatmentRoom)
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

		private void OnTreatmentDecision(int choice)
		{
			switch (choice)
			{
			case 0:
				_patient.SendHome();
				break;
			case 1:
				_patient.WaitForTreatmentRoomToBeBuilt(_requiredTreatmentRoom, GameAlgorithms.Config.PatientWaitForNewRoomTime);
				break;
			}
		}

		public override string GetTitleText()
		{
			return base.Definition.GetTitleString().Replace("{[ROOM]}", _requiredTreatmentRoom.GetLocalisedName());
		}

		public override string GetTooltipText()
		{
			return GetTitleText();
		}

		public override string GetMessageText()
		{
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder(1000);
			string textString = base.Definition.GetTextString();
			textString = textString.Replace("{[ROOM]}", _requiredTreatmentRoom.GetLocalisedName());
			textString = textString.Replace("{[ILLNESS]}", _patient.Illness.Name.Translation);
			textString = textString.Replace("{[DESCRIPTION]}", _patient.Illness.Description.Translation);
			builder.Append(textString);
			if (!_level.Metagame.HasUnlocked(_requiredTreatmentRoom))
			{
				string arg = ((!ShouldShowResearchMessage()) ? ScriptLocalization.Notification.TreatmentMessage_CompleteObjectives_CS.Replace("{[ROOM]}", _requiredTreatmentRoom.GetLocalisedName()) : ScriptLocalization.Notification.TreatmentMessage_ResearchNeeded_CS.Replace("{[ROOM]}", _requiredTreatmentRoom.GetLocalisedName()));
				builder.AppendFormat("\n\n{0}", arg);
			}
			else
			{
				string newValue = StringUtils.FormatCurrency(_requiredTreatmentRoom.GetCostWithRequiredItems());
				string arg2 = ScriptLocalization.Notification.TreatmentMessage_ResearchCost_CS.Replace("{[COST]}", newValue);
				builder.AppendFormat("\n\n{0}", arg2);
			}
			builder.AppendFormat("\n\n{0}", ScriptLocalization.Notification.TreatmentMessage_Decision_CS);
			string result = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return result;
		}

		private bool ShouldShowResearchMessage()
		{
			if (_level.Metagame.HasUnlockedRoomOfType(RoomDefinition.Type.Research))
			{
				foreach (ResearchProject item in _level.ResearchManager.GetAllProjectsForLevel(_level))
				{
					IReward[] rewards = item.Definition.Rewards;
					for (int i = 0; i < rewards.Length; i++)
					{
						if (rewards[i] is RewardRoom rewardRoom && rewardRoom.Definition.NotNull() && rewardRoom.Definition.Instance == _requiredTreatmentRoom)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override Character GetCharacter()
		{
			return _patient;
		}
	}
}
