using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GlobalStatsAndAchievementsStoreListener : IStatsAndAchievementsStoreListener
	{
		private HandleRef swigCPtr;

		public GlobalStatsAndAchievementsStoreListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GlobalStatsAndAchievementsStoreListener()
		{
		}

		public override void Dispose()
		{
		}
	}
}
