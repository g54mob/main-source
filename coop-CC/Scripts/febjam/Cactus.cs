using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class Cactus : NetworkEntityBehaviourBase, IMiscObject
{
	private struct Debounce
	{
		public Entity entity;

		public int removeAtFrame;
	}

	public enum State : byte
	{
		Spawning = 0,
		Spawned = 1,
		Destroying = 2
	}

	[Min(0f)]
	public float spawningDuration = 3f;

	[Min(0f)]
	public float destroyDuration = 1f;

	[Min(0f)]
	public float pluckingDuration = 2f;

	[Header("Players")]
	[Min(0f)]
	public float playerForce;

	[Min(0f)]
	public float playerAttackRadius = 1f;

	[Min(0f)]
	public float maxPlayerDistance = 4f;

	[Header("Boxes")]
	[Min(0f)]
	public float boxCheckRadius = 1f;

	[Min(0f)]
	public float boxCheckHeight = 4f;

	[Min(0f)]
	public float boxForce;

	[Min(0f)]
	public float boxForceUpwardsModifierDegrees = 30f;

	public Animator animator;

	public EventReference spawnSFXEvent;

	public EventReference attackSFXEvent;

	public EventReference destroySFXEvent;

	[Space]
	[Min(0f)]
	public float debounceDuration = 0.5f;

	[SyncVar]
	private float _syncSpawningTimeNormalized;

	[SyncVar]
	private float _syncPlayerDistanceNormalized;

	[SyncVar]
	private State _syncState;

	[SyncVar]
	private bool _syncIsPlucking;

	private Timer _serverTimer;

	private bool _serverAttacked;

	private int _localPlayerDebounceFrame;

	private Queue<Debounce> _serverDebounceQueue = new Queue<Debounce>();

	private HashSet<Entity> _serverDebounceSet = new HashSet<Entity>();

	private bool _destroyRequested;

	private bool _serverIsPlucking;

	private static List<Entity> _players;

	private static Collider[] _colliders;

	private static readonly int Attack;

	private static readonly int Pull;

	private static readonly int Grow;

	private static readonly int SELECTED;

	private static readonly int Selected;

	private static readonly int Nervous;

	public State state => _syncState;

	public float spawningTimeNormalized => _syncSpawningTimeNormalized;

	public float playerDistanceNormalized => _syncPlayerDistanceNormalized;

	public bool isPlucking => _syncIsPlucking;

	public float Network_syncSpawningTimeNormalized
	{
		get
		{
			return _syncSpawningTimeNormalized;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncSpawningTimeNormalized, 1uL, null);
		}
	}

	public float Network_syncPlayerDistanceNormalized
	{
		get
		{
			return _syncPlayerDistanceNormalized;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncPlayerDistanceNormalized, 2uL, null);
		}
	}

	public State Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 4uL, null);
		}
	}

	public bool Network_syncIsPlucking
	{
		get
		{
			return _syncIsPlucking;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIsPlucking, 8uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			Network_syncState = State.Spawning;
			Network_syncSpawningTimeNormalized = 0f;
			Network_syncPlayerDistanceNormalized = 0f;
			_serverTimer.SetTimer(spawningDuration);
		}
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (base.isServer)
		{
			_serverAttacked = false;
		}
	}

	protected override void OnUpdatePresentationLate()
	{
		float value = Mathf.Lerp(animator.GetFloat(Nervous), isPlucking ? 1 : 0, Time.deltaTime * 1f);
		animator.SetFloat(Nervous, value);
	}

	protected override void OnUpdateSimulationEarly()
	{
		animator.SetBool(Selected, value: false);
		_serverIsPlucking = false;
	}

	[UpdateInGroup(5)]
	protected override void OnUpdateSimulation()
	{
		switch (_syncState)
		{
		case State.Spawned:
		{
			if (TimeUtil.frame >= _localPlayerDebounceFrame && GameUtil.TryGetLocalPlayer(out var player) && !_destroyRequested)
			{
				Vector3 position = base.entity.transform.position;
				position.y = 0f;
				Vector3 position2 = player.transform.position;
				position2.y = 0f;
				Vector3 vector = position2 - position;
				if (vector.sqrMagnitude <= playerAttackRadius * playerAttackRadius)
				{
					player.GetObject<PlayerStress>().RequestBumpStress();
					player.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
					player.GetObject<PlayerAnimation>().PlayBonk();
					player.GetObject<PlayerColorManagerNetwork>().CmdPlayFlash();
					player.GetObject<VehicleController>().LocalPlayerTakeForce(vector.normalized * playerForce);
					_localPlayerDebounceFrame = TimeUtil.frame + TimeUtil.FramesForTime(debounceDuration);
					RequestAttack();
				}
			}
			break;
		}
		default:
			throw new InvalidEnumException();
		case State.Spawning:
		case State.Destroying:
			break;
		}
		if (!base.isServer)
		{
			return;
		}
		switch (_syncState)
		{
		case State.Spawning:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				Network_syncState = State.Spawned;
				_serverTimer.SetTimer(pluckingDuration);
				RpcCactusSpawned();
			}
			break;
		case State.Spawned:
		{
			Debounce result;
			while (_serverDebounceQueue.TryPeek(out result) && result.removeAtFrame <= TimeUtil.frame)
			{
				_serverDebounceQueue.Dequeue();
				_serverDebounceSet.Remove(result.entity);
			}
			Vector3 position3 = base.entity.transform.position;
			int num = Physics.OverlapCapsuleNonAlloc(position3 + Vector3.up * boxCheckHeight, position3 + Vector3.down * boxCheckHeight, boxCheckRadius, _colliders, 16384);
			for (int i = 0; i < num; i++)
			{
				Collider collider = _colliders[i];
				if (collider.TryGetEntity(out var item) && !item.rigidbody.isKinematic && item.TryGetObject<BoxProps>(out var obj) && !obj.serverIsSafe && item.TryGetObject<Grabbable>(out var obj2) && !obj2.serverIsOutbounding && !_serverDebounceSet.Contains(item))
				{
					Debounce item2 = new Debounce
					{
						entity = item,
						removeAtFrame = TimeUtil.frame + TimeUtil.FramesForTime(debounceDuration)
					};
					_serverDebounceQueue.Enqueue(item2);
					_serverDebounceSet.Add(item);
					obj2.ServerBreakStackAtMe();
					Vector3 position4 = item.rigidbody.position;
					Vector3 vector2 = new Vector3(position3.x, position4.y, position3.z);
					Vector3 normalized = (item.rigidbody.position - vector2).normalized;
					normalized = Quaternion.AngleAxis(boxForceUpwardsModifierDegrees, MathUtil.GetOrtho(normalized, Vector3.up)) * normalized;
					normalized *= boxForce;
					Vector3 position5 = collider.ClosestPoint(vector2);
					item.rigidbody.velocity = Vector3.zero;
					item.rigidbody.angularVelocity = Vector3.zero;
					item.rigidbody.AddForceAtPosition(normalized, position5, ForceMode.Impulse);
					if (item.TryGetObject<BoxActivator>(out var obj3))
					{
						ActivationContext context = new ActivationContext
						{
							type = ActivationContextType.Kicked,
							causer = base.entity
						};
						obj3.RequestActivate(context);
					}
					_serverAttacked = true;
				}
			}
			_players.Clear();
			base.entityManager.GetAllEntitiesWith<VehicleController>(_players);
			float num2 = float.MaxValue;
			for (int j = 0; j < _players.Count; j++)
			{
				Entity entity = _players[j];
				num2 = math.min(num2, math.distancesq(position3, entity.transform.position));
			}
			if (num2 < maxPlayerDistance * maxPlayerDistance)
			{
				if (num2 < playerAttackRadius * playerAttackRadius)
				{
					Network_syncPlayerDistanceNormalized = 1f;
				}
				else
				{
					float x = math.sqrt(num2);
					Network_syncPlayerDistanceNormalized = math.unlerp(maxPlayerDistance, playerAttackRadius, x);
				}
			}
			else
			{
				Network_syncPlayerDistanceNormalized = 0f;
			}
			if (_serverIsPlucking)
			{
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					ServerDestroy(null);
				}
			}
			else
			{
				_serverTimer.SetTimer(pluckingDuration);
			}
			break;
		}
		case State.Destroying:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				EntityUtil.Destroy(base.entity);
			}
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	protected override void OnUpdateSimulationLate()
	{
		if (base.isServer && _serverAttacked)
		{
			RpcCactusAttack();
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.isServer)
		{
			switch (_syncState)
			{
			case State.Spawning:
				Network_syncSpawningTimeNormalized = math.saturate(1f - _serverTimer.GetSecondsRemaining() / spawningDuration);
				break;
			default:
				throw new InvalidEnumException();
			case State.Spawned:
			case State.Destroying:
				break;
			}
			Network_syncIsPlucking = _serverIsPlucking;
		}
	}

	public void MarkIsCandidate()
	{
		if (_syncState != State.Destroying && _syncState != State.Spawning)
		{
			animator.SetBool(Selected, value: true);
		}
	}

	public void RequestAttack()
	{
		if (base.isServer)
		{
			_serverAttacked = true;
		}
		else
		{
			CmdCactusAttack();
		}
	}

	public void RequestDestroy()
	{
		CmdDestroy();
	}

	[Server]
	public void ServerIsPlucking()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Cactus::ServerIsPlucking()' called when server was not active");
		}
		else
		{
			_serverIsPlucking = true;
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdDestroy(NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Cactus::CmdDestroy(Mirror.NetworkConnectionToClient)", -1078574547, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerDestroy(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Cactus::ServerDestroy(Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else if (_syncState != State.Destroying && _syncState != State.Spawning)
		{
			Network_syncState = State.Destroying;
			_serverTimer.SetTimer(destroyDuration);
			RpcCactusDestroying();
		}
		else if (conn != null)
		{
			RpcDestroyDenied(conn);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdCactusAttack()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Cactus::CmdCactusAttack()", 211117933, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCactusSpawned()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Cactus::RpcCactusSpawned()", 713137590, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCactusAttack()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Cactus::RpcCactusAttack()", -866603526, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCactusDestroying()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Cactus::RpcCactusDestroying()", 3878648, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcDestroyDenied(NetworkConnectionToClient conn)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(conn, "System.Void Cactus::RpcDestroyDenied(Mirror.NetworkConnectionToClient)", 487028719, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
	}

	public void ServerIsBeingDestroyed()
	{
		ServerIsPlucking();
	}

	public void ServerDestroyedImmediate()
	{
		ServerDestroy(null);
	}

	static Cactus()
	{
		_players = new List<Entity>();
		_colliders = new Collider[32];
		Attack = Animator.StringToHash("attack");
		Pull = Animator.StringToHash("pull");
		Grow = Animator.StringToHash("grow");
		SELECTED = Shader.PropertyToID("_selected");
		Selected = Animator.StringToHash("selected");
		Nervous = Animator.StringToHash("nervous");
		RemoteProcedureCalls.RegisterCommand(typeof(Cactus), "System.Void Cactus::CmdDestroy(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdDestroy__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Cactus), "System.Void Cactus::CmdCactusAttack()", InvokeUserCode_CmdCactusAttack, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Cactus), "System.Void Cactus::RpcCactusSpawned()", InvokeUserCode_RpcCactusSpawned);
		RemoteProcedureCalls.RegisterRpc(typeof(Cactus), "System.Void Cactus::RpcCactusAttack()", InvokeUserCode_RpcCactusAttack);
		RemoteProcedureCalls.RegisterRpc(typeof(Cactus), "System.Void Cactus::RpcCactusDestroying()", InvokeUserCode_RpcCactusDestroying);
		RemoteProcedureCalls.RegisterRpc(typeof(Cactus), "System.Void Cactus::RpcDestroyDenied(Mirror.NetworkConnectionToClient)", InvokeUserCode_RpcDestroyDenied__NetworkConnectionToClient);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdDestroy__NetworkConnectionToClient(NetworkConnectionToClient conn)
	{
		ServerDestroy(conn);
	}

	protected static void InvokeUserCode_CmdDestroy__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDestroy called on client.");
		}
		else
		{
			((Cactus)obj).UserCode_CmdDestroy__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdCactusAttack()
	{
		_serverAttacked = true;
	}

	protected static void InvokeUserCode_CmdCactusAttack(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCactusAttack called on client.");
		}
		else
		{
			((Cactus)obj).UserCode_CmdCactusAttack();
		}
	}

	protected void UserCode_RpcCactusSpawned()
	{
		animator.SetTrigger(Grow);
		AudioManager.PlaySfx(spawnSFXEvent, base.transform.position);
	}

	protected static void InvokeUserCode_RpcCactusSpawned(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCactusSpawned called on server.");
		}
		else
		{
			((Cactus)obj).UserCode_RpcCactusSpawned();
		}
	}

	protected void UserCode_RpcCactusAttack()
	{
		animator.SetTrigger(Attack);
		AudioManager.PlaySfx(attackSFXEvent, base.transform.position);
	}

	protected static void InvokeUserCode_RpcCactusAttack(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCactusAttack called on server.");
		}
		else
		{
			((Cactus)obj).UserCode_RpcCactusAttack();
		}
	}

	protected void UserCode_RpcCactusDestroying()
	{
		animator.SetTrigger(Pull);
		AudioManager.PlaySfx(destroySFXEvent, base.transform.position);
	}

	protected static void InvokeUserCode_RpcCactusDestroying(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCactusDestroying called on server.");
		}
		else
		{
			((Cactus)obj).UserCode_RpcCactusDestroying();
		}
	}

	protected void UserCode_RpcDestroyDenied__NetworkConnectionToClient(NetworkConnectionToClient conn)
	{
		_destroyRequested = false;
	}

	protected static void InvokeUserCode_RpcDestroyDenied__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcDestroyDenied called on server.");
		}
		else
		{
			((Cactus)obj).UserCode_RpcDestroyDenied__NetworkConnectionToClient(null);
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(_syncSpawningTimeNormalized);
			writer.WriteFloat(_syncPlayerDistanceNormalized);
			GeneratedNetworkCode._Write_Cactus_002FState(writer, _syncState);
			writer.WriteBool(_syncIsPlucking);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_syncSpawningTimeNormalized);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(_syncPlayerDistanceNormalized);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			GeneratedNetworkCode._Write_Cactus_002FState(writer, _syncState);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(_syncIsPlucking);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncSpawningTimeNormalized, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncPlayerDistanceNormalized, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_Cactus_002FState(reader));
			GeneratedSyncVarDeserialize(ref _syncIsPlucking, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncSpawningTimeNormalized, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncPlayerDistanceNormalized, null, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_Cactus_002FState(reader));
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIsPlucking, null, reader.ReadBool());
		}
	}
}
