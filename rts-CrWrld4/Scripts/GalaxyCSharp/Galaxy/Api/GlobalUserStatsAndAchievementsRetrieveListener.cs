using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalUserStatsAndAchievementsRetrieveListener : IUserStatsAndAchievementsRetrieveListener
	{
		private HandleRef swigCPtr;

		public GlobalUserStatsAndAchievementsRetrieveListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalUserStatsAndAchievementsRetrieveListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
