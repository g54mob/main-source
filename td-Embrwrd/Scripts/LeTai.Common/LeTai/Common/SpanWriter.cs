using System;

namespace LeTai.Common
{
	public ref struct SpanWriter<T>
	{
		private readonly Span<T> _span;

		private int _nextIndex;

		public SpanWriter(Span<T> span)
		{
			_span = default(Span<T>);
			_nextIndex = 0;
		}

		public void Reset()
		{
		}

		public void Write(T value)
		{
		}

		public void FillRest(T value = default(T))
		{
		}
	}
}
