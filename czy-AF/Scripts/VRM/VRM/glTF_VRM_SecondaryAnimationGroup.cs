using System;
using UniGLTF;
using UniJSON;
using UnityEngine;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.secondaryanimation.spring")]
	public class glTF_VRM_SecondaryAnimationGroup : JsonSerializableBase
	{
		[JsonSchema(Description = "Annotation comment")]
		public string comment;

		[JsonSchema(Description = "The resilience of the swaying object (the power of returning to the initial pose).")]
		public float stiffiness;

		[JsonSchema(Description = "The strength of gravity.")]
		public float gravityPower;

		[JsonSchema(Description = "The direction of gravity. Set (0, -1, 0) for simulating the gravity. Set (1, 0, 0) for simulating the wind.")]
		public Vector3 gravityDir;

		[JsonSchema(Description = "The resistance (deceleration) of automatic animation.")]
		public float dragForce;

		[JsonSchema(Description = "The reference point of a swaying object can be set at any location except the origin. When implementing UI moving with warp, the parent node to move with warp can be specified if you don't want to make the object swaying with warp movement.")]
		public int center;

		[JsonSchema(Description = "The radius of the sphere used for the collision detection with colliders.")]
		public float hitRadius;

		[JsonSchema(Description = "Specify the node index of the root bone of the swaying object.")]
		[ItemJsonSchema(Minimum = 0.0)]
		public int[] bones = new int[0];

		[JsonSchema(Description = "Specify the index of the collider group for collisions with swaying objects.")]
		[ItemJsonSchema(Minimum = 0.0)]
		public int[] colliderGroups = new int[0];

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => comment);
			f.KeyValue(() => stiffiness);
			f.KeyValue(() => gravityPower);
			f.KeyValue(() => gravityDir);
			f.KeyValue(() => dragForce);
			f.KeyValue(() => center);
			f.KeyValue(() => hitRadius);
			f.KeyValue(() => bones);
			f.KeyValue(() => colliderGroups);
		}
	}
}
