using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Libs
{
	public class CircularBuffer<T> : IEnumerable<T>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__19 : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			public CircularBuffer<T> _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003CGetEnumerator_003Ed__19(int _003C_003E1__state)
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

		private T[] data;

		private int top;

		private int bottom;

		private int mask;

		public int Count => 0;

		public T this[int i]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public CircularBuffer()
		{
		}

		public CircularBuffer(int capacity)
		{
		}

		private static int Pow2(uint n)
		{
			return 0;
		}

		private void Extend()
		{
		}

		public void Insert(int i, T elem)
		{
		}

		public void InsertFirst(T elem)
		{
		}

		public void InsertLast(T elem)
		{
		}

		public void Erase(int i)
		{
		}

		public void EraseFirst()
		{
		}

		public void EraseLast()
		{
		}

		[IteratorStateMachine(typeof(CircularBuffer<>._003CGetEnumerator_003Ed__19))]
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
