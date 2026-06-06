using Cysharp.Text;

public static class NumericFormatExtensions
{
	public static string Format(this NumericFormat format, int number)
	{
		return ZString.Format(format.Value(), number);
	}

	public static string Format(this NumericFormat format, float number)
	{
		return ZString.Format(format.Value(), number);
	}

	public static string Format(this NumericFormat format, double number)
	{
		return ZString.Format(format.Value(), number);
	}
}
