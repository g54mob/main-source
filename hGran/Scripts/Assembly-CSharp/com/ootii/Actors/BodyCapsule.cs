using System;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Data.Serializers;

namespace com.ootii.Actors
{
	[Serializable]
	public class BodyCapsule : BodyShape
	{
		public Transform _EndTransform;

		public Vector3 _EndOffset;

		protected SphereCollider mEndCollider;

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

		public Transform EndTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 EndOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[SerializationIgnore]
		public new CapsuleCollider Collider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[SerializationIgnore]
		public SphereCollider EndCollider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void LateUpdate()
		{
		}

		public override List<BodyShapeHit> CollisionOverlap(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask)
		{
			return null;
		}

		public override BodyShapeHit[] CollisionCastAll(Vector3 rPositionDelta, Vector3 rDirection, float rDistance, int rLayerMask, float rMaxStepHeight = 0f)
		{
			return null;
		}

		public override Vector3 ClosestPoint(Vector3 rOrigin)
		{
			return default(Vector3);
		}

		public override bool ClosestPoint(Collider rCollider, Vector3 rMovement, bool rProcessTerrain, out Vector3 rShapePoint, out Vector3 rContactPoint)
		{
			rShapePoint = default(Vector3);
			rContactPoint = default(Vector3);
			return false;
		}

		public override void CreateUnityColliders()
		{
		}

		private int DetermineDirection()
		{
			return 0;
		}
	}
}
