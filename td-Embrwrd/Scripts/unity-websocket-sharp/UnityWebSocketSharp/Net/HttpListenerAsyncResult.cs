using System;
using System.Threading;

namespace UnityWebSocketSharp.Net
{
	internal class HttpListenerAsyncResult : IAsyncResult
	{
		private AsyncCallback _callback;

		private bool _completed;

		private bool _completedSynchronously;

		private HttpListenerContext _context;

		private bool _endCalled;

		private Exception _exception;

		private object _state;

		private object _sync;

		private ManualResetEvent _waitHandle;

		internal HttpListenerContext Context => null;

		internal bool EndCalled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal object SyncRoot => null;

		public object AsyncState => null;

		public WaitHandle AsyncWaitHandle => null;

		public bool CompletedSynchronously => false;

		public bool IsCompleted => false;

		internal HttpListenerAsyncResult(AsyncCallback callback, object state)
		{
		}

		private void complete()
		{
		}

		internal void Complete(Exception exception)
		{
		}

		internal void Complete(HttpListenerContext context, bool completedSynchronously)
		{
		}
	}
}
