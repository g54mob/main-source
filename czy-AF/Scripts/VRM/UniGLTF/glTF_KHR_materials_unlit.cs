using System;

namespace UniGLTF
{
	[Serializable]
	public class glTF_KHR_materials_unlit : JsonSerializableBase
	{
		public static string ExtensionName => "KHR_materials_unlit";

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
		}

		public static glTFMaterial CreateDefault()
		{
			glTFMaterial glTFMaterial2 = new glTFMaterial();
			glTFMaterial2.pbrMetallicRoughness = new glTFPbrMetallicRoughness
			{
				baseColorFactor = new float[4] { 1f, 1f, 1f, 1f },
				roughnessFactor = 0.9f,
				metallicFactor = 0f
			};
			glTFMaterial2.extensions = new glTFMaterial_extensions
			{
				KHR_materials_unlit = new glTF_KHR_materials_unlit()
			};
			return glTFMaterial2;
		}
	}
}
