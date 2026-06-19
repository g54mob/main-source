using System;
using System.Globalization;

namespace ModIOBrowser.Implementation
{
	internal static class TranslatedLanguagesExtensions
	{
		public static CultureInfo Culture(this TranslatedLanguages language)
		{
			return language switch
			{
				TranslatedLanguages.English => CultureInfo.GetCultureInfo("en-US"), 
				TranslatedLanguages.Swedish => CultureInfo.GetCultureInfo("sv-SE"), 
				TranslatedLanguages.Chinese => CultureInfo.GetCultureInfo("zh-CN"), 
				TranslatedLanguages.Korean => CultureInfo.GetCultureInfo("ko-KR"), 
				TranslatedLanguages.German => CultureInfo.GetCultureInfo("de-DE"), 
				TranslatedLanguages.Japanese => CultureInfo.GetCultureInfo("ja-JP"), 
				TranslatedLanguages.Spanish => CultureInfo.GetCultureInfo("es-ES"), 
				TranslatedLanguages.Thai => CultureInfo.GetCultureInfo("th-TH"), 
				TranslatedLanguages.French => CultureInfo.GetCultureInfo("fr-FR"), 
				TranslatedLanguages.BrazilianPortuguese => CultureInfo.GetCultureInfo("pt-BR"), 
				TranslatedLanguages.Italian => CultureInfo.GetCultureInfo("it-IT"), 
				TranslatedLanguages.ChineseTraditional => CultureInfo.GetCultureInfo("zh-TW"), 
				TranslatedLanguages.Ukrainian => CultureInfo.GetCultureInfo("uk"), 
				TranslatedLanguages.Russian => CultureInfo.GetCultureInfo("ru"), 
				_ => CultureInfo.GetCultureInfo("en-US"), 
			};
		}

		public static string Date(this TranslatedLanguages language, DateTime date)
		{
			return date.ToString(language.Culture());
		}

		public static string DateShort(this TranslatedLanguages language, DateTime date)
		{
			return date.ToString(language.Culture().DateTimeFormat.ShortDatePattern);
		}

		public static string Number<T>(this TranslatedLanguages language, T number) where T : IFormattable
		{
			return number.ToString("n", language.Culture());
		}
	}
}
