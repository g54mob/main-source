using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFTextureInfo_extensions : ExtensionsBase<glTFTextureInfo_extensions>
	{
		[JsonSchema(Required = true)]
		public glTF_KHR_texture_transform KHR_texture_transform;

		[JsonSerializeMembers]
		private void SerializeMembers_textureInfo(GLTFJsonFormatter f)
		{
			if (KHR_texture_transform != null)
			{
				f.KeyValue(() => KHR_texture_transform);
			}
		}
	}
}
