using System;

namespace CTS
{
	public struct Currency
	{
		private bool isNegative;

		private byte point;

		private ulong value;

		public override string ToString()
		{
			return (isNegative ? "-" : "") + value.ToString("N") + "." + point.ToString("D2");
		}

		public static Currency Set(float p_default)
		{
			Currency result = new Currency
			{
				isNegative = (p_default < 0f),
				value = (ulong)Math.Truncate(p_default)
			};
			result.point = (byte)Math.Truncate((p_default - (float)result.value) * 100f);
			return result;
		}

		public static Currency Set(int p_default)
		{
			return new Currency
			{
				isNegative = (p_default < 0),
				value = (ulong)Math.Abs(p_default),
				point = 0
			};
		}
	}
}
