using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class HuntPanel : NetworkBehaviour
{
	public Animator panelCoverAnim;

	public static HuntPanel Instance { get; private set; }

	public void RevealPanel()
	{
		if (base.isServer)
		{
			RevealPanelRpc();
		}
		else
		{
			RevealPanelCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void RevealPanelCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void HuntPanel::RevealPanelCmd()", -1165399775, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RevealPanelRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void HuntPanel::RevealPanelRpc()", 1467781634, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RevealPanelCmd()
	{
		RevealPanelRpc();
	}

	protected static void InvokeUserCode_RevealPanelCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RevealPanelCmd called on client.");
		}
		else
		{
			((HuntPanel)obj).UserCode_RevealPanelCmd();
		}
	}

	protected void UserCode_RevealPanelRpc()
	{
		panelCoverAnim.enabled = true;
	}

	protected static void InvokeUserCode_RevealPanelRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RevealPanelRpc called on server.");
		}
		else
		{
			((HuntPanel)obj).UserCode_RevealPanelRpc();
		}
	}

	static HuntPanel()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(HuntPanel), "System.Void HuntPanel::RevealPanelCmd()", InvokeUserCode_RevealPanelCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(HuntPanel), "System.Void HuntPanel::RevealPanelRpc()", InvokeUserCode_RevealPanelRpc);
	}
}
