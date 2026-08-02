using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class SeekBounds : RadiusSteeringBehaviour
	{
		[Tooltip("Determines which bounding box model is used for this behaviour. Each model has got different properties, and thus, a distinct impact on the performance.\n\nThe default BoundsType.ColliderAABB uses the axis-aligned bounding box which has the lowest impact on performance. However, if objects are rotated (not aligned with the world axes), the resulting AABB differs from the actual object specific collider bounds.\n\nBoundsType.ColliderOBB uses the object-oriented bounding box for a more precise result. Hence, it is more expensive. So it is advised to use this option only for dynamic or non-axis-aligned objects.\n\nBoundsType.Visual is similar to BoundsType.ColliderOBB, so it uses the object-oriented bounding box. The difference is that the bounds are given by the visual representation of the object, either by the SpriteRenderer or the MeshRenderer. For this to work with meshes, a received object must not be static, or otherwise, no visual bounds can be received. Concerning performance, the same advice is given as for BoundsType.ColliderOBB.")]
		public BoundsType BoundsType = BoundsType.ColliderOBB;

		protected float invertFactor = 1f;

		private Bounds bounds;

		private float sqrDistance;

		private float sqrInnerDistance;

		protected override bool forEachPercept => true;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			if (!percept.IsNearBounds(BoundsType, self.Position, OuterRadius))
			{
				return false;
			}
			Vector3 vector = percept.WorldToLocalMatrix.MultiplyPoint(self.Position);
			vector.Scale(percept.Scale);
			sqrDistance = percept.GetBoundsSqrDistance(self.Position, BoundsType);
			sqrInnerDistance = (percept.Position - self.Position).sqrMagnitude;
			sqrInnerRadius = InnerRadius * InnerRadius;
			sqrOuterRadius = OuterRadius * OuterRadius;
			if (sqrInnerDistance < sqrInnerRadius || sqrDistance > sqrOuterRadius)
			{
				return false;
			}
			bounds = percept.ColliderBoundsAABB;
			if (BoundsType == BoundsType.ColliderOBB)
			{
				bounds = percept.ColliderBoundsOBB;
			}
			if (BoundsType == BoundsType.Visual)
			{
				bounds = percept.VisualBounds;
			}
			startDirection = bounds.center - self.Position;
			bounds.center = Vector3.zero;
			float distance = 0f;
			float num = (UseSignificance ? percept.Significance : 1f) * MagnitudeMultiplier;
			float num2 = 0f;
			Ray ray = default(Ray);
			for (int i = 0; i < sensor.ReceptorCount; i++)
			{
				receptor = sensor[i];
				structure = receptor.Structure;
				ray.origin = vector + structure.Position;
				ray.direction = invertFactor * (Quaternion.Inverse(percept.Rotation) * Context.LocalToWorldMatrix.MultiplyVector(structure.Direction));
				if (bounds.IntersectRay(ray, out distance))
				{
					startMagnitude = MoveBehaviour.MapSpecial(RadiusMapping, percept.Radius + InnerRadius, percept.Radius + OuterRadius, distance);
					num2 = num * structure.Magnitude * startMagnitude;
				}
				else
				{
					startMagnitude = MoveBehaviour.MapSpecial(RadiusMapping, percept.Radius + InnerRadius, percept.Radius + OuterRadius, startDirection.magnitude);
					num2 = num * structure.Magnitude * startMagnitude * MapBySensitivity(ValueMapping, structure, invertFactor * startDirection, SensitivityOffset);
					num2 *= 2f - startMagnitude;
				}
				WriteValue(ValueWriting, TargetObjective, receptor.ID, num2, LayerBlending != LayerBlendingType.None);
			}
			return false;
		}
	}
}
