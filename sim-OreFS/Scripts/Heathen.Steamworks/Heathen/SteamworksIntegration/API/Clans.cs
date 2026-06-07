using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.API
{
	public static class Clans
	{
		public static class Client
		{
			public static readonly List<ChatRoom> joinedRooms = new List<ChatRoom>();

			private static GameConnectedClanChatMsgEvent eventGameConnectedClanChatMsg = new GameConnectedClanChatMsgEvent();

			private static GameConnectedChatJoinEvent eventGameConnectedChatJoin = new GameConnectedChatJoinEvent();

			private static GameConnectedChatLeaveEvent eventGameConnectedChatLeave = new GameConnectedChatLeaveEvent();

			private static CallResult<DownloadClanActivityCountsResult_t> m_DownloadClanActivityCountsResult_t;

			private static CallResult<ClanOfficerListResponse_t> m_ClanOfficerListResponse_t;

			private static CallResult<JoinClanChatRoomCompletionResult_t> m_JoinClanChatRoomCompletionResult_t;

			private static Callback<GameConnectedClanChatMsg_t> m_GameConnectedClanChatMsg_t;

			private static Callback<GameConnectedChatJoin_t> m_GameConnectedChatJoin_t;

			private static Callback<GameConnectedChatLeave_t> m_GameConnectedChatLeave_t;

			public static GameConnectedClanChatMsgEvent EventChatMessageReceived
			{
				get
				{
					if (m_GameConnectedClanChatMsg_t == null)
					{
						m_GameConnectedClanChatMsg_t = Callback<GameConnectedClanChatMsg_t>.Create(delegate(GameConnectedClanChatMsg_t result)
						{
							ChatRoom room = joinedRooms.FirstOrDefault((ChatRoom p) => p.id == result.m_steamIDClanChat);
							if (room.clan == default(ClanData))
							{
								room.id = result.m_steamIDClanChat;
								room.enterResponse = EChatRoomEnterResponse.k_EChatRoomEnterResponseError;
								if (App.isDebugging)
								{
									CSteamID id = room.id;
									Debug.LogWarning("Received a message from chat room: " + id.ToString() + ", no such room is known!");
								}
							}
							EChatEntryType type;
							CSteamID chatter;
							string chatMessage = GetChatMessage(result.m_steamIDClanChat, result.m_iMessageID, out type, out chatter);
							ClanChatMsg arg = new ClanChatMsg
							{
								room = room,
								message = chatMessage,
								type = type,
								user = chatter
							};
							eventGameConnectedClanChatMsg.Invoke(arg);
						});
					}
					return eventGameConnectedClanChatMsg;
				}
			}

			public static GameConnectedChatJoinEvent EventGameConnectedChatJoin
			{
				get
				{
					if (m_GameConnectedChatJoin_t == null)
					{
						m_GameConnectedChatJoin_t = Callback<GameConnectedChatJoin_t>.Create(delegate(GameConnectedChatJoin_t result)
						{
							ChatRoom arg = joinedRooms.FirstOrDefault((ChatRoom p) => p.id == result.m_steamIDClanChat);
							if (arg.clan == default(ClanData))
							{
								arg.id = result.m_steamIDClanChat;
								arg.enterResponse = EChatRoomEnterResponse.k_EChatRoomEnterResponseError;
								if (App.isDebugging)
								{
									CSteamID id = arg.id;
									Debug.LogWarning("Received a chat join event from chat room: " + id.ToString() + ", no such room is known!");
								}
							}
							eventGameConnectedChatJoin.Invoke(arg, result.m_steamIDUser);
						});
					}
					return eventGameConnectedChatJoin;
				}
			}

			public static GameConnectedChatLeaveEvent EventGameConnectedChatLeave
			{
				get
				{
					if (m_GameConnectedChatLeave_t == null)
					{
						m_GameConnectedChatLeave_t = Callback<GameConnectedChatLeave_t>.Create(delegate(GameConnectedChatLeave_t result)
						{
							ChatRoom room = joinedRooms.FirstOrDefault((ChatRoom p) => p.id == result.m_steamIDClanChat);
							if (room.clan == default(ClanData))
							{
								room.id = result.m_steamIDClanChat;
								room.enterResponse = EChatRoomEnterResponse.k_EChatRoomEnterResponseError;
								if (App.isDebugging)
								{
									CSteamID id = room.id;
									Debug.LogWarning("Received a chat leave event from chat room: " + id.ToString() + ", no such room is known!");
								}
							}
							eventGameConnectedChatLeave.Invoke(new UserLeaveData
							{
								room = room,
								user = result.m_steamIDUser,
								dropped = result.m_bDropped,
								kicked = result.m_bKicked
							});
						});
					}
					return eventGameConnectedChatLeave;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				eventGameConnectedClanChatMsg = new GameConnectedClanChatMsgEvent();
				eventGameConnectedChatJoin = new GameConnectedChatJoinEvent();
				eventGameConnectedChatLeave = new GameConnectedChatLeaveEvent();
				m_DownloadClanActivityCountsResult_t = null;
				m_ClanOfficerListResponse_t = null;
				m_JoinClanChatRoomCompletionResult_t = null;
				m_GameConnectedClanChatMsg_t = null;
				m_GameConnectedChatJoin_t = null;
				m_GameConnectedChatLeave_t = null;
				joinedRooms.Clear();
			}

			public static void JoinChatRoom(ClanData clan, Action<ChatRoom, bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (m_JoinClanChatRoomCompletionResult_t == null)
				{
					m_JoinClanChatRoomCompletionResult_t = CallResult<JoinClanChatRoomCompletionResult_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamFriends.JoinClanChatRoom(clan);
				m_JoinClanChatRoomCompletionResult_t.Set(hAPICall, delegate(JoinClanChatRoomCompletionResult_t r, bool e)
				{
					if (!e)
					{
						ChatRoom chatRoom = new ChatRoom
						{
							clan = clan,
							id = r.m_steamIDClanChat,
							enterResponse = r.m_eChatRoomEnterResponse
						};
						if (r.m_eChatRoomEnterResponse == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
						{
							joinedRooms.Add(chatRoom);
						}
						callback(chatRoom, e);
					}
					else
					{
						callback(default(ChatRoom), e);
					}
				});
			}

			public static bool LeaveChatRoom(CSteamID clanChatId)
			{
				joinedRooms.RemoveAll((ChatRoom p) => p.id == clanChatId);
				return SteamFriends.LeaveClanChatRoom(clanChatId);
			}

			public static bool LeaveChatRoom(ChatRoom clanChat)
			{
				joinedRooms.Remove(clanChat);
				return SteamFriends.LeaveClanChatRoom(clanChat.id);
			}

			public static UserData GetChatMemberByIndex(CSteamID clan, int index)
			{
				return SteamFriends.GetChatMemberByIndex(clan, index);
			}

			public static bool GetActivityCounts(CSteamID clan, out int online, out int inGame, out int chatting)
			{
				return SteamFriends.GetClanActivityCounts(clan, out online, out inGame, out chatting);
			}

			public static ClanData GetClanByIndex(int clanIndex)
			{
				return SteamFriends.GetClanByIndex(clanIndex);
			}

			public static ClanData[] GetClans()
			{
				int clanCount = SteamFriends.GetClanCount();
				ClanData[] array = new ClanData[clanCount];
				for (int i = 0; i < clanCount; i++)
				{
					array[i] = SteamFriends.GetClanByIndex(i);
				}
				return array;
			}

			public static int GetChatMemberCount(ClanData clanId)
			{
				return SteamFriends.GetClanChatMemberCount(clanId);
			}

			public static UserData[] GetChatMembers(ClanData clanId)
			{
				int clanChatMemberCount = SteamFriends.GetClanChatMemberCount(clanId);
				if (clanChatMemberCount > 0)
				{
					UserData[] array = new UserData[clanChatMemberCount];
					for (int i = 0; i < clanChatMemberCount; i++)
					{
						array[i] = SteamFriends.GetChatMemberByIndex(clanId, i);
					}
					return array;
				}
				return new UserData[0];
			}

			public static string GetChatMessage(CSteamID clanChatId, int index, out EChatEntryType type, out CSteamID chatter)
			{
				if (SteamFriends.GetClanChatMessage(clanChatId, index, out var prgchText, 8193, out type, out chatter) > 0)
				{
					return prgchText;
				}
				return string.Empty;
			}

			public static string GetChatMessage(ChatRoom clanChat, int index, out EChatEntryType type, out CSteamID chatter)
			{
				if (SteamFriends.GetClanChatMessage(clanChat.id, index, out var prgchText, 8193, out type, out chatter) > 0)
				{
					return prgchText;
				}
				return string.Empty;
			}

			public static int GetClanCount()
			{
				return SteamFriends.GetClanCount();
			}

			public static string GetName(ClanData clanId)
			{
				return SteamFriends.GetClanName(clanId);
			}

			public static UserData GetOfficerByIndex(ClanData clanId, int officerIndex)
			{
				return SteamFriends.GetClanOfficerByIndex(clanId, officerIndex);
			}

			public static UserData[] GetOfficers(ClanData clanId)
			{
				SteamFriends.RequestClanOfficerList(clanId);
				int clanOfficerCount = SteamFriends.GetClanOfficerCount(clanId);
				if (clanOfficerCount > 0)
				{
					UserData[] array = new UserData[clanOfficerCount];
					for (int i = 0; i < clanOfficerCount; i++)
					{
						array[i] = SteamFriends.GetClanOfficerByIndex(clanId, i);
					}
					return array;
				}
				return new UserData[0];
			}

			public static int GetOfficerCount(ClanData clanId)
			{
				return SteamFriends.GetClanOfficerCount(clanId);
			}

			public static UserData GetOwner(ClanData clanId)
			{
				return SteamFriends.GetClanOwner(clanId);
			}

			public static string GetTag(ClanData clanId)
			{
				return SteamFriends.GetClanTag(clanId);
			}

			public static bool OpenChatWindowInSteam(CSteamID clanChatRoomId)
			{
				return SteamFriends.OpenClanChatWindowInSteam(clanChatRoomId);
			}

			public static bool OpenChatWindowInSteam(ChatRoom clanChat)
			{
				return SteamFriends.OpenClanChatWindowInSteam(clanChat.id);
			}

			public static bool SendChatMessage(CSteamID clanChatId, string message)
			{
				return SteamFriends.SendClanChatMessage(clanChatId, message);
			}

			public static bool SendChatMessage(ChatRoom clanChat, string message)
			{
				return SteamFriends.SendClanChatMessage(clanChat.id, message);
			}

			public static bool IsClanChatAdmin(CSteamID clanChatId, CSteamID userId)
			{
				return SteamFriends.IsClanChatAdmin(clanChatId, userId);
			}

			public static bool IsClanChatAdmin(ChatRoom clanChat, CSteamID userId)
			{
				return SteamFriends.IsClanChatAdmin(clanChat.id, userId);
			}

			public static bool IsClanPublic(ClanData clanId)
			{
				return SteamFriends.IsClanPublic(clanId);
			}

			public static bool IsClanOfficialGameGroup(ClanData clanId)
			{
				return SteamFriends.IsClanOfficialGameGroup(clanId);
			}

			public static bool IsClanChatWindowOpenInSteam(CSteamID clanChatId)
			{
				return SteamFriends.IsClanChatWindowOpenInSteam(clanChatId);
			}

			public static void RequestClanOfficerList(CSteamID clanId, Action<ClanOfficerListResponse_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_ClanOfficerListResponse_t == null)
					{
						m_ClanOfficerListResponse_t = CallResult<ClanOfficerListResponse_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamFriends.RequestClanOfficerList(clanId);
					m_ClanOfficerListResponse_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool CloseClanChatWindowInSteam(CSteamID clanChatId)
			{
				return SteamFriends.CloseClanChatWindowInSteam(clanChatId);
			}

			public static bool CloseClanChatWindowInSteam(ChatRoom clanChat)
			{
				return SteamFriends.CloseClanChatWindowInSteam(clanChat.id);
			}

			public static void DownloadClanActivityCounts(CSteamID[] clans, Action<DownloadClanActivityCountsResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_DownloadClanActivityCountsResult_t == null)
					{
						m_DownloadClanActivityCountsResult_t = CallResult<DownloadClanActivityCountsResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamFriends.DownloadClanActivityCounts(clans, clans.Length);
					m_DownloadClanActivityCountsResult_t.Set(hAPICall, callback.Invoke);
				}
			}
		}
	}
}
