using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class VendingSlot : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CToggleInstancedAnimated_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tween moveTween;

		public Product product;

		public Vector3 position;

		public bool value;

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
		public _003CToggleInstancedAnimated_003Ed__62(int _003C_003E1__state)
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

	[SerializeField]
	private VendingPriceTag m_PriceTag;

	[SerializeField]
	private Label m_Label;

	[SerializeField]
	private Highlightable m_Highlightable;

	[SerializeField]
	private Transform m_InteractionPosition;

	[SerializeField]
	private Vector2 m_InteractionPositionMargin;

	[SerializeField]
	private Transform m_ProductFallStartTransform;

	public List<Product> m_Products;

	private VendingMachine m_Vending;

	private float m_CurrentPrice;

	private ItemQuantity m_ProductCountData;

	private Restocker m_OccupiedRestocker;

	private VendingMachineTransformCalculator m_TransformCalculator;

	private VendingLabelMaskController m_VendingLabelMaskController;

	private Dictionary<Product, Coroutine> m_InstancedActivationCoroutine;

	private Coroutine m_ProductFallCoroutine;

	public bool IsLabelEnabled => false;

	public bool IsPriceTagEnabled => false;

	public bool Full => false;

	public int ProductID => 0;

	public VendingMachine Vending => null;

	public float Price => 0f;

	public Transform FallTransform => null;

	public ItemQuantity Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Vector3 InteractionPosition => default(Vector3);

	public Quaternion InteractionRotation => default(Quaternion);

	public Vector3 InteractionPositionForward => default(Vector3);

	public bool HasProduct => false;

	public Transform PriceTagTransform => null;

	public bool EnablePriceTagCollider
	{
		set
		{
		}
	}

	public bool EnableLabelCollider
	{
		set
		{
		}
	}

	public bool IsDiscounted => false;

	public int ProductCount => 0;

	public Restocker OccupiedRestocker
	{
		set
		{
		}
	}

	public Label Label
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Initialize()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public bool IsOccupiedByOthers(Restocker restocker)
	{
		return false;
	}

	public bool IsOccupiedByMe(Restocker restocker)
	{
		return false;
	}

	public int GetIndexFromVending()
	{
		return 0;
	}

	public void SpawnProduct(int productID, int count)
	{
	}

	public void AddProduct(int productID, Product item)
	{
	}

	[IteratorStateMachine(typeof(_003CToggleInstancedAnimated_003Ed__62))]
	private IEnumerator ToggleInstancedAnimated(Product product, bool value, Tween moveTween, Vector3 position)
	{
		return null;
	}

	public Product TakeProductFromVending()
	{
		return null;
	}

	public void NPCBuyProductAnimated(NPC npc)
	{
	}

	public void OnButtonPushed(NPC npc)
	{
	}

	public void NPCBuyProductIdle()
	{
	}

	public void Clear()
	{
	}

	public void ResetSlot()
	{
	}

	public void ResetSlotWholesale()
	{
	}

	public void RemoveFromVendingManagerWhileCarrying()
	{
	}

	public void AddBackToVendingManagerAfterPlaced()
	{
	}

	public void ClearProductData()
	{
	}

	private void SetPriceTag()
	{
	}

	private void SetLabel()
	{
	}

	private void ToggleProductType(ProductSO product)
	{
	}

	private void PricingChanged(int productID)
	{
	}

	public void RequestLabelMaskUpdate()
	{
	}
}
