using System;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Data.Serializers;

namespace com.ootii.Actors
{
	public abstract class BodyShape
	{
		public const float EPSILON = 0.001f;

		public string _Name;

		public bool _UseUnityColliders;

		public bool _IsEnabledOnGround;

		public bool _IsEnabledOnSlope;

		public bool _IsEnabledAboveGround;

		[NonSerialized]
		public Transform _Parent;

		[NonSerialized]
		public ICharacterController _CharacterController;

		[NonSerialized]
		public Transform _Transform;

		public Vector3 _Offset;

		public float _Radius;

		protected Collider[] mColliders;

		protected RaycastHit[] mRaycastHitArray;

		protected BodyShapeHit[] mBodyShapeHitArray;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseUnityColliders
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsEnabledOnGround
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsEnabledOnSlope
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsEnabledAboveGround
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[SerializationIgnore]
		public Transform Parent => null;

		[SerializationIgnore]
		public ICharacterController CharacterController => null;

		[SerializationIgnore]
		public virtual Transform Transform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual Vector3 Offset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public virtual float Radius
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
		public virtual Collider[] Colliders
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
		public virtual Collider Collider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual void LateUpdate()
		{
		}

		public virtual List<BodyShapeHit> CollisionOverlap(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask)
		{
			return null;
		}

		public virtual BodyShapeHit[] CollisionCastAll(Vector3 rPositionDelta, Vector3 rDirection, float rDistance, int rLayerMask, float rMaxStepHeight = 0f)
		{
			return null;
		}

		public virtual Vector3 ClosestPoint(Vector3 rOrigin)
		{
			return default(Vector3);
		}

		public virtual bool ClosestPoint(Collider rCollider, Vector3 rMovement, bool rProcessTerrain, out Vector3 rShapePoint, out Vector3 rContactPoint)
		{
			rShapePoint = default(Vector3);
			rContactPoint = default(Vector3);
			return false;
		}

		public virtual Vector3 CalculateHitOrigin(Vector3 rHitPoint, Vector3 rStartPosition, Vector3 rEndPosition)
		{
			return default(Vector3);
		}

		public virtual void CreateUnityColliders()
		{
		}

		protected virtual bool CanCreateUnityColliders()
		{
			return false;
		}

		public virtual void DestroyUnityColliders()
		{
		}

		public virtual string Serialize()
		{
			return null;
		}

		public virtual void Deserialize(string rDefinition)
		{
		}
	}
}
