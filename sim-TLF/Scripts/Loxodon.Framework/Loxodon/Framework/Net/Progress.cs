using System;
using Loxodon.Framework.Execution;
using Loxodon.Log;

namespace Loxodon.Framework.Net
{
	public class Progress<T> : IProgress<T>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(Progress<T>));

		private readonly bool runOnMainThread;

		private readonly Action<T> handler;

		public event EventHandler<T> ProgressChanged;

		public Progress()
			: this((Action<T>)null, true)
		{
		}

		public Progress(Action<T> handler)
			: this(handler, true)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
		}

		public Progress(Action<T> handler, bool runOnMainThread)
		{
			this.handler = handler;
			this.runOnMainThread = runOnMainThread;
		}

		protected virtual void OnReport(T value)
		{
			try
			{
				Action<T> action = handler;
				EventHandler<T> eventHandler = this.ProgressChanged;
				if (action == null && eventHandler == null)
				{
					return;
				}
				if (runOnMainThread)
				{
					Executors.RunOnMainThread(delegate
					{
						RaiseProgressChanged(value);
					});
				}
				else
				{
					RaiseProgressChanged(value);
				}
			}
			catch (Exception message)
			{
				if (log.IsErrorEnabled)
				{
					log.Error(message);
				}
			}
		}

		void IProgress<T>.Report(T value)
		{
			OnReport(value);
		}

		private void RaiseProgressChanged(T value)
		{
			Action<T> action = handler;
			EventHandler<T> eventHandler = this.ProgressChanged;
			action?.Invoke(value);
			eventHandler?.Invoke(this, value);
		}
	}
}
