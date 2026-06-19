using UnityEngine;

namespace Gauges
{
	public class NeedleGauge : MonoBehaviour
	{
		[Header("Needle")]
		public Transform needle;

		[Header("Value Range")]
		public float minValue;

		public float maxValue = 200f;

		[Header("Angle Range")]
		public float minAngle = -130f;

		public float maxAngle = 130f;

		[Header("Smoothing")]
		public float smoothSpeed = 10f;

		private float currentAngle;

		[SerializeField]
		private float _offsetX;

		[SerializeField]
		private float _offsetY;

		public void SetValue(float value)
		{
			float t = Mathf.InverseLerp(minValue, maxValue, value);
			float b = Mathf.Lerp(minAngle, maxAngle, t);
			currentAngle = Mathf.Lerp(currentAngle, b, Time.deltaTime * smoothSpeed);
			needle.localRotation = Quaternion.Euler(_offsetX, _offsetY, currentAngle);
		}
	}
}
