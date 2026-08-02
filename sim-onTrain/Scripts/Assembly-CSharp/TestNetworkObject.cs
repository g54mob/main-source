using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TestNetworkObject : NetworkBehaviour
{
	[SyncVar]
	public string objectName = "Default Object";

	public string NetworkobjectName
	{
		get
		{
			return objectName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref objectName, 1uL, null);
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		Debug.Log($"Server: {objectName} başlatıldı. NetId: {base.netId}");
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		Debug.Log($"Client: {objectName} başlatıldı. NetId: {base.netId}");
	}

	[Command]
	public void CmdChangeName(string newName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(newName);
		SendCommandInternal("System.Void TestNetworkObject::CmdChangeName(System.String)", -1133601085, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcDisplayMessage(string message)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(message);
		SendRPCInternal("System.Void TestNetworkObject::RpcDisplayMessage(System.String)", 306534318, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdChangeName__String(string newName)
	{
		NetworkobjectName = newName;
		Debug.Log("Sunucu objenin adını değiştirdi: " + newName);
	}

	protected static void InvokeUserCode_CmdChangeName__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdChangeName called on client.");
		}
		else
		{
			((TestNetworkObject)obj).UserCode_CmdChangeName__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcDisplayMessage__String(string message)
	{
		Debug.Log("Client RPC Mesajı: " + message);
	}

	protected static void InvokeUserCode_RpcDisplayMessage__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcDisplayMessage called on server.");
		}
		else
		{
			((TestNetworkObject)obj).UserCode_RpcDisplayMessage__String(reader.ReadString());
		}
	}

	static TestNetworkObject()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TestNetworkObject), "System.Void TestNetworkObject::CmdChangeName(System.String)", InvokeUserCode_CmdChangeName__String, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(TestNetworkObject), "System.Void TestNetworkObject::RpcDisplayMessage(System.String)", InvokeUserCode_RpcDisplayMessage__String);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(objectName);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(objectName);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref objectName, null, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref objectName, null, reader.ReadString());
		}
	}
}
