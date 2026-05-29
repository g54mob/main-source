using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class Camera2DFollow : MonoBehaviour
	{
		public Transform target;

		public float damping;

		public float lookAheadFactor;

		public float lookAheadReturnSpeed;

		public float lookAheadMoveThreshold;

		private float m_OffsetZ;

		private Vector3 m_LastTargetPosition;

		private Vector3 m_CurrentVelocity;

		private Vector3 m_LookAheadPos;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
