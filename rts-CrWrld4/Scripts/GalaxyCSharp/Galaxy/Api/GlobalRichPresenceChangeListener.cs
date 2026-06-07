using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalRichPresenceChangeListener : IRichPresenceChangeListener
	{
		private HandleRef swigCPtr;

		public GlobalRichPresenceChangeListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalRichPresenceChangeListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
