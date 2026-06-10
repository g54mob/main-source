using System;
using FoxyVoxel.Logging;
using NSEipix.Base;

namespace NSMedieval.Controllers
{
	public class LoadingOverlayController : MonoSingleton<LoadingOverlayController>
	{
		public event Action<bool, bool> ShowOverlayEvent;

		public void ShowOverlay(bool show, bool showLoadingBar = true)
		{
			Log.Debug("Show overlay", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LoadingOverlayController.cs");
			this.ShowOverlayEvent?.Invoke(show, showLoadingBar);
		}
	}
}
