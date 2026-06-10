using System;
using System.Globalization;

namespace ModIOBrowser.Implementation
{
	internal static class TranslatedLanguagesExtensions
	{
		public static CultureInfo Culture(this TranslatedLanguages language)
		{
			return null;
		}

		public static string Date(this TranslatedLanguages language, DateTime date)
		{
			return null;
		}

		public static string DateShort(this TranslatedLanguages language, DateTime date)
		{
			return null;
		}

		public static string Number<T>(this TranslatedLanguages language, T number) where T : IFormattable
		{
			return null;
		}
	}
}
