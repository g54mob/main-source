using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class Station : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float pickUpDuration = 1f;

	public GameObject boxPrefab;

	[Header("Visuals")]
	public Transform packUpShakeTransform;

	public Vector3 shakeAxis = Vector3.forward;

	public float packUpShakeSpeed = 0.5f;

	public float packUpShakeIntensity = 5f;

	public float visualScalar = 1f;

	public float scaleThreshold;

	public EasingFunction.Ease shrinkEase = EasingFunction.Ease.Linear;

	public GameObject pickupVFX;

	public StudioEventEmitter pickUpWobbleSFX;

	[SyncVar]
	private byte _syncPickUpCount;

	[SyncVar]
	private float _syncNormalizedTime;

	[SyncVar]
	private bool _syncCanBePickedUp = true;

	private Timer _serverTimer;

	private static List<GrabbableHolder> _holders = new List<GrabbableHolder>();

	private bool _wasBeingPickedUp;

	public bool canBePickedUp => _syncCanBePickedUp;

	public bool isBeingPickedUp
	{
		get
		{
			if (_syncPickUpCount > 0)
			{
				return _syncCanBePickedUp;
			}
			return false;
		}
	}

	public float normalizedPickUpTime => _syncNormalizedTime;

	public byte Network_syncPickUpCount
	{
		get
		{
			return _syncPickUpCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncPickUpCount, 1uL, null);
		}
	}

	public float Network_syncNormalizedTime
	{
		get
		{
			return _syncNormalizedTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedTime, 2uL, null);
		}
	}

	public bool Network_syncCanBePickedUp
	{
		get
		{
			return _syncCanBePickedUp;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncCanBePickedUp, 4uL, null);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		if (_syncPickUpCount > 0 && _syncCanBePickedUp)
		{
			_serverTimer.DecrementTimer();
			Network_syncNormalizedTime = math.saturate(1f - _serverTimer.GetSecondsRemaining() / pickUpDuration);
			if (!_serverTimer.IsFinished())
			{
				return;
			}
			_holders.Clear();
			base.entity.GetObjects(_holders);
			for (int i = 0; i < _holders.Count; i++)
			{
				GrabbableHolder grabbableHolder = _holders[i];
				if (grabbableHolder.serverHeldEntity != Entity.invalid)
				{
					Grabbable grabbable = grabbableHolder.serverHeldEntity.GetObject<Grabbable>();
					grabbable.ServerRemoveFromHolder();
					grabbable.ServerBreakEntireStack();
					grabbableHolder.ServerRemoveItem();
				}
			}
			NetworkAggroManagerBase<VFXManager>.instance.Play(pickupVFX, base.transform.position);
			if (base.entity.TryGetObject<IStation>(out var obj))
			{
				obj.ServerIsBeingPickedUp();
			}
			base.entity.TryGetStruct<StationData>(out var comp);
			Entity entity = EntityUtil.Instantiate(boxPrefab, base.transform.position + Vector3.up);
			EntityUtil.Destroy(base.entity);
			entity.AddStruct(comp);
		}
		else
		{
			_serverTimer.SetTimer(pickUpDuration);
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (isBeingPickedUp && !_wasBeingPickedUp)
		{
			pickUpWobbleSFX.Play();
		}
		if (_wasBeingPickedUp && !isBeingPickedUp)
		{
			pickUpWobbleSFX.Stop();
		}
		visualScalar = 1f;
		if (packUpShakeTransform != null)
		{
			if (isBeingPickedUp)
			{
				float num = Mathf.Sin(Time.time * packUpShakeSpeed);
				Vector3 vector = shakeAxis * num * Mathf.Max(packUpShakeIntensity * normalizedPickUpTime, 0.3f);
				packUpShakeTransform.localRotation = Quaternion.Euler(vector.x, vector.y, vector.z);
				scaleThreshold = 0.8f;
				if (normalizedPickUpTime > scaleThreshold)
				{
					float value = (normalizedPickUpTime - scaleThreshold) / (1f - scaleThreshold);
					visualScalar = 1f - EasingFunction.Evaluate(shrinkEase, value);
				}
			}
			else
			{
				packUpShakeTransform.localRotation = Quaternion.identity;
			}
			packUpShakeTransform.localScale = Vector3.one * visualScalar;
		}
		_wasBeingPickedUp = isBeingPickedUp;
	}

	[Server]
	public void ServerIncrementPickUp()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Station::ServerIncrementPickUp()' called when server was not active");
		}
		else
		{
			Network_syncPickUpCount = (byte)(_syncPickUpCount + 1);
		}
	}

	[Server]
	public void ServerDecrementPickUp()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Station::ServerDecrementPickUp()' called when server was not active");
		}
		else
		{
			Network_syncPickUpCount = (byte)(_syncPickUpCount - 1);
		}
	}

	[Server]
	public void ServerSetUnpickable()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Station::ServerSetUnpickable()' called when server was not active");
		}
		else
		{
			Network_syncCanBePickedUp = false;
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
			NetworkWriterExtensions.WriteByte(writer, _syncPickUpCount);
			writer.WriteFloat(_syncNormalizedTime);
			writer.WriteBool(_syncCanBePickedUp);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			NetworkWriterExtensions.WriteByte(writer, _syncPickUpCount);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedTime);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(_syncCanBePickedUp);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncPickUpCount, null, NetworkReaderExtensions.ReadByte(reader));
			GeneratedSyncVarDeserialize(ref _syncNormalizedTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncCanBePickedUp, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncPickUpCount, null, NetworkReaderExtensions.ReadByte(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedTime, null, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncCanBePickedUp, null, reader.ReadBool());
		}
	}
}
