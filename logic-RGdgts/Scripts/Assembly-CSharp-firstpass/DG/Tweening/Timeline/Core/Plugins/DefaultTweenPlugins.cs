using System;
using UnityEngine;

namespace DG.Tweening.Timeline.Core.Plugins
{
	public static class DefaultTweenPlugins
	{
		[RuntimeInitializeOnLoadMethod]
		private static void Register()
		{
		}

		private static DOVisualTweenPlugin GetGlobalTweenPlugin(string id)
		{
			return null;
		}

		private static DOVisualTweenPlugin GetTweenPlugin(Type targetType, string targetTypeFullName)
		{
			return null;
		}
	}
}
