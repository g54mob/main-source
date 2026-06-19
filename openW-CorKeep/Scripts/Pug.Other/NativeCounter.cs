using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

[NativeContainer]
public struct NativeCounter
{
	[NativeContainer]
	[NativeContainerIsAtomicWriteOnly]
	public struct Concurrent
	{
		[NativeDisableUnsafePtrRestriction]
		private unsafe int* m_Counter;

		public unsafe static implicit operator Concurrent(NativeCounter cnt)
		{
			Concurrent result = default(Concurrent);
			result.m_Counter = cnt.m_Counter;
			return result;
		}

		public unsafe int Increment()
		{
			return Interlocked.Increment(ref *m_Counter);
		}
	}

	[NativeDisableUnsafePtrRestriction]
	private unsafe int* m_Counter;

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

	public unsafe NativeCounter(Allocator label)
	{
		m_AllocatorLabel = label;
		m_Counter = (int*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<int>(), 4, label);
		Count = 0;
	}

	public unsafe int Increment()
	{
		return ++(*m_Counter);
	}

	public unsafe void Dispose()
	{
		UnsafeUtility.Free(m_Counter, m_AllocatorLabel);
		m_Counter = null;
	}
}
