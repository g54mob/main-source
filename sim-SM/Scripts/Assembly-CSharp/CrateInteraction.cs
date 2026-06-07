using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CrateInteraction : Interaction
{
	[CompilerGenerated]
	private sealed class _003COnTakeLoop_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrateInteraction _003C_003E4__this;

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
		public _003COnTakeLoop_003Ed__48(int _003C_003E1__state)
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
	private sealed class _003COnThrowLoop_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrateInteraction _003C_003E4__this;

		private float _003Cm_HoldingTime_003E5__2;

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
		public _003COnThrowLoop_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003COnUseLoop_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrateInteraction _003C_003E4__this;

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
		public _003COnUseLoop_003Ed__42(int _003C_003E1__state)
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

	private const float m_HoldingInteractionTime = 0.5f;

	public Crate m_Crate;

	[SerializeField]
	private float m_ProductInteractionInterval;

	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private LayerMask m_InteractionLayer;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	private IInteractable m_CurrentInteractable;

	private DisplaySlot m_CurrentDisplaySlot;

	private VendingSlot m_CurrentVendingSlot;

	private Crate m_CurrentCrate;

	private bool m_IsOnUse;

	private bool m_IsOnTake;

	private bool m_IsOnThrow;

	private IEnumerator m_OnUseCoroutine;

	private IEnumerator m_OnTakeCoroutine;

	private IEnumerator m_OnThrowCoroutine;

	private float m_ClickTime;

	private PlayerInstance m_PlayerInstance;

	private NetworkCrateInteraction m_NetworkCrateInteraction;

	private float TotalProductInteractionInterval => 0f;

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

	public PlayerInstance PlayerInstance => null;

	public NetworkCrateInteraction NetworkCrateInteraction => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnThrow(bool down)
	{
	}

	private void OnTake(bool down)
	{
	}

	private void OnUse(bool down)
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

	[IteratorStateMachine(typeof(_003COnThrowLoop_003Ed__41))]
	private IEnumerator OnThrowLoop()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003COnUseLoop_003Ed__42))]
	private IEnumerator OnUseLoop()
	{
		return null;
	}

	private Product RemoveLocalProduct_Display(DisplaySlot slot)
	{
		return null;
	}

	private Product RemoveLocalProduct_Vending(VendingSlot slot)
	{
		return null;
	}

	private Product RemoveAndSpawnNetworkProduct_Display(DisplaySlot slot)
	{
		return null;
	}

	private Product RemoveAndSpawnNetworkProduct_Vending(VendingSlot slot)
	{
		return null;
	}

	private Product RespawnNetworkProduct(Product networkProduct)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003COnTakeLoop_003Ed__48))]
	private IEnumerator OnTakeLoop()
	{
		return null;
	}

	public void AddProductToDisplayNetwork(int productID, Vector3 productPosition, Quaternion productRotation, DisplaySlot targetDisplaySlot)
	{
	}

	public void AddProductToVendingNetwork(int productID, Vector3 productPosition, Quaternion productRotation, VendingSlot targetVendingSlot)
	{
	}

	private void CheckForInteraction()
	{
	}

	private void SetCurrentCrate(Crate crate)
	{
	}

	private void SetCurrentInteractable(IInteractable product)
	{
	}

	private void SetCurrentDisplaySlot(DisplaySlot displaySlot)
	{
	}

	private void SetCurrentVendingSlot(VendingSlot vendingSlot)
	{
	}

	public void EnableCrate()
	{
	}

	public void EnableCrateNetwork()
	{
	}

	public void BuyCrate()
	{
	}

	public void DisableCrate()
	{
	}

	public void DisableCrateNetwork()
	{
	}
}
