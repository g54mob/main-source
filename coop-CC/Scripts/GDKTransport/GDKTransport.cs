using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aggro.Core;
using Mirror;
using PlayFab.MultiplayerModels;
using PlayFab.Party;
using UnityEngine;

public class GDKTransport : Transport
{
	public static int NextConnectionId = 1;

	private static PlayFabPlayer[] reusablePlayFabPlayerSendTarget = new PlayFabPlayer[1];

	public bool ClientConnectedStatus { get; private set; }

	public bool ServerConnectedStatus { get; private set; }

	public Dictionary<int, PlayFabPlayer> ConnectionIdToPlayFabPlayer { get; private set; } = new Dictionary<int, PlayFabPlayer>();

	public Dictionary<string, int> PlayFabPlayerEntityKeyToConnectionId { get; private set; } = new Dictionary<string, int>();

	private HashSet<string> PlayersEntityKeysThatArePendingConnectionFinalization { get; set; } = new HashSet<string>();

	private PlayFabMultiplayerManager multiplayerManager { get; set; }

	private GameCoreManager gameCoreManager { get; set; }

	protected virtual void Awake()
	{
		gameCoreManager = GameCoreManager.GetOrCreateManager();
		multiplayerManager = PlayFabMultiplayerManager.Get();
	}

	protected virtual void OnDisable()
	{
		HandlePlayFabCallbacks(enabled: false);
	}

	public override bool Available()
	{
		return true;
	}

	public override async void ClientConnect(string address)
	{
		Debug.Log($"[{Time.frameCount}] [GDKTransport] [ClientConnect] Client is trying to connect to {address}.");
		await Task.Yield();
		ClientConnectedStatus = true;
		HandlePlayFabCallbacks(enabled: true);
		OnClientConnected?.Invoke();
	}

	public override bool ClientConnected()
	{
		return ClientConnectedStatus;
	}

	public override void ClientDisconnect()
	{
		ServerConnectedStatus = false;
		ClientConnectedStatus = false;
		ResetTransport();
		OnClientDisconnected?.Invoke();
	}

	public override void ClientSend(ArraySegment<byte> segment, int channelId = 0)
	{
		byte[] buffer = segment.ToArray();
		if (!gameCoreManager.PlayFabLobbyData.HostSet)
		{
			PlayFab.MultiplayerModels.EntityKey key = gameCoreManager.PlayFabLobbyData.HostKey;
			gameCoreManager.PlayFabLobbyData.HostList[0] = multiplayerManager.RemotePlayers.First((PlayFabPlayer x) => x.EntityKey.Id == key.Id);
			gameCoreManager.PlayFabLobbyData.HostSet = true;
		}
		DeliveryOption deliveryOption = ((channelId != 1) ? DeliveryOption.Guaranteed : DeliveryOption.BestEffort);
		multiplayerManager.SendDataMessage(buffer, gameCoreManager.PlayFabLobbyData.HostList, deliveryOption);
		OnClientDataSent?.Invoke(segment, channelId);
	}

	public override int GetMaxPacketSize(int channelId = 0)
	{
		return 65535;
	}

	public override bool ServerActive()
	{
		return ServerConnectedStatus;
	}

	public override void ServerDisconnect(int connectionId)
	{
		OnServerDisconnected?.Invoke(connectionId);
	}

	public override string ServerGetClientAddress(int connectionId)
	{
		return string.Empty;
	}

	public override void ServerSend(int connectionId, ArraySegment<byte> segment, int channelId = 0)
	{
		if (!ConnectionIdToPlayFabPlayer.TryGetValue(connectionId, out var value))
		{
			Debug.LogError($"[{Time.frameCount}] [GDKTransport] [ServerSend] Failed to get a player with connection id {connectionId}.");
			return;
		}
		byte[] buffer = segment.Slice(segment.Offset, segment.Count).ToArray();
		DeliveryOption deliveryOption = ((channelId != 1) ? DeliveryOption.Guaranteed : DeliveryOption.BestEffort);
		reusablePlayFabPlayerSendTarget[0] = value;
		multiplayerManager.SendDataMessage(buffer, reusablePlayFabPlayerSendTarget, deliveryOption);
		OnServerDataSent?.Invoke(connectionId, segment, channelId);
	}

