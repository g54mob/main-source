using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyStuff.CharacterCustomizer
{
	public class CustomizerIdleController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CIdleCycleRoutine_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomizerIdleController _003C_003E4__this;

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
			public _003CIdleCycleRoutine_003Ed__14(int _003C_003E1__state)
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

		[Header("Animation")]
		[Tooltip("The animator to control")]
		[SerializeField]
		private Animator animator;

		[Tooltip("Integer parameter name for idle variant selection")]
		[SerializeField]
		private string idleIndexParam;

		[Tooltip("Number of idle variants available (excluding base idle)")]
		[SerializeField]
		private int variantCount;

		[Header("Timing")]
		[Tooltip("Minimum time between idle variants (in seconds)")]
		[SerializeField]
		private float intervalMin;

		[Tooltip("Maximum time between idle variants (in seconds)")]
		[SerializeField]
		private float intervalMax;

		[Tooltip("How long to wait before resetting to base idle")]
		[SerializeField]
		private float resetDelay;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Coroutine idleRoutine;

		private bool isActive;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void StartIdleCycle()
		{
		}

		public void StopIdleCycle()
		{
		}

		[IteratorStateMachine(typeof(_003CIdleCycleRoutine_003Ed__14))]
		private IEnumerator IdleCycleRoutine()
		{
			return null;
		}
	}
}
