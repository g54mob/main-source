using Platforms;

namespace KitchenData
{
	public static class LocaleExtensions
	{
		public static string NameKey(this Locale locale)
		{
			return locale switch
			{
				Locale.Default => PlatformSettings.SupportsLanguageSelection ? "SETTINGS_LOCALE_SYSTEM" : "SETTINGS_LOCALE_ENGLISH", 
				Locale.English => "SETTINGS_LOCALE_ENGLISH", 
				Locale.BlankText => "SETTINGS_LOCALE_ENGLISH", 
				Locale.French => "SETTINGS_LOCALE_FRENCH", 
				Locale.German => "SETTINGS_LOCALE_GERMAN", 
				Locale.Spanish => "SETTINGS_LOCALE_SPANISH", 
				Locale.Polish => "SETTINGS_LOCALE_POLISH", 
				Locale.Russian => "SETTINGS_LOCALE_RUSSIAN", 
				Locale.PortugueseBrazil => "SETTINGS_LOCALE_PORTBR", 
				Locale.Japanese => "SETTINGS_LOCALE_JAPANESE", 
				Locale.ChineseSimplified => "SETTINGS_LOCALE_SIMPCHINESE", 
				Locale.ChineseTraditional => "SETTINGS_LOCALE_TRADCHINESE", 
				Locale.Korean => "SETTINGS_LOCALE_KOREAN", 
				Locale.Turkish => "SETTINGS_LOCALE_TURKISH", 
				_ => "SETTINGS_LOCALE_ENGLISH", 
			};
		}
	}
}
