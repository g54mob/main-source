using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Steamworks;
using UnityEngine;

namespace Aggro.Core
{
	public class SteamPlatform : IPlatform
	{
		private enum InitializationState
		{
			NotInitialized = 0,
			Errored = 1,
			Initialzied = 2
		}

		private CSteamID _lobbyId;

		private InitializationState _initState;

		private Action<PlatformGameJoin> _onJoinGame;

		private Callback<GameOverlayActivated_t> _overlayCallback;

		private Callback<LobbyEnter_t> _lobbyEnterCallback;

		private Callback<GameLobbyJoinRequested_t> _gameLobbyJoinRequestedCallback;

		private Callback<UserStatsStored_t> _userStatsStored;

		private bool _isOverlayActive;

		private bool _disableAutoJoin;

		private string _userName;

		private const string HOST_ADDRESS_KEY = "HostAddressKey";

		public async Task<bool> InitializeAsync(Action<PlatformGameJoin> onJoinGame)
		{
			await Task.Yield();
			if (_initState != InitializationState.NotInitialized)
			{
				return _initState == InitializationState.Initialzied;
			}
			if (SteamManager.Initialized)
			{
				if (await GetCurrentStatsAsync() != EResult.k_EResultOK)
				{
					_initState = InitializationState.Errored;
					return false;
				}
				_initState = InitializationState.Initialzied;
				_onJoinGame = onJoinGame;
				_overlayCallback = Callback<GameOverlayActivated_t>.Create(OnOverlayActivated);
				_lobbyEnterCallback = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
				_gameLobbyJoinRequestedCallback = Callback<GameLobbyJoinRequested_t>.Create(OnGameLobbyJoinRequested);
				_userStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatStored);
				Debug.Log("[SteamPlatform] Initialized");
				return true;
			}
			Debug.LogWarning("[SteamPlatform] SteamManager not initialized!");
			_initState = InitializationState.Errored;
			return false;
		}

		public PlatformType GetPlatformType()
		{
			if (SteamUtils.IsSteamRunningOnSteamDeck())
			{
				return PlatformType.SteamDeck;
			}
			return PlatformType.Steam;
		}

		public bool HasPlatformJoin()
		{
			return SteamUtils.IsOverlayEnabled();
		}

		public bool HasPlatformInvite()
		{
			return SteamUtils.IsOverlayEnabled();
		}

		private void OnOverlayActivated(GameOverlayActivated_t param)
		{
			_isOverlayActive = param.m_bActive > 0;
		}

		private void OnLobbyEntered(LobbyEnter_t enter)
		{
			if (_disableAutoJoin)
			{
				return;
			}
			LeaveLobby();
			switch ((EChatRoomEnterResponse)enter.m_EChatRoomEnterResponse)
			{
			case EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess:
				_lobbyId = new CSteamID(enter.m_ulSteamIDLobby);
				if (!(SteamMatchmaking.GetLobbyOwner(_lobbyId) == SteamUser.GetSteamID()))
				{
					string lobbyData = SteamMatchmaking.GetLobbyData(_lobbyId, "HostAddressKey");
					_onJoinGame(new PlatformGameJoin(PlatformError.Success, lobbyData));
				}
				break;
			case EChatRoomEnterResponse.k_EChatRoomEnterResponseFull:
				_onJoinGame(new PlatformGameJoin(PlatformError.LobbyFull));
				break;
			default:
				_onJoinGame(new PlatformGameJoin(PlatformError.UnknownError));
				break;
			}
		}

		private void OnGameLobbyJoinRequested(GameLobbyJoinRequested_t param)
		{
			if (param.m_steamIDLobby.IsValid())
			{
				SteamMatchmaking.JoinLobby(param.m_steamIDLobby);
			}
			else
			{
				Debug.LogWarning("[SteamPlatform] Invalid lobby with GameLobbyJoinRequested_t");
			}
		}

		private void OnUserStatStored(UserStatsStored_t param)
		{
			if (param.m_eResult != EResult.k_EResultOK)
			{
				Debug.LogWarning($"[SteamPlatform] SteamUserStats::StoreStats failed! Result: 0x{(int)param.m_eResult:X8}");
			}
		}

