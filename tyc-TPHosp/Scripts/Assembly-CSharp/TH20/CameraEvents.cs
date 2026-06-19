using System;

namespace TH20
{
	public class CameraEvents : IGameEventsBase
	{
		public Action<float> OnCameraPan;

		public Action<float> OnCameraRotate;

		public Action<float> OnCameraPitch;

		public Action<float> OnCameraZoom;

		public void Initialise()
		{
			GameEventsRegistry.RegisterLevelEvent(this);
		}

		public void VerifyEvents()
		{
			OnCameraPan.VerifyIsNull();
			OnCameraRotate.VerifyIsNull();
			OnCameraPitch.VerifyIsNull();
			OnCameraZoom.VerifyIsNull();
		}
	}
}
