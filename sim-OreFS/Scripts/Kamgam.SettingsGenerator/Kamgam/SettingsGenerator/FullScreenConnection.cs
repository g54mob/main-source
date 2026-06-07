using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class FullScreenConnection : Connection<bool>
	{
		protected bool? lastKnownFullScreen;

		protected int lastSetFrame;

		public override bool Get()
		{
			if (Time.frameCount - lastSetFrame > 3)
			{
				lastKnownFullScreen = null;
			}
			if (lastKnownFullScreen.HasValue)
			{
				return lastKnownFullScreen.Value;
			}
			return Screen.fullScreen;
		}

		public override void Set(bool fullScreen)
		{
			ScreenOrchestrator.Instance.RequestFullScreen(fullScreen);
			lastSetFrame = Time.frameCount;
			lastKnownFullScreen = fullScreen;
			NotifyListenersIfChanged(fullScreen);
		}
	}
}
