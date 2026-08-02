using JUTPS.InventorySystem;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class NetworkObjectSpawner : NetworkBehaviour
{
	public GameObject treeDestroyingParticle;

	public GameObject treeHitParticle;

	public static NetworkObjectSpawner Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void SetActiveObject(int i, bool visibility)
	{
		CmdSetActiveObject(i, visibility);
	}

	[ClientRpc]
	private void RPCTellHostToSetActiveObject(int i, bool visibility)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(i);
		writer.WriteBool(visibility);
		SendRPCInternal("System.Void NetworkObjectSpawner::RPCTellHostToSetActiveObject(System.Int32,System.Boolean)", 425599358, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetActiveObject(int i, bool visibility)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(i);
		writer.WriteBool(visibility);
		SendCommandInternal("System.Void NetworkObjectSpawner::CmdSetActiveObject(System.Int32,System.Boolean)", 230815071, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RPCTellHostToSetActiveObject__Int32__Boolean(int i, bool visibility)
	{
		GetComponentInParent<JUInventory>().SetActiveWeaponState(i, visibility);
	}

	protected static void InvokeUserCode_RPCTellHostToSetActiveObject__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RPCTellHostToSetActiveObject called on server.");
		}
		else
		{
			((NetworkObjectSpawner)obj).UserCode_RPCTellHostToSetActiveObject__Int32__Boolean(reader.ReadInt(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdSetActiveObject__Int32__Boolean(int i, bool visibility)
	{
		RPCTellHostToSetActiveObject(i, visibility);
	}

	protected static void InvokeUserCode_CmdSetActiveObject__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetActiveObject called on client.");
		}
		else
		{
			((NetworkObjectSpawner)obj).UserCode_CmdSetActiveObject__Int32__Boolean(reader.ReadInt(), reader.ReadBool());
		}
	}

	static NetworkObjectSpawner()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkObjectSpawner), "System.Void NetworkObjectSpawner::CmdSetActiveObject(System.Int32,System.Boolean)", InvokeUserCode_CmdSetActiveObject__Int32__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkObjectSpawner), "System.Void NetworkObjectSpawner::RPCTellHostToSetActiveObject(System.Int32,System.Boolean)", InvokeUserCode_RPCTellHostToSetActiveObject__Int32__Boolean);
	}
}
