using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pug.Platform;
using Steamworks;
using Steamworks.Data;
using Steamworks.ServerList;
using UnityEngine;

public class SteamNetworkSubset : NetworkSubsetBase
{
	private SteamId serverId;

	public override SteamId MySteamID => SteamClient.SteamId;

	public override bool UsesDirectConnection()
	{
		return false;
	}

	public override bool ConnectedToDedicatedServer(ServerConnectionInfo session)
	{
		if (session.IsValid() && session.GameID != null)
		{
			return session.GameID.Length >= 15;
		}
		return false;
	}

	public override bool IsUserValid(SteamId steamId)
	{
		return steamId.IsValid;
	}

	public override async Task<Pug.Platform.SteamNetworking.ConnectResult> Connect(ServerConnectionInfo connectionInfo, CancellationToken cancellationToken)
	{
		Pug.Platform.SteamNetworking.ConnectResult result = default(Pug.Platform.SteamNetworking.ConnectResult);
		string gameID = connectionInfo.GameID;
		if (gameID.Length < 6)
		{
			result.FailReason = "Error/GameNotFound";
			return result;
		}
		bool flag = NetworkSubsetBase.IsServer(gameID);
		if (gameID.Length < (flag ? 15 : 14))
		{
			result.FailReason = "Error/GameNotFound";
			return result;
		}
		string searchId = NetworkSubsetBase.SearchIdFromSession(gameID);
		string passwordFromSession = GetPasswordFromSession(gameID);
		result = ((!flag) ? (await ConnectToClient(searchId, passwordFromSession, cancellationToken)) : (await ConnectToServer(searchId, cancellationToken)));
		result.NetworkEndPoint = EndPointFromSteamId(serverId);
		return result;
	}

	private async Task<Pug.Platform.SteamNetworking.ConnectResult> ConnectToServer(string searchId, CancellationToken cancellationToken)
	{
		Pug.Platform.SteamNetworking.ConnectResult result = default(Pug.Platform.SteamNetworking.ConnectResult);
		using Internet serverList = new Internet();
		using LocalNetwork localServerList = new LocalNetwork();
		serverList.AddFilter("gametagsand", searchId);
		Task<bool> query = serverList.RunQueryAsync();
		Task<bool> localQuery = localServerList.RunQueryAsync();
		await Task.WhenAny(query, Task.Delay(-1, cancellationToken));
		await Task.WhenAny(localQuery, Task.Delay(-1, cancellationToken));
		if (cancellationToken.IsCancellationRequested)
		{
			Debug.Log("connect: server query canceled");
			result.FailReason = "Error/ConnectionClose";
			return result;
		}
		if (!query.IsCompleted || !localQuery.IsCompleted)
		{
			Debug.Log("connect: server search canceled");
			return result;
		}
		bool result2 = query.Result;
		bool result3 = localQuery.Result;
		if (!result2)
		{
			Debug.Log("Internet search for " + searchId + " failed");
		}
		if (!result3)
		{
			Debug.Log("LAN search for " + searchId + " failed");
		}
		ServerInfo? serverInfo = null;
		foreach (ServerInfo item in localServerList.Responsive)
		{
			if (item.Tags != null && item.Tags.Contains(searchId))
			{
				SteamNetworkingUtils.AllowWithoutAuth = 1;
				Debug.Log("Found matching responsive local server");
				serverInfo = item;
				break;
			}
			Debug.Log($"Found non-matching responsive local server {item.SteamId}:{item.TagString}");
		}
		if (!serverInfo.HasValue)
		{
			foreach (ServerInfo item2 in localServerList.Unresponsive)
			{
				if (item2.Tags != null && item2.Tags.Contains(searchId))
				{
					SteamNetworkingUtils.AllowWithoutAuth = 1;
					Debug.Log("Found matching unresponsive local server");
					serverInfo = item2;
					break;
				}
				Debug.Log($"Found non-matching unresponsive local server {item2.SteamId}:{item2.TagString}");
			}
		}
		if (!serverInfo.HasValue)
		{
			if (serverList.Responsive.Count != 0)
			{
				Debug.Log("Found responsive internet server");
				serverInfo = serverList.Responsive[0];
			}
			else
			{
				if (serverList.Unresponsive.Count == 0)
				{
					Debug.Log("Game server not found when searching for id " + searchId);
					result.FailReason = "Error/GameNotFound";
					return result;
				}
				Debug.Log("Found unresponsive internet server");
				serverInfo = serverList.Unresponsive[0];
			}
		}
		Debug.Log("Connecting to server " + serverInfo.Value.Name);
		serverId = serverInfo.Value.SteamId;
		serverAddress = NetAddress.From(serverInfo.Value.Address, (ushort)serverInfo.Value.ConnectionPort);
		return result;
	}

