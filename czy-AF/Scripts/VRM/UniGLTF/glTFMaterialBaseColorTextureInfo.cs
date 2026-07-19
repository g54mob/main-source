using System;

namespace UniGLTF
{
	[Serializable]
	public class glTFMaterialBaseColorTextureInfo : glTFTextureInfo
	{
		public override glTFTextureTypes TextureType => glTFTextureTypes.BaseColor;
	}
}
