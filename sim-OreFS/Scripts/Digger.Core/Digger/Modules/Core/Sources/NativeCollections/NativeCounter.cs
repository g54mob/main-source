using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Digger.Modules.Core.Sources.NativeCollections
{
	[NativeContainer]
	public struct NativeCounter
	{
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct Concurrent
		{
			[NativeDisableUnsafePtrRestriction]
			internal unsafe int* m_Counter;

			internal int increment;

			public unsafe int Increment()
			{
				return Interlocked.Add(ref *m_Counter, increment);
			}

			public unsafe int Decrement()
			{
				return Interlocked.Add(ref *m_Counter, -increment);
			}

			public unsafe int Add(int value)
			{
				return Interlocked.Add(ref *m_Counter, value);
			}
		}

		[NativeDisableUnsafePtrRestriction]
		private unsafe int* m_Counter;

		private int increment;

		private Allocator m_AllocatorLabel;

		public unsafe int Count
		{
			get
			{
				return *m_Counter;
			}
			set
			{
				*m_Counter = value;
			}
		}

		public unsafe bool IsCreated => m_Counter != null;

		public unsafe NativeCounter(Allocator label, int inc = 1)
		{
			m_AllocatorLabel = label;
			increment = inc;
			m_Counter = (int*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<int>(), 4, label);
			Count = 0;
		}

		public unsafe int Increment()
		{
			return *m_Counter += increment;
		}

		public unsafe int Decrement()
		{
			return *m_Counter -= increment;
		}

		public unsafe int Add(int value)
		{
			return *m_Counter += value;
		}

		public unsafe void Dispose()
		{
			UnsafeUtility.Free(m_Counter, m_AllocatorLabel);
			m_Counter = null;
		}

		public unsafe Concurrent ToConcurrent()
		{
			Concurrent result = default(Concurrent);
			result.increment = increment;
			result.m_Counter = m_Counter;
			return result;
		}
	}
}
