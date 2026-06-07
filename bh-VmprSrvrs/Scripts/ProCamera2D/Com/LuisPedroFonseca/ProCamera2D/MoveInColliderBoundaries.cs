using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	public class MoveInColliderBoundaries
	{
		private Func<Vector3, float> Vector3H;

		private Func<Vector3, float> Vector3V;

		private Func<float, float, Vector3> VectorHV;

		private const float Offset = 0.2f;

		private const float RaySizeCompensation = 0.2f;

		public Transform CameraTransform;

		public Vector2 CameraSize;

		public LayerMask CameraCollisionMask;

		public int TotalHorizontalRays;

		public int TotalVerticalRays;

		private RaycastOrigins _raycastOrigins;

		private CameraCollisionState _cameraCollisionState;

		private RaycastHit _raycastHit;

		private float _verticalDistanceBetweenRays;

		private float _horizontalDistanceBetweenRays;

		private ProCamera2D _proCamera2D;

		public RaycastOrigins RaycastOrigins => default(RaycastOrigins);

		public CameraCollisionState CameraCollisionState => default(CameraCollisionState);

		public MoveInColliderBoundaries(ProCamera2D proCamera2D)
		{
		}

		public Vector3 Move(Vector3 deltaMovement)
		{
			return default(Vector3);
		}

		private void UpdateRaycastOrigins()
		{
		}

		private void GetOffsetAndForceMovement(Vector3 rayTargetPos, ref Vector3 deltaMovement, ref bool horizontalCheck, ref bool verticalCheck, float hSign, float vSign)
		{
		}

		private float MoveInAxis(float deltaMovement, bool isHorizontal)
		{
			return 0f;
		}

		private void DrawRay(Vector3 start, Vector3 dir, Color color, float duration = 0f)
		{
		}
	}
}
