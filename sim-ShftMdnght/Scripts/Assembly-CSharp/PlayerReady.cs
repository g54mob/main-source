using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerReady : NetworkBehaviour
{
	[SyncVar]
	public bool isReady;

	public bool NetworkisReady
	{
		get
		{
			return isReady;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isReady, 1uL, null);
		}
	}

	[Command]
	public void CmdSetReady(bool ready)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(ready);
		SendCommandInternal("System.Void PlayerReady::CmdSetReady(System.Boolean)", 1068934397, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetReady__Boolean(bool ready)
	{
		NetworkisReady = ready;
		GameManager.Instance.CheckAllReady();
	}

	protected static void InvokeUserCode_CmdSetReady__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetReady called on client.");
		}
		else
		{
			((PlayerReady)obj).UserCode_CmdSetReady__Boolean(reader.ReadBool());
		}
	}

	static PlayerReady()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerReady), "System.Void PlayerReady::CmdSetReady(System.Boolean)", InvokeUserCode_CmdSetReady__Boolean, requiresAuthority: true);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isReady);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isReady);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isReady, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isReady, null, reader.ReadBool());
		}
	}
}
