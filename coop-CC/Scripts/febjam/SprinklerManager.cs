using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class SprinklerManager : NetworkAggroManagerBase<SprinklerManager>
{
	public enum State : byte
	{
		Inert = 0,
		SprinklersOnPuttingOutFires = 1,
		SprinklersOnFinishing = 2
	}

	[Min(0f)]
	public float timeUntilFireOut = 1f;

	[Min(0f)]
	public float timeUntilSprinklersDone = 3f;

	[Header("Puddles")]
	public GameObject puddlePrefab;

	[Range(0f, 1f)]
	public float puddleDensity;

	[Min(0f)]
	public float puddleShrinkGridSpaceDistance = 10f;

	[Min(0f)]
	public float puddlePositionNoise = 0.5f;

	[Min(0f)]
	public float puddleExclusionCheckRadius = 2f;

	[SyncVar]
	private State _syncState;

	private Timer _serverTimer;

	private ObjectQuery<IFlammable> _query;

	private List<Vector3> _serverPuddleLocs = new List<Vector3>();

	private int _serverPuddleSpawnCount;

	private int _serverPuddleTotalCount;

	private NetworkConnectionToClient _serverCauser;

	public State state => _syncState;

	public State Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 1uL, null);
		}
	}

	protected override void OnEntityStart()
	{
		_query = base.entityManager.CreateObjectQuery<IFlammable>();
		if (base.isServer)
		{
			_serverPuddleLocs.AddRangeNoGarbage(RoomPositionsUtil.GeneratePositions(puddleShrinkGridSpaceDistance, puddlePositionNoise, puddleExclusionCheckRadius, GetSeed()));
			_serverPuddleTotalCount = Mathf.CeilToInt(puddleDensity * (float)_serverPuddleLocs.Count);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		switch (_syncState)
		{
		case State.SprinklersOnPuttingOutFires:
		{
			_serverTimer.DecrementTimer();
			int num;
			if (_serverTimer.IsFinished())
			{
				num = _serverPuddleTotalCount;
				_query.Run();
				int num2 = 0;
				for (int i = 0; i < _query.count; i++)
				{
					IFlammable flammable = _query[i];
					if (flammable.ServerFlammableCanBePutOut())
					{
						num2++;
						flammable.ServerFlammablePutOut();
					}
				}
				if (_serverCauser != null && _serverCauser.isReady)
				{
					RpcFiresExtinguished(_serverCauser, (short)num2);
				}
				Network_syncState = State.SprinklersOnFinishing;
				_serverTimer.SetTimer(timeUntilSprinklersDone);
				_serverPuddleSpawnCount = 0;
				_serverPuddleLocs.Randomize(GetSeed());
			}
			else
			{
				num = (int)math.lerp(0f, _serverPuddleTotalCount, timeUntilSprinklersDone - _serverTimer.GetSecondsRemaining());
			}
			if (puddlePrefab != null)
			{
				while (_serverPuddleSpawnCount < num)
				{
					NetworkAggroManagerBase<PuddleManager>.instance.ServerSpawnPuddle(puddlePrefab, _serverPuddleLocs[_serverPuddleSpawnCount]);
					_serverPuddleSpawnCount++;
				}
			}
			break;
		}
		case State.SprinklersOnFinishing:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				Network_syncState = State.Inert;
			}
			break;
		default:
			throw new InvalidEnumException();
		case State.Inert:
			break;
		}
	}

	[Server]
	public void ServerTurnOn(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void SprinklerManager::ServerTurnOn(Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else if (_syncState == State.Inert)
		{
			_serverCauser = conn;
			Network_syncState = State.SprinklersOnPuttingOutFires;
			_serverTimer.SetTimer(timeUntilFireOut);
		}
	}

	[TargetRpc]
	private void RpcFiresExtinguished(NetworkConnectionToClient conn, short count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(count);
		SendTargetRPCInternal(conn, "System.Void SprinklerManager::RpcFiresExtinguished(Mirror.NetworkConnectionToClient,System.Int16)", -1843272329, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcFiresExtinguished__NetworkConnectionToClient__Int16(NetworkConnectionToClient conn, short count)
	{
		Platform.AddStat("stat_fires_extinguished", count);
	}

	protected static void InvokeUserCode_RpcFiresExtinguished__NetworkConnectionToClient__Int16(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcFiresExtinguished called on server.");
		}
		else
		{
			((SprinklerManager)obj).UserCode_RpcFiresExtinguished__NetworkConnectionToClient__Int16(null, reader.ReadShort());
		}
	}

	static SprinklerManager()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(SprinklerManager), "System.Void SprinklerManager::RpcFiresExtinguished(Mirror.NetworkConnectionToClient,System.Int16)", InvokeUserCode_RpcFiresExtinguished__NetworkConnectionToClient__Int16);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_SprinklerManager_002FState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_SprinklerManager_002FState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_SprinklerManager_002FState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_SprinklerManager_002FState(reader));
		}
	}
}
