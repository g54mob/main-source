using System;

namespace UniGLTF
{
	[Serializable]
	public class glTFMaterialEmissiveTextureInfo : glTFTextureInfo
	{
		public override glTFTextureTypes TextureType => glTFTextureTypes.Emissive;
	}
}
