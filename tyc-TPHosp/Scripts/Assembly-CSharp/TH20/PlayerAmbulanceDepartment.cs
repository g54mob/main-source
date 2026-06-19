#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class PlayerAmbulanceDepartment : AmbulanceDepartment
	{
		[DontSave]
		private PlayerAmbulanceDepartmentDefinition _departmentConfig;

		[DontSave]
		public bool DebugAutoAssignAmbulances;

		[DontSave]
		public bool DebugAmbulanceDisembark;

		public GameObject _ambulanceStatusUIPrefab;

		private bool _clownAchievementUnlocked;

		public PlayerAmbulance _pickedUpAmbulance;

		public PlayerAmbulanceDepartmentDefinition Config => _departmentConfig;

		public GameObject AmbulanceStatusUIPrefab => _ambulanceStatusUIPrefab;

		public PlayerAmbulanceDepartment(PlayerAmbulanceDepartmentDefinition config, Level level)
		{
			_departmentConfig = config;
			_departmentDefinitionBase = Config;
			_level = level;
			_ambulanceStatusUIPrefab = _departmentConfig.AmbulanceStatusUIPrefab;
			if (Config?.PlayerFoundationDefinition.Instance != null)
			{
				_foundationName = _level.Metagame.OrganisationName;
				_foundationIcon = Config.PlayerFoundationDefinition.Instance.Icon;
				_foundationStyle = Config.PlayerFoundationDefinition.Instance.FoundationStyle.Instance;
			}
			_ambulances = new List<Ambulance>();
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(CheckAmbulanceUpgradeComplete));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Combine(characterEvents.OnPatientDiedAtScene, new Action<bool, string>(base.OnPatientDiedAtScene));
			RegisterDebugCommands();
			RegisterEvents();
			_stats = new AmbulanceDepartmentStats(level.TimelineManager);
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(CheckAmbulanceUpgradeComplete));
			UnregisterDebugCommands();
			UnRegisterEvents();
			foreach (PlayerAmbulance ambulance in _ambulances)
			{
				ambulance.UnregisterEvents();
			}
			base.Destroy();
		}

		public void Update(float timeDelta)
		{
			if (_ambulances != null)
			{
				for (int i = 0; i < _ambulances.Count; i++)
				{
					_ambulances[i].Update(timeDelta);
				}
			}
		}

		public void CreateAmbulance(AmbulanceConfig config, RoomItem ambulanceItem)
		{
			if (_pickedUpAmbulance != null)
			{
				_ambulances.Add(_pickedUpAmbulance);
				_pickedUpAmbulance = null;
			}
			else
			{
				_ambulances.Add(new PlayerAmbulance(config, this, ambulanceItem));
			}
			Debug_LogOutAmbulanceFleet();
			CheckAmbulanceAchievement();
		}

		private void CheckAmbulanceAchievement()
		{
			List<AmbulanceConfig.UniqueAmbulanceID> list = new List<AmbulanceConfig.UniqueAmbulanceID>();
			foreach (PlayerAmbulance ambulance in _ambulances)
			{
				if (ambulance.AmbulanceItem != null && ambulance.AmbulanceItem.UpgradeLevel >= 2)
				{
					list.AddUnique(ambulance.Config.UniqueAmbulance);
				}
			}
			if (list.Count >= 6)
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.AllAmbulances);
			}
		}

		public void RemoveAmbulance(RoomItem ambulanceItem)
		{
			if (_ambulances.Find((Ambulance ambulance) => ambulance is PlayerAmbulance playerAmbulance2 && playerAmbulance2.AmbulanceItem == ambulanceItem) is PlayerAmbulance playerAmbulance)
			{
				_ambulances.Remove(playerAmbulance);
				Debug_LogOutAmbulanceFleet();
				if (!playerAmbulance.HasBeenSold)
				{
					_pickedUpAmbulance = playerAmbulance;
					_pickedUpAmbulance.OnPickup();
				}
			}
		}

		public void AmbulanceWasSold(Ambulance ambulance)
		{
			if (_pickedUpAmbulance == ambulance)
			{
				_pickedUpAmbulance = null;
			}
		}

		public bool IsAnyAmbulanceManeuvering(Ambulance thisAmbulance, bool entering)
		{
			if (thisAmbulance.AmbulanceType == AmbulanceConfig.Type.Air)
			{
				return false;
			}
			foreach (PlayerAmbulance ambulance in _ambulances)
			{
				if (ambulance == thisAmbulance || ambulance.AmbulanceType == AmbulanceConfig.Type.Air)
				{
					continue;
				}
				if (entering)
				{
					if (ambulance.CurrentState == Ambulance.State.WaitingForClearExitRoute || ambulance.IsDrivingIn)
					{
						return true;
					}
				}
				else if (ambulance.IsReversingIn || ambulance.IsPullingOut)
				{
					return true;
				}
			}
			return false;
		}

		private void CheckAmbulanceUpgradeComplete(RoomItem roomItem, Staff staff)
		{
			foreach (PlayerAmbulance ambulance in _ambulances)
			{
				if (ambulance.AmbulanceItem == roomItem)
				{
					ambulance.OnUpgradeComplete();
					CheckAmbulanceAchievement();
					break;
				}
			}
		}

		private void RegisterDebugCommands()
		{
			ConsoleCommandsDatabase.RegisterCommand("ToggleAutoEmergencyAssignment", "Allows ambulances to assign themselves", "ToggleAutoEmergencyAssignment", Debug_ToggleAutoEmergencyAssignment);
			ConsoleCommandsDatabase.RegisterCommand("ToggleDebugAmbulanceDisembark", "Runs a debug function to catch T-posers on disembark.", "ToggleDebugAmbulanceDisembark", Debug_ToggleDebugAmbulanceDisembark);
		}

		private void UnregisterDebugCommands()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleAutoEmergencyAssignment");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleDebugAmbulanceDisembark");
		}

		private void Debug_LogOutAmbulanceFleet()
		{
			string text = "Player fleet includes: ";
			foreach (Ambulance ambulance in _ambulances)
			{
				text = text + ambulance.Config.AmbulanceName.Translation + ", ";
			}
			Logging.Info(LogChannels.AmbulanceEmergency, text);
		}

		public ConsoleCommandResult Debug_ToggleAutoEmergencyAssignment(string[] args)
		{
			DebugAutoAssignAmbulances = !DebugAutoAssignAmbulances;
			return ConsoleCommandResult.Succeeded();
		}

		public ConsoleCommandResult Debug_ToggleDebugAmbulanceDisembark(string[] args)
		{
			DebugAmbulanceDisembark = !DebugAmbulanceDisembark;
			return ConsoleCommandResult.Succeeded();
		}

		public ConsoleCommandResult Debug_AssignAmbulance(PlayerAmbulance ambulance)
		{
			PlayerAmbulance playerAmbulance = null;
			ChallengeAmbulanceEmergency challengeAmbulanceEmergency = null;
			List<ChallengeAmbulanceEmergency> activeChallengesOfType = _level.ChallengeManager.GetActiveChallengesOfType<ChallengeAmbulanceEmergency>();
			playerAmbulance = ambulance;
			if (playerAmbulance == null)
			{
				return ConsoleCommandResult.Failed("No ambulances of this type are owned and ready for dispatch");
			}
			int index = UnityEngine.Random.Range(0, activeChallengesOfType.Count);
			ChallengeAmbulanceEmergency challengeAmbulanceEmergency2 = activeChallengesOfType[index];
			if (playerAmbulance.CanBeAssignedTo(challengeAmbulanceEmergency2, includeReassign: false) && !challengeAmbulanceEmergency2.IsJourneyFutile(playerAmbulance))
			{
				challengeAmbulanceEmergency = challengeAmbulanceEmergency2;
				if (challengeAmbulanceEmergency.IsJourneyFutile(playerAmbulance))
				{
					return ConsoleCommandResult.Failed("Ambulance did not go to emergency as no patients will be remaining by the time it gets there.");
				}
				challengeAmbulanceEmergency.AssignAmbulance(playerAmbulance);
				challengeAmbulanceEmergency.OnAmbulanceDepartHospital.InvokeSafe(playerAmbulance);
				playerAmbulance.BeginGettingReady();
				Logging.Info(LogChannels.AmbulanceEmergency, $"Ambulance {playerAmbulance.Config.AmbulanceName} has been (debug) dispatched! ({playerAmbulance.CurrentEmergencyDistance} miles out)");
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Ambulance did not go to emergency as no patients will be remaining by the time it gets there.");
		}

		public PlayerAmbulance FindAmbulanceForPatient(Patient patient)
		{
			foreach (Ambulance ambulance in _ambulances)
			{
				if (ambulance is PlayerAmbulance playerAmbulance && playerAmbulance.PatientsCollected.Contains(patient))
				{
					return playerAmbulance;
				}
			}
			return null;
		}

		public void RestoreFromSave(PlayerAmbulanceDepartmentDefinition config, Level level)
		{
			_departmentConfig = config;
			_departmentDefinitionBase = Config;
			RegisterEvents();
			RegisterDebugCommands();
			RestoreFromSave(level);
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(CheckAmbulanceUpgradeComplete));
		}

		public void RestoreAmbulanceFromSave(RoomItem roomItem)
		{
			foreach (PlayerAmbulance ambulance in _ambulances)
			{
				if (ambulance.AmbulanceItemID == roomItem.ID)
				{
					ambulance.RestoreFromSave(roomItem);
				}
			}
		}

		public void AddChallenge(ChallengeAmbulanceEmergency challengeAmbulanceEmergency)
		{
			if (!_emergencyStatTrackers.ContainsKey(challengeAmbulanceEmergency.EmergencyID))
			{
				_emergencyStatTrackers.Add(challengeAmbulanceEmergency.EmergencyID, new EmergencyStatTracker(challengeAmbulanceEmergency.TotalPatients, challengeAmbulanceEmergency.IsRescue));
			}
		}

		private void OnPatientCollected(List<Patient> patients, string emergencyID)
		{
			_emergencyStatTrackers[emergencyID].Patients.AddRange(patients);
			_emergencyStatTrackers[emergencyID].StatsContainer.IncrementStat(AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCollected, patients.Count);
			base.Stats.IncrementStat(AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCollected, patients.Count);
			CheckForAchievement(patients);
		}

		private void IncrementStat(Patient patient, AmbulanceDepartmentStats.AmbulanceDepartmentStat statType)
		{
			if (patient.IsAEPatient && _emergencyStatTrackers.ContainsKey(patient.AmbulanceEmergencyID))
			{
				_emergencyStatTrackers[patient.AmbulanceEmergencyID].StatsContainer.IncrementStat(statType);
				_emergencyStatTrackers[patient.AmbulanceEmergencyID].Patients.Remove(patient);
				base.Stats.IncrementStat(statType);
				CheckAllPatientsProcessed();
			}
		}

		private void CheckAllPatientsProcessed()
		{
			foreach (KeyValuePair<string, EmergencyStatTracker> emergencyStatTracker in _emergencyStatTrackers)
			{
				if (!emergencyStatTracker.Value.IsActive && emergencyStatTracker.Value.Patients.Count == 0)
				{
					if (!_emergencyStatTrackers.ContainsKey(emergencyStatTracker.Key))
					{
						Logging.Error(LogChannels.AmbulanceEmergency, "Trying to write stats for emergency now dealt with but no stat tracker exists.");
						break;
					}
					int score = CalculateChallengeScore(_emergencyStatTrackers[emergencyStatTracker.Key]);
					base.Stats.PushReputationScore(score);
					_emergencyStatTrackers.Remove(emergencyStatTracker.Key);
					break;
				}
			}
		}

		private void CheckForAchievement(List<Patient> patients)
		{
			if (_clownAchievementUnlocked || patients.Count == 0)
			{
				return;
			}
			int ambulanceID = patients[0].AmbulanceID;
			foreach (PlayerAmbulance ambulance in _ambulances)
			{
				if (ambulance.ID == ambulanceID && ambulance.Config.UniqueAmbulance == AmbulanceConfig.UniqueAmbulanceID.Clown && patients.Count == 20)
				{
					PlatformStatsAndAchievements.TriggerAchievement(AchievementId.ClownCarCollectAndCure);
					_clownAchievementUnlocked = true;
				}
			}
		}

		public void RespondingToEmergency(ChallengeAmbulanceEmergency emergency)
		{
			if (!_emergencyStatTrackers.ContainsKey(emergency.EmergencyID))
			{
				Logging.Error(LogChannels.AmbulanceEmergency, "Trying to respond to emergency with no stat tracker for it.");
			}
			_emergencyStatTrackers[emergency.EmergencyID].DidRespond = true;
		}

		public void EmergencyOver(ChallengeAmbulanceEmergency emergency)
		{
			if (_emergencyStatTrackers.ContainsKey(emergency.EmergencyID))
			{
				_emergencyStatTrackers[emergency.EmergencyID].IsActive = false;
			}
		}

		private void RegisterEvents()
		{
			if (_level?.ChallengeEvents != null)
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Combine(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientCollected));
				CharacterEvents characterEvents2 = _level.CharacterEvents;
				characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				CharacterEvents characterEvents3 = _level.CharacterEvents;
				characterEvents3.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents3.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents4 = _level.CharacterEvents;
				characterEvents4.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents4.OnPatientDied, new Action<Patient>(OnPatientDied));
				CharacterEvents characterEvents5 = _level.CharacterEvents;
				characterEvents5.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
				CharacterEvents characterEvents6 = _level.CharacterEvents;
				characterEvents6.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents6.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
				CharacterEvents characterEvents7 = _level.CharacterEvents;
				characterEvents7.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents7.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			}
		}

		private void UnRegisterEvents()
		{
			if (_level?.ChallengeEvents != null)
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Remove(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientCollected));
				CharacterEvents characterEvents2 = _level.CharacterEvents;
				characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				CharacterEvents characterEvents3 = _level.CharacterEvents;
				characterEvents3.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents3.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents4 = _level.CharacterEvents;
				characterEvents4.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents4.OnPatientDied, new Action<Patient>(OnPatientDied));
				CharacterEvents characterEvents5 = _level.CharacterEvents;
				characterEvents5.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
				CharacterEvents characterEvents6 = _level.CharacterEvents;
				characterEvents6.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents6.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
				CharacterEvents characterEvents7 = _level.CharacterEvents;
				characterEvents7.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents7.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			}
		}

		private void OnPatientCured(Patient patient, List<Staff> staffList)
		{
			IncrementStat(patient, AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCured);
		}

		private void OnPatientSentHome(Patient patient)
		{
			IncrementStat(patient, AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCureFailed);
		}

		private void OnPatientDied(Patient patient)
		{
			IncrementStat(patient, AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsDied);
		}

		private void OnPatientRageQuit(Patient patient)
		{
			IncrementStat(patient, AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCureFailed);
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> staffList)
		{
			IncrementStat(patient, AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCureFailed);
		}

		private void OnFatalTreatment(Patient patient, List<Staff> staffList)
		{
			IncrementStat(patient, AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsDied);
		}
	}
}
