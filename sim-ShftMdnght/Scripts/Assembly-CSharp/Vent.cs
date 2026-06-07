using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using UnityEngine;

public class Vent : Interactable
{
	public new PlayerManager curPlayerMan;

	public bool beingChecked;

	public Animator ventAnim;

	public bool playerIsCurrentlyInsideThisVent;

	public bool checkedRecently;

	public void Checked()
	{
		Invoke("NotCheckedRecently", 10f);
		checkedRecently = true;
		ventAnim.SetBool("Open", value: true);
		if (base.isServer)
		{
			ChangeInteractableStatusRpc(change: false);
		}
		else
		{
			ChangeInteractableStatusCmd(change: false);
		}
		Invoke("InteractableAgain", 3f);
	}

	private void InteractableAgain()
	{
		if (base.isServer)
		{
			ChangeInteractableStatusRpc(change: true);
		}
		else
		{
			ChangeInteractableStatusCmd(change: true);
		}
	}

	private void NotCheckedRecently()
	{
		checkedRecently = false;
	}

	public override void Interact(PlayerManager playerMan)
	{
		if (interactable)
		{
			if (PlayerPrefs.GetInt("VentsHint") != 1)
			{
				StoreManager.Instance.AddHint("<CROUCH BIND> to crouch and enter vents.");
				StoreManager.Instance.NextHint();
				PlayerPrefs.SetInt("VentsHint", 1);
			}
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
		SendCommandInternal("System.Void Vent::InteractCmd(PlayerManager)", -1963426594, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void Vent::ActuallyInteract(PlayerManager)", 531528887, writer, 0, includeOwner: true);
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
			((Vent)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
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
		ventAnim.SetBool("Open", !ventAnim.GetBool("Open"));
		curPlayerMan = playerMan;
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((Vent)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	static Vent()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Vent), "System.Void Vent::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Vent), "System.Void Vent::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
	}
}
