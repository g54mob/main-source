using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFPbrMetallicRoughness : JsonSerializableBase
	{
		public glTFMaterialBaseColorTextureInfo baseColorTexture;

		[JsonSchema(MinItems = 4, MaxItems = 4)]
		[ItemJsonSchema(Minimum = 0.0, Maximum = 1.0)]
		public float[] baseColorFactor;

		public glTFMaterialMetallicRoughnessTextureInfo metallicRoughnessTexture;

		[JsonSchema(Minimum = 0.0, Maximum = 1.0)]
		public float metallicFactor = 1f;

		[JsonSchema(Minimum = 0.0, Maximum = 1.0)]
		public float roughnessFactor = 1f;

		public object extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			if (baseColorTexture != null)
			{
				f.Key("baseColorTexture");
				f.GLTFValue(baseColorTexture);
			}
			if (baseColorFactor != null)
			{
				f.KeyValue(() => baseColorFactor);
			}
			if (metallicRoughnessTexture != null)
			{
				f.Key("metallicRoughnessTexture");
				f.GLTFValue(metallicRoughnessTexture);
			}
			f.KeyValue(() => metallicFactor);
			f.KeyValue(() => roughnessFactor);
		}
	}
}
