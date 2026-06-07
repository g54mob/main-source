using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Lean.Pool;
using UnityEngine;
using UnityEngine.AI;
using __Project__.Scripts.Multiplayer.Customers;

public class Customer : MonoBehaviour, IInteractable, IPoolable
{
	[CompilerGenerated]
	private sealed class _003CExitStore_003Ed__167 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

		public bool gothit;

		private float _003CcurrTime_003E5__2;

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
		public _003CExitStore_003Ed__167(int _003C_003E1__state)
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
	private sealed class _003CGoToScale_003Ed__177 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

		private IEnumerable<KeyValuePair<int, int>> _003CweighedProducts_003E5__2;

		private CustomerQueue _003Cqueue_003E5__3;

		private IEnumerator<KeyValuePair<int, int>> _003C_003E7__wrap3;

		private KeyValuePair<int, int> _003Cpair_003E5__5;

		private WeightedProductSO _003CweightedProduct_003E5__6;

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
		public _003CGoToScale_003Ed__177(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CMoveTo_003Ed__164 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

		public Vector3 target;

		private int _003CtryCount_003E5__2;

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
		public _003CMoveTo_003Ed__164(int _003C_003E1__state)
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
	private sealed class _003CMoveToNetwork_003Ed__163 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

		public Vector3 target;

		private int _003CtryCount_003E5__2;

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
		public _003CMoveToNetwork_003Ed__163(int _003C_003E1__state)
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
	private sealed class _003CProcessShoppingList_003Ed__171 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

		private List<int>.Enumerator _003C_003E7__wrap1;

		private int _003CproductID_003E5__3;

		private DisplaySlot _003CtargetDisplaySlot_003E5__4;

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
		public _003CProcessShoppingList_003Ed__171(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShopping_003Ed__160 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

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
		public _003CShopping_003Ed__160(int _003C_003E1__state)
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
	private sealed class _003CStartIceCreamSequence_003Ed__149 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IceCreamStand stand;

		public Customer _003C_003E4__this;

		public bool shortchange;

		private float _003CneedHelpTime_003E5__2;

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
		public _003CStartIceCreamSequence_003Ed__149(int _003C_003E1__state)
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
	private sealed class _003CTakeProductsFromDisplay_003Ed__165 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

		public DisplaySlot displaySlot;

		public int productID;

		private ProductSO _003Cproduct_003E5__2;

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
		public _003CTakeProductsFromDisplay_003Ed__165(int _003C_003E1__state)
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
	private sealed class _003CWaitForAvailableCheckout_003Ed__169 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Customer _003C_003E4__this;

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
		public _003CWaitForAvailableCheckout_003Ed__169(int _003C_003E1__state)
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
	private sealed class _003CWalkAroundIdle_003Ed__166 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DisplaySlot displaySlot;

		public Customer _003C_003E4__this;

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
		public _003CWalkAroundIdle_003Ed__166(int _003C_003E1__state)
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

	public const float m_CreditCardPaymentChance = 0.5f;

	private const float m_IdleWaitingDuration = 6f;

	private const float m_ExpensiveProductAnimationDuration = 2f;

	private const float m_ShoplifterGotHitAnimationDuration = 1.5f;

	private const float m_ShoplifterLookForProductAnimationDuration = 7f;

	private const float m_RotatingToDisplayTime = 0.3f;

	private const float m_TakingProductTime = 0.2f;

	private float m_RotationSmoothness;

	private readonly Vector2 m_ExtraPurchaseAmount;

	private readonly Vector2 m_WaitingIdleRange;

	public const float m_SpreadForce = 22f;

	private Transform m_TargetExitPoint;

	[SerializeField]
	private CustomerAnimator m_Animator;

	[SerializeField]
	private List<RuntimeAnimatorController> m_ShoplifterAnimatorControllers;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private Transform m_RightHand;

	[SerializeField]
	private GameObject m_ShoppingBag;

	[SerializeField]
	private int m_StorePointPenalty;

	[SerializeField]
	private int m_WrongShoplifterPenalty;

	[SerializeField]
	private bool m_GenderIsMale;

	private ItemQuantity m_ShoppingList;

	private ItemQuantity m_ShoppingCart;

	private IceCreamRequest m_IceCreamRequest;

	private bool m_IceCreamRequestFulfilled;

	private Product m_CurrentItem;

	private bool m_IsPickingUp;

	private bool m_IsPlayingAnimation;

	private bool m_IsSatisfiedCustomer;

	private bool m_StartedShopping;

	private bool m_FinishedShopping;

	private Checkout m_Checkout;

	private GameObject m_PaymentMoney;

	private GameObject m_PaymentCard;

	private Display m_TargetDisplay;

	private bool m_InCheckout;

	private bool m_HandingPayment;

	private bool m_PaymentViaCreditCard;

	private bool m_IsShoplifterRunning;

	private Vector3 m_DoorPosition;

	private Crate m_Crate;

	private IEnumerator m_GoToScaleCoroutine;

	private Scale m_TargetScale;

	private IceCreamStand m_TargetIceCreamStand;

	internal Shoplifter m_Shoplifter;

	private GameObject m_CurrentSpeechObject;

	private bool m_HasBeaten;

	private RuntimeAnimatorController m_RuntimeAnimatorController;

	private Animator m_AnimatorClient;

	private Coroutine m_IceCreamSequence;

	private NetworkCustomer m_NetworkCustomer;

	public bool isShoplifter;

	public bool isShoplifterCaught;

	public float LastCashValue;

	private float m_CachedAgentSpeed;

	private List<DisplaySlot> m_CachedDisplaySlots;

	public bool IsReadyToReceiveOrder { get; private set; }

	public bool IsIceCreamRequestFulfilled => false;

	public NetworkCustomer NetworkCustomer => null;

	public bool RequestsIceCream => false;

	public IceCreamRequest IceCreamRequest => null;

	public NavMeshAgent Agent => null;

	public GameObject CurrentSpeechObject
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ItemQuantity ShoppingCart
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ItemQuantity ShoppingList
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool IsSatisfied
	{
		set
		{
		}
	}

	public bool IsPlayingAnimation
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool PaymentViaCreditCard
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool HandingPayment => false;

	public CustomerAnimator Animator => null;

	public bool IsShoplifterRunning => false;

	public bool HasBeaten
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Product CurrentItem
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private bool IsShopping
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public IceCreamStand TargetIceCreamStand => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool Control { get; set; }

	public event EventHandler<ItemQuantity> ShoppingListCreated
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

	private bool PurchasedProductOnce(int productID)
	{
		return false;
	}

	public void ManualUpdate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void ResetCustomer()
	{
	}

	private void OnGameStopped(bool hasStopped)
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

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	internal void SetShoplifter()
	{
	}

	public void SetShoplifterAnimator()
	{
	}

	public void GoToStore(Vector3 doorPosition)
	{
	}

	public void StartShopping()
	{
	}

	public void HoldProduct()
	{
	}

	public void HoldProductOrder(int productItem, Vector3 fromPosition)
	{
	}

	public void ReleaseProduct()
	{
	}

	public void ReleaseProductOrder()
	{
	}

	public void MoveCheckoutPosition(Checkout checkout, TransformData queuePosition, bool firstCustomer)
	{
	}

	public void InteractWithCheckout()
	{
	}

	public void HandMoney(bool play, float cashValue = -1f)
	{
	}

	public GameObject HandCard(bool play)
	{
		return null;
	}

	public void DoPayment(bool viaCreditCard)
	{
	}

	public void DoPayment_Order(bool viaCreditCard, float cashValue)
	{
	}

	public void GoIceCreamThenFinishShopping(bool shortChange = false)
	{
	}

	[IteratorStateMachine(typeof(_003CStartIceCreamSequence_003Ed__149))]
	private IEnumerator StartIceCreamSequence(IceCreamStand stand, bool shortchange = false)
	{
		return null;
	}

	public void ResetIceCreamDelivery()
	{
	}

	public void ForceCompleteIceCreamDelivery()
	{
	}

	public void DeliverIceCream(IceCreamStatus status)
	{
	}

	public void FinishShopping(bool shortchange = false)
	{
	}

	public void SpreadProducts(SecurityGuard securityGuard)
	{
	}

	public void RunAway(bool isHitByGuard = false, SecurityGuard securityGuard = null)
	{
	}

	public void PlayHitSfx()
	{
	}

	private void SwitchShoppingBag(bool value)
	{
	}

	public void SwitchShoppingOrder(bool value)
	{
	}

	private void OnShoplifterDeteched(Shoplifter shoplifter, bool OnAlert)
	{
	}

	[IteratorStateMachine(typeof(_003CShopping_003Ed__160))]
	private IEnumerator Shopping()
	{
		return null;
	}

	private bool SamplePosition(Vector3 target, out Vector3 position)
	{
		position = default(Vector3);
		return false;
	}

	public void StopAgent()
	{
	}

	[IteratorStateMachine(typeof(_003CMoveToNetwork_003Ed__163))]
	public IEnumerator MoveToNetwork(Vector3 target, bool isFromCheckout = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveTo_003Ed__164))]
	public IEnumerator MoveTo(Vector3 target, bool isFromCheckout = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CTakeProductsFromDisplay_003Ed__165))]
	private IEnumerator TakeProductsFromDisplay(DisplaySlot displaySlot, int productID)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWalkAroundIdle_003Ed__166))]
	private IEnumerator WalkAroundIdle(DisplaySlot displaySlot)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CExitStore_003Ed__167))]
	private IEnumerator ExitStore(bool gothit = false)
	{
		return null;
	}

	public void SetGotHitLayer()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForAvailableCheckout_003Ed__169))]
	private IEnumerator WaitForAvailableCheckout()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CProcessShoppingList_003Ed__171))]
	private IEnumerator ProcessShoppingList()
	{
		return null;
	}

	private bool TakeProduct(DisplaySlot displaySlot, int productID)
	{
		return false;
	}

	public void TakeProductOrder(DisplaySlot displaySlot)
	{
	}

	private void DisplayMissingScaleInfo()
	{
	}

	private void CheckScaleStatus(Scale removedScale)
	{
	}

	private void OnScaleRemoved(Scale removed)
	{
	}

	[IteratorStateMachine(typeof(_003CGoToScale_003Ed__177))]
	private IEnumerator GoToScale()
	{
		return null;
	}

	private void GoToCheckout()
	{
	}

	private void CheckForProductsMissing(bool shortchange)
	{
	}

	private void OnDisplayMoved(Display display)
	{
	}

	private void OnPlayerInteractionDisabled()
	{
	}

	public void OnCheckoutBoxed(Checkout boxedCheckout)
	{
	}

	public void OnCheckoutMoved(Checkout movedCheckout)
	{
	}

	public void ResetShoplifter()
	{
	}

	public void SetShoplifterRunSettings()
	{
	}

	public void SetShoplifterRunSettings_Client()
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}
}
