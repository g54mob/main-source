public static class CustomExtensions
{
	public static string ToNumber(this int num)
	{
		return num.ToString("N0");
	}
}
