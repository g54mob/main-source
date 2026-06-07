using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Digger.Modules.Core.Sources.NativeCollections
{
	[NativeContainer]
	public struct LongNativePerThreadCounter
	{
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct Concurrent
		{
			[NativeDisableUnsafePtrRestriction]
			internal unsafe long* m_Counter;

			[NativeSetThreadIndex]
			internal int m_ThreadIndex;

			public unsafe void Increment()
			{
				m_Counter[8 * m_ThreadIndex]++;
			}

			public unsafe void Add(long value)
			{
				m_Counter[8 * m_ThreadIndex] += value;
			}
		}

		[NativeDisableUnsafePtrRestriction]
		private unsafe long* m_Counter;

		private Allocator m_AllocatorLabel;

		public const int LongsPerCacheLine = 8;

		public unsafe long Count
		{
			get
			{
				long num = 0L;
				for (int i = 0; i < 128; i++)
				{
					num += m_Counter[8 * i];
				}
				return num;
			}
			set
			{
				for (int i = 1; i < 128; i++)
				{
					m_Counter[8 * i] = 0L;
				}
				*m_Counter = value;
			}
		}

		public unsafe bool IsCreated => m_Counter != null;

		public unsafe LongNativePerThreadCounter(Allocator label)
		{
			m_AllocatorLabel = label;
			m_Counter = (long*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<long>() * 8 * 128, 8, label);
			Count = 0L;
		}

		public unsafe void Increment()
		{
			(*m_Counter)++;
		}

		public unsafe void Add(long value)
		{
			*m_Counter += value;
		}

		public unsafe void Dispose()
		{
			UnsafeUtility.Free(m_Counter, m_AllocatorLabel);
			m_Counter = null;
		}

		public unsafe Concurrent ToConcurrent()
		{
			Concurrent result = default(Concurrent);
			result.m_Counter = m_Counter;
			result.m_ThreadIndex = 0;
			return result;
		}
	}
}
