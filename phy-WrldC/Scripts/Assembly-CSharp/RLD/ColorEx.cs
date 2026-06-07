using UnityEngine;

namespace RLD
{
	public static class ColorEx
	{
		public static Color FromByteValues(byte r, byte g, byte b, byte a)
		{
			float num = 0.003921569f;
			return new Color((float)(int)r * num, (float)(int)g * num, (float)(int)b * num, (float)(int)a * num);
		}

		public static Color[] GetFilledColorArray(int arrayLength, Color fillValue)
		{
			Color[] array = new Color[arrayLength];
			for (int i = 0; i < arrayLength; i++)
			{
				array[i] = fillValue;
			}
			return array;
		}

		public static Color KeepAllButAlpha(this Color color, float newAlpha)
		{
			return new Color(color.r, color.g, color.b, newAlpha);
		}
	}
}
