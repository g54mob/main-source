using System;
using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.NativeCollections
{
	[NativeContainer]
	public struct LongNativeCounter
	{
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct Concurrent
		{
			[NativeDisableUnsafePtrRestriction]
			internal unsafe long* m_Counter;

			internal long increment;

			public unsafe long Increment()
			{
				return Interlocked.Add(ref *m_Counter, increment);
			}

			public unsafe long Decrement()
			{
				return Interlocked.Add(ref *m_Counter, -increment);
			}

			public unsafe long Add(long value)
			{
				return Interlocked.Add(ref *m_Counter, value);
			}
		}

		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct ConcurrentDouble
		{
			[NativeDisableUnsafePtrRestriction]
			internal unsafe long* m_Counter;

			internal long multiplier;

			internal double maxSafeDouble;

			internal double minSafeDouble;

			public unsafe void Add(double value)
			{
				long value2 = (long)(math.clamp(value, minSafeDouble, maxSafeDouble) * (double)multiplier);
				Interlocked.Add(ref *m_Counter, value2);
			}
		}

		[NativeDisableUnsafePtrRestriction]
		private unsafe long* m_Counter;

		private long increment;

		private Allocator m_AllocatorLabel;

		public unsafe long Count
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

		public unsafe LongNativeCounter(Allocator label, long inc = 1L)
		{
			m_AllocatorLabel = label;
			increment = inc;
			m_Counter = (long*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<long>(), 8, label);
			Count = 0L;
		}

		public unsafe long Increment()
		{
			return *m_Counter += increment;
		}

		public unsafe long Decrement()
		{
			return *m_Counter -= increment;
		}

		public unsafe long Add(long value)
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

		public unsafe ConcurrentDouble ToConcurrentDouble(long multiplier = 1000000L)
		{
			if (multiplier <= 0)
			{
				throw new ArgumentException("Multiplier must be positive", "multiplier");
			}
			ConcurrentDouble result = default(ConcurrentDouble);
			result.m_Counter = m_Counter;
			result.multiplier = multiplier;
			result.maxSafeDouble = 9.223372036854776E+18 / (double)multiplier;
			result.minSafeDouble = -9.223372036854776E+18 / (double)multiplier;
			return result;
		}
	}
}
