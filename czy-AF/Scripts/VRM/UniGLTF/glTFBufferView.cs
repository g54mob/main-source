using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFBufferView : JsonSerializableBase
	{
		[JsonSchema(Required = true, Minimum = 0.0)]
		public int buffer;

		[JsonSchema(Minimum = 0.0)]
		public int byteOffset;

		[JsonSchema(Required = true, Minimum = 1.0)]
		public int byteLength;

		[JsonSchema(Minimum = 4.0, Maximum = 252.0, MultipleOf = 4.0)]
		public int byteStride;

		[JsonSchema(EnumSerializationType = EnumSerializationType.AsInt, EnumExcludes = new object[] { glBufferTarget.NONE })]
		public glBufferTarget target;

		public object extensions;

		public object extras;

		public string name;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => buffer);
			f.KeyValue(() => byteOffset);
			f.KeyValue(() => byteLength);
			if (target != glBufferTarget.NONE)
			{
				f.Key("target");
				f.Value((int)target);
			}
		}
	}
}
