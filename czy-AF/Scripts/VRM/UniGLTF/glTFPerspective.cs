using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFPerspective
	{
		[JsonSchema(Minimum = 0.0, ExclusiveMinimum = true)]
		public float aspectRatio;

		[JsonSchema(Required = true, Minimum = 0.0, ExclusiveMinimum = true)]
		public float yfov;

		[JsonSchema(Minimum = 0.0, ExclusiveMinimum = true)]
		public float zfar;

		[JsonSchema(Required = true, Minimum = 0.0, ExclusiveMinimum = true)]
		public float znear;

		public glTFPerspective_extensions extensions;

		public glTFPerspective_extras extras;
	}
}
