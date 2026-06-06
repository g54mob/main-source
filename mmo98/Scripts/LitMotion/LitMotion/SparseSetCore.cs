using System;
using System.Runtime.CompilerServices;

namespace LitMotion
{
	internal sealed class SparseSetCore
	{
		public struct Slot : IEquatable<Slot>
		{
			public int Next;

			public int DenseIndex;

			public int Version;

			public readonly bool Equals(Slot other)
			{
				if (other.Next == Next && other.DenseIndex == DenseIndex)
				{
					return other.Version == Version;
				}
				return false;
			}

			public override readonly bool Equals(object obj)
			{
				if (obj is Slot other)
				{
					return Equals(other);
				}
				return false;
			}

			public override readonly int GetHashCode()
			{
				return HashCode.Combine(Next, DenseIndex, Version);
			}
		}

		private Slot[] slots;

		private int freeSlot = -1;

		public int Capacity => slots.Length;

		public SparseSetCore(int initialCapacity = 32)
		{
			EnsureCapacity(initialCapacity);
		}

		public void EnsureCapacity(int capacity)
		{
			int num;
			if (slots == null)
			{
				slots = new Slot[capacity];
				num = 0;
			}
			else
			{
				num = slots.Length;
				if (num >= capacity)
				{
					return;
				}
				int num2;
				for (num2 = num; num2 < capacity; num2 *= 2)
				{
				}
				Array.Resize(ref slots, num2);
			}
			Span<Slot> span = slots.AsSpan(num);
			for (int i = 0; i < span.Length; i++)
			{
				int num3 = num + i;
				span[i] = new Slot
				{
					Next = ((num3 == capacity - 1) ? freeSlot : (num3 + 1)),
					DenseIndex = -1,
					Version = 1
				};
			}
			freeSlot = num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SparseIndex Alloc(int denseIndex)
		{
			if (freeSlot == -1)
			{
				EnsureCapacity(slots.Length * 2);
			}
			int num = freeSlot;
			ref Slot reference = ref slots[num];
			freeSlot = reference.Next;
			reference.Next = -1;
			reference.DenseIndex = denseIndex;
			if (reference.Version == 0)
			{
				reference.Version = 1;
			}
			return new SparseIndex(num, reference.Version);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Free(SparseIndex sparseIndex)
		{
			ref Slot reference = ref slots[sparseIndex.Index];
			reference.Next = freeSlot;
			reference.Version++;
			freeSlot = sparseIndex.Index;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref Slot GetSlotRefUnchecked(int index)
		{
			return ref slots[index];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			for (int i = 0; i < slots.Length; i++)
			{
				slots[i] = new Slot
				{
					Next = ((i == slots.Length - 1) ? (-1) : (i + 1)),
					DenseIndex = -1,
					Version = 1
				};
			}
			freeSlot = 0;
		}
	}
}
