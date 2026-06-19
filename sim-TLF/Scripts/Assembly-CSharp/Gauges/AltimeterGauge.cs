using UnityEngine;

namespace Gauges
{
	public class AltimeterGauge : MonoBehaviour
	{
		[Header("Needles")]
		public Transform hundredsNeedle;

		public Transform tensNeedle;

		[Header("Smoothing")]
		public float smoothSpeed = 10f;

		[Header("Offsets")]
		[SerializeField]
		private float _offsetX;

		[SerializeField]
		private float _offsetY;

		[SerializeField]
		private float _rotationOffset;

		private float tensAngle;

		private float hundredsAngle;

		private float lastAltitude;

		private bool initialized;

		public void SetAltitude(float altitudeMeters)
		{
			if (!initialized)
			{
				lastAltitude = altitudeMeters;
				initialized = true;
			}
			float num = altitudeMeters - lastAltitude;
			lastAltitude = altitudeMeters;
			float num2 = 3.6f;
			tensAngle += num * num2;
			float num3 = altitudeMeters / 100f;
			float b = Mathf.Lerp(0f, 360f, num3 % 10f / 10f);
			hundredsAngle = Mathf.Lerp(hundredsAngle, b, Time.deltaTime * smoothSpeed);
			tensNeedle.localRotation = Quaternion.Euler(_offsetX, _offsetY, tensAngle - _rotationOffset);
			hundredsNeedle.localRotation = Quaternion.Euler(_offsetX, _offsetY, hundredsAngle - _rotationOffset);
		}
	}
}
