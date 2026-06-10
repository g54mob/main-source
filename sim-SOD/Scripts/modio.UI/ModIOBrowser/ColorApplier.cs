using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class ColorApplier<T> : MonoBehaviour where T : Graphic
	{
		[CompilerGenerated]
		private sealed class _003CAttemptToRecolorSoon_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ColorApplier<T> _003C_003E4__this;

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
			public _003CAttemptToRecolorSoon_003Ed__6(int _003C_003E1__state)
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

		public ColorSetterType color;

		public ColorScheme colorScheme;

		protected virtual T graphic => null;

		private void Start()
		{
		}

		private bool Apply()
		{
			return false;
		}

		[IteratorStateMachine(typeof(ColorApplier<>._003CAttemptToRecolorSoon_003Ed__6))]
		private IEnumerator AttemptToRecolorSoon()
		{
			return null;
		}
	}
}
