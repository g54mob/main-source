using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerFriendList : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerFriendList(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GalaxyTypeAwareListenerFriendList()
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
