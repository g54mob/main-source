using System;
using System.Collections.Generic;
using System.Threading;
using Loxodon.Framework.Utilities;
using Loxodon.Log;

namespace Loxodon.Framework.Messaging
{
	public class Subject<T> : SubjectBase
	{
		private class Subscription : ISubscription<T>, IDisposable
		{
			private static readonly ILog log = LogManager.GetLogger(typeof(Subscription));

			private Subject<T> subject;

			private Action<T> action;

			private SynchronizationContext context;

			private SendOrPostCallback sendOrPostCallback;

			private int disposed;

			public string Key { get; private set; }

			public Subscription(Subject<T> subject, Action<T> action)
			{
				this.subject = subject;
				this.action = action;
				sendOrPostCallback = delegate(object state)
				{
					this.action?.Invoke((T)state);
				};
				Key = Guid.NewGuid().ToString();
				this.subject.Add(this);
			}

			public void Publish(T message)
			{
				try
				{
					if (context != null)
					{
						context.Post(sendOrPostCallback, message);
					}
					else
					{
						action?.Invoke(message);
					}
				}
				catch (Exception message2)
				{
					if (log.IsWarnEnabled)
					{
						log.Warn(message2);
					}
				}
			}

			public ISubscription<T> ObserveOn(SynchronizationContext context)
			{
				this.context = context ?? throw new ArgumentNullException("context");
				return this;
			}

			protected virtual void Dispose(bool disposing)
			{
				try
				{
					if (Interlocked.CompareExchange(ref disposed, 1, 0) == 0)
					{
						if (subject != null)
						{
							subject.Remove(this);
						}
						context = null;
						action = null;
						subject = null;
					}
				}
				catch (Exception)
				{
				}
			}

			~Subscription()
			{
				Dispose(disposing: false);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}

		private readonly ConcurrentDictionary<string, WeakReference<Subscription>> subscriptions = new ConcurrentDictionary<string, WeakReference<Subscription>>();

		public bool IsEmpty()
		{
			return subscriptions.Count <= 0;
		}

		public override void Publish(object message)
		{
			Publish((T)message);
		}

		public void Publish(T message)
		{
			if (subscriptions.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, WeakReference<Subscription>> subscription in subscriptions)
			{
				subscription.Value.TryGetTarget(out var target);
				if (target != null)
				{
					target.Publish(message);
				}
				else
				{
					subscriptions.TryRemove(subscription.Key, out var _);
				}
			}
		}

		public ISubscription<T> Subscribe(Action<T> action)
		{
			return new Subscription(this, action);
		}

		private void Add(Subscription subscription)
		{
			WeakReference<Subscription> value = new WeakReference<Subscription>(subscription, trackResurrection: false);
			subscriptions.TryAdd(subscription.Key, value);
		}

		private void Remove(Subscription subscription)
		{
			subscriptions.TryRemove(subscription.Key, out var _);
		}
	}
}
