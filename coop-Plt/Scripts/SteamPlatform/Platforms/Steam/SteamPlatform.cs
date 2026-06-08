using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen;
using Kitchen.NetworkSupport;
using KitchenData;
using Photon.Realtime;
using Sirenix.Utilities;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platforms.Steam
{
	public class SteamPlatform : Platform
	{
		private static string AppDataPath = Path.GetDirectoryName(Path.GetDirectoryName(Application.persistentDataPath));

		private NetworkPermissions _CurrentNetworkPermissions;

		protected UserRegistry<SteamUser> UserRegistry = new UserRegistry<SteamUser>();

		private AppId AppID => 1599600;

		public override bool IsPlaytesting => CheckForDevelopmentBranch;

		public static bool CheckForDevelopmentBranch
		{
			get
			{
				try
				{
					return SteamApps.CurrentBetaName.StartsWith("playtest") || SteamApps.CurrentBetaName.StartsWith("development");
				}
				catch (Exception)
				{
					return false;
				}
			}
		}

		public bool Initialized { get; private set; }

		public override bool AllowsBlockingRead => true;

		public override PlatformUser PrimaryUser => UserRegistry.Find(new SteamUser(SteamClient.SteamId, SteamClient.Name));

		public override bool SupportsLeaderboards => true;

		private static string Directory
		{
			get
			{
				if (!CheckForDevelopmentBranch)
				{
					return Path.Combine(AppDataPath, "It's Happening", "PlateUp");
				}
				return Path.Combine(AppDataPath, "It's Happening", "PlateUpPlaytest");
			}
		}

		public override NetworkPermissions CurrentNetworkPermissions
		{
			get
			{
				return _CurrentNetworkPermissions;
			}
			set
			{
				_CurrentNetworkPermissions = value;
				if (_CurrentNetworkPermissions == NetworkPermissions.Open)
				{
					SteamFriends.SetRichPresence("connect", CurrentInvitation.InviteString);
				}
				else
				{
					SteamFriends.SetRichPresence("connect", "");
				}
			}
		}

		public static void SetAsActivePlatform()
		{
			if (PlatformSettings.CurrentPlatformType == PlatformType.Steam)
			{
				(Platform.Current = new SteamPlatform()).Initialise();
			}
		}

		protected override void Initialise()
		{
			if (Initialized)
			{
				return;
			}
			try
			{
				if (!SteamClient.IsValid)
				{
					SteamClient.Init(AppID);
					Kitchen.NetworkSupport.EventLog.Platform.Report(PlatformEvent.Initialise, $"Steam Platform Initialise (AppID {SteamClient.AppId})");
				}
				SteamFriends.OnGameOverlayActivated += SteamFriendsOnOnGameOverlayActivated;
				SetupInvitationHandlers();
				InitialiseFiles();
				base.Initialise();
				Initialized = true;
			}
			catch (Exception ex)
			{
				Kitchen.NetworkSupport.EventLog.Platform.Report(PlatformEvent.Initialise, "Steam initialise failed");
				Kitchen.NetworkSupport.EventLog.Platform.Report(PlatformEvent.Initialise, ex);
				Initialized = false;
			}
		}

		public bool Shutdown()
		{
			if (Initialized)
			{
				try
				{
					SteamClient.Shutdown();
					SteamFriends.OnGameOverlayActivated -= SteamFriendsOnOnGameOverlayActivated;
					ClearInvitationHandlers();
					Initialized = false;
				}
				catch
				{
				}
			}
			return !Initialized;
		}

		private void SteamFriendsOnOnGameOverlayActivated(bool is_opened)
		{
			GameHasFocusOverride = !is_opened;
		}

		public override MultiplayerAccessResult CanUseMultiplayer(IEnumerable<PlatformUser> users, bool force_rerun)
		{
			return MultiplayerAccessResult.Success;
		}

		public override void OpenInviteUI(NetworkInviteData invite_data)
		{
			if (PlatformSettings.IsEditor)
			{
				UnityEngine.Debug.LogWarning("Opening Steam Invite UI (ignoring in Editor)");
				return;
			}
			SteamId steamLobbyFromInvite = GetSteamLobbyFromInvite(invite_data);
			if ((ulong)steamLobbyFromInvite != 0L)
			{
				SteamFriends.OpenGameInviteOverlay(steamLobbyFromInvite);
			}
		}

		public override void Quit()
		{
			Process.GetCurrentProcess().Kill();
		}

		public override bool RequiresSoftwareKeyboard()
		{
			return SteamUtils.IsSteamInBigPictureMode;
		}

		public override async Task<(bool, string)> OpenSoftwareKeyboard(string title, int max_len, string placeholder)
		{
			string result = null;
			bool was_submitted = false;
			SteamUtils.OnGamepadTextInputDismissed += HandleDismiss;
			SteamUtils.ShowGamepadTextInput(GamepadTextInputMode.Normal, GamepadTextInputLineMode.SingleLine, title, max_len, placeholder);
			while (result == null)
			{
				await Task.Delay(50);
			}
			SteamUtils.OnGamepadTextInputDismissed -= HandleDismiss;
			return (was_submitted, result);
			void HandleDismiss(bool was_submitted_inner)
			{
				result = SteamUtils.GetEnteredGamepadText();
				was_submitted = was_submitted_inner;
			}
		}

		public static SteamId GetSteamLobbyFromInvite(NetworkInviteData invite)
		{
			string inviteOfPrefix = PlatformHelpers.GetInviteOfPrefix(invite.InviteString, "STEAM_LOBBY:");
			if (!string.IsNullOrEmpty(inviteOfPrefix))
			{
				if (!ulong.TryParse(inviteOfPrefix, out var result))
				{
					return default(SteamId);
				}
				return result;
			}
			return default(SteamId);
		}

		public static string GetSteamJoinCodeFromInvite(NetworkInviteData invite)
		{
			string inviteOfPrefix = PlatformHelpers.GetInviteOfPrefix(invite.InviteString, "STEAM_CODE:");
			if (!string.IsNullOrEmpty(inviteOfPrefix))
			{
				return inviteOfPrefix;
			}
			return null;
		}

		public override bool HasDLC(int dlc_id)
		{
			return SteamApps.IsDlcInstalled(dlc_id);
		}

		public override string GetLocale()
		{
			return GetGameLocaleFromSteamString(SteamApps.GameLanguage);
		}

		private static string GetGameLocaleFromSteamString(string steam_string)
		{
			return steam_string switch
			{
				"english" => "English", 
				"french" => "French", 
				"german" => "German", 
				"spanish" => "Spanish", 
				"latam" => "Spanish", 
				"polish" => "Polish", 
				"russian" => "Russian", 
				"portuguese" => "PortugueseBrazil", 
				"brazilian" => "PortugueseBrazil", 
				"japanese" => "Japanese", 
				"schinese" => "ChineseSimplified", 
				"tchinese" => "ChineseTraditional", 
				"koreana" => "Korean", 
				"turkish" => "Turkish", 
				_ => "Default", 
			};
		}

		protected override Dictionary<string, string> GetAchievementMapping(AchievementConfiguration config)
		{
			return config.DefaultMapping;
		}

		protected override Task<IEnumerable<string>> RetrieveUserAchievements(PlatformUser user)
		{
			if (!SteamClient.IsValid)
			{
				return Task.FromResult((IEnumerable<string>)new List<string>());
			}
			return Task.FromResult(from e in SteamUserStats.Achievements
				where e.State
				select e.Identifier);
		}

		protected override Task GrantUserAchievement(PlatformUser user, string identifier)
		{
			SteamUserStats.Achievements.Where((Achievement e) => e.Identifier == identifier).ForEach(delegate(Achievement e)
			{
				e.Trigger();
			});
			return Task.CompletedTask;
		}

		public override async Task SubmitScore(LeaderboardKey key, int score)
		{
			Leaderboard? leaderboard = await GetLeaderboard(key);
			if (leaderboard.HasValue)
			{
				await leaderboard.Value.SubmitScoreAsync(score);
			}
		}

		public override async Task<(int score, float percentile)> GetScore(LeaderboardKey key, int cached_score, bool modded_mode, bool skip_percentile)
		{
			Leaderboard? lb = await GetLeaderboard(key);
			if (!lb.HasValue)
			{
				return (score: -1, percentile: -1f);
			}
			if (modded_mode)
			{
				if (cached_score < 0)
				{
					return (score: -1, percentile: -1f);
				}
				if (skip_percentile)
				{
					return (score: cached_score, percentile: -1f);
				}
				float percentile = 1f;
				int offset = 1;
				while (true)
				{
					LeaderboardEntry[] array = await lb.Value.GetScoresAsync(100, offset);
					if (array == null || array.Length == 0)
					{
						break;
					}
					LeaderboardEntry[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						LeaderboardEntry leaderboardEntry = array2[i];
						if (cached_score <= leaderboardEntry.Score)
						{
							percentile = (float)leaderboardEntry.GlobalRank / (float)(lb.Value.EntryCount + 1);
							break;
						}
					}
					offset += array.Length;
				}
				return (score: cached_score, percentile: percentile);
			}
			LeaderboardEntry[] array3 = await lb.Value.GetScoresAroundUserAsync(0, 0);
			if (array3 == null || array3.Length == 0)
			{
				return (score: -1, percentile: -1f);
			}
			LeaderboardEntry leaderboardEntry2 = array3[0];
			return (score: leaderboardEntry2.Score, percentile: (float)leaderboardEntry2.GlobalRank / (float)lb.Value.EntryCount);
		}

		private async Task<Leaderboard?> GetLeaderboard(LeaderboardKey key)
		{
			Leaderboard? result = await SteamUserStats.FindOrCreateLeaderboardAsync(key.Name, LeaderboardSort.Ascending, LeaderboardDisplay.TimeMilliSeconds);
			if (!result.HasValue)
			{
				Kitchen.NetworkSupport.EventLog.Networking.Report(NetworkEvent.LeaderboardNotFound, key.Name);
			}
			return result;
		}

		protected void InitialiseFiles()
		{
			System.IO.Directory.CreateDirectory(Directory);
			FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(Directory);
			fileSystemWatcher.EnableRaisingEvents = true;
			fileSystemWatcher.IncludeSubdirectories = true;
			fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
			fileSystemWatcher.Changed += delegate(object s, FileSystemEventArgs e)
			{
				ReportFileSystemChange(folder(e));
			};
			fileSystemWatcher.Created += delegate(object s, FileSystemEventArgs e)
			{
				ReportFileSystemChange(folder(e));
			};
			fileSystemWatcher.Deleted += delegate(object s, FileSystemEventArgs e)
			{
				ReportFileSystemChange(folder(e));
			};
			fileSystemWatcher.Renamed += delegate(object s, RenamedEventArgs e)
			{
				ReportFileSystemChange(folder(e));
			};
			static string folder(FileSystemEventArgs e)
			{
				return Path.GetFileName(Path.GetDirectoryName(e.FullPath));
			}
		}

		private static string FullPath(string name)
		{
			return Path.Combine(Directory, name);
		}

		public override Task<byte[]> ReadAllBytes(string path)
		{
			return Task.FromResult(File.ReadAllBytes(FullPath(path)));
		}

		public override Task WriteAllBytes(string path, byte[] bytes)
		{
			File.WriteAllBytes(FullPath(path), bytes);
			ReportOwnFileSystemChange();
			return Task.CompletedTask;
		}

		public override Task CreateDirectory(string directory)
		{
			System.IO.Directory.CreateDirectory(FullPath(directory));
			ReportOwnFileSystemChange();
			return Task.CompletedTask;
		}

		public override Task DeleteFile(string path)
		{
			File.Delete(FullPath(path));
			return Task.CompletedTask;
		}

		public override Task RenameFile(string old_path, string new_path)
		{
			File.Move(FullPath(old_path), FullPath(new_path));
			ReportOwnFileSystemChange();
			return Task.CompletedTask;
		}

		public override async Task<IEnumerable<FileReference>> GetFiles(string path, string ext, bool filter_empty)
		{
			return from f in new DirectoryInfo(FullPath(path)).GetFiles()
				where f.Extension == ext && (!filter_empty || f.Length != 0)
				select new FileReference
				{
					Path = f.FullName,
					LastWriteTime = f.LastWriteTime,
					FileName = f.Name
				};
		}

		public override void ReceiveRichPresenceData(RichPresenceData rich_presence)
		{
			base.ReceiveRichPresenceData(rich_presence);
			if (rich_presence.Day > 15)
			{
				SteamFriends.SetRichPresence("day", (rich_presence.Day - 15).ToString());
				SteamFriends.SetRichPresence("gamemode", rich_presence.IsInGame ? "Overtime" : "Planning");
			}
			else
			{
				SteamFriends.SetRichPresence("day", rich_presence.Day.ToString());
				SteamFriends.SetRichPresence("gamemode", rich_presence.IsInGame ? "Restaurant" : "Planning");
			}
			if (rich_presence.IsMultiplayer)
			{
				SteamFriends.SetRichPresence("steam_display", "#Status_Multiplayer");
				SteamFriends.SetRichPresence("players", rich_presence.Players.ToString());
			}
			else
			{
				SteamFriends.SetRichPresence("steam_display", "#Status_Singleplayer");
			}
		}

		private void SetupInvitationHandlers()
		{
			SteamFriends.OnGameRichPresenceJoinRequested += SteamFriendsOnOnGameRichPresenceJoinRequested;
			SteamFriends.OnGameLobbyJoinRequested += OnSteamFriendsOnOnGameLobbyJoinRequested;
		}

		private void ClearInvitationHandlers()
		{
			SteamFriends.OnGameRichPresenceJoinRequested -= SteamFriendsOnOnGameRichPresenceJoinRequested;
			SteamFriends.OnGameLobbyJoinRequested -= OnSteamFriendsOnOnGameLobbyJoinRequested;
		}

		private void OnSteamFriendsOnOnGameLobbyJoinRequested(Lobby lobby, SteamId id)
		{
			QueuedJoinTarget = new NetworkInviteData
			{
				InviteString = PlatformHelpers.CreateNetworkInvite("STEAM_LOBBY:", lobby.Id.Value.ToString())
			};
		}

		private void SteamFriendsOnOnGameRichPresenceJoinRequested(Friend friend, string conn)
		{
			try
			{
				QueuedJoinTarget = new NetworkInviteData
				{
					InviteString = conn
				};
			}
			catch (Exception message)
			{
				UnityEngine.Debug.LogWarning("Tried to join a malformed Steam target (" + conn + ")");
				UnityEngine.Debug.LogWarning(message);
			}
		}

		public override string GetDisplayName(PlatformUser user)
		{
			if (!UserRegistry.GetDetails(user, out var details))
			{
				return PlatformSettings.MissingUserName;
			}
			return details.Name;
		}

		public override string GetInfoString(PlatformUser user)
		{
			return "";
		}

		public override Task<PlatformUser> GetUserUsingDevice(InputDevice device)
		{
			return Task.FromResult(UserRegistry.Find(new SteamUser(SteamClient.SteamId, SteamClient.Name)));
		}

		public override async Task<Result<AuthenticationValues>> GetPhotonAuth(bool force_skip_cache = false)
		{
			if (PlatformSettings.IsEditor)
			{
				return Kitchen.Result.Succeed(new AuthenticationValues());
			}
			AuthTicket authTicket = await Steamworks.SteamUser.GetAuthSessionTicketAsync();
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < authTicket.Data.Length; i++)
			{
				stringBuilder.AppendFormat("{0:x2}", authTicket.Data[i]);
			}
			AuthenticationValues authenticationValues = new AuthenticationValues();
			authenticationValues.UserId = SteamClient.SteamId.ToString();
			authenticationValues.AuthType = CustomAuthenticationType.Steam;
			authenticationValues.AddAuthParameter("ticket", stringBuilder.ToString());
			return Kitchen.Result.Succeed(authenticationValues);
		}
	}
}
