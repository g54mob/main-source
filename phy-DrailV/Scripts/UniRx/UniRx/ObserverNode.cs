using System;
using System.Threading;

namespace UniRx
{
	internal sealed class ObserverNode<T> : IObserver<T>, IDisposable
	{
		private readonly IObserver<T> observer;

		private IObserverLinkedList<T> list;

		public ObserverNode<T> Previous { get; internal set; }

		public ObserverNode<T> Next { get; internal set; }

		public ObserverNode(IObserverLinkedList<T> list, IObserver<T> observer)
		{
			this.list = list;
			this.observer = observer;
		}

		public void OnNext(T value)
		{
			observer.OnNext(value);
		}

		public void OnError(Exception error)
		{
			observer.OnError(error);
		}

		public void OnCompleted()
		{
			observer.OnCompleted();
		}

		public void Dispose()
		{
			IObserverLinkedList<T> observerLinkedList = Interlocked.Exchange(ref list, null);
			if (observerLinkedList != null)
			{
				observerLinkedList.UnsubscribeNode(this);
				observerLinkedList = null;
			}
		}
	}
}
