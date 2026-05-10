using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class ShoplifterTutorialCustomer : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CExitStore_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShoplifterTutorialCustomer _003C_003E4__this;

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
		public _003CExitStore_003Ed__79(int _003C_003E1__state)
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
	private sealed class _003CMoveTo_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 target;

		public ShoplifterTutorialCustomer _003C_003E4__this;

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
		public _003CMoveTo_003Ed__76(int _003C_003E1__state)
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
	private sealed class _003CProcessShoppingList_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShoplifterTutorialCustomer _003C_003E4__this;

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
		public _003CProcessShoppingList_003Ed__81(int _003C_003E1__state)
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
	private sealed class _003CShopping_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShoplifterTutorialCustomer _003C_003E4__this;

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
		public _003CShopping_003Ed__75(int _003C_003E1__state)
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
	private sealed class _003CTakeProductsFromDisplay_003Ed__77 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShoplifterTutorialCustomer _003C_003E4__this;

		public DisplaySlot displaySlot;

		public int productID;

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
		public _003CTakeProductsFromDisplay_003Ed__77(int _003C_003E1__state)
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
	private sealed class _003CWalkAroundIdle_003Ed__78 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DisplaySlot displaySlot;

		public ShoplifterTutorialCustomer _003C_003E4__this;

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
		public _003CWalkAroundIdle_003Ed__78(int _003C_003E1__state)
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

	private const float m_ShoplifterGotHitAnimationDuration = 1.5f;

	private const float m_ShoplifterLookForProductAnimationDuration = 7f;

	private const float m_RotatingToDisplayTime = 0.3f;

	private const float m_TakingProductTime = 0.2f;

	private float m_RotationSmoothness;

	public const float m_SpreadForce = 22f;

	private Transform m_TargetExitPoint;

	[SerializeField]
	private CustomerAnimator m_Animator;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private Transform m_RightHand;

	[SerializeField]
	private float m_PickingProductAnimationDuration;

	private ItemQuantity m_ShoppingList;

	private ItemQuantity m_ShoppingCart;

	private Product m_CurrentItem;

	private bool m_IsPickingUp;

	private bool m_IsPlayingAnimation;

	private bool m_FinishedShopping;

	private Display m_TargetDisplay;

	private TutorialShoplifter m_TutorialShoplifter;

	private GameObject m_CurrentSpeechObject;

	public bool isShoplifterCaught;

	public bool HasBeaten;

	private List<DisplaySlot> m_CachedDisplaySlots;

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

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private bool PurchasedProductOnce(int productID)
	{
		return false;
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

	public void GoToStore(Vector3 doorPosition)
	{
	}

	public void StartShopping()
	{
	}

	public void HoldProduct()
	{
	}

	public void ReleaseProduct()
	{
	}

	public void SpreadProducts(SecurityGuard securityGuard = null)
	{
	}

	public void RunAway(bool isHitByGuard = false, SecurityGuard securityGuard = null)
	{
	}

	private void OnShoplifterDetected(Shoplifter shoplifter, bool OnAlert)
	{
	}

	[IteratorStateMachine(typeof(_003CShopping_003Ed__75))]
	private IEnumerator Shopping()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveTo_003Ed__76))]
	private IEnumerator MoveTo(Vector3 target)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CTakeProductsFromDisplay_003Ed__77))]
	private IEnumerator TakeProductsFromDisplay(DisplaySlot displaySlot, int productID)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWalkAroundIdle_003Ed__78))]
	private IEnumerator WalkAroundIdle(DisplaySlot displaySlot)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CExitStore_003Ed__79))]
	private IEnumerator ExitStore(bool gothit = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CProcessShoppingList_003Ed__81))]
	private IEnumerator ProcessShoppingList()
	{
		return null;
	}

	private bool TakeProduct(DisplaySlot displaySlot, int productID)
	{
		return false;
	}

	private void OnDisplayMoved(Display display)
	{
	}

	private void OnPlayerInteractionDisabled()
	{
	}

	public void ResetShoplifter()
	{
	}

	private void SetShoplifterRunSettings()
	{
	}
}
