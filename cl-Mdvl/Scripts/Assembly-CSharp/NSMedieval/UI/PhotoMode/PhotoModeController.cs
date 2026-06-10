using System;
using NSEipix.Base;

namespace NSMedieval.UI.PhotoMode
{
	public class PhotoModeController : MonoSingleton<PhotoModeController>
	{
		public event Action<bool> PhotoModeVisibleEvent;

		public void TogglePhotoMode(bool visible)
		{
			this.PhotoModeVisibleEvent?.Invoke(visible);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.PhotoModeVisibleEvent = null;
		}
	}
}
