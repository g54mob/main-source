using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Networking.Transport;

public class DummyNetworking : NetworkingInterface
{
	public ServerConnectionInfo CurrentSession { get; }

	public bool isInitialized { get; }

	public bool ConnectedToDedicatedServer { get; }

	public bool CanSendInvites => true;

	public Platform AllowedPlatforms { get; set; }

	public int MaxPlayersCount { get; }

	public bool Initialize(Action<NetworkEndpoint> disconnectCallback, Action<NetworkEndpoint, int, byte[]> sideChannelCallback, bool useDirectConnection, Platform currentPlatform)
	{
		return false;
	}

	public void Deinitialize()
	{
	}

	NetworkEndpoint NetworkingInterface.GetLocalEndpoint()
	{
		return default(NetworkEndpoint);
	}

	public bool IsValidConnectionAddress(ServerConnectionInfo connectionInfo)
	{
		return true;
	}

	public bool StartListening()
	{
		return false;
	}

	public void StopListening()
	{
	}

	public bool StartSession(ServerConnectionInfo connectionInfo, int maxNumberPlayers, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
		return false;
	}

	public void StopSession()
	{
	}

	public void UpdateSession(string session)
	{
	}

	public void RecreateGameId(Action<bool> restartSessionCallback)
	{
	}

	public void Connect(ServerConnectionInfo connectionInfo, Action<NetworkEndpoint?> callback)
	{
		callback?.Invoke(null);
	}

	public void Disconnect()
	{
	}

	public void Update()
	{
	}

	public void SendMessages(NativeQueue<QueuedSendMessage> messages)
	{
	}

	public void ReceiveMessages(NativeQueue<QueuedSendMessage> messages)
	{
	}

	public void SendSideChannelMessage(NetworkEndpoint dest, int channel, byte[] packet)
	{
		throw new NotImplementedException();
	}

	public string GetConnectionId(NetworkEndpoint endpoint)
	{
		throw new NotImplementedException();
	}

	public void SetAdmin(NetworkEndpoint endpoint, ref PlayerAdminEntry adminEntry)
	{
	}

	public void InitializeBan(PlayerBanEntry playerBanEntry)
	{
	}

	public void BanPlayer(NetworkEndpoint endpoint, ref PlayerBanEntry playerBanEntry)
	{
	}

	public void UnbanPlayer(PlayerBanEntry playerBanEntry)
	{
	}

	public bool EntryMatchesEndpoint(PlayerBanEntry entry, NetworkEndpoint endpoint)
	{
		return false;
	}

	public bool EntryMatchesEndpoint(PlayerAdminEntry entry, NetworkEndpoint endpoint)
	{
		return false;
	}

	public void StartSessionInvitationFlow()
	{
		Manager.menu.PushMenu(RadicalMenu.MenuType.INVITE_FRIENDS);
	}

	public void SendSessionInvitations(List<PlatformUserID> invitees, Action<bool> callback)
	{
	}

	public bool CheckSessionValidity(string sessionId)
	{
		return true;
	}

	public int GetPing()
	{
		return 0;
	}
}
