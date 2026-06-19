using UnityEngine;

namespace Tayx.Graphy.Utils
{
	public static class IntString
	{
		public static string[] positiveBuffer = new string[0];

		public static string[] negativeBuffer = new string[0];

		public static float maxValue => positiveBuffer.Length;

		public static float minValue => negativeBuffer.Length;

		public static bool Inited
		{
			get
			{
				if (positiveBuffer.Length == 0)
				{
					return negativeBuffer.Length != 0;
				}
				return true;
			}
		}

		public static void Init(int minNegativeValue, int maxPositiveValue)
		{
			if (maxPositiveValue >= 0)
			{
				positiveBuffer = new string[maxPositiveValue];
				for (int i = 0; i < maxPositiveValue; i++)
				{
					positiveBuffer[i] = i.ToString();
				}
			}
			if (minNegativeValue <= 0)
			{
				int num = Mathf.Abs(minNegativeValue);
				negativeBuffer = new string[num];
				for (int j = 0; j < num; j++)
				{
					negativeBuffer[j] = (-j).ToString();
				}
			}
		}

		public static string ToStringNonAlloc(this int value)
		{
			if (value >= 0 && value < positiveBuffer.Length)
			{
				return positiveBuffer[value];
			}
			if (value < 0 && -value < negativeBuffer.Length)
			{
				return negativeBuffer[-value];
			}
			return value.ToString();
		}
	}
}
