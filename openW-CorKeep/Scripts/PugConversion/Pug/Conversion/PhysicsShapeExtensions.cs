using Unity.Physics;
using Unity.Physics.Authoring;

namespace Pug.Conversion
{
	internal static class PhysicsShapeExtensions
	{
		internal static CollisionFilter GetFilter(this PhysicsShapeAuthoring shape)
		{
			return new CollisionFilter
			{
				BelongsTo = shape.BelongsTo.Value,
				CollidesWith = shape.CollidesWith.Value
			};
		}

		internal static Material GetMaterial(this PhysicsShapeAuthoring shape)
		{
			return new Material
			{
				Friction = shape.Friction.Value,
				FrictionCombinePolicy = shape.Friction.CombineMode,
				Restitution = shape.Restitution.Value,
				RestitutionCombinePolicy = shape.Restitution.CombineMode,
				CollisionResponse = shape.CollisionResponse,
				CustomTags = shape.CustomTags.Value
			};
		}

		internal static BoxGeometry GetBoxProperties(this PhysicsShapeAuthoring shape, out EulerAngles orientation)
		{
			BoxGeometry boxProperties = shape.GetBoxProperties();
			orientation = new EulerAngles
			{
				Value = boxProperties.Orientation.ToEulerAngles()
			};
			return boxProperties;
		}

		internal static CylinderGeometry GetCylinderProperties(this PhysicsShapeAuthoring shape, out EulerAngles orientation)
		{
			CylinderGeometry cylinderProperties = shape.GetCylinderProperties();
			orientation = new EulerAngles
			{
				Value = cylinderProperties.Orientation.ToEulerAngles()
			};
			return cylinderProperties;
		}
	}
}
