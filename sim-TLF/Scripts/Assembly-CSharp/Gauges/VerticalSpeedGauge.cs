using UnityEngine;

namespace Gauges
{
	public class VerticalSpeedGauge : MonoBehaviour
	{
		[Header("Needle")]
		public Transform needle;

		[Header("Vertical Speed")]
		[Tooltip("Maximum climb/descent shown by gauge (m/s)")]
		public float maxVerticalSpeed = 20f;

		[Header("Angles")]
		[Tooltip("Angle at full climb (+maxVerticalSpeed)")]
		public float climbAngle = 90f;

		[Tooltip("Angle at full descent (-maxVerticalSpeed)")]
		public float descentAngle = -90f;

		[Header("Smoothing (VSI lag)")]
		[Tooltip("Lower = more realistic lag")]
		public float responseSpeed = 4f;

		[Header("Rotation Offsets")]
		[SerializeField]
		private float offsetX;

		[SerializeField]
		private float offsetY;

		[SerializeField]
		private float zeroAngle;

		private float displayedSpeed;

		public void SetVerticalSpeed(float verticalSpeed)
		{
			verticalSpeed = Mathf.Clamp(verticalSpeed, 0f - maxVerticalSpeed, maxVerticalSpeed);
			displayedSpeed = Mathf.Lerp(displayedSpeed, verticalSpeed, Time.deltaTime * responseSpeed);
			float num = displayedSpeed / maxVerticalSpeed;
			float num2 = ((num >= 0f) ? Mathf.Lerp(0f, climbAngle, num) : Mathf.Lerp(0f, descentAngle, 0f - num));
			needle.localRotation = Quaternion.Euler(offsetX, offsetY, zeroAngle + num2);
		}
	}
}
