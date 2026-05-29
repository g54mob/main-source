using UnityEngine;

public class ScannerInteraction : Interaction
{
	[SerializeField]
	private ScannerDevice m_ScannerDevice;

	[SerializeField]
	private TabletDevice m_TabletDevice;

	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private LayerMask m_LabelInteractionLayer;

	[SerializeField]
	private Camera m_TabletCamera;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	private NetworkScannerInteraction m_NetworkScannerInteraction;

	private IInteractable m_CurrentInteractable;

	private NetworkMarketShoppingCart m_NetworkMarketShoppingCart;

	private PlayerInstance m_PlayerInstance;

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

	private PlayerInstance PlayerInstance => null;

	public NetworkMarketShoppingCart NetworkMarketShoppingCart => null;

	public NetworkScannerInteraction NetworkScannerInteraction => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPurchaseCompleted(bool obj)
	{
	}

	private void OnBack()
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void CheckForInteraction()
	{
	}

	private void SetCurrentInteractable(IInteractable label)
	{
	}

	public void EnableDevice()
	{
	}

	public void DisableDevice()
	{
	}

	public void UpdateTabletScreen()
	{
	}
}
