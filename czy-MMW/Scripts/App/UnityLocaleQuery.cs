using UnityEngine;

public class UnityLocaleQuery
{
	public static LocaleDatabase.LocaleId GetLocaleId(LocaleDatabase localeDatabase)
	{
		LocaleDatabase.LocaleId localeId = GetLocaleId(Application.systemLanguage);
		if (localeDatabase.IsLocaleSelectable(localeId))
		{
			return localeId;
		}
		return LocaleDatabase.LocaleId.en_US;
	}

	public static LocaleDatabase.LocaleId GetLocaleId(SystemLanguage systemLanguage)
	{
		LocaleDatabase.LocaleId result = LocaleDatabase.LocaleId.Unknown;
		switch (systemLanguage)
		{
		case SystemLanguage.Arabic:
			result = LocaleDatabase.LocaleId.ar;
			break;
		case SystemLanguage.Chinese:
		case SystemLanguage.ChineseSimplified:
			result = LocaleDatabase.LocaleId.zh_CN;
			break;
		case SystemLanguage.ChineseTraditional:
			result = LocaleDatabase.LocaleId.zh_TW;
			break;
		case SystemLanguage.Czech:
			result = LocaleDatabase.LocaleId.cs;
			break;
		case SystemLanguage.Danish:
			result = LocaleDatabase.LocaleId.da;
			break;
		case SystemLanguage.Dutch:
			result = LocaleDatabase.LocaleId.nl;
			break;
		case SystemLanguage.English:
			result = LocaleDatabase.LocaleId.en_US;
			break;
		case SystemLanguage.Finnish:
			result = LocaleDatabase.LocaleId.fi;
			break;
		case SystemLanguage.French:
			result = LocaleDatabase.LocaleId.fr;
			break;
		case SystemLanguage.German:
			result = LocaleDatabase.LocaleId.de;
			break;
		case SystemLanguage.Italian:
			result = LocaleDatabase.LocaleId.it;
			break;
		case SystemLanguage.Japanese:
			result = LocaleDatabase.LocaleId.ja;
			break;
		case SystemLanguage.Korean:
			result = LocaleDatabase.LocaleId.ko;
			break;
		case SystemLanguage.Norwegian:
			result = LocaleDatabase.LocaleId.no;
			break;
		case SystemLanguage.Polish:
			result = LocaleDatabase.LocaleId.pl;
			break;
		case SystemLanguage.Portuguese:
			result = LocaleDatabase.LocaleId.pt_BR;
			break;
		case SystemLanguage.Russian:
			result = LocaleDatabase.LocaleId.ru;
			break;
		case SystemLanguage.Spanish:
			result = LocaleDatabase.LocaleId.es_ES;
			break;
		case SystemLanguage.Swedish:
			result = LocaleDatabase.LocaleId.sv_SE;
			break;
		case SystemLanguage.Thai:
			result = LocaleDatabase.LocaleId.th;
			break;
		case SystemLanguage.Turkish:
			result = LocaleDatabase.LocaleId.tr;
			break;
		case SystemLanguage.Ukrainian:
			result = LocaleDatabase.LocaleId.uk;
			break;
		}
		return result;
	}
}
