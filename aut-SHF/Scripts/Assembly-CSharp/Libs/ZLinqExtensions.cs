using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ZLinq;

namespace Libs
{
	public static class ZLinqExtensions
	{
		[CompilerGenerated]
		private sealed class _003CAsEnumerable_003Ed__0<TEnumerator, T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where TEnumerator : struct, IValueEnumerator<T>
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private ValueEnumerable<TEnumerator, T> valueEnumerable;

			public ValueEnumerable<TEnumerator, T> _003C_003E3__valueEnumerable;

			private TEnumerator _003Ce_003E5__2;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(T);
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
			public _003CAsEnumerable_003Ed__0(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[IteratorStateMachine(typeof(_003CAsEnumerable_003Ed__0<, >))]
		public static IEnumerable<T> AsEnumerable<TEnumerator, T>(this ValueEnumerable<TEnumerator, T> valueEnumerable) where TEnumerator : struct, IValueEnumerator<T>
		{
			return null;
		}
	}
}
