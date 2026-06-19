using System;
using Loxodon.Log;

namespace Loxodon.Framework.Asynchronous
{
	internal class Callbackable : ICallbackable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(Callbackable));

		private IAsyncResult result;

		private readonly object _lock = new object();

		private Action<IAsyncResult> callback;

		public Callbackable(IAsyncResult result)
		{
			this.result = result;
		}

		public void RaiseOnCallback()
		{
			lock (_lock)
			{
				try
				{
					if (callback == null)
					{
						return;
					}
					Delegate[] invocationList = callback.GetInvocationList();
					callback = null;
					Delegate[] array = invocationList;
					for (int i = 0; i < array.Length; i++)
					{
						Action<IAsyncResult> action = (Action<IAsyncResult>)array[i];
						try
						{
							action(result);
						}
						catch (Exception ex)
						{
							if (log.IsWarnEnabled)
							{
								log.WarnFormat("Class[{0}] callback exception.Error:{1}", GetType(), ex);
							}
						}
					}
				}
				catch (Exception ex2)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("Class[{0}] callback exception.Error:{1}", GetType(), ex2);
					}
				}
			}
		}

		public void OnCallback(Action<IAsyncResult> callback)
		{
			lock (_lock)
			{
				if (callback == null)
				{
					return;
				}
				if (result.IsDone)
				{
					try
					{
						callback(result);
						return;
					}
					catch (Exception ex)
					{
						if (log.IsWarnEnabled)
						{
							log.WarnFormat("Class[{0}] callback exception.Error:{1}", GetType(), ex);
						}
						return;
					}
				}
				this.callback = (Action<IAsyncResult>)Delegate.Combine(this.callback, callback);
			}
		}
	}
	internal class Callbackable<TResult> : ICallbackable<TResult>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(Callbackable<TResult>));

		private IAsyncResult<TResult> result;

		private readonly object _lock = new object();

		private Action<IAsyncResult<TResult>> callback;

		public Callbackable(IAsyncResult<TResult> result)
		{
			this.result = result;
		}

		public void RaiseOnCallback()
		{
			lock (_lock)
			{
				try
				{
					if (callback == null)
					{
						return;
					}
					Delegate[] invocationList = callback.GetInvocationList();
					callback = null;
					Delegate[] array = invocationList;
					for (int i = 0; i < array.Length; i++)
					{
						Action<IAsyncResult<TResult>> action = (Action<IAsyncResult<TResult>>)array[i];
						try
						{
							action(result);
						}
						catch (Exception ex)
						{
							if (log.IsWarnEnabled)
							{
								log.WarnFormat("Class[{0}] callback exception.Error:{1}", GetType(), ex);
							}
						}
					}
				}
				catch (Exception ex2)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("Class[{0}] callback exception.Error:{1}", GetType(), ex2);
					}
				}
			}
		}

		public void OnCallback(Action<IAsyncResult<TResult>> callback)
		{
			lock (_lock)
			{
				if (callback == null)
				{
					return;
				}
				if (result.IsDone)
				{
					try
					{
						callback(result);
						return;
					}
					catch (Exception ex)
					{
						if (log.IsWarnEnabled)
						{
							log.WarnFormat("Class[{0}] callback exception.Error:{1}", GetType(), ex);
						}
						return;
					}
				}
				this.callback = (Action<IAsyncResult<TResult>>)Delegate.Combine(this.callback, callback);
			}
		}
	}
}
