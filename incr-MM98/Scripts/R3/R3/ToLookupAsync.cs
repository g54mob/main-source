using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ToLookupAsync<T, TKey> : TaskObserverBase<T, ILookup<TKey, T>> where TKey : notnull
	{
		private readonly Dictionary<TKey, List<T>> dictionary;

		public ToLookupAsync(Func<T, TKey> keySelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken)
		{
			_003CkeySelector_003EP = keySelector;
			dictionary = new Dictionary<TKey, List<T>>(keyComparer);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			TKey key = _003CkeySelector_003EP(value);
			if (!dictionary.TryGetValue(key, out List<T> value2))
			{
				value2 = new List<T>();
				dictionary.Add(key, value2);
			}
			value2.Add(value);
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
				TrySetResult(new Lookup<TKey, T>(dictionary));
			}
		}
	}
	internal sealed class ToLookupAsync<T, TKey, TElement> : TaskObserverBase<T, ILookup<TKey, TElement>> where TKey : notnull
	{
		private readonly Dictionary<TKey, List<TElement>> dictionary;

		public ToLookupAsync(Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken)
		{
			_003CkeySelector_003EP = keySelector;
			_003CelementSelector_003EP = elementSelector;
			dictionary = new Dictionary<TKey, List<TElement>>(keyComparer);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			TKey key = _003CkeySelector_003EP(value);
			TElement item = _003CelementSelector_003EP(value);
			if (!dictionary.TryGetValue(key, out List<TElement> value2))
			{
				value2 = new List<TElement>();
				dictionary.Add(key, value2);
			}
			value2.Add(item);
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
				TrySetResult(new Lookup<TKey, TElement>(dictionary));
			}
		}
	}
}
