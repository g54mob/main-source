using System;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.blendshape.materialbind")]
	public class glTF_VRM_MaterialValueBind : JsonSerializableBase
	{
		public string materialName;

		public string propertyName;

		public float[] targetValue;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => materialName);
			f.KeyValue(() => propertyName);
			f.KeyValue(() => targetValue);
		}
	}
}
