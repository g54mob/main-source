using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBlower : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float blowerRadius = 10f;

	[Range(0f, 180f)]
	public float blowerArcDegrees = 90f;

	[Min(0f)]
	public float blowerMaxBoxForce = 15f;

	[Min(0f)]
	public float blowerMaxPlayerForce = 10f;

	[Min(0f)]
	public float blowerMaxPollenForce = 25f;

	public EasingFunction.Ease blowerForceEase = EasingFunction.Ease.EaseInOutQuad;

	[Min(0f)]
	public float upwardsHeight = 1f;

	[SyncVar]
	private bool _syncIsCurrentlyBlowing;

	[SyncVar]
	private Vector2 _syncBlowingPos;

	[SyncVar]
	private Vector2 _syncBlowingFwd;

	private const float HEIGHT = 20f;

	private static Collider[] _colliders = new Collider[128];

	public bool isCurrentlyBlowing => _syncIsCurrentlyBlowing;

	public bool Network_syncIsCurrentlyBlowing
	{
		get
		{
			return _syncIsCurrentlyBlowing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIsCurrentlyBlowing, 1uL, null);
		}
	}

	public Vector2 Network_syncBlowingPos
	{
		get
		{
			return _syncBlowingPos;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncBlowingPos, 2uL, null);
		}
	}

	public Vector2 Network_syncBlowingFwd
	{
		get
		{
			return _syncBlowingFwd;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncBlowingFwd, 4uL, null);
		}
	}

	protected override void OnUpdateSimulationEarly()
	{
		if (base.isLocalPlayer || !_syncIsCurrentlyBlowing || !GameUtil.TryGetLocalPlayer(out var player) || !player.TryGetObject<PlayerEffects>(out var obj))
		{
			return;
		}
		Vector3 vector = new Vector3(_syncBlowingPos.x, 0f, _syncBlowingPos.y);
		Vector3 lhs = new Vector3(_syncBlowingFwd.x, 0f, _syncBlowingFwd.y);
		float num = math.cos(blowerArcDegrees / 2f);
		Vector3 vector2 = player.transform.position - vector;
		if (Vector3.Dot(lhs, vector2) >= 0f)
		{
			float magnitude = vector2.magnitude;
			vector2 /= magnitude;
			if (Vector3.Dot(lhs, vector2) >= num)
			{
				float num2 = EasingFunction.Evaluate(blowerForceEase, blowerMaxPlayerForce, 0f, math.saturate(magnitude / blowerRadius));
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
				Network_syncIsCurrentlyBlowing = false;
				return;
			}
			PlayerGrabber playerGrabber = base.entity.GetObject<PlayerGrabber>();
			if (playerGrabber.grabState != PlayerGrabState.Grabbed || !playerGrabber.localPlayerGrabTarget.HasObject<BoxBlower>())
			{
				Network_syncIsCurrentlyBlowing = false;
				return;
			}
			Network_syncIsCurrentlyBlowing = true;
			Vector3 position = base.entity.transform.position;
			Vector3 forward = base.entity.transform.forward;
			Network_syncBlowingPos = new Vector2(position.x, position.z);
			Network_syncBlowingFwd = new Vector2(forward.x, forward.z);
		}
		if (!_syncIsCurrentlyBlowing)
		{
			return;
		}
		Vector3 vector = new Vector3(_syncBlowingPos.x, 0f, _syncBlowingPos.y);
		Vector3 lhs = new Vector3(_syncBlowingFwd.x, 0f, _syncBlowingFwd.y);
		float num = math.cos(blowerArcDegrees / 2f);
		int num2 = Physics.OverlapCapsuleNonAlloc(vector + Vector3.up * 10f, vector + Vector3.down * 10f, blowerRadius, _colliders, 16384);
		for (int i = 0; i < num2; i++)
		{
			if (!_colliders[i].TryGetEntity(out var entity))
			{
				continue;
			}
			Vector3 rhs = entity.transform.position - vector;
			if (!(Vector3.Dot(lhs, rhs) >= 0f))
			{
				continue;
			}
			rhs.Normalize();
			if (!(Vector3.Dot(lhs, rhs) >= num))
			{
				continue;
			}
			Vector3 vector2 = vector + Vector3.up * upwardsHeight;
			Vector3 vector3 = entity.transform.position - vector2;
			float magnitude = vector3.magnitude;
			vector3 /= magnitude;
			float num3 = EasingFunction.Evaluate(blowerForceEase, blowerMaxBoxForce, 0f, math.saturate(magnitude / blowerRadius));
			entity.rigidbody.AddForce(vector3 * num3, ForceMode.Force);
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
		if (!base.isServer)
		{
			return;
		}
		num2 = Physics.OverlapCapsuleNonAlloc(vector + Vector3.up * 10f, vector + Vector3.down * 10f, blowerRadius, _colliders, 8);
		for (int j = 0; j < num2; j++)
		{
			if (!_colliders[j].TryGetEntity(out var entity2))
			{
				continue;
			}
			Vector3 rhs2 = entity2.transform.position - vector;
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
					Vector3 vector4 = entity2.transform.position - vector;
					float magnitude2 = vector4.magnitude;
					vector4 /= magnitude2;
					magnitude2 -= obj4.pollenRadius;
					magnitude2 = math.max(magnitude2, 0f);
					float num4 = EasingFunction.Evaluate(blowerForceEase, blowerMaxPollenForce, 0f, math.saturate(magnitude2 / blowerRadius));
					obj4.AddForce(vector4 * num4);
				}
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_syncIsCurrentlyBlowing);
			writer.WriteVector2(_syncBlowingPos);
			writer.WriteVector2(_syncBlowingFwd);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncIsCurrentlyBlowing);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVector2(_syncBlowingPos);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVector2(_syncBlowingFwd);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyBlowing, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncBlowingPos, null, reader.ReadVector2());
			GeneratedSyncVarDeserialize(ref _syncBlowingFwd, null, reader.ReadVector2());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyBlowing, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncBlowingPos, null, reader.ReadVector2());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncBlowingFwd, null, reader.ReadVector2());
		}
	}
}
