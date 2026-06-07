using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Log;
using UnityEngine;

namespace Coherence
{
	internal class SimulatorFramerate
	{
		public class SimulatorFramerateLimiter : MonoBehaviour
		{
			[CompilerGenerated]
			private sealed class _003CForceTargetFrameRateLoop_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private object _003C_003E2__current;

				public SimulatorFramerateLimiter _003C_003E4__this;

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
				public _003CForceTargetFrameRateLoop_003Ed__8(int _003C_003E1__state)
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

			private Coherence.Log.Logger logger;

			private static int targetFrameRate;

			private Coroutine loop;

			private bool changed;

			public static void Init()
			{
			}

			private void Awake()
			{
			}

			private void OnEnable()
			{
			}

			private void OnDisable()
			{
			}

			[IteratorStateMachine(typeof(_003CForceTargetFrameRateLoop_003Ed__8))]
			private IEnumerator ForceTargetFrameRateLoop()
			{
				return null;
			}

			private void ForceTargetFrameRate()
			{
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
		}
	}
}
