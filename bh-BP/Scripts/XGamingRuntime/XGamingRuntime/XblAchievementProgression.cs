using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementProgression
	{
		public XblAchievementRequirement[] Requirements { get; private set; }

		public DateTime TimeUnlocked { get; private set; }

		internal XblAchievementProgression(XGamingRuntime.Interop.XblAchievementProgression interopProgression)
		{
		}
	}
}
