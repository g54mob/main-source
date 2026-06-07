using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Steamworks;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class SteamLobbyManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CLoadAvatarCoroutine_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SteamLobbyManager _003C_003E4__this;

			public CSteamID steamId;

			public Action<Texture2D> onLoaded;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLoadAvatarCoroutine_003Ed__93(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Steam Settings")]
		[SerializeField]
		private bool useSteam;

		[SerializeField]
		private uint steamAppId;

		private CSteamID currentLobbyId;

		private bool isHost;

		private string currentLobbyCode;

		private Dictionary<CSteamID, LobbyPlayerInfo> lobbyPlayers;

		private Dictionary<ulong, ulong> clientIdToSteamId;

		private Dictionary<CSteamID, Texture2D> avatarCache;

		private HashSet<CSteamID> loadingAvatars;

		private CallResult<LobbyCreated_t> lobbyCreatedCallResult;

		private CallResult<LobbyEnter_t> lobbyEnterCallResult;

		private CallResult<LobbyMatchList_t> lobbyMatchListCallResult;

		private Callback<LobbyDataUpdate_t> lobbyDataUpdateCallback;

		private Callback<LobbyChatUpdate_t> lobbyChatUpdateCallback;

		private Callback<P2PSessionRequest_t> p2pSessionRequestCallback;

		private Callback<GameLobbyJoinRequested_t> gameLobbyJoinRequestedCallback;

		private bool steamInitialized;

		private CSteamID pendingJoinLobbyId;

		public static SteamLobbyManager Instance { get; private set; }

		public bool HasPendingJoin => false;

		public event Action<bool, string> OnLobbyCreated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<bool, string> OnLobbyJoined
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnLobbyLeft
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<string> OnPlayerJoined
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<string> OnPlayerLeft
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<List<LobbyListEntry>> OnLobbyListUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CSteamID> OnSteamJoinRequested
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void InitializeSteam()
		{
		}

		private void RegisterCallbacks()
		{
		}

		private void CheckCommandLineJoin()
		{
		}

		private void CheckEarlyPendingJoin()
		{
		}

		private void OnGameLobbyJoinRequested(GameLobbyJoinRequested_t callback)
		{
		}

		public CSteamID ConsumePendingJoin()
		{
			return default(CSteamID);
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void CreateLobby(string lobbyName, int maxPlayers, ELobbyType visibility)
		{
		}

		private void OnLobbyCreatedCallback(LobbyCreated_t callback, bool bIOFailure)
		{
		}

		public void JoinLobbyByCode(string lobbyCode)
		{
		}

		public void JoinLobby(CSteamID lobbyId)
		{
		}

		private void OnLobbyEnterCallback(LobbyEnter_t callback, bool bIOFailure)
		{
		}

		private string GetEnterResponseError(uint response)
		{
			return null;
		}

		public void RequestLobbyList(bool isCodeLookup = false)
		{
		}

		private void OnLobbyMatchListCallback(LobbyMatchList_t callback, bool bIOFailure, bool isCodeLookup)
		{
		}

		public void LeaveLobby()
		{
		}

		private void ClearAvatarCache()
		{
		}

		public void InviteFriends()
		{
		}

		private void RefreshPlayerList()
		{
		}

		private void OnLobbyDataUpdate(LobbyDataUpdate_t callback)
		{
		}

		private void OnLobbyChatUpdate(LobbyChatUpdate_t callback)
		{
		}

		private void OnP2PSessionRequest(P2PSessionRequest_t callback)
		{
		}

		public bool IsSteamAvailable()
		{
			return false;
		}

		public bool IsInLobby()
		{
			return false;
		}

		public bool IsHost()
		{
			return false;
		}

		public string GetLobbyCode()
		{
			return null;
		}

		public CSteamID GetLobbyId()
		{
			return default(CSteamID);
		}

		public string GetLobbyName()
		{
			return null;
		}

		public int GetMaxPlayers()
		{
			return 0;
		}

		public int GetCurrentPlayers()
		{
			return 0;
		}

		public Dictionary<CSteamID, LobbyPlayerInfo> GetLobbyPlayers()
		{
			return null;
		}

		public CSteamID GetLocalSteamId()
		{
			return default(CSteamID);
		}

		public string GetLocalPlayerName()
		{
			return null;
		}

		public void SetGameInProgress(bool inProgress)
		{
		}

		public bool IsGameInProgress(CSteamID lobbyId)
		{
			return false;
		}

		public static string GetGameVersion()
		{
			return null;
		}

		public string GetLobbyVersion(CSteamID lobbyId)
		{
			return null;
		}

		public bool IsLobbyVersionCompatible(CSteamID lobbyId)
		{
			return false;
		}

		public void RegisterClientSteamId(ulong clientId, ulong steamId)
		{
		}

		public void UnregisterClientSteamId(ulong clientId)
		{
		}

		public ulong GetSteamIdForClient(ulong clientId)
		{
			return 0uL;
		}

		public void ClearClientSteamIdMappings()
		{
		}

		public void PrePopulateClientSteamIdMappings()
		{
		}

		public Texture2D GetPlayerAvatar(CSteamID steamId)
		{
			return null;
		}

		public void LoadPlayerAvatarAsync(CSteamID steamId, Action<Texture2D> onLoaded)
		{
		}

		[IteratorStateMachine(typeof(_003CLoadAvatarCoroutine_003Ed__93))]
		private IEnumerator LoadAvatarCoroutine(CSteamID steamId, Action<Texture2D> onLoaded)
		{
			return null;
		}

		private Texture2D GetSteamImageAsTexture(int imageHandle)
		{
			return null;
		}

		private void FlipImageVertically(byte[] imageData, int width, int height)
		{
		}
	}
}
