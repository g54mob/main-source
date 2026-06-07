using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerSharedFileDownload : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerSharedFileDownload(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GalaxyTypeAwareListenerSharedFileDownload()
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
