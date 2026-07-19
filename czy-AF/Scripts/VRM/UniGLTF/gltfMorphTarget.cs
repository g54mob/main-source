using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class gltfMorphTarget : JsonSerializableBase
	{
		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int POSITION = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int NORMAL = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int TANGENT = -1;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => POSITION);
			if (NORMAL >= 0)
			{
				f.KeyValue(() => NORMAL);
			}
			if (TANGENT >= 0)
			{
				f.KeyValue(() => TANGENT);
			}
		}
	}
}
