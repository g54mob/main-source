using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTF_KHR_texture_transform : JsonSerializableBase
	{
		[JsonSchema(MinItems = 2, MaxItems = 2)]
		public float[] offset = new float[2];

		public float rotation;

		[JsonSchema(MinItems = 2, MaxItems = 2)]
		public float[] scale = new float[2] { 1f, 1f };

		[ItemJsonSchema(Minimum = 0.0)]
		public int texCoord;

		public static string ExtensionName => "KHR_texture_transform";

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => offset);
			f.KeyValue(() => rotation);
			f.KeyValue(() => scale);
			f.KeyValue(() => texCoord);
		}
	}
}
