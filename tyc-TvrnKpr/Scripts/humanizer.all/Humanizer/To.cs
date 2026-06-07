using System.Globalization;

namespace Humanizer
{
	public static class To
	{
		public static ICulturedStringTransformer TitleCase => null;

		public static ICulturedStringTransformer LowerCase => null;

		public static ICulturedStringTransformer UpperCase => null;

		public static ICulturedStringTransformer SentenceCase => null;

		public static string Transform(this string input, params IStringTransformer[] transformers)
		{
			return null;
		}

		public static string Transform(this string input, CultureInfo culture, params ICulturedStringTransformer[] transformers)
		{
			return null;
		}
	}
}
