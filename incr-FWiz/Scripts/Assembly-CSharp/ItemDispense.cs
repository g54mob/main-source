using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class ItemDispense : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPassOutAllitems_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ItemDispense _003C_003E4__this;

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
		public _003CPassOutAllitems_003Ed__8(int _003C_003E1__state)
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

	public List<ItemStack> ItemsStacks;

	public float Dir;

	public float DirRand;

	public float SendDistance;

	public float DispenseTime;

	[SerializeField]
	private EventReference _dispenseSound;

	public void Initiate(List<ItemStack> itemsStacks)
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CPassOutAllitems_003Ed__8))]
	public IEnumerator PassOutAllitems()
	{
		return null;
	}

	public void CreateItem()
	{
	}

	public void Complete()
	{
	}
}
