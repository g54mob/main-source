using System;
using System.Collections.Generic;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.blendshape", Description = "BlendShapeAvatar of UniVRM")]
	public class glTF_VRM_BlendShapeMaster : JsonSerializableBase
	{
		public List<glTF_VRM_BlendShapeGroup> blendShapeGroups = new List<glTF_VRM_BlendShapeGroup>();

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.Key("blendShapeGroups");
			f.GLTFValue(blendShapeGroups);
		}
	}
}
