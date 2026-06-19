#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;

namespace TH20
{
	public class ActiveState : OnlineChallengeState
	{
		private Dictionary<OnlinePlayerID, BaseOnlineDataFile> _cachedDataFiles;

		private Dictionary<OnlinePlayerID, BaseOnlineDataFile> _cachedScreenshotDataFiles;

		private const float TimeBetweenDataCheck = 15f;

		private const float TimeBetweenScreenshotCheck = 15f;

		private float _elapsedTime;

		private float _elapsedTimeScreenshot;

		private bool _screenshotsEnabled;

		private List<ObjectiveSubGoal> _updatedSubGoals;

		public override void ConnectionEstablished()
		{
			if (!_connectionEstablished)
			{
				Enter();
			}
		}

		public override void Enter()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			_connectionEstablished = true;
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents3 = Level.CharacterEvents;
			characterEvents3.OnStaffStartTeaching = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Combine(characterEvents3.OnStaffStartTeaching, new Action<Staff, RoomLogicTrainingRoom>(OnStaffTrainingStarted));
			CharacterEvents characterEvents4 = Level.CharacterEvents;
			characterEvents4.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents4.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents5 = Level.CharacterEvents;
			characterEvents5.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents6 = Level.CharacterEvents;
			characterEvents6.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents6.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientDiagnosed));
			CharacterEvents characterEvents7 = Level.CharacterEvents;
			characterEvents7.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents7.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents8 = Level.CharacterEvents;
			characterEvents8.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents8.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnPatientIneffectiveCure));
			CharacterEvents characterEvents9 = Level.CharacterEvents;
			characterEvents9.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents9.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnNewRoomBuiltEvent = (Action<Room>)Delegate.Combine(buildEvents.OnNewRoomBuiltEvent, new Action<Room>(OnRoomBuilt));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents2.OnHospitalPlotBought, new Action<HospitalPlot>(OnPlotBought));
			LoanManager loanManager = Level.LoanManager;
			loanManager.OnTakeOutLoan = (Action<LoanOffer>)Delegate.Combine(loanManager.OnTakeOutLoan, new Action<LoanOffer>(OnLoanTaken));
			ObjectiveEvents objectiveEvents = Level.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnChallengeCompleted));
			OnlineChallengeData localPlayerObjectiveData = Owner.LocalPlayerObjectiveData;
			localPlayerObjectiveData.OnDataUpdated = (Action<OnlineChallengeData>)Delegate.Combine(localPlayerObjectiveData.OnDataUpdated, new Action<OnlineChallengeData>(OnPlayerDataUpdated));
			_screenshotsEnabled = PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.OnlineChallengeScreenshots);
			_cachedDataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, Owner.PlayerList, createIfNone: true);
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				BaseOnlineDataFile value = cachedDataFile.Value;
				value.Download(forceTry: true);
				value.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(value.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloadFinished));
			}
			if (!_screenshotsEnabled)
			{
				return;
			}
			ObjectiveEvents objectiveEvents2 = Level.ObjectiveEvents;
			objectiveEvents2.OnLocalPlayerScreenshotUpdated = (Action<OnlineChallengeObjective, OnlineScreenshotData>)Delegate.Combine(objectiveEvents2.OnLocalPlayerScreenshotUpdated, new Action<OnlineChallengeObjective, OnlineScreenshotData>(OnPlayerUpdatedScreenshot));
			_cachedScreenshotDataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineChallengeScreenshot, Owner.ObjectiveScreenshotUniqueID, Owner.PlayerList, createIfNone: true);
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedScreenshotDataFile in _cachedScreenshotDataFiles)
			{
				BaseOnlineDataFile value2 = cachedScreenshotDataFile.Value;
				value2.Download(forceTry: true);
				value2.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(value2.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileScreenshotDownloadFinished));
			}
		}

		public override void Exit()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents3 = Level.CharacterEvents;
			characterEvents3.OnStaffStartTeaching = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Remove(characterEvents3.OnStaffStartTeaching, new Action<Staff, RoomLogicTrainingRoom>(OnStaffTrainingStarted));
			CharacterEvents characterEvents4 = Level.CharacterEvents;
			characterEvents4.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents4.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents5 = Level.CharacterEvents;
			characterEvents5.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents5.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnPatientIneffectiveCure));
			CharacterEvents characterEvents6 = Level.CharacterEvents;
			characterEvents6.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents6.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents7 = Level.CharacterEvents;
			characterEvents7.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents7.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientDiagnosed));
			CharacterEvents characterEvents8 = Level.CharacterEvents;
			characterEvents8.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents8.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents9 = Level.CharacterEvents;
			characterEvents9.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents9.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnNewRoomBuiltEvent = (Action<Room>)Delegate.Remove(buildEvents.OnNewRoomBuiltEvent, new Action<Room>(OnRoomBuilt));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Remove(buildEvents2.OnHospitalPlotBought, new Action<HospitalPlot>(OnPlotBought));
			LoanManager loanManager = Level.LoanManager;
			loanManager.OnTakeOutLoan = (Action<LoanOffer>)Delegate.Remove(loanManager.OnTakeOutLoan, new Action<LoanOffer>(OnLoanTaken));
			ObjectiveEvents objectiveEvents = Level.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnChallengeCompleted));
			OnlineChallengeData localPlayerObjectiveData = Owner.LocalPlayerObjectiveData;
			localPlayerObjectiveData.OnDataUpdated = (Action<OnlineChallengeData>)Delegate.Remove(localPlayerObjectiveData.OnDataUpdated, new Action<OnlineChallengeData>(OnPlayerDataUpdated));
			if (_screenshotsEnabled)
			{
				ObjectiveEvents objectiveEvents2 = Level.ObjectiveEvents;
				objectiveEvents2.OnLocalPlayerScreenshotUpdated = (Action<OnlineChallengeObjective, OnlineScreenshotData>)Delegate.Remove(objectiveEvents2.OnLocalPlayerScreenshotUpdated, new Action<OnlineChallengeObjective, OnlineScreenshotData>(OnPlayerUpdatedScreenshot));
			}
			if (!_connectionEstablished || !OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				BaseOnlineDataFile value = cachedDataFile.Value;
				value.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(value.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloadFinished));
			}
			if (!_screenshotsEnabled)
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedScreenshotDataFile in _cachedScreenshotDataFiles)
			{
				BaseOnlineDataFile value2 = cachedScreenshotDataFile.Value;
				value2.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(value2.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileScreenshotDownloadFinished));
			}
		}

		public override void Update(float timeDelta)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			_elapsedTime += timeDelta;
			if (_elapsedTime >= 15f)
			{
				RequestFriendData();
				_elapsedTime = 0f;
			}
			if (_screenshotsEnabled)
			{
				_elapsedTimeScreenshot += timeDelta;
				if (_elapsedTimeScreenshot >= 15f)
				{
					RequestFriendScreenshotData();
					_elapsedTimeScreenshot = 0f;
				}
			}
		}

		private void OnFileDownloadFinished(BaseOnlineDataFile file, DownloadResult result, EOnlineResult onlineResult)
		{
			switch (result)
			{
			case DownloadResult.FileNotUpdated:
				if (Owner.FriendDataCache.ContainsKey(file.GetPlayerID()))
				{
					return;
				}
				break;
			default:
				return;
			case DownloadResult.FileUpdated:
				break;
			}
			if (file.Deserialize<OnlineChallengeData>(out var obj) == EOnlineResult.EOnlineResultOk)
			{
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(file.GetPlayerID());
				if (file.GetPlayerID() != obj.PlayerID)
				{
					Logging.Warning(LogChannels.Online, "Received Online Challenge data for {0} (Active) for {1} - but the SteamID embedded in the data does not match ({2})", Owner.Definition.NameLocalised, playerInfo.DisplayName, obj.PlayerID);
				}
				else
				{
					Owner.SetData(file.GetPlayerID(), obj);
					Owner.FriendDataCache[file.GetPlayerID()] = obj;
				}
			}
		}

		private void OnFileScreenshotDownloadFinished(BaseOnlineDataFile file, DownloadResult result, EOnlineResult onlineResult)
		{
			switch (result)
			{
			case DownloadResult.FileNotUpdated:
				if (Owner.FriendDataCache.ContainsKey(file.GetPlayerID()))
				{
					return;
				}
				break;
			default:
				return;
			case DownloadResult.FileUpdated:
				break;
			}
			if (file.Deserialize<OnlineScreenshotData>(out var obj) == EOnlineResult.EOnlineResultOk)
			{
				OnlineManager.GetPlayerInfo(file.GetPlayerID());
				Owner.SetScreenshotData(file.GetPlayerID(), obj);
			}
		}

		private void RequestFriendData()
		{
			if (_cachedDataFiles == null || _cachedDataFiles.Count == 0 || !OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				cachedDataFile.Value?.Download();
			}
		}

		private void RequestFriendScreenshotData()
		{
			if (!_screenshotsEnabled || !OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedScreenshotDataFile in _cachedScreenshotDataFiles)
			{
				cachedScreenshotDataFile.Value?.Download();
			}
		}

		private void OnPlayerDataUpdated(OnlineChallengeData playerData)
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && playerData != null)
			{
				OnlineManager.DataFiles.WriteFile(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, Owner.LocalPlayerObjectiveData);
			}
		}

		private void OnPlayerUpdatedScreenshot(OnlineChallengeObjective objective, OnlineScreenshotData playerScreenshotData)
		{
			if (objective == Owner && OnlineManager.IsInitializedAndLoggedOn() && playerScreenshotData != null)
			{
				OnlineManager.DataFiles.WriteFile(OnlineFileClass.OnlineChallengeScreenshot, Owner.ObjectiveScreenshotUniqueID, Owner.LocalPlayerScreenshotData);
			}
		}

		public override void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			if (_updatedSubGoals == null)
			{
				_updatedSubGoals = new List<ObjectiveSubGoal>();
			}
			_updatedSubGoals.AddUnique(subGoal);
		}

		public override void OnTimelineUpdated(int day)
		{
			if (day % 2 == 1)
			{
				LogPlayerHospitalStatusData();
			}
			if (_updatedSubGoals != null)
			{
				foreach (ObjectiveSubGoal updatedSubGoal in _updatedSubGoals)
				{
					int num = updatedSubGoal.Score();
					if (Owner.LocalPlayerObjectiveData.ScoreCount == 0 || Owner.LocalPlayerObjectiveData[Owner.LocalPlayerObjectiveData.ScoreCount - 1].Score != num)
					{
						Owner.LocalPlayerObjectiveData.LogEventScore(Owner.DaysElapsed, num);
						Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
					}
				}
				_updatedSubGoals.Clear();
			}
			foreach (OnlineChallengeEvent item in Owner.LocalPlayerObjectiveData.GetEventsForDay(day - 1, excludeScores: true))
			{
				Level.ObjectiveEvents.OnEventReceived.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData.PlayerID, item);
			}
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item2 in Owner.PlayerInfoDictionary)
			{
				if (!(item2.Value.ChallengeData is OnlineChallengeData onlineChallengeData))
				{
					continue;
				}
				foreach (OnlineChallengeEvent item3 in onlineChallengeData.GetEventsForDay(day, excludeScores: true))
				{
					Level.ObjectiveEvents.OnEventReceived.InvokeSafe(Owner, item2.Key, item3);
				}
			}
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			Owner.LocalPlayerObjectiveData.LogEventStaffHired(Owner.DaysElapsed, staff);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnStaffFired(Staff staff)
		{
			Owner.LocalPlayerObjectiveData.LogEventStaffFired(Owner.DaysElapsed, staff);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnStaffPromoted(Staff staff)
		{
			Owner.LocalPlayerObjectiveData.LogEventStaffPromoted(Owner.DaysElapsed, staff);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnStaffTrainingStarted(Staff staff, RoomLogicTrainingRoom roomTrainingLogic)
		{
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnPatientDied(Patient patient)
		{
			Owner.LocalPlayerObjectiveData.LogEventPatientDeath(Owner.DaysElapsed, patient.Illness);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnPatientRageQuit(Patient patient)
		{
			Owner.LocalPlayerObjectiveData.LogEventPatientRageQuit(Owner.DaysElapsed);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnPatientDiagnosed(Patient patient, Staff staff, Room room, float complete)
		{
			Owner.LocalPlayerObjectiveData.LogEventPatientDiagnosed(Owner.DaysElapsed, patient.Illness);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnPatientCured(Patient patient, List<Staff> staffList)
		{
			Owner.LocalPlayerObjectiveData.LogEventPatientCured(Owner.DaysElapsed, patient.Illness);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnPatientIneffectiveCure(Patient patient, List<Staff> staffList)
		{
			Owner.LocalPlayerObjectiveData.LogEventPatientIneffetiveTreatment(Owner.DaysElapsed, patient.Illness);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnPatientSentHome(Patient patient)
		{
			Owner.LocalPlayerObjectiveData.LogEventPatientSentHome(Owner.DaysElapsed);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnRoomBuilt(Room room)
		{
			Owner.LocalPlayerObjectiveData.LogEventRoomBuilt(Owner.DaysElapsed, room.Definition);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnPlotBought(HospitalPlot plot)
		{
			Owner.LocalPlayerObjectiveData.LogEventPlotBought(Owner.DaysElapsed, plot.Definition);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnLoanTaken(LoanOffer loan)
		{
			Owner.LocalPlayerObjectiveData.LogEventLoanTaken(Owner.DaysElapsed, loan);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}

		private void OnChallengeCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (!(objective is Challenge challenge))
			{
				return;
			}
			VIPChallengeConfig config = challenge.GetConfig<VIPChallengeConfig>();
			if (config != null)
			{
				VisitorDefinition instance = config.VisitorDef.Instance;
				if (instance != null)
				{
					Owner.LocalPlayerObjectiveData.LogEventChallenge(Owner.DaysElapsed, instance);
					Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
				}
			}
		}

		private void LogPlayerHospitalStatusData()
		{
			OnlineChallengeEventHospitalStatus onlineChallengeEventHospitalStatus = new OnlineChallengeEventHospitalStatus();
			onlineChallengeEventHospitalStatus.Day = Owner.DaysElapsed;
			onlineChallengeEventHospitalStatus.Type = OnlineChallengeEvent.Event.ObjectiveStatus;
			onlineChallengeEventHospitalStatus.DoctorCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Doctor);
			onlineChallengeEventHospitalStatus.NurseCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Nurse);
			onlineChallengeEventHospitalStatus.JanitorCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Janitor);
			onlineChallengeEventHospitalStatus.AssistantCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Assistant);
			onlineChallengeEventHospitalStatus.PatientCount = Level.CharacterManager.Patients.Count;
			onlineChallengeEventHospitalStatus.Reputation = Level.ReputationTracker.OverallReputation;
			onlineChallengeEventHospitalStatus.PrestigeLevel = Level.PrestigeTracker.Level;
			onlineChallengeEventHospitalStatus.PrestigeProgress = Level.PrestigeTracker.Progress;
			onlineChallengeEventHospitalStatus.Balance = Level.FinanceManager.Balance;
			onlineChallengeEventHospitalStatus.FoundationValue = Level.Metagame.TotalFoundationValue();
			onlineChallengeEventHospitalStatus.FoundationShareValue = (int)Level.Metagame.GetShareValue();
			onlineChallengeEventHospitalStatus.FoundationStars = Level.Metagame.TotalStars();
			onlineChallengeEventHospitalStatus.FoundationSilver = Level.Metagame.TotalSilverCumulative();
			Owner.LocalPlayerObjectiveData.LogEvent(onlineChallengeEventHospitalStatus);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}
	}
}
