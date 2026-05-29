using System;
using System.Linq;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/quick-match-lobby-control")]
	public class QuickMatchLobbyControl : MonoBehaviour
	{
		public enum Status
		{
			Idle = 0,
			Searching = 1,
			WaitingForStart = 2,
			Starting = 3
		}

		[Serializable]
		private struct AuthMessage
		{
			public int valid;

			public byte[] data;
		}

		[Header("UI Settings")]
		[Tooltip("Enabled when the control is not searching for a lobby or waiting for a lobby to fill")]
		public GameObject idleGroup;

		[Tooltip("Enabled when the control is search for a lobby or waiting for a lobby to fill")]
		public GameObject processingGroup;

		[Header("Lobby Management")]
		public bool updateRichPresenceGroupData = true;

		public EAuthSessionResponse[] kickWhen = new EAuthSessionResponse[8]
		{
			EAuthSessionResponse.k_EAuthSessionResponseAuthTicketCanceled,
			EAuthSessionResponse.k_EAuthSessionResponseAuthTicketInvalid,
			EAuthSessionResponse.k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed,
			EAuthSessionResponse.k_EAuthSessionResponseLoggedInElseWhere,
			EAuthSessionResponse.k_EAuthSessionResponseNoLicenseOrExpired,
			EAuthSessionResponse.k_EAuthSessionResponsePublisherIssuedBan,
			EAuthSessionResponse.k_EAuthSessionResponseUserNotConnectedToSteam,
			EAuthSessionResponse.k_EAuthSessionResponseVACBanned
		};

		public SearchArguments searchArguments = new SearchArguments();

		public CreateArguments createArguments = new CreateArguments();

		[Header("Events")]
		public UnityEvent evtProcessStarted;

		public UnityEvent evtProcessStopped;

		public LobbyDataEvent evtLobbyFull;

		public GameServerSetEvent evtGameCreated;

		public LobbyDataEvent evtEnterSuccess;

		public LobbyResponceEvent evtEnterFailed;

		public EResultEvent evtCreateFailed;

		public UnityEvent evtStateChanged;

		private bool cancelRequest;

		private float enterTime;

		private ulong filledId;

		public LobbyData Lobby { get; set; }

		public LobbyMemberData Owner => Lobby.Owner;

		public LobbyMemberData Me => Lobby.Me;

		public bool HasLobby
		{
			get
			{
				if (Lobby != CSteamID.Nil.m_SteamID)
				{
					return SteamMatchmaking.GetNumLobbyMembers(Lobby) > 0;
				}
				return false;
			}
		}

		public bool Searching { get; private set; }

		public bool IsPlayerOwner
		{
			get
			{
				if (HasLobby)
				{
					return Lobby.IsOwner;
				}
				return false;
			}
		}

		public bool AllPlayersReady
		{
			get
			{
				if (HasLobby)
				{
					return Lobby.AllPlayersReady;
				}
				return false;
			}
		}

		public bool IsPlayerReady
		{
			get
			{
				return Matchmaking.Client.GetLobbyMemberData(Lobby, User.Client.Id, "z_heathenReady") == "true";
			}
			set
			{
				Matchmaking.Client.SetLobbyMemberData(Lobby, "z_heathenReady", value.ToString().ToLower());
			}
		}

		public bool Full
		{
			get
			{
				if (HasLobby)
				{
					return Lobby.Full;
				}
				return false;
			}
		}

		public int Slots
		{
			get
			{
				if (!HasLobby)
				{
					return 0;
				}
				return SteamMatchmaking.GetLobbyMemberLimit(Lobby);
			}
		}

		public int MemberCount
		{
			get
			{
				if (!HasLobby)
				{
					return 0;
				}
				return SteamMatchmaking.GetNumLobbyMembers(Lobby);
			}
		}

		public LobbyGameServer GameServer
		{
			get
			{
				if (!HasLobby)
				{
					return default(LobbyGameServer);
				}
				return Lobby.GameServer;
			}
		}

		public Status WorkingStatus
		{
			get
			{
				if (!HasLobby && !Searching)
				{
					return Status.Idle;
				}
				if (Searching)
				{
					return Status.Searching;
				}
				if (HasLobby && !Lobby.HasServer)
				{
					return Status.WaitingForStart;
				}
				return Status.Starting;
			}
		}

		public float Timer => Time.unscaledTime - enterTime;

		private void Start()
		{
			if (LobbyData.SessionLobby(out var lobby))
			{
				Lobby = lobby;
			}
			Matchmaking.Client.EventLobbyChatMsg.AddListener(HandleChatMessage);
			Matchmaking.Client.EventLobbyEnterSuccess.AddListener(HandleLobbyEnterSuccess);
			Matchmaking.Client.EventLobbyAskedToLeave.AddListener(HandleLobbyKickRequest);
			Matchmaking.Client.EventLobbyDataUpdate.AddListener(HandleLobbyDataUpdated);
			Matchmaking.Client.EventLobbyChatUpdate.AddListener(HandleChatUpdate);
			Matchmaking.Client.EventLobbyGameCreated.AddListener(HandleGameServerSet);
			RefreshUI();
		}

		private void OnDestroy()
		{
			Matchmaking.Client.EventLobbyChatMsg.RemoveListener(HandleChatMessage);
			Matchmaking.Client.EventLobbyEnterSuccess.RemoveListener(HandleLobbyEnterSuccess);
			Matchmaking.Client.EventLobbyAskedToLeave.RemoveListener(HandleLobbyKickRequest);
			Matchmaking.Client.EventLobbyDataUpdate.RemoveListener(HandleLobbyDataUpdated);
			Matchmaking.Client.EventLobbyChatUpdate.RemoveListener(HandleChatUpdate);
			Matchmaking.Client.EventLobbyGameCreated.RemoveListener(HandleGameServerSet);
		}

		private void Update()
		{
			if (HasLobby && filledId != Lobby && Lobby.Full)
			{
				filledId = Lobby;
				evtLobbyFull.Invoke(Lobby);
			}
		}

		private void HandleChatUpdate(LobbyChatUpdate_t arg0)
		{
			if (arg0.m_ulSteamIDLobby == Lobby && arg0.m_rgfChatMemberStateChange == 1)
			{
				Friends.Client.SetPlayedWith(arg0.m_ulSteamIDUserChanged);
				evtStateChanged.Invoke();
			}
		}

		private void HandleLobbyKickRequest(LobbyData arg0)
		{
			if (arg0 == Lobby)
			{
				Debug.LogWarning("We have been asked to leave the lobby, this usually happens when we fail authentication with the lobby Owner.");
				Lobby.Leave();
				Lobby = default(LobbyData);
				RefreshUI();
			}
		}

		private void HandleLobbyDataUpdated(LobbyDataUpdateEventData arg0)
		{
			if (arg0.lobby == Lobby)
			{
				RefreshUI();
			}
		}

		private void HandleLobbyEnterSuccess(LobbyEnter_t arg0)
		{
			LobbyData lobby = arg0.m_ulSteamIDLobby;
			if (!lobby.IsSession)
			{
				return;
			}
			enterTime = Time.unscaledTime;
			filledId = 0uL;
			Lobby = lobby;
			if (LobbyData.GroupLobby(out var lobby2))
			{
				lobby2.SendChatMessage("[SessionId]" + Lobby.ToString());
			}
			RefreshUI();
			if (IsPlayerOwner)
			{
				return;
			}
			Authentication.GetAuthSessionTicket(Lobby.Owner.user, delegate(AuthenticationTicket ticket, bool error)
			{
				if (!error)
				{
					Lobby.SendChatMessage(new AuthMessage
					{
						valid = 1,
						data = ticket.Data
					});
				}
			});
		}

		private void HandleChatMessage(LobbyChatMsg message)
		{
			if (!(message.lobby == Lobby) || kickWhen.Length == 0 || !IsPlayerOwner || !message.TryFromJson<AuthMessage>(out var result) || result.valid != 1)
			{
				return;
			}
			Authentication.BeginAuthSession(result.data, message.sender, delegate(AuthenticationSession data)
			{
				if (data.User != message.sender || kickWhen.Contains(data.Response))
				{
					Debug.LogWarning($"{message.sender.Nickname} failed authentication with state {data.Response} and is being asked to leave.");
					Lobby.KickMember(data.User);
				}
				data.End();
			});
		}

		private void HandleGameServerSet(LobbyGameCreated_t arg0)
		{
			if (arg0.m_ulSteamIDLobby == Lobby)
			{
				evtGameCreated.Invoke(Lobby.GameServer);
				evtStateChanged.Invoke();
			}
		}

		private void RefreshUI()
		{
			if (!HasLobby)
			{
				if (updateRichPresenceGroupData)
				{
					UserData.SetRichPresence("steam_player_group", string.Empty);
					UserData.SetRichPresence("steam_player_group_size", string.Empty);
				}
				if (processingGroup.activeSelf)
				{
					idleGroup.SetActive(value: true);
					processingGroup.SetActive(value: false);
					evtProcessStopped.Invoke();
				}
			}
			else
			{
				if (updateRichPresenceGroupData)
				{
					UserData.SetRichPresence("steam_player_group", Lobby.ToString());
					UserData.SetRichPresence("steam_player_group_size", createArguments.slots.ToString());
				}
				if (!processingGroup.activeSelf)
				{
					idleGroup.SetActive(value: false);
					processingGroup.SetActive(value: true);
					evtProcessStarted.Invoke();
				}
			}
			evtStateChanged.Invoke();
		}

		public void Cancel()
		{
			if (Searching)
			{
				cancelRequest = true;
			}
			Searching = false;
			if (HasLobby)
			{
				Lobby.Leave();
				Lobby = default(LobbyData);
			}
			idleGroup.SetActive(value: true);
			processingGroup.SetActive(value: false);
			evtProcessStopped.Invoke();
			evtStateChanged.Invoke();
		}

		public void RunQuckMatch()
		{
			if ((LobbyData.GroupLobby(out var lobby) && !lobby.IsOwner) || HasLobby || Searching)
			{
				return;
			}
			idleGroup.SetActive(value: false);
			processingGroup.SetActive(value: true);
			evtProcessStarted.Invoke();
			filledId = 0uL;
			Searching = true;
			Matchmaking.Client.AddRequestLobbyListDistanceFilter(searchArguments.distance);
			if (LobbyData.GroupLobby(out var lobby2))
			{
				Matchmaking.Client.AddRequestLobbyListFilterSlotsAvailable(SteamMatchmaking.GetNumLobbyMembers(lobby2));
			}
			foreach (NearFilter nearValue in searchArguments.nearValues)
			{
				Matchmaking.Client.AddRequestLobbyListNearValueFilter(nearValue.key, nearValue.value);
			}
			foreach (NumericFilter numericFilter in searchArguments.numericFilters)
			{
				Matchmaking.Client.AddRequestLobbyListNumericalFilter(numericFilter.key, numericFilter.value, numericFilter.comparison);
			}
			foreach (StringFilter stringFilter in searchArguments.stringFilters)
			{
				Matchmaking.Client.AddRequestLobbyListStringFilter(stringFilter.key, stringFilter.value, stringFilter.comparison);
			}
			Matchmaking.Client.AddRequestLobbyListResultCountFilter(1);
			Matchmaking.Client.RequestLobbyList(delegate(LobbyData[] r, bool e)
			{
				if (cancelRequest)
				{
					cancelRequest = false;
				}
				else if (!e && r.Length >= 1)
				{
					Searching = false;
					Matchmaking.Client.JoinLobby(r[0], delegate(LobbyEnter lobbyEnter, bool flag)
					{
						EChatRoomEnterResponse response = lobbyEnter.Response;
						if (!flag && response == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
						{
							if (cancelRequest)
							{
								r[0].Leave();
								cancelRequest = false;
							}
							else
							{
								if (App.isDebugging)
								{
									Debug.Log("Quick match found, joined lobby: " + lobbyEnter.Lobby.ToString());
								}
								Lobby = lobbyEnter.Lobby;
								evtEnterSuccess.Invoke(r[0]);
								evtStateChanged.Invoke();
							}
						}
						else if (cancelRequest)
						{
							cancelRequest = false;
						}
						else if (response == EChatRoomEnterResponse.k_EChatRoomEnterResponseLimited)
						{
							Debug.LogError("This user is limited and cannot create or join lobbies or chats.");
							evtEnterFailed.Invoke(response);
						}
						else
						{
							Debug.LogError("Quick match failed, lobbies found but failed to join ... creating lobby.");
							evtEnterFailed.Invoke(response);
						}
					});
				}
				else
				{
					Matchmaking.Client.CreateLobby(createArguments.type, createArguments.slots, delegate(EResult result, LobbyData lobbyData, bool ioError)
					{
						Searching = false;
						if (!ioError)
						{
							if (cancelRequest)
							{
								lobbyData.Leave();
								cancelRequest = false;
							}
							else if (result == EResult.k_EResultOK)
							{
								if (App.isDebugging)
								{
									Debug.Log("New lobby created.");
								}
								Lobby = lobbyData;
								lobbyData.IsSession = true;
								lobbyData["name"] = createArguments.name;
								foreach (MetadataTempalate item in createArguments.metadata)
								{
									lobbyData[item.key] = item.value;
								}
								evtEnterSuccess.Invoke(lobbyData);
								evtStateChanged.Invoke();
							}
							else
							{
								Debug.Log($"No lobby created Steam API responce code: {result}");
								evtCreateFailed?.Invoke(result);
								evtStateChanged.Invoke();
							}
						}
						else if (cancelRequest)
						{
							cancelRequest = false;
						}
						else
						{
							Debug.LogError("Lobby creation failed with message: IOFailure\nSteam API responded with a general IO Failure.");
							evtCreateFailed?.Invoke(EResult.k_EResultIOFailure);
							evtStateChanged.Invoke();
						}
					});
				}
			});
		}

		public void SetGameServer()
		{
			Lobby.SetGameServer();
		}

		public void SetGameServer(string address, ushort port, CSteamID gameServerId)
		{
			Lobby.SetGameServer(address, port, gameServerId);
		}

		public void SetGameServer(string address, ushort port)
		{
			Lobby.SetGameServer(address, port);
		}

		public void SetGameServer(CSteamID gameServerId)
		{
			Lobby.SetGameServer(gameServerId);
		}
	}
}
