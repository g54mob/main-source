using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class BearTrap : NetworkBehaviour
{
	public Animator trapAnim;

	public MonsterCheckEvent monsterCheckScript;

	public bool caught;

	public GameObject cantPlaceRadius;

	public GameObject curCantPlaceRadius;

	public Transform radiusPos;

	public Interactable interactable;

	public SaveSnapshotObject saveSnapshotObject;

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
		SendCommandInternal("System.Void BearTrap::TrapCmd()", 710101885, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TrapRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BearTrap::TrapRpc()", 1492779758, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
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
			((BearTrap)obj).UserCode_TrapCmd();
		}
	}

	protected void UserCode_TrapRpc()
	{
		saveSnapshotObject.instantiableID = 1;
		monsterCheckScript.CauseDistraction();
		trapAnim.SetTrigger("Catch");
		base.gameObject.SetActive(value: false);
		caught = true;
	}

	protected static void InvokeUserCode_TrapRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TrapRpc called on server.");
		}
		else
		{
			((BearTrap)obj).UserCode_TrapRpc();
		}
	}

	static BearTrap()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(BearTrap), "System.Void BearTrap::TrapCmd()", InvokeUserCode_TrapCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(BearTrap), "System.Void BearTrap::TrapRpc()", InvokeUserCode_TrapRpc);
	}
}
