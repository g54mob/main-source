using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pug.UnityExtensions
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[] { typeof(int) })]
	public struct NativeCircularBuffer<T> : INativeDisposable, IDisposable where T : unmanaged
	{
		public struct DataView
		{
			public readonly int Offset;

			public readonly int Length;

			public NativeArray<T> ArrayView;

			public T this[int index]
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				readonly get
				{
					return ArrayView[(index + Offset) % ArrayView.Length];
				}
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set
				{
					ArrayView[(index + Offset) % ArrayView.Length] = value;
				}
			}

			public DataView(int offset, int length, NativeArray<T> arrayView)
			{
				Offset = offset;
				Length = length;
				ArrayView = arrayView;
			}

			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckParamsAndThrow(int offset, int length, NativeArray<T> arrayView)
			{
				if (!arrayView.IsCreated)
				{
					throw new ArgumentException("arrayView");
				}
				if (offset < 0 || offset >= arrayView.Length)
				{
					throw new ArgumentException("offset");
				}
				if (length < 0 || length > arrayView.Length)
				{
					throw new ArgumentException("length");
				}
			}

			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckIndexAndThrow(int index, int length)
			{
				if (index < 0 || index >= length)
				{
					throw new IndexOutOfRangeException();
				}
			}
		}

		private NativeList<T> list;

		private int readPtr;

		private int writePtr;

		public readonly bool IsCreated
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return list.IsCreated;
			}
		}

		public readonly bool Wraps => readPtr > writePtr;

		public readonly int Capacity => list.Length;

		public readonly int Readable
		{
			get
			{
				if (Wraps)
				{
					return list.Length - readPtr + writePtr;
				}
				return writePtr - readPtr;
			}
		}

		public readonly int WritableWithoutResize
		{
			get
			{
				if (!Wraps)
				{
					return list.Length - writePtr + readPtr;
				}
				return readPtr - writePtr;
			}
		}

		public NativeCircularBuffer(AllocatorManager.AllocatorHandle allocator, int capacity)
		{
			list = new NativeList<T>(capacity, allocator);
			list.Length = list.Capacity;
			readPtr = 0;
			writePtr = 0;
		}

		public void Reset()
		{
			readPtr = 0;
			writePtr = 0;
		}

		public void Write(T t)
		{
			if (WritableWithoutResize < 1)
			{
				GrowTo(list.Length + 1);
			}
			list[writePtr % list.Length] = t;
			writePtr++;
			if (writePtr > list.Length)
			{
				writePtr %= list.Length;
			}
		}

		public void Write(NativeArray<T>.ReadOnly t)
		{
			if (WritableWithoutResize < t.Length)
			{
				GrowTo(list.Length + t.Length - WritableWithoutResize);
			}
			NativeArray<T> dst = list.AsArray();
			int num = Mathf.Clamp(list.Length - writePtr, 0, t.Length);
			if (num > 0)
			{
				NativeArray<T>.Copy(t, 0, dst, writePtr, num);
			}
			int num2 = t.Length - num;
			if (num2 > 0)
			{
				NativeArray<T>.Copy(t, num, dst, 0, num2);
			}
			writePtr += t.Length;
			if (writePtr > list.Length)
			{
				writePtr %= list.Length;
			}
		}

		public void Write(ArraySegment<T> t)
		{
			if (WritableWithoutResize < t.Count)
			{
				GrowTo(list.Length + t.Count - WritableWithoutResize);
			}
			NativeArray<T> dst = list.AsArray();
			int num = Mathf.Clamp(list.Length - writePtr, 0, t.Count);
			if (num > 0)
			{
				NativeArray<T>.Copy(t.Array, t.Offset, dst, writePtr, num);
			}
			int num2 = t.Count - num;
			if (num2 > 0)
			{
				NativeArray<T>.Copy(t.Array, t.Offset + num, dst, 0, num2);
			}
			writePtr += t.Count;
			if (writePtr > list.Length)
			{
				writePtr %= list.Length;
			}
		}

		public bool TryPeek(out T t)
		{
			if (Readable < 1)
			{
				t = default(T);
				return false;
			}
			t = list[readPtr];
			return true;
		}

		public int Peek(ArraySegment<T> t)
		{
			int num = Mathf.Min(Readable, t.Count);
			NativeArray<T> src = list.AsArray();
			int num2 = Mathf.Clamp((Wraps ? list.Length : writePtr) - readPtr, 0, num);
			if (num2 > 0)
			{
				NativeArray<T>.Copy(src, readPtr, t.Array, t.Offset, num2);
			}
			int num3 = num - num2;
			if (num3 > 0)
			{
				NativeArray<T>.Copy(src, 0, t.Array, t.Offset + num2, num3);
			}
			return num;
		}

		public int Peek(NativeArray<T> t)
		{
			int num = Mathf.Min(Readable, t.Length);
			NativeArray<T> src = list.AsArray();
			int num2 = Mathf.Clamp((Wraps ? list.Length : writePtr) - readPtr, 0, num);
			if (num2 > 0)
			{
				NativeArray<T>.Copy(src, readPtr, t, 0, num2);
			}
			int num3 = num - num2;
			if (num3 > 0)
			{
				NativeArray<T>.Copy(src, 0, t, num2, num3);
			}
			return num;
		}

		public int SkipRead(int count)
		{
			count = Mathf.Min(Readable, count);
			readPtr = (readPtr + count) % list.Length;
			return count;
		}

		public bool TryRead(out T t)
		{
			if (!TryPeek(out t))
			{
				return false;
			}
			readPtr = (readPtr + 1) % list.Length;
			return true;
		}

		public int Read(NativeArray<T> t)
		{
			int num = Peek(t);
			readPtr = (readPtr + num) % list.Length;
			return num;
		}

		public int Read(ArraySegment<T> t)
		{
			int num = Peek(t);
			readPtr = (readPtr + num) % list.Length;
			return num;
		}

		public void GrowTo(int newSize)
		{
			int length = list.Length;
			if (length >= newSize)
			{
				return;
			}
			list.Length = newSize;
			if (list.Length < list.Capacity)
			{
				list.Length = list.Capacity;
			}
			if (Wraps)
			{
				int num = list.Length - length;
				int num2 = writePtr;
				NativeArray<T> nativeArray = list.AsArray();
				NativeArray<T>.Copy(nativeArray, 0, nativeArray, length, Mathf.Min(num2, num));
				if (num2 > num)
				{
					NativeArray<T>.Copy(nativeArray, num, nativeArray, 0, num2 - num);
					writePtr = num2 - num;
				}
				else
				{
					writePtr = length + num2;
				}
			}
		}

		public DataView ViewRaw()
		{
			return new DataView(0, Capacity, list.AsArray());
		}

		public DataView ViewReadRelative()
		{
			return new DataView(readPtr, Readable, list.AsArray());
		}

		public override string ToString()
		{
			return string.Format("{0}[Capacity: {1}, Readable: {2}, WritableWithoutResize: {3}, ReadPtr: {4}, WritePtr: {5}]", "NativeCircularBuffer", list.Length, Readable, WritableWithoutResize, readPtr, writePtr);
		}

		public JobHandle Dispose(JobHandle inputDeps)
		{
			return list.Dispose(inputDeps);
		}

		public void Dispose()
		{
			list.Dispose();
		}
	}
}
