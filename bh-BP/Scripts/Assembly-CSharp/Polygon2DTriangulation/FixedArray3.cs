using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Polygon2DTriangulation
{
	public struct FixedArray3<T> : IEnumerable<T>, IEnumerable where T : class
	{
		[CompilerGenerated]
		private sealed class _003CEnumerate_003Ed__10 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FixedArray3<T> _003C_003E4__this;

			public FixedArray3<T> _003C_003E3___003C_003E4__this;

			private int _003Ci_003E5__2;

			T IEnumerator<T>.Current
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
			public _003CEnumerate_003Ed__10(int _003C_003E1__state)
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

		public T _0;

		public T _1;

		public T _2;

		public T this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Contains(T value)
		{
			return false;
		}

		public int IndexOf(T value)
		{
			return 0;
		}

		public void Clear()
		{
		}

		public void Clear(T value)
		{
		}

		[IteratorStateMachine(typeof(FixedArray3<>._003CEnumerate_003Ed__10))]
		private IEnumerable<T> Enumerate()
		{
			return null;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
