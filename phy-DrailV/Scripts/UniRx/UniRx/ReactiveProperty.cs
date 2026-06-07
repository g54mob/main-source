using System;
using System.Collections.Generic;
using UniRx.InternalUtil;
using UnityEngine;

namespace UniRx
{
	[Serializable]
	public class ReactiveProperty<T> : IReactiveProperty<T>, IReadOnlyReactiveProperty<T>, IObservable<T>, IDisposable, IOptimizedObservable<T>, IObserverLinkedList<T>
	{
		private static readonly IEqualityComparer<T> defaultEqualityComparer = UnityEqualityComparer.GetDefault<T>();

		[SerializeField]
		private T value;

		[NonSerialized]
		private ObserverNode<T> root;

		[NonSerialized]
		private ObserverNode<T> last;

		[NonSerialized]
		private bool isDisposed;

		protected virtual IEqualityComparer<T> EqualityComparer => defaultEqualityComparer;

		public T Value
		{
			get
			{
				return value;
			}
			set
			{
				if (!EqualityComparer.Equals(this.value, value))
				{
					SetValue(value);
					if (!isDisposed)
					{
						RaiseOnNext(ref value);
					}
				}
			}
		}

		public bool HasValue => true;

		public ReactiveProperty()
			: this(default(T))
		{
		}

		public ReactiveProperty(T initialValue)
		{
			SetValue(initialValue);
		}

		private void RaiseOnNext(ref T value)
		{
			for (ObserverNode<T> next = root; next != null; next = next.Next)
			{
				next.OnNext(value);
			}
		}

		protected virtual void SetValue(T value)
		{
			this.value = value;
		}

		public void SetValueAndForceNotify(T value)
		{
			SetValue(value);
			if (!isDisposed)
			{
				RaiseOnNext(ref value);
			}
		}

		public IDisposable Subscribe(IObserver<T> observer)
		{
			if (isDisposed)
			{
				observer.OnCompleted();
				return Disposable.Empty;
			}
			observer.OnNext(value);
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

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
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

		public override string ToString()
		{
			if (value != null)
			{
				return value.ToString();
			}
			return "(null)";
		}

		public bool IsRequiredSubscribeOnCurrentThread()
		{
			return false;
		}
	}
}
