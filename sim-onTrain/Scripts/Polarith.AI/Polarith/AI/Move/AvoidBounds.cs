using System;
using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class AvoidBounds : Avoid
	{
		[Tooltip("The plane for determining the resulting magnitude values moves smoothly around the corners of the perceived objects bounds. With this non-negative parameter, the smoothness can be increased. In practice, this controls how close the avoidance trajectory is towards the bounds. This value is in Unity units and dependent on the longest side of the colliders bounds. It is internally clamped to the maximum bounds size and thus resulting in a behaviour equivalent to 'AIMAvoid'.")]
		[OpenRangeMin(0f)]
		[SerializeField]
		private float smoothness;

		[Tooltip("Determines which bounding box model is used for this behaviour. Each model has got different properties, and thus, a different impact on the performance.\n\nThe default 'ColliderAABB' uses the axis-aligned bounding box which has the lowest impact on performance. However, if objects are rotated (not aligned with the world axes), the resulting AABB differs from the actual object specific collider bounds.\n\n'ColliderOBB' uses the object-oriented bounding box for a more precise result. Hence, it is more expensive. So it is advised to use this option only for dynamic and/or non-axis-aligned objects.\n\n'Visual' is similar to 'ColliderOBB', so it uses the object-oriented bounding box. The difference is that the bounds are given by the visual representation of the object, either by the 'SpriteRenderer' or the 'MeshRenderer'. In order for this to work with meshes, a received object must not be static, or otherwise, no visual bounds can be received. With respect to performance, the same advice is given for 'ColliderOBB'.")]
		[SerializeField]
		private BoundsType boundsType = BoundsType.ColliderOBB;

		private static Vector3[] dim = new Vector3[3]
		{
			Vector3.right,
			Vector3.up,
			Vector3.forward
		};

		private Vector3 intersection;

		private Vector3 normal;

		private Vector3 extents;

		private Vector3 center;

		private Vector3 position;

		private Vector3 positionBounds;

		private Vector3 borderLeft;

		private Vector3 borderRight;

		private float capOffset;

		private int shortest;

		private int longest;

		public Vector3 Intersection => intersection;

		public float Smoothness
		{
			get
			{
				return smoothness;
			}
			set
			{
				smoothness = value;
			}
		}

		public BoundsType BoundsType
		{
			get
			{
				return boundsType;
			}
			set
			{
				boundsType = value;
			}
		}

		protected override bool IsPerceptSignificant()
		{
			switch (boundsType)
			{
			case BoundsType.ColliderAABB:
				extents = percept.ColliderBoundsAABB.extents;
				center = percept.ColliderBoundsAABB.center;
				percept.ColliderBoundsAABB.center = Vector3.zero;
				position = Quaternion.Inverse(percept.Rotation) * (self.Position - percept.Position - (center - percept.Position));
				positionBounds = percept.ColliderBoundsAABB.ClosestPoint(position);
				percept.ColliderBoundsAABB.center = center;
				break;
			case BoundsType.ColliderOBB:
				extents = percept.ColliderBoundsOBB.extents;
				center = percept.ColliderBoundsOBB.center;
				percept.ColliderBoundsOBB.center = Vector3.zero;
				position = Quaternion.Inverse(percept.Rotation) * (self.Position - percept.Position - (center - percept.Position));
				positionBounds = percept.ColliderBoundsOBB.ClosestPoint(position);
				percept.ColliderBoundsOBB.center = center;
				break;
			case BoundsType.Visual:
				extents = percept.VisualBounds.extents;
				center = percept.VisualBounds.center;
				percept.VisualBounds.center = Vector3.zero;
				position = Quaternion.Inverse(percept.Rotation) * (self.Position - percept.Position - (center - percept.Position));
				positionBounds = percept.VisualBounds.ClosestPoint(position);
				percept.VisualBounds.center = center;
				break;
			}
			intersection = percept.Position + (center - percept.Position) + percept.Rotation * positionBounds;
			startDirection = intersection - self.Position;
			sqrInnerRadius = InnerRadius * InnerRadius;
			sqrOuterRadius = OuterRadius * OuterRadius;
			if (startDirection.sqrMagnitude < sqrInnerRadius || startDirection.sqrMagnitude > sqrOuterRadius)
			{
				return false;
			}
			SortExtents();
			capOffset = ((smoothness >= 0f) ? smoothness : 0f);
			if (capOffset >= extents[shortest] + extents[longest])
			{
				capOffset = extents[shortest] + extents[longest];
			}
			if (extents.x <= 0.05f)
			{
				extents.x = 0.05f;
			}
			if (extents.y <= 0.05f)
			{
				extents.y = 0.05f;
			}
			if (extents.z <= 0.05f)
			{
				extents.z = 0.05f;
			}
			borderRight = dim[longest] * (extents[longest] - extents[shortest] - capOffset);
			borderLeft = -borderRight;
			if (positionBounds[longest] >= borderLeft[longest] && positionBounds[longest] <= borderRight[longest])
			{
				normal = positionBounds;
				normal[longest] = 0f;
				normal.Normalize();
			}
			else if (positionBounds[longest] >= borderRight[longest])
			{
				normal = (borderRight - position).normalized;
			}
			else if (positionBounds[longest] <= borderLeft[longest])
			{
				normal = (borderLeft - position).normalized;
			}
			startMagnitude = MoveBehaviour.MapSpecialSqr(RadiusMapping, sqrInnerRadius, sqrOuterRadius, startDirection.sqrMagnitude);
			return true;
		}

		protected override void CalculatePlane()
		{
			normal = percept.Rotation * normal;
			if (Mathf2.Approximately(normal.y, 0f) && Mathf2.Approximately(normal.x, 0f))
			{
				planeDirection1 = new Vector3(0f - normal.z, 0f, normal.x);
			}
			else
			{
				planeDirection1 = new Vector3(0f - normal.y, normal.x, 0f);
			}
			planeDirection2 = new Vector3(0f - normal.z * planeDirection1.y, normal.z * planeDirection1.x, normal.x * planeDirection1.y - normal.y * planeDirection1.x);
			planeDirection2 -= Vector3.Dot(planeDirection1, planeDirection2) / Vector3.Dot(planeDirection1, planeDirection1) * planeDirection1;
			planeDirection1.Normalize();
			planeDirection2.Normalize();
		}

		private void SortExtents()
		{
			longest = 0;
			shortest = 2;
			if (extents.x < extents.y)
			{
				if (extents.x < extents.z)
				{
					shortest = 0;
					if (extents.z < extents.y)
					{
						longest = 1;
					}
					else
					{
						longest = 2;
					}
				}
			}
			else if (extents.z < extents.y)
			{
				shortest = 2;
			}
			else
			{
				shortest = 1;
			}
		}
	}
}
