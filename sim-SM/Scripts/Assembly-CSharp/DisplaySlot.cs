using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class DisplaySlot : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CToggleInstancedAnimated_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CToggleInstancedAnimated_003Ed__69(int _003C_003E1__state)
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

	public Action<DisplaySlot> OnProductRemoved;

	[SerializeField]
	private PriceTag m_PriceTag;

	[SerializeField]
	private Label m_Label;

	[SerializeField]
	private Highlightable m_Highlightable;

	[SerializeField]
	private Transform m_InteractionPosition;

	[SerializeField]
	private Vector2 m_InteractionPositionMargin;

	public List<Product> m_Products;

	private Display m_Display;

	private float m_CurrentPrice;

	private ItemQuantity m_ProductCountData;

	private Restocker m_OccupiedRestocker;

	private DisplayProductTransformCalculator m_TransformCalculator;

	private LabelMaskController m_LabelMaskController;

	private Dictionary<Product, Coroutine> m_InstancedActivationCoroutine;

	public bool IsLabelEnabled => false;

	public bool IsPriceTagEnabled => false;

	public virtual bool Full => false;

	public virtual int ProductID => 0;

	public Display Display => null;

	public float Price => 0f;

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

	public virtual bool HasTakeHint => false;

	public virtual bool HasUseHint => false;

	public virtual int ProductCount => 0;

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

	public bool IsSlotRequiredFill()
	{
		return false;
	}

	public bool IsNeedRefill()
	{
		return false;
	}

	public void Initialize()
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

	public int GetIndexFromDisplay()
	{
		return 0;
	}

	public bool IsEmptySlot()
	{
		return false;
	}

	public void SpawnProduct(int productID, int count)
	{
	}

	public void ReOrderProduct(int productID)
	{
	}

	public virtual void AddProduct(int productID, Product item)
	{
	}

	public void AddProductWithoutAnimate(int productID, Product item)
	{
	}

	[IteratorStateMachine(typeof(_003CToggleInstancedAnimated_003Ed__69))]
	protected virtual IEnumerator ToggleInstancedAnimated(Product product, bool value, Tween moveTween, Vector3 position)
	{
		return null;
	}

	private void ToggleInstancedAnimated(Product product, bool value, Vector3 position)
	{
	}

	public virtual Product TakeProductFromDisplay()
	{
		return null;
	}

	public int WholesaleOrderRemoveProductFromDisplaySlot(int count)
	{
		return 0;
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

	public void RemoveFromDisplayManagerWhileCarrying()
	{
	}

	public void AddBackToDisplayManagerAfterPlaced()
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

	internal ProductSO PeekProductSO()
	{
		return null;
	}

	public bool CanRestockWith(int productID)
	{
		return false;
	}
}
