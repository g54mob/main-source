using UnityEngine;

namespace DG.Tweening.Timeline.Core.Plugins
{
	internal static class DefaultActionPlugins
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
