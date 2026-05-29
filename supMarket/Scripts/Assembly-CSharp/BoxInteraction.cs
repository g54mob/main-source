using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class BoxInteraction : Interaction
{
	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private float m_PlacementRaycastDistance;

	[SerializeField]
	private LayerMask m_BoxInteractionLayer;

	[SerializeField]
	private float m_ProductInteractionInterval;

	[SerializeField]
	private float m_MinTimeToStartPlacingAfterOpeningBox;

	[SerializeField]
	private Material m_HologramMaterial;

	private Box m_Box;

	private bool m_PlacingMode;

	private bool m_holdingUse;

	private bool m_IsBoxOpen;

	private float m_lastPlaceTime;

	private bool m_holdingTake;

	private float m_lastTakeTime;

	private DisplaySlot m_CurrentDisplaySlot;

	private RackSlot m_CurrentRackSlot;

	private VendingSlot m_CurrentVendingSlot;

	private TrashBin m_CurrentTrashBin;

	private BoxPlacementArea m_TargetPlacementArea;

	private IPlacementArea m_CurrentPlacementArea;

	private float m_PlacementRotation;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	private MissionSystem m_MissionSystem;

	private PlayerInstance m_PlayerInstance;

	private Spring<Vector3> m_PositionSpring;

	private Spring<Vector3> m_ScaleSpring;

	private Spring<Quaternion> m_RotationSpring;

	private NetworkBoxInteraction m_NetworkBoxInteraction;

	public bool IsWaitingAvailability;

	private PlayerInstance PlayerInstance => null;

	private bool m_InSkateboard => false;

	private bool IsDisplay => false;

	public override bool Enable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override IInteractable Interactable
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Box Box => null;

	public NetworkBoxInteraction NetworkBoxInteraction
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void RegisterEvents()
	{
	}

	private void OnDisable()
	{
	}

	private void UnRegisterEvents()
	{
	}

	private void Update()
	{
	}

	private void AlignOnBoxPlacement()
	{
	}

	private void CheckForAreaPlacement()
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnTake(bool down)
	{
	}

	private void OnDrop(bool down = false)
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void OnBack()
	{
	}

	private void OnThrow(bool isDown)
	{
	}

	public void Throw()
	{
	}

	public void CancelInteracitonForOnlyMultiplayer()
	{
	}

	public void Throw(string userID)
	{
	}

	public void LocalThrow()
	{
	}

	public void WholesaleThrowBox()
	{
	}

	public void WholesaleThrowBox_Order()
	{
	}

	private void OnClose()
	{
	}

	private void CheckForInteraction()
	{
	}

	private void CheckForPlacingItem()
	{
	}

	private void CheckForTakingItem()
	{
	}

	public void DropBox()
	{
	}

	public void DropBox(string userId)
	{
	}

	public void TryPlaceProductToDisplay(Vector3 playSoundPosition)
	{
	}

	public void TryPlaceProductToDisplay(DisplaySlot displaySlot, Vector3 playSoundPosition)
	{
	}

	public void TryPlaceProductToVending(VendingSlot vendingSlot, Vector3 playSoundPosition)
	{
	}

	public void PlaceProductToVending(Box box, VendingSlot vendingSlot, Vector3 playSoundPosition)
	{
	}

	public void PlaceProductToDisplay(Box box, DisplaySlot displaySlot, Vector3 playSoundPosition)
	{
	}

	private bool CheckPlaceProductToSlot()
	{
		return false;
	}

	private void TryTakeProductFromSlot()
	{
	}

	public void TakeProductFromVending(Box box, VendingSlot vendingSlot)
	{
	}

	public void TakeProductFromDisplay(Box box, DisplaySlot displaySlot)
	{
	}

	private bool CheckTakeProductFromSlot()
	{
		return false;
	}

	private void ThrowIntoTrashBin()
	{
	}

	public void Network_ThrowIntoTrashBin(string userID, Vector3 playSoundPosition)
	{
	}

	private void PlaceBoxToPlacementArea()
	{
	}

	public bool CheckPlaceBoxToRack(string receiverUserId = null)
	{
		return false;
	}

	public bool CheckPlaceBoxToRack(RackSlot _CurrentRackSlot, string receiverUserId = null)
	{
		return false;
	}

	public void PlaceBoxToRack()
	{
	}

	public void PlaceBoxToRack_Network(int targetRackViewId, int targetRackSlotIndex, Vector3 playSoundPosition)
	{
	}

	private void SetCurrentDisplaySlot(DisplaySlot displaySlot)
	{
	}

	private void SetCurrentPlacementArea(IPlacementArea placementArea)
	{
	}

	private void SetCurrentRackSlot(RackSlot rackSlot)
	{
	}

	private void SetCurrentVendingSlot(VendingSlot vendingSlot)
	{
	}

	private void SetCurrentTrashBin(TrashBin trashBin)
	{
	}

	public void DefaultHints(bool show)
	{
	}

	private void SortedPlacementAreaHints(bool show)
	{
	}

	private void PlacementAreaHints()
	{
	}

	private void UpdateOpeningBoxHint()
	{
	}

	private void PlacingModeHints(bool show)
	{
	}

	protected virtual void PlaceProductHints(bool show)
	{
	}

	private void TrashBinHint(bool show)
	{
	}

	private void RackHints(bool show)
	{
	}

	private void VendingHints(bool show)
	{
	}
}
