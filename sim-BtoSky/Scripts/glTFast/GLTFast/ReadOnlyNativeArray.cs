using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace GLTFast
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	[DebuggerDisplay("Length = {Length}")]
	internal struct ReadOnlyNativeArray<T> where T : unmanaged
	{
		[NativeDisableUnsafePtrRestriction]
		internal unsafe void* m_Buffer;

		internal int m_Length;

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Length;
			}
		}

		public unsafe T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return UnsafeUtility.ReadArrayElement<T>(m_Buffer, index);
			}
		}

		public unsafe bool IsCreated
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Buffer != null;
			}
		}

		internal unsafe ReadOnlyNativeArray(NativeArray<T> nativeArray)
		{
			m_Buffer = nativeArray.GetUnsafeReadOnlyPtr();
			m_Length = nativeArray.Length;
		}

		internal unsafe ReadOnlyNativeArray(void* buffer, int length)
		{
			m_Buffer = buffer;
			m_Length = length;
		}

		public unsafe ReadOnlyNativeArray<T> GetSubArray(int start, int length)
		{
			return new ReadOnlyNativeArray<T>((byte*)m_Buffer + (long)UnsafeUtility.SizeOf<T>() * (long)start, length);
		}

		public unsafe NativeSlice<T> ToSlice()
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(m_Buffer, m_Length, Allocator.None).Slice();
		}

		public unsafe NativeArray<T>.ReadOnly AsNativeArrayReadOnly()
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(m_Buffer, m_Length, Allocator.None).AsReadOnly();
		}

		public unsafe ReadOnlyNativeStridedArray<TTarget> ToStrided<TTarget>(int offset, int count, int byteStride) where TTarget : unmanaged
		{
			return new ReadOnlyNativeStridedArray<TTarget>(m_Buffer, Length * UnsafeUtility.SizeOf<T>(), offset, count, byteStride);
		}

		public unsafe void* GetUnsafeReadOnlyPtr()
		{
			return m_Buffer;
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckGetSubArrayArguments(int start, int length)
		{
			if (start < 0)
			{
				throw new ArgumentOutOfRangeException("start", "start must be >= 0");
			}
			if (start + length > Length)
			{
				throw new ArgumentOutOfRangeException("length", $"sub array range {start}-{start + length - 1} is outside the range of the native array 0-{Length - 1}");
			}
			if (start + length < 0)
			{
				throw new ArgumentException($"sub array range {start}-{start + length - 1} caused an integer overflow and is outside the range of the native array 0-{Length - 1}");
			}
		}

		public void CopyTo(NativeArray<T> array)
		{
			Copy(this, array);
		}

		public unsafe ReadOnlyNativeArray<TTarget> Reinterpret<TTarget>() where TTarget : unmanaged
		{
			long num = UnsafeUtility.SizeOf<T>();
			long num2 = UnsafeUtility.SizeOf<TTarget>();
			long num3 = Length * num / num2;
			return new ReadOnlyNativeArray<TTarget>(m_Buffer, (int)num3);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckReinterpretSize<TTarget>(long uSize, long byteLen, long uLen)
		{
			if (uLen * uSize != byteLen)
			{
				throw new InvalidOperationException($"Types {typeof(T)} (array length {Length}) and {typeof(TTarget)} cannot be aliased due to size constraints. The size of the types and lengths involved must line up.");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckElementReadAccess(int index)
		{
			if ((uint)index >= (uint)m_Length)
			{
				throw new IndexOutOfRangeException($"Index {index} is out of range (must be between 0 and {m_Length - 1}).");
			}
		}

		private unsafe static void Copy(ReadOnlyNativeArray<T> src, NativeArray<T> dst)
		{
			byte* unsafePtr = (byte*)dst.GetUnsafePtr();
			UnsafeUtility.MemCpy(unsafePtr, src.m_Buffer, src.Length * UnsafeUtility.SizeOf<T>());
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCopyLengths(int srcLength, int dstLength)
		{
			if (srcLength != dstLength)
			{
				throw new ArgumentException("source and destination length must be the same");
			}
		}
	}
}
