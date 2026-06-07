using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class AggregateByAsyncSeedSelector<TSource, TKey, TAccumulate> : TaskObserverBase<TSource, IEnumerable<KeyValuePair<TKey, TAccumulate>>> where TKey : notnull
	{
		private readonly Dictionary<TKey, TAccumulate> dictionary;

		public AggregateByAsyncSeedSelector(Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken)
		{
			_003CkeySelector_003EP = keySelector;
			_003CseedSelector_003EP = seedSelector;
			_003Cfunc_003EP = func;
			dictionary = new Dictionary<TKey, TAccumulate>(keyComparer);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			TKey val = _003CkeySelector_003EP(value);
			if (!dictionary.TryGetValue(val, out var value2))
			{
				value2 = _003CseedSelector_003EP(val);
			}
			dictionary[val] = _003Cfunc_003EP(value2, value);
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
