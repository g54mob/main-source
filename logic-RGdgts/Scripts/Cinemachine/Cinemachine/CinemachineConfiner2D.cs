using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class CinemachineConfiner2D : CinemachineExtension
	{
		private class VcamExtraState
		{
			public Vector3 m_PreviousDisplacement;

			public Vector3 m_DampedDisplacement;

			public ConfinerOven.BakedSolution m_BakedSolution;

			public CinemachineVirtualCameraBase m_vcam;
		}

		private struct ShapeCache
		{
			public ConfinerOven m_confinerOven;

			public List<List<Vector2>> m_OriginalPath;

			public Matrix4x4 m_DeltaWorldToBaked;

			public Matrix4x4 m_DeltaBakedToWorld;

			private float m_aspectRatio;

			private float m_maxWindowSize;

			internal float m_maxComputationTimePerFrameInSeconds;

			private Matrix4x4 m_bakedToWorld;

			private Collider2D m_boundingShape2D;

			public void Invalidate()
			{
			}

			public bool ValidateCache(Collider2D boundingShape2D, float maxWindowSize, float aspectRatio, out bool confinerStateChanged)
			{
				confinerStateChanged = default(bool);
				return false;
			}

			private bool IsValid(in Collider2D boundingShape2D, in float aspectRatio, in float maxOrthoSize)
			{
				return false;
			}

			private void CalculateDeltaTransformationMatrix()
			{
			}
		}

		public Collider2D m_BoundingShape2D;

		public float m_Damping;

		public float m_MaxWindowSize;

		private float m_MaxComputationTimePerFrameInSeconds;

		private const float k_cornerAngleTreshold = 10f;

		private ShapeCache m_shapeCache;

		public void InvalidateCache()
		{
		}

		public bool ValidateCache(float cameraAspectRatio)
		{
			return false;
		}

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}

		private float CalculateHalfFrustumHeight(in CameraState state, in float cameraPosLocalZ)
		{
			return 0f;
		}

		private void OnValidate()
		{
		}

		private void Reset()
		{
		}
	}
}
