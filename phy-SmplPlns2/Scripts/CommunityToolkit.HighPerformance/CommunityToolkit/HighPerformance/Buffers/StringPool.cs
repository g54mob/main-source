using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using CommunityToolkit.HighPerformance.Helpers;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance.Buffers
{
	public sealed class StringPool
	{
		private struct FixedSizePriorityMap
		{
			private struct MapEntry
			{
				public int HashCode;

				public string? Value;

				public int NextIndex;

				public int HeapIndex;
			}

			private struct HeapEntry
			{
				public uint Timestamp;

				public int MapIndex;
			}

			private const int EndOfList = -1;

			private readonly int[] buckets;

			private readonly MapEntry[] mapEntries;

			private readonly HeapEntry[] heapEntries;

			private int count;

			private uint timestamp;

			public object SyncRoot
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return buckets;
				}
			}

			public FixedSizePriorityMap(int capacity)
			{
				buckets = new int[capacity];
				mapEntries = new MapEntry[capacity];
				heapEntries = new HeapEntry[capacity];
				count = 0;
				timestamp = 0u;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Add(string value, int hashcode)
			{
				ref string reference = ref TryGet(value.AsSpan(), hashcode);
				if (Unsafe.IsNullRef(ref reference))
				{
					Insert(value, hashcode);
				}
				else
				{
					reference = value;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public string GetOrAdd(string value, int hashcode)
			{
				ref string reference = ref TryGet(value.AsSpan(), hashcode);
				if (!Unsafe.IsNullRef(ref reference))
				{
					return reference;
				}
				Insert(value, hashcode);
				return value;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public string GetOrAdd(ReadOnlySpan<char> span, int hashcode)
			{
				ref string reference = ref TryGet(span, hashcode);
				if (!Unsafe.IsNullRef(ref reference))
				{
					return reference;
				}
				string text = span.ToString();
				Insert(text, hashcode);
				return text;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool TryGet(ReadOnlySpan<char> span, int hashcode, [NotNullWhen(true)] out string? value)
			{
				ref string reference = ref TryGet(span, hashcode);
				if (!Unsafe.IsNullRef(ref reference))
				{
					value = reference;
					return true;
				}
				value = null;
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Reset()
			{
				buckets.AsSpan().Clear();
				mapEntries.AsSpan().Clear();
				heapEntries.AsSpan().Clear();
				count = 0;
				timestamp = 0u;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private unsafe ref string TryGet(ReadOnlySpan<char> span, int hashcode)
			{
				ref MapEntry source = ref mapEntries.DangerousGetReference();
				ref MapEntry reference = ref *(MapEntry*)null;
				int num = buckets.Length;
				int i = hashcode & (num - 1);
				int num2 = buckets.DangerousGetReferenceAt(i) - 1;
				while ((uint)num2 < (uint)num)
				{
					reference = ref Unsafe.Add(ref source, (nint)(uint)num2);
					if (reference.HashCode == hashcode && reference.Value.AsSpan().SequenceEqual(span))
					{
						UpdateTimestamp(ref reference.HeapIndex);
						return ref reference.Value;
					}
					num2 = reference.NextIndex;
				}
				return ref *(string*)null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void Insert(string value, int hashcode)
			{
				ref int source = ref buckets.DangerousGetReference();
				ref MapEntry source2 = ref mapEntries.DangerousGetReference();
				ref HeapEntry reference = ref heapEntries.DangerousGetReference();
				int mapIndex;
				int num;
				if (count == mapEntries.Length)
				{
					mapIndex = reference.MapIndex;
					num = 0;
					Remove(Unsafe.Add(ref source2, (nint)(uint)mapIndex).HashCode, mapIndex);
				}
				else
				{
					mapIndex = count;
					num = count;
				}
				int num2 = hashcode & (buckets.Length - 1);
				ref int reference2 = ref Unsafe.Add(ref source, (nint)(uint)num2);
				ref MapEntry reference3 = ref Unsafe.Add(ref source2, (nint)(uint)mapIndex);
				ref HeapEntry reference4 = ref Unsafe.Add(ref reference, (nint)(uint)num);
				reference3.HashCode = hashcode;
				reference3.Value = value;
				reference3.NextIndex = reference2 - 1;
				reference3.HeapIndex = num;
				reference2 = mapIndex + 1;
				count++;
				reference4.MapIndex = mapIndex;
				UpdateTimestamp(ref reference3.HeapIndex);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void Remove(int hashcode, int mapIndex)
			{
				ref MapEntry source = ref mapEntries.DangerousGetReference();
				int i = hashcode & (buckets.Length - 1);
				int num = buckets.DangerousGetReferenceAt(i) - 1;
				int num2 = -1;
				ref MapEntry reference;
				while (true)
				{
					reference = ref Unsafe.Add(ref source, (nint)(uint)num);
					if (num == mapIndex)
					{
						break;
					}
					num2 = num;
					num = reference.NextIndex;
				}
				if (num2 != -1)
				{
					Unsafe.Add(ref source, (nint)(uint)num2).NextIndex = reference.NextIndex;
				}
				else
				{
					buckets.DangerousGetReferenceAt(i) = reference.NextIndex + 1;
				}
				count--;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void UpdateTimestamp(ref int heapIndex)
			{
				int num = heapIndex;
				int num2 = count;
				ref MapEntry source = ref mapEntries.DangerousGetReference();
				ref HeapEntry source2 = ref heapEntries.DangerousGetReference();
				ref HeapEntry reference = ref Unsafe.Add(ref source2, (nint)(uint)num);
				uint num3 = timestamp;
				if (num3 == uint.MaxValue)
				{
					UpdateAllTimestamps();
					num3 = (uint)(num2 - 1);
				}
				reference.Timestamp = (timestamp = num3 + 1);
				int num6;
				while (true)
				{
					ref HeapEntry reference2 = ref reference;
					int num4 = num * 2 + 1;
					int num5 = num * 2 + 2;
					num6 = num;
					if (num4 < num2)
					{
						ref HeapEntry reference3 = ref Unsafe.Add(ref source2, (nint)(uint)num4);
						if (reference3.Timestamp < reference2.Timestamp)
						{
							reference2 = ref reference3;
							num6 = num4;
						}
					}
					if (num5 < num2)
					{
						ref HeapEntry reference4 = ref Unsafe.Add(ref source2, (nint)(uint)num5);
						if (reference4.Timestamp < reference2.Timestamp)
						{
							reference2 = ref reference4;
							num6 = num5;
						}
					}
					if (Unsafe.AreSame(ref reference, ref reference2))
					{
						break;
					}
					Unsafe.Add(ref source, (nint)(uint)reference.MapIndex).HeapIndex = num6;
					Unsafe.Add(ref source, (nint)(uint)reference2.MapIndex).HeapIndex = num;
					num = num6;
					HeapEntry heapEntry = reference;
					reference = reference2;
					reference2 = heapEntry;
					reference = ref Unsafe.Add(ref source2, (nint)(uint)num);
				}
				heapIndex = num6;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void UpdateAllTimestamps()
			{
				int num = count;
				ref HeapEntry source = ref heapEntries.DangerousGetReference();
				for (int i = 0; i < num; i++)
				{
					Unsafe.Add(ref source, (nint)(uint)i).Timestamp = (uint)i;
				}
			}
		}

		private const int DefaultSize = 2048;

		private const int MinimumSize = 32;

		private readonly FixedSizePriorityMap[] maps;

		private readonly int numberOfMaps;

		public static StringPool Shared { get; } = new StringPool();

		public int Size { get; }

		public StringPool()
			: this(2048)
		{
		}

		public StringPool(int minimumSize)
		{
			if (minimumSize <= 0)
			{
				ThrowArgumentOutOfRangeException();
			}
			minimumSize = Math.Max(minimumSize, 32);
			FindFactors(minimumSize, 2, out var x, out var y);
			FindFactors(minimumSize, 3, out var x2, out var y2);
			FindFactors(minimumSize, 4, out var x3, out var y3);
			uint num = x * y;
			uint num2 = x2 * y2;
			uint num3 = x3 * y3;
			if (num2 < num)
			{
				num = num2;
				x = x2;
				y = y2;
			}
			if (num3 < num)
			{
				num = num3;
				x = x3;
				y = y3;
			}
			Span<FixedSizePriorityMap> span = (maps = new FixedSizePriorityMap[x]);
			for (int i = 0; i < span.Length; i++)
			{
				span[i] = new FixedSizePriorityMap((int)y);
			}
			numberOfMaps = (int)x;
			Size = (int)num;
			static void FindFactors(int size, int factor, out uint reference, out uint reference2)
			{
				double num4 = Math.Sqrt((double)size / (double)factor);
				double num5 = (double)factor * num4;
				reference = BitOperations.RoundUpToPowerOf2((uint)num4);
				reference2 = BitOperations.RoundUpToPowerOf2((uint)num5);
			}
		}

		public void Add(string value)
		{
			if (value.Length == 0)
			{
				return;
			}
			int hashCode = GetHashCode(value.AsSpan());
			int i = hashCode & (numberOfMaps - 1);
			ref FixedSizePriorityMap reference = ref maps.DangerousGetReferenceAt(i);
			lock (reference.SyncRoot)
			{
				reference.Add(value, hashCode);
			}
		}

		public string GetOrAdd(string value)
		{
			if (value.Length == 0)
			{
				return string.Empty;
			}
			int hashCode = GetHashCode(value.AsSpan());
			int i = hashCode & (numberOfMaps - 1);
			ref FixedSizePriorityMap reference = ref maps.DangerousGetReferenceAt(i);
			lock (reference.SyncRoot)
			{
				return reference.GetOrAdd(value, hashCode);
			}
		}

		public string GetOrAdd(ReadOnlySpan<char> span)
		{
			if (span.IsEmpty)
			{
				return string.Empty;
			}
			int hashCode = GetHashCode(span);
			int i = hashCode & (numberOfMaps - 1);
			ref FixedSizePriorityMap reference = ref maps.DangerousGetReferenceAt(i);
			lock (reference.SyncRoot)
			{
				return reference.GetOrAdd(span, hashCode);
			}
		}

		public unsafe string GetOrAdd(ReadOnlySpan<byte> span, Encoding encoding)
		{
			if (span.IsEmpty)
			{
				return string.Empty;
			}
			int maxCharCount = encoding.GetMaxCharCount(span.Length);
			SpanOwner<char> spanOwner = SpanOwner<char>.Allocate(maxCharCount);
			try
			{
				fixed (byte* bytes = span)
				{
					fixed (char* ptr = &spanOwner.DangerousGetReference())
					{
						int chars = encoding.GetChars(bytes, span.Length, ptr, maxCharCount);
						return GetOrAdd(new ReadOnlySpan<char>(ptr, chars));
					}
				}
			}
			finally
			{
				spanOwner.Dispose();
			}
		}

		public bool TryGet(ReadOnlySpan<char> span, [NotNullWhen(true)] out string? value)
		{
			if (span.IsEmpty)
			{
				value = string.Empty;
				return true;
			}
			int hashCode = GetHashCode(span);
			int i = hashCode & (numberOfMaps - 1);
			ref FixedSizePriorityMap reference = ref maps.DangerousGetReferenceAt(i);
			lock (reference.SyncRoot)
			{
				return reference.TryGet(span, hashCode, out value);
			}
		}

		public void Reset()
		{
			Span<FixedSizePriorityMap> span = maps.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				ref FixedSizePriorityMap reference = ref span[i];
				lock (reference.SyncRoot)
				{
					reference.Reset();
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetHashCode(ReadOnlySpan<char> span)
		{
			return HashCode<char>.Combine(span);
		}

		private static void ThrowArgumentOutOfRangeException()
		{
			throw new ArgumentOutOfRangeException("minimumSize", "The requested size must be greater than 0");
		}
	}
}
