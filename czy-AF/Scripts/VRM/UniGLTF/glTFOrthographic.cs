using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFOrthographic
	{
		[JsonSchema(Required = true)]
		public float xmag;

		[JsonSchema(Required = true)]
		public float ymag;

		[JsonSchema(Required = true, Minimum = 0.0, ExclusiveMinimum = true)]
		public float zfar;

		[JsonSchema(Required = true, Minimum = 0.0)]
		public float znear;

		[JsonSchema(MinProperties = 1)]
		public glTFOrthographic_extensions extensions;

		[JsonSchema(MinProperties = 1)]
		public glTFOrthographic_extras extras;
	}
}
