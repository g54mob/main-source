namespace FluentAssertions.Execution
{
	internal static class StringExtensions
	{
		public static WithoutFormattingWrapper AsNonFormattable(this string value)
		{
			return new WithoutFormattingWrapper(value);
		}

		public static WithoutFormattingWrapper AsNonFormattable(this object value)
		{
			return new WithoutFormattingWrapper(value?.ToString());
		}
	}
}
