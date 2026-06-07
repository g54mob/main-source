using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;

namespace Pathfinding.Collections
{
	public struct NativeCircularBuffer<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : struct
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__44 : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			public NativeCircularBuffer<T> _003C_003E4__this;

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
			public _003CGetEnumerator_003Ed__44(int _003C_003E1__state)
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
		private sealed class _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NativeCircularBuffer<T> _003C_003E4__this;

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
			public _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__45(int _003C_003E1__state)
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

		[NativeDisableUnsafePtrRestriction]
		internal unsafe T* data;

		internal int head;

		private int length;

		private int capacityMask;

		public AllocatorManager.AllocatorHandle Allocator;

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

		readonly int IReadOnlyCollection<T>.Count => 0;

		public readonly bool IsCreated => false;

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

		public unsafe NativeCircularBuffer(AllocatorManager.AllocatorHandle allocator)
		{
			data = null;
			head = 0;
			length = 0;
			capacityMask = 0;
			Allocator = default(AllocatorManager.AllocatorHandle);
		}

		public unsafe NativeCircularBuffer(int initialCapacity, AllocatorManager.AllocatorHandle allocator)
		{
			data = null;
			head = 0;
			length = 0;
			capacityMask = 0;
			Allocator = default(AllocatorManager.AllocatorHandle);
		}

		public unsafe NativeCircularBuffer(CircularBuffer<T> buffer, out ulong gcHandle)
		{
			data = null;
			head = 0;
			length = 0;
			capacityMask = 0;
			Allocator = default(AllocatorManager.AllocatorHandle);
			gcHandle = default(ulong);
		}

		public unsafe NativeCircularBuffer(T[] data, int head, int length, out ulong gcHandle)
		{
			this.data = null;
			this.head = 0;
			this.length = 0;
			capacityMask = 0;
			Allocator = default(AllocatorManager.AllocatorHandle);
			gcHandle = default(ulong);
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

		public T Pop(bool fromStart)
		{
			return default(T);
		}

		public readonly T GetBoundaryValue(bool start)
		{
			return default(T);
		}

		public void TrimTo(int length)
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Grow()
		{
		}

		public void Dispose()
		{
		}

		[IteratorStateMachine(typeof(NativeCircularBuffer<>._003CGetEnumerator_003Ed__44))]
		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(NativeCircularBuffer<>._003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__45))]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public NativeCircularBuffer<T> Clone()
		{
			return default(NativeCircularBuffer<T>);
		}
	}
}
