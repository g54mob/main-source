using System;
using System.Runtime.InteropServices;
using AOT;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XAsyncBlock : IDisposable
	{
		public struct XAsyncBlockInterop
		{
			public IntPtr queue;

			public IntPtr context;

			public IntPtr callback;

			public unsafe fixed byte reserved[32];
		}

		public XTaskQueueHandle Queue;

		public IntPtr Context;

		public XAsyncCompletionRoutine Callback;

		public XAsyncBlockInterop Interop;

		private GCHandle callbackObjHandle;

		private GCHandle interopHandle;

		private static XAsyncCompletionRoutineInterop InteropCallback;

		private bool disposedValue;

		public bool IsCompleted { get; private set; }

		public IntPtr InteropPtr => (IntPtr)0;

		[AOT.MonoPInvokeCallback(typeof(XAsyncCompletionRoutineInterop))]
		private static void OnXAsyncBlockCompletion(IntPtr asyncBlock)
		{
		}

		public XAsyncBlock(XTaskQueueHandle queue, XAsyncCompletionRoutine callback, IntPtr context)
		{
		}

		private void DoCompletionCallback()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		~XAsyncBlock()
		{
		}

		public void Dispose()
		{
		}
	}
}
