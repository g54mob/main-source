using System;
using System.Collections.Generic;
using System.Threading;

namespace R3
{
	public class ReactiveProperty<T> : ReadOnlyReactiveProperty<T>, ISubject<T>
	{
		private sealed class ObserverNode : IDisposable
		{
			public readonly Observer<T> Observer;

			private ReactiveProperty<T>? parent;

			public ObserverNode? Previous { get; set; }

			public ObserverNode? Next { get; set; }

			public ObserverNode(ReactiveProperty<T> parent, Observer<T> observer)
			{
				this.parent = parent;
				Observer = observer;
				if (parent.root == null)
				{
					Volatile.Write(ref parent.root, this);
					return;
				}
				ObserverNode observerNode = parent.root.Previous ?? parent.root;
				observerNode.Next = this;
				Previous = observerNode;
				parent.root.Previous = this;
			}

			public void Dispose()
			{
				ReactiveProperty<T> reactiveProperty = Interlocked.Exchange(ref parent, null);
				if (reactiveProperty == null)
				{
					return;
				}
				lock (reactiveProperty)
				{
					if (reactiveProperty.IsCompletedOrDisposed)
					{
						return;
					}
					if (this == reactiveProperty.root)
					{
						if (Previous == null || Next == null)
						{
							reactiveProperty.root = null;
							return;
						}
						ObserverNode next = Next;
						if (next.Next == null)
						{
							next.Previous = null;
						}
						else
						{
							next.Previous = Previous;
						}
						reactiveProperty.root = next;
					}
					else
					{
						Previous.Next = Next;
						if (Next != null)
						{
							Next.Previous = Previous;
						}
						else
						{
							reactiveProperty.root.Previous = Previous;
						}
					}
				}
			}
		}

		private const byte NotCompleted = 0;

		private const byte CompletedSuccess = 1;

		private const byte CompletedFailure = 2;

		private const byte Disposed = 3;

		private byte completeState;

		private Exception? error;

		private T currentValue;

		private IEqualityComparer<T>? equalityComparer;

		private ObserverNode? root;

		public IEqualityComparer<T>? EqualityComparer => equalityComparer;

		public override T CurrentValue => currentValue;

		public bool HasObservers => root != null;

		public bool IsCompleted
		{
			get
			{
				if (completeState != 1)
				{
					return completeState == 2;
				}
				return true;
			}
		}

		public bool IsDisposed => completeState == 3;

		public bool IsCompletedOrDisposed
		{
			get
			{
				if (!IsCompleted)
				{
					return IsDisposed;
				}
				return true;
			}
		}

		public virtual T Value
		{
			get
			{
				return currentValue;
			}
			set
			{
				OnValueChanging(ref value);
				if (EqualityComparer == null || !EqualityComparer.Equals(currentValue, value))
				{
					currentValue = value;
					OnValueChanged(value);
					OnNextCore(value);
				}
			}
		}

		public ReactiveProperty()
			: this(default(T))
		{
		}

		public ReactiveProperty(T value)
			: this(value, (IEqualityComparer<T>?)EqualityComparer<T>.Default)
		{
		}

		public ReactiveProperty(T value, IEqualityComparer<T>? equalityComparer)
		{
			this.equalityComparer = equalityComparer;
			OnValueChanging(ref value);
			currentValue = value;
			OnValueChanged(value);
		}

		protected ReactiveProperty(T value, IEqualityComparer<T>? equalityComparer, bool callOnValueChangeInBaseConstructor)
		{
			this.equalityComparer = equalityComparer;
			if (callOnValueChangeInBaseConstructor)
			{
				OnValueChanging(ref value);
			}
			currentValue = value;
			if (callOnValueChangeInBaseConstructor)
			{
				OnValueChanged(value);
			}
		}

		protected virtual void OnValueChanging(ref T value)
		{
		}

		protected ref T GetValueRef()
		{
			return ref currentValue;
		}

		public virtual void ForceNotify()
		{
			OnNext(Value);
		}

		public virtual void OnNext(T value)
		{
			OnValueChanging(ref value);
			currentValue = value;
			OnValueChanged(value);
			OnNextCore(value);
		}

		protected virtual void OnNextCore(T value)
		{
			ThrowIfDisposed();
			if (IsCompleted)
			{
				return;
			}
			ObserverNode next = root;
			ObserverNode observerNode = next?.Previous;
			while (next != null)
			{
				next.Observer.OnNext(value);
				if (next == observerNode)
				{
					break;
				}
				next = next.Next;
			}
		}

		public void OnErrorResume(Exception error)
		{
			ThrowIfDisposed();
			if (IsCompleted)
			{
				return;
			}
			OnReceiveError(error);
			ObserverNode observerNode = Volatile.Read(ref root);
			ObserverNode observerNode2 = observerNode?.Previous;
			while (observerNode != null)
			{
				observerNode.Observer.OnErrorResume(error);
				if (observerNode == observerNode2)
				{
					break;
				}
				observerNode = observerNode.Next;
			}
		}

		public void OnCompleted(Result result)
		{
			ThrowIfDisposed();
			if (IsCompleted)
			{
				return;
			}
			ObserverNode observerNode = null;
			lock (this)
			{
				if (completeState != 0)
				{
					ThrowIfDisposed();
					return;
				}
				completeState = (byte)(result.IsSuccess ? 1 : 2);
				error = result.Exception;
				observerNode = Volatile.Read(ref root);
				Volatile.Write(ref root, null);
			}
			if (result.IsFailure)
			{
				OnReceiveError(result.Exception);
			}
			ObserverNode observerNode2 = observerNode?.Previous;
			while (observerNode != null)
			{
				observerNode.Observer.OnCompleted(result);
				if (observerNode == observerNode2)
				{
					break;
				}
				observerNode = observerNode.Next;
			}
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			Result? result;
			lock (this)
			{
				ThrowIfDisposed();
				result = ((!IsCompleted) ? ((Result?)null) : new Result?((error == null) ? Result.Success : Result.Failure(error)));
			}
			if (!result.HasValue)
			{
				observer.OnNext(currentValue);
				lock (this)
				{
					ThrowIfDisposed();
					if (!IsCompleted)
					{
						return new ObserverNode(this, observer);
					}
					result = ((error == null) ? Result.Success : Result.Failure(error));
				}
			}
			else if (result.HasValue)
			{
				if (result.Value.IsSuccess)
				{
					observer.OnNext(currentValue);
				}
				observer.OnCompleted(result.Value);
				return Disposable.Empty;
			}
			if (result.HasValue)
			{
				observer.OnCompleted(result.Value);
			}
			return Disposable.Empty;
		}

		private void ThrowIfDisposed()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException("");
			}
		}

		public override void Dispose()
		{
			Dispose(callOnCompleted: true);
		}

		public void Dispose(bool callOnCompleted)
		{
			ObserverNode observerNode = null;
			lock (this)
			{
				if (completeState == 3)
				{
					return;
				}
				if (callOnCompleted && !IsCompleted)
				{
					observerNode = Volatile.Read(ref root);
				}
				Volatile.Write(ref root, null);
				completeState = 3;
			}
			while (observerNode != null)
			{
				observerNode.Observer.OnCompleted();
				observerNode = observerNode.Next;
			}
			DisposeCore();
		}

		protected virtual void DisposeCore()
		{
		}

		public override string? ToString()
		{
			if (currentValue != null)
			{
				return currentValue.ToString();
			}
			return "(null)";
		}
	}
}
