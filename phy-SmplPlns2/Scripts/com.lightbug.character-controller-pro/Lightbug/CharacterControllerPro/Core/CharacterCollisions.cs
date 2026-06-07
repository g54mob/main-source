using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	public abstract class CharacterCollisions : MonoBehaviour
	{
		private readonly CollisionInfo _collisionInfo = new CollisionInfo();

		protected Transform Transform;

		public HitInfo[] HitsBuffer { get; protected set; } = new HitInfo[20];

		protected CharacterActor CharacterActor { get; private set; }

		public PhysicsComponent PhysicsComponent { get; protected set; }

		private float BackstepDistance => 2f * ContactOffset;

		public abstract float ContactOffset { get; }

		public abstract float CollisionRadius { get; }

		public static CharacterCollisions CreateInstance(GameObject gameObject)
		{
			Rigidbody2D component = gameObject.GetComponent<Rigidbody2D>();
			Rigidbody component2 = gameObject.GetComponent<Rigidbody>();
			if (component != null)
			{
				return gameObject.GetOrAddComponent<CharacterCollisions2D>();
			}
			if (component2 != null)
			{
				return gameObject.GetOrAddComponent<CharacterCollisions3D>();
			}
			return null;
		}

		public CollisionInfo CheckForGround(Vector3 position, float stepOffset, float stepDownDistance, in HitInfoFilter hitInfoFilter, HitFilterDelegate hitFilter = null)
		{
			float num = stepOffset + BackstepDistance;
			Vector3 vector = CustomUtilities.Multiply(-CharacterActor.Up, Mathf.Max(0.1f, stepDownDistance));
			Vector3 bottomCenter = CharacterActor.GetBottomCenter(position, num);
			Vector3 castDisplacement = vector + CustomUtilities.Multiply(Vector3.Normalize(vector), num + ContactOffset);
			PhysicsComponent.SphereCast(out var hitInfo, bottomCenter, CollisionRadius, castDisplacement, in hitInfoFilter, allowOverlaps: false, hitFilter);
			UpdateCollisionInfo(_collisionInfo, position, in hitInfo, castDisplacement, num, calculateEdge: true, in hitInfoFilter);
			return _collisionInfo;
		}

		public CollisionInfo CheckForGroundRay(Vector3 position, in HitInfoFilter hitInfoFilter, HitFilterDelegate hitFilter = null)
		{
			float num = CharacterActor.BodySize.x / 2f;
			Vector3 bottomCenter = CharacterActor.GetBottomCenter(position);
			Vector3 vector = CustomUtilities.Multiply(-CharacterActor.Up, Mathf.Max(0.1f, CharacterActor.stepDownDistance));
			Vector3 castDisplacement = vector + CustomUtilities.Multiply(Vector3.Normalize(vector), num);
			PhysicsComponent.Raycast(out var hitInfo, bottomCenter, castDisplacement, in hitInfoFilter, allowOverlaps: false, hitFilter);
			UpdateCollisionInfo(_collisionInfo, position, in hitInfo, castDisplacement, num, calculateEdge: false, in hitInfoFilter);
			return _collisionInfo;
		}

		public CollisionInfo CastBody(Vector3 position, Vector3 displacement, float bottomOffset, in HitInfoFilter hitInfoFilter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			float backstepDistance = BackstepDistance;
			Vector3 vectorValue = Vector3.Normalize(displacement);
			Vector3 bottomCenter = CharacterActor.GetBottomCenter(position, bottomOffset);
			Vector3 topCenter = CharacterActor.GetTopCenter(position);
			bottomCenter -= CustomUtilities.Multiply(vectorValue, backstepDistance);
			topCenter -= CustomUtilities.Multiply(vectorValue, backstepDistance);
			Vector3 castDisplacement = displacement + CustomUtilities.Multiply(Vector3.Normalize(displacement), backstepDistance + ContactOffset);
			float radius = CharacterActor.BodySize.x / 2f;
			PhysicsComponent.CapsuleCast(out var hitInfo, bottomCenter, topCenter, radius, castDisplacement, in hitInfoFilter, allowOverlaps, hitFilter);
			UpdateCollisionInfo(_collisionInfo, position, in hitInfo, castDisplacement, backstepDistance, calculateEdge: false, in hitInfoFilter);
			return _collisionInfo;
		}

		[Obsolete("Use CheckOverlap instead.")]
		public bool CheckOverlapWithLayerMask(Vector3 position, float bottomOffset, in HitInfoFilter hitInfoFilter, HitFilterDelegate hitFilter = null)
		{
			return CheckOverlap(position, bottomOffset, in hitInfoFilter, hitFilter);
		}

		public bool CheckOverlap(Vector3 position, float bottomOffset, in HitInfoFilter hitInfoFilter, HitFilterDelegate hitFilter = null)
		{
			Vector3 bottomCenter = CharacterActor.GetBottomCenter(position, bottomOffset);
			Vector3 topCenter = CharacterActor.GetTopCenter(position);
			float radius = CharacterActor.BodySize.x / 2f - 0.005f;
			return PhysicsComponent.OverlapCapsule(bottomCenter, topCenter, radius, in hitInfoFilter, hitFilter);
		}

		public bool CheckBodySize(Vector3 size, Vector3 position, in HitInfoFilter hitInfoFilter, HitFilterDelegate hitFilter = null)
		{
			Vector3 bottomCenter = CharacterActor.GetBottomCenter(position, size);
			float radius = size.x / 2f;
			Vector3 bottomCenterToTopCenter = CharacterActor.GetBottomCenterToTopCenter(size);
			PhysicsComponent.SphereCast(out var hitInfo, bottomCenter, radius, bottomCenterToTopCenter, in hitInfoFilter, allowOverlaps: false, hitFilter);
			return !hitInfo.hit;
		}

		public bool CheckBodySize(Vector3 size, in HitInfoFilter hitInfoFilter, HitFilterDelegate hitFilter = null)
		{
			return CheckBodySize(size, CharacterActor.Position, in hitInfoFilter, hitFilter);
		}

		public void UpdateCollisionInfo(CollisionInfo collisionInfo, Vector3 position, in HitInfo hitInfo, Vector3 castDisplacement, float preDistance, bool calculateEdge = true, in HitInfoFilter hitInfoFilter = default(HitInfoFilter))
		{
			if (hitInfo.hit)
			{
				Vector3 vector = Vector3.Normalize(castDisplacement);
				float num = hitInfo.distance - preDistance - ContactOffset;
				Vector3 vector2 = vector * num;
				if (calculateEdge)
				{
					UpdateEdgeInfo(CharacterActor.GetBottomCenter(position + vector2), in hitInfo.point, in hitInfoFilter, out var upperHitInfo, out var lowerHitInfo);
					collisionInfo.SetData(in hitInfo, CharacterActor.Up, vector2, in upperHitInfo, in lowerHitInfo);
				}
				else
				{
					collisionInfo.SetData(in hitInfo, CharacterActor.Up, vector2);
				}
			}
			else
			{
				collisionInfo.Reset();
			}
		}

		private void UpdateEdgeInfo(in Vector3 edgeCenterReference, in Vector3 contactPoint, in HitInfoFilter hitInfoFilter, out HitInfo upperHitInfo, out HitInfo lowerHitInfo)
		{
			Vector3 castDisplacement = CustomUtilities.Multiply(Vector3.Normalize(contactPoint - edgeCenterReference), 2f);
			Vector3 origin = edgeCenterReference + CustomUtilities.Multiply(CharacterActor.Up, 0.005f);
			Vector3 origin2 = edgeCenterReference - CustomUtilities.Multiply(CharacterActor.Up, 0.005f);
			PhysicsComponent.Raycast(out upperHitInfo, origin, castDisplacement, in hitInfoFilter);
			PhysicsComponent.Raycast(out lowerHitInfo, origin2, castDisplacement, in hitInfoFilter);
		}

		protected virtual void Awake()
		{
			CharacterActor = GetComponent<CharacterActor>();
			if (CharacterActor == null)
			{
				Debug.Log("CharacterCollisions: CharacterComponent missing");
			}
		}
	}
}
