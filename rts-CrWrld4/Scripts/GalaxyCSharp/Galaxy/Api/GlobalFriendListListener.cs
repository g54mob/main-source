using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalFriendListListener : IFriendListListener
	{
		private HandleRef swigCPtr;

		public GlobalFriendListListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalFriendListListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