	private async Task<Pug.Platform.SteamNetworking.ConnectResult> ConnectToClient(string searchId, string password, CancellationToken cancellationToken)
	{
		Pug.Platform.SteamNetworking.ConnectResult result = default(Pug.Platform.SteamNetworking.ConnectResult);
		SteamId lobbyId = LobbyIdFromSession(searchId);
		Task<Lobby?> joinLobbyTask = SteamMatchmaking.JoinLobbyAsync(lobbyId);
		await Task.WhenAny(joinLobbyTask, Task.Delay(-1, cancellationToken));
		if (cancellationToken.IsCancellationRequested)
		{
			joinLobbyTask.ContinueWith(delegate(Task<Lobby?> task)
			{
				task.Result?.Leave();
			});
			Debug.Log("connect: join lobby canceled");
			result.FailReason = "Error/ConnectionClose";
			return result;
		}
		if (!joinLobbyTask.Result.HasValue)
		{
			Debug.LogError("Failed to join lobby");
			result.FailReason = "Error/GameNotFound";
			return result;
		}
		result.Lobby = joinLobbyTask.Result.Value;
		using HMACSHA256 hMACSHA = new HMACSHA256(Encoding.UTF8.GetBytes(password));
		byte[] bytes = Encoding.UTF8.GetBytes(MySteamID.ToString());
		string value = Convert.ToBase64String(hMACSHA.ComputeHash(bytes));
		result.Lobby.SetMemberData("hmac", value);
		SetAuthenticated(isTrue: true);
		uint ip = 0u;
		ushort port = 0;
		if (!result.Lobby.GetGameServer(ref ip, ref port, ref serverId))
		{
			Debug.LogError("Couldn't get game server from lobby");
			result.FailReason = "Error/GameNotFound";
			return result;
		}
		return result;
	}

	private SteamId LobbyIdFromSession(string session)
	{
		SteamId result = 109775240917155840uL;
		string text = session.Substring(0, 6);
		char[] sessionIdCharacterPool = NetworkingManager.sessionIdCharacterPool;
		uint num = 0u;
		for (int num2 = text.Length - 1; num2 >= 0; num2--)
		{
			num *= (uint)sessionIdCharacterPool.Length;
			for (uint num3 = 0u; num3 < (uint)sessionIdCharacterPool.Length; num3++)
			{
				if (sessionIdCharacterPool[num3] == text[num2])
				{
					num += num3;
					break;
				}
			}
		}
		result.Value |= num;
		return result;
	}

	public override ConnectionManager TryConnect(IConnectionManager iConnectionManager, ref Pug.Platform.SteamNetworking.ConnectResult result)
	{
		if (serverAddress.Port != 0 && !serverAddress.IsFakeIPv4)
		{
			Debug.Log($"Trying to connect to {serverAddress}");
			return SteamNetworkingSockets.ConnectNormal(serverAddress, iConnectionManager);
		}
		if (!serverId.IsValid)
		{
			Debug.LogError("Couldn't get address to connect to");
			result.FailReason = "Error/GameNotFound";
			return null;
		}
		Debug.Log($"Trying to connect to userid:{serverId}");
		return SteamNetworkingSockets.ConnectRelay(serverId, 0, iConnectionManager);
	}

	public override byte[] AuthenticationMessage()
	{
		return _steamRelayPasswordBytes;
	}

	public override bool IsValidConnection(SteamId connectedTo)
	{
		return connectedTo.IsValid;
	}

	public override void AuthenticatePlayer()
	{
		SteamNetworkingAvailability authenticationStatus = SteamNetworkingSockets.GetAuthenticationStatus();
		if (authenticationStatus != SteamNetworkingAvailability.Current)
		{
			SteamNetworkingSockets.InitAuthentication();
		}
		Debug.Log($"Steam auth: {authenticationStatus}");
	}

	public override bool IsUserBanned(ulong userID, bool onConnecting)
	{
		if (onConnecting)
		{
			return IsUserBannedCheck(userID);
		}
		return true;
	}

	public override Task SetPublicIP()
	{
		return Task.FromResult(IP = LocalIP);
	}

	public SteamNetworkSubset(object lockObject, Func<ulong, bool> isUserBannedCheck)
		: base(lockObject, isUserBannedCheck)
	{
	}
}
