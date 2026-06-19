using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CrafterDoubleByproduct : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COutputOtherItem_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrafterDoubleByproduct _003C_003E4__this;

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
		public _003COutputOtherItem_003Ed__6(int _003C_003E1__state)
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
	private Crafter _crafter;

	[SerializeField]
	private float _chance;

	public float DoubleOutputInterval;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnCraftItem(ItemType type)
	{
	}

	[IteratorStateMachine(typeof(_003COutputOtherItem_003Ed__6))]
	public IEnumerator OutputOtherItem()
	{
		return null;
	}

	public void AddChance(float chance)
	{
	}
}
