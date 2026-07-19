using System;

namespace UniGLTF
{
	[Serializable]
	public class glTFMaterialMetallicRoughnessTextureInfo : glTFTextureInfo
	{
		public override glTFTextureTypes TextureType => glTFTextureTypes.Metallic;
	}
}
