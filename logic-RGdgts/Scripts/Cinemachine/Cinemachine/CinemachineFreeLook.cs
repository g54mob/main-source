using System;
using UnityEngine;

namespace Cinemachine
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[ExcludeFromPreset]
	public class CinemachineFreeLook : CinemachineVirtualCameraBase
	{
		[Serializable]
		public struct Orbit
		{
			public float m_Height;

			public float m_Radius;

			public Orbit(float h, float r)
			{
				m_Height = 0f;
				m_Radius = 0f;
			}
		}

		public delegate CinemachineVirtualCamera CreateRigDelegate(CinemachineFreeLook vcam, string name, CinemachineVirtualCamera copyFrom);

		public delegate void DestroyRigDelegate(GameObject rig);

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_LookAt;

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_Follow;

		public bool m_CommonLens;

		public LensSettings m_Lens;

		public TransitionParams m_Transitions;

		[SerializeField]
		[HideInInspector]
		private BlendHint m_LegacyBlendHint;

		[AxisStateProperty]
		public AxisState m_YAxis;

		public AxisState.Recentering m_YAxisRecentering;

		[AxisStateProperty]
		public AxisState m_XAxis;

		[OrbitalTransposerHeadingProperty]
		public CinemachineOrbitalTransposer.Heading m_Heading;

		public AxisState.Recentering m_RecenterToTargetHeading;

		public CinemachineTransposer.BindingMode m_BindingMode;

		public float m_SplineCurvature;

		public Orbit[] m_Orbits;

		[SerializeField]
		[HideInInspector]
		private float m_LegacyHeadingBias;

		private bool mUseLegacyRigDefinitions;

		private bool mIsDestroyed;

		private CameraState m_State;

		[SerializeField]
		[HideInInspector]
		[NoSaveDuringPlay]
		private CinemachineVirtualCamera[] m_Rigs;

		private CinemachineOrbitalTransposer[] mOrbitals;

		private CinemachineBlend mBlendA;

		private CinemachineBlend mBlendB;

		public static CreateRigDelegate CreateRigOverride;

		public static DestroyRigDelegate DestroyRigOverride;

		private Orbit[] m_CachedOrbits;

		private float m_CachedTension;

		private Vector4[] m_CachedKnots;

		private Vector4[] m_CachedCtrl1;

		private Vector4[] m_CachedCtrl2;

		public static string[] RigNames => null;

		public override bool PreviousStateIsValid
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override CameraState State => default(CameraState);

		public override Transform LookAt
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Transform Follow
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private float CachedXAxisHeading { get; set; }

		protected override void OnValidate()
		{
		}

		public CinemachineVirtualCamera GetRig(int i)
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		public void UpdateInputAxisProvider()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnTransformChildrenChanged()
		{
		}

		private void Reset()
		{
		}

		public override bool IsLiveChild(ICinemachineCamera vcam, bool dominantChildOnly = false)
		{
			return false;
		}

		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		public override void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}

		public override void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
		}

		private float GetYAxisClosestValue(Vector3 cameraPos, Vector3 up)
		{
			return 0f;
		}

		private void InvalidateRigCache()
		{
		}

		private void DestroyRigs()
		{
		}

		private CinemachineVirtualCamera[] CreateRigs(CinemachineVirtualCamera[] copyFrom)
		{
			return null;
		}

		private void UpdateRigCache()
		{
		}

		private int LocateExistingRigs(string[] rigNames, bool forceOrbital)
		{
			return 0;
		}

		private float UpdateXAxisHeading(CinemachineOrbitalTransposer orbital, float deltaTime, Vector3 up)
		{
			return 0f;
		}

		private void PushSettingsToRigs()
		{
		}

		private float GetYAxisValue()
		{
			return 0f;
		}

		private CameraState CalculateNewState(Vector3 worldUp, float deltaTime)
		{
			return default(CameraState);
		}

		public Vector3 GetLocalPositionForCameraFromInput(float t)
		{
			return default(Vector3);
		}

		private void UpdateCachedSpline()
		{
		}
	}
}
