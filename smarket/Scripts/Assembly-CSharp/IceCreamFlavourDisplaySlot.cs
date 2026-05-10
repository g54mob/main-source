using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class IceCreamFlavourDisplaySlot : DisplaySlot, IDisplaySlotProductPlacementCondition
{
	[CompilerGenerated]
	private sealed class _003CToggleInstancedAnimated_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CToggleInstancedAnimated_003Ed__12(int _003C_003E1__state)
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
	private IceCreamFlavourInteractable m_FlavourInteractable;

	public override int ProductID => 0;

	public override int ProductCount => 0;

	public override bool Full => false;

	public override bool HasTakeHint => false;

	public bool CanAdd => false;

	public override Product TakeProductFromDisplay()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CToggleInstancedAnimated_003Ed__12))]
	protected override IEnumerator ToggleInstancedAnimated(Product product, bool value, Tween moveTween, Vector3 position)
	{
		return null;
	}

	public override void AddProduct(int productID, Product item)
	{
	}

	bool IDisplaySlotProductPlacementCondition.CanAdd(ProductSO p)
	{
		return false;
	}
}
