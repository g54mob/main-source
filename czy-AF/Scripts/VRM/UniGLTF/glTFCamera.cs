using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFCamera
	{
		public glTFOrthographic orthographic;

		public glTFPerspective perspective;

		[JsonSchema(Required = true, EnumSerializationType = EnumSerializationType.AsLowerString)]
		public ProjectionType type;

		public string name;

		public glTFCamera_extensions extensions;

		public glTFCamera_extras extras;
	}
}
