using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class Barricade : ConstrictedInteractable
{
	public GameObject colliderHolder;

	public GameObject barricade;

	public Animator doorAnim;

	public Interactable door;

	public EntryDoor entryDoor;

	public GameObject plankDrop;

	public Hittable hittable;

	public void Place()
	{
		if (base.isServer)
		{
			PlaceRpc();
		}
		else
		{
			PlaceCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void PlaceCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Barricade::PlaceCmd()", -906319855, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void PlaceRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Barricade::PlaceRpc()", 375181042, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void BarricadeDestroyed()
	{
		if (base.isServer)
		{
			NetworkServer.Spawn(Object.Instantiate(plankDrop, base.transform.position, Quaternion.identity));
		}
		ClientPlayer.Instance.inventoryMan.Invoke("CheckConstrictedInteractables", 0.3f);
	}

	public override void CheckForCurItem(int curIndex)
	{
		if (barricade.activeInHierarchy)
		{
			colliderHolder.SetActive(value: false);
			return;
		}
		for (int i = 0; i < allowedItems.Length; i++)
		{
			if (curIndex == allowedItems[i])
			{
				colliderHolder.SetActive(value: true);
				constrictionAllows = true;
				return;
			}
		}
		constrictionAllows = false;
		colliderHolder.SetActive(value: false);
		StopLookAt();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_PlaceCmd()
	{
		PlaceRpc();
	}

	protected static void InvokeUserCode_PlaceCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PlaceCmd called on client.");
		}
		else
		{
			((Barricade)obj).UserCode_PlaceCmd();
		}
	}

	protected void UserCode_PlaceRpc()
	{
		if ((bool)door)
		{
			door.ChangeInteractableStatus(change: false);
		}
		else
		{
			entryDoor.canEnter = false;
		}
		doorAnim.SetTrigger("CloseDoor");
		barricade.SetActive(value: true);
	}

	protected static void InvokeUserCode_PlaceRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PlaceRpc called on server.");
		}
		else
		{
			((Barricade)obj).UserCode_PlaceRpc();
		}
	}

	static Barricade()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Barricade), "System.Void Barricade::PlaceCmd()", InvokeUserCode_PlaceCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Barricade), "System.Void Barricade::PlaceRpc()", InvokeUserCode_PlaceRpc);
	}
}
