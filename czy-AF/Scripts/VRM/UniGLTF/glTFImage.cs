using System;
using System.IO;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFImage : JsonSerializableBase
	{
		public string name;

		public string uri;

		[JsonSchema(Dependencies = new string[] { "mimeType" }, Minimum = 0.0)]
		public int bufferView;

		[JsonSchema(EnumValues = new object[] { "image/jpeg", "image/png" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string mimeType;

		public object extensions;

		public object extras;

		public string GetExt()
		{
			string text = mimeType;
			if (!(text == "image/png"))
			{
				if (text == "image/jpeg")
				{
					return ".jpg";
				}
				if (uri.StartsWith("data:image/jpeg;"))
				{
					return ".jpg";
				}
				if (uri.StartsWith("data:image/png;"))
				{
					return ".png";
				}
				return Path.GetExtension(uri).ToLower();
			}
			return ".png";
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => name);
			if (!string.IsNullOrEmpty(uri))
			{
				f.KeyValue(() => uri);
				return;
			}
			f.KeyValue(() => bufferView);
			f.KeyValue(() => mimeType);
		}
	}
}
