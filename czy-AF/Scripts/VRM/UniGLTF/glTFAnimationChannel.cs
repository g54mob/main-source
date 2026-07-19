using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFAnimationChannel : JsonSerializableBase
	{
		[JsonSchema(Required = true, Minimum = 0.0)]
		public int sampler = -1;

		[JsonSchema(Required = true)]
		public glTFAnimationTarget target;

		public object extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => sampler);
			f.Key("target");
			f.GLTFValue(target);
		}
	}
}
