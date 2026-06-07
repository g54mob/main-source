using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class Landmine : NetworkBehaviour
{
	public MonsterCheckEvent monsterCheckScript;

	public GameObject cantPlaceRadius;

	public GameObject curCantPlaceRadius;

	public Transform radiusPos;

	public Interactable interactable;

	public AudioSource landmineBeep;

	public GameObject explosion;

	public void EnableRadius()
	{
		interactable.interactable = false;
		curCantPlaceRadius.SetActive(value: true);
	}

	public void DisableRadius()
	{
		interactable.interactable = true;
		curCantPlaceRadius.SetActive(value: false);
	}

	private void Start()
	{
		curCantPlaceRadius = Object.Instantiate(cantPlaceRadius, radiusPos.position, Quaternion.identity);
		curCantPlaceRadius.SetActive(value: false);
		if (ClientPlayer.Instance.inventoryMan.holdingIndex == 7)
		{
			ClientPlayer.Instance.inventoryMan.Invoke("TurnOnBearTrapRadii", 1f);
		}
	}

	private void OnDisable()
	{
		Object.Destroy(curCantPlaceRadius);
	}

	public void Trap()
	{
		if (ClientPlayer.Instance.playerMan.isServer)
		{
			TrapRpc();
		}
		else
		{
			TrapCmd();
		}
		interactable.ChangeInteractableStatus(change: true);
	}

	[Command(requiresAuthority = false)]
	private void TrapCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Landmine::TrapCmd()", 1547026988, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TrapRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Landmine::TrapRpc()", -1967855549, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SpawnExplosion()
	{
		if (base.isServer)
		{
			NetworkServer.Spawn(Object.Instantiate(explosion, base.transform.position, Quaternion.identity));
		}
		monsterCheckScript.CauseDistraction();
		base.transform.root.gameObject.SetActive(value: false);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TrapCmd()
	{
		TrapRpc();
	}

	protected static void InvokeUserCode_TrapCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command TrapCmd called on client.");
		}
		else
		{
			((Landmine)obj).UserCode_TrapCmd();
		}
	}

	protected void UserCode_TrapRpc()
	{
		Invoke("SpawnExplosion", 0.4f);
		base.gameObject.SetActive(value: false);
		landmineBeep.Play();
	}

	protected static void InvokeUserCode_TrapRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TrapRpc called on server.");
		}
		else
		{
			((Landmine)obj).UserCode_TrapRpc();
		}
	}

	static Landmine()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Landmine), "System.Void Landmine::TrapCmd()", InvokeUserCode_TrapCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Landmine), "System.Void Landmine::TrapRpc()", InvokeUserCode_TrapRpc);
	}
}
