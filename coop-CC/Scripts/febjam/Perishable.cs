using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class Perishable : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float lifetimeDuration = 30f;

	[SyncVar]
	private float _normalizedLifeRemaining;

	private Timer _lifeTimer;

	private bool _wasDamaged;

	public float normalizedLifeRemaining => _normalizedLifeRemaining;

	public float Network_normalizedLifeRemaining
	{
		get
		{
			return _normalizedLifeRemaining;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _normalizedLifeRemaining, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_lifeTimer.SetTimer(lifetimeDuration);
	}

	protected override void OnUpdateSimulation()
	{
		BoxHealth boxHealth = base.entity.GetObject<BoxHealth>();
		if (!boxHealth.isDamaged)
		{
			if (_wasDamaged)
			{
				_wasDamaged = false;
				_lifeTimer.SetTimer(lifetimeDuration);
			}
			_lifeTimer.DecrementTimer();
			if (_lifeTimer.IsFinished())
			{
				boxHealth.RequestTakeDamage(DamageType.Damaged);
			}
		}
		else
		{
			_wasDamaged = false;
			_lifeTimer.Clear();
		}
	}

	protected override void OnUpdatePresentation()
	{
		Network_normalizedLifeRemaining = math.saturate(_lifeTimer.GetSecondsRemaining() / lifetimeDuration);
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
			writer.WriteFloat(_normalizedLifeRemaining);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_normalizedLifeRemaining);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _normalizedLifeRemaining, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _normalizedLifeRemaining, null, reader.ReadFloat());
		}
	}
}
