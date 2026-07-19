using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFMaterial : JsonSerializableBase
	{
		public string name;

		public glTFPbrMetallicRoughness pbrMetallicRoughness = new glTFPbrMetallicRoughness
		{
			baseColorFactor = new float[4] { 1f, 1f, 1f, 1f }
		};

		public glTFMaterialNormalTextureInfo normalTexture;

		public glTFMaterialOcclusionTextureInfo occlusionTexture;

		public glTFMaterialEmissiveTextureInfo emissiveTexture;

		[JsonSchema(MinItems = 3, MaxItems = 3)]
		[ItemJsonSchema(Minimum = 0.0, Maximum = 1.0)]
		public float[] emissiveFactor;

		[JsonSchema(EnumValues = new object[] { "OPAQUE", "MASK", "BLEND" }, EnumSerializationType = EnumSerializationType.AsUpperString)]
		public string alphaMode;

		[JsonSchema(Dependencies = new string[] { "alphaMode" }, Minimum = 0.0)]
		public float alphaCutoff = 0.5f;

		public bool doubleSided;

		[JsonSchema(SkipSchemaComparison = true)]
		public glTFMaterial_extensions extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			if (!string.IsNullOrEmpty(name))
			{
				f.Key("name");
				f.Value(name);
			}
			if (pbrMetallicRoughness != null)
			{
				f.Key("pbrMetallicRoughness");
				f.GLTFValue(pbrMetallicRoughness);
			}
			if (normalTexture != null)
			{
				f.Key("normalTexture");
				f.GLTFValue(normalTexture);
			}
			if (occlusionTexture != null)
			{
				f.Key("occlusionTexture");
				f.GLTFValue(occlusionTexture);
			}
			if (emissiveTexture != null)
			{
				f.Key("emissiveTexture");
				f.GLTFValue(emissiveTexture);
			}
			if (emissiveFactor != null)
			{
				f.Key("emissiveFactor");
				f.Serialize(emissiveFactor);
			}
			f.KeyValue(() => doubleSided);
			if (!string.IsNullOrEmpty(alphaMode))
			{
				f.KeyValue(() => alphaMode);
			}
			if (extensions != null)
			{
				f.Key("extensions");
				f.GLTFValue(extensions);
			}
		}

		public glTFTextureInfo[] GetTextures()
		{
			return new glTFTextureInfo[5]
			{
				(pbrMetallicRoughness != null) ? pbrMetallicRoughness.baseColorTexture : null,
				(pbrMetallicRoughness != null) ? pbrMetallicRoughness.metallicRoughnessTexture : null,
				normalTexture,
				occlusionTexture,
				emissiveTexture
			};
		}
	}
}
