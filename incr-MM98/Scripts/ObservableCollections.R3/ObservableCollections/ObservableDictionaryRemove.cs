using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableDictionaryRemove<TKey, TValue> : Observable<DictionaryRemoveEvent<TKey, TValue>>
	{
		private sealed class _DictionaryCollectionRemove : ObservableCollectionObserverBase<KeyValuePair<TKey, TValue>, DictionaryRemoveEvent<TKey, TValue>>
		{
			public _DictionaryCollectionRemove(IObservableCollection<KeyValuePair<TKey, TValue>> collection, Observer<DictionaryRemoveEvent<TKey, TValue>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>> eventArgs)
			{
				if (eventArgs.Action != NotifyCollectionChangedAction.Remove)
				{
					return;
				}
				if (eventArgs.IsSingleItem)
				{
					observer.OnNext(new DictionaryRemoveEvent<TKey, TValue>(eventArgs.OldItem.Key, eventArgs.OldItem.Value));
					return;
				}
				ReadOnlySpan<KeyValuePair<TKey, TValue>> newItems = eventArgs.NewItems;
				for (int i = 0; i < newItems.Length; i++)
				{
					KeyValuePair<TKey, TValue> keyValuePair = newItems[i];
					observer.OnNext(new DictionaryRemoveEvent<TKey, TValue>(keyValuePair.Key, keyValuePair.Value));
				}
			}
		}

		public ObservableDictionaryRemove(IReadOnlyObservableDictionary<TKey, TValue> dictionary, CancellationToken cancellationToken)
		{
			_003Cdictionary_003EP = dictionary;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<DictionaryRemoveEvent<TKey, TValue>> observer)
		{
			return new _DictionaryCollectionRemove(_003Cdictionary_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
