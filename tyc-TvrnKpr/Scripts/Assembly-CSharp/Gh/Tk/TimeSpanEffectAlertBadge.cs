using System.Collections.Generic;

namespace Gh.Tk
{
	public abstract class TimeSpanEffectAlertBadge<T> : AlertBadgeBase where T : TimeSpanEffect
	{
		protected static List<T> _events;

		public TimeSpanEffectAlertBadge(string alertType, string iconId, string titleKey)
		{
		}

		public static void RegisterEvent(T effectEvent)
		{
		}

		public static void UnregisterEvent(T effectEvent)
		{
		}

		protected virtual string GetTooltipKey()
		{
			return null;
		}

		protected override bool UpdateInternal()
		{
			return false;
		}
	}
}
