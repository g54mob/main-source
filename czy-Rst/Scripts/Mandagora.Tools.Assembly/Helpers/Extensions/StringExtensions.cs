namespace Helpers.Extensions
{
	public static class StringExtensions
	{
		public static bool IsEmpty(this string text)
		{
			return string.IsNullOrEmpty(text);
		}
	}
}
