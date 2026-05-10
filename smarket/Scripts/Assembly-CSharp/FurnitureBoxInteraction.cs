using MyBox;
using UnityEngine;

public class FurnitureBoxInteraction : Interaction
{
	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private LayerMask m_BoxInteractionLayer;

	[Separator("Furniture Spawn Animation", false)]
	[SerializeField]
	private float m_ScaleUpSpeed;

	[Separator("Furniture Selling", false)]
	[SerializeField]
	private float m_HoldingInteractionTime;

	private PlayerInstance m_PlayerInstance;

	private FurnitureBox m_Box;

	private NetworkFurnitureBoxInteraction m_NetworkFurnitureBoxInteraction;

	private bool m_PlacingMode;

	private TrashBin m_CurrentTrashBin;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	private bool m_HoldingSellButton;

	private float m_HoldingTime;

	[SerializeField]
	private bool m_InAnimationTransition;

	public bool IsWaitingAvailability;

	private FurnitureBoxData m_FurnitureBoxData;

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

	public FurnitureBox CurrentFurnitureBox => null;

	public NetworkFurnitureBoxInteraction NetworkFurnitureBoxInteraction => null;

	public PlayerInstance PlayerInstance => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnUse(bool down)
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

	private void OnSell(bool started)
	{
	}

	private void OnThrow(bool isDown)
	{
	}

	public void LocalThrow()
	{
	}

	public void Throw()
	{
	}

	public void CancelInteracitonForOnlyMultiplayer()
	{
	}

	private void CheckForInteraction()
	{
	}

	private void CheckHoldingInteraction()
	{
	}

	private GameObject Spawn()
	{
		return null;
	}

	private void OpenBox()
	{
	}

	public void NetworkOpenBox()
	{
	}

	public void OpenBoxOrder(GameObject spawnedObject, FurnitureBoxData furnitureBoxData = null)
	{
	}

	public void CheckFurnitureType(GameObject furniture, FurnitureBoxData furnitureBoxData, bool shouldInteract = true)
	{
	}

	public void DropBox(Vector3 playSoundPosition)
	{
	}

	public void DropBox(string userId, Vector3 playSoundPosition)
	{
	}

	private void ThrowIntoTrashBin()
	{
	}

	public void Network_ThrowIntoTrashBin(string userId)
	{
	}

	private void SellFurniture()
	{
	}

	public void SellFurnitureOrder()
	{
	}

	private void SetCurrentTrashBin(TrashBin trashBin)
	{
	}

	private void DefaultHints(bool show)
	{
	}

	private void PlacingModeHints(bool show)
	{
	}

	private void TrashBinHint(bool show)
	{
	}
}
