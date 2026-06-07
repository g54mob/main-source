using System;
using System.Collections;
using System.Collections.Generic;

namespace UniRx.Operators
{
	internal class DelayFrameObservable<T> : OperatorObservableBase<T>
	{
		private class DelayFrame : OperatorObserverBase<T, T>
		{
			private readonly DelayFrameObservable<T> parent;

			private readonly object gate = new object();

			private readonly QueuePool pool = new QueuePool();

			private int runningEnumeratorCount;

			private bool readyDrainEnumerator;

			private bool running;

			private IDisposable sourceSubscription;

			private Queue<T> currentQueueReference;

			private bool calledCompleted;

			private bool hasError;

			private Exception error;

			private BooleanDisposable cancelationToken;

			public DelayFrame(DelayFrameObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
			}

			public IDisposable Run()
			{
				cancelationToken = new BooleanDisposable();
				((SingleAssignmentDisposable)(sourceSubscription = new SingleAssignmentDisposable())).Disposable = parent.source.Subscribe(this);
				return StableCompositeDisposable.Create(cancelationToken, sourceSubscription);
			}

			private IEnumerator DrainQueue(Queue<T> q, int frameCount)
			{
				lock (gate)
				{
					readyDrainEnumerator = false;
					running = false;
				}
				while (!cancelationToken.IsDisposed && frameCount-- != 0)
				{
					yield return null;
				}
				try
				{
					if (q != null)
					{
						while (q.Count > 0 && !hasError && !cancelationToken.IsDisposed)
						{
							lock (gate)
							{
								running = true;
							}
							T value = q.Dequeue();
							observer.OnNext(value);
							lock (gate)
							{
								running = false;
							}
						}
						if (q.Count == 0)
						{
							pool.Return(q);
						}
					}
					if (hasError)
					{
						if (!cancelationToken.IsDisposed)
						{
							cancelationToken.Dispose();
							try
							{
								observer.OnError(error);
								yield break;
							}
							finally
							{
								Dispose();
							}
						}
					}
					else
					{
						if (!calledCompleted)
						{
							yield break;
						}
						lock (gate)
						{
							if (runningEnumeratorCount != 1)
							{
								yield break;
							}
						}
						if (!cancelationToken.IsDisposed)
						{
							cancelationToken.Dispose();
							try
							{
								observer.OnCompleted();
								yield break;
							}
							finally
							{
								Dispose();
							}
						}
					}
				}
				finally
				{
					lock (gate)
					{
						runningEnumeratorCount--;
					}
				}
			}

			public override void OnNext(T value)
			{
				if (cancelationToken.IsDisposed)
				{
					return;
				}
				Queue<T> queue = null;
				lock (gate)
				{
					if (readyDrainEnumerator)
					{
						if (currentQueueReference != null)
						{
							currentQueueReference.Enqueue(value);
						}
						return;
					}
					readyDrainEnumerator = true;
					runningEnumeratorCount++;
					queue = (currentQueueReference = pool.Get());
					queue.Enqueue(value);
				}
				switch (parent.frameCountType)
				{
				case FrameCountType.Update:
					MainThreadDispatcher.StartUpdateMicroCoroutine(DrainQueue(queue, parent.frameCount));
					break;
				case FrameCountType.FixedUpdate:
					MainThreadDispatcher.StartFixedUpdateMicroCoroutine(DrainQueue(queue, parent.frameCount));
					break;
				case FrameCountType.EndOfFrame:
					MainThreadDispatcher.StartEndOfFrameMicroCoroutine(DrainQueue(queue, parent.frameCount));
					break;
				default:
					throw new ArgumentException("Invalid FrameCountType:" + parent.frameCountType);
				}
			}

			public override void OnError(Exception error)
			{
				sourceSubscription.Dispose();
				if (cancelationToken.IsDisposed)
				{
					return;
				}
				lock (gate)
				{
					if (running)
					{
						hasError = true;
						this.error = error;
						return;
					}
				}
				cancelationToken.Dispose();
				try
				{
					observer.OnError(error);
				}
				finally
				{
					Dispose();
				}
			}

			public override void OnCompleted()
			{
				sourceSubscription.Dispose();
				if (cancelationToken.IsDisposed)
				{
					return;
				}
				lock (gate)
				{
					calledCompleted = true;
					if (readyDrainEnumerator)
					{
						return;
					}
					readyDrainEnumerator = true;
					runningEnumeratorCount++;
				}
				switch (parent.frameCountType)
				{
				case FrameCountType.Update:
					MainThreadDispatcher.StartUpdateMicroCoroutine(DrainQueue(null, parent.frameCount));
					break;
				case FrameCountType.FixedUpdate:
					MainThreadDispatcher.StartFixedUpdateMicroCoroutine(DrainQueue(null, parent.frameCount));
					break;
				case FrameCountType.EndOfFrame:
					MainThreadDispatcher.StartEndOfFrameMicroCoroutine(DrainQueue(null, parent.frameCount));
					break;
				default:
					throw new ArgumentException("Invalid FrameCountType:" + parent.frameCountType);
				}
			}
		}

		private class QueuePool
		{
			private readonly object gate = new object();

			private readonly Queue<Queue<T>> pool = new Queue<Queue<T>>(2);

			public Queue<T> Get()
			{
				lock (gate)
				{
					if (pool.Count == 0)
					{
						return new Queue<T>(2);
					}
					return pool.Dequeue();
				}
			}

			public void Return(Queue<T> q)
			{
				lock (gate)
				{
					pool.Enqueue(q);
				}
			}
		}

		private readonly IObservable<T> source;

		private readonly int frameCount;

		private readonly FrameCountType frameCountType;

		public DelayFrameObservable(IObservable<T> source, int frameCount, FrameCountType frameCountType)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.frameCount = frameCount;
			this.frameCountType = frameCountType;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			return new DelayFrame(this, observer, cancel).Run();
		}
	}
}
