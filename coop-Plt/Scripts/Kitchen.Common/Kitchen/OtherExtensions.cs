using UnityEngine;

namespace Kitchen
{
	public static class OtherExtensions
	{
		public static string ToShortString(this Resolution r)
		{
			return $"{r.width} x {r.height}";
		}

		public static int ProbabilisticRound(this float f)
		{
			int num = (int)f;
			float num2 = f % 1f;
			if (Random.value < num2)
			{
				num++;
			}
			return num;
		}
	}
}
