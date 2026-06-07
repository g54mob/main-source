using Cinemachine.Utility;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineFramingTransposer : CinemachineComponentBase
	{
		public enum FramingMode
		{
			Horizontal = 0,
			Vertical = 1,
			HorizontalAndVertical = 2,
			None = 3
		}

		public enum AdjustmentMode
		{
			ZoomOnly = 0,
			DollyOnly = 1,
			DollyThenZoom = 2
		}

		public Vector3 m_TrackedObjectOffset;

		[Space]
		public float m_LookaheadTime;

		public float m_LookaheadSmoothing;

		public bool m_LookaheadIgnoreY;

		[Space]
		public float m_XDamping;

		public float m_YDamping;

		public float m_ZDamping;

		public bool m_TargetMovementOnly;

		[Space]
		public float m_ScreenX;

		public float m_ScreenY;

		public float m_CameraDistance;

		[Space]
		public float m_DeadZoneWidth;

		public float m_DeadZoneHeight;

		public float m_DeadZoneDepth;

		[Space]
		public bool m_UnlimitedSoftZone;

		public float m_SoftZoneWidth;

		public float m_SoftZoneHeight;

		public float m_BiasX;

		public float m_BiasY;

		public bool m_CenterOnActivate;

		[Space]
		public FramingMode m_GroupFramingMode;

		public AdjustmentMode m_AdjustmentMode;

		public float m_GroupFramingSize;

		public float m_MaxDollyIn;

		public float m_MaxDollyOut;

		public float m_MinimumDistance;

		public float m_MaximumDistance;

		public float m_MinimumFOV;

		public float m_MaximumFOV;

		public float m_MinimumOrthoSize;

		public float m_MaximumOrthoSize;

		private const float kMinimumCameraDistance = 0.01f;

		private const float kMinimumGroupSize = 0.01f;

		private Vector3 m_PreviousCameraPosition;

		private PositionPredictor m_Predictor;

		private float m_prevFOV;

		private Quaternion m_prevRotation;

		internal Rect SoftGuideRect
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		internal Rect HardGuideRect
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		public override bool BodyAppliesAfterAim => false;

		public Vector3 TrackedPoint { get; private set; }

		private bool InheritingPosition { get; set; }

		public Bounds LastBounds { get; private set; }

		public Matrix4x4 LastBoundsMatrix { get; private set; }

		private void OnValidate()
		{
		}

		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		public override bool OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime, ref CinemachineVirtualCameraBase.TransitionParams transitionParams)
		{
			return false;
		}

		private Rect ScreenToOrtho(Rect rScreen, float orthoSize, float aspect)
		{
			return default(Rect);
		}

		private Vector3 OrthoOffsetToScreenBounds(Vector3 targetPos2D, Rect screenRect)
		{
			return default(Vector3);
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		private float GetTargetHeight(Vector2 boundsSize)
		{
			return 0f;
		}

		private Vector3 ComputeGroupBounds(ICinemachineTargetGroup group, ref CameraState curState)
		{
			return default(Vector3);
		}

		private static Bounds GetScreenSpaceGroupBoundingBox(ICinemachineTargetGroup group, ref Vector3 pos, Quaternion orientation)
		{
			return default(Bounds);
		}
	}
}
