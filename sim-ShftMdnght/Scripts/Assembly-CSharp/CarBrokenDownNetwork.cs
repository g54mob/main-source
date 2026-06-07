using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class CarBrokenDownNetwork : NetworkBehaviour
{
	public ChaseWhenNear chase;

	private bool alreadyEndedChase;

	public void StartChasing()
	{
		if (ClientPlayer.Instance.isServer)
		{
			StartChasingRpc();
		}
		else
		{
			StartChasingCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void StartChasingCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void CarBrokenDownNetwork::StartChasingCmd()", -1006130315, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void StartChasingRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CarBrokenDownNetwork::StartChasingRpc()", -1340199978, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void EndChasing()
	{
		if (!alreadyEndedChase)
		{
			if (ClientPlayer.Instance.isServer)
			{
				EndChasingRpc();
			}
			else
			{
				EndChasingCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void EndChasingCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void CarBrokenDownNetwork::EndChasingCmd()", 1435098700, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void EndChasingRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CarBrokenDownNetwork::EndChasingRpc()", -270910109, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_StartChasingCmd()
	{
		StartChasingRpc();
	}

	protected static void InvokeUserCode_StartChasingCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command StartChasingCmd called on client.");
		}
		else
		{
			((CarBrokenDownNetwork)obj).UserCode_StartChasingCmd();
		}
	}

	protected void UserCode_StartChasingRpc()
	{
		chase.StartChasing();
	}

	protected static void InvokeUserCode_StartChasingRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC StartChasingRpc called on server.");
		}
		else
		{
			((CarBrokenDownNetwork)obj).UserCode_StartChasingRpc();
		}
	}

	protected void UserCode_EndChasingCmd()
	{
		EndChasingRpc();
	}

	protected static void InvokeUserCode_EndChasingCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command EndChasingCmd called on client.");
		}
		else
		{
			((CarBrokenDownNetwork)obj).UserCode_EndChasingCmd();
		}
	}

	protected void UserCode_EndChasingRpc()
	{
		if (!alreadyEndedChase)
		{
			alreadyEndedChase = true;
			chase.EndChase();
		}
	}

	protected static void InvokeUserCode_EndChasingRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EndChasingRpc called on server.");
		}
		else
		{
			((CarBrokenDownNetwork)obj).UserCode_EndChasingRpc();
		}
	}

	static CarBrokenDownNetwork()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(CarBrokenDownNetwork), "System.Void CarBrokenDownNetwork::StartChasingCmd()", InvokeUserCode_StartChasingCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(CarBrokenDownNetwork), "System.Void CarBrokenDownNetwork::EndChasingCmd()", InvokeUserCode_EndChasingCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(CarBrokenDownNetwork), "System.Void CarBrokenDownNetwork::StartChasingRpc()", InvokeUserCode_StartChasingRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(CarBrokenDownNetwork), "System.Void CarBrokenDownNetwork::EndChasingRpc()", InvokeUserCode_EndChasingRpc);
	}
}
