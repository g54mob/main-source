using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class PlanarAvoidBounds : RadiusSteeringBehaviour
	{
		[Tooltip("Influences the preferred avoidance direction relative to an agent's movement direction.\n\nThe agent will get interest into both left and right according to its movement direction with respect to the 'AvoidanceAngle' in degrees based on how much these directions are facing towards the processed percept.")]
		[Range(0f, 180f)]
		public float AvoidanceAngle = 25f;

		[Tooltip("Is applied to the dot product of an agent's movement direction and the direction perpendicular to the relevant bound side.\n\nIf this value is set to 0, the agent will have the strongest avoid magnitude when directly facing the bounds and an avoid magnitude of 0 when he is perpendicular to the bounds. An offset value near -1 means that the agent will remain at its trajectory and a value of 1 means the agent will try to turn around.")]
		[Range(-1f, 1f)]
		public float Offset;

		[Tooltip("Determines which bounding box model is used for this behaviour. Each model has got different properties, and thus, a distinct impact on the performance.\n\nThe default BoundsType.ColliderAABB uses the axis-aligned bounding box which has the lowest impact on performance. However, if objects are rotated (not aligned with the world axes), the resulting AABB differs from the actual object specific collider bounds.\n\nBoundsType.ColliderOBB uses the object-oriented bounding box for a more precise result. Hence, it is more expensive. So it is advised to use this option only for dynamic or non-axis-aligned objects.\n\nBoundsType.Visual is similar to BoundsType.ColliderOBB, so it uses the object-oriented bounding box. The difference is that the bounds are given by the visual representation of the object, either by the SpriteRenderer or the MeshRenderer. For this to work with meshes, a received object must not be static, or otherwise, no visual bounds can be received. Concerning performance, the same advice is given as for BoundsType.ColliderOBB.")]
		public BoundsType BoundsType = BoundsType.ColliderOBB;

		private static readonly Vector3 nullVec = Vector3.zero;

		private float angle;

		private float sqrDist;

		private float innerDist;

		private float magnitude1;

		private float magnitude2;

		private Vector3 resultDir;

		private Vector3 dir;

		private Vector3 center;

		private Vector3 closestDir;

		private Vector3 extents;

		private Vector3 up;

		private Vector3 selfPos;

		private Vector3 selfDir;

		private Vector3 selfPosTmp;

		private Quaternion inverseRot;

		private Bounds bound;

		protected override bool forEachPercept => true;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			if (!percept.IsNearBounds(BoundsType, self.Position, OuterRadius))
			{
				return false;
			}
			sqrDist = percept.GetBoundsSqrDistance(self.Position, BoundsType, VectorProjection);
			innerDist = (percept.Position - self.Position).sqrMagnitude;
			sqrInnerRadius = InnerRadius * InnerRadius;
			sqrOuterRadius = OuterRadius * OuterRadius;
			if (innerDist < sqrInnerRadius || sqrDist > sqrOuterRadius)
			{
				return false;
			}
			startMagnitude = MoveBehaviour.MapSpecial(RadiusMapping, 0f, OuterRadius, Mathf.Sqrt(sqrDist));
			switch (BoundsType)
			{
			case BoundsType.ColliderOBB:
				inverseRot = Quaternion.Inverse(percept.Rotation);
				selfDir = inverseRot * self.Velocity;
				selfDir.Normalize();
				selfPos = percept.WorldToLocalMatrix.MultiplyPoint(self.Position);
				selfPos.x *= percept.Scale.x;
				selfPos.y *= percept.Scale.y;
				selfPos.z *= percept.Scale.z;
				extents.x = percept.ColliderBoundsOBB.extents.x;
				extents.y = percept.ColliderBoundsOBB.extents.y;
				extents.z = percept.ColliderBoundsOBB.extents.z;
				bound = percept.ColliderBoundsOBB;
				bound.size = extents * 2f;
				if (VectorProjection == VectorProjectionType.PlaneXY)
				{
					selfPos.z = 0f;
				}
				if (VectorProjection == VectorProjectionType.PlaneXZ)
				{
					selfPos.y = 0f;
				}
				break;
			case BoundsType.Visual:
				inverseRot = Quaternion.Inverse(percept.Rotation);
				selfDir = inverseRot * self.Velocity;
				selfDir.Normalize();
				selfPos = percept.WorldToLocalMatrix.MultiplyPoint(self.Position);
				selfPos.x *= percept.Scale.x;
				selfPos.y *= percept.Scale.y;
				selfPos.z *= percept.Scale.z;
				bound = percept.VisualBounds;
				extents = percept.VisualBounds.extents;
				if (VectorProjection == VectorProjectionType.PlaneXY)
				{
					selfPos.z = 0f;
				}
				if (VectorProjection == VectorProjectionType.PlaneXZ)
				{
					selfPos.y = 0f;
				}
				break;
			case BoundsType.ColliderAABB:
				inverseRot = Quaternion.identity;
				selfDir = self.Velocity;
				selfDir.Normalize();
				selfPos = self.Position;
				bound = percept.ColliderBoundsAABB;
				extents = percept.ColliderBoundsAABB.extents;
				break;
			}
			return true;
		}

		protected override void PerceptSteering()
		{
			center = bound.center;
			if (BoundsType != BoundsType.ColliderAABB)
			{
				center.x = 0f;
				center.y = 0f;
				center.z = 0f;
			}
			selfPosTmp = selfPos;
			DetermineDirection();
			selfPos = selfPosTmp;
			up.x = 0f;
			up.y = 0f;
			up.z = 1f;
			if (VectorProjection != VectorProjectionType.PlaneXY)
			{
				dir.z = dir.y;
				dir.y = 0f;
				up.y = 1f;
				up.z = 0f;
			}
			dir.Normalize();
			if (BoundsType != BoundsType.ColliderAABB)
			{
				bound.center = nullVec;
			}
			closestDir = (bound.ClosestPoint(selfPos) - selfPos).normalized;
			angle = Vector3.Dot(selfDir, dir) + Offset;
			angle = ((angle <= 0f) ? 0f : angle);
			ResultDirection = Quaternion.AngleAxis((0f - AvoidanceAngle) * angle, up) * self.Velocity;
			resultDir = Quaternion.AngleAxis(AvoidanceAngle * angle, up) * self.Velocity;
			magnitude1 = Vector3.Dot((inverseRot * ResultDirection).normalized, closestDir);
			magnitude2 = Vector3.Dot((inverseRot * resultDir).normalized, closestDir);
			magnitude1 = ((magnitude1 <= 0f) ? 0f : magnitude1);
			magnitude2 = ((magnitude2 <= 0f) ? 0f : magnitude2);
			ResultMagnitude = startMagnitude * (1f - magnitude1) + startMagnitude * angle;
			magnitude2 = startMagnitude * (1f - magnitude2) + startMagnitude * angle;
			for (int i = 0; i < sensor.ReceptorCount; i++)
			{
				structure = sensor.GetReceptor(i).Structure;
				WriteValue(ValueWritingType.AssignGreater, TargetObjective, i, (UseSignificance ? percept.Significance : 1f) * MagnitudeMultiplier * structure.Magnitude * magnitude2 * MapBySensitivity(ValueMapping, structure, resultDir, SensitivityOffset), LayerBlending != LayerBlendingType.None);
			}
		}

		private void DetermineDirection()
		{
			if (VectorProjection != VectorProjectionType.PlaneXY)
			{
				center.y = center.z;
				center.z = 0f;
				extents.y = extents.z;
				extents.z = 0f;
				selfPos.y = selfPos.z;
				selfPos.z = 0f;
			}
			dir.x = 1f;
			dir.y = 1f;
			dir.z = 0f;
			if (selfPos.y >= center.y + extents.y)
			{
				if (selfPos.x < center.x - extents.x)
				{
					dir.y = -1f;
				}
				else if (selfPos.x > center.x + extents.x)
				{
					dir.x = -1f;
					dir.y = -1f;
				}
				else
				{
					dir.x = 0f;
					dir.y = -1f;
				}
			}
			else if (selfPos.y <= center.y - extents.y)
			{
				if (!(selfPos.x < center.x - extents.x))
				{
					if (selfPos.x > center.x + extents.x)
					{
						dir.x = -1f;
					}
					else
					{
						dir.x = 0f;
					}
				}
			}
			else if (selfPos.y >= center.y - extents.y && selfPos.y <= center.y + extents.y)
			{
				dir.y = 0f;
				if (selfPos.x > center.x + extents.x)
				{
					dir.x = -1f;
				}
			}
		}
	}
}
