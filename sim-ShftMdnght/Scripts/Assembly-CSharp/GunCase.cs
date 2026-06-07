using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using UnityEngine;

public class GunCase : Interactable
{
	public string destroyObjectTag;

	public int objIndex;

	public bool allowEveryoneToHave;

	public override void Interact(PlayerManager playerMan)
	{
		if (playerMan.downed)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < playerMan.inventoryMan.maxInventorySlots; i++)
		{
			if (playerMan.inventoryMan.inventoryIds[i] == -1)
			{
				flag = true;
				break;
			}
			if (playerMan.inventoryMan.inventoryAmounts[i] < playerMan.inventoryMan.maxStack[playerMan.inventoryMan.inventoryIds[i]] && playerMan.inventoryMan.inventoryIds[i] == objIndex)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			StoreManager.Instance.SetAlert("Your inventory is full!", "red");
		}
		else if (base.isServer)
		{
			ActuallyInteract(playerMan);
		}
		else
		{
			InteractCmd(playerMan);
		}
	}

	[Command(requiresAuthority = false)]
	public override void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void GunCase::InteractCmd(PlayerManager)", 856764835, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void GunCase::ActuallyInteract(PlayerManager)", 517598192, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected override void UserCode_InteractCmd__PlayerManager(PlayerManager playerMan)
	{
		ActuallyInteract(playerMan);
	}

	protected new static void InvokeUserCode_InteractCmd__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command InteractCmd called on client.");
		}
		else
		{
			((GunCase)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected override void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
	{
		if (!interactable)
		{
			return;
		}
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2 && playerMan == ClientPlayer.Instance.playerMan)
		{
			StoreManager.Instance.SetAlert("Complete the tutorial first", "red");
			return;
		}
		if (base.isServer)
		{
			NetworkServer.Destroy(GameObject.FindWithTag(destroyObjectTag));
		}
		if (playerMan != ClientPlayer.Instance.playerMan)
		{
			return;
		}
		if (playerMan.inventoryMan.curInventorySlot >= 0 && playerMan.inventoryMan.trash[playerMan.inventoryMan.curInventorySlot] > 0 && playerMan.inventoryMan.holdingIndex == 6)
		{
			StoreManager.Instance.SetAlert("Must take trash out back to the dumpster!", "red");
			return;
		}
		if (interactSFX != null)
		{
			interactSFX.Play();
		}
		if (interactAnim != null)
		{
			interactAnim.SetTrigger("Interact");
		}
		interactEvent.Invoke();
		if (useInteractCooldown)
		{
			global::OutlineFx.OutlineFx[] array = outlines;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			if (base.isServer)
			{
				ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				ChangeInteractableStatusCmd(change: false);
			}
			Invoke("CanInteract", interactCooldown);
		}
		if (!interactable)
		{
			return;
		}
		GameObject[] array2 = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject gameObject in array2)
		{
			if (gameObject.GetComponent<InventoryManager>().hasGun)
			{
				if (gameObject == ClientPlayer.Instance.gameObject)
				{
					ClientPlayer.Instance.inventoryMan.DestroyObject();
				}
				else
				{
					StoreManager.Instance.SetAlert("Someone is already holding this.", "red");
				}
				return;
			}
		}
		ClientPlayer.Instance.inventoryMan.PickupNewObj(objIndex, 6);
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((GunCase)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	static GunCase()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GunCase), "System.Void GunCase::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(GunCase), "System.Void GunCase::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
	}
}
