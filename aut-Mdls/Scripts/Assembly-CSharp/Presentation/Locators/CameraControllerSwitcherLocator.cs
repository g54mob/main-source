using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/CameraControllerSwitcher", fileName = "CameraControllerSwitcherLocator", order = 0)]
	public class CameraControllerSwitcherLocator : ScriptableObject
	{
		private CameraControllerSwitcher _cameraControllerSwitcher;

		public CameraControllerSwitcher CameraControllerSwitcher => _cameraControllerSwitcher;

		public void SetCameraControllerSwitcher(CameraControllerSwitcher CameraControllerSwitcher)
		{
			_cameraControllerSwitcher = CameraControllerSwitcher;
		}
	}
}
