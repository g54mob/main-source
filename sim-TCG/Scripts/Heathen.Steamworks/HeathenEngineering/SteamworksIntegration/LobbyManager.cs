using System;
using System.Collections.Generic;
using System.Text;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[HelpURL("https://kb.heathen.group/toolkit-for-steamworks-sdk/unity/ui-components/lobby-manager")]
	public class LobbyManager : MonoBehaviour
	{
		public enum ManagedLobbyEvents
		{
			AuthenticationSessionResults = 0,
			LobbyChatMessageReceived = 1,
			LobbyCreationFailed = 2,
			LobbyCreationSuccess = 3,
			LobbyInviteReceived = 4,
			LobbyJoinFailure = 5,
			LobbyJoinSuccess = 6,
			LobbyLeave = 7,
			MetadataUpdated = 8,
			OtherUserLeft = 9,
			OtherUserJoined = 10,
			QuickMatchFailed = 11,
			SearchResultsReady = 12,
			SessionConnectionUpdated = 13,
			YouAreAskedToLeave = 14
		}

		[SerializeField]
		private List<ManagedLobbyEvents> m_Delegates;

		[Tooltip("The values to be used when searching for a lobby")]
		public SearchArguments searchArguments = new SearchArguments();

		[Tooltip("The values to be used when creating a new lobby")]
		public CreateArguments createArguments = new CreateArguments();

		[Tooltip("The Rich Presence fields to be set when joining a lobby.\nDoes not apply to creating a lobby, use the Create Arguments for that.")]
		public List<StringKeyValuePair> richPresenceFields = new List<StringKeyValuePair>();

		[Header("Events")]
		public LobbyInviteEvent evtLobbyInvite;

		public LobbyChatMsgEvent evtChatMsgReceived;

		public LobbyDataListEvent evtFound;

		public LobbyDataEvent evtEnterSuccess;

		public LobbyResponceEvent evtEnterFailed;

		public LobbyDataEvent evtCreated;

		public EResultEvent evtCreateFailed;

		public UnityEvent evtQuickMatchFailed;

		public LobbyDataUpdateEvent evtDataUpdated;

		public UnityEvent evtLeave;

		public UnityEvent evtAskedToLeave;

		public GameServerSetEvent evtGameCreated;

		public UserDataEvent evtUserJoined;

		public UserLeaveEvent evtUserLeft;

		public LobbyAuthenticaitonSessionEvent evtAuthenticationSessionResult;

		public LobbyData Lobby { get; set; }

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
				if (HasLobby)
				{
					return Matchmaking.Client.GetLobbyMemberData(Lobby, User.Client.Id, "z_heathenReady") == "true";
				}
				return false;
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

		[Obsolete("Use MaxMembers instead.")]
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

		public bool IsTypeSet
		{
			get
			{
				if (HasLobby)
				{
					return Lobby.IsTypeSet;
				}
				return false;
			}
		}

		public ELobbyType Type
		{
			get
			{
				return Lobby.Type;
			}
			set
			{
				LobbyData lobby = Lobby;
				lobby.Type = value;
			}
		}

		public int MaxMembers
		{
			get
			{
				if (!HasLobby)
				{
					return 0;
				}
				return Matchmaking.Client.GetLobbyMemberLimit(new CSteamID(Lobby));
			}
			set
			{
				Matchmaking.Client.SetLobbyMemberLimit(new CSteamID(Lobby), value);
			}
		}

		public bool HasServer
		{
			get
			{
				uint punGameServerIP;
				ushort punGameServerPort;
				CSteamID psteamIDGameServer;
				return SteamMatchmaking.GetLobbyGameServer(Lobby, out punGameServerIP, out punGameServerPort, out psteamIDGameServer);
			}
		}

		public LobbyGameServer GameServer => Matchmaking.Client.GetLobbyGameServer(Lobby);

		public string this[string key]
		{
			get
			{
				return Lobby[key];
			}
			set
			{
				LobbyData lobby = Lobby;
				lobby[key] = value;
			}
		}

		public LobbyMemberData this[UserData user] => Lobby[user];

		public LobbyMemberData[] Members => Matchmaking.Client.GetLobbyMembers(Lobby);

		private void OnEnable()
		{
			Matchmaking.Client.EventLobbyAskedToLeave.AddListener(HandleAskedToLeave);
			Matchmaking.Client.EventLobbyDataUpdate.AddListener(HandleLobbyDataUpdate);
			Matchmaking.Client.EventLobbyLeave.AddListener(HandleLobbyLeave);
			Matchmaking.Client.EventLobbyGameCreated.AddListener(HandleGameServerSet);
			Matchmaking.Client.EventLobbyChatUpdate.AddListener(HandleChatUpdate);
			Matchmaking.Client.EventLobbyAuthenticationRequest.AddListener(HandleAuthRequest);
			Matchmaking.Client.EventLobbyChatMsg.AddListener(HandleChatMessage);
			Matchmaking.Client.EventLobbyInvite.AddListener(evtLobbyInvite.Invoke);
		}

		private void OnDisable()
		{
			Matchmaking.Client.EventLobbyAskedToLeave.RemoveListener(HandleAskedToLeave);
			Matchmaking.Client.EventLobbyDataUpdate.RemoveListener(HandleLobbyDataUpdate);
			Matchmaking.Client.EventLobbyLeave.RemoveListener(HandleLobbyLeave);
			Matchmaking.Client.EventLobbyGameCreated.RemoveListener(HandleGameServerSet);
			Matchmaking.Client.EventLobbyChatUpdate.RemoveListener(HandleChatUpdate);
			Matchmaking.Client.EventLobbyAuthenticationRequest.RemoveListener(HandleAuthRequest);
			Matchmaking.Client.EventLobbyChatMsg.RemoveListener(HandleChatMessage);
			Matchmaking.Client.EventLobbyInvite.RemoveListener(evtLobbyInvite.Invoke);
		}

		private void HandleChatMessage(LobbyChatMsg message)
		{
			if (message.lobby == Lobby)
			{
				evtChatMsgReceived.Invoke(message);
			}
		}

		private void HandleAuthRequest(LobbyData lobby, UserData sender, byte[] ticket, byte[] inventory)
		{
			if (lobby == Lobby)
			{
				Authentication.BeginAuthSession(ticket, sender, delegate(AuthenticationSession session)
				{
					evtAuthenticationSessionResult.Invoke(session, inventory);
				});
			}
		}

		private void HandleChatUpdate(LobbyChatUpdate_t arg0)
		{
			if (arg0.m_ulSteamIDLobby == Lobby)
			{
				EChatMemberStateChange rgfChatMemberStateChange = (EChatMemberStateChange)arg0.m_rgfChatMemberStateChange;
				if (rgfChatMemberStateChange == EChatMemberStateChange.k_EChatMemberStateChangeEntered)
				{
					evtUserJoined?.Invoke(arg0.m_ulSteamIDUserChanged);
					return;
				}
				evtUserLeft?.Invoke(new UserLobbyLeaveData
				{
					user = arg0.m_ulSteamIDUserChanged,
					state = rgfChatMemberStateChange
				});
			}
		}

		private void HandleGameServerSet(LobbyGameCreated_t arg0)
		{
			if (arg0.m_ulSteamIDLobby == Lobby)
			{
				evtGameCreated.Invoke(GameServer);
			}
		}

		private void HandleLobbyLeave(LobbyData arg0)
		{
			if (arg0 == Lobby)
			{
				Lobby = default(LobbyData);
				evtLeave.Invoke();
			}
		}

		private void HandleAskedToLeave(LobbyData arg0)
		{
			if (arg0 == Lobby)
			{
				evtAskedToLeave.Invoke();
			}
		}

		private void HandleLobbyDataUpdate(LobbyDataUpdateEventData arg0)
		{
			if (arg0.lobby == Lobby)
			{
				evtDataUpdated.Invoke(arg0);
			}
		}

		public bool SetType(ELobbyType type)
		{
			createArguments.type = type;
			return Matchmaking.Client.SetLobbyType(Lobby, type);
		}

		public bool SetJoinable(bool makeJoinable)
		{
			return Matchmaking.Client.SetLobbyJoinable(Lobby, makeJoinable);
		}

		public void QuickMatch(bool createOnFail = true)
		{
			if (HasLobby)
			{
				Lobby.Leave();
				Lobby = CSteamID.Nil.m_SteamID;
			}
			Matchmaking.Client.AddRequestLobbyListDistanceFilter(searchArguments.distance);
			if (searchArguments.slots > 0)
			{
				Matchmaking.Client.AddRequestLobbyListFilterSlotsAvailable(searchArguments.slots);
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
				if (!e && r.Length >= 1)
				{
					Matchmaking.Client.JoinLobby(r[0], delegate(LobbyEnter lobbyEnter, bool flag)
					{
						EChatRoomEnterResponse response = lobbyEnter.Response;
						if (!flag && response == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
						{
							if (App.isDebugging)
							{
								Debug.Log("Quick match found, joined lobby: " + lobbyEnter.Lobby.ToString());
							}
							Lobby = lobbyEnter.Lobby;
							evtFound?.Invoke(r);
							evtEnterSuccess.Invoke(r[0]);
						}
						else if (response == EChatRoomEnterResponse.k_EChatRoomEnterResponseLimited)
						{
							Debug.LogError("This user is limited and cannot create or join lobbies or chats.");
							evtEnterFailed.Invoke(response);
						}
						else if (createOnFail)
						{
							if (App.isDebugging)
							{
								Debug.LogError("Quick match failed, lobbies found but failed to join ... creating lobby.");
							}
							Create();
						}
						else
						{
							evtQuickMatchFailed.Invoke();
						}
					});
				}
				else if (createOnFail)
				{
					if (App.isDebugging)
					{
						Debug.Log("Quick match failed, no lobbies found ... creating lobby.");
					}
					Create();
				}
				else
				{
					evtQuickMatchFailed.Invoke();
				}
			});
		}

		public void Create()
		{
			Create(null);
		}

		public void Create(string name, ELobbyType type, int slots, params MetadataTempalate[] metadata)
		{
			createArguments.name = name;
			createArguments.type = type;
			createArguments.slots = slots;
			createArguments.metadata.Clear();
			createArguments.metadata.AddRange(metadata);
			createArguments.richPresenceFields.Clear();
			Create(null);
		}

		public void Create(ELobbyType type, int slots, params MetadataTempalate[] metadata)
		{
			createArguments.name = string.Empty;
			createArguments.type = type;
			createArguments.slots = slots;
			createArguments.metadata.Clear();
			createArguments.metadata.AddRange(metadata);
			createArguments.richPresenceFields.Clear();
			Create(null);
		}

		public void Create(Action<EResult, LobbyData, bool> callback)
		{
			if (HasLobby)
			{
				Lobby.Leave();
				Lobby = CSteamID.Nil.m_SteamID;
			}
			Matchmaking.Client.CreateLobby(createArguments.type, createArguments.slots, delegate(EResult result, LobbyData lobby, bool ioError)
			{
				if (!ioError)
				{
					if (result == EResult.k_EResultOK)
					{
						if (App.isDebugging)
						{
							Debug.Log("New lobby created.");
						}
						Lobby = lobby;
						if (createArguments.usageHint == CreateArguments.UseHintOptions.Group)
						{
							lobby.IsGroup = true;
						}
						else if (createArguments.usageHint == CreateArguments.UseHintOptions.Session)
						{
							lobby.IsSession = true;
						}
						lobby["name"] = createArguments.name;
						foreach (MetadataTempalate item in createArguments.metadata)
						{
							if (item.value.Contains("@[") && item.value.Contains("]"))
							{
								string value = item.value;
								string result2;
								while (Utilities.FindToken("@[", "]", value, out result2))
								{
									if (!(result2 == "@[userName]"))
									{
										if (result2 == "@[userLevel]")
										{
											value.Replace(result2, UserData.Me.Level.ToString());
										}
										else
										{
											value.Replace(result2, "");
										}
									}
									else
									{
										value.Replace(result2, UserData.Me.Name);
									}
								}
							}
							else
							{
								lobby[item.key] = item.value;
							}
						}
						if (createArguments != null && createArguments.richPresenceFields != null)
						{
							foreach (StringKeyValuePair richPresenceField in createArguments.richPresenceFields)
							{
								if (richPresenceField.value.Contains("@[") && richPresenceField.value.Contains("]"))
								{
									string value2 = richPresenceField.value;
									string result3;
									while (Utilities.FindToken("@[", "]", value2, out result3))
									{
										if (result3 == "@[lobbyId]")
										{
											value2.Replace(result3, lobby.ToString());
										}
										else
										{
											value2.Replace(result3, lobby[result3[2..^1]]);
										}
									}
								}
								else
								{
									Friends.Client.SetRichPresence(richPresenceField.key, richPresenceField.value);
								}
							}
						}
						evtCreated?.Invoke(lobby);
					}
					else
					{
						Debug.Log($"No lobby created Steam API response code: {result}");
						evtCreateFailed?.Invoke(result);
					}
				}
				else
				{
					Debug.LogError("Lobby creation failed with message: IOFailure\nSteam API responded with a general IO Failure.");
					evtCreateFailed?.Invoke(EResult.k_EResultIOFailure);
				}
				callback?.Invoke(result, lobby, ioError);
			});
		}

		public void Search(int maxResults)
		{
			if (maxResults <= 0)
			{
				return;
			}
			Matchmaking.Client.AddRequestLobbyListDistanceFilter(searchArguments.distance);
			if (searchArguments.slots > 0)
			{
				Matchmaking.Client.AddRequestLobbyListFilterSlotsAvailable(searchArguments.slots);
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
			Matchmaking.Client.AddRequestLobbyListResultCountFilter(maxResults);
			Matchmaking.Client.RequestLobbyList(delegate(LobbyData[] r, bool e)
			{
				if (!e)
				{
					evtFound?.Invoke(r);
				}
				else
				{
					evtFound?.Invoke(new LobbyData[0]);
				}
			});
		}

		public void Join(LobbyData lobby)
		{
			if (HasLobby)
			{
				Lobby.Leave();
				Lobby = CSteamID.Nil.m_SteamID;
			}
			Matchmaking.Client.JoinLobby(lobby, delegate(LobbyEnter r, bool e)
			{
				if (!e)
				{
					if (r.Response == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
					{
						if (App.isDebugging)
						{
							Debug.Log("Joined lobby: " + lobby.ToString());
						}
						Lobby = r.Lobby;
						evtEnterSuccess.Invoke(lobby);
					}
					else
					{
						evtEnterFailed.Invoke(r.Response);
					}
				}
				else
				{
					evtEnterFailed.Invoke(EChatRoomEnterResponse.k_EChatRoomEnterResponseError);
				}
			});
		}

		public void Join(ulong lobby)
		{
			if (HasLobby)
			{
				Lobby.Leave();
				Lobby = CSteamID.Nil.m_SteamID;
			}
			Matchmaking.Client.JoinLobby(lobby, delegate(LobbyEnter r, bool e)
			{
				if (!e)
				{
					if (r.Response == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
					{
						if (App.isDebugging)
						{
							Debug.Log("Joined lobby: " + lobby);
						}
						Lobby = r.Lobby;
						if (richPresenceFields != null)
						{
							foreach (StringKeyValuePair richPresenceField in richPresenceFields)
							{
								if (richPresenceField.value.Contains("@[") && richPresenceField.value.Contains("]"))
								{
									string value = richPresenceField.value;
									string result;
									while (Utilities.FindToken("@[", "]", value, out result))
									{
										if (result == "@[lobbyId]")
										{
											value.Replace(result, r.Lobby.ToString());
										}
										else
										{
											value.Replace(result, r.Lobby[result[2..^1]]);
										}
									}
								}
								else
								{
									Friends.Client.SetRichPresence(richPresenceField.key, richPresenceField.value);
								}
							}
						}
						evtEnterSuccess.Invoke(lobby);
					}
					else
					{
						evtEnterFailed.Invoke(r.Response);
					}
				}
				else
				{
					evtEnterFailed.Invoke(EChatRoomEnterResponse.k_EChatRoomEnterResponseError);
				}
			});
		}

		public void Join(string lobbyIdAsString)
		{
			LobbyData lobby = LobbyData.Get(lobbyIdAsString);
			if (lobby.IsValid)
			{
				if (HasLobby)
				{
					Lobby.Leave();
					Lobby = CSteamID.Nil.m_SteamID;
				}
				Join(lobby);
			}
			else
			{
				Debug.LogWarning(lobbyIdAsString + " is not a valid Lobby ID");
			}
		}

		public void Leave()
		{
			Lobby.Leave();
			Lobby = CSteamID.Nil.m_SteamID;
		}

		public bool SetLobbyData(string key, string value)
		{
			return Matchmaking.Client.SetLobbyData(Lobby, key, value);
		}

		public void SetMemberData(string key, string value)
		{
			Matchmaking.Client.SetLobbyMemberData(Lobby, key, value);
		}

		public LobbyMemberData GetLobbyMember(UserData member)
		{
			return new LobbyMemberData
			{
				lobby = Lobby,
				user = member
			};
		}

		public string GetLobbyData(string key)
		{
			return Matchmaking.Client.GetLobbyData(Lobby, key);
		}

		public string GetMemberData(UserData member, string key)
		{
			return Matchmaking.Client.GetLobbyMemberData(Lobby, member, key);
		}

		public bool IsMemberReady(UserData member)
		{
			return Matchmaking.Client.GetLobbyMemberData(Lobby, member, "z_heathenReady") == "true";
		}

		public void KickMember(UserData member)
		{
			Lobby.KickMember(member);
		}

		public void Invite(UserData user)
		{
			Matchmaking.Client.InviteUserToLobby(Lobby, user);
		}

		public void Invite(uint FriendId)
		{
			Matchmaking.Client.InviteUserToLobby(Lobby, UserData.Get(FriendId));
		}

		public void Authenticate(Action<AuthenticationTicket, bool> callback)
		{
			Lobby.Authenticate(callback);
		}

		public bool Authenticate(LobbyAuthenticationData data)
		{
			return Lobby.Authenticate(data);
		}

		public bool SendChatMessage(string message)
		{
			return Lobby.SendChatMessage(message);
		}

		public bool SendChatMessage(byte[] data)
		{
			return Lobby.SendChatMessage(data);
		}

		public bool SendChatMessage(object jsonObject)
		{
			return SendChatMessage(Encoding.UTF8.GetBytes(JsonUtility.ToJson(jsonObject)));
		}

		public void SendChatMessageString(string message)
		{
			SendChatMessage(message);
		}
	}
}
