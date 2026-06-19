using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class BoxRoboVacuum : NetworkEntityBehaviourBase
{
	public enum EnabledStrategy
	{
		LooseAndBase = 0,
		Activated = 1
	}

	public bool onlyDestroyTrash = true;

	public EnabledStrategy strategy;

	[Min(0f)]
	public float vacuumRadius = 5f;

	[Min(0f)]
	public float vacuumMaxTrashForce = 15f;

	[Min(0f)]
	public float vacuumMaxBoxForce = 15f;

	[Min(0f)]
	public float blowerMaxPlayerForce = 10f;

	public EasingFunction.Ease vacuumForceEase = EasingFunction.Ease.EaseOutQuad;

	[Min(0f)]
	public float upwardsHeight = 1f;

	[Min(0f)]
	public float destroyRadius = 2f;

	[SyncVar]
	private bool _syncIsCurrentlyVacuuming;

	[SyncVar]
	private Vector2 _syncVacuumingPos;

	private const float HEIGHT = 20f;

	private static Collider[] _colliders = new Collider[128];

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

	protected override void OnUpdateSimulationEarly()
	{
		if (_syncIsCurrentlyVacuuming && GameUtil.TryGetLocalPlayer(out var player) && player.TryGetObject<PlayerEffects>(out var obj))
		{
			Vector3 vector = new Vector3(_syncVacuumingPos.x, 0f, _syncVacuumingPos.y);
			Vector3 vector2 = player.transform.position - vector;
			if (vector2.sqrMagnitude < vacuumRadius * vacuumRadius)
			{
				float magnitude = vector2.magnitude;
				vector2 /= magnitude;
				float num = EasingFunction.Evaluate(vacuumForceEase, blowerMaxPlayerForce, 0f, math.saturate(magnitude / vacuumRadius));
				obj.AddForce(vector2 * num);
			}
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			switch (strategy)
			{
			case EnabledStrategy.LooseAndBase:
			{
				Grabbable grabbable = base.entity.GetObject<Grabbable>();
				if (!grabbable.ServerIsBeingHeldByPlayer() && !grabbable.ServerIsBeingHeldByHolder() && grabbable.isBase)
				{
					Network_syncIsCurrentlyVacuuming = true;
					Vector3 position = base.entity.transform.position;
					Network_syncVacuumingPos = new Vector2(position.x, position.z);
				}
				else
				{
					Network_syncIsCurrentlyVacuuming = false;
				}
				break;
			}
			case EnabledStrategy.Activated:
			{
				BoxActivator boxActivator = base.entity.GetObject<BoxActivator>();
				Network_syncIsCurrentlyVacuuming = boxActivator.activated;
				break;
			}
			default:
				throw new InvalidEnumException();
			}
		}
		if (!_syncIsCurrentlyVacuuming)
		{
			return;
		}
		Vector3 vector = new Vector3(_syncVacuumingPos.x, 0f, _syncVacuumingPos.y);
		int num = Physics.OverlapCapsuleNonAlloc(vector + Vector3.up * 10f, vector + Vector3.down * 10f, vacuumRadius, _colliders, 16384);
		for (int i = 0; i < num; i++)
		{
			if (!_colliders[i].TryGetEntity(out var entity) || !(entity != base.entity))
			{
				continue;
			}
			(entity.transform.position - vector).Normalize();
			Vector3 vector2 = vector + Vector3.up * upwardsHeight;
			if (math.distancesq(entity.transform.position, vector2) <= destroyRadius * destroyRadius)
			{
				if (base.isServer && (entity.tags.Has(CCTags.TAG_JUNK) || !onlyDestroyTrash))
				{
					EntityUtil.Destroy(entity);
				}
			}
			else
			{
				Vector3 vector3 = vector2 - entity.transform.position;
				float magnitude = vector3.magnitude;
				vector3 /= magnitude;
				float num2 = EasingFunction.Evaluate(vacuumForceEase, entity.tags.Has(CCTags.TAG_JUNK) ? vacuumMaxTrashForce : vacuumMaxBoxForce, 0f, math.saturate(magnitude / vacuumRadius));
				entity.rigidbody.AddForce(vector3 * num2, ForceMode.Force);
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
			writer.WriteBool(_syncIsCurrentlyVacuuming);
			writer.WriteVector2(_syncVacuumingPos);
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
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyVacuuming, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncVacuumingPos, null, reader.ReadVector2());
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
	}
}
