using Cinemachine.Utility;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineComposer : CinemachineComponentBase
	{
		private struct FovCache
		{
			public Rect mFovSoftGuideRect;

			public Rect mFovHardGuideRect;

			public float mFovH;

			public float mFov;

			private float mOrthoSizeOverDistance;

			private float mAspect;

			private Rect mSoftGuideRect;

			private Rect mHardGuideRect;

			public void UpdateCache(LensSettings lens, Rect softGuide, Rect hardGuide, float targetDistance)
			{
			}

			private Rect ScreenToFOV(Rect rScreen, float fov, float fovH, float aspect)
			{
				return default(Rect);
			}
		}

		public Vector3 m_TrackedObjectOffset;

		[Space]
		public float m_LookaheadTime;

		public float m_LookaheadSmoothing;

		public bool m_LookaheadIgnoreY;

		[Space]
		public float m_HorizontalDamping;

		public float m_VerticalDamping;

		[Space]
		public float m_ScreenX;

		public float m_ScreenY;

		public float m_DeadZoneWidth;

		public float m_DeadZoneHeight;

		public float m_SoftZoneWidth;

		public float m_SoftZoneHeight;

		public float m_BiasX;

		public float m_BiasY;

		public bool m_CenterOnActivate;

		private Vector3 m_CameraPosPrevFrame;

		private Vector3 m_LookAtPrevFrame;

		private Vector2 m_ScreenOffsetPrevFrame;

		private Quaternion m_CameraOrientationPrevFrame;

		internal PositionPredictor m_Predictor;

		private FovCache mCache;

		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		public Vector3 TrackedPoint { get; private set; }

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

		protected virtual Vector3 GetLookAtPointAndSetTrackedPoint(Vector3 lookAt, Vector3 up, float deltaTime)
		{
			return default(Vector3);
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

		public override void PrePipelineMutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		private void RotateToScreenBounds(ref CameraState state, Rect screenRect, Vector3 trackedPoint, ref Quaternion rigOrientation, float fov, float fovH, float deltaTime)
		{
		}

		private bool ClampVerticalBounds(ref Rect r, Vector3 dir, Vector3 up, float fov)
		{
			return false;
		}
	}
}
