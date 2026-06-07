namespace BCnEncoder.Shared
{
	internal static class IntHelper
	{
		public static int SignExtend(int orig, int precision)
		{
			int num = 1 << precision - 1;
			int num2 = num - 1;
			if ((orig & num) != 0)
			{
				return ~num2 | (orig & num2);
			}
			return orig & num2;
		}
	}
}
