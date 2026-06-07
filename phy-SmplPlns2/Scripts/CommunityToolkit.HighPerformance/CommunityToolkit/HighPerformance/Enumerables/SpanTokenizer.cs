using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Enumerables
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ref struct SpanTokenizer<T> where T : IEquatable<T>
	{
		private readonly Span<T> span;

		private readonly T separator;

		private int start;

		private int end;

		public readonly Span<T> Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return span.Slice(start, end - start);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SpanTokenizer(Span<T> span, T separator)
		{
			this.span = span;
			this.separator = separator;
			start = 0;
			end = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly SpanTokenizer<T> GetEnumerator()
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
				int num2 = span.Slice(num).IndexOf(separator);
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
