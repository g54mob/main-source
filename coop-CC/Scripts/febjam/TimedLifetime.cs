using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class TimedLifetime : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float lifetimeDuration = 5f;

	[SyncVar]
	private float _syncNormalizedLifetime;

	private Timer _serverTimer;

	public float normalizedLifetime => _syncNormalizedLifetime;

	public float Network_syncNormalizedLifetime
	{
		get
		{
			return _syncNormalizedLifetime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedLifetime, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_serverTimer.SetTimer(lifetimeDuration);
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				EntityUtil.Destroy(base.entity);
			}
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.isServer)
		{
			Network_syncNormalizedLifetime = math.saturate(1f - _serverTimer.GetSecondsRemaining() / lifetimeDuration);
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
			writer.WriteFloat(_syncNormalizedLifetime);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedLifetime);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedLifetime, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedLifetime, null, reader.ReadFloat());
		}
	}
}
