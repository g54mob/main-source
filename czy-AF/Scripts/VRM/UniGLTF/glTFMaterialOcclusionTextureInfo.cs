using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFMaterialOcclusionTextureInfo : glTFTextureInfo
	{
		[JsonSchema(Minimum = 0.0, Maximum = 1.0)]
		public float strength = 1f;

		public override glTFTextureTypes TextureType => glTFTextureTypes.Occlusion;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => strength);
			base.SerializeMembers(f);
		}
	}
}
