using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ButtonTest : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CIncrementMyIntCoroutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ButtonTest _003C_003E4__this;

			private int _003Cseconds_003E5__2;

			private int _003Ci_003E5__3;

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
			public _003CIncrementMyIntCoroutine_003Ed__4(int _003C_003E1__state)
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

		public int myInt;

		[Button(null, EButtonEnableMode.Always)]
		private void IncrementMyInt()
		{
		}

		[Button("Decrement My Int", EButtonEnableMode.Editor)]
		private void DecrementMyInt()
		{
		}

		[Button(null, EButtonEnableMode.Playmode)]
		private void LogMyInt(string prefix = "MyInt = ")
		{
		}

		[IteratorStateMachine(typeof(_003CIncrementMyIntCoroutine_003Ed__4))]
		[Button("StartCoroutine", EButtonEnableMode.Always)]
		private IEnumerator IncrementMyIntCoroutine()
		{
			return null;
		}
	}
}
