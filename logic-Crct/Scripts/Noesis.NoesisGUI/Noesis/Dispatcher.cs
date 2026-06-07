using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Noesis
{
	public sealed class Dispatcher
	{
		private struct DispatcherOperation
		{
			public DispatcherPriority Priority;

			public Delegate Callback;

			public object Args;

			public AutoResetEvent WaitEvent;

			public static void Invoke(Delegate callback, object args, SynchronizationContext context)
			{
			}

			public void Invoke(SynchronizationContext context)
			{
			}

			public void Wait()
			{
			}
		}

		private static Dictionary<int, Dispatcher> _dispatchers;

		private int _threadId;

		private int _managedThreadId;

		private Queue<DispatcherOperation> _operations;

		private DispatcherSynchronizationContext _context;

		public static Dispatcher CurrentDispatcher => null;

		public int ThreadId => 0;

		public SynchronizationContext SynchronizationContext => null;

		private static int CurrentThreadId => 0;

		private int ManagedThreadId => 0;

		private static int CurrentManagedThreadId => 0;

		public bool CheckAccess()
		{
			return false;
		}

		public void VerifyAccess()
		{
		}

		public void BeginInvoke(Action action)
		{
		}

		public void BeginInvoke(Delegate d, object args)
		{
		}

		public void BeginInvoke(DispatcherPriority priority, Action action)
		{
		}

		public void BeginInvoke(DispatcherPriority priority, Delegate d, object args)
		{
		}

		public void Invoke(Action action)
		{
		}

		public void Invoke(Delegate d, object args)
		{
		}

		public void Invoke(DispatcherPriority priority, Action action)
		{
		}

		public void Invoke(DispatcherPriority priority, Delegate d, object args)
		{
		}

		private void AddOperation(DispatcherPriority priority, Delegate d, object args, AutoResetEvent wait = null)
		{
		}

		internal void ProcessQueue()
		{
		}

		internal static Dispatcher FromThreadId(int threadId)
		{
			return null;
		}

		[PreserveSig]
		private static extern int Noesis_GetCurrentThreadId();

		private Dispatcher(int threadId)
		{
		}
	}
}
