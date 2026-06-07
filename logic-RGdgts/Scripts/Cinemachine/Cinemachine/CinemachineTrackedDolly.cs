using System;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineTrackedDolly : CinemachineComponentBase
	{
		public enum CameraUpMode
		{
			Default = 0,
			Path = 1,
			PathNoRoll = 2,
			FollowTarget = 3,
			FollowTargetNoRoll = 4
		}

		[Serializable]
		public struct AutoDolly
		{
			public bool m_Enabled;

			public float m_PositionOffset;

			public int m_SearchRadius;

			public int m_SearchResolution;

			public AutoDolly(bool enabled, float positionOffset, int searchRadius, int stepsPerSegment)
			{
				m_Enabled = false;
				m_PositionOffset = 0f;
				m_SearchRadius = 0;
				m_SearchResolution = 0;
			}
		}

		public CinemachinePathBase m_Path;

		public float m_PathPosition;

		public CinemachinePathBase.PositionUnits m_PositionUnits;

		public Vector3 m_PathOffset;

		public float m_XDamping;

		public float m_YDamping;

		public float m_ZDamping;

		public CameraUpMode m_CameraUp;

		public float m_PitchDamping;

		public float m_YawDamping;

		public float m_RollDamping;

		public AutoDolly m_AutoDolly;

		private float m_PreviousPathPosition;

		private Quaternion m_PreviousOrientation;

		private Vector3 m_PreviousCameraPosition;

		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		private Vector3 AngularDamping => default(Vector3);

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		private Quaternion GetCameraOrientationAtPathPoint(Quaternion pathOrientation, Vector3 up)
		{
			return default(Quaternion);
		}
	}
}
