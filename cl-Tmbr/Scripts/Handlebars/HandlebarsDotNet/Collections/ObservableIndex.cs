using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	public class ObservableIndex<TKey, TValue, TComparer> : IObservable<ObservableEvent<TValue>>, IObserver<ObservableEvent<TValue>>, IIndexed<TKey, TValue>, IReadOnlyIndexed<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TComparer : IEqualityComparer<TKey>
	{
		private readonly ReaderWriterLockSlim _observersLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

		private readonly ReaderWriterLockSlim _itemsLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

		private readonly WeakCollection<IObserver<ObservableEvent<TValue>>> _observers;

		private readonly DictionarySlim<TKey, TValue, TComparer> _inner;

		public int Count
		{
			get
			{
				using (_itemsLock.ReadLock())
				{
					return _inner.Count;
				}
			}
		}

		public TValue this[in TKey key]
		{
			get
			{
				if (!TryGetValue(in key, out var value))
				{
					return default(TValue);
				}
				return value;
			}
			set
			{
				AddOrReplace(in key, in value);
			}
		}

		TValue IIndexed<TKey, TValue>.this[in TKey key]
		{
			get
			{
				return this[in key];
			}
			set
			{
				this[in key] = value;
			}
		}

		TValue IReadOnlyIndexed<TKey, TValue>.this[in TKey key] => this[in key];

		public ObservableIndex(TComparer comparer, IReadOnlyIndexed<TKey, TValue> outer = null)
		{
			_inner = ((outer != null) ? new DictionarySlim<TKey, TValue, TComparer>(outer, comparer) : new DictionarySlim<TKey, TValue, TComparer>(comparer));
			_observers = new WeakCollection<IObserver<ObservableEvent<TValue>>>();
			if (outer is IObservable<ObservableEvent<TValue>> observable)
			{
				observable.Subscribe(this);
			}
		}

		public IDisposable Subscribe(IObserver<ObservableEvent<TValue>> observer)
		{
			using (_observersLock.WriteLock())
			{
				_observers.Add(observer);
			}
			return new DisposableContainer<WeakCollection<IObserver<ObservableEvent<TValue>>>, ReaderWriterLockSlim>(_observers, _observersLock, delegate(WeakCollection<IObserver<ObservableEvent<TValue>>> observers, ReaderWriterLockSlim @lock)
			{
				using (@lock.WriteLock())
				{
					observers.Remove(this);
				}
			});
		}

		private void Publish(ObservableEvent<TValue> @event)
		{
			using (_observersLock.ReadLock())
			{
				foreach (IObserver<ObservableEvent<TValue>> observer in _observers)
				{
					try
					{
						observer.OnNext(@event);
					}
					catch
					{
					}
				}
			}
		}

		public void AddOrReplace(in TKey key, in TValue value)
		{
			using (_itemsLock.WriteLock())
			{
				_inner.AddOrReplace(in key, in value);
			}
			Publish(new DictionaryAddedObservableEvent<TKey, TValue>(key, value));
		}

		public bool ContainsKey(in TKey key)
		{
			using (_itemsLock.ReadLock())
			{
				return _inner.ContainsKey(in key);
			}
		}

		public bool TryGetValue(in TKey key, out TValue value)
		{
			using (_itemsLock.ReadLock())
			{
				return _inner.TryGetValue(in key, out value);
			}
		}

		public void Clear()
		{
			using (_itemsLock.WriteLock())
			{
				_inner.Clear();
			}
			Publish(new DictionaryClearedObservableEvent<TValue>());
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			KeyValuePair<TKey, TValue>[] array;
			using (_itemsLock.ReadLock())
			{
				array = _inner.ToArray();
			}
			for (int index = 0; index < array.Length; index++)
			{
				yield return array[index];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(ObservableEvent<TValue> value)
		{
			if (!(value is DictionaryAddedObservableEvent<TKey, TValue> dictionaryAddedObservableEvent))
			{
				if (!(value is DictionaryClearedObservableEvent<TValue>))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				Clear();
			}
			else
			{
				AddOrReplace(dictionaryAddedObservableEvent.Key, dictionaryAddedObservableEvent.Value);
			}
		}

		void IIndexed<TKey, TValue>.AddOrReplace(in TKey key, in TValue value)
		{
			AddOrReplace(in key, in value);
		}

		bool IReadOnlyIndexed<TKey, TValue>.ContainsKey(in TKey key)
		{
			return ContainsKey(in key);
		}

		bool IReadOnlyIndexed<TKey, TValue>.TryGetValue(in TKey key, out TValue value)
		{
			return TryGetValue(in key, out value);
		}
	}
}
