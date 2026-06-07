using System;
using System.Threading;

namespace UnityWebSocketSharp.Net
{
	internal class HttpStreamAsyncResult : IAsyncResult
	{
		private byte[] _buffer;

		private AsyncCallback _callback;

		private bool _completed;

		private int _count;

		private Exception _exception;

		private int _offset;

		private object _state;

		private object _sync;

		private int _syncRead;

		private ManualResetEvent _waitHandle;

		internal byte[] Buffer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal int Count
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal Exception Exception => null;

		internal bool HasException => false;

		internal int Offset
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal int SyncRead
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public object AsyncState => null;

		public WaitHandle AsyncWaitHandle => null;

		public bool CompletedSynchronously => false;

		public bool IsCompleted => false;

		internal HttpStreamAsyncResult(AsyncCallback callback, object state)
		{
		}

		internal void Complete()
		{
		}

		internal void Complete(Exception exception)
		{
		}
	}
}
