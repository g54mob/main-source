namespace Helpers.Extensions
{
	public static class OtherExtensions
	{
		public static bool IsDefault<T>(this T value) where T : struct
		{
			return value.Equals(default(T));
		}
	}
}
