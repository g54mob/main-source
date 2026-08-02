using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class PlanarSeekBounds : RadiusSteeringBehaviour
	{
		[Tooltip("Per default, this behaviour writes a value of 1 * 'MagnitudeMultiplier' to the 'TargetObjective' if the receptor is facing towards the percept's bounding box. Otherwise, the value 0 is written. To have a smoother transition at the bounding box edges, the 'Spread' can be increased, whereby a spread of 0 is the default and with a spread of 1, the outer vertices of the bounding box can be interpreted as independent obstacles (or interest objects). This results in the typical magnitude fan around the receptor, except the difference hat everything pointing towards the bounds is still 1 * 'MagnitudeMultiplier'.")]
		[Range(0f, 1f)]
		public float Spread = 1f;

		[Tooltip("Determines which bounding box model is used for this behaviour. Each model has got different properties, and thus, a distinct impact on the performance.\n\nThe default BoundsType.ColliderAABB uses the axis-aligned bounding box which has the lowest impact on performance. However, if objects are rotated (not aligned with the world axes), the resulting AABB differs from the actual object specific collider bounds.\n\nBoundsType.ColliderOBB uses the object-oriented bounding box for a more precise result. Hence, it is more expensive. So it is advised to use this option only for dynamic or non-axis-aligned objects.\n\nBoundsType.Visual is similar to BoundsType.ColliderOBB, so it uses the object-oriented bounding box. The difference is that the bounds are given by the visual representation of the object, either by the SpriteRenderer or the MeshRenderer. For this to work with meshes, a received object must not be static, or otherwise, no visual bounds can be received. Concerning performance, the same advice is given as for BoundsType.ColliderOBB.")]
		public BoundsType BoundsType = BoundsType.ColliderOBB;

		protected bool inverted;

		private Quaternion invRot;

		private Vector3 dir1;

		private Vector3 dir2;

		private Vector3 rotDir;

		private Vector3 leftDir;

		private Vector3 rightDir;

		private Vector3 centerDir;

		private Vector3 localCenter;

		private Vector3 extentsTmp;

		private Vector3 selfPos;

		private Vector3 posChache;

		private Vector3 extents;

		private float sqrDistance;

		private float dot;

		private float dotL;

		private float dotR;

		private float dotC;

		private float distance;

		private float innerDist;

		protected override bool forEachPercept => true;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			if (!percept.IsNearBounds(BoundsType, self.Position, OuterRadius))
			{
				return false;
			}
			sqrDistance = percept.GetBoundsSqrDistance(self.Position, BoundsType, VectorProjection);
			innerDist = (percept.Position - self.Position).sqrMagnitude;
			sqrInnerRadius = InnerRadius * InnerRadius;
			sqrOuterRadius = OuterRadius * OuterRadius;
			if (innerDist < sqrInnerRadius || sqrDistance > sqrOuterRadius)
			{
				return false;
			}
			distance = MoveBehaviour.MapSpecial(RadiusMapping, 0f, OuterRadius, Mathf.Sqrt(sqrDistance));
			localCenter = Vector3.zero;
			switch (BoundsType)
			{
			case BoundsType.ColliderOBB:
				invRot = Quaternion.Inverse(percept.Rotation);
				selfPos = percept.WorldToLocalMatrix.MultiplyPoint(self.Position);
				selfPos.Scale(percept.Scale);
				extents = percept.ColliderBoundsOBB.extents;
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
				invRot = Quaternion.Inverse(percept.Rotation);
				selfPos = percept.WorldToLocalMatrix.MultiplyPoint(self.Position);
				selfPos.Scale(percept.Scale);
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
				invRot = Quaternion.identity;
				selfPos = self.Position;
				extents = percept.ColliderBoundsAABB.extents;
				localCenter = percept.ColliderBoundsAABB.center;
				break;
			}
			extentsTmp = extents;
			posChache = selfPos;
			DetermineDirection();
			selfPos = posChache;
			if (VectorProjection != VectorProjectionType.PlaneXY)
			{
				dir1.z = dir1.y;
				dir1.y = 0f;
				dir2.z = dir2.y;
				dir2.y = 0f;
				centerDir.z = centerDir.y;
				centerDir.y = 0f;
			}
			if (BoundsType == BoundsType.ColliderAABB && VectorProjection != VectorProjectionType.PlaneXY)
			{
				localCenter.z = localCenter.y;
				localCenter.y = 0f;
			}
			leftDir.x = localCenter.x + extents.x * dir1.x - selfPos.x;
			leftDir.y = localCenter.y + extents.y * dir1.y - selfPos.y;
			leftDir.z = localCenter.z + extents.z * dir1.z - selfPos.z;
			rightDir.x = localCenter.x + extents.x * dir2.x - selfPos.x;
			rightDir.y = localCenter.y + extents.y * dir2.y - selfPos.y;
			rightDir.z = localCenter.z + extents.z * dir2.z - selfPos.z;
			leftDir.Normalize();
			rightDir.Normalize();
			centerDir.Normalize();
			dot = Vector3.Dot(leftDir, rightDir);
			Vector3 vector = rightDir;
			for (int i = 0; i < sensor.ReceptorCount; i++)
			{
				structure = sensor.GetReceptor(i).Structure;
				rotDir = invRot * Context.LocalToWorldMatrix.MultiplyVector(structure.Direction);
				dotL = Vector3.Dot(rotDir, leftDir);
				dotR = Vector3.Dot(rotDir, rightDir);
				dotC = Vector3.Dot(rotDir, centerDir);
				if (dotC >= 0.01f && dotL >= dot && dotR >= dot)
				{
					if (!inverted)
					{
						ResultMagnitude = distance * structure.Magnitude * (UseSignificance ? percept.Significance : 1f);
					}
					else
					{
						ResultMagnitude = 0f;
					}
				}
				else
				{
					vector = rightDir;
					if (dotL > dotR)
					{
						vector = leftDir;
					}
					if (BoundsType != BoundsType.ColliderAABB)
					{
						vector = percept.Rotation * vector;
					}
					ResultMagnitude = (UseSignificance ? percept.Significance : 1f) * structure.Magnitude * MapBySensitivity(ValueMapping, structure, vector, SensitivityOffset);
					ResultMagnitude *= Spread;
					if (inverted)
					{
						ResultMagnitude = 1f - ResultMagnitude;
					}
					ResultMagnitude *= distance;
				}
				WriteValue(ValueWriting, TargetObjective, i, ResultMagnitude * MagnitudeMultiplier, LayerBlending != LayerBlendingType.None);
			}
			return false;
		}

		private void DetermineDirection()
		{
			if (VectorProjection != VectorProjectionType.PlaneXY)
			{
				localCenter.y = localCenter.z;
				localCenter.z = 0f;
				extentsTmp.y = extentsTmp.z;
				extentsTmp.z = 0f;
				selfPos.y = selfPos.z;
				selfPos.z = 0f;
			}
			dir1.x = 1f;
			dir1.y = 1f;
			dir1.z = 0f;
			dir2.x = 1f;
			dir2.y = 1f;
			dir2.z = 0f;
			centerDir.x = 1f;
			centerDir.y = 1f;
			centerDir.z = 0f;
			if (selfPos.y >= localCenter.y + extentsTmp.y)
			{
				centerDir.y = -1f;
				if (selfPos.x < localCenter.x - extentsTmp.x)
				{
					dir1.x = -1f;
					dir1.y = -1f;
				}
				else if (selfPos.x > localCenter.x + extentsTmp.x)
				{
					dir1.x = -1f;
					dir2.y = -1f;
					centerDir.x = -1f;
				}
				else
				{
					dir1.x = -1f;
					centerDir.x = 0f;
				}
			}
			else if (selfPos.y <= localCenter.y - extentsTmp.y)
			{
				if (selfPos.x < localCenter.x - extentsTmp.x)
				{
					dir1.x = -1f;
					dir2.y = -1f;
				}
				else if (selfPos.x > localCenter.x + extentsTmp.x)
				{
					dir1.x = -1f;
					dir1.y = -1f;
					centerDir.x = -1f;
				}
				else
				{
					dir1.x = -1f;
					dir1.y = -1f;
					dir2.y = -1f;
					centerDir.x = 0f;
				}
			}
			else if (selfPos.y >= localCenter.y - extentsTmp.y && selfPos.y <= localCenter.y + extentsTmp.y)
			{
				centerDir.y = 0f;
				if (selfPos.x < localCenter.x - extentsTmp.x)
				{
					dir1.x = -1f;
					dir2.x = -1f;
					dir2.y = -1f;
				}
				if (selfPos.x > localCenter.x + extentsTmp.x)
				{
					dir2.y = -1f;
					centerDir.x = -1f;
				}
			}
		}
	}
}
