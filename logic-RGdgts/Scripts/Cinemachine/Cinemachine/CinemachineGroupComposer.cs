using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineGroupComposer : CinemachineComposer
	{
		public enum FramingMode
		{
			Horizontal = 0,
			Vertical = 1,
			HorizontalAndVertical = 2
		}

		public enum AdjustmentMode
		{
			ZoomOnly = 0,
			DollyOnly = 1,
			DollyThenZoom = 2
		}

		[Space]
		public float m_GroupFramingSize;

		public FramingMode m_FramingMode;

		public float m_FrameDamping;

		public AdjustmentMode m_AdjustmentMode;

		public float m_MaxDollyIn;

		public float m_MaxDollyOut;

		public float m_MinimumDistance;

		public float m_MaximumDistance;

		public float m_MinimumFOV;

		public float m_MaximumFOV;

		public float m_MinimumOrthoSize;

		public float m_MaximumOrthoSize;

		private float m_prevFramingDistance;

		private float m_prevFOV;

		public Bounds LastBounds { get; private set; }

		public Matrix4x4 LastBoundsMatrix { get; private set; }

		private void OnValidate()
		{
		}

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		private float GetTargetHeight(Vector2 boundsSize)
		{
			return 0f;
		}

		private static Bounds GetScreenSpaceGroupBoundingBox(ICinemachineTargetGroup group, Matrix4x4 observer, out Vector3 newFwd)
		{
			newFwd = default(Vector3);
			return default(Bounds);
		}
	}
}
