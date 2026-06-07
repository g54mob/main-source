using System;
using Cinemachine.Utility;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineOrbitalTransposer : CinemachineTransposer
	{
		[Serializable]
		public struct Heading
		{
			public enum HeadingDefinition
			{
				PositionDelta = 0,
				Velocity = 1,
				TargetForward = 2,
				WorldForward = 3
			}

			public HeadingDefinition m_Definition;

			public int m_VelocityFilterStrength;

			public float m_Bias;

			public Heading(HeadingDefinition def, int filterStrength, float bias)
			{
				m_Definition = default(HeadingDefinition);
				m_VelocityFilterStrength = 0;
				m_Bias = 0f;
			}
		}

		internal delegate float UpdateHeadingDelegate(CinemachineOrbitalTransposer orbital, float deltaTime, Vector3 up);

		[Space]
		[OrbitalTransposerHeadingProperty]
		public Heading m_Heading;

		public AxisState.Recentering m_RecenterToTargetHeading;

		[AxisStateProperty]
		public AxisState m_XAxis;

		[SerializeField]
		[HideInInspector]
		private float m_LegacyRadius;

		[SerializeField]
		[HideInInspector]
		private float m_LegacyHeightOffset;

		[SerializeField]
		[HideInInspector]
		private float m_LegacyHeadingBias;

		[HideInInspector]
		[NoSaveDuringPlay]
		public bool m_HeadingIsSlave;

		internal UpdateHeadingDelegate HeadingUpdater;

		private Vector3 mLastTargetPosition;

		private HeadingTracker mHeadingTracker;

		private Rigidbody mTargetRigidBody;

		private Vector3 mLastCameraPosition;

		private Transform PreviousTarget { get; set; }

		private float LastHeading { get; set; }

		protected override void OnValidate()
		{
		}

		public float UpdateHeading(float deltaTime, Vector3 up, ref AxisState axis)
		{
			return 0f;
		}

		public float UpdateHeading(float deltaTime, Vector3 up, ref AxisState axis, ref AxisState.Recentering recentering, bool isLive)
		{
			return 0f;
		}

		private void OnEnable()
		{
		}

		public void UpdateInputAxisProvider()
		{
		}

		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		public override bool OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime, ref CinemachineVirtualCameraBase.TransitionParams transitionParams)
		{
			return false;
		}

		public float GetAxisClosestValue(Vector3 cameraPos, Vector3 up)
		{
			return 0f;
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		public override Vector3 GetTargetCameraPosition(Vector3 worldUp)
		{
			return default(Vector3);
		}

		private float GetTargetHeading(float currentHeading, Quaternion targetOrientation)
		{
			return 0f;
		}
	}
}
