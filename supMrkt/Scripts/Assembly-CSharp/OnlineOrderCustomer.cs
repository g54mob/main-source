using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class OnlineOrderCustomer : MonoBehaviour, IInteractable, IPoolable
{
	[CompilerGenerated]
	private sealed class _003CExitStore_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public OnlineOrderCustomer _003C_003E4__this;

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
		public _003CExitStore_003Ed__101(int _003C_003E1__state)
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
	private sealed class _003CWave_003Ed__106 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public OnlineOrderCustomer _003C_003E4__this;

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
		public _003CWave_003Ed__106(int _003C_003E1__state)
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

	private const float m_IdleWaitingDuration = 3f;

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
	private GameObject m_ShoppingBag;

	[SerializeField]
	private Transform m_RightHand;

	[SerializeField]
	private int m_StorePointPenalty;

	[SerializeField]
	private int m_WrongShoplifterPenalty;

	[SerializeField]
	private bool m_GenderIsMale;

	[SerializeField]
	private TextMeshPro m_NameText;

	[SerializeField]
	private GameObject m_Indicator;

	private Product m_CurrentItem;

	private bool m_IsPickingUp;

	private bool m_IsPlayingAnimation;

	private bool m_IsSatisfiedCustomer;

	private bool m_InCheckout;

	private bool m_HandingPayment;

	private bool m_IsShoplifterRunning;

	private Shoplifter m_Shoplifter;

	private GameObject m_CurrentSpeechObject;

	private bool m_HasBeaten;

	public bool isShoplifter;

	public bool isShoplifterCaught;

	private OrderListData m_Order;

	private bool m_IsOrderDelivered;

	private Coroutine m_WaveCoroutine;

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

	public TextMeshPro NameText
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

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public OrderListData Order
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int SpawnIndex { get; set; }

	public int PrefabIndex { get; set; }

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

	private void OnEnable()
	{
	}

	public void ManualUpdate()
	{
	}

	private void OnDisable()
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
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

	private void CheckExpiration()
	{
	}

	private void OrderExpired()
	{
	}

	public void OrderCancelled()
	{
	}

	[IteratorStateMachine(typeof(_003CExitStore_003Ed__101))]
	private IEnumerator ExitStore()
	{
		return null;
	}

	private void ResetCustomer()
	{
	}

	private void DespawnCustomer()
	{
	}

	public void DeliverOrder(OrderListData Order)
	{
	}

	public void PlayAnimations()
	{
	}

	[IteratorStateMachine(typeof(_003CWave_003Ed__106))]
	private IEnumerator Wave()
	{
		return null;
	}
}
