using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace GLTFast
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	[DebuggerDisplay("Length = {m_Count}")]
	internal struct ReadOnlyNativeStridedArray<T> where T : unmanaged
	{
		[NativeDisableUnsafePtrRestriction]
		private unsafe void* m_Buffer;

		private readonly int m_Count;

		private readonly int m_ByteStride;

		public unsafe T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return UnsafeUtility.ReadArrayElementWithStride<T>(m_Buffer, index, m_ByteStride);
			}
		}

		internal unsafe ReadOnlyNativeStridedArray(void* buffer, int byteLength, int offset, int count, int byteStride)
		{
			m_Buffer = (byte*)buffer + offset;
			m_Count = count;
			m_ByteStride = byteStride;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckReadIndex(int index)
		{
			if (index < 0 || index >= m_Count)
			{
				throw new IndexOutOfRangeException($"Index {index} is out of range (must be between 0 and {m_Count - 1}).");
			}
		}
	}
}
