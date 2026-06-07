using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalAchievementChangeListener : IAchievementChangeListener
	{
		private HandleRef swigCPtr;

		public GlobalAchievementChangeListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalAchievementChangeListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
