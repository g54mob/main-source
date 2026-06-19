using UnityEngine;

namespace Tayx.Graphy.Utils
{
	public static class FloatString
	{
		private static float decimalMultiplayer = 1f;

		public static string[] positiveBuffer = new string[0];

		public static string[] negativeBuffer = new string[0];

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

		public static float maxValue => (positiveBuffer.Length - 1).FromIndex();

		public static float minValue => 0f - (negativeBuffer.Length - 1).FromIndex();

		public static void Init(float minNegativeValue, float maxPositiveValue, int deciminals = 1)
		{
			decimalMultiplayer = Pow(10, Mathf.Clamp(deciminals, 1, 5));
			int num = minNegativeValue.ToIndex();
			int num2 = maxPositiveValue.ToIndex();
			if (num2 >= 0)
			{
				positiveBuffer = new string[num2];
				for (int i = 0; i < num2; i++)
				{
					positiveBuffer[i] = i.FromIndex().ToString("0.0");
				}
			}
			if (num >= 0)
			{
				negativeBuffer = new string[num];
				for (int j = 0; j < num; j++)
				{
					negativeBuffer[j] = (-j).FromIndex().ToString("0.0");
				}
			}
		}

		public static string ToStringNonAlloc(this float value)
		{
			int num = value.ToIndex();
			if (value >= 0f && num < positiveBuffer.Length)
			{
				return positiveBuffer[num];
			}
			if (value < 0f && num < negativeBuffer.Length)
			{
				return negativeBuffer[num];
			}
			return value.ToString();
		}

		public static string ToStringNonAlloc(this float value, string format)
		{
			int num = value.ToIndex();
			if (value >= 0f && num < positiveBuffer.Length)
			{
				return positiveBuffer[num];
			}
			if (value < 0f && num < negativeBuffer.Length)
			{
				return negativeBuffer[num];
			}
			return value.ToString(format);
		}

		private static int Pow(int f, int p)
		{
			for (int i = 1; i < p; i++)
			{
				f *= f;
			}
			return f;
		}

		private static int ToIndex(this float f)
		{
			return Mathf.Abs((f * decimalMultiplayer).ToInt());
		}

		private static float FromIndex(this int i)
		{
			return i.ToFloat() / decimalMultiplayer;
		}

		public static int ToInt(this float f)
		{
			return (int)f;
		}

		public static float ToFloat(this int i)
		{
			return i;
		}
	}
}
