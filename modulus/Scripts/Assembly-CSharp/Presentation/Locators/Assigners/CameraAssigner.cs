using UnityEngine;

namespace Presentation.Locators.Assigners
{
	public class CameraAssigner : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private CameraLocator _gridLocator;

		private void Awake()
		{
			_gridLocator.SetCamera(_camera);
		}
	}
}
