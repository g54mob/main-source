using UnityEngine;

namespace RLD
{
	public static class MathEx
	{
		public static bool AlmostEqual(float v1, float v2, float epsilon)
		{
			return Mathf.Abs(v1 - v2) < epsilon;
		}

		public static int GetNumDigits(int number)
		{
			if (number != 0)
			{
				return Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(number)) + 1f);
			}
			return 1;
		}

		public static float SafeAcos(float cosine)
		{
			cosine = Mathf.Max(-1f, Mathf.Min(1f, cosine));
			return Mathf.Acos(cosine);
		}

		public static bool SolveQuadratic(float a, float b, float c, out float t1, out float t2)
		{
			t1 = (t2 = 0f);
			float num = b * b - 4f * a * c;
			if (num < 0f)
			{
				return false;
			}
			float num2 = 2f * a;
			if (num2 == 0f)
			{
				return false;
			}
			if (num == 0f)
			{
				t1 = (t2 = (0f - b) / num2);
				return true;
			}
			float num3 = Mathf.Sqrt(num);
			t1 = (0f - b + num3) / num2;
			t2 = (0f - b - num3) / num2;
			if (t1 > t2)
			{
				float num4 = t1;
				t1 = t2;
				t2 = num4;
			}
			return true;
		}
	}
}
