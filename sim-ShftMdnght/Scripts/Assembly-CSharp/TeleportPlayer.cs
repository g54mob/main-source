using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TeleportPlayer : NetworkBehaviour
{
	[SerializeField]
	private CharacterController cc;

	public override void OnStartAuthority()
	{
		if (cc == null)
		{
			cc = GetComponent<CharacterController>();
		}
	}

	public void RequestTeleport(Vector3 targetPos)
	{
		if (base.isServer)
		{
			TeleportInternal(targetPos);
		}
		else
		{
			CmdTeleport(targetPos);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTeleport(Vector3 targetPos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(targetPos);
		SendCommandInternal("System.Void TeleportPlayer::CmdTeleport(UnityEngine.Vector3)", -2091173301, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcTeleport(Vector3 targetPos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(targetPos);
		SendRPCInternal("System.Void TeleportPlayer::RpcTeleport(UnityEngine.Vector3)", -1359226674, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void TeleportInternal(Vector3 targetPos)
	{
		if (cc == null)
		{
			cc = GetComponent<CharacterController>();
		}
		bool flag = cc != null && cc.enabled;
		if (cc != null)
		{
			cc.enabled = false;
		}
		base.transform.position = targetPos;
		if (cc != null)
		{
			cc.enabled = flag;
		}
		if (ClientPlayer.Instance.playerMan.curChangeEnvLightingCoroutine != null)
		{
			StopCoroutine(ClientPlayer.Instance.playerMan.curChangeEnvLightingCoroutine);
		}
		ClientPlayer.Instance.playerMan.curChangeEnvLightingCoroutine = StartCoroutine(ClientPlayer.Instance.playerMan.ChangeEnvironmentLighting(Color.black, 0.01f, 3f));
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdTeleport__Vector3(Vector3 targetPos)
	{
		TeleportInternal(targetPos);
		RpcTeleport(targetPos);
	}

	protected static void InvokeUserCode_CmdTeleport__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTeleport called on client.");
		}
		else
		{
			((TeleportPlayer)obj).UserCode_CmdTeleport__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_RpcTeleport__Vector3(Vector3 targetPos)
	{
		TeleportInternal(targetPos);
	}

	protected static void InvokeUserCode_RpcTeleport__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTeleport called on server.");
		}
		else
		{
			((TeleportPlayer)obj).UserCode_RpcTeleport__Vector3(reader.ReadVector3());
		}
	}

	static TeleportPlayer()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TeleportPlayer), "System.Void TeleportPlayer::CmdTeleport(UnityEngine.Vector3)", InvokeUserCode_CmdTeleport__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TeleportPlayer), "System.Void TeleportPlayer::RpcTeleport(UnityEngine.Vector3)", InvokeUserCode_RpcTeleport__Vector3);
	}
}
