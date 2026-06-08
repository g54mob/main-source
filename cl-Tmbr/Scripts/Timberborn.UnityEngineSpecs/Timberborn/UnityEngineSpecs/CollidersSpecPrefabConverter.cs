using System;
using System.Collections.Immutable;
using Timberborn.BlueprintPrefabSystem;
using Timberborn.BlueprintSystem;
using Timberborn.Coordinates;
using UnityEngine;

namespace Timberborn.UnityEngineSpecs
{
	internal class CollidersSpecPrefabConverter : ISpecToPrefabConverter
	{
		public bool CanConvert(ComponentSpec spec)
		{
			return spec is CollidersSpec;
		}

		public void Convert(GameObject owner, ComponentSpec spec)
		{
			CollidersSpec collidersSpec = (CollidersSpec)spec;
			ImmutableArray<BoxColliderSpec>.Enumerator enumerator = collidersSpec.BoxColliders.GetEnumerator();
			while (enumerator.MoveNext())
			{
				BoxColliderSpec current = enumerator.Current;
				BoxCollider boxCollider = owner.AddComponent<BoxCollider>();
				boxCollider.center = current.Center;
				boxCollider.size = current.Size;
			}
			ImmutableArray<SphereColliderSpec>.Enumerator enumerator2 = collidersSpec.SphereColliders.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				SphereColliderSpec current2 = enumerator2.Current;
				SphereCollider sphereCollider = owner.AddComponent<SphereCollider>();
				sphereCollider.center = current2.Center;
				sphereCollider.radius = current2.Radius;
			}
			ImmutableArray<CapsuleColliderSpec>.Enumerator enumerator3 = collidersSpec.CapsuleColliders.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				CapsuleColliderSpec current3 = enumerator3.Current;
				CapsuleCollider capsuleCollider = owner.AddComponent<CapsuleCollider>();
				capsuleCollider.center = current3.Center;
				capsuleCollider.radius = current3.Radius;
				capsuleCollider.height = current3.Height;
				capsuleCollider.direction = GetDirection(current3.Axis);
			}
		}

		private static int GetDirection(Axis axis)
		{
			return axis switch
			{
				Axis.X => 0, 
				Axis.Y => 1, 
				Axis.Z => 2, 
				_ => throw new ArgumentOutOfRangeException("axis", axis, null), 
			};
		}
	}
}
