using System;
using System.Collections.Generic;
using DV.Common;
using DV.Scenarios.Common;
using UnityEngine;

namespace DV.UI
{
	public abstract class AUserProfileProvider : MonoBehaviour
	{
		public const string CAREER = "Career";

		public const string FREEROAM = "FreeRoam";

		public abstract bool HasLastUsedUserProfile { get; }

		public abstract bool CanCreateNewProfile { get; }

		public abstract IGameSession CurrentSession { get; }

		public abstract bool HasCareerSessions { get; }

		public abstract bool HasFreeRoamSessions { get; }

		public abstract bool HasLastPlayedCareerSession { get; }

		public abstract bool HasLastPlayedFreeRoamSession { get; }

		public abstract bool HasLastPlayedSessionForAnyGameMode { get; }

		public abstract bool IsCustomCareerUnlocked { get; }

		public abstract int TotalExistingLicenseCount { get; }

		public event Action UserProfileChanged;

		public event Action SessionChanged;

		protected void UserProfileLoaded_Fire()
		{
			this.UserProfileChanged?.Invoke();
		}

		protected void SessionChanged_Fire()
		{
			this.SessionChanged?.Invoke();
		}

		public abstract IUserProfile GetCurrentProfile();

		public abstract List<IUserProfile> GetProfiles();

		public abstract void LoadProfile(IUserProfile profile);

		public abstract IUserProfile CreateNewUserProfile(string name);

		public abstract string GetNewUserNameSuggestion();

		public abstract void RenameProfile(IUserProfile profile, string newName);

		public abstract void DeleteProfile(IUserProfile profile);

		public abstract void OpenImportFolderFor(IUserProfile selectedProfile);

		public abstract bool HasLastPlayedSessionForGameMode(string gameMode);

		public abstract IGameSession GetLastPlayedSessionForGameMode(string gameMode);

		public abstract int GetLastPlayedSessionIdForGameMode(string gameMode);

		public abstract IGameSession GetLastPlayedSession();

		public abstract int GetLastPlayedSessionId();

		public abstract List<IGameSession> GetSessionsForGameMode(string gameMode);

		public abstract bool HasSessionWithID(int sessionID);

		public abstract IGameSession GetSessionByID(int sessionID);

		public abstract ISaveGame GetLastPlayedCareerSave();

		public abstract ISaveGame GetLastPlayedFreeRoamSave();

		public abstract ISaveGame GetLastPlayedSaveForGameMode(string gameMode);

		public abstract ISaveGame GetLastPlayedSave();

		public abstract List<string> GetGameModes();

		public abstract string LocalizeGameMode(string gameMode);

		public abstract bool IsValidGameMode(string gameMode);

		public abstract bool IsManualSavingAllowed();

		public abstract bool IsSavingRestrictedByTutorial();

		public abstract bool IsSavingRestrictedByPhotoMode();

		public abstract bool IsInSingleSaveMode(IGameSession session);

		public abstract bool IsDifficultyPicked(IGameSession session);

		public abstract void CopySettings(IUserProfile from, IUserProfile to);

		public abstract void CopyCareerSaves(IUserProfile from, IUserProfile to);

		public abstract void CopyFreeRoamSaves(IUserProfile from, IUserProfile to);

		public abstract void CopyAllSaves(IUserProfile from, IUserProfile to);

		public abstract IGameSession CreateNewSession(string sessionName, string gameMode);

		public abstract void DeleteSession(IGameSession session);

		public abstract void SetSessionDifficulty(IGameSession session, IDifficulty difficulty);

		public abstract IDifficulty GetSessionDifficulty(IGameSession session);

		public abstract string GetLastUsedDifficulty(IUserProfile user, string gameMode);

		public abstract void SetLastUsedDifficulty(IUserProfile user, string difficultyName, string gameMode);

		public abstract string GetDefaultDifficultyForGameMode(string gameMode);

		public abstract void ApplyNewGameData(IGameSession session, IScenario scenario, IScenarioCRUD crud);

		public abstract void SetSessionScenario(IGameSession session, IScenario scenario, IScenarioCRUD crud);

		public abstract IScenario GetSessionScenario(IGameSession session, IScenarioCRUD crud);

		public abstract ISaveGameplayInfo GetSaveGameplayInfo(ISaveGame save);

		public abstract ISaveGame SaveGame(SaveType type);

		public abstract ISaveGame OverwriteSave(ISaveGame save, SaveType newType);

		public abstract IGameSession BranchOutSession(ISaveGame sourceSave, string sessionName);

		public abstract void LoadGame(ISaveGame save);

		public abstract void FlushChanges();

		public abstract string GetFilesystemPath(string userManagementPath);
	}
}
