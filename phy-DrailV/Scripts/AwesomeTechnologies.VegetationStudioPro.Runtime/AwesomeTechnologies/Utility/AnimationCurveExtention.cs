using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public static class AnimationCurveExtention
	{
		public static float[] GenerateCurveArray(this AnimationCurve self, int sampleCount)
		{
			float[] array = new float[sampleCount];
			for (int i = 0; i <= sampleCount - 1; i++)
			{
				array[i] = self.Evaluate((float)i / (float)sampleCount);
			}
			return array;
		}
	}
}
