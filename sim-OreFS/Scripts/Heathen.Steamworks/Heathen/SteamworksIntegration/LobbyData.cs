using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct LobbyData : IEquatable<CSteamID>, IEquatable<ulong>, IEquatable<LobbyData>
	{
		private ulong id;

		public const string DataName = "name";

		public const string DataVersion = "z_heathenGameVersion";

		public const string DataReady = "z_heathenReady";

		public const string DataKick = "z_heathenKick";

		public const string DataMode = "z_heathenMode";

		public const string DataType = "z_heathenType";

		public readonly CSteamID SteamId => new CSteamID(id);

		public readonly AccountID_t AccountId => SteamId.GetAccountID();

		public readonly uint FriendId => AccountId.m_AccountID;

		public readonly string HexId => FriendId.ToString("X");

		public readonly bool IsValid
		{
			get
			{
				CSteamID steamId = SteamId;
				if (steamId == CSteamID.Nil || steamId.GetEAccountType() != EAccountType.k_EAccountTypeChat || steamId.GetEUniverse() != EUniverse.k_EUniversePublic)
				{
					return false;
				}
				return true;
			}
		}

		public readonly string Name
		{
			get
			{
				return this["name"];
			}
			set
			{
				this["name"] = value;
			}
		}

		public readonly LobbyMemberData Owner
		{
			get
			{
				return new LobbyMemberData
				{
					lobby = this,
					user = Matchmaking.Client.GetLobbyOwner(id)
				};
			}
			set
			{
				Matchmaking.Client.SetLobbyOwner(id, value.user);
			}
		}

		public readonly LobbyMemberData Me => new LobbyMemberData
		{
			lobby = this,
			user = User.Client.Id
		};

		public readonly LobbyMemberData[] Members => Matchmaking.Client.GetLobbyMembers(id);

		public readonly bool IsTypeSet => !string.IsNullOrEmpty(Matchmaking.Client.GetLobbyData(id, "z_heathenType"));

		public readonly ELobbyType Type
		{
			get
			{
				if (int.TryParse(Matchmaking.Client.GetLobbyData(id, "z_heathenType"), out var result))
				{
					return (ELobbyType)result;
				}
				return ELobbyType.k_ELobbyTypePrivate;
			}
			set
			{
				Matchmaking.Client.SetLobbyType(id, value);
			}
		}

		public readonly string GameVersion
		{
			get
			{
				return this["z_heathenGameVersion"];
			}
			set
			{
				this["z_heathenGameVersion"] = value;
			}
		}

		public readonly bool IsOwner => SteamUser.GetSteamID() == SteamMatchmaking.GetLobbyOwner(this);

		public readonly bool IsGroup
		{
			get
			{
				return this["z_heathenMode"] == "Group";
			}
			set
			{
				if (IsOwner)
				{
					if (value)
					{
						SetType(ELobbyType.k_ELobbyTypeInvisible);
						this["z_heathenMode"] = "Group";
					}
					else
					{
						this["z_heathenMode"] = "General";
					}
				}
			}
		}

		public readonly bool IsSession
		{
			get
			{
				return this["z_heathenMode"] == "Session";
			}
			set
			{
				if (IsOwner)
				{
					if (value)
					{
						this["z_heathenMode"] = "Session";
					}
					else
					{
						this["z_heathenMode"] = "General";
					}
				}
			}
		}

		public readonly bool HasServer
		{
			get
			{
				uint punGameServerIP;
				ushort punGameServerPort;
				CSteamID psteamIDGameServer;
				return SteamMatchmaking.GetLobbyGameServer(this, out punGameServerIP, out punGameServerPort, out psteamIDGameServer);
			}
		}

		public readonly LobbyGameServer GameServer => Matchmaking.Client.GetLobbyGameServer(id);

		public readonly bool AllPlayersReady => !Members.Any((LobbyMemberData p) => !p.IsReady);

		public readonly bool AllPlayersNotReady
		{
			get
			{
				if (!Members.Any((LobbyMemberData p) => p.IsReady))
				{
					return true;
				}
				return false;
			}
		}

		public readonly bool IsReady
		{
			get
			{
				return Matchmaking.Client.GetLobbyMemberData(id, User.Client.Id, "z_heathenReady") == "true";
			}
			set
			{
				Matchmaking.Client.SetLobbyMemberData(id, "z_heathenReady", value.ToString().ToLower());
			}
		}

		public readonly bool Full => Matchmaking.Client.GetLobbyMemberLimit(id) <= SteamMatchmaking.GetNumLobbyMembers(this);

		public readonly int MaxMembers
		{
			get
			{
				return Matchmaking.Client.GetLobbyMemberLimit(id);
			}
			set
			{
				Matchmaking.Client.SetLobbyMemberLimit(id, value);
			}
		}

		public readonly int MemberCount => SteamMatchmaking.GetNumLobbyMembers(this);

		public readonly string this[string metadataKey]
		{
			get
			{
				return Matchmaking.Client.GetLobbyData(id, metadataKey);
			}
			set
			{
				Matchmaking.Client.SetLobbyData(id, metadataKey, value);
			}
		}

		public readonly LobbyMemberData this[UserData user]
		{
			get
			{
				if (GetMember(user, out var member))
				{
					return member;
				}
				return default(LobbyMemberData);
			}
		}

		public readonly bool GetMember(UserData user, out LobbyMemberData member)
		{
			return Matchmaking.Client.GetMember(this, user, out member);
		}

		public readonly bool IsAMember(CSteamID id)
		{
			return Matchmaking.Client.IsAMember(this, id);
		}

		public readonly bool SetType(ELobbyType type)
		{
			return Matchmaking.Client.SetLobbyType(id, type);
		}

		public readonly bool SetJoinable(bool makeJoinable)
		{
			return Matchmaking.Client.SetLobbyJoinable(id, makeJoinable);
		}

		public readonly Dictionary<string, string> GetMetadata()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int lobbyDataCount = SteamMatchmaking.GetLobbyDataCount(this);
			for (int i = 0; i < lobbyDataCount; i++)
			{
				SteamMatchmaking.GetLobbyDataByIndex(this, i, out var pchKey, 255, out var pchValue, 8192);
				dictionary.Add(pchKey, pchValue);
			}
			return dictionary;
		}

		public static void Create(CreateArguments createArguments, Action<EResult, LobbyData, bool> callback)
		{
			Create(createArguments.type, createArguments.slots, delegate(EResult eResult, LobbyData lobby, bool ioError)
			{
				if (!ioError && eResult == EResult.k_EResultOK)
				{
					foreach (MetadataTemplate item in createArguments.metadata)
					{
						lobby[item.key] = item.value;
					}
					callback?.Invoke(eResult, lobby, ioError);
				}
			});
		}

		public static void Create(ELobbyType type, int slots, Action<EResult, LobbyData, bool> callback)
		{
			Matchmaking.Client.CreateLobby(type, slots, callback);
		}

		public static void CreateParty(int slots, Action<EResult, LobbyData, bool> callback)
		{
			Matchmaking.Client.CreateLobby(ELobbyType.k_ELobbyTypeInvisible, slots, delegate(EResult r, LobbyData l, bool e)
			{
				if (!e && r == EResult.k_EResultOK)
				{
					l.IsGroup = true;
				}
				callback?.Invoke(r, l, e);
			});
		}

		public static void CreateSession(ELobbyType type, int slots, Action<EResult, LobbyData, bool> callback)
		{
			Matchmaking.Client.CreateLobby(type, slots, delegate(EResult r, LobbyData l, bool e)
			{
				if (!e && r == EResult.k_EResultOK)
				{
					l.IsSession = true;
				}
				callback?.Invoke(r, l, e);
			});
		}

		public static void CreatePublicSession(int slots, Action<EResult, LobbyData, bool> callback)
		{
			Matchmaking.Client.CreateLobby(ELobbyType.k_ELobbyTypePublic, slots, delegate(EResult r, LobbyData l, bool e)
			{
				if (!e && r == EResult.k_EResultOK)
				{
					l.IsSession = true;
				}
				callback?.Invoke(r, l, e);
			});
		}

		public static void CreatePrivateSession(int slots, Action<EResult, LobbyData, bool> callback)
		{
			Matchmaking.Client.CreateLobby(ELobbyType.k_ELobbyTypePrivate, slots, delegate(EResult r, LobbyData l, bool e)
			{
				if (!e && r == EResult.k_EResultOK)
				{
					l.IsSession = true;
				}
				callback?.Invoke(r, l, e);
			});
		}

		public static void CreateFriendOnlySession(int slots, Action<EResult, LobbyData, bool> callback)
		{
			Matchmaking.Client.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, slots, delegate(EResult r, LobbyData l, bool e)
			{
				if (!e && r == EResult.k_EResultOK)
				{
					l.IsSession = true;
				}
				callback?.Invoke(r, l, e);
			});
		}

		public readonly void Join(Action<LobbyEnter, bool> callback)
		{
			Matchmaking.Client.JoinLobby(this, callback);
		}

		public readonly void Leave()
		{
			if (!(SteamId == CSteamID.Nil))
			{
				Matchmaking.Client.LeaveLobby(this);
			}
		}

		public readonly bool DeleteLobbyData(string dataKey)
		{
			return Matchmaking.Client.DeleteLobbyData(id, dataKey);
		}

		public readonly bool InviteUserToLobby(UserData targetUser)
		{
			return Matchmaking.Client.InviteUserToLobby(id, targetUser);
		}

		public readonly bool SendChatMessage(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				return false;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			return SteamMatchmaking.SendLobbyChatMsg(this, bytes, bytes.Length);
		}

		public readonly bool SendChatMessage(byte[] data)
		{
			if (data == null || data.Length < 1)
			{
				return false;
			}
			return SteamMatchmaking.SendLobbyChatMsg(this, data, data.Length);
		}

		public readonly bool SendChatMessage(object jsonObject)
		{
			return SendChatMessage(Encoding.UTF8.GetBytes(JsonUtility.ToJson(jsonObject)));
		}

		public readonly void SetGameServer(string address, ushort port, CSteamID gameServerId)
		{
			Matchmaking.Client.SetLobbyGameServer(id, address, port, gameServerId);
		}

		public readonly void SetGameServer(string address, ushort port)
		{
			Matchmaking.Client.SetLobbyGameServer(id, address, port, CSteamID.Nil);
		}

		public readonly void SetGameServer(CSteamID gameServerId)
		{
			Matchmaking.Client.SetLobbyGameServer(id, 0u, 0, gameServerId);
		}

		public readonly void SetGameServer()
		{
			Matchmaking.Client.SetLobbyGameServer(id, 0u, 0, User.Client.Id);
		}

		public readonly bool KickMember(UserData memberId)
		{
			if (!IsOwner)
			{
				return false;
			}
			string text = Matchmaking.Client.GetLobbyData(id, "z_heathenKick");
			if (text == null)
			{
				text = string.Empty;
			}
			if (!text.Contains("[" + memberId.ToString() + "]"))
			{
				text = text + "[" + memberId.ToString() + "]";
			}
			return Matchmaking.Client.SetLobbyData(id, "z_heathenKick", text);
		}

		public readonly bool KickListContains(UserData memberId)
		{
			return Matchmaking.Client.GetLobbyData(id, "z_heathenKick").Contains("[" + memberId.ToString() + "]");
		}

		public readonly bool RemoveFromKickList(UserData memberId)
		{
			if (!IsOwner)
			{
				return false;
			}
			string lobbyData = Matchmaking.Client.GetLobbyData(id, "z_heathenKick");
			lobbyData = lobbyData.Replace("[" + memberId.ToString() + "]", string.Empty);
			return Matchmaking.Client.SetLobbyData(id, "z_heathenKick", lobbyData);
		}

		public readonly bool ClearKickList()
		{
			if (!IsOwner)
			{
				return false;
			}
			return Matchmaking.Client.DeleteLobbyData(id, "z_heathenKick");
		}

		public readonly UserData[] GetKickList()
		{
			string lobbyData = Matchmaking.Client.GetLobbyData(id, "z_heathenKick");
			if (!string.IsNullOrEmpty(lobbyData))
			{
				string[] array = lobbyData.Split(new string[1] { "][" }, StringSplitOptions.RemoveEmptyEntries);
				List<UserData> list = new List<UserData>();
				for (int i = 0; i < array.Length; i++)
				{
					UserData item = UserData.Get(array[i].Replace("[", string.Empty).Replace("]", string.Empty));
					if (item.IsValid)
					{
						list.Add(item);
					}
				}
				return list.ToArray();
			}
			return new UserData[0];
		}

		public readonly void SetMemberMetadata(string key, string value)
		{
			Matchmaking.Client.SetLobbyMemberData(id, key, value);
		}

		public readonly string GetMemberMetadata(string key)
		{
			return Matchmaking.Client.GetLobbyMemberData(id, User.Client.Id, key);
		}

		public readonly string GetMemberMetadata(UserData memberId, string key)
		{
			return Matchmaking.Client.GetLobbyMemberData(id, memberId, key);
		}

		public readonly string GetMemberMetadata(LobbyMemberData member, string key)
		{
			return Matchmaking.Client.GetLobbyMemberData(id, member.user, key);
		}

		public readonly bool RequestData()
		{
			return Matchmaking.Client.RequestLobbyData(id);
		}

		public static LobbyData Get(string accountId)
		{
			uint num = Convert.ToUInt32(accountId, 16);
			if (num != 0)
			{
				return Get(num);
			}
			return CSteamID.Nil;
		}

		public static LobbyData Get(uint accountId)
		{
			return new CSteamID(new AccountID_t(accountId), 393216u, EUniverse.k_EUniversePublic, EAccountType.k_EAccountTypeChat);
		}

		public static LobbyData Get(AccountID_t accountId)
		{
			return new CSteamID(accountId, 393216u, EUniverse.k_EUniversePublic, EAccountType.k_EAccountTypeChat);
		}

		public static LobbyData Get(ulong id)
		{
			return new LobbyData
			{
				id = id
			};
		}

		public static LobbyData Get(CSteamID id)
		{
			return new LobbyData
			{
				id = id.m_SteamID
			};
		}

		public static bool GroupLobby(out LobbyData lobby)
		{
			lobby = Matchmaking.Client.memberOfLobbies.FirstOrDefault((LobbyData p) => p.IsGroup);
			return lobby.IsValid;
		}

		public static bool SessionLobby(out LobbyData lobby)
		{
			lobby = Matchmaking.Client.memberOfLobbies.FirstOrDefault((LobbyData p) => p.IsSession);
			return lobby.IsValid;
		}

		public static void Join(string accountId, Action<LobbyEnter, bool> callback)
		{
			Matchmaking.Client.JoinLobby(Get(accountId), callback);
		}

		public static void Join(LobbyData lobby, Action<LobbyEnter, bool> callback)
		{
			Matchmaking.Client.JoinLobby(lobby, callback);
		}

		public static void Join(AccountID_t accountId, Action<LobbyEnter, bool> callback)
		{
			Matchmaking.Client.JoinLobby(Get(accountId), callback);
		}

		public static void Request(ELobbyDistanceFilter distanceFilter, int openSlotsRequired, int maxResultsToReturn, IEnumerable<StringFilter> stringFilters, IEnumerable<NearFilter> nearFilters, IEnumerable<NumericFilter> numericFilters, Action<LobbyData[], bool> callback)
		{
			Matchmaking.Client.AddRequestLobbyListDistanceFilter(distanceFilter);
			Matchmaking.Client.AddRequestLobbyListFilterSlotsAvailable(openSlotsRequired);
			if (stringFilters != null && stringFilters.Count() > 0)
			{
				foreach (StringFilter stringFilter in stringFilters)
				{
					Matchmaking.Client.AddRequestLobbyListStringFilter(stringFilter.key, stringFilter.value, stringFilter.comparison);
				}
			}
			if (nearFilters != null && nearFilters.Count() > 0)
			{
				foreach (NearFilter nearFilter in nearFilters)
				{
					Matchmaking.Client.AddRequestLobbyListNearValueFilter(nearFilter.key, nearFilter.value);
				}
			}
			if (numericFilters != null && numericFilters.Count() > 0)
			{
				foreach (NumericFilter numericFilter in numericFilters)
				{
					Matchmaking.Client.AddRequestLobbyListNumericalFilter(numericFilter.key, numericFilter.value, numericFilter.comparison);
				}
			}
			Matchmaking.Client.AddRequestLobbyListResultCountFilter(maxResultsToReturn);
			Matchmaking.Client.RequestLobbyList(callback);
		}

		public static void Request(SearchArguments searchArguments, int maxResultsToReturn, Action<LobbyData[], bool> callback)
		{
			Matchmaking.Client.AddRequestLobbyListDistanceFilter(searchArguments.distance);
			Matchmaking.Client.AddRequestLobbyListFilterSlotsAvailable(searchArguments.slots);
			if (searchArguments.stringFilters != null && searchArguments.stringFilters.Count() > 0)
			{
				foreach (StringFilter stringFilter in searchArguments.stringFilters)
				{
					Matchmaking.Client.AddRequestLobbyListStringFilter(stringFilter.key, stringFilter.value, stringFilter.comparison);
				}
			}
			if (searchArguments.nearValues != null && searchArguments.nearValues.Count() > 0)
			{
				foreach (NearFilter nearValue in searchArguments.nearValues)
				{
					Matchmaking.Client.AddRequestLobbyListNearValueFilter(nearValue.key, nearValue.value);
				}
			}
			if (searchArguments.numericFilters != null && searchArguments.numericFilters.Count() > 0)
			{
				foreach (NumericFilter numericFilter in searchArguments.numericFilters)
				{
					Matchmaking.Client.AddRequestLobbyListNumericalFilter(numericFilter.key, numericFilter.value, numericFilter.comparison);
				}
			}
			Matchmaking.Client.AddRequestLobbyListResultCountFilter(maxResultsToReturn);
			Matchmaking.Client.RequestLobbyList(callback);
		}

		public static void QuickMatch(SearchArguments searchArguments, CreateArguments createArguments, Action<EResult, LobbyData, bool> callback)
		{
			Request(searchArguments, 1, delegate(LobbyData[] results, bool error)
			{
				if (error)
				{
					callback?.Invoke(EResult.k_EResultIOFailure, default(LobbyData), error);
				}
				else if (results == null || results.Length < 1)
				{
					CreateSession(createArguments.type, createArguments.slots, delegate(EResult eResult, LobbyData lobby, bool ioError)
					{
						if (!ioError && eResult == EResult.k_EResultOK)
						{
							foreach (MetadataTemplate item in createArguments.metadata)
							{
								lobby[item.key] = item.value;
							}
							callback?.Invoke(eResult, lobby, ioError);
						}
					});
				}
				else
				{
					results[0].Join(delegate(LobbyEnter lEnter, bool flag)
					{
						if (flag)
						{
							callback?.Invoke(EResult.k_EResultIOFailure, default(LobbyData), flag);
						}
						else
						{
							switch (lEnter.Response)
							{
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseBanned:
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseCommunityBan:
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseMemberBlockedYou:
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseYouBlockedMember:
								callback?.Invoke(EResult.k_EResultBanned, lEnter.Lobby, flag);
								break;
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseFull:
								callback?.Invoke(EResult.k_EResultLimitExceeded, lEnter.Lobby, flag);
								break;
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseLimited:
								callback?.Invoke(EResult.k_EResultLimitedUserAccount, lEnter.Lobby, flag);
								break;
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess:
								callback?.Invoke(EResult.k_EResultOK, lEnter.Lobby, flag);
								break;
							case EChatRoomEnterResponse.k_EChatRoomEnterResponseRatelimitExceeded:
								callback?.Invoke(EResult.k_EResultRateLimitExceeded, lEnter.Lobby, flag);
								break;
							default:
								callback?.Invoke(EResult.k_EResultFail, lEnter.Lobby, flag);
								break;
							}
						}
					});
				}
			});
		}

		public readonly void Authenticate(Action<AuthenticationTicket, bool> callback)
		{
			UserData owningUser = Owner.user;
			LobbyData thisLobby = this;
			Authentication.GetAuthSessionTicket(owningUser, delegate(AuthenticationTicket ticket, bool ioError)
			{
				thisLobby.Authenticate(new LobbyAuthenticationData
				{
					to = owningUser,
					ticket = ticket.Data,
					inventory = null
				});
				callback(ticket, ioError);
			});
		}

		public readonly bool Authenticate(LobbyAuthenticationData data)
		{
			return Matchmaking.Client.SendLobbyChatMsg(this, Encoding.UTF8.GetBytes(JsonUtility.ToJson(data)));
		}

		public int CompareTo(CSteamID other)
		{
			return id.CompareTo(other);
		}

		public int CompareTo(ulong other)
		{
			return id.CompareTo(other);
		}

		public override string ToString()
		{
			return HexId;
		}

		public bool Equals(CSteamID other)
		{
			return id.Equals(other);
		}

		public bool Equals(ulong other)
		{
			return id.Equals(other);
		}

		public override bool Equals(object obj)
		{
			return id.Equals(obj);
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}

		public bool Equals(LobbyData other)
		{
			return id.Equals(other.id);
		}

		public static bool operator ==(LobbyData l, LobbyData r)
		{
			return l.id == r.id;
		}

		public static bool operator ==(CSteamID l, LobbyData r)
		{
			return l.m_SteamID == r.id;
		}

		public static bool operator ==(LobbyData l, CSteamID r)
		{
			return l.id == r.m_SteamID;
		}

		public static bool operator ==(LobbyData l, ulong r)
		{
			return l.id == r;
		}

		public static bool operator ==(ulong l, LobbyData r)
		{
			return l == r.id;
		}

		public static bool operator !=(LobbyData l, LobbyData r)
		{
			return l.id != r.id;
		}

		public static bool operator !=(CSteamID l, LobbyData r)
		{
			return l.m_SteamID != r.id;
		}

		public static bool operator !=(LobbyData l, CSteamID r)
		{
			return l.id != r.m_SteamID;
		}

		public static bool operator !=(LobbyData l, ulong r)
		{
			return l.id != r;
		}

		public static bool operator !=(ulong l, LobbyData r)
		{
			return l != r.id;
		}

		public static implicit operator CSteamID(LobbyData c)
		{
			return c.SteamId;
		}

		public static implicit operator LobbyData(CSteamID id)
		{
			return new LobbyData
			{
				id = id.m_SteamID
			};
		}

		public static implicit operator ulong(LobbyData id)
		{
			return id.id;
		}

		public static implicit operator LobbyData(ulong id)
		{
			return new LobbyData
			{
				id = id
			};
		}

		public static implicit operator LobbyData(AccountID_t id)
		{
			return Get(id);
		}

		public static implicit operator LobbyData(uint id)
		{
			return Get(id);
		}

		public static implicit operator LobbyData(string id)
		{
			return Get(id);
		}
	}
}
