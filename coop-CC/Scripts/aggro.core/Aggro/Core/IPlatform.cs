using System;
using System.Threading.Tasks;

namespace Aggro.Core
{
	public interface IPlatform
	{
		Task<bool> InitializeAsync(Action<PlatformGameJoin> onJoinGame);

		PlatformType GetPlatformType();

		bool HasPlatformJoin();

		bool HasPlatformInvite();

		Task<bool> CreateLobbyAsync(bool allowFriends, int playerCount);

		void LeaveLobby();

		void SetLobbyJoinable(bool isJoinable);

		void SetLobbyAllowFriends(bool allowFriends);

		string GetUserName();

		Task<Platform.JoinListError> OpenJoinList();

		string GetAccountId();

		ulong GetPlatformId();

		string GetPlayFabId();

		void OpenInviteList();

		bool ShouldPause();

		bool HasPendingInvite();

		Task<PlatformGameJoin> AcceptPendingInvite();

		Task<bool> RefreshGlobalStatsAsync();

		void SetStat(string id, int stat);

		void SetStat(string id, float stat);

		void FlushStatsAndAchievements();

		bool TryGetStat(string id, out int stat);

		bool TryGetStat(string id, out float stat);

		bool TryGetGlobalStat(string id, out long stat);

		bool TryGetGlobalStat(string id, out double stat);

		void UnlockAchievement(string id);

		void ResetStatsAndAchievements();

		Task<byte[]> LoadSaveAsync(string filepath);

		Task SaveAsync(string filepath, byte[] bytes);

		Task DeleteSaveAsync(string filepath);

		bool DoesSaveExist(string filepath);

		bool IsOnline();

		bool PlayerMutedByPlatform(ulong platformId);

		bool PlayerMutedByPlatform(string playfabId);

		void ShowProfile(ulong platformId);
	}
}
