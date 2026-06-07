using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class CinemachineCollider : CinemachineExtension
	{
		public enum ResolutionStrategy
		{
			PullCameraForward = 0,
			PreserveCameraHeight = 1,
			PreserveCameraDistance = 2
		}

		private class VcamExtraState
		{
			public Vector3 m_previousDisplacement;

			public Vector3 m_previousDisplacementCorrection;

			public float colliderDisplacement;

			public bool targetObscured;

			public float occlusionStartTime;

			public List<Vector3> debugResolutionPath;

			private float m_SmoothedDistance;

			private float m_SmoothedTime;

			public void AddPointToDebugPath(Vector3 p)
			{
			}

			public float ApplyDistanceSmoothing(float distance, float smoothingTime)
			{
				return 0f;
			}

			public void UpdateDistanceSmoothing(float distance, float smoothingTime)
			{
			}

			public void ResetDistanceSmoothing(float smoothingTime)
			{
			}
		}

		public LayerMask m_CollideAgainst;

		[TagField]
		public string m_IgnoreTag;

		public LayerMask m_TransparentLayers;

		public float m_MinimumDistanceFromTarget;

		[Space]
		public bool m_AvoidObstacles;

		public float m_DistanceLimit;

		public float m_MinimumOcclusionTime;

		public float m_CameraRadius;

		public ResolutionStrategy m_Strategy;

		public int m_MaximumEffort;

		public float m_SmoothingTime;

		public float m_Damping;

		public float m_DampingWhenOccluded;

		public float m_OptimalTargetDistance;

		private const float PrecisionSlush = 0.001f;

		private RaycastHit[] m_CornerBuffer;

		private const float AngleThreshold = 0.1f;

		private Collider[] mColliderBuffer;

		private static SphereCollider mCameraCollider;

		private static GameObject mCameraColliderGameObject;

		public List<List<Vector3>> DebugPaths => null;

		public bool IsTargetObscured(ICinemachineCamera vcam)
		{
			return false;
		}

		public bool CameraWasDisplaced(ICinemachineCamera vcam)
		{
			return false;
		}

		public float GetCameraDisplacementDistance(ICinemachineCamera vcam)
		{
			return 0f;
		}

		private void OnValidate()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}

		private Vector3 PreserveLineOfSight(ref CameraState state, ref VcamExtraState extra)
		{
			return default(Vector3);
		}

		private Vector3 PullCameraInFrontOfNearestObstacle(Vector3 cameraPos, Vector3 lookAtPos, int layerMask, ref RaycastHit hitInfo)
		{
			return default(Vector3);
		}

		private Vector3 PushCameraBack(Vector3 currentPos, Vector3 pushDir, RaycastHit obstacle, Vector3 lookAtPos, Plane startPlane, float targetDistance, int iterations, ref VcamExtraState extra)
		{
			return default(Vector3);
		}

		private bool GetWalkingDirection(Vector3 pos, Vector3 pushDir, RaycastHit obstacle, ref Vector3 outDir)
		{
			return false;
		}

		private float GetPushBackDistance(Ray ray, Plane startPlane, float targetDistance, Vector3 lookAtPos)
		{
			return 0f;
		}

		private float ClampRayToBounds(Ray ray, float distance, Bounds bounds)
		{
			return 0f;
		}

		private static void DestroyCollider()
		{
		}

		private Vector3 RespectCameraRadius(Vector3 cameraPos, ref CameraState state)
		{
			return default(Vector3);
		}

		private bool CheckForTargetObstructions(CameraState state)
		{
			return false;
		}

		private bool IsTargetOffscreen(CameraState state)
		{
			return false;
		}
	}
}
