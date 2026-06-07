using System;
using UnityEngine;

namespace UMA.Dynamics
{
	[Serializable]
	public class ColliderDefinition
	{
		[Serializable]
		public enum ColliderType
		{
			Box = 0,
			Sphere = 1,
			Capsule = 2
		}

		public enum Direction
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public ColliderType colliderType;

		public Vector3 colliderCentre;

		[Tooltip("The size of the box collider")]
		public Vector3 boxDimensions;

		public float sphereRadius;

		public float capsuleRadius;

		public float capsuleHeight;

		public Direction capsuleAlignment;
	}
}
