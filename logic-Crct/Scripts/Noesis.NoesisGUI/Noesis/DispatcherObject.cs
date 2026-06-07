using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DispatcherObject : BaseComponent
	{
		public Dispatcher Dispatcher => null;

		public int ThreadId => 0;

		internal new static DispatcherObject CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DispatcherObject(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DispatcherObject obj)
		{
			return default(HandleRef);
		}

		protected DispatcherObject()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public bool CheckAccess()
		{
			return false;
		}

		public void VerifyAccess()
		{
		}
	}
}
