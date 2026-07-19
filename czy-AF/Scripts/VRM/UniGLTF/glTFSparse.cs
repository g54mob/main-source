using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFSparse : JsonSerializableBase
	{
		[JsonSchema(Required = true, Minimum = 1.0)]
		public int count;

		[JsonSchema(Required = true)]
		public glTFSparseIndices indices;

		[JsonSchema(Required = true)]
		public glTFSparseValues values;

		public object extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => count);
			f.Key("indices");
			f.GLTFValue(indices);
			f.Key("values");
			f.GLTFValue(values);
		}
	}
}
