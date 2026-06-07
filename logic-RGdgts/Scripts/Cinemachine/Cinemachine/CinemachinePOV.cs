using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachinePOV : CinemachineComponentBase
	{
		public enum RecenterTargetMode
		{
			None = 0,
			FollowTargetForward = 1,
			LookAtTargetForward = 2
		}

		public RecenterTargetMode m_RecenterTarget;

		[AxisStateProperty]
		public AxisState m_VerticalAxis;

		public AxisState.Recentering m_VerticalRecentering;

		[AxisStateProperty]
		public AxisState m_HorizontalAxis;

		public AxisState.Recentering m_HorizontalRecentering;

		[HideInInspector]
		public bool m_ApplyBeforeBody;

		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		public void UpdateInputAxisProvider()
		{
		}

		public override void PrePipelineMutateCameraState(ref CameraState state, float deltaTime)
		{
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		public Vector2 GetRecenterTarget()
		{
			return default(Vector2);
		}

		private static float NormalizeAngle(float angle)
		{
			return 0f;
		}

		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		public override bool OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime, ref CinemachineVirtualCameraBase.TransitionParams transitionParams)
		{
			return false;
		}

		private void SetAxesForRotation(Quaternion targetRot)
		{
		}
	}
}
