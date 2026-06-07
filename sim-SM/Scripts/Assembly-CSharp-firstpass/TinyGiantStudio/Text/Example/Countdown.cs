using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TinyGiantStudio.Text.Example
{
	public class Countdown : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCountdownRoutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Countdown _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003CCountdownRoutine_003Ed__6(int _003C_003E1__state)
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
		private bool startCountdownOnStart;

		[Space]
		[SerializeField]
		private Modular3DText modular3DText;

		[Space]
		[SerializeField]
		private string textAfterCountdownEnds;

		[Space]
		[SerializeField]
		private int duration;

		[Tooltip("How fast the duration goes down.\nValue of 1 = normal time.")]
		[SerializeField]
		private float timeStep;

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CCountdownRoutine_003Ed__6))]
		private IEnumerator CountdownRoutine()
		{
			return null;
		}
	}
}
