using UnityEngine;

public class IceCreamBucketInteraction : Interaction
{
	public IceCreamBucket SelectedBucket;

	private bool m_PlacingMode;

	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private LayerMask m_BucketInteractionLayer;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	private RackSlot m_CurrentRackSlot;

	private TrashBin m_CurrentTrashBin;

	private IceCreamFlavourInteractable m_CurrentTarget;

	private bool m_HoldingUse;

	private float m_HoldingTime;

	private float m_HoldingInteractionTime;

	private PlayerInstance m_PlayerInstance;

	private NetworkIceCreamBucketInteraction m_NetworkBucketInteraction;

	private bool m_InAnimationTransition;

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

	public bool HasRemaining => false;

	private PlayerInstance PlayerInstance => null;

	public NetworkIceCreamBucketInteraction NetworkBucketInteraction => null;

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

	public void CheckForInteraction()
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnClose()
	{
	}

	public void BoxUpBucket()
	{
	}

	public void InteractBox(IceCreamBucketBox box)
	{
	}

	private void ThrowIntoTrashBin()
	{
	}

	public void ThrowIntoTrashBin_Order(Vector3 playSoundPosition)
	{
	}

	private void SetCurrentTrashBin(TrashBin trashBin)
	{
	}

	private void SetCurrentTarget(IceCreamFlavourInteractable flavourInteractable)
	{
	}

	private void DefaultHints(bool show)
	{
	}

	private void AddIceCreamHints(bool show)
	{
	}

	private void TrashBinHint(bool show)
	{
	}
}
