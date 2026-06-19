using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;

public class NetworkPlayerClientToServer : NetworkEntityBehaviourBase
{
	[SyncVar]
	public string syncPlayerName;

	[SyncVar]
	public string syncClientName;

	[SyncVar]
	public byte syncColorIndex;

	[SyncVar]
	public ulong syncPlatformId;

	[SyncVar]
	public string syncPlayFabId;

	[SyncVar]
	public bool syncIsHost;

	public string NetworksyncPlayerName
	{
		get
		{
			return syncPlayerName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncPlayerName, 1uL, null);
		}
	}

	public string NetworksyncClientName
	{
		get
		{
			return syncClientName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncClientName, 2uL, null);
		}
	}

	public byte NetworksyncColorIndex
	{
		get
		{
			return syncColorIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncColorIndex, 4uL, null);
		}
	}

	public ulong NetworksyncPlatformId
	{
		get
		{
			return syncPlatformId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncPlatformId, 8uL, null);
		}
	}

	public string NetworksyncPlayFabId
	{
		get
		{
			return syncPlayFabId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncPlayFabId, 16uL, null);
		}
	}

	public bool NetworksyncIsHost
	{
		get
		{
			return syncIsHost;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncIsHost, 32uL, null);
		}
	}

	public override void OnStartAuthority()
	{
		NetworksyncIsHost = base.isServer;
	}

	protected override void OnUpdateSimulation()
	{
		if (base.authority)
		{
			string userName = Platform.GetUserName();
			if (userName != syncPlayerName)
			{
				NetworksyncPlayerName = userName;
			}
			int colorIndex = SaveManager.data.GetColorIndex();
			if (colorIndex != syncColorIndex)
			{
				NetworksyncColorIndex = (byte)colorIndex;
			}
			string playerName = NetworkAggroManagerBase<NetworkPlayerManager>.instance.comms.PlayerName;
			if (playerName != syncClientName)
			{
				NetworksyncClientName = playerName;
			}
			ulong platformId = Platform.GetPlatformId();
			if (platformId != syncPlatformId)
			{
				NetworksyncPlatformId = platformId;
			}
			string playFabId = Platform.GetPlayFabId();
			if (playFabId != syncPlayFabId)
			{
				NetworksyncPlayFabId = playFabId;
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
			writer.WriteString(syncPlayerName);
			writer.WriteString(syncClientName);
			NetworkWriterExtensions.WriteByte(writer, syncColorIndex);
			writer.WriteVarULong(syncPlatformId);
			writer.WriteString(syncPlayFabId);
			writer.WriteBool(syncIsHost);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(syncPlayerName);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteString(syncClientName);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			NetworkWriterExtensions.WriteByte(writer, syncColorIndex);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarULong(syncPlatformId);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteString(syncPlayFabId);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteBool(syncIsHost);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref syncPlayerName, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref syncClientName, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref syncColorIndex, null, NetworkReaderExtensions.ReadByte(reader));
			GeneratedSyncVarDeserialize(ref syncPlatformId, null, reader.ReadVarULong());
			GeneratedSyncVarDeserialize(ref syncPlayFabId, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref syncIsHost, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncPlayerName, null, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncClientName, null, reader.ReadString());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncColorIndex, null, NetworkReaderExtensions.ReadByte(reader));
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncPlatformId, null, reader.ReadVarULong());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncPlayFabId, null, reader.ReadString());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncIsHost, null, reader.ReadBool());
		}
	}
}
