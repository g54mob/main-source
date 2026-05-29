using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OnlineOrderInteraction : Interaction
{
	[CompilerGenerated]
	private sealed class _003COnThrowLoop_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public OnlineOrderInteraction _003C_003E4__this;

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
		public _003COnThrowLoop_003Ed__73(int _003C_003E1__state)
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
	private sealed class _003COnsellLoop_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public OnlineOrderInteraction _003C_003E4__this;

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
		public _003COnsellLoop_003Ed__75(int _003C_003E1__state)
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

	private const float TakeProductSpeedMultiplier = 1f;

	[SerializeField]
	private OrderNotebookContainer m_OrderNotebookContainer;

	[SerializeField]
	private OrderPaperBag m_OrderPaperBagPrefab;

	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private float m_PlacementRaycastDistance;

	[SerializeField]
	private LayerMask m_OnlineOrderInteractionLayer;

	[SerializeField]
	private float m_ProductInteractionInterval;

	[SerializeField]
	private Material m_HologramMaterial;

	[SerializeField]
	private Vector3 m_PaperBagPositionOffset;

	[SerializeField]
	private Vector3 m_PaperBagRotationOffset;

	[SerializeField]
	private int m_MaxBagItemCount;

	[SerializeField]
	private Camera m_ToolCamera;

	[SerializeField]
	private int m_StorePointPerDeliver;

	private bool m_PlacingMode;

	private bool m_holdingUse;

	private float m_lastPlaceTime;

	private bool m_holdingTake;

	private float m_lastTakeTime;

	private DisplaySlot m_CurrentDisplaySlot;

	private TrashBin m_CurrentTrashBin;

	private BoxPlacementArea m_TargetPlacementArea;

	private float m_PlacementRotation;

	private OrderPaperBag m_CurrentOrderPaperBag;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	public Action onOrderInteractionOpened;

	public Action onOrderInteractionClosed;

	private Spring<Vector3> m_PositionSpring;

	private Spring<Vector3> m_ScaleSpring;

	private Spring<Quaternion> m_RotationSpring;

	private bool m_IsOnThrow;

	private bool m_IsOnSell;

	private IEnumerator m_OnThrowCoroutine;

	private IEnumerator m_OnSellCoroutine;

	private Product m_CurrentProduct;

	private OnlineOrderCustomer m_CurrentCustomer;

	private MiniMap m_MiniMap;

	private OrderPaperBag m_PaperBagInteraction;

	private IPlacementArea m_CurrentPlacementArea;

	private PlayerInstance m_PlayerInstance;

	private NetworkOnlineOrderInteraction m_NetworkOrderInteraction;

	public OrderPaperBag CurrentOrderPaperBag => null;

	public OrderNotebookContainer OrderNotebookContainer => null;

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

	public bool IsInPlacingMode => false;

	private PlayerInstance PlayerInstance => null;

	private void Update()
	{
	}

	public OrderPaperBag CreatePaperBag()
	{
		return null;
	}

	public void TakePaperBag(OrderPaperBag paperBag)
	{
	}

	private void RemovePaperBag()
	{
	}

	private void OnPaperBagProductRemoved(int productId)
	{
	}

	private void OnPaperBagProductAdded(int productId)
	{
	}

	private void OnPaperBagOpened()
	{
	}

	public void EnableOrderInteraction()
	{
	}

	public void DisableOrderInteraction()
	{
	}

	private void OnEnable()
	{
	}

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSwap(bool positive)
	{
	}

	private void OnNext()
	{
	}

	private void OnPrevious()
	{
	}

	private void OnThrow(bool down)
	{
	}

	[IteratorStateMachine(typeof(_003COnThrowLoop_003Ed__73))]
	private IEnumerator OnThrowLoop()
	{
		return null;
	}

	private void OnSell(bool down)
	{
	}

	[IteratorStateMachine(typeof(_003COnsellLoop_003Ed__75))]
	private IEnumerator OnsellLoop()
	{
		return null;
	}

	private void OnUse(bool down)
	{
	}

	private void PlaceBoxToPlacementArea()
	{
	}

	private void OnTake(bool down)
	{
	}

	private void OnBack()
	{
	}

	private void OnClose()
	{
	}

	private void OnDrop(bool down = false)
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	public void OnAttachTag()
	{
	}

	public void OnDetachTag()
	{
	}

	private void CheckForInteraction()
	{
	}

	private void SetCurrentPlacementArea(IPlacementArea placementArea)
	{
	}

	private void SortedPlacementAreaHints(bool show)
	{
	}

	private void SetPaperBagInteraction(OrderPaperBag paperBag)
	{
	}

	private void SetCurrentProduct(Product value)
	{
	}

	private void SetCurrentCustomer(OnlineOrderCustomer Customer)
	{
	}

	private void CheckForPlacingItem()
	{
	}

	private void CheckForTakingItem()
	{
	}

	private void Drop()
	{
	}

	private void PlaceProductToDisplay()
	{
	}

	private void TakeProductFromDisplay()
	{
	}

	private void ThrowIntoTrashBin()
	{
	}

	private void DeliverOrder()
	{
	}

	public void OrderExpired(OrderListData order)
	{
	}

	private void SetCurrentDisplaySlot(DisplaySlot displaySlot)
	{
	}

	private void SetCurrentTrashBin(TrashBin value)
	{
	}

	private void DefaultHints(bool show)
	{
	}

	private void PlacingModeHints(bool show)
	{
	}

	private void TakeProductHints(bool show)
	{
	}

	private void DeliverOrderHints(bool show)
	{
	}

	private void PlaceProductHints(bool show)
	{
	}

	private void AlignOnBoxPlacement()
	{
	}

	private void CheckForAreaPlacement()
	{
	}

	private void PlacementAreaHints()
	{
	}

	public void LoadPaperBagData(IReadOnlyList<int> productIds)
	{
	}

	public void OnPaperBagInteracted(OrderPaperBag value)
	{
	}
}
