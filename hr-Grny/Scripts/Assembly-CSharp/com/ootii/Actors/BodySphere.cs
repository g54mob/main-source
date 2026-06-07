using System;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Data.Serializers;

namespace com.ootii.Actors
{
	[Serializable]
	public class BodySphere : BodyShape
	{
		public override Vector3 Offset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public override float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[SerializationIgnore]
		public new SphereCollider Collider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override List<BodyShapeHit> CollisionOverlap(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask)
		{
			return null;
		}

		public override BodyShapeHit[] CollisionCastAll(Vector3 rPositionDelta, Vector3 rDirection, float rDistance, int rLayerMask, float rMaxStepHeight = 0f)
		{
			return null;
		}

		public override bool ClosestPoint(Collider rCollider, Vector3 rMovement, bool rProcessTerrain, out Vector3 rShapePoint, out Vector3 rContactPoint)
		{
			rShapePoint = default(Vector3);
			rContactPoint = default(Vector3);
			return false;
		}

		public override Vector3 CalculateHitOrigin(Vector3 rHitPoint, Vector3 rStartPosition, Vector3 rEndPosition)
		{
			return default(Vector3);
		}

		public override void CreateUnityColliders()
		{
		}
	}
}
