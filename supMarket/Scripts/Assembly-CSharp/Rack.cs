using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Rack : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Highlightable m_Highlightable;

	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private int m_ID;

	private RackData m_RackData;

	private RackSlot[] m_RackSlots;

	private PhotonView m_PhotonView;

	private NetworkRack m_NetworkRack;

	public bool IsPlacingMode;

	public PhotonView PhotonView => null;

	public NetworkRack OwnNetworkRack => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public FurniturePlacingMode PlacingMode => null;

	public int ID => 0;

	public RackData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<RackSlot> RackSlots => null;

	public bool EnableBoxColliders
	{
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Initialize()
	{
	}

	public int GetIndexOfRackSlot(RackSlot rackSlot)
	{
		return 0;
	}

	public RackSlot GetRackSlotFromIndex(int index)
	{
		return null;
	}

	public void RemoveFromRackManagerWhileCarrying()
	{
	}

	public void AddBackToRackManagerAfterPlaced()
	{
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void StartPlacingMode()
	{
	}

	public void StartPlacingMode(string userId)
	{
	}

	public void BoxUp()
	{
	}

	public void Place()
	{
	}

	public void Despawn()
	{
	}

	public void AddOrRemoveRenderer(Renderer[] renderers, bool add)
	{
	}

	public void ResetRackData()
	{
	}

	public void RepositionBoxesInstant()
	{
	}

	public void RepositionBoxesDelay()
	{
	}

	public void FixInstancedRenderer()
	{
	}
}
