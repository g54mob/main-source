using UnityEngine;

namespace Gauges
{
	public class GyroGauge : MonoBehaviour
	{
		[Header("References")]
		public Transform horizonDisc;

		public Transform horizonLine;

		public Transform horizonLinePivot;

		[Header("Limits")]
		public float maxPitch = 30f;

		[Header("Smoothing")]
		public float smoothSpeed = 10f;

		[Header("Pitch Translation")]
		public Vector3 pitchAxis = Vector3.up;

		public float pitchToPosition = 0.002f;

		public Vector3 linePositionOffset;

		private float pitchCurrent;

		private float rollCurrent;

		public void SetAttitude(float pitch, float roll)
		{
			pitch = Mathf.Clamp(pitch, 0f - maxPitch, maxPitch);
			pitchCurrent = Mathf.Lerp(pitchCurrent, pitch, Time.deltaTime * smoothSpeed);
			rollCurrent = Mathf.Lerp(rollCurrent, roll, Time.deltaTime * smoothSpeed);
			horizonDisc.localRotation = Quaternion.Euler(0f, rollCurrent, 0f);
			horizonLinePivot.localRotation = Quaternion.Euler(0f, rollCurrent, 0f);
			horizonLine.localPosition = linePositionOffset + pitchAxis.normalized * pitchCurrent * pitchToPosition;
		}

		private void OnDrawGizmos()
		{
			if ((bool)horizonLine)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawLine(horizonLine.position, horizonLine.position + horizonLine.up * 0.05f);
			}
		}
	}
}
