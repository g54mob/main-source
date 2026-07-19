using System;
using System.Collections.Generic;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.secondaryanimation.collidergroup", Description = "Set sphere balls for colliders used for collision detections with swaying objects.")]
	public class glTF_VRM_SecondaryAnimationColliderGroup : JsonSerializableBase
	{
		[JsonSchema(Description = "The node of the collider group for setting up collision detections.", Minimum = 0.0)]
		public int node;

		public List<glTF_VRM_SecondaryAnimationCollider> colliders = new List<glTF_VRM_SecondaryAnimationCollider>();

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => node);
			f.Key("colliders");
			f.GLTFValue(colliders);
		}
	}
}
