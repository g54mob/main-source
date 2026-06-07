using System;
using System.Collections.Generic;
using System.Linq;
using Jundroo.SocialPlatforms.Steam.Multiplayer.Events;
using Steamworks;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer
{
	public class SteamPlatformMultiplayer : ISteamPlatformMultiplayer
	{
		private Callback<LobbyChatMsg_t> _callbackLobbyChatMessage;

		private Callback<LobbyChatUpdate_t> _callbackLobbyChatUpdate;

		private Callback<LobbyDataUpdate_t> _callbackLobbyDataUpdate;

		private Callback<GameLobbyJoinRequested_t> _callbackLobbyJoinRequested;

		private Callback<SteamNetworkingMessagesSessionFailed_t> _callbackNetworkingMessagesSessionFailed;

		private Callback<SteamNetworkingMessagesSessionRequest_t> _callbackNetworkingMessagesSessionRequest;

		private CallResult<LobbyCreated_t> _callResultCreateLobby;

		private CallResult<LobbyEnter_t> _callResultJoinLobby;

		private CallResult<LobbyMatchList_t> _callResultRequestLobbyList;

		private byte[] _lobbyChatMessageReceivedBuffer = new byte[4096];

		private IntPtr[] _messageBuffer;

		private byte[] _messageDataBuffer;

		public static bool EnableDebugLogging { get; set; } = true;

		public static bool EnableDebugLoggingForNetworkMessages { get; set; } = false;

		public event EventHandler<CreateLobbyResultEventArgs> CreateLobbyResult;

		public event EventHandler<JoinLobbyRequestedEventArgs> JoinLobbyRequested;

		public event EventHandler<JoinLobbyResultEventArgs> JoinLobbyResult;

		public event EventHandler<LobbyChatMessageEventArgs> LobbyChatMessageReceived;

		public event EventHandler<LobbyChatUpdateEventArgs> LobbyChatUpdate;

		public event EventHandler<LobbyDataUpdateEventArgs> LobbyDataUpdate;

		public event EventHandler<LobbyMemberDataUpdateEventArgs> LobbyMemberDataUpdate;

		public event EventHandler<NetworkingMessagesSessionFailedEventArgs> NetworkingMessagesSessionFailed;

		public event EventHandler<NetworkingMessagesSessionRequestEventArgs> NetworkingMessagesSessionRequest;

		public event EventHandler<RequestLobbyListResultEventArgs> RequestLobbyListResult;

		internal SteamPlatformMultiplayer()
		{
			_callResultCreateLobby = new CallResult<LobbyCreated_t>(OnLobbyCreatedResult);
			_callResultJoinLobby = new CallResult<LobbyEnter_t>(OnLobbyEnterResult);
			_callResultRequestLobbyList = new CallResult<LobbyMatchList_t>(OnRequestLobbyListResult);
			_callbackLobbyChatUpdate = new Callback<LobbyChatUpdate_t>(OnLobbyChatUpdate);
			_callbackLobbyChatMessage = new Callback<LobbyChatMsg_t>(OnLobbyChatMessageReceived);
			_callbackLobbyDataUpdate = new Callback<LobbyDataUpdate_t>(OnLobbyDataUpdate);
			_callbackLobbyJoinRequested = new Callback<GameLobbyJoinRequested_t>(OnLobbyJoinRequested);
			_callbackNetworkingMessagesSessionFailed = new Callback<SteamNetworkingMessagesSessionFailed_t>(OnNetworkingMessagesSessionFailed);
			_callbackNetworkingMessagesSessionRequest = new Callback<SteamNetworkingMessagesSessionRequest_t>(OnNetworkingMessagesSessionRequest);
			ApplyGreaseToSqueakyWheels();
		}

		public bool AcceptSessionWithUser(ulong userId)
		{
			SteamNetworkingIdentity identityRemote = default(SteamNetworkingIdentity);
			identityRemote.SetSteamID64(userId);
			return SteamNetworkingMessages.AcceptSessionWithUser(ref identityRemote);
		}

		public void ActivateGameOverlayInviteDialog(ulong lobbyId)
		{
			SteamFriends.ActivateGameOverlayInviteDialog((CSteamID)lobbyId);
		}

		public bool CloseSessionWithUser(ulong userId)
		{
			SteamNetworkingIdentity identityRemote = default(SteamNetworkingIdentity);
			identityRemote.SetSteamID64(userId);
			return SteamNetworkingMessages.CloseSessionWithUser(ref identityRemote);
		}

		public void CreateLobby(LobbyType type, int maxMembers)
		{
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam CreateLobby: Type={type}, MaxMembers={maxMembers}");
			}
			SteamAPICall_t hAPICall = SteamMatchmaking.CreateLobby(ConvertEnum(type), maxMembers);
			_callResultCreateLobby.Set(hAPICall);
		}

		public bool DeleteLobbyData(ulong lobbyId, string key)
		{
			bool flag = SteamMatchmaking.DeleteLobbyData(new CSteamID(lobbyId), key);
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam DeleteLobbyData: LobbyId={lobbyId}, Key={key}, Result={flag}");
			}
			return flag;
		}

		public int EstimatePingTimeFromLocalHost(string pingLocation)
		{
			if (!SteamNetworkingUtils.ParsePingLocationString(pingLocation, out var result))
			{
				return -1;
			}
			return SteamNetworkingUtils.EstimatePingTimeFromLocalHost(ref result);
		}

		public ulong? GetCurrentLobbyOfFriend(ulong friendId)
		{
			if (SteamFriends.GetFriendGamePlayed(new CSteamID(friendId), out var pFriendGameInfo) && pFriendGameInfo.m_gameID.AppID() == SteamUtils.GetAppID() && pFriendGameInfo.m_steamIDLobby.IsValid())
			{
				return pFriendGameInfo.m_steamIDLobby.m_SteamID;
			}
			return null;
		}

		public void GetLobbyData(ulong lobbyId, IDictionary<string, string> lobbyData)
		{
			int lobbyDataCount = GetLobbyDataCount(lobbyId);
			for (int i = 0; i < lobbyDataCount; i++)
			{
				if (!GetLobbyDataByIndex(lobbyId, i, out var key, out var value))
				{
					Debug.LogError($"Steam failed to retrieve lobby data for lobby '{lobbyId}' at index '{i}'");
				}
				else
				{
					lobbyData.Add(key, value);
				}
			}
		}

		public Dictionary<string, string> GetLobbyData(ulong lobbyId)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			GetLobbyData(lobbyId, dictionary);
			return dictionary;
		}

		public string GetLobbyData(ulong lobbyId, string key)
		{
			string lobbyData = SteamMatchmaking.GetLobbyData(new CSteamID(lobbyId), key);
			if (EnableDebugLogging)
			{
				Debug.Log(string.Format("Steam GetLobbyData: LobbyId={0}, Key={1}, Value={2}", lobbyId, key ?? "(null)", lobbyData ?? "(null)"));
			}
			return lobbyData;
		}

		public bool GetLobbyDataByIndex(ulong lobbyId, int index, out string key, out string value, int? keyBufferSize = null, int? valueBufferSize = null)
		{
			int valueOrDefault = keyBufferSize.GetValueOrDefault();
			if (!keyBufferSize.HasValue)
			{
				valueOrDefault = 255;
				keyBufferSize = valueOrDefault;
			}
			valueOrDefault = valueBufferSize.GetValueOrDefault();
			if (!valueBufferSize.HasValue)
			{
				valueOrDefault = 8192;
				valueBufferSize = valueOrDefault;
			}
			return SteamMatchmaking.GetLobbyDataByIndex(new CSteamID(lobbyId), index, out key, keyBufferSize.Value, out value, valueBufferSize.Value);
		}

		public int GetLobbyDataCount(ulong lobbyId)
		{
			return SteamMatchmaking.GetLobbyDataCount(new CSteamID(lobbyId));
		}

		public string GetLobbyMemberData(ulong lobbyId, ulong userId, string key)
		{
			string lobbyMemberData = SteamMatchmaking.GetLobbyMemberData(new CSteamID(lobbyId), new CSteamID(userId), key);
			if (EnableDebugLogging)
			{
				Debug.Log(string.Format("Steam GetLobbyMemberData: LobbyId={0}, UserId={1}, Key={2}, Value={3}", lobbyId, userId, key ?? "(null)", lobbyMemberData ?? "(null)"));
			}
			return lobbyMemberData;
		}

		public int GetLobbyMemberLimit(ulong lobbyId)
		{
			int lobbyMemberLimit = SteamMatchmaking.GetLobbyMemberLimit(new CSteamID(lobbyId));
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam GetLobbyMemberLimit: LobbyId={lobbyId}, Result={lobbyMemberLimit}");
			}
			return lobbyMemberLimit;
		}

		public List<LobbyMemberInfo> GetLobbyMembers(ulong lobbyId)
		{
			int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(new CSteamID(lobbyId));
			List<LobbyMemberInfo> list = new List<LobbyMemberInfo>(numLobbyMembers);
			GetLobbyMembers(lobbyId, numLobbyMembers, list);
			return list;
		}

		public void GetLobbyMembers(ulong lobbyId, IList<LobbyMemberInfo> members)
		{
			int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(new CSteamID(lobbyId));
			GetLobbyMembers(lobbyId, numLobbyMembers, members);
		}

		public ulong GetLobbyOwner(ulong lobbyId)
		{
			CSteamID lobbyOwner = SteamMatchmaking.GetLobbyOwner(new CSteamID(lobbyId));
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam GetLobbyOwner: LobbyId={lobbyId}, Result={lobbyOwner.m_SteamID}");
			}
			return lobbyOwner.m_SteamID;
		}

		public string GetLocalPingLocation()
		{
			if (SteamNetworkingUtils.GetLocalPingLocation(out var result) < 0f)
			{
				return string.Empty;
			}
			SteamNetworkingUtils.ConvertPingLocationToString(ref result, out var pszBuf, 1024);
			return pszBuf;
		}

		public int GetNumLobbyMembers(ulong lobbyId)
		{
			return SteamMatchmaking.GetNumLobbyMembers(new CSteamID(lobbyId));
		}

		public void JoinLobby(ulong lobbyId)
		{
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam JoinLobby: Lobby={lobbyId}");
			}
			SteamAPICall_t hAPICall = SteamMatchmaking.JoinLobby(new CSteamID(lobbyId));
			_callResultJoinLobby.Set(hAPICall);
		}

		public void LeaveLobby(ulong lobbyId)
		{
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam LeaveLobby: Lobby={lobbyId}");
			}
			SteamMatchmaking.LeaveLobby(new CSteamID(lobbyId));
		}

		public unsafe int ReceiveMessagesOnChannel(int localChannel, int maxMessages, List<SteamNetworkingMessage> messages)
		{
			if (_messageBuffer == null)
			{
				_messageBuffer = new IntPtr[maxMessages];
			}
			if (_messageBuffer.Length < maxMessages)
			{
				Array.Resize(ref _messageBuffer, maxMessages);
			}
			int num = 0;
			if (_messageDataBuffer == null)
			{
				_messageDataBuffer = new byte[4096];
			}
			int num2 = SteamNetworkingMessages.ReceiveMessagesOnChannel(localChannel, _messageBuffer, maxMessages);
			for (int i = 0; i < num2; i++)
			{
				SteamNetworkingMessage_t* ptr = (SteamNetworkingMessage_t*)(void*)_messageBuffer[i];
				CSteamID steamID = ptr->m_identityPeer.GetSteamID();
				int cbSize = ptr->m_cbSize;
				if (num + cbSize > _messageDataBuffer.Length)
				{
					int num3 = _messageDataBuffer.Length;
					while (num + cbSize > num3)
					{
						num3 *= 2;
					}
					Array.Resize(ref _messageDataBuffer, num3);
				}
				ulong gcHandle;
				byte* ptr2 = (byte*)UnsafeUtility.PinGCArrayAndGetDataAddress(_messageDataBuffer, out gcHandle);
				UnsafeUtility.MemCpy(ptr2 + num, (void*)ptr->m_pData, cbSize);
				UnsafeUtility.ReleaseGCObject(gcHandle);
				SteamNetworkingMessage item = new SteamNetworkingMessage((ulong)steamID, new ArraySegment<byte>(_messageDataBuffer, num, cbSize));
				messages.Add(item);
				num += cbSize;
				SteamNetworkingMessage_t.Release(_messageBuffer[i]);
				_messageBuffer[i] = IntPtr.Zero;
			}
			return num2;
		}

		public bool RequestLobbyData(ulong lobbyId)
		{
			bool flag = SteamMatchmaking.RequestLobbyData(new CSteamID(lobbyId));
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam RequestLobbyData: LobbyId={lobbyId}, Result={flag}");
			}
			return flag;
		}

		public void RequestLobbyList(LobbyFilters filters)
		{
			if (filters == null)
			{
				filters = new LobbyFilters();
			}
			if (EnableDebugLogging)
			{
				string newLine = Environment.NewLine;
				Debug.Log("Steam RequestLobbyList:" + newLine + $"  Distance: {filters.Distance}{newLine}" + $"  Max Results: {filters.MaxResults}{newLine}" + $"  Slots Available: {filters.SlotsAvailable}{newLine}" + "  Sorting: " + ((filters.ResultSorting.Count == 0) ? "None" : (newLine + string.Join(newLine, filters.ResultSorting.Select(((string Key, int TargetValue) x) => $"    Key: {x.Key}, Value: {x.TargetValue}")))) + newLine + "  String Filters: " + ((filters.StringFilters.Count == 0) ? "None" : (newLine + string.Join(newLine, filters.StringFilters.Select(((string Key, string Value, LobbyComparisonType ComparisonType) x) => $"    Key: {x.Key}, Value: {x.Value}, Comparison: {x.ComparisonType}")))) + newLine + "  Numeric Filters: " + ((filters.NumericalFilters.Count == 0) ? "None" : (newLine + string.Join(newLine, filters.NumericalFilters.Select(((string Key, int Value, LobbyComparisonType ComparisonType) x) => $"    Key: {x.Key}, Value: {x.Value}, Comparison: {x.ComparisonType}")))) + newLine);
			}
			SteamMatchmaking.AddRequestLobbyListDistanceFilter(ConvertEnum(filters.Distance));
			if (filters.MaxResults > 0)
			{
				SteamMatchmaking.AddRequestLobbyListResultCountFilter(filters.MaxResults);
			}
			if (filters.SlotsAvailable > 1)
			{
				SteamMatchmaking.AddRequestLobbyListFilterSlotsAvailable(filters.SlotsAvailable);
			}
			foreach (var item in filters.ResultSorting)
			{
				SteamMatchmaking.AddRequestLobbyListNearValueFilter(item.Key, item.TargetValue);
			}
			foreach (var stringFilter in filters.StringFilters)
			{
				SteamMatchmaking.AddRequestLobbyListStringFilter(stringFilter.Key, stringFilter.Value, ConvertEnum(stringFilter.ComparisonType));
			}
			foreach (var numericalFilter in filters.NumericalFilters)
			{
				SteamMatchmaking.AddRequestLobbyListNumericalFilter(numericalFilter.Key, numericalFilter.Value, ConvertEnum(numericalFilter.ComparisonType));
			}
			SteamAPICall_t hAPICall = SteamMatchmaking.RequestLobbyList();
			_callResultRequestLobbyList.Set(hAPICall);
		}

		public bool SendLobbyChatMessage(ulong lobbyId, byte[] data, int dataSize)
		{
			bool flag = SteamMatchmaking.SendLobbyChatMsg(new CSteamID(lobbyId), data, dataSize);
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam SendLobbyChatMessage: LobbyId={lobbyId}, MessageSize={dataSize}, Result={flag}");
			}
			return flag;
		}

		public unsafe SendMessageResult SendMessageToUser(ulong userId, ArraySegment<byte> data, SteamNetworkingSendFlags sendFlags, int channel)
		{
			SteamNetworkingIdentity identityRemote = default(SteamNetworkingIdentity);
			identityRemote.SetSteamID64(userId);
			byte[] array = data.Array;
			ulong gcHandle;
			IntPtr pubData = new IntPtr(UnsafeUtility.PinGCArrayAndGetDataAddress(array, out gcHandle));
			pubData += data.Offset;
			EResult result = SteamNetworkingMessages.SendMessageToUser(ref identityRemote, pubData, (uint)data.Count, (int)sendFlags, channel);
			UnsafeUtility.ReleaseGCObject(gcHandle);
			return (SendMessageResult)result;
		}

		public bool SetLobbyData(ulong lobbyId, string key, string value)
		{
			bool flag = SteamMatchmaking.SetLobbyData(new CSteamID(lobbyId), key, value);
			if (EnableDebugLogging)
			{
				Debug.Log(string.Format("Steam SetLobbyData: LobbyId={0}, Key={1}, Value={2}, Result={3}", lobbyId, key ?? "(null)", value ?? "(null)", flag));
			}
			return flag;
		}

		public bool SetLobbyJoinable(ulong lobbyId, bool joinable)
		{
			bool flag = SteamMatchmaking.SetLobbyJoinable(new CSteamID(lobbyId), joinable);
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam SetLobbyJoinable: LobbyId={lobbyId}, Joinable={joinable}, Result={flag}");
			}
			return flag;
		}

		public void SetLobbyMemberData(ulong lobbyId, string key, string value)
		{
			SteamMatchmaking.SetLobbyMemberData(new CSteamID(lobbyId), key, value);
			if (EnableDebugLogging)
			{
				Debug.Log(string.Format("Steam SetLobbyMemberData: LobbyId={0}, Key={1}, Value={2}", lobbyId, key ?? "(null)", value ?? "(null)"));
			}
		}

		public bool SetLobbyMemberLimit(ulong lobbyId, int maxMembers)
		{
			bool flag = SteamMatchmaking.SetLobbyMemberLimit(new CSteamID(lobbyId), maxMembers);
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam SetLobbyMemberLimit: LobbyId={lobbyId}, MaxMembers={maxMembers}, Result={flag}");
			}
			return flag;
		}

		public bool SetLobbyOwner(ulong lobbyId, ulong ownerId)
		{
			bool flag = SteamMatchmaking.SetLobbyOwner(new CSteamID(lobbyId), new CSteamID(ownerId));
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam SetLobbyOwner: LobbyId={lobbyId}, OwnerId={ownerId}, Result={flag}");
			}
			return flag;
		}

		public bool SetLobbyType(ulong lobbyId, LobbyType type)
		{
			bool flag = SteamMatchmaking.SetLobbyType(new CSteamID(lobbyId), ConvertEnum(type));
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam SetLobbyType: LobbyId={lobbyId}, Type={type}, Result={flag}");
			}
			return flag;
		}

		public void SetPlayedWith(ulong userId)
		{
			SteamFriends.SetPlayedWith((CSteamID)userId);
		}

		private static LobbyType ConvertEnum(ELobbyType type)
		{
			return type switch
			{
				ELobbyType.k_ELobbyTypePrivate => LobbyType.Private, 
				ELobbyType.k_ELobbyTypeFriendsOnly => LobbyType.FriendsOnly, 
				ELobbyType.k_ELobbyTypePublic => LobbyType.Public, 
				ELobbyType.k_ELobbyTypeInvisible => LobbyType.Invisible, 
				ELobbyType.k_ELobbyTypePrivateUnique => LobbyType.PrivateUnique, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "ELobbyType", type)), 
			};
		}

		private static ELobbyType ConvertEnum(LobbyType type)
		{
			return type switch
			{
				LobbyType.Private => ELobbyType.k_ELobbyTypePrivate, 
				LobbyType.FriendsOnly => ELobbyType.k_ELobbyTypeFriendsOnly, 
				LobbyType.Public => ELobbyType.k_ELobbyTypePublic, 
				LobbyType.Invisible => ELobbyType.k_ELobbyTypeInvisible, 
				LobbyType.PrivateUnique => ELobbyType.k_ELobbyTypePrivateUnique, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "ELobbyType", type)), 
			};
		}

		private static EChatEntryType ConvertEnum(ChatEntryType type)
		{
			return type switch
			{
				ChatEntryType.Invalid => EChatEntryType.k_EChatEntryTypeInvalid, 
				ChatEntryType.ChatMsg => EChatEntryType.k_EChatEntryTypeChatMsg, 
				ChatEntryType.Typing => EChatEntryType.k_EChatEntryTypeTyping, 
				ChatEntryType.InviteGame => EChatEntryType.k_EChatEntryTypeInviteGame, 
				ChatEntryType.Emote => EChatEntryType.k_EChatEntryTypeEmote, 
				ChatEntryType.LobbyGameStart => EChatEntryType.k_EChatEntryTypeInvalid, 
				ChatEntryType.LeftConversation => EChatEntryType.k_EChatEntryTypeLeftConversation, 
				ChatEntryType.Entered => EChatEntryType.k_EChatEntryTypeEntered, 
				ChatEntryType.WasKicked => EChatEntryType.k_EChatEntryTypeWasKicked, 
				ChatEntryType.WasBanned => EChatEntryType.k_EChatEntryTypeWasBanned, 
				ChatEntryType.Disconnected => EChatEntryType.k_EChatEntryTypeDisconnected, 
				ChatEntryType.HistoricalChat => EChatEntryType.k_EChatEntryTypeHistoricalChat, 
				ChatEntryType.Reserved1 => EChatEntryType.k_EChatEntryTypeInvalid, 
				ChatEntryType.Reserved2 => EChatEntryType.k_EChatEntryTypeInvalid, 
				ChatEntryType.LinkBlocked => EChatEntryType.k_EChatEntryTypeLinkBlocked, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "ChatEntryType", type)), 
			};
		}

		private static ChatEntryType ConvertEnum(EChatEntryType type)
		{
			return type switch
			{
				EChatEntryType.k_EChatEntryTypeInvalid => ChatEntryType.Invalid, 
				EChatEntryType.k_EChatEntryTypeChatMsg => ChatEntryType.ChatMsg, 
				EChatEntryType.k_EChatEntryTypeTyping => ChatEntryType.Typing, 
				EChatEntryType.k_EChatEntryTypeInviteGame => ChatEntryType.InviteGame, 
				EChatEntryType.k_EChatEntryTypeEmote => ChatEntryType.Emote, 
				EChatEntryType.k_EChatEntryTypeLeftConversation => ChatEntryType.LeftConversation, 
				EChatEntryType.k_EChatEntryTypeEntered => ChatEntryType.Entered, 
				EChatEntryType.k_EChatEntryTypeWasKicked => ChatEntryType.WasKicked, 
				EChatEntryType.k_EChatEntryTypeWasBanned => ChatEntryType.WasBanned, 
				EChatEntryType.k_EChatEntryTypeDisconnected => ChatEntryType.Disconnected, 
				EChatEntryType.k_EChatEntryTypeHistoricalChat => ChatEntryType.HistoricalChat, 
				EChatEntryType.k_EChatEntryTypeLinkBlocked => ChatEntryType.LinkBlocked, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "EChatEntryType", type)), 
			};
		}

		private static ELobbyDistanceFilter ConvertEnum(LobbyDistanceFilterType distanceFilterType)
		{
			return distanceFilterType switch
			{
				LobbyDistanceFilterType.Close => ELobbyDistanceFilter.k_ELobbyDistanceFilterClose, 
				LobbyDistanceFilterType.Default => ELobbyDistanceFilter.k_ELobbyDistanceFilterDefault, 
				LobbyDistanceFilterType.Far => ELobbyDistanceFilter.k_ELobbyDistanceFilterFar, 
				LobbyDistanceFilterType.Worldwide => ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "LobbyDistanceFilterType", distanceFilterType)), 
			};
		}

		private static LobbyDistanceFilterType ConvertEnum(ELobbyDistanceFilter distanceFilterType)
		{
			return distanceFilterType switch
			{
				ELobbyDistanceFilter.k_ELobbyDistanceFilterClose => LobbyDistanceFilterType.Close, 
				ELobbyDistanceFilter.k_ELobbyDistanceFilterDefault => LobbyDistanceFilterType.Default, 
				ELobbyDistanceFilter.k_ELobbyDistanceFilterFar => LobbyDistanceFilterType.Far, 
				ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide => LobbyDistanceFilterType.Worldwide, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "ELobbyDistanceFilter", distanceFilterType)), 
			};
		}

		private static ELobbyComparison ConvertEnum(LobbyComparisonType comparisonType)
		{
			return comparisonType switch
			{
				LobbyComparisonType.EqualToOrLessThan => ELobbyComparison.k_ELobbyComparisonEqualToOrLessThan, 
				LobbyComparisonType.LessThan => ELobbyComparison.k_ELobbyComparisonLessThan, 
				LobbyComparisonType.Equal => ELobbyComparison.k_ELobbyComparisonEqual, 
				LobbyComparisonType.GreaterThan => ELobbyComparison.k_ELobbyComparisonGreaterThan, 
				LobbyComparisonType.EqualToOrGreaterThan => ELobbyComparison.k_ELobbyComparisonEqualToOrGreaterThan, 
				LobbyComparisonType.NotEqual => ELobbyComparison.k_ELobbyComparisonNotEqual, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "LobbyComparisonType", comparisonType)), 
			};
		}

		private static LobbyComparisonType ConvertEnum(ELobbyComparison comparisonType)
		{
			return comparisonType switch
			{
				ELobbyComparison.k_ELobbyComparisonEqualToOrLessThan => LobbyComparisonType.EqualToOrLessThan, 
				ELobbyComparison.k_ELobbyComparisonLessThan => LobbyComparisonType.LessThan, 
				ELobbyComparison.k_ELobbyComparisonEqual => LobbyComparisonType.Equal, 
				ELobbyComparison.k_ELobbyComparisonGreaterThan => LobbyComparisonType.GreaterThan, 
				ELobbyComparison.k_ELobbyComparisonEqualToOrGreaterThan => LobbyComparisonType.EqualToOrGreaterThan, 
				ELobbyComparison.k_ELobbyComparisonNotEqual => LobbyComparisonType.NotEqual, 
				_ => throw new NotSupportedException(string.Format("Unsupported {0}: {1}", "ELobbyComparison", comparisonType)), 
			};
		}

		private void ApplyGreaseToSqueakyWheels()
		{
			_callResultCreateLobby.ToString();
			_callResultJoinLobby.ToString();
			_callResultRequestLobbyList.ToString();
			_callbackLobbyChatUpdate.ToString();
			_callbackLobbyDataUpdate.ToString();
			_callbackLobbyChatMessage.ToString();
			_callbackLobbyJoinRequested.ToString();
			_callbackNetworkingMessagesSessionFailed.ToString();
			_callbackNetworkingMessagesSessionRequest.ToString();
		}

		private void GetLobbyMembers(ulong lobbyId, int count, IList<LobbyMemberInfo> members)
		{
			for (int i = 0; i < count; i++)
			{
				CSteamID lobbyMemberByIndex = SteamMatchmaking.GetLobbyMemberByIndex(new CSteamID(lobbyId), i);
				string friendPersonaName = SteamFriends.GetFriendPersonaName(lobbyMemberByIndex);
				members.Add(new LobbyMemberInfo(lobbyMemberByIndex.m_SteamID, friendPersonaName));
			}
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam GetLobbyMembers: LobbyId={lobbyId}, Count={count}{Environment.NewLine}" + string.Join(Environment.NewLine, members.Select((LobbyMemberInfo x) => $"  {x.UserId}: {x.PersonaName}")));
			}
		}

		private void OnLobbyChatMessageReceived(LobbyChatMsg_t data)
		{
			byte[] lobbyChatMessageReceivedBuffer = _lobbyChatMessageReceivedBuffer;
			CSteamID pSteamIDUser;
			EChatEntryType peChatEntryType;
			int lobbyChatEntry = SteamMatchmaking.GetLobbyChatEntry(new CSteamID(data.m_ulSteamIDLobby), (int)data.m_iChatID, out pSteamIDUser, lobbyChatMessageReceivedBuffer, lobbyChatMessageReceivedBuffer.Length, out peChatEntryType);
			byte[] messageData = new ArraySegment<byte>(lobbyChatMessageReceivedBuffer, 0, lobbyChatEntry).ToArray();
			ChatEntryType chatEntryType = ConvertEnum(peChatEntryType);
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam LobbyChatMessageReceived: LobbyId={data.m_ulSteamIDLobby}, UserId={data.m_ulSteamIDUser}, Type={chatEntryType}, MessageSize={lobbyChatEntry}");
			}
			this.LobbyChatMessageReceived?.Invoke(this, new LobbyChatMessageEventArgs(data.m_ulSteamIDLobby, data.m_ulSteamIDUser, chatEntryType, messageData));
		}

		private void OnLobbyChatUpdate(LobbyChatUpdate_t data)
		{
			ChatMemberStateChangeType rgfChatMemberStateChange = (ChatMemberStateChangeType)data.m_rgfChatMemberStateChange;
			if (EnableDebugLogging)
			{
				Debug.Log("Steam LobbyChatUpdate: " + $"Lobby={data.m_ulSteamIDLobby}, " + $"User={data.m_ulSteamIDUserChanged}, " + $"ChangedByUser={data.m_ulSteamIDMakingChange}, " + $"State={rgfChatMemberStateChange} ({data.m_rgfChatMemberStateChange})");
			}
			this.LobbyChatUpdate?.Invoke(this, new LobbyChatUpdateEventArgs(data.m_ulSteamIDLobby, data.m_ulSteamIDUserChanged, data.m_ulSteamIDMakingChange, rgfChatMemberStateChange));
		}

		private void OnLobbyCreatedResult(LobbyCreated_t result, bool failure)
		{
			if (result.m_eResult != EResult.k_EResultOK || failure)
			{
				Debug.LogError($"Failed to create a game lobby. Failure: {failure}, Result: {result.m_eResult}");
			}
			CreateLobbyResultType createLobbyResultType = (CreateLobbyResultType)((failure && result.m_eResult == EResult.k_EResultOK) ? EResult.k_EResultFail : result.m_eResult);
			if (EnableDebugLogging)
			{
				Debug.Log("Steam LobbyCreated: " + $"Lobby={result.m_ulSteamIDLobby}, " + $"Result={result.m_eResult}, " + $"ResultType={createLobbyResultType}");
			}
			this.CreateLobbyResult?.Invoke(this, new CreateLobbyResultEventArgs(result.m_ulSteamIDLobby, createLobbyResultType));
		}

		private void OnLobbyDataUpdate(LobbyDataUpdate_t data)
		{
			bool flag = data.m_ulSteamIDLobby != data.m_ulSteamIDMember;
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam LobbyDataUpdate: LobbyId={data.m_ulSteamIDLobby}, {(flag ? $"UserId={data.m_ulSteamIDMember}, " : string.Empty)}Success={data.m_bSuccess}");
			}
			bool success = data.m_bSuccess == 1;
			if (flag)
			{
				this.LobbyMemberDataUpdate?.Invoke(this, new LobbyMemberDataUpdateEventArgs(data.m_ulSteamIDLobby, data.m_ulSteamIDMember, success));
			}
			else
			{
				this.LobbyDataUpdate?.Invoke(this, new LobbyDataUpdateEventArgs(data.m_ulSteamIDLobby, success));
			}
		}

		private void OnLobbyEnterResult(LobbyEnter_t result, bool failure)
		{
			JoinLobbyResultType joinLobbyResultType = JoinLobbyResultType.Ok;
			if (failure || result.m_EChatRoomEnterResponse != 1)
			{
				Debug.LogError($"Failed to join a game lobby. Failure: {failure}, Locked: {result.m_bLocked}, ChatRoomEnterResponse: {result.m_EChatRoomEnterResponse}");
				joinLobbyResultType = JoinLobbyResultType.Fail;
			}
			if (EnableDebugLogging)
			{
				Debug.Log("Steam LobbyEnter: " + $"Lobby={result.m_ulSteamIDLobby}, " + $"Locked={result.m_bLocked}, " + $"ChatRoomEnterResponse={result.m_EChatRoomEnterResponse}, " + $"ChatPermissions={result.m_rgfChatPermissions}, " + $"ResultType={joinLobbyResultType}");
			}
			this.JoinLobbyResult?.Invoke(this, new JoinLobbyResultEventArgs(result.m_ulSteamIDLobby, result.m_bLocked, joinLobbyResultType));
		}

		private void OnLobbyJoinRequested(GameLobbyJoinRequested_t data)
		{
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam GameLobbyJoinRequested: LobbyId={data.m_steamIDLobby}, FriendId={data.m_steamIDFriend}");
			}
			this.JoinLobbyRequested?.Invoke(this, new JoinLobbyRequestedEventArgs(data.m_steamIDLobby.m_SteamID, data.m_steamIDFriend.m_SteamID));
		}

		private void OnNetworkingMessagesSessionFailed(SteamNetworkingMessagesSessionFailed_t data)
		{
			ulong steamID = data.m_info.m_identityRemote.GetSteamID64();
			SteamNetworkingConnectionState eState = (SteamNetworkingConnectionState)data.m_info.m_eState;
			if (EnableDebugLoggingForNetworkMessages)
			{
				Debug.Log($"Steam SteamNetworkingMessagesSessionFailed: SteamId={steamID}, State={eState}");
			}
			this.NetworkingMessagesSessionFailed?.Invoke(this, new NetworkingMessagesSessionFailedEventArgs(steamID, eState));
		}

		private void OnNetworkingMessagesSessionRequest(SteamNetworkingMessagesSessionRequest_t data)
		{
			ulong steamID = data.m_identityRemote.GetSteamID64();
			if (EnableDebugLoggingForNetworkMessages)
			{
				Debug.Log($"Steam OnNetworkingMessagesSessionRequest: SteamId={steamID}");
			}
			this.NetworkingMessagesSessionRequest?.Invoke(this, new NetworkingMessagesSessionRequestEventArgs(steamID));
		}

		private void OnRequestLobbyListResult(LobbyMatchList_t result, bool failure)
		{
			int num = (int)result.m_nLobbiesMatching;
			if (failure)
			{
				Debug.LogError("Steam failed to retrieve a list of multiplayer lobbies.");
				num = 0;
			}
			List<ulong> list = new List<ulong>(num);
			for (int i = 0; i < num; i++)
			{
				CSteamID lobbyByIndex = SteamMatchmaking.GetLobbyByIndex(i);
				if (lobbyByIndex.IsValid())
				{
					list.Add(lobbyByIndex.m_SteamID);
				}
			}
			if (EnableDebugLogging)
			{
				Debug.Log($"Steam RequestLobbyList: Count={result.m_nLobbiesMatching}, Failure={failure} {Environment.NewLine}{string.Join(Environment.NewLine, list)}");
			}
			this.RequestLobbyListResult?.Invoke(this, new RequestLobbyListResultEventArgs(list, !failure));
		}
	}
}
