using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class AggregateByAsync<TSource, TKey, TAccumulate> : TaskObserverBase<TSource, IEnumerable<KeyValuePair<TKey, TAccumulate>>> where TKey : notnull
	{
		private readonly Dictionary<TKey, TAccumulate> dictionary;

		public AggregateByAsync(Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken)
		{
			_003CkeySelector_003EP = keySelector;
			_003Cseed_003EP = seed;
			_003Cfunc_003EP = func;
			dictionary = new Dictionary<TKey, TAccumulate>(keyComparer);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			TKey key = _003CkeySelector_003EP(value);
			if (!dictionary.TryGetValue(key, out var value2))
			{
				value2 = _003Cseed_003EP;
			}
			dictionary[key] = _003Cfunc_003EP(value2, value);
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
