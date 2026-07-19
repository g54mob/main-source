using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFMaterialNormalTextureInfo : glTFTextureInfo
	{
		public float scale = 1f;

		public override glTFTextureTypes TextureType => glTFTextureTypes.Normal;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => scale);
			base.SerializeMembers(f);
		}
	}
}
