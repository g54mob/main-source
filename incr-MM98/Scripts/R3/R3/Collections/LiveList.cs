using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using R3.Internal;

namespace R3.Collections
{
	public sealed class LiveList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IDisposable
	{
		private sealed class ListObserver : Observer<T>
		{
			public ListObserver(LiveList<T> parent)
			{
				_003Cparent_003EP = parent;
				base._002Ector();
			}

			protected override void OnNextCore(T message)
			{
				lock (_003Cparent_003EP.list)
				{
					if (_003Cparent_003EP.bufferSize == -1)
					{
						((List<T>)_003Cparent_003EP.list).Add(message);
						return;
					}
					RingBuffer<T> ringBuffer = (RingBuffer<T>)_003Cparent_003EP.list;
					if (ringBuffer.Count == _003Cparent_003EP.bufferSize)
					{
						ringBuffer.RemoveFirst();
					}
					ringBuffer.AddLast(message);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				ObservableSystem.GetUnhandledExceptionHandler()(error);
			}

			protected override void OnCompletedCore(Result complete)
			{
				lock (_003Cparent_003EP.list)
				{
					_003Cparent_003EP.completedValue = complete;
					_003Cparent_003EP.isCompleted = true;
				}
			}
		}

		private readonly IReadOnlyList<T> list;

		private readonly IDisposable sourceSubscription;

		private readonly int bufferSize;

		private bool isCompleted;

		private Result completedValue;

		public bool IsCompleted => isCompleted;

		public Result Result
		{
			get
			{
				lock (list)
				{
					if (!isCompleted)
					{
						throw new InvalidOperationException("LiveList is not completed, you should check IsCompleted.");
					}
					return completedValue;
				}
			}
		}

		public T this[int index]
		{
			get
			{
				lock (list)
				{
					return list[index];
				}
			}
		}

		public int Count
		{
			get
			{
				lock (list)
				{
					return list.Count;
				}
			}
		}

		public LiveList(Observable<T> source)
		{
			if (bufferSize == 0)
			{
				bufferSize = 1;
			}
			bufferSize = -1;
			list = new List<T>();
			sourceSubscription = source.Subscribe(new ListObserver(this));
		}

		public LiveList(Observable<T> source, int bufferSize)
		{
			if (bufferSize == 0)
			{
				bufferSize = 1;
			}
			this.bufferSize = bufferSize;
			list = new RingBuffer<T>(bufferSize);
			sourceSubscription = source.Subscribe(new ListObserver(this));
		}

		public void Clear()
		{
			lock (list)
			{
				list.Clear();
			}
		}

		public void Dispose()
		{
			sourceSubscription.Dispose();
		}

		public void ForEach(Action<T> action)
		{
			lock (list)
			{
				RingBufferSpan<T>.Enumerator enumerator = list.GetSpan().GetEnumerator();
				while (enumerator.MoveNext())
				{
					action(enumerator.Current);
				}
			}
		}

		public void ForEach<TState>(TState state, Action<T, TState> action)
		{
			lock (list)
			{
				RingBufferSpan<T>.Enumerator enumerator = list.GetSpan().GetEnumerator();
				while (enumerator.MoveNext())
				{
					action(enumerator.Current, state);
				}
			}
		}

		public T[] ToArray()
		{
			lock (list)
			{
				return list.ToArray();
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			lock (list)
			{
				return ToArray().AsEnumerable().GetEnumerator();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			lock (list)
			{
				return ToArray().AsEnumerable().GetEnumerator();
			}
		}
	}
}
