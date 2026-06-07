using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class ScaryVentGirl : NetworkBehaviour
{
	public Animator anim;

	public bool someoneHoldingGun;

	public bool explosiveArmed;

	public void CheckWhetherToHide()
	{
		if (someoneHoldingGun || explosiveArmed)
		{
			anim.SetBool("Hide", value: true);
		}
		else
		{
			anim.SetBool("Hide", value: false);
		}
	}

	public void ChangeHoldingGunStatus(bool x)
	{
		if (base.isServer)
		{
			ChangeHoldingGunStatusRpc(x);
		}
		else
		{
			ChangeHoldingGunStatusCmd(x);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeHoldingGunStatusCmd(bool x)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(x);
		SendCommandInternal("System.Void ScaryVentGirl::ChangeHoldingGunStatusCmd(System.Boolean)", -1165467566, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeHoldingGunStatusRpc(bool x)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(x);
		SendRPCInternal("System.Void ScaryVentGirl::ChangeHoldingGunStatusRpc(System.Boolean)", -1061797303, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeHoldingGunStatusCmd__Boolean(bool x)
	{
		ChangeHoldingGunStatusRpc(x);
	}

	protected static void InvokeUserCode_ChangeHoldingGunStatusCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeHoldingGunStatusCmd called on client.");
		}
		else
		{
			((ScaryVentGirl)obj).UserCode_ChangeHoldingGunStatusCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeHoldingGunStatusRpc__Boolean(bool x)
	{
		someoneHoldingGun = x;
		CheckWhetherToHide();
	}

	protected static void InvokeUserCode_ChangeHoldingGunStatusRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeHoldingGunStatusRpc called on server.");
		}
		else
		{
			((ScaryVentGirl)obj).UserCode_ChangeHoldingGunStatusRpc__Boolean(reader.ReadBool());
		}
	}

	static ScaryVentGirl()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ScaryVentGirl), "System.Void ScaryVentGirl::ChangeHoldingGunStatusCmd(System.Boolean)", InvokeUserCode_ChangeHoldingGunStatusCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ScaryVentGirl), "System.Void ScaryVentGirl::ChangeHoldingGunStatusRpc(System.Boolean)", InvokeUserCode_ChangeHoldingGunStatusRpc__Boolean);
	}
}
