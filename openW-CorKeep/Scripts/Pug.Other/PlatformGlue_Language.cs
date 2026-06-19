using UnityEngine;

public static class PlatformGlue_Language
{
	public static string ToRRSLangCode(this SystemLanguage language)
	{
		return language switch
		{
			SystemLanguage.English => "en", 
			SystemLanguage.Swedish => "sv", 
			SystemLanguage.French => "fr", 
			SystemLanguage.German => "de", 
			SystemLanguage.Japanese => "ja", 
			SystemLanguage.Chinese => "zh-cn", 
			SystemLanguage.ChineseSimplified => "zh-cn", 
			SystemLanguage.ChineseTraditional => "zh-tw", 
			SystemLanguage.Spanish => "es", 
			SystemLanguage.Russian => "ru", 
			SystemLanguage.Italian => "it", 
			SystemLanguage.Dutch => "nl", 
			SystemLanguage.Portuguese => "pt-br", 
			SystemLanguage.Korean => "ko", 
			SystemLanguage.Arabic => "ar", 
			SystemLanguage.Polish => "pl", 
			SystemLanguage.Turkish => "tr", 
			SystemLanguage.Ukrainian => "uk", 
			SystemLanguage.Czech => "cz", 
			SystemLanguage.Thai => "th", 
			_ => null, 
		};
	}

	public static string GetSystemPreferredLanguage()
	{
		return Manager.platform.language;
	}
}
