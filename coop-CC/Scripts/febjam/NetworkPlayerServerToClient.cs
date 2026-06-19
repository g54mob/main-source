using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine.SceneManagement;

public class NetworkPlayerServerToClient : NetworkEntityBehaviourBase
{
	[SyncVar]
	public short syncPing;

	[SyncVar]
	public int syncOrder;

	public short NetworksyncPing
	{
		get
		{
			return syncPing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncPing, 1uL, null);
		}
	}

	public int NetworksyncOrder
	{
		get
		{
			return syncOrder;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncOrder, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		SceneManager.MoveGameObjectToScene(base.gameObject, NetworkAggroManagerBase<NetworkPlayerManager>.instance.comms.gameObject.scene);
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
			writer.WriteShort(syncPing);
			writer.WriteVarInt(syncOrder);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteShort(syncPing);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(syncOrder);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref syncPing, null, reader.ReadShort());
			GeneratedSyncVarDeserialize(ref syncOrder, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncPing, null, reader.ReadShort());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncOrder, null, reader.ReadVarInt());
		}
	}
}
