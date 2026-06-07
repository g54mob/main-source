using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class CalculateOrthographicSize : MonoBehaviour
	{
		public Camera MainCamera;

		private Camera _camera;

		public void Start()
		{
			_camera = GetComponent<Camera>();
		}

		public void Update()
		{
			_camera.orthographicSize = MainCamera.orthographicSize * Mathf.Max(1f, MainCamera.aspect) * 1.5f;
		}
	}
}
