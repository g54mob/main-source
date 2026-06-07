using UnityEngine;

namespace RLD
{
	public static class CameraFocus
	{
		public class Data
		{
			private Vector3 _cameraWorldPosition;

			private Vector3 _focusPoint;

			private float _focusPointOffset;

			public Vector3 CameraWorldPosition => _cameraWorldPosition;

			public Vector3 FocusPoint => _focusPoint;

			public float FocusPointOffset => _focusPointOffset;

			public Data(Vector3 cameraWorldPosition, Vector3 focusPoint)
			{
				_cameraWorldPosition = cameraWorldPosition;
				_focusPoint = focusPoint;
				_focusPointOffset = (cameraWorldPosition - focusPoint).magnitude;
			}
		}

		public static Data CalculateFocusData(Camera camera, AABB focusAABB, CameraFocusSettings focusSettings)
		{
			float magnitude = focusAABB.Size.magnitude;
			float num = camera.GetFrustumDistanceFromHeight(magnitude) + focusSettings.FocusDistanceAdd;
			if (num < camera.nearClipPlane)
			{
				num += camera.nearClipPlane - num;
			}
			return new Data(focusAABB.Center - camera.transform.forward * num, focusAABB.Center);
		}
	}
}
