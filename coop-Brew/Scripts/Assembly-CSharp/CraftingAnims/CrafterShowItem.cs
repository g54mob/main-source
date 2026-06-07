using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CraftingAnims
{
	public class CrafterShowItem : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_ItemShow_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float waitTime;

			public string item;

			public CrafterShowItem _003C_003E4__this;

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
			public _003C_ItemShow_003Ed__3(int _003C_003E1__state)
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

		private CrafterController crafterController;

		public void Awake()
		{
		}

		public void ItemShow(string item, float waitTime)
		{
		}

		[IteratorStateMachine(typeof(_003C_ItemShow_003Ed__3))]
		private IEnumerator _ItemShow(string item, float waitTime)
		{
			return null;
		}
	}
}
