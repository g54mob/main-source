using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalAuthListener : IAuthListener
	{
		private HandleRef swigCPtr;

		public GlobalAuthListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalAuthListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
