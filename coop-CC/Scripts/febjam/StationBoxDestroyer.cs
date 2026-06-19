using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class StationBoxDestroyer : NetworkEntityBehaviourBase
{
	public enum DestroyerState : byte
	{
		Idle = 0,
		Destroying = 1
	}

	private static readonly int Destroying;

	[Min(0f)]
	public float destroyDuration = 5f;

	[Min(1f)]
	public int moneyGainedOnDestroy = 10;

	[SyncVar]
	private float _syncNormalizedTime;

	[SyncVar]
	private DestroyerState _syncState;

	private Timer _serverTimer;

	public Animator animator;

	public EventReference pressSfx;

	public GameObject poofVFX;

	public Transform poofVFXTransform;

	public float normalizedTime => _syncNormalizedTime;

	public DestroyerState state => _syncState;

	public float Network_syncNormalizedTime
	{
		get
		{
			return _syncNormalizedTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedTime, 1uL, null);
		}
	}

	public DestroyerState Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 2uL, null);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		GrabbableHolder grabbableHolder = base.entity.GetObject<GrabbableHolder>();
		switch (_syncState)
		{
		case DestroyerState.Idle:
			if (grabbableHolder.isHoldingAnItem)
			{
				_serverTimer.SetTimer(destroyDuration);
				Network_syncState = DestroyerState.Destroying;
			}
			break;
		case DestroyerState.Destroying:
			if (grabbableHolder.isHoldingAnItem)
			{
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					if (grabbableHolder.serverHeldEntity.tags.Has(CCTags.TAG_JUNK))
					{
						RpcTrashDestroyed();
					}
					if (grabbableHolder.serverHeldEntity.TryGetObject<BoxProps>(out var obj) && !string.IsNullOrEmpty(obj.onTrashCompactedId))
					{
						NetworkAggroManagerBase<AchievementManager>.instance.ServerUnlockAchievement(obj.onTrashCompactedId);
					}
					EntityUtil.Destroy(grabbableHolder.serverHeldEntity);
					Network_syncState = DestroyerState.Idle;
					grabbableHolder.NetworkisInteractable = true;
					NetworkAggroManagerBase<ShiftManager>.instance.ServerAddMoney(moneyGainedOnDestroy);
					NetworkAggroManagerBase<VFXManager>.instance.Play(poofVFX, poofVFXTransform.position, poofVFXTransform.rotation);
				}
			}
			else
			{
				Network_syncState = DestroyerState.Idle;
				grabbableHolder.NetworkisInteractable = true;
			}
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	protected override void OnUpdatePresentation()
	{
		animator.SetBool(Destroying, _syncState == DestroyerState.Destroying);
		if (base.isServer)
		{
			Network_syncNormalizedTime = math.saturate(_serverTimer.GetSecondsRemaining() / destroyDuration);
		}
	}

	[ClientRpc]
	private void RpcTrashDestroyed()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StationBoxDestroyer::RpcTrashDestroyed()", -327405701, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	static StationBoxDestroyer()
	{
		Destroying = Animator.StringToHash("destroying");
		RemoteProcedureCalls.RegisterRpc(typeof(StationBoxDestroyer), "System.Void StationBoxDestroyer::RpcTrashDestroyed()", InvokeUserCode_RpcTrashDestroyed);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcTrashDestroyed()
	{
		AudioManager.PlaySfx(pressSfx, base.transform.position);
		Aggro.Core.Platform.AddStat("stat_junk_destroyed", 1);
		Aggro.Core.Platform.AddStat("stat_trash_money", moneyGainedOnDestroy);
	}

	protected static void InvokeUserCode_RpcTrashDestroyed(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTrashDestroyed called on server.");
		}
		else
		{
			((StationBoxDestroyer)obj).UserCode_RpcTrashDestroyed();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(_syncNormalizedTime);
			GeneratedNetworkCode._Write_StationBoxDestroyer_002FDestroyerState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedTime);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			GeneratedNetworkCode._Write_StationBoxDestroyer_002FDestroyerState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_StationBoxDestroyer_002FDestroyerState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedTime, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_StationBoxDestroyer_002FDestroyerState(reader));
		}
	}
}
