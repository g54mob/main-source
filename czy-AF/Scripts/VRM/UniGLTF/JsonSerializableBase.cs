using System;

namespace UniGLTF
{
	[Serializable]
	public abstract class JsonSerializableBase
	{
		protected abstract void SerializeMembers(GLTFJsonFormatter f);

		public string ToJson()
		{
			GLTFJsonFormatter gLTFJsonFormatter = new GLTFJsonFormatter();
			gLTFJsonFormatter.BeginMap();
			SerializeMembers(gLTFJsonFormatter);
			gLTFJsonFormatter.EndMap();
			return gLTFJsonFormatter.ToString();
		}
	}
}
