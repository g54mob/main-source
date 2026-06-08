using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kitchen;
using Kitchen.NetworkSupport;
using KitchenData;
using Photon.Realtime;
using Platforms.MockPlatform;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platforms
{
	public abstract class Platform : IAsyncFileSystem
	{
		public enum MultiplayerAccessResult
		{
			Unset = 0,
			Checking = 1,
			Success = 2,
			NoInternet = 3,
			NoAccount = 4,
			NoPremium = 5,
			PromptedError = 6
		}

		private static Platform _Current;

		public RichPresenceData RichPresenceData;

		protected bool GameHasFocusOverride = true;

		private const string CONSOLE_PHYSICAL_DLC_NAME = "SwitchPhysicalEdition";

		private const int CONSOLE_PHYSICAL_DLC_ID = 4293;

		public TaskCompletionSource<bool> AchievementInitialisationCompleteSource = new TaskCompletionSource<bool>();

		protected AchievementStore AchievementStore;

		public bool DiscordEnabled;

		public int CurrentFSIMReadCount = 2;

		public NetworkInviteData QueuedJoinTarget;

		private HashSet<string> NetworkAccessRequests = new HashSet<string>();

		protected HashSet<PlatformUser> CurrentUsers = new HashSet<PlatformUser>();

		private HashSet<PlatformUser> CurrentUserTemp = new HashSet<PlatformUser>();

		private HashSet<PlatformUser> UsersToRemove = new HashSet<PlatformUser>();

		public static Platform Current
		{
			get
			{
				return _Current;
			}
			protected set
			{
				Debug.Log($"Platform set to {value}");
				_Current = value;
			}
		}

		public virtual bool IsPlaytesting => false;

		public virtual bool GameHasFocus
		{
			get
			{
				if (Application.isFocused)
				{
					return GameHasFocusOverride;
				}
				return false;
			}
		}

		public virtual bool ShouldPauseWhenNotFocused => !PlatformSettings.IsPC;

		public virtual bool SupportsLeaderboards => false;

		public virtual bool AllLocalUsersRequireMultiplayerSubscription => true;

		public virtual bool AllowsBlockingRead => false;

		public Task<bool> AchievementInitialisationComplete => AchievementInitialisationCompleteSource.Task;

		public virtual bool CanShowAchievementProgress => AchievementProgress().total > 0;

		protected virtual bool SupportsDiscordOnPlatform => PlatformSettings.IsPC;

		public virtual string FSIMFilename => "save.fs";

		public virtual string FSIMBackupFilename => "save_backup.fs";

		public virtual string FSIMFlagName => "fsim_status.txt";

		public virtual NetworkedPlayState NetworkPlayState { get; set; }

		public virtual int RemotePeerCount { get; set; }

		public virtual NetworkInviteData CurrentInvitation { get; set; }

		public virtual NetworkPermissions CurrentNetworkPermissions { get; set; }

		public bool HasActiveNetworkAccessRequest => NetworkAccessRequests.Count > 0;

		public virtual PlatformUser PrimaryUser { get; protected set; }

		public static event Action<PlatformUser> OnUserSignOut;

		public static event Action<PlatformUser> OnUserNameChange;

		public event Action<string> OnFileSystemChange;

		public event Action OnClearFileSystemChanges;

		public static void UseMockPlatform()
		{
			Current = new Platforms.MockPlatform.MockPlatform();
		}

		public static void StopUsingMockPlatform()
		{
			if (Current is Platforms.MockPlatform.MockPlatform)
			{
				Current = null;
			}
		}

		protected virtual void Initialise()
		{
			InitialiseAchievements();
			InitialiseDiscord();
		}

		public virtual void Update()
		{
			UpdateDiscord();
		}

		public virtual void ReceiveRichPresenceData(RichPresenceData data)
		{
			RichPresenceData = data;
		}

		public abstract void OpenInviteUI(NetworkInviteData invite);

		public virtual void SetActiveWhileNotFocus(bool active_while_not_focus)
		{
		}

		public virtual void SetCPUBoostMode(bool active)
		{
		}

		public abstract Task<Result<AuthenticationValues>> GetPhotonAuth(bool force_skip_cache = false);

		public abstract MultiplayerAccessResult CanUseMultiplayer(IEnumerable<PlatformUser> main_local_users, bool force_rerun = false);

		public virtual void Quit()
		{
			Application.Quit(0);
		}

		public virtual bool RequiresSoftwareKeyboard()
		{
			return false;
		}

		public virtual bool HasDLC(int dlc_id)
		{
			return false;
		}

		public abstract string GetLocale();

		public virtual string JoinPath(string path1, string path2)
		{
			return path1 + "/" + path2;
		}

		public virtual string[] SplitPath(string path)
		{
			return path.Split('/');
		}

		protected virtual void InitialiseAchievements()
		{
			AchievementInitialisationCompleteSource.TrySetResult(result: true);
		}

		protected abstract Dictionary<string, string> GetAchievementMapping(AchievementConfiguration config);

		public virtual async Task LoadAchievements(AchievementConfiguration achievement_data)
		{
			await AchievementInitialisationComplete;
			AchievementStore = new AchievementStore(RetrieveUserAchievements, GrantUserAchievement, GetAchievementMapping(achievement_data));
		}

		public virtual bool HasAchievement(PlatformUser user, string identifier)
		{
			return AchievementStore?.Has(user, identifier) ?? false;
		}

		public virtual bool HasAchievement(string identifier)
		{
			return AchievementStore?.Has(PrimaryUser, identifier) ?? false;
		}

		public virtual void UnlockAchievement(string identifier, IEnumerable<PlatformUser> users)
		{
			AchievementStore?.Unlock(users, identifier);
		}

		public virtual (int current, int total) AchievementProgress()
		{
			return AchievementStore?.GetProgress(PrimaryUser) ?? (0, 0);
		}

		protected abstract Task<IEnumerable<string>> RetrieveUserAchievements(PlatformUser user);

		protected abstract Task GrantUserAchievement(PlatformUser user, string identifier);

		protected virtual void InitialiseDiscord()
		{
			if (SupportsDiscordOnPlatform)
			{
				DiscordEnabled = DiscordInvitationSystem.Initialise();
			}
		}

		protected virtual void UpdateDiscord()
		{
			if (DiscordEnabled)
			{
				DiscordInvitationSystem.Update(RichPresenceData, CurrentNetworkPermissions);
			}
		}

		protected virtual void HandleDiscordLink()
		{
			if (DiscordEnabled)
			{
				DiscordInvitationSystem.OpenJoinServerUI();
			}
		}

		public virtual void OpenDiscordInvite()
		{
			if (DiscordEnabled)
			{
				DiscordInvitationSystem.OpenInviteUI();
			}
		}

		protected void RaiseOnUserSignOut(PlatformUser user)
		{
			Platform.OnUserSignOut(user);
		}

		protected void RaiseOnNameChange(PlatformUser user)
		{
			Platform.OnUserNameChange(user);
		}

		protected void ReportFileSystemChange(string path)
		{
			this.OnFileSystemChange?.Invoke(path);
		}

		protected void ReportOwnFileSystemChange()
		{
			this.OnClearFileSystemChanges?.Invoke();
		}

		public abstract Task<byte[]> ReadAllBytes(string path);

		public abstract Task WriteAllBytes(string path, byte[] bytes);

		public abstract Task CreateDirectory(string directory);

		public abstract Task DeleteFile(string path);

		public abstract Task<IEnumerable<FileReference>> GetFiles(string path, string ext, bool filter_empty);

		public abstract Task RenameFile(string old_path, string new_path);

		public virtual void SavePlayerPrefs()
		{
			PlayerPrefs.Save();
		}

		public virtual async Task<byte[]> GetFSIMContent()
		{
			try
			{
				byte[] array = await ReadAllBytes(FSIMFlagName);
				EventLog.Files.Report(FileEvent.FSIMLoad, $"Read {FSIMFlagName}, {array == null}, {array?.Length}");
				if (array != null && array.Length != 0 && int.TryParse(Encoding.UTF8.GetString(array), out var result) && result >= CurrentFSIMReadCount)
				{
					return null;
				}
			}
			catch (Exception)
			{
			}
			try
			{
				byte[] array2 = await ReadAllBytes(FSIMBackupFilename);
				if (array2 != null && array2.Length != 0)
				{
					return array2;
				}
			}
			catch (Exception)
			{
			}
			return await ReadAllBytes(FSIMFilename);
		}

		public virtual async Task BackupFSIM()
		{
			EventLog.Files.Report(FileEvent.FSIMMarkLoaded, "Write " + FSIMFlagName);
			await WriteAllBytes(FSIMFlagName, Encoding.UTF8.GetBytes(CurrentFSIMReadCount.ToString()));
		}

		public virtual string FixFSIMFilename(string filename)
		{
			return filename;
		}

		public virtual Task LoadPlayerPrefs()
		{
			return Task.CompletedTask;
		}

		public virtual async Task<(bool, string)> OpenSoftwareKeyboard(string title, int max_len, string placeholder)
		{
			TouchScreenKeyboard keyboard = TouchScreenKeyboard.Open(string.Empty, TouchScreenKeyboardType.ASCIICapable, autocorrection: false, multiline: false, secure: false, alert: false, placeholder, max_len);
			while (keyboard.status == TouchScreenKeyboard.Status.Visible)
			{
				await Task.Delay(50);
			}
			return keyboard.status switch
			{
				TouchScreenKeyboard.Status.Done => (true, keyboard.text ?? ""), 
				_ => (false, ""), 
			};
		}

		public virtual void HandleControllerEvent(InputDevice device, InputDeviceChange event_type)
		{
		}

		public virtual ControllerType GetControllerType(InputDevice device)
		{
			if (device.description.deviceClass == "Keyboard")
			{
				return ControllerType.Keyboard;
			}
			if (device.description.deviceClass == "Mouse")
			{
				return ControllerType.Mouse;
			}
			if (device.description.manufacturer.Contains("Sony") || device.description.deviceClass.Contains("PS5DualSenseGamepad"))
			{
				return ControllerType.Playstation;
			}
			return ControllerType.Xbox;
		}

		public virtual Task SubmitScore(LeaderboardKey key, int score)
		{
			return Task.CompletedTask;
		}

		public virtual Task<(int score, float percentile)> GetScore(LeaderboardKey key, int cached_score, bool modded_mode, bool skip_percentile)
		{
			return Task.FromResult((-1, -1f));
		}

		public virtual string GetPlatformLocalisation(PlatformString key)
		{
			return "Uh oh";
		}

		public abstract string GetInfoString(PlatformUser user);

		public virtual void OpenUserInfoUI(PlatformUser user)
		{
		}

		public virtual string AddAccessRequest(string identifier)
		{
			NetworkAccessRequests.Add(identifier);
			return identifier;
		}

		public virtual void RemoveAccessRequest(string identifier)
		{
			NetworkAccessRequests.Remove(identifier);
		}

		public abstract string GetDisplayName(PlatformUser user);

		public virtual string GetIdentifierString(PlatformUser user)
		{
			return GetDisplayName(user);
		}

		public abstract Task<PlatformUser> GetUserUsingDevice(InputDevice device);

		public virtual Task<PlatformUser> RequestDeviceNewUser(InputDevice device)
		{
			return GetUserUsingDevice(device);
		}

		public virtual void ReportUserColour(PlatformUser user, Color colour)
		{
		}

		public virtual IEnumerable<PlatformUser> GetUsersToRemove()
		{
			return UsersToRemove;
		}

		public virtual void UpdateUsers(IEnumerable<PlatformUser> currently_active_users)
		{
			CurrentUserTemp.Clear();
			CurrentUserTemp.AddRange(currently_active_users);
			foreach (PlatformUser currentUser in CurrentUsers)
			{
				if (!CurrentUserTemp.Contains(currentUser))
				{
					HandleUserLeave(currentUser);
				}
			}
			foreach (PlatformUser item in CurrentUserTemp)
			{
				if (!CurrentUsers.Contains(item))
				{
					HandleUserJoin(item);
				}
			}
			UsersToRemove.RemoveWhere((PlatformUser u) => !CurrentUserTemp.Contains(u));
			HashSet<PlatformUser> currentUserTemp = CurrentUserTemp;
			HashSet<PlatformUser> currentUsers = CurrentUsers;
			CurrentUsers = currentUserTemp;
			CurrentUserTemp = currentUsers;
		}

		protected virtual void HandleUserJoin(PlatformUser user)
		{
		}

		protected virtual void HandleUserLeave(PlatformUser user)
		{
		}

		protected virtual void RequestUserRemoval(PlatformUser user)
		{
			UsersToRemove.Add(user);
		}

		static Platform()
		{
			Platform.OnUserSignOut = delegate
			{
			};
			Platform.OnUserNameChange = delegate
			{
			};
		}
	}
}
