using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TurnOffIfMultiplayer : NetworkBehaviour
{
	public GameObject multiplayerObj;

	public GameObject singleplayerObj;

	private void OnEnable()
	{
		CheckPlayers();
		Invoke("CheckPlayers", 1f);
		Invoke("CheckPlayers", 2f);
		Invoke("CheckPlayers", 3f);
		Invoke("CheckPlayers", 4f);
		Invoke("CheckPlayers", 5f);
	}

	private void CheckPlayers()
	{
		if (base.isServer)
		{
			CheckObjectsRpc(NetworkServer.connections.Count);
		}
	}

	[ClientRpc]
	private void CheckObjectsRpc(int x)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(x);
		SendRPCInternal("System.Void TurnOffIfMultiplayer::CheckObjectsRpc(System.Int32)", 1114484914, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CheckObjectsRpc__Int32(int x)
	{
		if (x > 1)
		{
			if ((bool)multiplayerObj)
			{
				multiplayerObj.SetActive(value: true);
			}
			if ((bool)singleplayerObj)
			{
				singleplayerObj.SetActive(value: false);
			}
		}
		else
		{
			if ((bool)multiplayerObj)
			{
				multiplayerObj.SetActive(value: false);
			}
			if ((bool)singleplayerObj)
			{
				singleplayerObj.SetActive(value: true);
			}
		}
	}

	protected static void InvokeUserCode_CheckObjectsRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CheckObjectsRpc called on server.");
		}
		else
		{
			((TurnOffIfMultiplayer)obj).UserCode_CheckObjectsRpc__Int32(reader.ReadVarInt());
		}
	}

	static TurnOffIfMultiplayer()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(TurnOffIfMultiplayer), "System.Void TurnOffIfMultiplayer::CheckObjectsRpc(System.Int32)", InvokeUserCode_CheckObjectsRpc__Int32);
	}
}
