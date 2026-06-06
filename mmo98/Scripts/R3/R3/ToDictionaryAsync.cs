using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ToDictionaryAsync<T, TKey> : TaskObserverBase<T, Dictionary<TKey, T>> where TKey : notnull
	{
		private readonly Dictionary<TKey, T> dictionary;

		public ToDictionaryAsync(Func<T, TKey> keySelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken)
		{
			_003CkeySelector_003EP = keySelector;
			dictionary = new Dictionary<TKey, T>(keyComparer);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			TKey key = _003CkeySelector_003EP(value);
			dictionary.Add(key, value);
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			TrySetException(error);
		}

		protected override void OnCompletedCore(Result result)
		{
			if (result.IsFailure)
			{
				TrySetException(result.Exception);
			}
			else
			{
				TrySetResult(dictionary);
			}
		}
	}
	internal sealed class ToDictionaryAsync<T, TKey, TElement> : TaskObserverBase<T, Dictionary<TKey, TElement>> where TKey : notnull
	{
		private readonly Dictionary<TKey, TElement> dictionary;

		public ToDictionaryAsync(Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken)
		{
			_003CkeySelector_003EP = keySelector;
			_003CelementSelector_003EP = elementSelector;
			dictionary = new Dictionary<TKey, TElement>(keyComparer);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			TKey key = _003CkeySelector_003EP(value);
			TElement value2 = _003CelementSelector_003EP(value);
			dictionary.Add(key, value2);
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			TrySetException(error);
		}

		protected override void OnCompletedCore(Result result)
		{
			if (result.IsFailure)
			{
				TrySetException(result.Exception);
			}
			else
			{
				TrySetResult(dictionary);
			}
		}
	}
}
