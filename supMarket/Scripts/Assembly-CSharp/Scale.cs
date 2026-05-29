using System;
using System.Runtime.CompilerServices;
using Lean.Pool;
using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class Scale : MonoBehaviour, IInteractable, IPoolable, ICustomerHelperControllable, IPlacingStateContainer
{
	public enum ScaleInteractionState
	{
		IDLE = 0,
		CONTROL = 1,
		BARCODE = 2,
		PLACING = 3
	}

	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private int m_ID;

	public const int FURNITURE_ID = 223;

	[SerializeField]
	private Transform m_ControlTransform;

	private Camera m_Camera;

	private ScaleController m_Controller;

	private ScaleInteractionState m_State;

	private ScaleAudio m_ScaleAudio;

	[SerializeField]
	private Transform m_ProductPointTransform;

	[SerializeField]
	private Numpad m_Numpad;

	[SerializeField]
	private ScaleProductDisplay m_ScaleProductDisplay;

	[SerializeField]
	private ProductPaperBag m_ProductPrefab;

	[SerializeField]
	private BarcodeSpawner m_BarcodeSpawner;

	private BarcodeDragger m_BarcodeDragger;

	private ProductCountPair m_Product;

	[SerializeField]
	private CustomerQueue m_Queue;

	private PlayerScaleController m_PlayerController;

	private NetworkScale m_NetworkScale;

	public int ID => 0;

	public Transform ControlTransform => null;

	public FurniturePlacingMode PlacingMode => null;

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint { get; }

	public string HoldingInteractionHint { get; }

	public string SecondInteractionHint { get; }

	public string RepairInteractionHint { get; }

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public ScaleController Controller => null;

	public Vector3 ControlPosition => default(Vector3);

	public Vector3 StandingPosition => default(Vector3);

	public Quaternion StandingRotation => default(Quaternion);

	public CustomerHelper ControlledBy { get; set; }

	public CustomerHelper Standing { get; set; }

	bool IPlacingStateContainer.IsPlacing => false;

	public ScaleInteractionState State => default(ScaleInteractionState);

	public ScaleAudio ScaleAudio => null;

	public Numpad Numpad => null;

	public Barcode ActiveBarcode => null;

	public ProductPaperBag ProductInstance { get; private set; }

	public BarcodeDragger BarcodeDragger => null;

	public PaperBagFactory PaperBagFactory { get; private set; }

	public ProductCountPair Product
	{
		get
		{
			return default(ProductCountPair);
		}
		set
		{
		}
	}

	public CustomerQueue CustomerQueue => null;

	public NetworkScale NetworkScale => null;

	GameObject ICustomerHelperControllable.gameObject => null;

	public event Action<ScaleInteractionState, ScaleInteractionState> StateChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void TogglePlacementHints(bool value, PlayerInstance interactedPlayer)
	{
	}

	public void AttachBarcodeToCenter()
	{
	}

	public void AttachBarcodeCenterOrder(Vector3 hitPoint, Vector3 hitNormal)
	{
	}

	public bool TryGetAttachmentInfo(out RaycastHit hit)
	{
		hit = default(RaycastHit);
		return false;
	}

	public bool TryProcessBarcode(out RaycastHit hit)
	{
		hit = default(RaycastHit);
		return false;
	}

	public void ProcessBarcodeNetwork(Vector3 hitPoint, Vector3 hitNormal)
	{
	}

	public void RemoveExistingProduct()
	{
	}

	public void RemoveExistingProductOrder()
	{
	}

	private void CreateProduct()
	{
	}

	public void CreateProductOrder(ProductCountPair productCountPair)
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	private void SetPlayerController()
	{
	}

	public void SetPlayerController(PlayerInstance player)
	{
	}

	public void SetController(ScaleController controller)
	{
	}

	public bool HoldingInteract()
	{
		return false;
	}

	private void StartPlacement()
	{
	}

	public void StartPlacementNetwork(string userId)
	{
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void CreateBarcode()
	{
	}

	public void CreateBarcodeNetwork(string value)
	{
	}

	public void ToggleBarcodeHighlight()
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void Despawn()
	{
	}

	public void DestroyActiveBarcode()
	{
	}

	public void ClearQueue()
	{
	}

	public void SetState(ScaleInteractionState state, ScaleController controller = null)
	{
	}

	public void SetStateNetwork(ScaleInteractionState state, PlayerInstance interactedPlayer)
	{
	}

	public void RaiseWarning()
	{
	}
}
