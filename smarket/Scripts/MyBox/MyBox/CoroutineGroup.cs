using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyBox
{
	public class CoroutineGroup
	{
		[CompilerGenerated]
		private sealed class _003CDoStart_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CoroutineGroup _003C_003E4__this;

			public IEnumerator coroutine;

			private Coroutine _003Cstarted_003E5__2;

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
			public _003CDoStart_003Ed__9(int _003C_003E1__state)
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

		private readonly MonoBehaviour _owner;

		private readonly List<Coroutine> _activeCoroutines;

		public int ActiveCoroutinesAmount => 0;

		public bool AnyProcessing => false;

		public CoroutineGroup(MonoBehaviour owner)
		{
		}

		public Coroutine StartCoroutine(IEnumerator coroutine)
		{
			return null;
		}

		public void StopAll()
		{
		}

		[IteratorStateMachine(typeof(_003CDoStart_003Ed__9))]
		private IEnumerator DoStart(IEnumerator coroutine)
		{
			return null;
		}
	}
}
