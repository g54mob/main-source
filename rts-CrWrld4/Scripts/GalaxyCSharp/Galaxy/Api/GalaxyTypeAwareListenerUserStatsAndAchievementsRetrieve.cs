using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerUserStatsAndAchievementsRetrieve : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerUserStatsAndAchievementsRetrieve(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~GalaxyTypeAwareListenerUserStatsAndAchievementsRetrieve()
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
