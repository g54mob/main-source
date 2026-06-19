using System;
using System.Threading.Tasks;

namespace Aggro.Core
{
	public class EditorPlatform : IPlatform
	{
		public async Task<bool> InitializeAsync(Action<PlatformGameJoin> onJoinGame)
		{
			await Task.Yield();
			return true;
		}

		public PlatformType GetPlatformType()
		{
			return PlatformType.PC;
		}

		public bool HasPlatformJoin()
		{
			return false;
		}

		public bool HasPlatformInvite()
		{
			return false;
		}

		public async Task<bool> CreateLobbyAsync(bool allowFriends, int playerCount)
		{
			await Task.Yield();
			return true;
		}

		public void LeaveLobby()
		{
		}

		public void SetLobbyJoinable(bool isJoinable)
		{
		}

		public void SetLobbyAllowFriends(bool allowFriends)
		{
		}

		public string GetUserName()
		{
			return "EDITOR";
		}

		public Task<Platform.JoinListError> OpenJoinList()
		{
			return Task.FromResult(Platform.JoinListError.NoJoinAvailable);
		}

		public string GetAccountId()
		{
			return "EDITOR";
		}

		public ulong GetPlatformId()
		{
			return 0uL;
		}

		public string GetPlayFabId()
		{
			return string.Empty;
		}

		public void OpenInviteList()
		{
		}

		public bool ShouldPause()
		{
			return false;
		}

		public bool HasPendingInvite()
		{
			return false;
		}

		public Task<PlatformGameJoin> AcceptPendingInvite()
		{
			throw new NotImplementedException();
		}

		public async Task<bool> RefreshGlobalStatsAsync()
		{
			await Task.Yield();
			return true;
		}

		public void SetStat(string id, int stat)
		{
		}

		public void SetStat(string id, float stat)
		{
		}

		public void FlushStatsAndAchievements()
		{
		}

		public bool TryGetStat(string id, out int stat)
		{
			stat = 777;
			return true;
		}

		public bool TryGetStat(string id, out float stat)
		{
			stat = 777f;
			return true;
		}

		public bool TryGetGlobalStat(string id, out long stat)
		{
			stat = 777L;
			return true;
		}

		public bool TryGetGlobalStat(string id, out double stat)
		{
			stat = 777.0;
			return true;
		}

		public void UnlockAchievement(string id)
		{
		}

		public void ResetStatsAndAchievements()
		{
		}

		public Task<byte[]> LoadSaveAsync(string filepath)
		{
			return PlatformUtil.LoadGameAsync(filepath);
		}

		public Task SaveAsync(string filepath, byte[] bytes)
		{
			return PlatformUtil.SaveGameAsync(filepath, bytes);
		}

		public Task DeleteSaveAsync(string filepath)
		{
			return PlatformUtil.DeleteSaveAsync(filepath);
		}

		public bool DoesSaveExist(string filepath)
		{
			return PlatformUtil.DoesSaveExist(filepath);
		}

		public bool IsOnline()
		{
			return true;
		}

		public bool PlayerMutedByPlatform(ulong platformId)
		{
			return false;
		}

		public bool PlayerMutedByPlatform(string playfabId)
		{
			return false;
		}

		public void ShowProfile(ulong platformId)
		{
		}
	}
}
