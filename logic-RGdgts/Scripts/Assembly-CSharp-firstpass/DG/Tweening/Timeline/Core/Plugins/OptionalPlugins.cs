using UnityEngine;

namespace DG.Tweening.Timeline.Core.Plugins
{
	internal static class OptionalPlugins
	{
		[RuntimeInitializeOnLoadMethod]
		private static void Register()
		{
		}

		private static DOVisualActionPlugin GetActionPlugin(string id)
		{
			return null;
		}
	}
}
