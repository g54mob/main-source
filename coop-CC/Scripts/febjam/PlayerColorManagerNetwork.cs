using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerColorManagerNetwork : NetworkEntityBehaviourBase
{
	[SyncVar]
	public int activePlayerColorIndex;

	public PlayerColorManager playerColorManager;

	public int NetworkactivePlayerColorIndex
	{
		get
		{
			return activePlayerColorIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref activePlayerColorIndex, 1uL, null);
		}
	}

	public void SetPlayerColorIndex(int index)
	{
		NetworkactivePlayerColorIndex = index;
		if (Application.isPlaying)
		{
			SaveManager.data.SetColorIndex(activePlayerColorIndex);
		}
		else
		{
			playerColorManager.activePlayerColorIndex = activePlayerColorIndex;
		}
	}

	[ContextMenu("CyclePlayerColor")]
	public void CycleToNextPlayerColor(int dir = 1)
	{
		if (activePlayerColorIndex + dir < 0)
		{
			NetworkactivePlayerColorIndex = playerColorManager.playerColors.Count - 1;
		}
		else if (activePlayerColorIndex + dir > playerColorManager.playerColors.Count - 1)
		{
			NetworkactivePlayerColorIndex = 0;
		}
		else
		{
			NetworkactivePlayerColorIndex = activePlayerColorIndex + dir;
		}
		SaveManager.data.SetColorIndex(activePlayerColorIndex);
	}

	protected override void OnEntityCreated()
	{
		if (!GameUtil.isReady)
		{
			NetworkactivePlayerColorIndex = SaveManager.data.GetColorIndex();
		}
	}

	public override void OnStartLocalPlayer()
	{
		NetworkactivePlayerColorIndex = SaveManager.data.GetColorIndex();
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (base.isLocalPlayer)
		{
			NetworkactivePlayerColorIndex = SaveManager.data.GetColorIndex();
		}
	}

	[Command]
	public void CmdPlayFlash()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerColorManagerNetwork::CmdPlayFlash()", 1138618592, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcPlayFlash()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerColorManagerNetwork::RpcPlayFlash()", -1511647671, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlayFlash()
	{
		RpcPlayFlash();
	}

	protected static void InvokeUserCode_CmdPlayFlash(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayFlash called on client.");
		}
		else
		{
			((PlayerColorManagerNetwork)obj).UserCode_CmdPlayFlash();
		}
	}

	protected void UserCode_RpcPlayFlash()
	{
		playerColorManager.Flash();
	}

	protected static void InvokeUserCode_RpcPlayFlash(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayFlash called on server.");
		}
		else
		{
			((PlayerColorManagerNetwork)obj).UserCode_RpcPlayFlash();
		}
	}

	static PlayerColorManagerNetwork()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerColorManagerNetwork), "System.Void PlayerColorManagerNetwork::CmdPlayFlash()", InvokeUserCode_CmdPlayFlash, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerColorManagerNetwork), "System.Void PlayerColorManagerNetwork::RpcPlayFlash()", InvokeUserCode_RpcPlayFlash);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(activePlayerColorIndex);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(activePlayerColorIndex);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref activePlayerColorIndex, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref activePlayerColorIndex, null, reader.ReadVarInt());
		}
	}
}
