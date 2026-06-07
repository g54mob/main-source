using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DV.Common;
using DV.Localization;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UI
{
	public class UserProfileProvider : AUserProfileProvider
	{
		[SerializeField]
		private DVUserNamingProvider namingProvider;

		private int cachedTotalJobLicenseCount = -1;

		private int cachedTotalGeneralLicenseCount = -1;

		private UserManager UM => SingletonBehaviour<UserManager>.Instance;

		public override bool HasLastUsedUserProfile => GetCurrentProfile() != null;

		public override bool CanCreateNewProfile => UM.CanCreateNewUser();

		public override IGameSession CurrentSession => UM.CurrentUser?.CurrentSession;

		public override bool HasLastPlayedCareerSession => GetLastPlayedSessionForGameMode("Career") != null;

		public override bool HasLastPlayedFreeRoamSession => GetLastPlayedSessionForGameMode("FreeRoam") != null;

		public override bool HasCareerSessions => GetSessionsForGameMode("Career").Count != 0;

		public override bool HasFreeRoamSessions => GetSessionsForGameMode("FreeRoam").Count != 0;

		public override bool HasLastPlayedSessionForAnyGameMode => UM.CurrentUser?.CurrentSession != null;

		public int TotalJobLicensesCount
		{
			get
			{
				if (cachedTotalJobLicenseCount < 0)
				{
					cachedTotalJobLicenseCount = Globals.G.Types.jobLicenses.Count - (Globals.G.Types.jobLicenses.Contains(JobLicenses.Basic.ToV2()) ? 1 : 0);
				}
				return cachedTotalJobLicenseCount;
			}
		}

		public int TotalGeneralLicensesCount
		{
			get
			{
				if (cachedTotalGeneralLicenseCount < 0)
				{
					cachedTotalGeneralLicenseCount = Globals.G.Types.generalLicenses.Count;
				}
				return cachedTotalGeneralLicenseCount;
			}
		}

		public override bool IsCustomCareerUnlocked
		{
			get
			{
				bool num = SingletonBehaviour<UnlockablesManager>.Instance.UnlockedJobLicenses.Contains("TrainLength1");
				bool flag = SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGeneralLicenses.Contains("ConcurrentJobs1");
				return num || flag;
			}
		}

		public override int TotalExistingLicenseCount => TotalJobLicensesCount + TotalGeneralLicensesCount;

		public override IUserProfile GetCurrentProfile()
		{
			return UM.CurrentUser;
		}

		public override List<IUserProfile> GetProfiles()
		{
			return UM.Users.Cast<IUserProfile>().ToList();
		}

		public override void LoadProfile(IUserProfile profile)
		{
			UM.SaveCurrentUser();
			UM.SwitchUser((User)profile);
			UserProfileLoaded_Fire();
			SessionChanged_Fire();
		}

		public override IUserProfile CreateNewUserProfile(string name)
		{
			User result = UM.CreateUser(name);
			SessionChanged_Fire();
			UserProfileLoaded_Fire();
			return result;
		}

		public override void DeleteProfile(IUserProfile profile)
		{
			User user = (User)profile;
			UM.DeleteUser(user);
			UserProfileLoaded_Fire();
			SessionChanged_Fire();
		}

		public override string GetNewUserNameSuggestion()
		{
			List<string> list = (from p in GetProfiles()
				select p.Name).ToList();
			int num = 0;
			string text;
			do
			{
				num++;
				text = $"{namingProvider.DefaultName} {num}";
			}
			while (list.Contains(text));
			return text;
		}

		public override void RenameProfile(IUserProfile profile, string newName)
		{
			User obj = (User)profile;
			obj.Name = newName;
			obj.Save(UserSavingMode.JustUser);
		}

		public override void OpenImportFolderFor(IUserProfile selectedProfile)
		{
			User user = (User)selectedProfile;
			string text = user.UserBasePath + "/ImportSave";
			if (!user.Storage.DirectoryExists(text))
			{
				try
				{
					user.Storage.CreateDirectory(text);
				}
				catch (Exception exception)
				{
					Debug.LogError("ImportSave directory couldn't be created for " + selectedProfile.Name + " at " + text);
					Debug.LogException(exception);
				}
			}
			if (user.Storage.DirectoryExists(text))
			{
				Util.OpenFolder(user.Storage.GetFilesystemPath(text));
			}
			else
			{
				Debug.LogWarning("ImportSave directory doesn't exist and couldn't be created, doing nothing.");
			}
		}

		public override bool HasLastPlayedSessionForGameMode(string gameMode)
		{
			return GetLastPlayedSessionForGameMode(gameMode) != null;
		}

		public override IGameSession GetLastPlayedSessionForGameMode(string gameMode)
		{
			UM.CurrentUser.CurrentSessionPerMode.TryGetValue(gameMode, out var value);
			return value;
		}

		public override int GetLastPlayedSessionIdForGameMode(string gameMode)
		{
			return GetLastPlayedSessionForGameMode(gameMode)?.SessionID ?? (-1);
		}

		public override IGameSession GetLastPlayedSession()
		{
			return UM.CurrentUser.CurrentSession;
		}

		public override int GetLastPlayedSessionId()
		{
			return GetLastPlayedSession()?.SessionID ?? (-1);
		}

		public override List<IGameSession> GetSessionsForGameMode(string gameMode)
		{
			UM.CurrentUser.Sessions.TryGetValue(gameMode, out var value);
			return value?.Cast<IGameSession>().ToList() ?? new List<IGameSession>();
		}

		public override bool HasSessionWithID(int sessionID)
		{
			return GetSessionByID(sessionID) != null;
		}

		public override IGameSession GetSessionByID(int sessionID)
		{
			return GetAllSessions().FirstOrDefault((IGameSession s) => s.SessionID == sessionID);
		}

		public override ISaveGame GetLastPlayedCareerSave()
		{
			return GetLastPlayedSessionForGameMode("Career")?.LatestSave;
		}

		public override ISaveGame GetLastPlayedFreeRoamSave()
		{
			return GetLastPlayedSessionForGameMode("FreeRoam")?.LatestSave;
		}

		public override ISaveGame GetLastPlayedSaveForGameMode(string gameMode)
		{
			return GetLastPlayedSessionForGameMode(gameMode)?.LatestSave;
		}

		public override ISaveGame GetLastPlayedSave()
		{
			return UM.CurrentUser.CurrentSession?.LatestSave;
		}

		public override bool IsValidGameMode(string gameMode)
		{
			return GetGameModes().Contains(gameMode);
		}

		public override List<string> GetGameModes()
		{
			return UM.GameModes.ToList();
		}

		public override string LocalizeGameMode(string gameMode)
		{
			return LocalizationAPI.L(UM.GetLocalizationKey(gameMode));
		}

		public override bool IsManualSavingAllowed()
		{
			if (!GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.SaveGame))
			{
				return false;
			}
			if (IsSavingRestrictedByPhotoMode())
			{
				return false;
			}
			if (DevSceneUtil.IsGameScene())
			{
				return SingletonBehaviour<SaveGameManager>.Instance.SaveAllowed();
			}
			return true;
		}

		public override bool IsSavingRestrictedByTutorial()
		{
			return !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.SaveGame);
		}

		public override bool IsSavingRestrictedByPhotoMode()
		{
			if (SingletonBehaviour<PlayerCameraSwitcher>.Instance == null || SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera == null)
			{
				return false;
			}
			return SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode;
		}

		public override bool IsInSingleSaveMode(IGameSession session)
		{
			if (session != null)
			{
				if (!IsDifficultyPicked(session))
				{
					return false;
				}
				return session.GetDifficulty().SingleSaveMode;
			}
			if (SceneSwitcher.IsInGameWorld)
			{
				return Globals.G.GameParams.SingleSaveMode;
			}
			return false;
		}

		public override bool IsDifficultyPicked(IGameSession session)
		{
			if (session.GameData["Difficulty_picked"] != null)
			{
				return session.GameData.Value<bool>("Difficulty_picked");
			}
			return true;
		}

		public override void CopySettings(IUserProfile from, IUserProfile to)
		{
			User otherUser = (User)from;
			((User)to).CopyPreferencesFrom(otherUser);
		}

		public override void CopyCareerSaves(IUserProfile from, IUserProfile to)
		{
			User user = (User)from;
			User user2 = (User)to;
			int num = 0;
			if (user.Sessions.TryGetValue("Career", out var value))
			{
				foreach (IGameSession item in value)
				{
					user2.CopySessionFrom(user, (GameSession)item);
					num++;
				}
			}
			Debug.Log("Copied " + num + " career save(s)");
		}

		public override void CopyFreeRoamSaves(IUserProfile from, IUserProfile to)
		{
			User user = (User)from;
			User user2 = (User)to;
			int num = 0;
			if (user.Sessions.TryGetValue("FreeRoam", out var value))
			{
				foreach (IGameSession item in value)
				{
					user2.CopySessionFrom(user, (GameSession)item);
					num++;
				}
			}
			Debug.Log("Copied " + num + " free roam save(s)");
		}

		public override void CopyAllSaves(IUserProfile from, IUserProfile to)
		{
			User user = (User)from;
			User user2 = (User)to;
			int num = 0;
			foreach (KeyValuePair<string, ReadOnlyObservableCollection<IGameSession>> session in user.Sessions)
			{
				foreach (IGameSession item in session.Value)
				{
					user2.CopySessionFrom(user, (GameSession)item);
					num++;
				}
			}
			Debug.Log("Copied " + num + " save(s)");
		}

		public override IGameSession CreateNewSession(string sessionName, string gameMode)
		{
			GameSession gameSession = UM.CurrentUser.StartSession(gameMode, "World1");
			gameSession.Name = sessionName;
			gameSession.Save();
			SessionChanged_Fire();
			return gameSession;
		}

		public override void DeleteSession(IGameSession session)
		{
			if (session is GameSession session2)
			{
				IGameSession currentSession = UM.CurrentUser.CurrentSession;
				UM.CurrentUser.DeleteSession(session2);
				if (UM.CurrentUser.CurrentSession != currentSession)
				{
					SessionChanged_Fire();
				}
			}
			else
			{
				Debug.Log("Tried to delete a session that wasn't a GameSession (" + (session?.Name ?? "null") + ")");
			}
		}

		public override IGameSession BranchOutSession(ISaveGame sourceSave, string sessionName)
		{
			IGameSession parentSession = sourceSave.ParentSession;
			GameSession gameSession = UM.CurrentUser.StartSession(sourceSave.ParentSession.GameMode, sourceSave.ParentSession.World, sessionName);
			foreach (KeyValuePair<string, JToken> gameDatum in parentSession.GameData)
			{
				gameSession.GameData.Add(gameDatum.Key, gameDatum.Value.DeepClone());
			}
			try
			{
				List<string> files = sourceSave.GetFiles(null);
				UM.Storage.CreateDirectory(gameSession.BasePath + "/Saves");
				foreach (string item in files)
				{
					UM.Storage.CopyFile(item, gameSession.BasePath + "/Saves/" + Path.GetFileName(item));
				}
				gameSession.ForceRefreshSaves();
				gameSession.Save();
				SessionChanged_Fire();
				return gameSession;
			}
			catch (Exception ex)
			{
				Debug.LogError("Error branching session: " + ex.Message);
				Debug.LogException(ex);
				return null;
			}
		}

		public override ISaveGameplayInfo GetSaveGameplayInfo(ISaveGame save)
		{
			return new SaveGameplayInfo(save);
		}

		public override ISaveGame SaveGame(SaveType type)
		{
			try
			{
				ISaveGame saveGame = SingletonBehaviour<SaveGameManager>.Instance.Save(type);
				if (saveGame != null)
				{
					Debug.Log(string.Format("Game saved ({0}) at {1}", type, DateTime.Now.ToString("h:mm:ss")));
				}
				else
				{
					Debug.LogError("Saving isn't allowed at the moment");
				}
				return saveGame;
			}
			catch (Exception ex)
			{
				Debug.LogError($"Saving {type} failed: {ex.Message}");
				Debug.LogException(ex);
				return null;
			}
		}

		public override ISaveGame OverwriteSave(ISaveGame save, SaveType newType)
		{
			try
			{
				ISaveGame saveGame = SingletonBehaviour<SaveGameManager>.Instance.Save(newType, save);
				if (saveGame != null)
				{
					Debug.Log(string.Format("Game overwritten ({0}) at {1}", newType, DateTime.Now.ToString("h:mm:ss")));
				}
				else
				{
					Debug.LogError("Saving isn't allowed at the moment");
				}
				return saveGame;
			}
			catch (Exception ex)
			{
				Debug.LogError("Overwriting save " + save.Name + " failed: " + ex.Message);
				Debug.LogException(ex);
				return null;
			}
		}

		public override void LoadGame(ISaveGame save)
		{
			AStartGameData.Continue(save, useSessionDifficulty: true);
			SceneSwitcher.SwitchToScene(DVScenes.Game);
		}

		public override void FlushChanges()
		{
			UM.SaveCurrentUser();
		}

		public override void SetSessionDifficulty(IGameSession session, IDifficulty difficulty)
		{
			if (session != null && difficulty != null)
			{
				session.SetDifficulty(difficulty);
			}
		}

		public override IDifficulty GetSessionDifficulty(IGameSession session)
		{
			return session?.GetDifficulty();
		}

		public override string GetLastUsedDifficulty(IUserProfile user, string gameMode)
		{
			string text = "Last_used_difficulty_" + gameMode;
			if (user != null && user.GameData[text] != null)
			{
				return user.GameData.Value<string>(text);
			}
			return "";
		}

		public override void SetLastUsedDifficulty(IUserProfile user, string difficultyName, string gameMode)
		{
			if (user != null)
			{
				user.GameData["Last_used_difficulty_" + gameMode] = difficultyName;
			}
		}

		public override string GetDefaultDifficultyForGameMode(string gameMode)
		{
			if (gameMode == "Career")
			{
				return "Standard";
			}
			if (gameMode == "FreeRoam")
			{
				return "Standard Sandbox";
			}
			Debug.LogError("Game mode " + gameMode + " doesn't have a default difficulty, defaulting to Standard");
			return "Standard";
		}

		public override IScenario GetSessionScenario(IGameSession session, IScenarioCRUD crud)
		{
			return session?.GetScenario(crud);
		}

		public override void SetSessionScenario(IGameSession session, IScenario scenario, IScenarioCRUD crud)
		{
			session.SetScenario(scenario, crud);
		}

		public override void ApplyNewGameData(IGameSession session, IScenario scenario, IScenarioCRUD crud)
		{
			if (session.GameMode == "FreeRoam")
			{
				SetSessionScenario(session, scenario, crud);
			}
		}

		private List<IGameSession> GetAllSessions()
		{
			return UM.CurrentUser.Sessions.Values.SelectMany((ReadOnlyObservableCollection<IGameSession> ls) => ls).Cast<IGameSession>().ToList();
		}

		public override string GetFilesystemPath(string userManagementPath)
		{
			return UM.Storage.GetFilesystemPath(userManagementPath);
		}
	}
}
