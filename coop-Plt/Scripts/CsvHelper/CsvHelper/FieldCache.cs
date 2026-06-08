using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CsvHelper
{
	internal class FieldCache
	{
		[DebuggerDisplay("HashCode = {HashCode}, Next = {Next}, Value = {Value}")]
		private struct Entry
		{
			public uint HashCode;

			public int Next;

			public string Value;
		}

		private readonly int maxFieldSize;

		private int size;

		private int[] buckets;

		private Entry[] entries;

		private int count;

		public FieldCache(int initialSize = 128, int maxFieldSize = 128)
		{
			this.maxFieldSize = maxFieldSize;
			size = initialSize;
			buckets = new int[size];
			entries = new Entry[size];
		}

		public string GetField(char[] buffer, int start, int length)
		{
			if (length == 0)
			{
				return string.Empty;
			}
			if (length > maxFieldSize)
			{
				return new string(buffer, start, length);
			}
			uint hashCode = GetHashCode(buffer, start, length);
			ref int bucket = ref GetBucket(hashCode);
			int num = bucket - 1;
			while ((uint)num < (uint)entries.Length)
			{
				ref Entry reference = ref entries[num];
				if (reference.HashCode == hashCode && reference.Value.AsSpan().SequenceEqual(new Span<char>(buffer, start, length)))
				{
					return reference.Value;
				}
				num = reference.Next;
			}
			if (count == entries.Length)
			{
				Resize();
				bucket = ref GetBucket(hashCode);
			}
			ref Entry reference2 = ref entries[count];
			reference2.HashCode = hashCode;
			reference2.Next = bucket - 1;
			reference2.Value = new string(buffer, start, length);
			bucket = count + 1;
			count++;
			return reference2.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint GetHashCode(char[] buffer, int start, int length)
		{
			uint num = 17u;
			for (int i = start; i < start + length; i++)
			{
				num = num * 31 + buffer[i];
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ref int GetBucket(uint hashCode)
		{
			return ref buckets[hashCode & (buckets.Length - 1)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Resize()
		{
			size *= 2;
			Entry[] array = new Entry[size];
			Array.Copy(entries, array, count);
			buckets = new int[size];
			for (int i = 0; i < count; i++)
			{
				ref Entry reference = ref array[i];
				if (reference.Next >= -1)
				{
					ref int bucket = ref GetBucket(reference.HashCode);
					reference.Next = bucket - 1;
					bucket = i + 1;
				}
			}
			entries = array;
		}
	}
}