		public async Task<bool> CreateLobbyAsync(bool allowFriendsToJoin, int playerCount)
		{
			if (_initState != InitializationState.Initialzied)
			{
				await Task.Yield();
				return false;
			}
			ELobbyType eLobbyType = (allowFriendsToJoin ? ELobbyType.k_ELobbyTypeFriendsOnly : ELobbyType.k_ELobbyTypePrivate);
			LobbyCreated_t lobbyCreatedT = default(LobbyCreated_t);
			Callback<LobbyCreated_t> onLobbyCreated = Callback<LobbyCreated_t>.Create(delegate(LobbyCreated_t r)
			{
				lobbyCreatedT = r;
			});
			SteamMatchmaking.CreateLobby(eLobbyType, playerCount);
			while (lobbyCreatedT.m_eResult == EResult.k_EResultNone)
			{
				await Task.Yield();
			}
			onLobbyCreated.Dispose();
			if (lobbyCreatedT.m_eResult != EResult.k_EResultOK)
			{
				Debug.LogError($"[SteamNetwork] SteamMatchMaking::CreateLobby failed! Reason: 0x{(int)lobbyCreatedT.m_eResult:X8}");
				return false;
			}
			_lobbyId = new CSteamID(lobbyCreatedT.m_ulSteamIDLobby);
			if (!SteamMatchmaking.SetLobbyData(_lobbyId, "HostAddressKey", SteamUser.GetSteamID().ToString()))
			{
				Debug.LogError("[SteamNetwork] SteamMatchMaking::SetLobbyData failed!");
				SteamMatchmaking.LeaveLobby(_lobbyId);
				_lobbyId = CSteamID.Nil;
				return false;
			}
			return true;
		}

		public void LeaveLobby()
		{
			if (_lobbyId.IsValid())
			{
				SteamMatchmaking.LeaveLobby(_lobbyId);
				_lobbyId = CSteamID.Nil;
			}
		}

		public void SetLobbyJoinable(bool isJoinable)
		{
			if (_initState == InitializationState.Initialzied && _lobbyId.IsValid())
			{
				SteamMatchmaking.SetLobbyJoinable(_lobbyId, isJoinable);
			}
		}

		public void SetLobbyAllowFriends(bool allowFriends)
		{
			if (_initState == InitializationState.Initialzied && _lobbyId.IsValid())
			{
				SteamMatchmaking.SetLobbyType(_lobbyId, allowFriends ? ELobbyType.k_ELobbyTypeFriendsOnly : ELobbyType.k_ELobbyTypePrivate);
			}
		}

		public string GetUserName()
		{
			if (string.IsNullOrEmpty(_userName))
			{
				Regex regex = new Regex("<[^>]*>");
				_userName = regex.Replace(SteamFriends.GetPersonaName(), "");
			}
			return _userName;
		}

		public Task<Platform.JoinListError> OpenJoinList()
		{
			SteamFriends.ActivateGameOverlay("Friends");
			return Task.FromResult(Platform.JoinListError.None);
		}

		public string GetAccountId()
		{
			return SteamUser.GetSteamID().GetAccountID().ToString();
		}

		public ulong GetPlatformId()
		{
			return SteamUser.GetSteamID().m_SteamID;
		}

		public string GetPlayFabId()
		{
			return string.Empty;
		}

		public void OpenInviteList()
		{
			if (_initState == InitializationState.Initialzied && _lobbyId.IsValid())
			{
				SteamFriends.ActivateGameOverlayInviteDialog(_lobbyId);
			}
		}

		public bool ShouldPause()
		{
			return _isOverlayActive;
		}

