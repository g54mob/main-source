using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Actors
{
	public class BodyShapeHit
	{
		public BodyShape Shape;

		public Vector3 StartPosition;

		public Vector3 EndPosition;

		public Collider HitCollider;

		public Vector3 HitOrigin;

		public Vector3 HitPoint;

		public Vector3 HitNormal;

		public float HitDistance;

		public float HitRootDistance;

		public bool HitPenetration;

		public bool IsPlatformHit;

		public RaycastHit Hit;

		private static ObjectPool<BodyShapeHit> sPool;

		public static int Length => 0;

		public void CalculateHitOrigin()
		{
		}

		public static BodyShapeHit Allocate()
		{
			return null;
		}

		public static BodyShapeHit Allocate(BodyShapeHit rInstance)
		{
			return null;
		}

		public static void Release(BodyShapeHit rInstance)
		{
		}
	}
}
