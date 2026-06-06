using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using R3.Internal;

namespace R3.Collections
{
	[StructLayout(LayoutKind.Auto)]
	public struct FreeListCore<T> where T : class
	{
		private readonly object gate;

		private T?[]? values;

		private int lastIndex;

		public bool IsDisposed => lastIndex == -2;

		public FreeListCore(object gate)
		{
			values = null;
			this.gate = gate;
			lastIndex = -1;
		}

		public ReadOnlySpan<T?> AsSpan()
		{
			int num = Volatile.Read(ref lastIndex);
			T[] array = Volatile.Read(ref values);
			if (array == null)
			{
				return ReadOnlySpan<T>.Empty;
			}
			return array.AsSpan(0, num + 1);
		}

		public void Add(T item, out int removeKey)
		{
			lock (gate)
			{
				ThrowHelper.ThrowObjectDisposedIf(IsDisposed, typeof(FreeListCore<T>));
				if (values == null)
				{
					values = new T[1];
				}
				int num = FindNullIndex(values);
				if (num == -1)
				{
					int num2 = values.Length;
					T[] array = ((num2 == 1) ? new T[4] : new T[num2 + num2 / 2]);
					Array.Copy(values, array, num2);
					Volatile.Write(ref values, array);
					num = num2;
				}
				values[num] = item;
				if (lastIndex < num)
				{
					Volatile.Write(ref lastIndex, num);
				}
				removeKey = num;
			}
		}

		public void Remove(int index)
		{
			lock (gate)
			{
				if (values != null && index < values.Length)
				{
					ref T? reference = ref values[index];
					if (reference == null)
					{
						throw new KeyNotFoundException($"key index {index} is not found.");
					}
					reference = null;
					if (index == lastIndex)
					{
						Volatile.Write(ref lastIndex, FindLastNonNullIndex(values, index));
					}
				}
			}
		}

		public bool RemoveSlow(T value)
		{
			lock (gate)
			{
				if (values == null)
				{
					return false;
				}
				if (lastIndex < 0)
				{
					return false;
				}
				int num = -1;
				Span<T> span = values.AsSpan(0, lastIndex + 1);
				for (int i = 0; i < span.Length; i++)
				{
					if (span[i] == value)
					{
						num = i;
						break;
					}
				}
				if (num != -1)
				{
					Remove(num);
					return true;
				}
			}
			return false;
		}

		public void Clear(bool removeArray)
		{
			lock (gate)
			{
				if (lastIndex >= 0)
				{
					values.AsSpan(0, lastIndex + 1).Clear();
				}
				if (removeArray)
				{
					values = null;
				}
				if (lastIndex != -2)
				{
					lastIndex = -1;
				}
			}
		}

		public void Dispose()
		{
			lock (gate)
			{
				values = null;
				lastIndex = -2;
			}
		}

		private unsafe static int FindNullIndex(T?[] target)
		{
			fixed (IntPtr* ptr = &Unsafe.As<T, IntPtr>(ref MemoryMarshal.GetReference(target.AsSpan())))
			{
				void* pointer = ptr;
				return new ReadOnlySpan<IntPtr>(pointer, target.Length).IndexOf(IntPtr.Zero);
			}
		}

		private unsafe static int FindLastNonNullIndex(T?[] target, int lastIndex)
		{
			fixed (IntPtr* ptr = &Unsafe.As<T, IntPtr>(ref MemoryMarshal.GetReference(target.AsSpan())))
			{
				void* pointer = ptr;
				ReadOnlySpan<IntPtr> readOnlySpan = new ReadOnlySpan<IntPtr>(pointer, lastIndex);
				for (int num = readOnlySpan.Length - 1; num >= 0; num--)
				{
					if (readOnlySpan[num] != IntPtr.Zero)
					{
						return num;
					}
				}
				return -1;
			}
		}
	}
}