		public bool HasPendingInvite()
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length - 1; i++)
			{
				if (commandLineArgs[i] == "+connect_lobby" && ulong.TryParse(commandLineArgs[i + 1], out var _))
				{
					return true;
				}
			}
			return false;
		}

		public async Task<PlatformGameJoin> AcceptPendingInvite()
		{
			LeaveLobby();
			ulong result = 0uL;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length - 1 && (!(commandLineArgs[i] == "+connect_lobby") || !ulong.TryParse(commandLineArgs[i + 1], out result)); i++)
			{
			}
			EChatRoomEnterResponse? result2 = null;
			ulong lobbyId = 0uL;
			CallResult<LobbyEnter_t> callResult = CallResult<LobbyEnter_t>.Create(delegate(LobbyEnter_t x, bool bIOFailure)
			{
				if (bIOFailure)
				{
					result2 = EChatRoomEnterResponse.k_EChatRoomEnterResponseError;
				}
				else
				{
					result2 = (EChatRoomEnterResponse)x.m_EChatRoomEnterResponse;
				}
				lobbyId = x.m_ulSteamIDLobby;
			});
			_disableAutoJoin = true;
			SteamAPICall_t hAPICall = SteamMatchmaking.JoinLobby(new CSteamID(result));
			callResult.Set(hAPICall);
			while (!result2.HasValue)
			{
				await Task.Yield();
			}
			_disableAutoJoin = false;
			switch (result2.Value)
			{
			case EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess:
				_lobbyId = new CSteamID(lobbyId);
				return new PlatformGameJoin(PlatformError.Success, SteamMatchmaking.GetLobbyData(_lobbyId, "HostAddressKey"));
			case EChatRoomEnterResponse.k_EChatRoomEnterResponseFull:
				return new PlatformGameJoin(PlatformError.LobbyFull);
			default:
				return new PlatformGameJoin(PlatformError.UnknownError);
			}
		}

		private async Task<EResult> GetCurrentStatsAsync()
		{
			EResult result = EResult.k_EResultNone;
			Callback<UserStatsReceived_t> statsCallback = Callback<UserStatsReceived_t>.Create(delegate(UserStatsReceived_t x)
			{
				result = x.m_eResult;
			});
			if (!SteamUserStats.RequestCurrentStats())
			{
				statsCallback.Dispose();
				Debug.LogError("[SteamPlatform] SteamUserStats::RequestCurrentStats failed!");
				return EResult.k_EResultUnexpectedError;
			}
			while (result == EResult.k_EResultNone)
			{
				await Task.Yield();
			}
			statsCallback.Dispose();
			if (result != EResult.k_EResultOK)
			{
				Debug.LogError($"[SteamPlatform] SteamUserStats::RequestCurrentStats Error! Result: 0x{(int)result:X8}");
			}
			return result;
		}

		public async Task<bool> RefreshGlobalStatsAsync()
		{
			if (_initState != InitializationState.Initialzied)
			{
				return false;
			}
			if (await GetCurrentStatsAsync() != EResult.k_EResultOK)
			{
				_initState = InitializationState.Errored;
				return false;
			}
			EResult result = EResult.k_EResultNone;
			CallResult<GlobalStatsReceived_t> callresult = CallResult<GlobalStatsReceived_t>.Create(delegate(GlobalStatsReceived_t x, bool bIOFailure)
			{
				if (bIOFailure)
				{
					Debug.LogError($"IO Failure! Result was: 0x{(int)x.m_eResult:X8}");
					result = EResult.k_EResultIOFailure;
				}
				else
				{
					result = x.m_eResult;
				}
			});
			SteamAPICall_t hAPICall = SteamUserStats.RequestGlobalStats(0);
			callresult.Set(hAPICall);
			while (result == EResult.k_EResultNone)
			{
				await Task.Yield();
			}
			callresult.Dispose();
			if (result != EResult.k_EResultOK)
			{
				Debug.LogError($"[SteamPlatform] SteamUserStats::RequestGlobalStats Error! Result: 0x{(int)result:X8}");
				return false;
			}
			return true;
		}

		public void SetStat(string id, int stat)
		{
			if (_initState == InitializationState.Initialzied && !SteamUserStats.SetStat(id, stat))
			{
				Debug.LogWarning($"[SteamPlatform] SteamUserStats::SetStat failed! Id: {id} Data: {stat}");
			}
		}

		public void SetStat(string id, float stat)
		{
			if (_initState == InitializationState.Initialzied && !SteamUserStats.SetStat(id, stat))
			{
				Debug.LogWarning($"[SteamPlatform] SteamUserStats::SetStat failed! Id: {id} Data: {stat}");
			}
		}

		public void FlushStatsAndAchievements()
		{
			if (!SteamUserStats.StoreStats())
			{
				Debug.LogWarning("[SteamPlatform] SteamUserStats::StoreStats failed!");
			}
		}

		public bool TryGetStat(string id, out int stat)
		{
			return SteamUserStats.GetStat(id, out stat);
		}

		public bool TryGetStat(string id, out float stat)
		{
			return SteamUserStats.GetStat(id, out stat);
		}

		public bool TryGetGlobalStat(string id, out long stat)
		{
			return SteamUserStats.GetGlobalStat(id, out stat);
		}

		public bool TryGetGlobalStat(string id, out double stat)
		{
			return SteamUserStats.GetGlobalStat(id, out stat);
		}

		public void UnlockAchievement(string id)
		{
			Debug.Log("[SteamPlatform] Unlocking achievement " + id);
			SteamUserStats.GetAchievement(id, out var pbAchieved);
			if (!SteamUserStats.SetAchievement(id))
			{
				Debug.LogWarning("[SteamPlatform] SteamUserStats::SetAchievement failed!");
			}
			if (!pbAchieved && !SteamUserStats.StoreStats())
			{
				Debug.LogWarning("[SteamPlatform] SteamUserStats::StoreStats failed!");
			}
		}

		public void ResetStatsAndAchievements()
		{
			if (!SteamUserStats.ResetAllStats(bAchievementsToo: true))
			{
				Debug.LogWarning("[SteamPlatform] SteamUserStats::ResetAllStats failed!");
			}
			if (!SteamUserStats.StoreStats())
			{
				Debug.LogWarning("[SteamPlatform] SteamUserStats::StoreStats failed!");
			}
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
			return SteamUser.BLoggedOn();
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
			if (SteamUtils.IsOverlayEnabled())
			{
				CSteamID steamID = new CSteamID(platformId);
				SteamFriends.ActivateGameOverlayToUser("steamid", steamID);
			}
		}
	}
}
