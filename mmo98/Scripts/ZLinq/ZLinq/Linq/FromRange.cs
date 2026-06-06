using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRange : IValueEnumerator<int>, IDisposable
	{
		internal readonly int count;

		internal readonly int start;

		internal readonly int to;

		private int value;

		public FromRange(int start, int count)
		{
			this.count = count;
			this.start = start;
			to = start + count;
			value = start;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = this.count;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<int> span)
		{
			span = default(ReadOnlySpan<int>);
			return false;
		}

		public bool TryCopyTo(Span<int> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var num, out var length))
			{
				FillIncremental(destination.Slice(0, length), start + num);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out int current)
		{
			if (value < to)
			{
				current = value;
				value++;
				return true;
			}
			current = 0;
			return false;
		}

		public void Dispose()
		{
		}

		internal static void FillIncremental(Span<int> span, int start)
		{
			ref int reference = ref MemoryMarshal.GetReference(span);
			ref int right = ref Unsafe.Add(ref reference, span.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = start++;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
