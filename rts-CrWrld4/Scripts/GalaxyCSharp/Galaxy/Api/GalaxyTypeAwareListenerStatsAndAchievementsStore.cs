using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerStatsAndAchievementsStore : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerStatsAndAchievementsStore(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GalaxyTypeAwareListenerStatsAndAchievementsStore()
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
