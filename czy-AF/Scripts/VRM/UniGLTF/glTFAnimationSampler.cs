using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFAnimationSampler : JsonSerializableBase
	{
		[JsonSchema(Required = true, Minimum = 0.0)]
		public int input = -1;

		[JsonSchema(EnumValues = new object[] { "LINEAR", "STEP", "CUBICSPLINE" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string interpolation;

		[JsonSchema(Required = true, Minimum = 0.0)]
		public int output = -1;

		public object extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => input);
			if (!string.IsNullOrEmpty(interpolation))
			{
				f.KeyValue(() => interpolation);
			}
			f.KeyValue(() => output);
		}
	}
}
