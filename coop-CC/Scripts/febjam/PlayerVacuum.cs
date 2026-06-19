using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerVacuum : NetworkEntityBehaviourBase
{
	private struct DestroyCandidate : IEquatable<DestroyCandidate>
	{
		public Entity entity;

		public Timer timer;

		public bool isBeingDestroyed;

		public bool Equals(DestroyCandidate other)
		{
			return entity == other.entity;
		}
	}

	public GameObject objectDestroyVFX;

	[Min(0f)]
	public float vacuumRadius = 10f;

	[Range(0f, 180f)]
	public float vacuumArcDegrees = 90f;

	[Min(0f)]
	public float vacuumMaxTrashForce = 60f;

	[Min(0f)]
	public float vacuumMaxBoxForce = 15f;

	[Min(0f)]
	public float vacuumMaxPlayerForce = 10f;

	[Min(0f)]
	public float vacuumMaxPollenForce = 25f;

	public EasingFunction.Ease vacuumForceEase = EasingFunction.Ease.EaseInOutQuad;

	[Min(0f)]
	public float upwardsHeight = 1f;

	[Min(0f)]
	public float destroyForwardDistance = 2f;

	[Min(0f)]
	public float destroyRadius = 2f;

	[Min(0f)]
	public float destroyDuration = 0.5f;

	[Min(0f)]
	public float destroyPhysicsDrag = 5f;

	[SyncVar]
	private bool _syncIsCurrentlyVacuuming;

	[SyncVar]
	private Vector2 _syncVacuumingPos;

	[SyncVar]
	private Vector2 _syncVacuumingFwd;

	private const float HEIGHT = 20f;

	private List<DestroyCandidate> _serverCandidates = new List<DestroyCandidate>();

	private static Collider[] _colliders;

	public bool isCurrentlyVacuuming => _syncIsCurrentlyVacuuming;

	public bool Network_syncIsCurrentlyVacuuming
	{
		get
		{
			return _syncIsCurrentlyVacuuming;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIsCurrentlyVacuuming, 1uL, null);
		}
	}

	public Vector2 Network_syncVacuumingPos
	{
		get
		{
			return _syncVacuumingPos;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncVacuumingPos, 2uL, null);
		}
	}

	public Vector2 Network_syncVacuumingFwd
	{
		get
		{
			return _syncVacuumingFwd;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncVacuumingFwd, 4uL, null);
		}
	}

	protected override void OnUpdateSimulationEarly()
	{
		if (base.isLocalPlayer || !_syncIsCurrentlyVacuuming || !GameUtil.TryGetLocalPlayer(out var player) || !player.TryGetObject<PlayerEffects>(out var obj))
		{
			return;
		}
		Vector3 vector = new Vector3(_syncVacuumingPos.x, 0f, _syncVacuumingPos.y);
		Vector3 lhs = new Vector3(_syncVacuumingFwd.x, 0f, _syncVacuumingFwd.y);
		float num = math.cos(vacuumArcDegrees / 2f);
		Vector3 vector2 = player.transform.position - vector;
		if (vector2.sqrMagnitude < vacuumRadius * vacuumRadius && Vector3.Dot(lhs, vector2) >= 0f)
		{
			float magnitude = vector2.magnitude;
			vector2 /= magnitude;
			if (Vector3.Dot(lhs, vector2) >= num)
			{
				float num2 = EasingFunction.Evaluate(vacuumForceEase, vacuumMaxPlayerForce, 0f, math.saturate(magnitude / vacuumRadius));
				obj.AddForce(vector2 * num2);
			}
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isLocalPlayer)
		{
			if (!AggroInputManager.input.Game.UseBox.IsPressed() || AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen)
			{
				Network_syncIsCurrentlyVacuuming = false;
				return;
			}
			PlayerGrabber playerGrabber = base.entity.GetObject<PlayerGrabber>();
			if (playerGrabber.grabState != PlayerGrabState.Grabbed || !playerGrabber.localPlayerGrabTarget.HasObject<BoxVacuum>())
			{
				Network_syncIsCurrentlyVacuuming = false;
				return;
			}
			Network_syncIsCurrentlyVacuuming = true;
			Vector3 forward = base.entity.transform.forward;
			Vector3 vector = base.entity.transform.position + forward * destroyForwardDistance;
			Network_syncVacuumingPos = new Vector2(vector.x, vector.z);
			Network_syncVacuumingFwd = new Vector2(forward.x, forward.z);
		}
		if (_syncIsCurrentlyVacuuming)
		{
			Vector3 vector2 = new Vector3(_syncVacuumingPos.x, 0f, _syncVacuumingPos.y);
			Vector3 lhs = new Vector3(_syncVacuumingFwd.x, 0f, _syncVacuumingFwd.y);
			if (base.isServer)
			{
				for (int i = 0; i < _serverCandidates.Count; i++)
				{
					DestroyCandidate value = _serverCandidates[i];
					value.isBeingDestroyed = false;
					_serverCandidates[i] = value;
				}
			}
			Vector3 vector3 = vector2 + Vector3.up * upwardsHeight;
			float num = math.cos(vacuumArcDegrees / 2f);
			int num2 = Physics.OverlapCapsuleNonAlloc(vector2 + Vector3.up * 10f, vector2 + Vector3.down * 10f, vacuumRadius, _colliders, 16384);
			for (int j = 0; j < num2; j++)
			{
				if (!_colliders[j].TryGetEntity(out var entity) || entity.rigidbody.isKinematic)
				{
					continue;
				}
				Vector3 rhs = entity.transform.position - vector2;
				bool flag = math.distancesq(entity.transform.position, vector3) <= destroyRadius * destroyRadius;
				if (flag)
				{
					entity.rigidbody.velocity = PhysicsUtil.ApplyDrag(entity.rigidbody.velocity, destroyPhysicsDrag);
					if (base.isServer && entity.tags.Has(CCTags.TAG_JUNK))
					{
						DestroyCandidate item = new DestroyCandidate
						{
							entity = entity
						};
						int num3 = _serverCandidates.IndexOf(item);
						if (num3 < 0)
						{
							item.timer.SetTimer(destroyDuration);
							num3 = _serverCandidates.Count;
							_serverCandidates.Add(item);
						}
						item = _serverCandidates[num3];
						item.isBeingDestroyed = true;
						_serverCandidates[num3] = item;
					}
				}
				if (!flag && !(Vector3.Dot(lhs, rhs) >= 0f))
				{
					continue;
				}
				rhs.Normalize();
				if (!flag && !(Vector3.Dot(lhs, rhs) >= num))
				{
					continue;
				}
				Vector3 vector4 = vector3 - entity.transform.position;
				float magnitude = vector4.magnitude;
				vector4 /= magnitude;
				float num4 = EasingFunction.Evaluate(vacuumForceEase, entity.tags.Has(CCTags.TAG_JUNK) ? vacuumMaxTrashForce : vacuumMaxBoxForce, 0f, math.saturate(magnitude / vacuumRadius));
				entity.rigidbody.AddForce(vector4 * num4, ForceMode.Force);
				if (base.isServer)
				{
					if (entity.TryGetObject<BoxWander>(out var obj))
					{
						obj.ServerStopWander();
					}
					if (entity.TryGetObject<BoxCharge>(out var obj2))
					{
						obj2.ServerStopCharging();
					}
				}
			}
			int num5 = 0;
			if (base.isServer)
			{
				for (int k = 0; k < _serverCandidates.Count; k++)
				{
					DestroyCandidate value2 = _serverCandidates[k];
					if (value2.isBeingDestroyed)
					{
						value2.timer.DecrementTimer();
						if (value2.timer.IsFinished())
						{
							NetworkAggroManagerBase<VFXManager>.instance.Play(objectDestroyVFX, value2.entity.transform.position);
							EntityUtil.Destroy(value2.entity);
							num5++;
							_serverCandidates.RemoveAtSwapBack(k);
							k--;
						}
						else
						{
							_serverCandidates[k] = value2;
						}
					}
					else
					{
						_serverCandidates.RemoveAtSwapBack(k);
						k--;
					}
				}
				num2 = Physics.OverlapCapsuleNonAlloc(vector2 + Vector3.up * 10f, vector2 + Vector3.down * 10f, vacuumRadius, _colliders, 8);
				for (int l = 0; l < num2; l++)
				{
					if (!_colliders[l].TryGetEntity(out var entity2))
					{
						continue;
					}
					Vector3 rhs2 = entity2.transform.position - vector2;
					if (!(Vector3.Dot(lhs, rhs2) >= 0f))
					{
						continue;
					}
					rhs2.Normalize();
					if (Vector3.Dot(lhs, rhs2) >= num)
					{
						Pollen obj4;
						if (entity2.TryGetObject<IMiscObject>(out var obj3))
						{
							obj3.ServerIsBeingDestroyed();
						}
						else if (entity2.TryGetObject<Pollen>(out obj4))
						{
							Vector3 vector5 = vector2 - entity2.transform.position;
							float magnitude2 = vector5.magnitude;
							vector5 /= magnitude2;
							magnitude2 -= obj4.pollenRadius;
							magnitude2 = math.max(magnitude2, 0f);
							float num6 = EasingFunction.Evaluate(vacuumForceEase, vacuumMaxPollenForce, 0f, math.saturate(magnitude2 / vacuumRadius));
							obj4.AddForce(vector5 * num6);
						}
					}
				}
			}
			if (num5 > 0 && base.isServer)
			{
				RpcTrashDestroyed(base.entity.netIdentity.connectionToClient, (byte)num5);
			}
		}
		else if (base.isServer)
		{
			_serverCandidates.Clear();
		}
	}

	[TargetRpc]
	private void RpcTrashDestroyed(NetworkConnectionToClient conn, byte count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, count);
		SendTargetRPCInternal(conn, "System.Void PlayerVacuum::RpcTrashDestroyed(Mirror.NetworkConnectionToClient,System.Byte)", 1581527677, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position + base.transform.forward * destroyForwardDistance, 0.2f);
	}

	static PlayerVacuum()
	{
		_colliders = new Collider[128];
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerVacuum), "System.Void PlayerVacuum::RpcTrashDestroyed(Mirror.NetworkConnectionToClient,System.Byte)", InvokeUserCode_RpcTrashDestroyed__NetworkConnectionToClient__Byte);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcTrashDestroyed__NetworkConnectionToClient__Byte(NetworkConnectionToClient conn, byte count)
	{
		Platform.AddStat("stat_junk_destroyed", count);
	}

	protected static void InvokeUserCode_RpcTrashDestroyed__NetworkConnectionToClient__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcTrashDestroyed called on server.");
		}
		else
		{
			((PlayerVacuum)obj).UserCode_RpcTrashDestroyed__NetworkConnectionToClient__Byte(null, NetworkReaderExtensions.ReadByte(reader));
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_syncIsCurrentlyVacuuming);
			writer.WriteVector2(_syncVacuumingPos);
			writer.WriteVector2(_syncVacuumingFwd);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncIsCurrentlyVacuuming);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVector2(_syncVacuumingPos);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVector2(_syncVacuumingFwd);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyVacuuming, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncVacuumingPos, null, reader.ReadVector2());
			GeneratedSyncVarDeserialize(ref _syncVacuumingFwd, null, reader.ReadVector2());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyVacuuming, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncVacuumingPos, null, reader.ReadVector2());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncVacuumingFwd, null, reader.ReadVector2());
		}
	}
}
