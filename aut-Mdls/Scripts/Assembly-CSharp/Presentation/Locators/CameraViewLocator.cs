using Presentation.CameraView;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/CameraView", fileName = "CameraViewLocator", order = 0)]
	public class CameraViewLocator : ScriptableObject
	{
		private Presentation.CameraView.CameraView _cameraView;

		public Presentation.CameraView.CameraView CameraView => _cameraView;

		public void SetCameraView(Presentation.CameraView.CameraView cameraView)
		{
			_cameraView = cameraView;
		}
	}
}
