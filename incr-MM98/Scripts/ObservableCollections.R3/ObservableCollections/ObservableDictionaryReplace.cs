using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableDictionaryReplace<TKey, TValue> : Observable<DictionaryReplaceEvent<TKey, TValue>>
	{
		private sealed class _DictionaryCollectionReplace : ObservableCollectionObserverBase<KeyValuePair<TKey, TValue>, DictionaryReplaceEvent<TKey, TValue>>
		{
			public _DictionaryCollectionReplace(IObservableCollection<KeyValuePair<TKey, TValue>> collection, Observer<DictionaryReplaceEvent<TKey, TValue>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Replace)
				{
					observer.OnNext(new DictionaryReplaceEvent<TKey, TValue>(eventArgs.NewItem.Key, eventArgs.OldItem.Value, eventArgs.NewItem.Value));
				}
			}
		}

		public ObservableDictionaryReplace(IReadOnlyObservableDictionary<TKey, TValue> dictionary, CancellationToken cancellationToken)
		{
			_003Cdictionary_003EP = dictionary;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<DictionaryReplaceEvent<TKey, TValue>> observer)
		{
			return new _DictionaryCollectionReplace(_003Cdictionary_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
