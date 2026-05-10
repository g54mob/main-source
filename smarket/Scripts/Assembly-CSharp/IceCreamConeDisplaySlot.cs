using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class IceCreamConeDisplaySlot : DisplaySlot, IDisplaySlotProductPlacementCondition
{
	[CompilerGenerated]
	private sealed class _003CComplete_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Sequence seq;

		public Product item;

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
		public _003CComplete_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003CToggleInstancedAnimated_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CToggleInstancedAnimated_003Ed__14(int _003C_003E1__state)
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
	private ProductSO m_Product;

	[SerializeField]
	private IndexedStaticInstancer m_Instancer;

	[SerializeField]
	private IceCreamConeInteractable m_ConeInteractable;

	public override int ProductCount => 0;

	public override int ProductID => 0;

	public override bool Full => false;

	public override bool HasTakeHint => false;

	public bool CanAdd => false;

	public override Product TakeProductFromDisplay()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CToggleInstancedAnimated_003Ed__14))]
	protected override IEnumerator ToggleInstancedAnimated(Product product, bool value, Tween moveTween, Vector3 position)
	{
		return null;
	}

	public override void AddProduct(int productID, Product item)
	{
	}

	[IteratorStateMachine(typeof(_003CComplete_003Ed__16))]
	private IEnumerator Complete(Product item, Sequence seq)
	{
		return null;
	}

	bool IDisplaySlotProductPlacementCondition.CanAdd(ProductSO p)
	{
		return false;
	}
}
