using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableDictionaryAdd<TKey, TValue> : Observable<DictionaryAddEvent<TKey, TValue>>
	{
		private sealed class _DictionaryCollectionAdd : ObservableCollectionObserverBase<KeyValuePair<TKey, TValue>, DictionaryAddEvent<TKey, TValue>>
		{
			public _DictionaryCollectionAdd(IObservableCollection<KeyValuePair<TKey, TValue>> collection, Observer<DictionaryAddEvent<TKey, TValue>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>> eventArgs)
			{
				if (eventArgs.Action != NotifyCollectionChangedAction.Add)
				{
					return;
				}
				if (eventArgs.IsSingleItem)
				{
					observer.OnNext(new DictionaryAddEvent<TKey, TValue>(eventArgs.NewItem.Key, eventArgs.NewItem.Value));
					return;
				}
				ReadOnlySpan<KeyValuePair<TKey, TValue>> newItems = eventArgs.NewItems;
				for (int i = 0; i < newItems.Length; i++)
				{
					KeyValuePair<TKey, TValue> keyValuePair = newItems[i];
					observer.OnNext(new DictionaryAddEvent<TKey, TValue>(keyValuePair.Key, keyValuePair.Value));
				}
			}
		}

		public ObservableDictionaryAdd(IReadOnlyObservableDictionary<TKey, TValue> dictionary, CancellationToken cancellationToken)
		{
			_003Cdictionary_003EP = dictionary;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<DictionaryAddEvent<TKey, TValue>> observer)
		{
			return new _DictionaryCollectionAdd(_003Cdictionary_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
