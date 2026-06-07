using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class Cinemachine3rdPersonFollow : CinemachineComponentBase
	{
		public Vector3 Damping;

		public Vector3 ShoulderOffset;

		public float VerticalArmLength;

		public float CameraSide;

		public float CameraDistance;

		public LayerMask CameraCollisionFilter;

		[TagField]
		public string IgnoreTag;

		public float CameraRadius;

		private Vector3 m_PreviousFollowTargetPosition;

		private Vector3 m_DampingCorrection;

		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		private void OnValidate()
		{
		}

		private void Reset()
		{
		}

		private void OnDestroy()
		{
		}

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		private void PositionCamera(ref CameraState curState, float deltaTime)
		{
		}

		public void GetRigPositions(out Vector3 root, out Vector3 shoulder, out Vector3 hand)
		{
			root = default(Vector3);
			shoulder = default(Vector3);
			hand = default(Vector3);
		}

		private Quaternion GetHeading(Vector3 targetForward, Vector3 up)
		{
			return default(Quaternion);
		}

		private void GetRawRigPositions(Vector3 root, Quaternion targetRot, Quaternion heading, out Vector3 shoulder, out Vector3 hand)
		{
			shoulder = default(Vector3);
			hand = default(Vector3);
		}

		private Vector3 ResolveCollisions(Vector3 root, Vector3 tip, float cameraRadius)
		{
			return default(Vector3);
		}
	}
}
