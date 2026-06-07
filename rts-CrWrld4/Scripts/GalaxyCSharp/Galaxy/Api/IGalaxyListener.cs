using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IGalaxyListener : IDisposable
	{
		private static Dictionary<IntPtr, IGalaxyListener> listeners;

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IGalaxyListener(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(IGalaxyListener obj)
		{
			return default(HandleRef);
		}

		~IGalaxyListener()
		{
		}

		public virtual void Dispose()
		{
		}
	}
}
