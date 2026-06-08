using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	public class ObservableList<T> : IAppendOnlyList<T>, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IObservable<ObservableEvent<T>>, IObserver<ObservableEvent<T>>
	{
		private readonly ReaderWriterLockSlim _observersLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

		private readonly ReaderWriterLockSlim _itemsLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

		private readonly WeakCollection<IObserver<ObservableEvent<T>>> _observers = new WeakCollection<IObserver<ObservableEvent<T>>>();

		private readonly List<T> _inner;

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

		public T this[int index]
		{
			get
			{
				using (_itemsLock.ReadLock())
				{
					return _inner[index];
				}
			}
		}

		public ObservableList(IEnumerable<T> list = null)
		{
			_inner = ((list != null) ? new List<T>(list) : new List<T>());
			if (list is IObservable<ObservableEvent<T>> observable)
			{
				observable.Subscribe(this);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			T[] array;
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

		public void Add(T value)
		{
			using (_itemsLock.WriteLock())
			{
				_inner.Add(value);
			}
			Publish(new AddedObservableEvent<T>(value));
		}

		public IDisposable Subscribe(IObserver<ObservableEvent<T>> observer)
		{
			using (_observersLock.WriteLock())
			{
				_observers.Add(observer);
			}
			return new DisposableContainer<WeakCollection<IObserver<ObservableEvent<T>>>, ReaderWriterLockSlim>(_observers, _observersLock, delegate(WeakCollection<IObserver<ObservableEvent<T>>> observers, ReaderWriterLockSlim @lock)
			{
				using (@lock.WriteLock())
				{
					observers.Remove(this);
				}
			});
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(ObservableEvent<T> value)
		{
			if (value is AddedObservableEvent<T> addedObservableEvent)
			{
				Add(addedObservableEvent.Value);
				return;
			}
			throw new ArgumentOutOfRangeException("value");
		}

		private void Publish(ObservableEvent<T> @event)
		{
			using (_observersLock.ReadLock())
			{
				foreach (IObserver<ObservableEvent<T>> observer in _observers)
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
	}
}
