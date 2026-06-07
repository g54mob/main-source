using System;

namespace ZLinq
{
	public interface ITraverser<TTraverser, T> : IDisposable where TTraverser : struct, ITraverser<TTraverser, T>
	{
		T Origin { get; }

		TTraverser ConvertToTraverser(T next);

		bool TryGetHasChild(out bool hasChild);

		bool TryGetChildCount(out int count);

		bool TryGetParent(out T parent);

		bool TryGetNextChild(out T child);

		bool TryGetNextSibling(out T next);

		bool TryGetPreviousSibling(out T previous);
	}
}
