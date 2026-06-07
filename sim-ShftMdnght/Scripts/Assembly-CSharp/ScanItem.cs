using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using UnityEngine;

public class ScanItem : Interactable
{
	public Animator collectAnimator;

	public int objectIndex;

	public Collider col;

	public int cost;

	public override void Interact(PlayerManager playerMan)
	{
		if (interactable)
		{
			if (base.isServer)
			{
				InteractRpc();
			}
			else
			{
				InteractCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void InteractCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ScanItem::InteractCmd()", -250114757, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void InteractRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ScanItem::InteractRpc()", -2067724168, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_InteractCmd()
	{
		InteractRpc();
	}

	protected static void InvokeUserCode_InteractCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command InteractCmd called on client.");
		}
		else
		{
			((ScanItem)obj).UserCode_InteractCmd();
		}
	}

	protected void UserCode_InteractRpc()
	{
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
		base.StopLookAt();
		if (base.isServer)
		{
			ChangeInteractableStatusRpc(change: false);
		}
		else
		{
			ChangeInteractableStatusCmd(change: false);
		}
		collectAnimator.enabled = true;
		TransactionManager.Instance.ItemScanned(cost);
		Object.Destroy(base.gameObject, 1.5f);
	}

	protected static void InvokeUserCode_InteractRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC InteractRpc called on server.");
		}
		else
		{
			((ScanItem)obj).UserCode_InteractRpc();
		}
	}

	static ScanItem()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ScanItem), "System.Void ScanItem::InteractCmd()", InvokeUserCode_InteractCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ScanItem), "System.Void ScanItem::InteractRpc()", InvokeUserCode_InteractRpc);
	}
}
