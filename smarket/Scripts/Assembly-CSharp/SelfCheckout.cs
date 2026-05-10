using UnityEngine;

public class SelfCheckout : MonoBehaviour, ICustomerHelperControllable, IPlacingStateContainer
{
	[SerializeField]
	private Checkout m_Checkout;

	[SerializeField]
	private GameObject m_ShoppingBag;

	[SerializeField]
	private bool m_IsMirrrored;

	[SerializeField]
	public GameObject m_RepairIndicator;

	[SerializeField]
	public Transform CustomerHelperStandPosition;

	[SerializeField]
	public Transform CustomerHelperHelpPosition;

	[Header("Settings")]
	[SerializeField]
	private float m_CustomerScanningInterval;

	[SerializeField]
	private float m_PlayerScanningInterval;

	[SerializeField]
	private float m_CashierScanningInterval;

	[SerializeField]
	private float m_CashierBoostedScanningInterval;

	[Header("SFX")]
	[SerializeField]
	private SFXInstance m_CashierSFX;

	private NetworkCheckout m_NetworkCheckout;

	public bool IsScanning;

	public GameObject ShoppingBag => null;

	public Checkout Checkout => null;

	public float PlayerScanningInterval => 0f;

	public NetworkCheckout NetworkCheckout => null;

	public Vector3 ControlPosition => default(Vector3);

	public Vector3 StandingPosition => default(Vector3);

	Quaternion ICustomerHelperControllable.StandingRotation => default(Quaternion);

	public CustomerHelper ControlledBy { get; set; }

	public CustomerHelper Standing { get; set; }

	bool IPlacingStateContainer.IsPlacing => false;

	GameObject ICustomerHelperControllable.gameObject => null;

	private void OnEnable()
	{
	}

	public float SetRepairIntervals()
	{
		return 0f;
	}

	public void RepairSelfCheckout()
	{
	}

	public void RepairSelfCheckoutOrder()
	{
	}

	public void StartSelfCheckout()
	{
	}

	public void StartCustomerHelperCheckout()
	{
	}

	private void FireForceFinish()
	{
	}

	public void FinishSelfCheckout()
	{
	}

	private void OnDestroy()
	{
	}

	public void FinishSelfCheckout_Order()
	{
	}

	public void SetScale()
	{
	}

	private void UnsubscribeDayCycle()
	{
	}

	private void OnDayFinished()
	{
	}

	public void ResetCheckout()
	{
	}

	public void InterruptedCustomerHelper()
	{
	}

	public void StartCustomerHelperCheckoutOrder(CustomerHelper helper)
	{
	}
}
