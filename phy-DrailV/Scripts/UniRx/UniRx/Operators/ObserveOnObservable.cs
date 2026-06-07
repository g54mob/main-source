using System;
using System.Collections.Generic;

namespace UniRx.Operators
{
	internal class ObserveOnObservable<T> : OperatorObservableBase<T>
	{
		private class ObserveOn : OperatorObserverBase<T, T>
		{
			private class SchedulableAction : IDisposable
			{
				public Notification<T> data;

				public LinkedListNode<SchedulableAction> node;

				public IDisposable schedule;

				public bool IsScheduled => schedule != null;

				public void Dispose()
				{
					if (schedule != null)
					{
						schedule.Dispose();
					}
					schedule = null;
					if (node.List != null)
					{
						node.List.Remove(node);
					}
				}
			}

			private readonly ObserveOnObservable<T> parent;

			private readonly LinkedList<SchedulableAction> actions = new LinkedList<SchedulableAction>();

			private bool isDisposed;

			public ObserveOn(ObserveOnObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
			}

			public IDisposable Run()
			{
				isDisposed = false;
				return StableCompositeDisposable.Create(parent.source.Subscribe(this), Disposable.Create(delegate
				{
					lock (actions)
					{
						isDisposed = true;
						while (actions.Count > 0)
						{
							actions.First.Value.Dispose();
						}
					}
				}));
			}

			public override void OnNext(T value)
			{
				QueueAction(new Notification<T>.OnNextNotification(value));
			}

			public override void OnError(Exception error)
			{
				QueueAction(new Notification<T>.OnErrorNotification(error));
			}

			public override void OnCompleted()
			{
				QueueAction(new Notification<T>.OnCompletedNotification());
			}

			private void QueueAction(Notification<T> data)
			{
				SchedulableAction schedulableAction = new SchedulableAction
				{
					data = data
				};
				lock (actions)
				{
					if (!isDisposed)
					{
						schedulableAction.node = actions.AddLast(schedulableAction);
						ProcessNext();
					}
				}
			}

			private void ProcessNext()
			{
				lock (actions)
				{
					if (actions.Count == 0 || isDisposed)
					{
						return;
					}
					SchedulableAction action = actions.First.Value;
					if (action.IsScheduled)
					{
						return;
					}
					action.schedule = parent.scheduler.Schedule(delegate
					{
						try
						{
							switch (action.data.Kind)
							{
							case NotificationKind.OnNext:
								observer.OnNext(action.data.Value);
								break;
							case NotificationKind.OnError:
								observer.OnError(action.data.Exception);
								break;
							case NotificationKind.OnCompleted:
								observer.OnCompleted();
								break;
							}
						}
						finally
						{
							lock (actions)
							{
								action.Dispose();
							}
							if (action.data.Kind == NotificationKind.OnNext)
							{
								ProcessNext();
							}
							else
							{
								Dispose();
							}
						}
					});
				}
			}
		}

		private class ObserveOn_ : OperatorObserverBase<T, T>
		{
			private readonly ObserveOnObservable<T> parent;

			private readonly ISchedulerQueueing scheduler;

			private readonly BooleanDisposable isDisposed;

			private readonly Action<T> onNext;

			public ObserveOn_(ObserveOnObservable<T> parent, ISchedulerQueueing scheduler, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
				this.scheduler = scheduler;
				isDisposed = new BooleanDisposable();
				onNext = OnNext_;
			}

			public IDisposable Run()
			{
				return StableCompositeDisposable.Create(parent.source.Subscribe(this), isDisposed);
			}

			private void OnNext_(T value)
			{
				observer.OnNext(value);
			}

			private void OnError_(Exception error)
			{
				try
				{
					observer.OnError(error);
				}
				finally
				{
					Dispose();
				}
			}

			private void OnCompleted_(Unit _)
			{
				try
				{
					observer.OnCompleted();
				}
				finally
				{
					Dispose();
				}
			}

			public override void OnNext(T value)
			{
				scheduler.ScheduleQueueing(isDisposed, value, onNext);
			}

			public override void OnError(Exception error)
			{
				scheduler.ScheduleQueueing(isDisposed, error, OnError_);
			}

			public override void OnCompleted()
			{
				scheduler.ScheduleQueueing(isDisposed, Unit.Default, OnCompleted_);
			}
		}

		private readonly IObservable<T> source;

		private readonly IScheduler scheduler;

		public ObserveOnObservable(IObservable<T> source, IScheduler scheduler)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.scheduler = scheduler;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			if (!(scheduler is ISchedulerQueueing schedulerQueueing))
			{
				return new ObserveOn(this, observer, cancel).Run();
			}
			return new ObserveOn_(this, schedulerQueueing, observer, cancel).Run();
		}
	}
}
