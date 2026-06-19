using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Networking.Transport;

public interface NetworkingInterface
{
	ServerConnectionInfo CurrentSession { get; }

	bool isInitialized { get; }

	bool ConnectedToDedicatedServer { get; }

	bool CanSendInvites => true;

	Platform AllowedPlatforms { get; }

	int MaxPlayersCount { get; }

	bool Initialize(Action<NetworkEndpoint> disconnectCallback, Action<NetworkEndpoint, int, byte[]> sideChannelCallback, bool useDirectConnection, Platform currentPlatform);

	void Deinitialize();

	NetworkEndpoint GetLocalEndpoint();

	bool IsValidConnectionAddress(ServerConnectionInfo connectionInfo);

	bool StartListening();

	void StopListening();

	bool StartSession(ServerConnectionInfo connectionInfo, int maxNumberPlayers, Action<bool> callback);

	void StopSession();

	void UpdateSession(string session);

	void UpdateSession(string session, int maxPlayerCount)
	{
		UpdateSession(session);
	}

	void RecreateGameId(Action<bool> restartSessionCallback);

	void Connect(ServerConnectionInfo connectionInfo, Action<NetworkEndpoint?> callback);

	void Disconnect();

	void Update();

	void SendMessages(NativeQueue<QueuedSendMessage> messages);

	void ReceiveMessages(NativeQueue<QueuedSendMessage> messages);

	void SendSideChannelMessage(NetworkEndpoint dest, int channel, byte[] packet);

	string GetConnectionId(NetworkEndpoint endpoint);

	void SetAdmin(NetworkEndpoint endpoint, ref PlayerAdminEntry adminEntry);

	void InitializeBan(PlayerBanEntry playerBanEntry);

	void BanPlayer(NetworkEndpoint endpoint, ref PlayerBanEntry playerBanEntry);

	void UnbanPlayer(PlayerBanEntry playerBanEntry);

	bool EntryMatchesEndpoint(PlayerBanEntry entry, NetworkEndpoint endpoint);

	bool EntryMatchesEndpoint(PlayerAdminEntry entry, NetworkEndpoint endpoint);

	void StartSessionInvitationFlow();

	void SendSessionInvitations(List<PlatformUserID> invitees, Action<bool> callback);

	bool CheckSessionValidity(string sessionId);

	int GetPing();
}
