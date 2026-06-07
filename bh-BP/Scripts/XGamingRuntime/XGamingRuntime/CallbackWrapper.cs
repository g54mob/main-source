using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime
{
	public class CallbackWrapper<T> : IDisposable where T : Delegate
	{
		private GCHandle selfPtr;

		public T StaticCallback { get; private set; }

		public T Callback { get; private set; }

		public IntPtr Context { get; private set; }

		public IntPtr CallbackContext => (IntPtr)0;

		public CallbackWrapper(T callback, IntPtr context, T staticCallback)
		{
		}

		~CallbackWrapper()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
