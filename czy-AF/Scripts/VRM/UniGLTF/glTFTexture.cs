using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFTexture : JsonSerializableBase
	{
		[JsonSchema(Minimum = 0.0)]
		public int sampler;

		[JsonSchema(Minimum = 0.0)]
		public int source;

		public object extensions;

		public object extras;

		public string name;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => sampler);
			f.KeyValue(() => source);
		}
	}
}
