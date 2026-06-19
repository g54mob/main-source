using System;
using Loxodon.Log;

namespace Loxodon.Framework.Asynchronous
{
	internal class ProgressCallbackable<TProgress> : IProgressCallbackable<TProgress>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ProgressCallbackable<TProgress>));

		private IProgressResult<TProgress> result;

		private readonly object _lock = new object();

		private Action<IProgressResult<TProgress>> callback;

		private Action<TProgress> progressCallback;

		public ProgressCallbackable(IProgressResult<TProgress> result)
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
						Action<IProgressResult<TProgress>> action = (Action<IProgressResult<TProgress>>)array[i];
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
				finally
				{
					progressCallback = null;
				}
			}
		}

		public void RaiseOnProgressCallback(TProgress progress)
		{
			lock (_lock)
			{
				try
				{
					if (progressCallback == null)
					{
						return;
					}
					Delegate[] invocationList = progressCallback.GetInvocationList();
					for (int i = 0; i < invocationList.Length; i++)
					{
						Action<TProgress> action = (Action<TProgress>)invocationList[i];
						try
						{
							action(progress);
						}
						catch (Exception ex)
						{
							if (log.IsWarnEnabled)
							{
								log.WarnFormat("Class[{0}] progress callback exception.Error:{1}", GetType(), ex);
							}
						}
					}
				}
				catch (Exception ex2)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("Class[{0}] progress callback exception.Error:{1}", GetType(), ex2);
					}
				}
			}
		}

		public void OnCallback(Action<IProgressResult<TProgress>> callback)
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
				this.callback = (Action<IProgressResult<TProgress>>)Delegate.Combine(this.callback, callback);
			}
		}

		public void OnProgressCallback(Action<TProgress> callback)
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
						callback(result.Progress);
						return;
					}
					catch (Exception ex)
					{
						if (log.IsWarnEnabled)
						{
							log.WarnFormat("Class[{0}] progress callback exception.Error:{1}", GetType(), ex);
						}
						return;
					}
				}
				progressCallback = (Action<TProgress>)Delegate.Combine(progressCallback, callback);
			}
		}
	}
	internal class ProgressCallbackable<TProgress, TResult> : IProgressCallbackable<TProgress, TResult>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ProgressCallbackable<TProgress, TResult>));

		private IProgressResult<TProgress, TResult> result;

		private readonly object _lock = new object();

		private Action<IProgressResult<TProgress, TResult>> callback;

		private Action<TProgress> progressCallback;

		public ProgressCallbackable(IProgressResult<TProgress, TResult> result)
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
						Action<IProgressResult<TProgress, TResult>> action = (Action<IProgressResult<TProgress, TResult>>)array[i];
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
				finally
				{
					progressCallback = null;
				}
			}
		}

		public void RaiseOnProgressCallback(TProgress progress)
		{
			lock (_lock)
			{
				try
				{
					if (progressCallback == null)
					{
						return;
					}
					Delegate[] invocationList = progressCallback.GetInvocationList();
					for (int i = 0; i < invocationList.Length; i++)
					{
						Action<TProgress> action = (Action<TProgress>)invocationList[i];
						try
						{
							action(progress);
						}
						catch (Exception ex)
						{
							if (log.IsWarnEnabled)
							{
								log.WarnFormat("Class[{0}] progress callback exception.Error:{1}", GetType(), ex);
							}
						}
					}
				}
				catch (Exception ex2)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("Class[{0}] progress callback exception.Error:{1}", GetType(), ex2);
					}
				}
			}
		}

		public void OnCallback(Action<IProgressResult<TProgress, TResult>> callback)
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
				this.callback = (Action<IProgressResult<TProgress, TResult>>)Delegate.Combine(this.callback, callback);
			}
		}

		public void OnProgressCallback(Action<TProgress> callback)
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
						callback(result.Progress);
						return;
					}
					catch (Exception ex)
					{
						if (log.IsWarnEnabled)
						{
							log.WarnFormat("Class[{0}] progress callback exception.Error:{1}", GetType(), ex);
						}
						return;
					}
				}
				progressCallback = (Action<TProgress>)Delegate.Combine(progressCallback, callback);
			}
		}
	}
}
