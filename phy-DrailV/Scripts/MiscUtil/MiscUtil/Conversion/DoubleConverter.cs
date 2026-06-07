using System;
using System.Globalization;

namespace MiscUtil.Conversion
{
	public class DoubleConverter
	{
		private class ArbitraryDecimal
		{
			private byte[] digits;

			private int decimalPoint;

			internal ArbitraryDecimal(long x)
			{
				string text = x.ToString(CultureInfo.InvariantCulture);
				digits = new byte[text.Length];
				for (int i = 0; i < text.Length; i++)
				{
					digits[i] = (byte)(text[i] - 48);
				}
				Normalize();
			}

			internal void MultiplyBy(int amount)
			{
				byte[] array = new byte[digits.Length + 1];
				for (int num = digits.Length - 1; num >= 0; num--)
				{
					int num2 = digits[num] * amount + array[num + 1];
					array[num] = (byte)(num2 / 10);
					array[num + 1] = (byte)(num2 % 10);
				}
				if (array[0] != 0)
				{
					digits = array;
				}
				else
				{
					Array.Copy(array, 1, digits, 0, digits.Length);
				}
				Normalize();
			}

			internal void Shift(int amount)
			{
				decimalPoint += amount;
			}

			internal void Normalize()
			{
				int i;
				for (i = 0; i < digits.Length && digits[i] == 0; i++)
				{
				}
				int num = digits.Length - 1;
				while (num >= 0 && digits[num] == 0)
				{
					num--;
				}
				if (i != 0 || num != digits.Length - 1)
				{
					byte[] array = new byte[num - i + 1];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = digits[j + i];
					}
					decimalPoint -= digits.Length - (num + 1);
					digits = array;
				}
			}

			public override string ToString()
			{
				char[] array = new char[digits.Length];
				for (int i = 0; i < digits.Length; i++)
				{
					array[i] = (char)(digits[i] + 48);
				}
				if (decimalPoint == 0)
				{
					return new string(array);
				}
				if (decimalPoint < 0)
				{
					return new string(array) + new string('0', -decimalPoint);
				}
				if (decimalPoint >= array.Length)
				{
					return "0." + new string('0', decimalPoint - array.Length) + new string(array);
				}
				return new string(array, 0, array.Length - decimalPoint) + "." + new string(array, array.Length - decimalPoint, decimalPoint);
			}
		}

		public static string ToExactString(double d)
		{
			if (double.IsPositiveInfinity(d))
			{
				return "+Infinity";
			}
			if (double.IsNegativeInfinity(d))
			{
				return "-Infinity";
			}
			if (double.IsNaN(d))
			{
				return "NaN";
			}
			long num = BitConverter.DoubleToInt64Bits(d);
			bool flag = num < 0;
			int num2 = (int)((num >> 52) & 0x7FF);
			long num3 = num & 0xFFFFFFFFFFFFFL;
			if (num2 == 0)
			{
				num2++;
			}
			else
			{
				num3 |= 0x10000000000000L;
			}
			num2 -= 1075;
			if (num3 == 0)
			{
				return "0";
			}
			while ((num3 & 1) == 0)
			{
				num3 >>= 1;
				num2++;
			}
			ArbitraryDecimal arbitraryDecimal = new ArbitraryDecimal(num3);
			if (num2 < 0)
			{
				for (int i = 0; i < -num2; i++)
				{
					arbitraryDecimal.MultiplyBy(5);
				}
				arbitraryDecimal.Shift(-num2);
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					arbitraryDecimal.MultiplyBy(2);
				}
			}
			if (flag)
			{
				return "-" + arbitraryDecimal.ToString();
			}
			return arbitraryDecimal.ToString();
		}
	}
}
