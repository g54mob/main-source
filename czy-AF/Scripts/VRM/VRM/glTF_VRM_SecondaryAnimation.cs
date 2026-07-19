using System;
using System.Collections.Generic;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.secondaryanimation", Description = "The setting of automatic animation of string-like objects such as tails and hairs.")]
	public class glTF_VRM_SecondaryAnimation : JsonSerializableBase
	{
		[JsonSchema(ExplicitIgnorableItemLength = 0)]
		public List<glTF_VRM_SecondaryAnimationGroup> boneGroups = new List<glTF_VRM_SecondaryAnimationGroup>();

		[JsonSchema(ExplicitIgnorableItemLength = 0)]
		public List<glTF_VRM_SecondaryAnimationColliderGroup> colliderGroups = new List<glTF_VRM_SecondaryAnimationColliderGroup>();

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.Key("boneGroups");
			f.GLTFValue(boneGroups);
			f.Key("colliderGroups");
			f.GLTFValue(colliderGroups);
		}
	}
}
