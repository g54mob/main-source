using System.Runtime.CompilerServices;
using Rewired.UI;

internal static class kRIDpurjMjwwxxsfIWuQHoPXIuoF
{
	private static AdtOIqFjosNYtDDJzoleKiXwEio.EventFunction<IVisibilityChangedHandler, bool> avpaTYtZQCxSldsuGHudTZOYkfu;

	[CompilerGenerated]
	private static AdtOIqFjosNYtDDJzoleKiXwEio.EventFunction<IVisibilityChangedHandler, bool> ZCwIsrHovbcKJeKasXtvDGSZlUI;

	internal static AdtOIqFjosNYtDDJzoleKiXwEio.EventFunction<IVisibilityChangedHandler, bool> visibilityChangedHandlerDelegate
	{
		get
		{
			if (avpaTYtZQCxSldsuGHudTZOYkfu == null)
			{
				avpaTYtZQCxSldsuGHudTZOYkfu = delegate(IVisibilityChangedHandler P_0, bool P_1)
				{
					P_0.OnVisibilityChanged(P_1);
				};
			}
			return avpaTYtZQCxSldsuGHudTZOYkfu;
		}
	}

	[CompilerGenerated]
	private static void MJqypUJHxPQNhmgMBKVGDTViClB(IVisibilityChangedHandler P_0, bool P_1)
	{
		P_0.OnVisibilityChanged(P_1);
	}
}
