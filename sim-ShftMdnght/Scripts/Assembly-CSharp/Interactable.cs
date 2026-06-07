using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : NetworkBehaviour
{
	public bool interactable = true;

	public global::OutlineFx.OutlineFx[] outlines;

	public string interactText;

	public AudioSource interactSFX;

	public Animator interactAnim;

	public UnityEvent interactEvent;

	public bool onlyInvokeEventLocally;

	public float interactCooldown;

	public bool useInteractCooldown;

	public bool holdInteractable;

	public float holdInteractableTime;

	public bool boardedUp;

	public UnityEvent startInteractingEvent;

	public UnityEvent stopInteractingEvent;

	public PlayerManager curPlayerMan;

	public UnityEvent eventEvent;

	public virtual void Start()
	{
		global::OutlineFx.OutlineFx[] array = outlines;
		foreach (global::OutlineFx.OutlineFx outlineFx in array)
		{
			if ((bool)outlineFx)
			{
				outlineFx.Alpha = 1f;
				outlineFx.enabled = false;
			}
		}
	}

	public void ChangeInteractableStatus(bool change)
	{
		if (base.isServer)
		{
			ChangeInteractableStatusRpc(change);
		}
		else
		{
			ChangeInteractableStatusCmd(change);
		}
	}

	[Command(requiresAuthority = false)]
	public void ChangeInteractableStatusCmd(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendCommandInternal("System.Void Interactable::ChangeInteractableStatusCmd(System.Boolean)", 939693956, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChangeInteractableStatusRpc(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendRPCInternal("System.Void Interactable::ChangeInteractableStatusRpc(System.Boolean)", -188160601, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public virtual void LookAt()
	{
		if (interactable)
		{
			global::OutlineFx.OutlineFx[] array = outlines;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
		}
	}

	public virtual void StopLookAt()
	{
		global::OutlineFx.OutlineFx[] array = outlines;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
	}

	public void InvokeScan()
	{
	}

	private void Scan()
	{
		AstarPath.Instance.Scan();
	}

	public virtual void Interact(PlayerManager playerMan)
	{
		curPlayerMan = playerMan;
		if (onlyInvokeEventLocally)
		{
			interactEvent.Invoke();
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

	[Command(requiresAuthority = false)]
	public virtual void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void Interactable::InteractCmd(PlayerManager)", 2043721287, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public virtual void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void Interactable::ActuallyInteract(PlayerManager)", 405716380, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void OpenHatsLocker()
	{
		ClientPlayer.Instance.playerMan.OpenCustomizablesMenu();
	}

	public void ReInvokeInteractCooldown()
	{
		if (base.isServer)
		{
			ReInvokeInteractCooldownRpc();
		}
		else
		{
			ReInvokeInteractCooldownCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void ReInvokeInteractCooldownCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Interactable::ReInvokeInteractCooldownCmd()", 1631540271, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ReInvokeInteractCooldownRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Interactable::ReInvokeInteractCooldownRpc()", 1926413596, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void DestroyItself()
	{
		if (base.isServer)
		{
			DestroyItselfRpc();
		}
		else
		{
			DestroyItselfCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void DestroyItselfCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Interactable::DestroyItselfCmd()", 1824442890, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void DestroyItselfRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Interactable::DestroyItselfRpc()", 1315438333, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void CanInteract()
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

	public void FirstAidKit()
	{
		if (SaveManager.Instance.tokens < 3)
		{
			if (curPlayerMan == ClientPlayer.Instance.playerMan)
			{
				StoreManager.Instance.SetAlert("Not enough funds.", "red");
			}
		}
		else
		{
			PurchaseWithTokens(3);
			eventEvent.Invoke();
		}
	}

	public void Health(int x)
	{
		curPlayerMan.Heal(x);
	}

	public void PurchaseWithTokens(int cost)
	{
		if (base.isServer)
		{
			StoreManager.Instance.ChangeTokenBalance(-cost);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeInteractableStatusCmd__Boolean(bool change)
	{
		ChangeInteractableStatusRpc(change);
	}

	protected static void InvokeUserCode_ChangeInteractableStatusCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeInteractableStatusCmd called on client.");
		}
		else
		{
			((Interactable)obj).UserCode_ChangeInteractableStatusCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeInteractableStatusRpc__Boolean(bool change)
	{
		interactable = change;
		global::OutlineFx.OutlineFx[] array = outlines;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
	}

	protected static void InvokeUserCode_ChangeInteractableStatusRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeInteractableStatusRpc called on server.");
		}
		else
		{
			((Interactable)obj).UserCode_ChangeInteractableStatusRpc__Boolean(reader.ReadBool());
		}
	}

	protected virtual void UserCode_InteractCmd__PlayerManager(PlayerManager playerMan)
	{
		ActuallyInteract(playerMan);
	}

	protected static void InvokeUserCode_InteractCmd__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command InteractCmd called on client.");
		}
		else
		{
			((Interactable)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected virtual void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
	{
		if (!interactable)
		{
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
		curPlayerMan = playerMan;
		if (!onlyInvokeEventLocally)
		{
			interactEvent.Invoke();
		}
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
	}

	protected static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((Interactable)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_ReInvokeInteractCooldownCmd()
	{
		ReInvokeInteractCooldownRpc();
	}

	protected static void InvokeUserCode_ReInvokeInteractCooldownCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ReInvokeInteractCooldownCmd called on client.");
		}
		else
		{
			((Interactable)obj).UserCode_ReInvokeInteractCooldownCmd();
		}
	}

	protected void UserCode_ReInvokeInteractCooldownRpc()
	{
		CancelInvoke("CanInteract");
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

	protected static void InvokeUserCode_ReInvokeInteractCooldownRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ReInvokeInteractCooldownRpc called on server.");
		}
		else
		{
			((Interactable)obj).UserCode_ReInvokeInteractCooldownRpc();
		}
	}

	protected void UserCode_DestroyItselfCmd()
	{
		DestroyItselfRpc();
	}

	protected static void InvokeUserCode_DestroyItselfCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DestroyItselfCmd called on client.");
		}
		else
		{
			((Interactable)obj).UserCode_DestroyItselfCmd();
		}
	}

	protected void UserCode_DestroyItselfRpc()
	{
		if (base.isServer)
		{
			NetworkServer.Destroy(base.gameObject);
		}
	}

	protected static void InvokeUserCode_DestroyItselfRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DestroyItselfRpc called on client.");
		}
		else
		{
			((Interactable)obj).UserCode_DestroyItselfRpc();
		}
	}

	static Interactable()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Interactable), "System.Void Interactable::ChangeInteractableStatusCmd(System.Boolean)", InvokeUserCode_ChangeInteractableStatusCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Interactable), "System.Void Interactable::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Interactable), "System.Void Interactable::ReInvokeInteractCooldownCmd()", InvokeUserCode_ReInvokeInteractCooldownCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Interactable), "System.Void Interactable::DestroyItselfCmd()", InvokeUserCode_DestroyItselfCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Interactable), "System.Void Interactable::DestroyItselfRpc()", InvokeUserCode_DestroyItselfRpc, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Interactable), "System.Void Interactable::ChangeInteractableStatusRpc(System.Boolean)", InvokeUserCode_ChangeInteractableStatusRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(Interactable), "System.Void Interactable::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
		RemoteProcedureCalls.RegisterRpc(typeof(Interactable), "System.Void Interactable::ReInvokeInteractCooldownRpc()", InvokeUserCode_ReInvokeInteractCooldownRpc);
	}
}
