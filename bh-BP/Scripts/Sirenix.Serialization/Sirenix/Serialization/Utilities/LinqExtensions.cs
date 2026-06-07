using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sirenix.Serialization.Utilities
{
	internal static class LinqExtensions
	{
		[CompilerGenerated]
		private sealed class _003CAppend_003Ed__2<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerable<T> append;

			public IEnumerable<T> _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppend_003Ed__2(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			return null;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppend_003Ed__2<>))]
		public static IEnumerable<T> Append<T>(this IEnumerable<T> source, IEnumerable<T> append)
		{
			return null;
		}
	}
}
