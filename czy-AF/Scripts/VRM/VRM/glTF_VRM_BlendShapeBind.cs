using System;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.blendshape.bind")]
	public class glTF_VRM_BlendShapeBind : JsonSerializableBase
	{
		[JsonSchema(Required = true, Minimum = 0.0)]
		public int mesh = -1;

		[JsonSchema(Required = true, Minimum = 0.0)]
		public int index = -1;

		[JsonSchema(Required = true, Minimum = 0.0, Maximum = 100.0, Description = "SkinnedMeshRenderer.SetBlendShapeWeight")]
		public float weight;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => mesh);
			f.KeyValue(() => index);
			f.KeyValue(() => weight);
		}
	}
}
