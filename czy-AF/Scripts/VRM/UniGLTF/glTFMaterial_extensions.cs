using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFMaterial_extensions : ExtensionsBase<glTFMaterial_extensions>
	{
		[JsonSchema(Required = true)]
		public glTF_KHR_materials_unlit KHR_materials_unlit;

		[JsonSerializeMembers]
		private void SerializeMembers_unlit(GLTFJsonFormatter f)
		{
			if (KHR_materials_unlit != null)
			{
				f.Key("KHR_materials_unlit");
				f.GLTFValue(KHR_materials_unlit);
			}
		}
	}
}
