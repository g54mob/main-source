using System.Collections.Generic;

namespace UniGLTF
{
	public static class AnimationExporter
	{
		public class InputOutputValues
		{
			public float[] Input;

			public float[] Output;
		}

		public class AnimationWithSampleCurves
		{
			public glTFAnimation Animation;

			public Dictionary<int, InputOutputValues> SamplerMap = new Dictionary<int, InputOutputValues>();
		}
	}
}
