using System;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerReveiver : NetworkBehaviour, IInteractable
{
	private bool isActive = true;

	private bool isInteracting;

	[SerializeField]
	private Transform interactionParent;

	private TSPlayerController reveivingPlayer;

	public float reveivingTime = 10f;

	public TSPlayerController player;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	private void OnDisable()
	{
		if (reveivingPlayer != null)
		{
			TsPlayerAnimationController componentInChildren = reveivingPlayer.GetComponentInChildren<TsPlayerAnimationController>();
			if (componentInChildren != null)
			{
				componentInChildren.StopCPR();
			}
			FPSArmsAnimationController component = reveivingPlayer.GetComponent<FPSArmsAnimationController>();
			if (component != null)
			{
				component.StopCPR();
			}
			TSPlayerStatusHolder component2 = reveivingPlayer.GetComponent<TSPlayerStatusHolder>();
			if (component2 != null)
			{
				component2.isCPR = false;
			}
			Interactor component3 = reveivingPlayer.GetComponent<Interactor>();
			if (component3 != null)
			{
				component3.lastInteractable = null;
			}
		}
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HidePanels();
		}
		isInteracting = false;
		reveivingPlayer = null;
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (isInteracting || player == null || !player.isDeath)
		{
			return;
		}
		reveivingPlayer = playerInventory.GetComponent<TSPlayerController>();
		isInteracting = true;
		List<InteractionData> list = new List<InteractionData>();
		if (Enum.TryParse<KeyCode>(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey.ToString(), out var result))
		{
			list.Add(new InteractionData(result, "Revieve", hasHoldAction: true, reveivingTime, delegate
			{
				CmdReveivePlayer();
			}, delegate
			{
				StartCPRAnimation();
			}, delegate
			{
				StopCPRAnimation();
			}));
		}
		InteractionPanel.Instance.ShowMultipleInteractionOnOverlay(base.transform, playerInventory.transform, list);
	}

	public void StartCPRAnimation()
	{
		Debug.Log("StartCPRAnimation called");
		if (reveivingPlayer == null)
		{
			Debug.Log("reveivingPlayer is null!");
			return;
		}
		TsPlayerAnimationController componentInChildren = reveivingPlayer.GetComponentInChildren<TsPlayerAnimationController>();
		if (componentInChildren == null)
		{
			Debug.Log("TsPlayerAnimationController is null!");
			return;
		}
		FPSArmsAnimationController component = reveivingPlayer.GetComponent<FPSArmsAnimationController>();
		TSPlayerStatusHolder component2 = reveivingPlayer.GetComponent<TSPlayerStatusHolder>();
		if (component2 != null)
		{
			component2.isCPR = true;
		}
		Debug.Log("Starting CPR animation for player (TPS + FPS)");
		componentInChildren.CPR();
		if (component != null)
		{
			component.StartCPR();
		}
	}

	public void StopCPRAnimation()
	{
		Debug.Log("StopCPRAnimation called");
		if (reveivingPlayer == null)
		{
			Debug.Log("reveivingPlayer is null!");
			return;
		}
		TsPlayerAnimationController componentInChildren = reveivingPlayer.GetComponentInChildren<TsPlayerAnimationController>();
		if (componentInChildren == null)
		{
			Debug.Log("TsPlayerAnimationController is null!");
			return;
		}
		FPSArmsAnimationController component = reveivingPlayer.GetComponent<FPSArmsAnimationController>();
		TSPlayerStatusHolder component2 = reveivingPlayer.GetComponent<TSPlayerStatusHolder>();
		if (component2 != null)
		{
			component2.isCPR = false;
		}
		Debug.Log("Stopping CPR animation for player (TPS + FPS)");
		componentInChildren.StopCPR();
		if (component != null)
		{
			component.StopCPR();
		}
	}

	public void StopInteract()
	{
		Debug.Log("Stop interact");
		isInteracting = false;
		InteractionPanel.Instance.HidePanels();
		if (reveivingPlayer != null)
		{
			Interactor component = reveivingPlayer.GetComponent<Interactor>();
			if (component != null)
			{
				component.lastInteractable = null;
			}
			TSPlayerStatusHolder component2 = reveivingPlayer.GetComponent<TSPlayerStatusHolder>();
			if (component2 != null)
			{
				component2.isCPR = false;
			}
			TsPlayerAnimationController componentInChildren = reveivingPlayer.GetComponentInChildren<TsPlayerAnimationController>();
			if (componentInChildren != null)
			{
				componentInChildren.StopCPR();
			}
			FPSArmsAnimationController component3 = reveivingPlayer.GetComponent<FPSArmsAnimationController>();
			if (component3 != null)
			{
				component3.StopCPR();
			}
		}
		reveivingPlayer = null;
	}

	[Command(requiresAuthority = false)]
	public void CmdReveivePlayer(NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerReveiver::CmdReveivePlayer(Mirror.NetworkConnectionToClient)", -314221988, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcReveivePlayer()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerReveiver::RpcReveivePlayer()", 433573492, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdReveivePlayer__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			Debug.Log("PlayerReveiver is not active, cannot revive - player already fully dead");
			return;
		}
		if (player == null || !player.isDeath)
		{
			Debug.Log("Player is not dead, cannot revive again");
			return;
		}
		RpcReveivePlayer();
		player.RpcActivateReveiverObject(active: false);
	}

	protected static void InvokeUserCode_CmdReveivePlayer__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReveivePlayer called on client.");
		}
		else
		{
			((PlayerReveiver)obj).UserCode_CmdReveivePlayer__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcReveivePlayer()
	{
		Debug.Log("RpcReveivePlayer called - reveivingPlayer: " + ((reveivingPlayer != null) ? reveivingPlayer.name : "null"));
		if (reveivingPlayer != null)
		{
			TSPlayerStatusHolder component = reveivingPlayer.GetComponent<TSPlayerStatusHolder>();
			if (component != null)
			{
				component.isCPR = false;
			}
			TsPlayerAnimationController componentInChildren = reveivingPlayer.GetComponentInChildren<TsPlayerAnimationController>();
			if (componentInChildren != null)
			{
				Debug.Log("Stopping TPS CPR animation in RpcReveivePlayer");
				componentInChildren.StopCPR();
			}
			FPSArmsAnimationController component2 = reveivingPlayer.GetComponent<FPSArmsAnimationController>();
			if (component2 != null)
			{
				Debug.Log("Stopping FPS CPR animation in RpcReveivePlayer");
				component2.StopCPR();
			}
		}
		if (player != null && player.isOwned)
		{
			player.ToReveive();
		}
		StopInteract();
		Debug.Log("Player Revived");
	}

	protected static void InvokeUserCode_RpcReveivePlayer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcReveivePlayer called on server.");
		}
		else
		{
			((PlayerReveiver)obj).UserCode_RpcReveivePlayer();
		}
	}

	static PlayerReveiver()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerReveiver), "System.Void PlayerReveiver::CmdReveivePlayer(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdReveivePlayer__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerReveiver), "System.Void PlayerReveiver::RpcReveivePlayer()", InvokeUserCode_RpcReveivePlayer);
	}
}