	public override void ServerStart()
	{
		Debug.Log($"[{Time.frameCount}] [GDKTransport] [ServerStart] Server start.");
		ServerConnectedStatus = true;
		HandlePlayFabCallbacks(enabled: true);
	}

	public override void ServerStop()
	{
		ResetTransport();
		Shutdown();
	}

	public override Uri ServerUri()
	{
		return null;
	}

	public override void Shutdown()
	{
		ResetTransport();
	}

	protected virtual void _OnRemotePlayerJoined(object sender, PlayFabPlayer player)
	{
		if (!gameCoreManager.PlayFabLobbyData.LobbyJoinable)
		{
			Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnRemotePlayerJoined] A remote player attempted to join, but the lobby isn't joinable. EntityKey ID is '{player.EntityKey.Id}'.");
		}
		else if (!(player.EntityKey.Id == GameCoreManager.GetOrCreateManager().PlayFabConnectionData.ClientEntityKey.Id) && ServerConnectedStatus)
		{
			int num = RecognizedPlayFabPlayer(player);
			Debug.Log($"[{Time.frameCount}] [GDKTransport ] [_OnRemotePlayerJoined] Remote player joined, assigning connectionId {num}. Waiting for follow up message to establish connectivity.");
			PlayersEntityKeysThatArePendingConnectionFinalization.Add(player.EntityKey.Id);
		}
	}

	protected virtual void _OnRemotePlayerLeft(object sender, PlayFabPlayer player)
	{
		if ((!ClientConnectedStatus && !ServerConnectedStatus) || player.EntityKey.Id == gameCoreManager.PlayFabConnectionData.ClientEntityKey.Id)
		{
			return;
		}
		gameCoreManager.PlayFabLobbyData.CurrentMemberCount--;
		Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnRemotePlayerJoined] After the remote player left, we are tracking {gameCoreManager.PlayFabLobbyData.CurrentMemberCount}");
		Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnRemotePlayerLeft] Player {player.EntityKey.Id} left");
		if (player.EntityKey.Id == gameCoreManager.PlayFabLobbyData.HostKey.Id)
		{
			Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnRemotePlayerLeft] The host left the session. Disconnecting client.");
			Platform.LeaveLobby();
			ClientDisconnect();
			return;
		}
		(Platform.GetPlatformInterface() as GameCorePlatform)?.UpdateActivityFromLobby(updateRecentPlayers: false);
		if (PlayFabPlayerEntityKeyToConnectionId.TryGetValue(player.EntityKey.Id, out var value))
		{
			Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnRemotePlayerLeft] Disconnecting connection to connectionId {value}.");
			PlayFabPlayerEntityKeyToConnectionId.Remove(player.EntityKey.Id);
			ConnectionIdToPlayFabPlayer.Remove(value);
			OnServerDisconnected?.Invoke(value);
		}
		else
		{
			Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnRemotePlayerLeft] A player has left the PlayFab Network, but did not have an assigned connection id. '{player.EntityKey.Id}'");
		}
	}

	protected virtual async void _OnDataMessageReceived(object sender, PlayFabPlayer from, byte[] buffer)
	{
		if (!ShouldRecognizePlayFabPlayer(from, gameCoreManager.PlayFabLobbyData.LobbyJoinable, out var connectionId))
		{
			Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnDataMessageReceived] A player sent a data message, but they are not recognized and the lobby is currently not joinable. Ignoring message. Letting this message process would result in a connection error. '{from.EntityKey.Id}'");
			return;
		}
		ArraySegment<byte> segmentedMessage = new ArraySegment<byte>(buffer, 0, buffer.Length);
		if (ServerConnectedStatus)
		{
			if (PlayersEntityKeysThatArePendingConnectionFinalization.Contains(from.EntityKey.Id))
			{
				Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnDataMessageReceived] Received message from a client that is pending connection finalization. Establishing connection now!");
				PlayersEntityKeysThatArePendingConnectionFinalization.Remove(from.EntityKey.Id);
				OnServerConnectedWithAddress(connectionId, from.EntityKey.Id);
				await Task.Yield();
			}
			OnServerDataReceived?.Invoke(connectionId, segmentedMessage, 0);
		}
		else
		{
			OnClientDataReceived?.Invoke(segmentedMessage, 0);
		}
	}

	protected virtual void _OnError(object sender, PlayFabMultiplayerManagerErrorArgs arg)
	{
		if ((ClientConnectedStatus || ServerConnectedStatus) && arg.Code != 61)
		{
			Debug.Log($"[{Time.frameCount}] [GDKTransport] [_OnError] Error received, exiting lobby; '{arg.Type}'; '{arg.Message}'");
			if (ServerConnectedStatus)
			{
				OnServerError?.Invoke(0, ToTransportError(arg.Type), arg.Message);
				NetworkManager.singleton.StopHost();
			}
			else
			{
				OnClientError?.Invoke(ToTransportError(arg.Type), arg.Message);
				NetworkManager.singleton.StopClient();
			}
		}
	}

	public static TransportError ToTransportError(PlayFabMultiplayerManagerErrorType error)
	{
		_ = 4;
		return TransportError.ConnectionClosed;
	}

	protected virtual int RecognizedPlayFabPlayer(PlayFabPlayer toRecognize)
	{
		if (PlayFabPlayerEntityKeyToConnectionId.TryGetValue(toRecognize.EntityKey.Id, out var value))
		{
			return value;
		}
		int num = NextConnectionId++;
		ConnectionIdToPlayFabPlayer.TryAdd(num, toRecognize);
		PlayFabPlayerEntityKeyToConnectionId.TryAdd(toRecognize.EntityKey.Id, num);
		Debug.Log($"[{Time.frameCount}] [GDKTransport] [RecognizedPlayFabPlayer] Current server status is {ServerConnectedStatus}. " + "Remote player joined network. " + $"Assigned id {num} to them. Their entity id is '{toRecognize.EntityKey.Id}'.");
		gameCoreManager.PlayFabLobbyData.CurrentMemberCount++;
		Debug.Log($"[{Time.frameCount}] [GDKTransport] [RecognizedPlayFabPlayer] After the remote player joined, we are tracking {gameCoreManager.PlayFabLobbyData.CurrentMemberCount}");
		(Platform.GetPlatformInterface() as GameCorePlatform)?.UpdateActivityFromLobby(updateRecentPlayers: true);
		return num;
	}

	protected virtual bool ShouldRecognizePlayFabPlayer(PlayFabPlayer toRecognize, bool lobbyJoinable, out int connectionId)
	{
		if (PlayFabPlayerEntityKeyToConnectionId.TryGetValue(toRecognize.EntityKey.Id, out connectionId))
		{
			return true;
		}
		if (!lobbyJoinable)
		{
			connectionId = -1;
			return false;
		}
		connectionId = RecognizedPlayFabPlayer(toRecognize);
		return true;
	}

	public void ResetTransport()
	{
		Debug.Log($"[{Time.frameCount}] [GDKTransport] [ResetTransport] Resetting transport.");
		gameCoreManager.PlayFabLobbyData.LobbyJoinable = true;
		ConnectionIdToPlayFabPlayer.Clear();
		PlayFabPlayerEntityKeyToConnectionId.Clear();
		PlayersEntityKeysThatArePendingConnectionFinalization.Clear();
		ServerConnectedStatus = false;
		ClientConnectedStatus = false;
		HandlePlayFabCallbacks(enabled: false);
	}

	public void HandlePlayFabCallbacks(bool enabled)
	{
		if (enabled)
		{
			multiplayerManager.OnRemotePlayerJoined += _OnRemotePlayerJoined;
			multiplayerManager.OnRemotePlayerLeft += _OnRemotePlayerLeft;
			multiplayerManager.OnDataMessageReceived += _OnDataMessageReceived;
			multiplayerManager.OnError += _OnError;
		}
		else
		{
			multiplayerManager.OnRemotePlayerJoined -= _OnRemotePlayerJoined;
			multiplayerManager.OnRemotePlayerLeft -= _OnRemotePlayerLeft;
			multiplayerManager.OnDataMessageReceived -= _OnDataMessageReceived;
			multiplayerManager.OnError -= _OnError;
		}
	}
}
