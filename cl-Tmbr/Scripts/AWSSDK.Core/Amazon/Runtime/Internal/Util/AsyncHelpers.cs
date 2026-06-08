using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	public static class AsyncHelpers
	{
		private class ExclusiveSynchronizationContext : SynchronizationContext
		{
			private bool done;

			private readonly AutoResetEvent pendingObjects = new AutoResetEvent(initialState: false);

			private readonly Queue<Tuple<SendOrPostCallback, object>> objects = new Queue<Tuple<SendOrPostCallback, object>>();

			public Exception ObjectException { get; set; }

			public override void Send(SendOrPostCallback d, object state)
			{
				throw new NotSupportedException("We cannot send to our same thread");
			}

			public override void Post(SendOrPostCallback d, object state)
			{
				lock (objects)
				{
					objects.Enqueue(Tuple.Create(d, state));
				}
				pendingObjects.Set();
			}

			public void EndMessageLoop()
			{
				Post(delegate
				{
					done = true;
				}, null);
			}

			public void BeginMessageLoop()
			{
				while (!done)
				{
					Tuple<SendOrPostCallback, object> tuple = null;
					lock (objects)
					{
						if (objects.Count > 0)
						{
							tuple = objects.Dequeue();
						}
					}
					if (tuple != null)
					{
						tuple.Item1(tuple.Item2);
						if (ObjectException != null)
						{
							ExceptionDispatchInfo.Capture(ObjectException).Throw();
						}
					}
					else
					{
						pendingObjects.WaitOne();
					}
				}
			}

			public override SynchronizationContext CreateCopy()
			{
				return this;
			}
		}

		public static void RunSync(Func<Task> workItem)
		{
			SynchronizationContext current = SynchronizationContext.Current;
			try
			{
				ExclusiveSynchronizationContext synch = new ExclusiveSynchronizationContext();
				SynchronizationContext.SetSynchronizationContext(synch);
				synch.Post(async delegate
				{
					try
					{
						await workItem().ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception objectException)
					{
						synch.ObjectException = objectException;
						throw;
					}
					finally
					{
						synch.EndMessageLoop();
					}
				}, null);
				synch.BeginMessageLoop();
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(current);
			}
		}

		public static T RunSync<T>(Func<Task<T>> workItem)
		{
			SynchronizationContext current = SynchronizationContext.Current;
			try
			{
				ExclusiveSynchronizationContext synch = new ExclusiveSynchronizationContext();
				SynchronizationContext.SetSynchronizationContext(synch);
				T ret = default(T);
				synch.Post(async delegate
				{
					try
					{
						ret = await workItem().ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception objectException)
					{
						synch.ObjectException = objectException;
						throw;
					}
					finally
					{
						synch.EndMessageLoop();
					}
				}, null);
				synch.BeginMessageLoop();
				return ret;
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(current);
			}
		}
	}
}
