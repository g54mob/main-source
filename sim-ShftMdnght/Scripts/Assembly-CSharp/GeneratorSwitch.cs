using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class GeneratorSwitch : Interactable
{
	public bool powerOff;

	public override void Interact(PlayerManager playerMan)
	{
		if (!powerOff)
		{
			StoreManager.Instance.SetAlert("No need to reset the generator.", "red");
			return;
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject gameObject in array)
		{
			PlayerManager component = gameObject.GetComponent<PlayerManager>();
			if (!component.dead && !component.downed && Vector3.Distance(gameObject.transform.position, base.transform.position) > 7f)
			{
				StoreManager.Instance.SetAlert("All hands are needed to pull this switch.", "red");
				return;
			}
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
	public override void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void GeneratorSwitch::InteractCmd(PlayerManager)", 485108648, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void GeneratorSwitch::ActuallyInteract(PlayerManager)", -1459273667, writer, 0, includeOwner: true);
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
			((GeneratorSwitch)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected override void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
	{
		if (interactable)
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
		}
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((GeneratorSwitch)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	static GeneratorSwitch()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GeneratorSwitch), "System.Void GeneratorSwitch::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(GeneratorSwitch), "System.Void GeneratorSwitch::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
	}
}
