using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class StationSprinkler : NetworkEntityBehaviourBase
{
	public enum SprinklerPreventionState : byte
	{
		Inert = 0,
		WarmingUp = 1,
		Preventing = 2
	}

	[Range(0f, 20f)]
	public float detectionRadius = 5f;

	[Range(0f, 20f)]
	public float putOutRadius = 5f;

	[Min(0f)]
	public float warmUpDuration = 1f;

	[Min(0f)]
	public float preventingDuration = 2f;

	public ParticleSystem activeParticleSystem;

	[Header("Puddles")]
	public GameObject puddlePrefab;

	public Vector2 puddleMinMaxRadius = new Vector2(1f, 4f);

	[Min(1f)]
	public int puddleCount = 4;

	[SyncVar]
	private SprinklerPreventionState _syncState;

	private Timer _serverTimer;

	private int _serverPuddleCount;

	private int _serverPutOutCount;

	private static List<IFlammable> _flammables;

	private static Collider[] _colliders;

	public SprinklerPreventionState state => _syncState;

	public SprinklerPreventionState Network_syncState
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

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		switch (_syncState)
		{
		case SprinklerPreventionState.Inert:
			_flammables.Clear();
			ServerGetOnFireBoxes(_flammables, detectionRadius);
			if (_flammables.Count > 0)
			{
				_serverTimer.SetTimer(warmUpDuration);
				Network_syncState = SprinklerPreventionState.WarmingUp;
			}
			break;
		case SprinklerPreventionState.WarmingUp:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				_serverTimer.SetTimer(preventingDuration);
				Network_syncState = SprinklerPreventionState.Preventing;
				_serverPuddleCount = 0;
				_serverPutOutCount = 0;
			}
			break;
		case SprinklerPreventionState.Preventing:
		{
			_flammables.Clear();
			ServerGetOnFireBoxes(_flammables, putOutRadius);
			for (int i = 0; i < _flammables.Count; i++)
			{
				_flammables[i].ServerFlammablePutOut();
				_serverPutOutCount++;
			}
			_serverTimer.DecrementTimer();
			int num;
			if (_serverTimer.IsFinished())
			{
				Network_syncState = SprinklerPreventionState.Inert;
				num = puddleCount;
				if (_serverPutOutCount > 0)
				{
					RpcFiresPutOut((byte)_serverPutOutCount);
				}
			}
			else
			{
				num = (int)math.lerp(0f, puddleCount, preventingDuration - _serverTimer.GetSecondsRemaining());
			}
			if (puddlePrefab != null)
			{
				Unity.Mathematics.Random random = GetRandom();
				Vector3 position = base.entity.transform.position;
				while (_serverPuddleCount < num)
				{
					_serverPuddleCount++;
					float2 float5 = random.NextFloat2Direction();
					Vector3 vector = new Vector3(float5.x, 0f, float5.y);
					Vector3 position2 = position + vector * random.NextFloat(puddleMinMaxRadius.x, puddleMinMaxRadius.y);
					NetworkAggroManagerBase<PuddleManager>.instance.ServerSpawnPuddle(puddlePrefab, position2);
				}
			}
			break;
		}
		default:
			throw new InvalidEnumException();
		}
	}

	[ClientRpc]
	private void RpcFiresPutOut(byte count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, count);
		SendRPCInternal("System.Void StationSprinkler::RpcFiresPutOut(System.Byte)", 308942779, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected override void OnUpdatePresentation()
	{
		if (activeParticleSystem != null)
		{
			ParticleSystem.EmissionModule emission = activeParticleSystem.emission;
			emission.enabled = _syncState == SprinklerPreventionState.WarmingUp || _syncState == SprinklerPreventionState.Preventing;
		}
	}

	private void ServerGetOnFireBoxes(List<IFlammable> entities, float radius)
	{
		int num = Physics.OverlapSphereNonAlloc(base.entity.transform.position, radius, _colliders, 147464);
		for (int i = 0; i < num; i++)
		{
			if (_colliders[i].GetEntity().TryGetObject<IFlammable>(out var obj) && obj.ServerFlammableCanBePutOut())
			{
				entities.Add(obj);
			}
		}
	}

	static StationSprinkler()
	{
		_flammables = new List<IFlammable>();
		_colliders = new Collider[128];
		RemoteProcedureCalls.RegisterRpc(typeof(StationSprinkler), "System.Void StationSprinkler::RpcFiresPutOut(System.Byte)", InvokeUserCode_RpcFiresPutOut__Byte);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcFiresPutOut__Byte(byte count)
	{
		Platform.AddStat("stat_fires_extinguished", count);
	}

	protected static void InvokeUserCode_RpcFiresPutOut__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcFiresPutOut called on server.");
		}
		else
		{
			((StationSprinkler)obj).UserCode_RpcFiresPutOut__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_StationSprinkler_002FSprinklerPreventionState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_StationSprinkler_002FSprinklerPreventionState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_StationSprinkler_002FSprinklerPreventionState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_StationSprinkler_002FSprinklerPreventionState(reader));
		}
	}
}
