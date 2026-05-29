using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace PG
{
	public class DisappearingText : MonoBehaviour
	{
		public enum DisappearAction
		{
			OnTriggerEnter = 0,
			OnTriggerExit = 1
		}

		[CompilerGenerated]
		private sealed class _003COnDisappear_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DisappearingText _003C_003E4__this;

			private float _003Ctimer_003E5__2;

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
			public _003COnDisappear_003Ed__6(int _003C_003E1__state)
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

		public TextMeshPro Text;

		public float DisappearTime;

		public DisappearAction Action;

		private Coroutine DisappearCoroutine;

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		[IteratorStateMachine(typeof(_003COnDisappear_003Ed__6))]
		private IEnumerator OnDisappear()
		{
			return null;
		}
	}
}
