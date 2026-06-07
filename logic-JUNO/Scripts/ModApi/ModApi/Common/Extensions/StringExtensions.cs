namespace ModApi.Common.Extensions
{
	public static class StringExtensions
	{
		public static string Replace(this string value, string oldValue)
		{
			return value.Replace(oldValue, string.Empty);
		}
	}
}
