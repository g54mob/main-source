using System;
using System.Collections.Generic;
using UniRx.InternalUtil;

namespace UniRx
{
	public class ReadOnlyReactiveProperty<T> : IReadOnlyReactiveProperty<T>, IObservable<T>, IDisposable, IOptimizedObservable<T>, IObserverLinkedList<T>, IObserver<T>
	{
		private static readonly IEqualityComparer<T> defaultEqualityComparer = UnityEqualityComparer.GetDefault<T>();

		private readonly bool distinctUntilChanged = true;

		private bool canPublishValueOnSubscribe;

		private bool isDisposed;

		private bool isSourceCompleted;

		private T latestValue;

		private Exception lastException;

		private IDisposable sourceConnection;

		private ObserverNode<T> root;

		private ObserverNode<T> last;

		public T Value => latestValue;

		public bool HasValue => canPublishValueOnSubscribe;

		protected virtual IEqualityComparer<T> EqualityComparer => defaultEqualityComparer;

		public ReadOnlyReactiveProperty(IObservable<T> source)
		{
			sourceConnection = source.Subscribe(this);
		}

		public ReadOnlyReactiveProperty(IObservable<T> source, bool distinctUntilChanged)
		{
			this.distinctUntilChanged = distinctUntilChanged;
			sourceConnection = source.Subscribe(this);
		}

		public ReadOnlyReactiveProperty(IObservable<T> source, T initialValue)
		{
			latestValue = initialValue;
			canPublishValueOnSubscribe = true;
			sourceConnection = source.Subscribe(this);
		}

		public ReadOnlyReactiveProperty(IObservable<T> source, T initialValue, bool distinctUntilChanged)
		{
			this.distinctUntilChanged = distinctUntilChanged;
			latestValue = initialValue;
			canPublishValueOnSubscribe = true;
			sourceConnection = source.Subscribe(this);
		}

		public IDisposable Subscribe(IObserver<T> observer)
		{
			if (lastException != null)
			{
				observer.OnError(lastException);
				return Disposable.Empty;
			}
			if (isSourceCompleted)
			{
				if (canPublishValueOnSubscribe)
				{
					observer.OnNext(latestValue);
					observer.OnCompleted();
					return Disposable.Empty;
				}
				observer.OnCompleted();
				return Disposable.Empty;
			}
			if (isDisposed)
			{
				observer.OnCompleted();
				return Disposable.Empty;
			}
			if (canPublishValueOnSubscribe)
			{
				observer.OnNext(latestValue);
			}
			ObserverNode<T> observerNode = new ObserverNode<T>(this, observer);
			if (root == null)
			{
				root = (last = observerNode);
			}
			else
			{
				last.Next = observerNode;
				observerNode.Previous = last;
				last = observerNode;
			}
			return observerNode;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				sourceConnection.Dispose();
				ObserverNode<T> next = root;
				root = (last = null);
				isDisposed = true;
				while (next != null)
				{
					next.OnCompleted();
					next = next.Next;
				}
			}
		}

		void IObserverLinkedList<T>.UnsubscribeNode(ObserverNode<T> node)
		{
			if (node == root)
			{
				root = node.Next;
			}
			if (node == last)
			{
				last = node.Previous;
			}
			if (node.Previous != null)
			{
				node.Previous.Next = node.Next;
			}
			if (node.Next != null)
			{
				node.Next.Previous = node.Previous;
			}
		}

		void IObserver<T>.OnNext(T value)
		{
			if (!isDisposed && (!canPublishValueOnSubscribe || !distinctUntilChanged || !EqualityComparer.Equals(latestValue, value)))
			{
				canPublishValueOnSubscribe = true;
				latestValue = value;
				for (ObserverNode<T> next = root; next != null; next = next.Next)
				{
					next.OnNext(value);
				}
			}
		}

		void IObserver<T>.OnError(Exception error)
		{
			lastException = error;
			for (ObserverNode<T> next = root; next != null; next = next.Next)
			{
				next.OnError(error);
			}
			root = (last = null);
		}

		void IObserver<T>.OnCompleted()
		{
			isSourceCompleted = true;
			root = (last = null);
		}

		public override string ToString()
		{
			if (latestValue != null)
			{
				return latestValue.ToString();
			}
			return "(null)";
		}

		public bool IsRequiredSubscribeOnCurrentThread()
		{
			return false;
		}
	}
}
