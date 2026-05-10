using System;
using UnityEngine;

public class CheckoutInteraction : Interaction
{
	public NetworkCheckoutInteraction NetworkCheckoutInteraction;

	[SerializeField]
	private float m_MaxRaycastDistance_ForScanning;

	[SerializeField]
	private LayerMask m_ProductLayer;

	[SerializeField]
	private LayerMask m_MoneyLayer;

	[SerializeField]
	private LayerMask m_PosTerminalLayer;

	[SerializeField]
	private float m_ScanningInterval;

	private Checkout m_Checkout;

	private Checkout.State m_State;

	private Product m_CurrentProduct;

	private MoneyPack m_CurrentMoney;

	private PosTerminal m_CurrentPosTerminal;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	private bool m_PlacingMode;

	private float m_lastScanTime;

	private bool m_isGamepad;

	private bool m_isGamepadTriggered;

	private PlayerInstance m_ownedPlayerInstance;

	public Action<Checkout> onCheckoutBoxed;

	public Action<Checkout> onCheckoutClosed;

	public Checkout.State CurrentCheckoutState => default(Checkout.State);

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

	public bool PlacingMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool CollectingChange => false;

	public PlayerInstance PlayerInstance => null;

	public Checkout Checkout
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Checkout.State State
	{
		get
		{
			return default(Checkout.State);
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

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void CheckoutStateChanged()
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnOpenClose()
	{
	}

	private void OnTake(bool down)
	{
	}

	private void OnGamepadTriggered(bool down)
	{
	}

	private void OnApproveCheckout()
	{
	}

	private void OnBack()
	{
	}

	public bool IsOnBackAvailable()
	{
		return false;
	}

	public void CancelInteracitonForOnlyMultiplayer()
	{
	}

	private void OnBackCheckout()
	{
	}

	public void OnBackCheckout_Network()
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void OnClose()
	{
	}

	private void BoxUpCheckout()
	{
	}

	public void BoxUpCheckoutNetwork()
	{
	}

	public void BoxUpCheckoutNetworkOrder()
	{
	}

	private bool CanCheckoutBoxup()
	{
		return false;
	}

	private void StartScanning()
	{
	}

	private void StartRaycastingMoney()
	{
	}

	private void StartRaycastingPosTerminal()
	{
	}

	private void InteractWithProduct()
	{
	}

	public void InteractWithProduct_Order(int _productIndex)
	{
	}

	private void InteractWithMoney(bool add)
	{
	}

	private void InteractWithPosTerminal()
	{
	}

	private void InteractWithCustomerPayment()
	{
	}

	public void SetCheckout(Checkout _checkout)
	{
	}

	private void TryPlaceCheckout()
	{
	}

	public void PlaceCheckout()
	{
	}

	public void DefaultHint(bool show)
	{
	}

	public void ScanningHint(bool show)
	{
	}

	public void PosTerminalHint(bool show)
	{
	}

	public void TakingPaymentHint(bool show)
	{
	}

	public void ChangeHints(bool show)
	{
	}

	public void ApproveHint(bool show)
	{
	}

	public void OpenCloseHint(bool show)
	{
	}

	public void MovingHints(bool show)
	{
	}

	public void OnDayFinished()
	{
	}
}
