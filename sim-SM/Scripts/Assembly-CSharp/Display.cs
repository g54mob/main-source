using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class Display : MonoBehaviour, IInteractable
{
	[SerializeField]
	private DisplayType m_Type;

	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private int m_ID;

	[SerializeField]
	private List<GameObject> m_SaleSignList;

	private DisplayData m_DisplayData;

	private DisplaySlot[] m_DisplaySlots;

	private PhotonView m_PhotonView;

	private NetworkDisplay m_NetworkDisplay;

	public bool IsSignOpen;

	private bool m_IsOccupied;

	private Collider[] m_Colliders;

	public bool IsPlacingMode;

	public Action OnDisplayPlaced;

	public PhotonView PhotonView => null;

	public NetworkDisplay OwnNetworkDisplay => null;

	public InteractactableType Type => default(InteractactableType);

	public DisplayType DisplayType => default(DisplayType);

	public DisplayData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public DisplaySlot RandomSlot => null;

	public List<DisplaySlot> DisplaySlots => null;

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public FurniturePlacingMode PlacingMode => null;

	public int ID => 0;

	private bool EnablePriceTagColliders
	{
		set
		{
		}
	}

	private bool EnableLabelColliders
	{
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Initialize()
	{
	}

	private void Awake()
	{
	}

	public void SetCollisions(bool willOpen)
	{
	}

	public void OccupyDisplay(bool isOccupied)
	{
	}

	public void OccupyOrder(bool isOccupied)
	{
	}

	public int GetIndexOfDisplaySlot(DisplaySlot displaySlot)
	{
		return 0;
	}

	public DisplaySlot GetDisplaySlotFromIndex(int index)
	{
		return null;
	}

	public void RemoveFromDisplayManagerWhileCarrying()
	{
	}

	public void AddBackToDisplayManagerAfterPlaced()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool HoldingInteract()
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

	public void StartPlacingModeNetwork()
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

	private void CheckDiscountsOnPlaced()
	{
	}

	public void Despawn()
	{
	}

	public void ActivateRandomSaleSign()
	{
	}

	public void ActiveSaleSignById(int index)
	{
	}

	public void CloseSaleSign()
	{
	}

	public void ResetDisplayData()
	{
	}

	public void PopulateWithLabeledEmptySlots(int productID, List<DisplaySlot> slots)
	{
	}

	public int GetLabeledEmptySlotsNonAlloc(int productID, DisplaySlot[] slots)
	{
		return 0;
	}

	public IEnumerable<DisplaySlot> LabeledEmptySlots(int productID)
	{
		return null;
	}

	public bool CustomInteract()
	{
		return false;
	}
}
