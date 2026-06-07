using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using UnityEngine;

public class Trash : ConstrictedInteractable
{
	public new PlayerManager curPlayerMan;

	public Animator trashAnim;

	public bool dontCountTowardHygiene;

	private void OnEnable()
	{
		if (!dontCountTowardHygiene)
		{
			ReviewsManager.Instance.UpdateHygienePenalty(1);
		}
	}

	public override void Start()
	{
		if ((bool)ClientPlayer.Instance)
		{
			ClientPlayer.Instance.inventoryMan.Invoke("CheckConstrictedInteractables", 1f);
		}
		base.Start();
	}

	public override void Interact(PlayerManager playerMan)
	{
		if (interactable && constrictionAllows)
		{
			StoreManager.Instance.dumpsterOutline.enabled = true;
			if (base.isServer)
			{
				ActuallyInteract(playerMan);
			}
			else
			{
				InteractCmd(playerMan);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public override void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void Trash::InteractCmd(PlayerManager)", -1139718793, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void Trash::ActuallyInteract(PlayerManager)", -1077935732, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Delete()
	{
		NetworkServer.Destroy(base.gameObject);
	}

	private void OnDisable()
	{
		if (!dontCountTowardHygiene)
		{
			ReviewsManager.Instance.UpdateHygienePenalty(-1);
		}
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
			((Trash)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected override void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
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
		curPlayerMan = playerMan;
		base.StopLookAt();
		if (base.isServer)
		{
			ChangeInteractableStatusRpc(change: false);
		}
		else
		{
			ChangeInteractableStatusCmd(change: false);
		}
		trashAnim.enabled = true;
		playerMan.inventoryMan.AddTrash();
		Invoke("Delete", 0.5f);
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((Trash)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	static Trash()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Trash), "System.Void Trash::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Trash), "System.Void Trash::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
	}
}
