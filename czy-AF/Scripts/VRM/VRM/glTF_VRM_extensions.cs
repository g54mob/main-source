using System;
using System.Collections.Generic;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm", Description = "\r\nVRM extension is for 3d humanoid avatars (and models) in VR applications.\r\n")]
	public class glTF_VRM_extensions : JsonSerializableBase
	{
		[JsonSchema(Description = "Version of exporter that vrm created. UniVRM-0.58.1")]
		public string exporterVersion = "UniVRM-0.58.1";

		[JsonSchema(Description = "Version of VRM specification. 0.0")]
		public string specVersion = VRMSpecVersion.Version;

		public glTF_VRM_Meta meta = new glTF_VRM_Meta();

		public glTF_VRM_Humanoid humanoid = new glTF_VRM_Humanoid();

		public glTF_VRM_Firstperson firstPerson = new glTF_VRM_Firstperson();

		public glTF_VRM_BlendShapeMaster blendShapeMaster = new glTF_VRM_BlendShapeMaster();

		public glTF_VRM_SecondaryAnimation secondaryAnimation = new glTF_VRM_SecondaryAnimation();

		public List<glTF_VRM_Material> materialProperties = new List<glTF_VRM_Material>();

		public static string ExtensionName => "VRM";

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => exporterVersion);
			f.KeyValue(() => specVersion);
			f.Key("meta");
			f.GLTFValue(meta);
			f.Key("humanoid");
			f.GLTFValue(humanoid);
			f.Key("firstPerson");
			f.GLTFValue(firstPerson);
			f.Key("blendShapeMaster");
			f.GLTFValue(blendShapeMaster);
			f.Key("secondaryAnimation");
			f.GLTFValue(secondaryAnimation);
			f.Key("materialProperties");
			f.GLTFValue(materialProperties);
		}
	}
}
