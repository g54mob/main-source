using UnityEngine;

namespace TH20
{
	public class CameraGentleSwayComponent : CameraEffect
	{
		public Vector2 CameraSwayAmplitude = new Vector2(1f, 1f);

		public Vector2 CameraSwayFrequency = new Vector2(1f, 1f);

		private Camera _camera;

		private Vector3 _cachedCameraPosition;

		private float _elapsedTime;

		public override void Apply(Camera cam)
		{
			if (_camera == null)
			{
				_camera = cam;
				_cachedCameraPosition = cam.transform.position;
				_elapsedTime = 0f;
			}
			if (!(_camera == null))
			{
				_elapsedTime += Time.unscaledDeltaTime;
				float num = Mathf.Sin(_elapsedTime * CameraSwayFrequency.x) * CameraSwayAmplitude.x;
				float num2 = Mathf.Sin(_elapsedTime * CameraSwayFrequency.y) * CameraSwayAmplitude.y;
				_camera.transform.position = _cachedCameraPosition + _camera.transform.right * num + _camera.transform.up * num2;
			}
		}
	}
}
