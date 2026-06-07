using System;
using System.ComponentModel;
using System.Threading;

namespace NGenerics.Threading
{
	public class BackgroundWorker<TInput, TOutput, TProgress>
	{
		private readonly SendOrPostCallback operationCompleted;

		private readonly Action<TInput> threadStart;

		protected AsyncOperation AsyncOperation { get; private set; }

		public bool CancellationPending { get; private set; }

		public bool IsBusy { get; private set; }

		public bool WorkerReportsProgress { get; set; }

		public bool ThrowExceptionOnCompleted { get; set; }

		public bool WorkerSupportsCancellation { get; set; }

		public Action<object, DoWorkEventArgs<TInput, TOutput>> DoWork { get; set; }

		public Action<object, ProgressChangedEventArgs<TProgress>> ProgressChanged { get; set; }

		public Action<object, RunWorkerCompletedEventArgs<TOutput>> RunWorkerCompleted { get; set; }

		public BackgroundWorker()
		{
			ThrowExceptionOnCompleted = true;
			threadStart = WorkerThreadStart;
			operationCompleted = AsyncOperationCompleted;
		}

		public void CancelAsync()
		{
			if (!WorkerSupportsCancellation)
			{
				throw new InvalidOperationException("BackgroundWorker_WorkerDoesntSupportCancellation");
			}
			CancellationPending = true;
		}

		public void ReportProgress(int percentProgress)
		{
			ReportProgress(percentProgress, default(TProgress));
		}

		public void ReportProgress(int percentProgress, TProgress userState)
		{
			if (!WorkerReportsProgress)
			{
				throw new InvalidOperationException("BackgroundWorker_WorkerDoesntReportProgress");
			}
			ProgressChangedEventArgs<TProgress> e = new ProgressChangedEventArgs<TProgress>(percentProgress, userState);
			if (AsyncOperation == null)
			{
				OnProgressChanged(e);
				return;
			}
			AsyncOperation.Post(delegate(object state)
			{
				OnProgressChanged((ProgressChangedEventArgs<TProgress>)state);
			}, e);
		}

		public void SleepWhileBusy()
		{
			while (IsBusy)
			{
				Thread.Sleep(10);
			}
		}

		public void ExecuteOnCallingThread<T>(Action<T> action, T arg)
		{
			if (AsyncOperation == null)
			{
				action(arg);
				return;
			}
			AsyncOperation.Post(delegate(object state)
			{
				action((T)state);
			}, arg);
		}

		public void RunWorkerAsync()
		{
			RunWorkerAsync(default(TInput));
		}

		public virtual void RunWorkerAsync(TInput argument)
		{
			if (IsBusy)
			{
				throw new InvalidOperationException("BackgroundWorker_WorkerAlreadyRunning");
			}
			IsBusy = true;
			CancellationPending = false;
			AsyncOperation = AsyncOperationManager.CreateOperation(null);
			threadStart.BeginInvoke(argument, null, null);
		}

		protected virtual void OnDoWork(DoWorkEventArgs<TInput, TOutput> eventArgs)
		{
			if (DoWork == null)
			{
				throw new InvalidOperationException("BackgroundWorker_DoWorkNoDefined");
			}
			DoWork(this, eventArgs);
		}

		protected virtual void OnProgressChanged(ProgressChangedEventArgs<TProgress> eventArgs)
		{
			if (ProgressChanged != null)
			{
				ProgressChanged(this, eventArgs);
			}
		}

		protected virtual void OnRunWorkerCompleted(RunWorkerCompletedEventArgs<TOutput> eventArgs)
		{
			if (ThrowExceptionOnCompleted && eventArgs.Error != null)
			{
				throw eventArgs.Error;
			}
			if (RunWorkerCompleted != null)
			{
				RunWorkerCompleted(this, eventArgs);
			}
		}

		private void AsyncOperationCompleted(object arg)
		{
			IsBusy = false;
			CancellationPending = false;
			OnRunWorkerCompleted((RunWorkerCompletedEventArgs<TOutput>)arg);
		}

		private void WorkerThreadStart(TInput input)
		{
			TOutput result = default(TOutput);
			Exception error = null;
			bool cancelled = false;
			try
			{
				DoWorkEventArgs<TInput, TOutput> e = new DoWorkEventArgs<TInput, TOutput>(input);
				OnDoWork(e);
				if (e.Cancel)
				{
					cancelled = true;
				}
				else
				{
					result = e.Result;
				}
			}
			catch (Exception ex)
			{
				error = ex;
			}
			RunWorkerCompletedEventArgs<TOutput> arg = new RunWorkerCompletedEventArgs<TOutput>(result, error, cancelled);
			AsyncOperation.PostOperationCompleted(operationCompleted, arg);
		}
	}
}
