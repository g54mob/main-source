using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using UnityEngine;

public class Checkout : MonoBehaviour, IInteractable
{
	public enum State
	{
		IDLE = 0,
		SCANNING = 1,
		CUSTOMER_HANDING_CASH = 2,
		CUSTOMER_HANDING_CARD = 3,
		PAYMENT_CREDIT_CARD = 4,
		PLACING = 5,
		PAYMENT_CASH = 6,
		CASHIER = 7,
		CLOSED = 8
	}

	[CompilerGenerated]
	private sealed class _003CBeatCheckoutCustomer_003Ed__191 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Checkout _003C_003E4__this;

		public Customer customer;

		public float duration;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CBeatCheckoutCustomer_003Ed__191(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCustomerHelpAnimator_003Ed__142 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Checkout _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCustomerHelpAnimator_003Ed__142(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRepairingSelfCheckout_003Ed__139 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Checkout _003C_003E4__this;

		public bool isPlayer;

		public PlayerInstance playerInstance;

		private float _003Cinterval_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRepairingSelfCheckout_003Ed__139(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private const float m_MovingProductToBagTime = 1f;

	private const float m_ChangeTolerance = 0.5f;

	private const float m_MaxPercentageOfTotalPriceForMissingChange = 0.5f;

	[SerializeField]
	private Queue m_Queue;

	[SerializeField]
	private CheckoutBelt m_Belt;

	[SerializeField]
	private CheckoutScreen m_CheckoutScreen;

	[SerializeField]
	private CheckoutDrawer m_CheckoutDrawer;

	[SerializeField]
	private CheckoutChangeManager m_ChangeManager;

	[SerializeField]
	private Animator m_CashRegisterAnimator;

	[SerializeField]
	private Transform m_CheckoutPosition;

	[SerializeField]
	private Transform m_ShoppingBag;

	[SerializeField]
	private Transform m_ClosedSign;

	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private int m_ID;

	[SerializeField]
	private AutomatedCheckout m_AutomatedCheckout;

	[SerializeField]
	private SelfCheckout m_SelfCheckout;

	[SerializeField]
	private bool m_IsSelfCheckout;

	[SerializeField]
	private float m_SelfCheckoutMovePower;

	[SerializeField]
	private float m_CustomerWaveInterval;

	[Separator("Cash Register", false)]
	[SerializeField]
	private CashRegisterScreen m_RegisterScreen;

	[SerializeField]
	private Color m_CorrectChangeColor;

	[SerializeField]
	private Color m_WrongChangeColor;

	[SerializeField]
	private GameObject m_NoEnoughMoneyIndicator;

	[SerializeField]
	private float m_NoEnoughMoneyIndicatorLifetime;

	[Separator("Cash Register", false)]
	[SerializeField]
	private PosTerminal m_PosTerminal;

	[Separator("Store Point", false)]
	[SerializeField]
	private int m_StorePointPerCheckout;

	[SerializeField]
	private int m_PointPenaltyOnLowChange;

	[SerializeField]
	private float m_PointPenaltyChanceOnLowChange;

	private List<Customer> m_Customers;

	private ItemQuantity m_CurrentShoppingCart;

	private bool m_InInteraction;

	private State m_State;

	private float m_TotalPrice;

	private float m_ReceivedPayment;

	private float m_CorrectChange;

	private float m_CollectedChange;

	private bool m_CollectingChange;

	private CheckoutData m_CheckoutData;

	private State m_StateBeforeMoving;

	private bool m_PosInteraction;

	private bool m_HasCashier;

	private Coroutine m_CustomerHelpCoroutine;

	private Coroutine m_RepairingSelfCheckoutCoroutine;

	private NetworkCheckout m_NetworkCheckout;

	public List<int> ScannedProductsIndex;

	public bool CurrentCustomerGotHit;

	public List<float> UsedMoneyForChange;

	public PlayerInstance CheckoutUserPlayerInstace;

	public bool IsLastPaymentViaCard;

	private bool m_CanApproveChange => false;

	private bool m_ReachedMinChange => false;

	private CustomerHelper HelpingCustomerHelper => null;

	private CustomerHelper StandingCustomerHelper => null;

	public int ID => 0;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public bool Full => false;

	public List<Customer> Customers => null;

	public bool InInteraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public State CurrentState => default(State);

	public State StateBeforeMoving => default(State);

	public CheckoutBelt Belt => null;

	public ItemQuantity CurrentShoppingCart => null;

	public float TotalPrice
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public bool IsRepairing { get; set; }

	public bool CollectingChange => false;

	public InteractionType InteractionType => default(InteractionType);

	public CheckoutData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public FurniturePlacingMode PlacingMode => null;

	public bool PosInteraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool HasCashier => false;

	public bool IsSelfCheckout => false;

	public SelfCheckout SelfCheckout => null;

	public bool IsOpen
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int CashierID => 0;

	public Cashier Cashier => null;

	public NetworkCheckout NetworkCheckout => null;

	public float CollectedChange
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void Subscribe(Customer customer)
	{
	}

	public void Unsubscribe(Customer customer)
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	private void EnterCheckout()
	{
	}

	public void EnterCheckout(string userId)
	{
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CRepairingSelfCheckout_003Ed__139))]
	private IEnumerator RepairingSelfCheckout(bool isPlayer, PlayerInstance playerInstance)
	{
		return null;
	}

	private void FinishRepairSelfCheckout()
	{
	}

	public void FinishRepairSelfCheckoutNetwork()
	{
	}

	[IteratorStateMachine(typeof(_003CCustomerHelpAnimator_003Ed__142))]
	private IEnumerator CustomerHelpAnimator()
	{
		return null;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public Product GetProductFromBelt(int _index)
	{
		return null;
	}

	public int GetProductIndexFromBelt(Product _product)
	{
		return 0;
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void GetBeltItems()
	{
	}

	public void OpenCloseCheckout()
	{
	}

	public void OpenCheckout()
	{
	}

	public void CloseCheckout()
	{
	}

	public void SwitchClosedObject(bool isOpen)
	{
	}

	public void OpenCloseCheckout_Network(bool _IsOpen)
	{
	}

	public void StartCheckout(ItemQuantity shoppingCart, Customer customer = null)
	{
	}

	public void OpenShoppingBag()
	{
	}

	private void StartSelfCheckout()
	{
	}

	public void StartSelfCheckoutOrder(bool needHelp)
	{
	}

	public void FinishSelfCheckoutOrder()
	{
	}

	public void ProductScanned(Product product, bool cashier = false)
	{
	}

	public void ProductScannedInstant_Network(Product product)
	{
	}

	public bool IsCheckoutEnterable()
	{
		return false;
	}

	public void FinishedScanning()
	{
	}

	public void FinishScanning_Order(bool _paymentViaCreditCard, Customer _customer)
	{
	}

	public void TookCustomersCash(float payment, PlayerInstance playerInstance)
	{
	}

	public void TookCustomersCash_Order(float payment, PlayerInstance playerInstance)
	{
	}

	public void TookCustomersCard(PlayerInstance playerInstance)
	{
	}

	public void TookCustomersCard_Order(PlayerInstance playerInstance)
	{
	}

	public void AddOrRemoveChange(MoneyPack money, bool add)
	{
	}

	public void AddOrRemoveChange_Order(float value, bool add, float collectedChange)
	{
	}

	public bool TryFinishingCashPayment(bool? canApproveChange = null, bool isClientTriggered = false, Vector3? playSoundPosition = null)
	{
		return false;
	}

	public bool TryFinishingCashPayment_Order(Vector3 playSoundPosition)
	{
		return false;
	}

	public bool TryFinishingCardPayment(float posTotal, string userId = null, bool isClientTriggered = false, Vector3? playSoundPosition = null)
	{
		return false;
	}

	public bool FinishingCardPayment_Order(Vector3 playSoundPosition)
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

	public void PlaceCheckout()
	{
	}

	public void Despawn()
	{
	}

	public void AddCashier(Cashier cashier)
	{
	}

	public void AddCashier_Network(Cashier cashier)
	{
	}

	public void RemoveCashier()
	{
	}

	public void RemoveCashier_Network()
	{
	}

	public void CashierTookPayment(bool paymentViaCreditCard)
	{
	}

	public void CashierCompletedCheckout()
	{
	}

	private void AskForCustomer()
	{
	}

	private void ChangeState(State newState, PlayerInstance player = null)
	{
	}

	private void UpdateQueue()
	{
	}

	private void ResetCashRegister()
	{
	}

	private void ClearCheckout()
	{
	}

	private void OnDayFinished()
	{
	}

	private void UnsubscribeDayCycle()
	{
	}

	private void RefreshCurrentCheckout()
	{
	}

	[IteratorStateMachine(typeof(_003CBeatCheckoutCustomer_003Ed__191))]
	public IEnumerator BeatCheckoutCustomer(Customer customer, float duration)
	{
		return null;
	}

	public void RequestCashier()
	{
	}
}
