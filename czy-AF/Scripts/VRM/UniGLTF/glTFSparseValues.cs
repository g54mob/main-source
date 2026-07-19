using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFSparseValues : JsonSerializableBase
	{
		[JsonSchema(Required = true, Minimum = 0.0)]
		public int bufferView = -1;

		[JsonSchema(Minimum = 0.0)]
		public int byteOffset;

		public object extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => bufferView);
			f.KeyValue(() => byteOffset);
		}
	}
}
