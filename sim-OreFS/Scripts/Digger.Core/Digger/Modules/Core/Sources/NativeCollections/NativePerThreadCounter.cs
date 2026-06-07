using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Digger.Modules.Core.Sources.NativeCollections
{
	[NativeContainer]
	public struct NativePerThreadCounter
	{
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct Concurrent
		{
			[NativeDisableUnsafePtrRestriction]
			internal unsafe int* m_Counter;

			[NativeSetThreadIndex]
			internal int m_ThreadIndex;

			public unsafe void Increment()
			{
				m_Counter[16 * m_ThreadIndex]++;
			}

			public unsafe void Add(int value)
			{
				m_Counter[16 * m_ThreadIndex] += value;
			}
		}

		[NativeDisableUnsafePtrRestriction]
		private unsafe int* m_Counter;

		private Allocator m_AllocatorLabel;

		public const int IntsPerCacheLine = 16;

		public unsafe int Count
		{
			get
			{
				int num = 0;
				for (int i = 0; i < 128; i++)
				{
					num += m_Counter[16 * i];
				}
				return num;
			}
			set
			{
				for (int i = 1; i < 128; i++)
				{
					m_Counter[16 * i] = 0;
				}
				*m_Counter = value;
			}
		}

		public unsafe bool IsCreated => m_Counter != null;

		public unsafe NativePerThreadCounter(Allocator label)
		{
			m_AllocatorLabel = label;
			m_Counter = (int*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<int>() * 16 * 128, 4, label);
			Count = 0;
		}

		public unsafe void Increment()
		{
			(*m_Counter)++;
		}

		public unsafe void Add(int value)
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
