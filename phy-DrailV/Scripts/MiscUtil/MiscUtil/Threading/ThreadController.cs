using System;
using System.Threading;

namespace MiscUtil.Threading
{
	public class ThreadController
	{
		private readonly object stateLock = new object();

		private ControlledThreadStart starter;

		private object state;

		private bool started;

		private Thread thread;

		private bool stopping;

		private ExceptionHandler exceptionDelegate;

		private ThreadProgress finishedDelegate;

		private ThreadProgress stopRequestedDelegate;

		public bool Started
		{
			get
			{
				lock (stateLock)
				{
					return started;
				}
			}
		}

		public Thread Thread
		{
			get
			{
				lock (stateLock)
				{
					return thread;
				}
			}
		}

		public bool Stopping
		{
			get
			{
				lock (stateLock)
				{
					return stopping;
				}
			}
		}

		public event ExceptionHandler Exception
		{
			add
			{
				lock (stateLock)
				{
					exceptionDelegate = (ExceptionHandler)Delegate.Combine(exceptionDelegate, value);
				}
			}
			remove
			{
				lock (stateLock)
				{
					exceptionDelegate = (ExceptionHandler)Delegate.Remove(exceptionDelegate, value);
				}
			}
		}

		public event ThreadProgress Finished
		{
			add
			{
				lock (stateLock)
				{
					finishedDelegate = (ThreadProgress)Delegate.Combine(finishedDelegate, value);
				}
			}
			remove
			{
				lock (stateLock)
				{
					finishedDelegate = (ThreadProgress)Delegate.Remove(finishedDelegate, value);
				}
			}
		}

		public event ThreadProgress StopRequested
		{
			add
			{
				lock (stateLock)
				{
					stopRequestedDelegate = (ThreadProgress)Delegate.Combine(stopRequestedDelegate, value);
				}
			}
			remove
			{
				lock (stateLock)
				{
					stopRequestedDelegate = (ThreadProgress)Delegate.Remove(stopRequestedDelegate, value);
				}
			}
		}

		public ThreadController(ControlledThreadStart starter, object state)
		{
			if (starter == null)
			{
				throw new ArgumentNullException("starter");
			}
			this.starter = starter;
			this.state = state;
		}

		public ThreadController(ControlledThreadStart starter)
			: this(starter, null)
		{
		}

		public void CreateThread()
		{
			lock (stateLock)
			{
				if (thread != null)
				{
					throw new InvalidOperationException("Thread has already been created");
				}
				thread = new Thread(RunTask);
			}
		}

		public void Start()
		{
			lock (stateLock)
			{
				if (started)
				{
					throw new InvalidOperationException("Thread has already been created");
				}
				if (thread == null)
				{
					thread = new Thread(RunTask);
				}
				thread.Start();
				started = true;
			}
		}

		public void Stop()
		{
			lock (stateLock)
			{
				stopping = true;
			}
			ThreadProgress threadProgress;
			lock (stateLock)
			{
				threadProgress = stopRequestedDelegate;
			}
			threadProgress?.Invoke(this);
		}

		private void RunTask()
		{
			try
			{
				object obj = state;
				state = null;
				starter(this, obj);
			}
			catch (Exception e)
			{
				ExceptionHandler exceptionHandler;
				lock (stateLock)
				{
					exceptionHandler = exceptionDelegate;
				}
				exceptionHandler?.Invoke(this, e);
			}
			finally
			{
				ThreadProgress threadProgress;
				lock (stateLock)
				{
					threadProgress = finishedDelegate;
				}
				threadProgress?.Invoke(this);
			}
		}
	}
}
