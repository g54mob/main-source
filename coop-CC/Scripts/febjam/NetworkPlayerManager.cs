using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Dissonance.Integrations.MirrorIgnorance;
using Mirror;
using UnityEngine;

public class NetworkPlayerManager : NetworkAggroManagerBase<NetworkPlayerManager>
{
	public struct PlayerStats
	{
		public string playerName;

		public string voiceName;

		public string playFabId;

		public ulong platformId;

		public int colorIndex;

		public int ping;
	}

	public GameObject playerPrefab;

	public MirrorIgnoranceCommsNetwork comms;

	private List<Entity> _serverPlayers = new List<Entity>();

	private ObjectQuery<NetworkPlayerServerToClient> _query;

	[Min(0f)]
	public float updateStatsEvery = 1f;

	private Timer _serverTimer;

	private int _order;

	protected override void OnEntityCreated()
	{
		_query = base.entityManager.CreateObjectQuery<NetworkPlayerServerToClient>();
		if (base.isServer)
		{
			_serverTimer.SetTimer(updateStatsEvery);
		}
	}

	protected override void OnEntityStart()
	{
		if (base.isServer)
		{
			ServerPlayerJoined(NetworkServer.localConnection);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		_serverTimer.DecrementTimer();
		if (_serverTimer.IsFinished())
		{
			_serverTimer.SetTimer(updateStatsEvery);
			for (int i = 0; i < _serverPlayers.Count; i++)
			{
				Entity entity = _serverPlayers[i];
				entity.GetObject<NetworkPlayerServerToClient>().NetworksyncPing = (short)NetworkUtil.ServerGetPing(entity.netIdentity.connectionToClient);
			}
		}
	}

	[Server]
	public void ServerPlayerJoined(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkPlayerManager::ServerPlayerJoined(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		Entity item = Object.Instantiate(playerPrefab).GetEntity();
		item.netIdentity.AssignClientAuthority(conn);
		NetworkPlayerServerToClient networkPlayerServerToClient = item.GetObject<NetworkPlayerServerToClient>();
		networkPlayerServerToClient.NetworksyncOrder = _order++;
		networkPlayerServerToClient.NetworksyncPing = 0;
		_serverPlayers.Add(item);
	}

	[Server]
	public void ServerPlayerLeft(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkPlayerManager::ServerPlayerLeft(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		for (int i = 0; i < _serverPlayers.Count; i++)
		{
			Entity entity = _serverPlayers[i];
			if (entity.netIdentity.connectionToClient == conn)
			{
				GameObject obj = entity.gameObject;
				base.entityManager.DestroyEntity(entity.key);
				_serverPlayers.RemoveAt(i);
				NetworkServer.Destroy(obj);
				break;
			}
		}
	}

	public void PopulatePlayerStats(List<PlayerStats> stats)
	{
		_query.Run();
		if (_query.count == 0)
		{
			return;
		}
		int ping = 0;
		_query.Sort((NetworkPlayerServerToClient x, NetworkPlayerServerToClient y) => x.syncOrder.CompareTo(y.syncOrder));
		int count = stats.Count;
		for (int num = 0; num < _query.count; num++)
		{
			Entity entity = _query[num].entity;
			NetworkPlayerServerToClient networkPlayerServerToClient = _query[num];
			if (entity.isOwned)
			{
				ping = networkPlayerServerToClient.syncPing;
				continue;
			}
			NetworkPlayerClientToServer networkPlayerClientToServer = entity.GetObject<NetworkPlayerClientToServer>();
			stats.Add(new PlayerStats
			{
				voiceName = networkPlayerClientToServer.syncClientName,
				playerName = networkPlayerClientToServer.syncPlayerName,
				playFabId = networkPlayerClientToServer.syncPlayFabId,
				platformId = networkPlayerClientToServer.syncPlatformId,
				colorIndex = networkPlayerClientToServer.syncColorIndex,
				ping = networkPlayerServerToClient.syncPing
			});
		}
		if (!base.isServer)
		{
			PlayerStats value = stats[count];
			value.ping = ping;
			stats[count] = value;
		}
	}

	public bool TryGetHostNameAndColor(out string name, out int colorIndex)
	{
		if (!Exists())
		{
			name = null;
			colorIndex = 0;
			return false;
		}
		_query.Run();
		for (int i = 0; i < _query.count; i++)
		{
			NetworkPlayerClientToServer networkPlayerClientToServer = _query[i].entity.GetObject<NetworkPlayerClientToServer>();
			if (networkPlayerClientToServer.syncIsHost)
			{
				name = networkPlayerClientToServer.syncPlayerName;
				colorIndex = networkPlayerClientToServer.syncColorIndex;
				return true;
			}
		}
		name = null;
		colorIndex = 0;
		return false;
	}

	public override bool Weaved()
	{
		return true;
	}
}
