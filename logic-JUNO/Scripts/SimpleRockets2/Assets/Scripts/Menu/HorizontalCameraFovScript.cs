using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class HorizontalCameraFovScript : MonoBehaviour
	{
		private Camera _camera;

		[SerializeField]
		private float _horizontalFov = 60f;

		protected virtual void Start()
		{
			_camera = GetComponent<Camera>();
		}

		protected virtual void Update()
		{
			_camera.fieldOfView = _horizontalFov / _camera.aspect;
		}
	}
}
