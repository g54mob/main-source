namespace FluentAssertions.Common
{
	internal static class IntegerExtensions
	{
		public static string Times(this int count)
		{
			if (count != 1)
			{
				return $"{count} times";
			}
			return "1 time";
		}

		internal static bool IsConsecutiveTo(this int startNumber, int endNumber)
		{
			return endNumber == startNumber + 1;
		}
	}
}
