using System;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public struct OverrideCapsuleCollider
	{
		public string name;

		public bool enabled;

		public bool isTrigger;

		public Vector3 center;

		[Min(0f)]
		public float height;

		[Tooltip("[0: XAxis] [1:Y Axis] [2:Z Axis]")]
		[Min(0f)]
		public int direction;

		[Min(0f)]
		public float radius;

		public PhysicMaterial material;

		[Flag]
		public CapsuleModifier modify;

		public readonly bool IsNull => modify == (CapsuleModifier)0;

		public OverrideCapsuleCollider(CapsuleCollider collider)
		{
			name = "Preset";
			enabled = collider.enabled;
			isTrigger = collider.isTrigger;
			center = collider.center;
			height = collider.height;
			radius = collider.radius;
			direction = collider.direction;
			material = collider.sharedMaterial;
			modify = (CapsuleModifier)(-1);
		}

		public void Modify(CapsuleCollider collider)
		{
			if (modify != 0 && !(collider == null))
			{
				if (Modify(CapsuleModifier.enabled))
				{
					collider.enabled = enabled;
				}
				if (Modify(CapsuleModifier.isTrigger))
				{
					collider.isTrigger = isTrigger;
				}
				if (Modify(CapsuleModifier.center))
				{
					collider.center = center;
				}
				if (Modify(CapsuleModifier.height))
				{
					collider.height = height;
				}
				if (Modify(CapsuleModifier.radius))
				{
					collider.radius = radius;
				}
				if (Modify(CapsuleModifier.direction))
				{
					collider.direction = direction;
				}
				if (Modify(CapsuleModifier.material))
				{
					collider.material = material;
				}
			}
		}

		public bool Modify(CapsuleModifier modifier)
		{
			return (modify & modifier) == modifier;
		}

		public static bool Modify(int modify, CapsuleModifier modifier)
		{
			return ((uint)modify & (uint)modifier) == (uint)modifier;
		}
	}
}
