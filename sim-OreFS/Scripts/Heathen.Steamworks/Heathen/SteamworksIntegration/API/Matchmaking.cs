using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.API
{
	public static class Matchmaking
	{
		public static class Client
		{
			public static List<LobbyData> memberOfLobbies = new List<LobbyData>();

			private static LobbyEnterEvent eventLobbyEnter = new LobbyEnterEvent();

			private static LobbyEnterEvent eventLobbyEnterSuccess = new LobbyEnterEvent();

			private static LobbyEnterEvent eventLobbyEnterFailed = new LobbyEnterEvent();

			private static LobbyDataUpdateEvent eventLobbyDataUpdate = new LobbyDataUpdateEvent();

			private static LobbyChatMsgEvent eventLobbyChatMsg = new LobbyChatMsgEvent();

			private static LobbyAuthenticationEvent eventLobbyAuthentication = new LobbyAuthenticationEvent();

			private static FavoritesListChangedEvent eventFavoritesListChanged = new FavoritesListChangedEvent();

			private static LobbyChatUpdateEvent eventLobbyChatUpdate = new LobbyChatUpdateEvent();

			private static LobbyGameCreatedEvent eventLobbyGameCreated = new LobbyGameCreatedEvent();

			private static LobbyInviteEvent eventLobbyInvite = new LobbyInviteEvent();

			private static LobbyDataEvent eventLobbyLeave = new LobbyDataEvent();

			private static LobbyDataEvent eventLobbyAskedToLeave = new LobbyDataEvent();

			private static CallResult<LobbyCreated_t> m_LobbyCreated_t;

			private static CallResult<LobbyMatchList_t> m_LobbyMatchList_t;

			private static CallResult<LobbyEnter_t> m_LobbyEnter_t2;

			private static Callback<LobbyEnter_t> m_LobbyEnter_t;

			private static Callback<LobbyDataUpdate_t> m_LobbyDataUpdate_t;

			private static Callback<LobbyChatMsg_t> m_LobbyChatMsg_t;

			private static Callback<FavoritesListChanged_t> m_FavoritesListChanged_t;

			private static Callback<LobbyChatUpdate_t> m_LobbyChatUpdate_t;

			private static Callback<LobbyGameCreated_t> m_LobbyGameCreated_t;

			private static Callback<LobbyInvite_t> m_LobbyInvite_t;

			public static LobbyEnterEvent EventLobbyEnterSuccess
			{
				get
				{
					if (m_LobbyEnter_t == null)
					{
						m_LobbyEnter_t = Callback<LobbyEnter_t>.Create(LobbyEnterHandler);
					}
					return eventLobbyEnterSuccess;
				}
			}

			public static LobbyEnterEvent EventLobbyEnterFailed
			{
				get
				{
					if (m_LobbyEnter_t == null)
					{
						m_LobbyEnter_t = Callback<LobbyEnter_t>.Create(LobbyEnterHandler);
					}
					return eventLobbyEnterFailed;
				}
			}

			public static LobbyDataUpdateEvent EventLobbyDataUpdate
			{
				get
				{
					if (m_LobbyDataUpdate_t == null)
					{
						m_LobbyDataUpdate_t = Callback<LobbyDataUpdate_t>.Create(delegate(LobbyDataUpdate_t response)
						{
							if (response.m_ulSteamIDLobby == response.m_ulSteamIDMember)
							{
								LobbyData arg = response.m_ulSteamIDLobby;
								if (arg["z_heathenKick"].Contains("[" + User.Client.Id.ToString() + "]"))
								{
									eventLobbyAskedToLeave.Invoke(arg);
								}
							}
							eventLobbyDataUpdate.Invoke(response);
						});
					}
					return eventLobbyDataUpdate;
				}
			}

			public static LobbyChatMsgEvent EventLobbyChatMsg
			{
				get
				{
					if (m_LobbyChatMsg_t == null)
					{
						m_LobbyChatMsg_t = Callback<LobbyChatMsg_t>.Create(delegate(LobbyChatMsg_t result)
						{
							byte[] array = new byte[4096];
							CSteamID cSteamID = new CSteamID(result.m_ulSteamIDLobby);
							CSteamID pSteamIDUser;
							EChatEntryType peChatEntryType;
							int lobbyChatEntry = SteamMatchmaking.GetLobbyChatEntry(cSteamID, (int)result.m_iChatID, out pSteamIDUser, array, array.Length, out peChatEntryType);
							Array.Resize(ref array, lobbyChatEntry);
							LobbyChatMsg arg = new LobbyChatMsg
							{
								lobby = cSteamID,
								type = peChatEntryType,
								data = array,
								receivedTime = DateTime.Now,
								sender = pSteamIDUser
							};
							LobbyAuthenticationData result3;
							if (arg.type == EChatEntryType.k_EChatEntryTypeChatMsg && arg.sender != UserData.Me && arg.lobby.IsOwner)
							{
								if (arg.TryFromJson<LobbyAuthenticationData>(out var result2) && result2.ticket != null)
								{
									eventLobbyAuthentication.Invoke(arg.lobby, arg.sender, result2.ticket, result2.inventory);
								}
								else
								{
									eventLobbyChatMsg.Invoke(arg);
								}
							}
							else if (!arg.TryFromJson<LobbyAuthenticationData>(out result3) || result3.ticket == null)
							{
								eventLobbyChatMsg.Invoke(arg);
							}
						});
					}
					return eventLobbyChatMsg;
				}
			}

			public static LobbyAuthenticationEvent EventLobbyAuthenticationRequest
			{
				get
				{
					if (m_LobbyChatMsg_t == null)
					{
						m_LobbyChatMsg_t = Callback<LobbyChatMsg_t>.Create(delegate(LobbyChatMsg_t result)
						{
							byte[] array = new byte[4096];
							CSteamID cSteamID = new CSteamID(result.m_ulSteamIDLobby);
							CSteamID pSteamIDUser;
							EChatEntryType peChatEntryType;
							int lobbyChatEntry = SteamMatchmaking.GetLobbyChatEntry(cSteamID, (int)result.m_iChatID, out pSteamIDUser, array, array.Length, out peChatEntryType);
							Array.Resize(ref array, lobbyChatEntry);
							LobbyChatMsg arg = new LobbyChatMsg
							{
								lobby = cSteamID,
								type = peChatEntryType,
								data = array,
								receivedTime = DateTime.Now,
								sender = pSteamIDUser
							};
							LobbyAuthenticationData result3;
							if (arg.type == EChatEntryType.k_EChatEntryTypeChatMsg && arg.sender != UserData.Me && arg.lobby.IsOwner)
							{
								if (arg.TryFromJson<LobbyAuthenticationData>(out var result2) && result2.ticket != null)
								{
									eventLobbyAuthentication.Invoke(arg.lobby, arg.sender, result2.ticket, result2.inventory);
								}
								else
								{
									eventLobbyChatMsg.Invoke(arg);
								}
							}
							else if (!arg.TryFromJson<LobbyAuthenticationData>(out result3) || result3.ticket == null)
							{
								eventLobbyChatMsg.Invoke(arg);
							}
						});
					}
					return eventLobbyAuthentication;
				}
			}

			public static FavoritesListChangedEvent EventFavoritesListChanged
			{
				get
				{
					if (m_FavoritesListChanged_t == null)
					{
						m_FavoritesListChanged_t = Callback<FavoritesListChanged_t>.Create(eventFavoritesListChanged.Invoke);
					}
					return eventFavoritesListChanged;
				}
			}

			public static LobbyChatUpdateEvent EventLobbyChatUpdate
			{
				get
				{
					if (m_LobbyChatUpdate_t == null)
					{
						m_LobbyChatUpdate_t = Callback<LobbyChatUpdate_t>.Create(eventLobbyChatUpdate.Invoke);
					}
					return eventLobbyChatUpdate;
				}
			}

			public static LobbyGameCreatedEvent EventLobbyGameCreated
			{
				get
				{
					if (m_LobbyGameCreated_t == null)
					{
						m_LobbyGameCreated_t = Callback<LobbyGameCreated_t>.Create(eventLobbyGameCreated.Invoke);
					}
					return eventLobbyGameCreated;
				}
			}

			public static LobbyInviteEvent EventLobbyInvite
			{
				get
				{
					if (m_LobbyInvite_t == null)
					{
						m_LobbyInvite_t = Callback<LobbyInvite_t>.Create(delegate(LobbyInvite_t e)
						{
							eventLobbyInvite.Invoke(e);
						});
					}
					return eventLobbyInvite;
				}
			}

			public static LobbyDataEvent EventLobbyLeave => eventLobbyLeave;

			public static LobbyDataEvent EventLobbyAskedToLeave => eventLobbyAskedToLeave;

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				memberOfLobbies = new List<LobbyData>();
				eventLobbyEnter = new LobbyEnterEvent();
				eventLobbyDataUpdate = new LobbyDataUpdateEvent();
				eventLobbyChatMsg = new LobbyChatMsgEvent();
				eventFavoritesListChanged = new FavoritesListChangedEvent();
				eventLobbyChatUpdate = new LobbyChatUpdateEvent();
				eventLobbyGameCreated = new LobbyGameCreatedEvent();
				eventLobbyInvite = new LobbyInviteEvent();
				eventLobbyLeave = new LobbyDataEvent();
				eventLobbyAskedToLeave = new LobbyDataEvent();
				m_LobbyCreated_t = null;
				m_LobbyMatchList_t = null;
				m_LobbyEnter_t2 = null;
				m_LobbyEnter_t = null;
				m_LobbyChatMsg_t = null;
				m_LobbyDataUpdate_t = null;
				m_FavoritesListChanged_t = null;
				m_LobbyChatUpdate_t = null;
				m_LobbyGameCreated_t = null;
				m_LobbyInvite_t = null;
			}

			private static void LobbyEnterHandler(LobbyEnter_t response)
			{
				EChatRoomEnterResponse eChatRoomEnterResponse = (EChatRoomEnterResponse)response.m_EChatRoomEnterResponse;
				if (eChatRoomEnterResponse == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
				{
					if (!memberOfLobbies.Any((LobbyData p) => p == response.m_ulSteamIDLobby))
					{
						memberOfLobbies.Add(new CSteamID(response.m_ulSteamIDLobby));
					}
					eventLobbyEnterSuccess.Invoke(response);
				}
				else
				{
					if (App.isDebugging || Application.isEditor)
					{
						if (eChatRoomEnterResponse != EChatRoomEnterResponse.k_EChatRoomEnterResponseLimited)
						{
							Debug.LogWarning("This user is limited and cannot fully join a Steam Lobby! metadata and lobby chat will not work for this user though they may appear in the members list.");
						}
						else if (eChatRoomEnterResponse != EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
						{
							Debug.LogWarning("Detected a Failed lobby enter attempt (" + response.m_ulSteamIDLobby + ":" + eChatRoomEnterResponse.ToString() + ")");
						}
						else
						{
							Debug.Log("Detected a successful lobby enter attempt (" + response.m_ulSteamIDLobby + ":" + eChatRoomEnterResponse.ToString() + ")");
						}
						LeaveLobby(response.m_ulSteamIDLobby);
					}
					eventLobbyEnterFailed.Invoke(response);
				}
				eventLobbyEnter.Invoke(response);
			}

			public static LobbyData GetCommandLineConnectLobby()
			{
				string[] commandLineArgs = Environment.GetCommandLineArgs();
				ulong result = 0uL;
				for (int i = 0; i < commandLineArgs.Length; i++)
				{
					if (commandLineArgs[i] == "+connect_lobby" && i + 1 < commandLineArgs.Length && ulong.TryParse(commandLineArgs[i + 1], out result))
					{
						return result;
					}
				}
				return result;
			}

			public static void AddHistoryGame(AppId_t appID, uint ipAddress, ushort port, ushort queryPort, DateTime lastPlayedOnServer)
			{
				SteamMatchmaking.AddFavoriteGame(appID, ipAddress, port, queryPort, 2u, Convert.ToUInt32((lastPlayedOnServer - new DateTime(1970, 1, 1)).TotalSeconds));
			}

			public static void AddFavoriteGame(AppId_t appID, uint ipAddress, ushort port, ushort queryPort, DateTime lastPlayedOnServer)
			{
				SteamMatchmaking.AddFavoriteGame(appID, ipAddress, port, queryPort, 1u, Convert.ToUInt32((lastPlayedOnServer - new DateTime(1970, 1, 1)).TotalSeconds));
			}

			public static void AddHistoryGame(AppId_t appID, string ipAddress, ushort port, ushort queryPort, DateTime lastPlayedOnServer)
			{
				SteamMatchmaking.AddFavoriteGame(appID, Utilities.IPStringToUint(ipAddress), port, queryPort, 2u, Convert.ToUInt32((lastPlayedOnServer - new DateTime(1970, 1, 1)).TotalSeconds));
			}

			public static void AddFavoriteGame(AppId_t appID, string ipAddress, ushort port, ushort queryPort, DateTime lastPlayedOnServer)
			{
				SteamMatchmaking.AddFavoriteGame(appID, Utilities.IPStringToUint(ipAddress), port, queryPort, 1u, Convert.ToUInt32((lastPlayedOnServer - new DateTime(1970, 1, 1)).TotalSeconds));
			}

			public static void AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter distanceFilter)
			{
				SteamMatchmaking.AddRequestLobbyListDistanceFilter(distanceFilter);
			}

			public static void AddRequestLobbyListFilterSlotsAvailable(int slotsAvailable)
			{
				SteamMatchmaking.AddRequestLobbyListFilterSlotsAvailable(slotsAvailable);
			}

			public static void AddRequestLobbyListNearValueFilter(string key, int value)
			{
				SteamMatchmaking.AddRequestLobbyListNearValueFilter(key, value);
			}

			public static void AddRequestLobbyListNumericalFilter(string key, int value, ELobbyComparison comparison)
			{
				SteamMatchmaking.AddRequestLobbyListNumericalFilter(key, value, comparison);
			}

			public static void AddRequestLobbyListResultCountFilter(int max)
			{
				SteamMatchmaking.AddRequestLobbyListResultCountFilter(max);
			}

			public static void AddRequestLobbyListStringFilter(string key, string value, ELobbyComparison comparison)
			{
				SteamMatchmaking.AddRequestLobbyListStringFilter(key, value, comparison);
			}

			[Obsolete("Update your callback to take (EResult result, Lobby lobby, bool IOError)")]
			public static void CreateLobby(ELobbyType type, int maxMembers, Action<LobbyData, bool> callback)
			{
				CreateLobby(type, maxMembers, delegate(EResult r, LobbyData l, bool e)
				{
					callback?.Invoke(l, e);
				});
			}

			public static void CreateLobby(ELobbyType type, int maxMembers, Action<EResult, LobbyData, bool> callback)
			{
				if (type == ELobbyType.k_ELobbyTypePrivateUnique)
				{
					throw new ArgumentOutOfRangeException("The `k_ELobbyTypePrivateUnique` should not be used and is a legacy feature of Steam API that is not defined for use in the Client API. It is shown in the ELobbyType and editor as a matter of compatibility with the native API. Do Not User It.");
				}
				if (callback == null)
				{
					return;
				}
				if (m_LobbyCreated_t == null)
				{
					m_LobbyCreated_t = CallResult<LobbyCreated_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamMatchmaking.CreateLobby(type, maxMembers);
				m_LobbyCreated_t.Set(hAPICall, delegate(LobbyCreated_t r, bool e)
				{
					if (!e && r.m_eResult == EResult.k_EResultOK)
					{
						LobbyData lobby = new CSteamID(r.m_ulSteamIDLobby);
						int num = (int)type;
						SetLobbyData(lobby, "z_heathenType", num.ToString());
						memberOfLobbies.Add(new CSteamID(r.m_ulSteamIDLobby));
					}
					if (type == ELobbyType.k_ELobbyTypeInvisible)
					{
						LobbyData lobbyData = LobbyData.Get(r.m_ulSteamIDLobby);
						lobbyData.IsGroup = true;
					}
					else
					{
						LobbyData lobbyData = LobbyData.Get(r.m_ulSteamIDLobby);
						lobbyData.IsSession = true;
					}
					callback(r.m_eResult, new CSteamID(r.m_ulSteamIDLobby), e);
				});
			}

			public static bool DeleteLobbyData(LobbyData lobby, string key)
			{
				return SteamMatchmaking.DeleteLobbyData(lobby, key);
			}

			public static FavoriteGame? GetFavoriteGame(int index)
			{
				if (SteamMatchmaking.GetFavoriteGame(index, out var pnAppID, out var pnIP, out var pnConnPort, out var pnQueryPort, out var punFlags, out var pRTime32LastPlayedOnServer))
				{
					return new FavoriteGame
					{
						appId = pnAppID,
						ipAddress = pnIP,
						connectionPort = pnConnPort,
						queryPort = pnQueryPort,
						lastPlayedOnServer = new DateTime(1970, 1, 1).AddSeconds(pRTime32LastPlayedOnServer),
						isHistory = (punFlags == 2)
					};
				}
				return null;
			}

			public static FavoriteGame[] GetFavoriteGames()
			{
				int favoriteGameCount = SteamMatchmaking.GetFavoriteGameCount();
				FavoriteGame[] array = new FavoriteGame[favoriteGameCount];
				for (int i = 0; i < favoriteGameCount; i++)
				{
					SteamMatchmaking.GetFavoriteGame(i, out var pnAppID, out var pnIP, out var pnConnPort, out var pnQueryPort, out var punFlags, out var pRTime32LastPlayedOnServer);
					array[i] = new FavoriteGame
					{
						appId = pnAppID,
						ipAddress = pnIP,
						connectionPort = pnConnPort,
						queryPort = pnQueryPort,
						lastPlayedOnServer = new DateTime(1970, 1, 1).AddSeconds(pRTime32LastPlayedOnServer),
						isHistory = (punFlags == 2)
					};
				}
				return array;
			}

			public static int GetFavoriteGameCount()
			{
				return SteamMatchmaking.GetFavoriteGameCount();
			}

			public static string GetLobbyData(LobbyData lobby, string key)
			{
				return SteamMatchmaking.GetLobbyData(lobby, key);
			}

			public static Dictionary<string, string> GetLobbyData(LobbyData lobby)
			{
				int lobbyDataCount = SteamMatchmaking.GetLobbyDataCount(lobby);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				for (int i = 0; i < lobbyDataCount; i++)
				{
					if (SteamMatchmaking.GetLobbyDataByIndex(lobby, i, out var pchKey, 255, out var pchValue, 8192))
					{
						dictionary.Add(pchKey, pchValue);
					}
				}
				return dictionary;
			}

			public static LobbyGameServer GetLobbyGameServer(LobbyData lobby)
			{
				SteamMatchmaking.GetLobbyGameServer(lobby, out var punGameServerIP, out var punGameServerPort, out var psteamIDGameServer);
				return new LobbyGameServer
				{
					id = psteamIDGameServer,
					ipAddress = punGameServerIP,
					port = punGameServerPort
				};
			}

			public static LobbyMemberData[] GetLobbyMembers(LobbyData lobby)
			{
				int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(lobby);
				LobbyMemberData[] array = new LobbyMemberData[numLobbyMembers];
				for (int i = 0; i < numLobbyMembers; i++)
				{
					array[i] = new LobbyMemberData
					{
						lobby = lobby,
						user = SteamMatchmaking.GetLobbyMemberByIndex(lobby, i)
					};
				}
				return array;
			}

			public static int GetLobbyMemberLimit(LobbyData lobby)
			{
				return SteamMatchmaking.GetLobbyMemberLimit(lobby);
			}

			public static CSteamID GetLobbyOwner(LobbyData lobby)
			{
				return SteamMatchmaking.GetLobbyOwner(lobby);
			}

			public static bool InviteUserToLobby(LobbyData lobby, UserData user)
			{
				return SteamMatchmaking.InviteUserToLobby(lobby, user);
			}

			public static void JoinLobby(LobbyData lobby, Action<LobbyEnter, bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (m_LobbyEnter_t2 == null)
				{
					m_LobbyEnter_t2 = CallResult<LobbyEnter_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamMatchmaking.JoinLobby(lobby);
				m_LobbyEnter_t2.Set(hAPICall, delegate(LobbyEnter_t r, bool e)
				{
					EChatRoomEnterResponse eChatRoomEnterResponse = (EChatRoomEnterResponse)r.m_EChatRoomEnterResponse;
					if (!e && eChatRoomEnterResponse == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
					{
						memberOfLobbies.Add(new CSteamID(r.m_ulSteamIDLobby));
					}
					else if (eChatRoomEnterResponse == EChatRoomEnterResponse.k_EChatRoomEnterResponseLimited)
					{
						SteamMatchmaking.LeaveLobby(new CSteamID(r.m_ulSteamIDLobby));
					}
					callback(r, e);
				});
			}

			public static void LeaveLobby(LobbyData lobby)
			{
				if (App.isDebugging)
				{
					LobbyData lobbyData = lobby;
					Debug.Log("Detected lobby exit (" + lobbyData.ToString() + ")");
				}
				eventLobbyLeave.Invoke(lobby);
				SteamMatchmaking.LeaveLobby(lobby);
				memberOfLobbies.RemoveAll((LobbyData p) => p == lobby);
			}

			public static bool RemoveFavoriteGame(AppId_t appId, uint ip, ushort connectionPort, ushort queryPort)
			{
				return SteamMatchmaking.RemoveFavoriteGame(appId, ip, connectionPort, queryPort, 1u);
			}

			public static bool RemoveHistoryGame(AppId_t appId, uint ip, ushort connectionPort, ushort queryPort)
			{
				return SteamMatchmaking.RemoveFavoriteGame(appId, ip, connectionPort, queryPort, 2u);
			}

			public static bool RemoveFavoriteGame(AppId_t appId, string ip, ushort connectionPort, ushort queryPort)
			{
				return SteamMatchmaking.RemoveFavoriteGame(appId, Utilities.IPStringToUint(ip), connectionPort, queryPort, 1u);
			}

			public static bool RemoveHistoryGame(AppId_t appId, string ip, ushort connectionPort, ushort queryPort)
			{
				return SteamMatchmaking.RemoveFavoriteGame(appId, Utilities.IPStringToUint(ip), connectionPort, queryPort, 2u);
			}

			public static bool RequestLobbyData(LobbyData lobby)
			{
				return SteamMatchmaking.RequestLobbyData(lobby);
			}

			public static void RequestLobbyList(Action<LobbyData[], bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (m_LobbyMatchList_t == null)
				{
					m_LobbyMatchList_t = CallResult<LobbyMatchList_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamMatchmaking.RequestLobbyList();
				m_LobbyMatchList_t.Set(hAPICall, delegate(LobbyMatchList_t results, bool error)
				{
					if (!error && results.m_nLobbiesMatching != 0)
					{
						LobbyData[] array = new LobbyData[results.m_nLobbiesMatching];
						for (int i = 0; i < results.m_nLobbiesMatching; i++)
						{
							array[i] = SteamMatchmaking.GetLobbyByIndex(i);
						}
						callback(array, error);
					}
					else
					{
						callback(new LobbyData[0], error);
					}
				});
			}

			public static bool SendLobbyChatMsg(LobbyData lobby, byte[] messageBody)
			{
				return SteamMatchmaking.SendLobbyChatMsg(lobby, messageBody, messageBody.Length);
			}

			public static bool SetLobbyData(LobbyData lobby, string key, string value)
			{
				return SteamMatchmaking.SetLobbyData(lobby, key, value);
			}

			public static void SetLobbyGameServer(LobbyData lobby, uint ip, ushort port, CSteamID gameServerId)
			{
				SteamMatchmaking.SetLobbyGameServer(lobby, ip, port, gameServerId);
			}

			public static void SetLobbyGameServer(LobbyData lobby, string ip, ushort port, CSteamID gameServerId)
			{
				SteamMatchmaking.SetLobbyGameServer(lobby, Utilities.IPStringToUint(ip), port, gameServerId);
			}

			public static bool SetLobbyJoinable(LobbyData lobby, bool joinable)
			{
				return SteamMatchmaking.SetLobbyJoinable(lobby, joinable);
			}

			public static string GetLobbyMemberData(LobbyData lobby, CSteamID member, string key)
			{
				return SteamMatchmaking.GetLobbyMemberData(lobby, member, key);
			}

			public static bool GetMember(LobbyData lobby, CSteamID id, out LobbyMemberData member)
			{
				if (GetLobbyMemberData(lobby, id, "anyKey") == null)
				{
					member = default(LobbyMemberData);
					return false;
				}
				member = new LobbyMemberData
				{
					lobby = lobby,
					user = id
				};
				return true;
			}

			public static bool IsAMember(LobbyData lobby, CSteamID id)
			{
				return GetLobbyMemberData(lobby, id, "anyKey") != null;
			}

			public static void SetLobbyMemberData(LobbyData lobby, string key, string value)
			{
				SteamMatchmaking.SetLobbyMemberData(lobby, key, value);
			}

			public static bool SetLobbyMemberLimit(LobbyData lobby, int maxMembers)
			{
				return SteamMatchmaking.SetLobbyMemberLimit(lobby, maxMembers);
			}

			public static bool SetLobbyOwner(LobbyData lobby, CSteamID newOwner)
			{
				return SteamMatchmaking.SetLobbyOwner(lobby, newOwner);
			}

			public static bool SetLobbyType(LobbyData lobby, ELobbyType type)
			{
				CSteamID steamIDLobby = lobby;
				int num = (int)type;
				SteamMatchmaking.SetLobbyData(steamIDLobby, "z_heathenType", num.ToString());
				return SteamMatchmaking.SetLobbyType(lobby, type);
			}

			public static void CancelQuery(HServerListRequest request)
			{
				SteamMatchmakingServers.CancelQuery(request);
			}

			public static void CancelServerQuery(HServerQuery query)
			{
				SteamMatchmakingServers.CancelServerQuery(query);
			}

			public static int GetServerCount(HServerListRequest request)
			{
				return SteamMatchmakingServers.GetServerCount(request);
			}

			public static gameserveritem_t GetServerDetails(HServerListRequest request, int index)
			{
				return SteamMatchmakingServers.GetServerDetails(request, index);
			}

			public static gameserveritem_t[] GetServerDetails(HServerListRequest request)
			{
				int serverCount = SteamMatchmakingServers.GetServerCount(request);
				gameserveritem_t[] array = new gameserveritem_t[serverCount];
				for (int i = 0; i < serverCount; i++)
				{
					array[i] = SteamMatchmakingServers.GetServerDetails(request, i);
				}
				return array;
			}

			public static bool IsRefreshing(HServerListRequest request)
			{
				return SteamMatchmakingServers.IsRefreshing(request);
			}

			public static HServerQuery PingServer(uint ip, ushort port, ISteamMatchmakingPingResponse response)
			{
				return SteamMatchmakingServers.PingServer(ip, port, response);
			}

			public static HServerQuery PingServer(string ip, ushort port, ISteamMatchmakingPingResponse response)
			{
				return SteamMatchmakingServers.PingServer(Utilities.IPStringToUint(ip), port, response);
			}

			public static HServerQuery PlayerDetails(uint ip, ushort port, ISteamMatchmakingPlayersResponse response)
			{
				return SteamMatchmakingServers.PlayerDetails(ip, port, response);
			}

			public static HServerQuery PlayerDetails(string ip, ushort port, ISteamMatchmakingPlayersResponse response)
			{
				return SteamMatchmakingServers.PlayerDetails(Utilities.IPStringToUint(ip), port, response);
			}

			public static void RefreshQuery(HServerListRequest request)
			{
				SteamMatchmakingServers.RefreshQuery(request);
			}

			public static void RefreshServer(HServerListRequest request, int index)
			{
				SteamMatchmakingServers.RefreshServer(request, index);
			}

			public static void ReleaseRequest(HServerListRequest request)
			{
				SteamMatchmakingServers.ReleaseRequest(request);
			}

			public static HServerListRequest RequestFavoritesServerList(AppId_t appId, MatchMakingKeyValuePair_t[] filters, ISteamMatchmakingServerListResponse pRequestServersResponse)
			{
				return SteamMatchmakingServers.RequestFavoritesServerList(appId, filters, (uint)filters.Length, pRequestServersResponse);
			}

			public static HServerListRequest RequestFriendsServerList(AppId_t appId, MatchMakingKeyValuePair_t[] filters, ISteamMatchmakingServerListResponse pRequestServersResponse)
			{
				return SteamMatchmakingServers.RequestFriendsServerList(appId, filters, (uint)filters.Length, pRequestServersResponse);
			}

			public static HServerListRequest RequestHistoryServerList(AppId_t appId, MatchMakingKeyValuePair_t[] filters, ISteamMatchmakingServerListResponse pRequestServersResponse)
			{
				return SteamMatchmakingServers.RequestHistoryServerList(appId, filters, (uint)filters.Length, pRequestServersResponse);
			}

			public static HServerListRequest RequestInternetServerList(AppId_t appId, MatchMakingKeyValuePair_t[] filters, ISteamMatchmakingServerListResponse pRequestServersResponse)
			{
				return SteamMatchmakingServers.RequestInternetServerList(appId, filters, (uint)filters.Length, pRequestServersResponse);
			}

			public static HServerListRequest RequestLANServerList(AppId_t appId, ISteamMatchmakingServerListResponse pRequestServersResponse)
			{
				return SteamMatchmakingServers.RequestLANServerList(appId, pRequestServersResponse);
			}

			public static HServerListRequest RequestSpectatorServerList(AppId_t appId, MatchMakingKeyValuePair_t[] filters, ISteamMatchmakingServerListResponse pRequestServersResponse)
			{
				return SteamMatchmakingServers.RequestSpectatorServerList(appId, filters, (uint)filters.Length, pRequestServersResponse);
			}

			public static HServerQuery ServerRules(uint ip, ushort port, ISteamMatchmakingRulesResponse response)
			{
				return SteamMatchmakingServers.ServerRules(ip, port, response);
			}

			public static HServerQuery ServerRules(string ip, ushort port, ISteamMatchmakingRulesResponse response)
			{
				return SteamMatchmakingServers.ServerRules(Utilities.IPStringToUint(ip), port, response);
			}

			public static void LeaveAllLobbies()
			{
				LobbyData[] array = memberOfLobbies.ToArray();
				foreach (LobbyData lobbyData in array)
				{
					lobbyData.Leave();
				}
				memberOfLobbies.Clear();
			}
		}
	}
}
