using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Enumerables
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ref struct ReadOnlySpanTokenizer<T> where T : IEquatable<T>
	{
		private readonly ReadOnlySpan<T> span;

		private readonly T separator;

		private int start;

		private int end;

		public readonly ReadOnlySpan<T> Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return span.Slice(start, end - start);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ReadOnlySpanTokenizer(ReadOnlySpan<T> span, T separator)
		{
			this.span = span;
			this.separator = separator;
			start = 0;
			end = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly ReadOnlySpanTokenizer<T> GetEnumerator()
		{
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			int num = end + 1;
			int length = span.Length;
			if (num <= length)
			{
				start = num;
				int num2 = System.MemoryExtensions.IndexOf(span.Slice(num), separator);
				if (num2 >= 0)
				{
					end = num + num2;
					return true;
				}
				end = length;
				return true;
			}
			return false;
		}
	}
}
