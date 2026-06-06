using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;

namespace Pathfinding.Collections
{
	public struct CircularBuffer<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__39 : IEnumerator<T>, IEnumerator, IDisposable
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
			public _003CGetEnumerator_003Ed__39(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CircularBuffer<T> _003C_003E4__this;

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
			public _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__40(int _003C_003E1__state)
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

		internal T[] data;

		internal int head;

		private int length;

		public readonly int Length
		{
			[IgnoredByDeepProfiler]
			get
			{
				return 0;
			}
		}

		public readonly int AbsoluteStartIndex => 0;

		public readonly int AbsoluteEndIndex => 0;

		public readonly ref T First
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				throw null;
			}
		}

		public readonly ref T Last
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				throw null;
			}
		}

		readonly int IReadOnlyCollection<T>.Count
		{
			[IgnoredByDeepProfiler]
			get
			{
				return 0;
			}
		}

		public T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			readonly get
			{
				return default(T);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public CircularBuffer(int initialCapacity)
		{
			data = null;
			head = 0;
			length = 0;
		}

		public CircularBuffer(T[] backingArray)
		{
			data = null;
			head = 0;
			length = 0;
		}

		public void Clear()
		{
		}

		public void AddRange(List<T> items)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public void PushStart(T item)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public void PushEnd(T item)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public void Push(bool toStart, T item)
		{
		}

		[IgnoredByDeepProfiler]
		public T PopStart()
		{
			return default(T);
		}

		[IgnoredByDeepProfiler]
		public T PopEnd()
		{
			return default(T);
		}

		[IgnoredByDeepProfiler]
		public T Pop(bool fromStart)
		{
			return default(T);
		}

		public readonly T GetBoundaryValue(bool start)
		{
			return default(T);
		}

		public void InsertAbsolute(int index, T item)
		{
		}

		public void Splice(int startIndex, int toRemove, List<T> toInsert)
		{
		}

		public void SpliceAbsolute(int startIndex, int toRemove, List<T> toInsert)
		{
		}

		public void SpliceUninitialized(int startIndex, int toRemove, int toInsert)
		{
		}

		public void SpliceUninitializedAbsolute(int startIndex, int toRemove, int toInsert)
		{
		}

		private void MoveAbsolute(int startIndex, int endIndex, int deltaIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public readonly T GetAbsolute(int index)
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public readonly void SetAbsolute(int index, T value)
		{
		}

		private void Grow()
		{
		}

		public void Pool()
		{
		}

		[IteratorStateMachine(typeof(CircularBuffer<>._003CGetEnumerator_003Ed__39))]
		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(CircularBuffer<>._003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__40))]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public CircularBuffer<T> Clone()
		{
			return default(CircularBuffer<T>);
		}
	}
}
