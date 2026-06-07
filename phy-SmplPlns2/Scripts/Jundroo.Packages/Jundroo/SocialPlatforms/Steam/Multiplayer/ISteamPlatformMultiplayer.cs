using System;
using System.Collections.Generic;
using Jundroo.SocialPlatforms.Steam.Multiplayer.Events;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer
{
	public interface ISteamPlatformMultiplayer
	{
		event EventHandler<CreateLobbyResultEventArgs> CreateLobbyResult;

		event EventHandler<JoinLobbyRequestedEventArgs> JoinLobbyRequested;

		event EventHandler<JoinLobbyResultEventArgs> JoinLobbyResult;

		event EventHandler<LobbyChatMessageEventArgs> LobbyChatMessageReceived;

		event EventHandler<LobbyChatUpdateEventArgs> LobbyChatUpdate;

		event EventHandler<LobbyDataUpdateEventArgs> LobbyDataUpdate;

		event EventHandler<LobbyMemberDataUpdateEventArgs> LobbyMemberDataUpdate;

		event EventHandler<NetworkingMessagesSessionFailedEventArgs> NetworkingMessagesSessionFailed;

		event EventHandler<NetworkingMessagesSessionRequestEventArgs> NetworkingMessagesSessionRequest;

		event EventHandler<RequestLobbyListResultEventArgs> RequestLobbyListResult;

		bool AcceptSessionWithUser(ulong userId);

		void ActivateGameOverlayInviteDialog(ulong lobbyId);

		bool CloseSessionWithUser(ulong userId);

		void CreateLobby(LobbyType type, int maxMembers);

		bool DeleteLobbyData(ulong lobbyId, string key);

		int EstimatePingTimeFromLocalHost(string pingLocation);

		ulong? GetCurrentLobbyOfFriend(ulong friendId);

		string GetLobbyData(ulong lobbyId, string key);

		void GetLobbyData(ulong lobbyId, IDictionary<string, string> lobbyData);

		Dictionary<string, string> GetLobbyData(ulong lobbyId);

		bool GetLobbyDataByIndex(ulong lobbyId, int index, out string key, out string value, int? keyBufferSize = null, int? valueBufferSize = null);

		int GetLobbyDataCount(ulong lobbyId);

		string GetLobbyMemberData(ulong lobbyId, ulong userId, string key);

		int GetLobbyMemberLimit(ulong lobbyId);

		List<LobbyMemberInfo> GetLobbyMembers(ulong lobbyId);

		void GetLobbyMembers(ulong lobbyId, IList<LobbyMemberInfo> members);

		ulong GetLobbyOwner(ulong lobbyId);

		string GetLocalPingLocation();

		int GetNumLobbyMembers(ulong lobbyId);

		void JoinLobby(ulong lobbyId);

		void LeaveLobby(ulong lobbyId);

		int ReceiveMessagesOnChannel(int localChannel, int maxMessages, List<SteamNetworkingMessage> messages);

		bool RequestLobbyData(ulong lobbyId);

		void RequestLobbyList(LobbyFilters filters);

		bool SendLobbyChatMessage(ulong lobbyId, byte[] data, int dataSize);

		SendMessageResult SendMessageToUser(ulong userId, ArraySegment<byte> data, SteamNetworkingSendFlags sendFlags, int channel);

		bool SetLobbyData(ulong lobbyId, string key, string value);

		bool SetLobbyJoinable(ulong lobbyId, bool joinable);

		void SetLobbyMemberData(ulong lobbyId, string key, string value);

		bool SetLobbyMemberLimit(ulong lobbyId, int maxMembers);

		bool SetLobbyOwner(ulong lobbyId, ulong ownerId);

		bool SetLobbyType(ulong lobbyId, LobbyType type);

		void SetPlayedWith(ulong userId);
	}
}
