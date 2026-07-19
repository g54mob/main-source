using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFSparseIndices : JsonSerializableBase
	{
		[JsonSchema(Required = true, Minimum = 0.0)]
		public int bufferView = -1;

		[JsonSchema(Minimum = 0.0)]
		public int byteOffset;

		[JsonSchema(Required = true, EnumValues = new object[] { 5121, 5123, 5125 })]
		public glComponentType componentType;

		public object extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => bufferView);
			f.KeyValue(() => byteOffset);
			f.Key("componentType");
			f.Value((int)componentType);
		}
	}
}
