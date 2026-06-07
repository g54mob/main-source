using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalFileShareListener : IFileShareListener
	{
		private HandleRef swigCPtr;

		public GlobalFileShareListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalFileShareListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
