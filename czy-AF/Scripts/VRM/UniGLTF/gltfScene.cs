using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class gltfScene : JsonSerializableBase
	{
		[JsonSchema(MinItems = 1)]
		[ItemJsonSchema(Minimum = 0.0)]
		public int[] nodes;

		public object extensions;

		public object extras;

		public string name;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => nodes);
		}
	}
}
