using System.Globalization;
using System.Text.RegularExpressions;

namespace Humanizer
{
	internal class ToTitleCase : ICulturedStringTransformer, IStringTransformer
	{
		public string Transform(string input)
		{
			return null;
		}

		public string Transform(string input, CultureInfo culture)
		{
			return null;
		}

		private static bool AllCapitals(string input)
		{
			return false;
		}

		private static string ReplaceWithTitleCase(Match word, string source, CultureInfo culture, bool firstWord)
		{
			return null;
		}
	}
}
