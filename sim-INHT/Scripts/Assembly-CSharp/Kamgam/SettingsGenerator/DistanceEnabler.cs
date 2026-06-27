using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class DistanceEnabler : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStateCoroutine_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool enable;

			public DistanceEnabler _003C_003E4__this;

			private float _003Cstep_003E5__2;

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
			public _003CStateCoroutine_003Ed__7(int _003C_003E1__state)
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

		private Light light;

		private Transform player;

		private bool coroutineRunning;

		private Coroutine stateCoroutine;

		private float defaultIntensity;

		private void Start()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CStateCoroutine_003Ed__7))]
		private IEnumerator StateCoroutine(bool enable)
		{
			return null;
		}
	}
}
