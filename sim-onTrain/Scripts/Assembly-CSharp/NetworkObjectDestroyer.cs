using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class NetworkObjectDestroyer : NetworkBehaviour
{
	public static NetworkObjectDestroyer Instance;

	private void Awake()
	{
		Instance = this;
	}

	[ClientRpc]
	private void TellServerToDestroyObject(GameObject obj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(obj);
		SendRPCInternal("System.Void NetworkObjectDestroyer::TellServerToDestroyObject(UnityEngine.GameObject)", 475894501, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdDestroyObject(GameObject obj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(obj);
		SendCommandInternal("System.Void NetworkObjectDestroyer::CmdDestroyObject(UnityEngine.GameObject)", -1417029578, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TellServerToDestroyObject__GameObject(GameObject obj)
	{
		NetworkServer.Destroy(obj);
	}

	protected static void InvokeUserCode_TellServerToDestroyObject__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TellServerToDestroyObject called on server.");
		}
		else
		{
			((NetworkObjectDestroyer)obj).UserCode_TellServerToDestroyObject__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_CmdDestroyObject__GameObject(GameObject obj)
	{
		if ((bool)obj)
		{
			TellServerToDestroyObject(obj);
		}
	}

	protected static void InvokeUserCode_CmdDestroyObject__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDestroyObject called on client.");
		}
		else
		{
			((NetworkObjectDestroyer)obj).UserCode_CmdDestroyObject__GameObject(reader.ReadGameObject());
		}
	}

	static NetworkObjectDestroyer()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkObjectDestroyer), "System.Void NetworkObjectDestroyer::CmdDestroyObject(UnityEngine.GameObject)", InvokeUserCode_CmdDestroyObject__GameObject, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkObjectDestroyer), "System.Void NetworkObjectDestroyer::TellServerToDestroyObject(UnityEngine.GameObject)", InvokeUserCode_TellServerToDestroyObject__GameObject);
	}
}
