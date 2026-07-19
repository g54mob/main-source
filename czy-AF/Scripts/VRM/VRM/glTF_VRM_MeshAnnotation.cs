using System;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.firstperson.meshannotation")]
	public class glTF_VRM_MeshAnnotation : JsonSerializableBase
	{
		[JsonSchema(Minimum = 0.0)]
		public int mesh;

		public string firstPersonFlag;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => mesh);
			f.KeyValue(() => firstPersonFlag);
		}
	}
}
