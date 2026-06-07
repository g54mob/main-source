using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerFileShare : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerFileShare(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GalaxyTypeAwareListenerFileShare()
		{
		}

		public override void Dispose()
		{
		}

		public static ListenerType GetListenerType()
		{
			return default(ListenerType);
		}
	}
}
