using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class TestEntityMirror : NetworkEntityBehaviourBase
{
	[SyncVar]
	private Entity _syncEntity;

	private ObjectQuery<VehicleController> _query;

	public Entity Network_syncEntity
	{
		get
		{
			return _syncEntity;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncEntity, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_query = base.entityManager.CreateObjectQuery<VehicleController>();
	}

	protected override void OnUpdatePresentation()
	{
		Debug.Log(_syncEntity);
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			_query.Run();
			if (_query.count > 0)
			{
				Network_syncEntity = _query.GetEntity(Random.Range(0, _query.count));
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
			writer.WriteEntity(_syncEntity);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteEntity(_syncEntity);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncEntity, null, reader.ReadEntity());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncEntity, null, reader.ReadEntity());
		}
	}
}
