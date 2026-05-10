using System;
using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Data;
using __Project__.Scripts.Janitor.Interfaces;

public class Garbage : MonoBehaviourPunCallbacks, IInteractable, IPunInstantiateMagicCallback, ICleanable
{
	public int productId;

	public MeshCollider garbageMesh;

	public GarbageSaveData garbageSaveData;

	private TrashbagInteraction m_TrashbagInteraction;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public Action OnCleaned { get; set; }

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool InstantInteract()
	{
		return false;
	}

	[PunRPC]
	public void RPC_Collect(string userID)
	{
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public void Setup(int garbageId)
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}
}
