namespace MiscUtil.Collections.Extensions
{
	public static class RangeBasedExt
	{
		public static Range<T> To<T>(this T start, T end)
		{
			return new Range<T>(start, end);
		}

		public static RangeIterator<char> StepChar(this Range<char> range, int step)
		{
			return range.Step((char c) => (char)(c + step));
		}
	}
}
