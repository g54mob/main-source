using UnityEngine;

namespace NWH.WheelController3D
{
	public class CameraFollow : MonoBehaviour
	{
		public Transform target;

		[Range(0f, 30f)]
		public float distance;

		[Range(0f, 10f)]
		public float height;

		[Range(0f, 10f)]
		public float targetUpOffset;

		[Range(-10f, 10f)]
		public float targetForwardOffset;

		[Range(0f, 50f)]
		public float smoothing;

		private float angle;

		[Range(0f, 5f)]
		public float angleFollowStrength;

		private Vector3 targetForward;

		private void Update()
		{
			Vector3 a = targetForward;
			targetForward = Vector3.Lerp(a, target.forward, Time.deltaTime);
			angle = AngleSigned(target.forward, target.position - base.transform.position, Vector3.up);
			Vector3 position = target.position + targetForward * (0f - distance) + Vector3.up * height;
			base.transform.position = position;
			base.transform.LookAt(target.position + Vector3.up * targetUpOffset + target.forward * targetForwardOffset);
			base.transform.rotation = Quaternion.AngleAxis((0f - angle) * angleFollowStrength, Vector3.up) * base.transform.rotation;
		}

		public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
		{
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * 57.29578f;
		}
	}
}
