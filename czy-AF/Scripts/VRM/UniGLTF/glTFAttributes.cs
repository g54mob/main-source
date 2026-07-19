using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFAttributes : JsonSerializableBase
	{
		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int POSITION = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int NORMAL = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int TANGENT = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int TEXCOORD_0 = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int COLOR_0 = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int JOINTS_0 = -1;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int WEIGHTS_0 = -1;

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is glTFAttributes glTFAttributes2))
			{
				return base.Equals(obj);
			}
			if (POSITION == glTFAttributes2.POSITION && NORMAL == glTFAttributes2.NORMAL && TANGENT == glTFAttributes2.TANGENT && TEXCOORD_0 == glTFAttributes2.TEXCOORD_0 && COLOR_0 == glTFAttributes2.COLOR_0 && JOINTS_0 == glTFAttributes2.JOINTS_0)
			{
				return WEIGHTS_0 == glTFAttributes2.WEIGHTS_0;
			}
			return false;
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => POSITION);
			if (NORMAL != -1)
			{
				f.KeyValue(() => NORMAL);
			}
			if (TANGENT != -1)
			{
				f.KeyValue(() => TANGENT);
			}
			if (TEXCOORD_0 != -1)
			{
				f.KeyValue(() => TEXCOORD_0);
			}
			if (COLOR_0 != -1)
			{
				f.KeyValue(() => COLOR_0);
			}
			if (JOINTS_0 != -1)
			{
				f.KeyValue(() => JOINTS_0);
			}
			if (WEIGHTS_0 != -1)
			{
				f.KeyValue(() => WEIGHTS_0);
			}
		}
	}
}
