using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalGogServicesConnectionStateListener : IGogServicesConnectionStateListener
	{
		private HandleRef swigCPtr;

		public GlobalGogServicesConnectionStateListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalGogServicesConnectionStateListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
