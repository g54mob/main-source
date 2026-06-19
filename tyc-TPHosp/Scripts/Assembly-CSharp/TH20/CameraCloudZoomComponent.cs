using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CameraCloudZoomComponent : CameraEffect
	{
		private Camera _camera;

		private Vector3 _start;

		private Vector3 _end;

		private float _elapsedTime;

		private float _zoomTime;

		private void Initialise(float zoomTime)
		{
			_elapsedTime = 0f;
			_zoomTime = zoomTime;
			_camera = base.gameObject.GetComponent<Camera>();
		}

		public void ZoomIn(float zoomTime, float distance)
		{
			Initialise(zoomTime);
			_end = Vector3.zero;
			_start = _end - _camera.transform.forward * distance;
		}

		public void ZoomOut(float zoomTime, float distance)
		{
			Initialise(zoomTime);
			_start = Vector3.zero;
			_end = _start - _camera.transform.forward * distance;
		}

		public override void Apply(Camera cam)
		{
			if (_camera != null)
			{
				_elapsedTime += Time.unscaledDeltaTime;
				if (_elapsedTime > _zoomTime)
				{
					Object.Destroy(this);
					return;
				}
				float p = _elapsedTime / _zoomTime;
				Vector3 vector = Vector3.Lerp(_start, _end, EasingsUtils.CubicEaseOut(p));
				_camera.transform.position += vector;
			}
		}
	}
}
