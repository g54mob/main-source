using System;
using UniGLTF;
using UniJSON;
using UnityEngine;

namespace VRM
{
	[Serializable]
	public class glTF_VRM_SecondaryAnimationCollider : JsonSerializableBase
	{
		[JsonSchema(Description = "The local coordinate from the node of the collider group.")]
		public Vector3 offset;

		[JsonSchema(Description = "The radius of the collider.")]
		public float radius;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => offset);
			f.KeyValue(() => radius);
		}
	}
}
