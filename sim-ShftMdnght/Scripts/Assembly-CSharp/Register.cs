using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class Register : Interactable
{
	public AudioSource bellSFX;

	public bool canCompleteTransaction;

	public override void Interact(PlayerManager playerMan)
	{
		base.StopLookAt();
		if (!canCompleteTransaction)
		{
			StoreManager.Instance.SetAlert("Bag all items first!", "red");
			return;
		}
		if (!TransactionManager.Instance.canTransact)
		{
			if (StoreManager.Instance.playerMans.Count > 1)
			{
				StoreManager.Instance.SetAlert("ALL players must complete the tutorial first.", "red");
			}
			else
			{
				StoreManager.Instance.SetAlert("Complete other parts of the tutorial first!", "red");
			}
			return;
		}
		TransactionManager.Instance.CompleteTransaction();
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
	public override void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void Register::InteractCmd(PlayerManager)", 271272648, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void Register::ActuallyInteract(PlayerManager)", 530503261, writer, 0, includeOwner: true);
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
			((Register)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected override void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
	{
		bellSFX.Play();
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((Register)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	static Register()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Register), "System.Void Register::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Register), "System.Void Register::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
	}
}
