using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class FlashlightVisible : NetworkBehaviour
{
	public GameObject visible;

	public GameObject invisible;

	public bool inspectable;

	public void FlashlightEnabled()
	{
		if (base.isServer)
		{
			FlashlightEnabledRpc();
		}
		else
		{
			FlashlightEnabledCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void FlashlightEnabledCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void FlashlightVisible::FlashlightEnabledCmd()", 2041081834, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void FlashlightEnabledRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void FlashlightVisible::FlashlightEnabledRpc()", -1378576931, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void FlashlightDisabled()
	{
		if (base.isServer)
		{
			FlashlightDisabledRpc();
		}
		else
		{
			FlashlightDisabledCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void FlashlightDisabledCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void FlashlightVisible::FlashlightDisabledCmd()", 1120273773, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void FlashlightDisabledRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void FlashlightVisible::FlashlightDisabledRpc()", -1510860706, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_FlashlightEnabledCmd()
	{
		FlashlightEnabledRpc();
	}

	protected static void InvokeUserCode_FlashlightEnabledCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command FlashlightEnabledCmd called on client.");
		}
		else
		{
			((FlashlightVisible)obj).UserCode_FlashlightEnabledCmd();
		}
	}

	protected void UserCode_FlashlightEnabledRpc()
	{
		visible.SetActive(value: true);
		invisible.SetActive(value: false);
	}

	protected static void InvokeUserCode_FlashlightEnabledRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC FlashlightEnabledRpc called on server.");
		}
		else
		{
			((FlashlightVisible)obj).UserCode_FlashlightEnabledRpc();
		}
	}

	protected void UserCode_FlashlightDisabledCmd()
	{
		FlashlightDisabledRpc();
	}

	protected static void InvokeUserCode_FlashlightDisabledCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command FlashlightDisabledCmd called on client.");
		}
		else
		{
			((FlashlightVisible)obj).UserCode_FlashlightDisabledCmd();
		}
	}

	protected void UserCode_FlashlightDisabledRpc()
	{
		visible.SetActive(value: false);
		invisible.SetActive(value: true);
	}

	protected static void InvokeUserCode_FlashlightDisabledRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC FlashlightDisabledRpc called on server.");
		}
		else
		{
			((FlashlightVisible)obj).UserCode_FlashlightDisabledRpc();
		}
	}

	static FlashlightVisible()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(FlashlightVisible), "System.Void FlashlightVisible::FlashlightEnabledCmd()", InvokeUserCode_FlashlightEnabledCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(FlashlightVisible), "System.Void FlashlightVisible::FlashlightDisabledCmd()", InvokeUserCode_FlashlightDisabledCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(FlashlightVisible), "System.Void FlashlightVisible::FlashlightEnabledRpc()", InvokeUserCode_FlashlightEnabledRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(FlashlightVisible), "System.Void FlashlightVisible::FlashlightDisabledRpc()", InvokeUserCode_FlashlightDisabledRpc);
	}
}
