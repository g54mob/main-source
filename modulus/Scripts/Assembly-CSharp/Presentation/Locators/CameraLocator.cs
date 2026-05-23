using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/Camera", fileName = "Camera", order = 0)]
	public class CameraLocator : ScriptableObject
	{
		private Camera _camera;

		public Camera Camera => _camera;

		public void SetCamera(Camera camera)
		{
			_camera = camera;
		}
	}
}
