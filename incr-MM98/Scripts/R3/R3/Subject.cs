using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace R3
{
	public class Subject<T> : Observable<T>, ISubject<T>, IDisposable
	{
		private sealed class ObserverNode : IDisposable
		{
			public readonly Observer<T> Observer;

			private Subject<T>? parent;

			public ulong Version;

			public ObserverNode? Previous { get; set; }

			public ObserverNode? Next { get; set; }

			public ObserverNode(Subject<T> parent, Observer<T> observer, ulong version)
			{
				this.parent = parent;
				Observer = observer;
				Version = version;
				lock (parent)
				{
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
			}

			public void Dispose()
			{
				Subject<T> subject = Interlocked.Exchange(ref parent, null);
				if (subject == null)
				{
					return;
				}
				lock (subject)
				{
					if (subject.IsCompletedOrDisposed)
					{
						return;
					}
					if (this == subject.root)
					{
						if (Previous == null || Next == null)
						{
							subject.root = null;
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
						subject.root = next;
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
							subject.root.Previous = Previous;
						}
					}
				}
			}
		}

		private CompleteState completeState;

		private ObserverNode? root;

		private ulong version = 1uL;

		public bool IsDisposed => completeState.IsDisposed;

		internal bool IsCompletedOrDisposed => completeState.IsCompletedOrDisposed;

		public void OnNext(T value)
		{
			if (!completeState.IsCompleted)
			{
				ulong num = GetVersion();
				ObserverNode next = root;
				while (next != null && next.Version <= num)
				{
					next.Observer.OnNext(value);
					next = next.Next;
				}
			}
		}

		public void OnErrorResume(Exception error)
		{
			if (!completeState.IsCompleted)
			{
				ulong num = GetVersion();
				ObserverNode next = root;
				while (next != null && next.Version <= num)
				{
					next.Observer.OnErrorResume(error);
					next = next.Next;
				}
			}
		}

		public void OnCompleted(Result result)
		{
			if (completeState.TrySetResult(result) == CompleteState.ResultStatus.Done)
			{
				ulong num = GetVersion();
				ObserverNode next = root;
				while (next != null && next.Version <= num)
				{
					next.Observer.OnCompleted(result);
					next = next.Next;
				}
			}
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			Result? result = completeState.TryGetResult();
			if (result.HasValue)
			{
				observer.OnCompleted(result.Value);
				return Disposable.Empty;
			}
			ObserverNode observerNode = new ObserverNode(this, observer, version);
			result = completeState.TryGetResult();
			if (result.HasValue)
			{
				observerNode.Observer.OnCompleted(result.Value);
				observerNode.Dispose();
				return Disposable.Empty;
			}
			return observerNode;
		}

		private void ThrowIfDisposed()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException("");
			}
		}

		public void Dispose()
		{
			Dispose(callOnCompleted: true);
		}

		public void Dispose(bool callOnCompleted)
		{
			if (!completeState.TrySetDisposed(out var alreadyCompleted))
			{
				return;
			}
			if (!alreadyCompleted && callOnCompleted)
			{
				ulong num = GetVersion();
				ObserverNode next = root;
				Volatile.Write(ref root, null);
				while (next != null && next.Version <= num)
				{
					next.Observer.OnCompleted();
					next = next.Next;
				}
			}
			else
			{
				Volatile.Write(ref root, null);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ulong GetVersion()
		{
			if (version == ulong.MaxValue)
			{
				ResetAllObserverVersion();
				return 0uL;
			}
			return version++;
			void ResetAllObserverVersion()
			{
				lock (this)
				{
					for (ObserverNode next = root; next != null; next = next.Next)
					{
						next.Version = 0uL;
					}
					version = 1uL;
				}
			}
		}
	}
}
