using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public abstract class glTFTextureInfo : JsonSerializableBase, IglTFTextureinfo
	{
		[JsonSchema(Required = true, Minimum = 0.0)]
		public int index = -1;

		[JsonSchema(Minimum = 0.0)]
		public int texCoord;

		public glTFTextureInfo_extensions extensions;

		public object extras;

		public abstract glTFTextureTypes TextureType { get; }

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => index);
			f.KeyValue(() => texCoord);
			if (extensions != null)
			{
				f.KeyValue(() => extensions);
			}
		}
	}
}
