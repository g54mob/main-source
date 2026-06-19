using System.Threading.Tasks;
using UnityEngine;

namespace Aggro.Core
{
	public static class Platform
	{
		private enum InitializeResult
		{
			NotInitialized = 0,
			Success = 1,
			Failure = 2
		}

		public enum JoinListError
		{
			None = 0,
			NoJoinAvailable = 1,
			NotInitialized = 2
		}

		private static InitializeResult _result;

		private static IPlatform _platform;

		private static PlatformGameJoin _pendingJoin;

		public static bool hasPendingJoin { get; private set; }

		public static async Task<bool> InitializeAsync()
		{
			if (_result == InitializeResult.NotInitialized)
			{
				_platform = new GameCorePlatform();
				if (await _platform.InitializeAsync(OnJoinedLobby))
				{
					_result = InitializeResult.Success;
				}
				else
				{
					_result = InitializeResult.Failure;
				}
			}
			return _result == InitializeResult.Success;
		}

		public static PlatformType GetPlatformType()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.GetPlatformType();
			}
			return PlatformType.None;
		}

		public static IPlatform GetPlatformInterface()
		{
			if (_result != InitializeResult.Success)
			{
				return null;
			}
			return _platform;
		}

		private static void OnJoinedLobby(PlatformGameJoin invite)
		{
			hasPendingJoin = true;
			_pendingJoin = invite;
		}

		public static PlatformGameJoin GetAndConsumeJoin()
		{
			hasPendingJoin = false;
			return _pendingJoin;
		}

		public static bool HasPlatformJoin()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.HasPlatformJoin();
			}
			return false;
		}

		public static bool HasPlatformInvite()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.HasPlatformInvite();
			}
			return false;
		}

		public static bool HasPendingInvite()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.HasPendingInvite();
			}
			return false;
		}

		public static async Task<PlatformGameJoin> AcceptPendingInvite()
		{
			if (_result == InitializeResult.Success)
			{
				return await _platform.AcceptPendingInvite();
			}
			await Task.Yield();
			return new PlatformGameJoin(PlatformError.UnknownError);
		}

		public static async Task<bool> CreateLobbyAsync(bool allowFriends, int playerCount)
		{
			if (_result == InitializeResult.Success)
			{
				return await _platform.CreateLobbyAsync(allowFriends, playerCount);
			}
			await Task.Yield();
			return false;
		}

		public static void LeaveLobby()
		{
			if (_result == InitializeResult.Success)
			{
				_platform.LeaveLobby();
			}
		}

		public static void SetLobbyJoinable(bool isJoinable)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.SetLobbyJoinable(isJoinable);
			}
		}

		public static void SetLobbyAllowFriends(bool allowFriends)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.SetLobbyAllowFriends(allowFriends);
			}
		}

		public static string GetUserName()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.GetUserName();
			}
			return "<UNKNOWN>";
		}

		public static async Task<JoinListError> OpenJoinList()
		{
			if (_result == InitializeResult.Success)
			{
				return await _platform.OpenJoinList();
			}
			return JoinListError.NoJoinAvailable;
		}

		public static string GetAccountId()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.GetAccountId();
			}
			return "ERROR_ID";
		}

		public static ulong GetPlatformId()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.GetPlatformId();
			}
			return 0uL;
		}

		public static string GetPlayFabId()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.GetPlayFabId();
			}
			return "ERROR_ID";
		}

		public static void OpenInviteList()
		{
			if (_result == InitializeResult.Success)
			{
				_platform.OpenInviteList();
			}
		}

		public static bool ShouldPause()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.ShouldPause();
			}
			return false;
		}

		public static async Task<bool> RefreshGlobalStatsAsync()
		{
			if (_result == InitializeResult.Success)
			{
				return await _platform.RefreshGlobalStatsAsync();
			}
			return false;
		}

		public static void SetStat(string id, int stat)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.SetStat(id, stat);
			}
		}

		public static void SetStat(string id, float stat)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.SetStat(id, stat);
			}
		}

		public static void AddStat(string id, int stat)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.TryGetStat(id, out int stat2);
				_platform.SetStat(id, stat2 + stat);
			}
		}

		public static void AddStat(string id, float stat)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.TryGetStat(id, out float stat2);
				_platform.SetStat(id, stat2 + stat);
			}
		}

		public static void FlushStatsAndAchievements()
		{
			if (_result == InitializeResult.Success)
			{
				_platform.FlushStatsAndAchievements();
			}
		}

		public static bool TryGetStat(string id, out int stat)
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.TryGetStat(id, out stat);
			}
			stat = 0;
			return false;
		}

		public static bool TryGetStat(string id, out float stat)
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.TryGetStat(id, out stat);
			}
			stat = 0f;
			return false;
		}

		public static bool TryGetGlobalStat(string id, out long stat)
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.TryGetGlobalStat(id, out stat);
			}
			stat = 0L;
			return false;
		}

		public static bool TryGetGlobalStat(string id, out double stat)
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.TryGetGlobalStat(id, out stat);
			}
			stat = 0.0;
			return false;
		}

		public static void UnlockAchievement(string id)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.UnlockAchievement(id);
			}
		}

		public static void ResetStatsAndAchievements()
		{
			if (_result == InitializeResult.Success)
			{
				_platform.ResetStatsAndAchievements();
			}
		}

		public static async Task<byte[]> LoadSaveAsync(string filepath)
		{
			if (_result == InitializeResult.Success)
			{
				return await _platform.LoadSaveAsync(filepath);
			}
			Debug.Log($"[{Time.frameCount}] [Platform] [LoadSaveAsync] Initialization status is {_result}, cannot load save yet!");
			await Task.Yield();
			return new byte[0];
		}

		public static async Task SaveAsync(string filepath, byte[] bytes)
		{
			if (_result == InitializeResult.Success)
			{
				await _platform.SaveAsync(filepath, bytes);
			}
			else
			{
				await Task.Yield();
			}
		}

		public static async Task DeleteSaveAsync(string filepath)
		{
			if (_result == InitializeResult.Success)
			{
				await _platform.DeleteSaveAsync(filepath);
			}
			else
			{
				await Task.Yield();
			}
		}

		public static bool DoesSaveExist(string filepath)
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.DoesSaveExist(filepath);
			}
			return false;
		}

		public static bool IsOnline()
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.IsOnline();
			}
			return true;
		}

		public static bool PlayerMutedByPlatform()
		{
			if (_result == InitializeResult.Success)
			{
				if (!_platform.PlayerMutedByPlatform(GetPlatformId()))
				{
					return _platform.PlayerMutedByPlatform(GetPlayFabId());
				}
				return true;
			}
			return false;
		}

		public static bool PlayerMutedByPlatform(ulong platformId)
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.PlayerMutedByPlatform(platformId);
			}
			return false;
		}

		public static bool PlayerMutedByPlatform(string PlayFabId)
		{
			if (_result == InitializeResult.Success)
			{
				return _platform.PlayerMutedByPlatform(PlayFabId);
			}
			return false;
		}

		public static void ShowProfile(ulong PlatformId)
		{
			if (_result == InitializeResult.Success)
			{
				_platform.ShowProfile(PlatformId);
			}
		}
	}
}
