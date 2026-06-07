using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalSharedFileDownloadListener : ISharedFileDownloadListener
	{
		private HandleRef swigCPtr;

		public GlobalSharedFileDownloadListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalSharedFileDownloadListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
