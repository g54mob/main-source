using UnityEngine;

namespace Utils
{
	public static class MathUtils
	{
		public static int RoundToInt(float value, bool roundHalfwayUp)
		{
			float num = (float)Mathf.RoundToInt(value * 1000f) / 1000f;
			if (!roundHalfwayUp)
			{
				return Mathf.CeilToInt(num - 0.5f);
			}
			return Mathf.FloorToInt(num + 0.5f);
		}

		public static float EaseInOutCubic(float time)
		{
			if (!(time < 0.5f))
			{
				return 1f - Mathf.Pow(-2f * time + 2f, 3f) / 2f;
			}
			return 4f * time * time * time;
		}
	}
}
