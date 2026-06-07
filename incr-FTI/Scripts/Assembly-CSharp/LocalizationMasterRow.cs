using System;
using UnityEngine;

[Serializable]
public class LocalizationMasterRow
{
	public string Key;

	public string en;

	public string es;

	public string fr;

	public string it;

	public string tr;

	public string zhCN;

	public string zhTW;

	public string ru;

	public string pt;

	public string ptBR;

	public string nl;

	public string sv;

	public string de;

	public string ja;

	public string uk;

	public string cz;

	public string GetValue(UserLanguage userLanguage)
	{
		string text = null;
		switch (userLanguage)
		{
		case UserLanguage.Spanish:
			text = es;
			break;
		case UserLanguage.SimplifiedChinese:
			text = zhCN;
			break;
		case UserLanguage.TraditionalChinese:
			text = zhTW;
			break;
		case UserLanguage.DefaultEnglish:
			text = en;
			break;
		case UserLanguage.French:
			text = fr;
			break;
		case UserLanguage.Italian:
			text = it;
			break;
		case UserLanguage.Turkish:
			text = tr;
			break;
		case UserLanguage.PortugueseEuropean:
			text = pt;
			break;
		case UserLanguage.PortugueseBrazilian:
			text = ptBR;
			break;
		case UserLanguage.Russian:
			text = ru;
			break;
		case UserLanguage.Japanese:
			text = ja;
			break;
		case UserLanguage.Czech:
			text = cz;
			break;
		case UserLanguage.Ukrainian:
			text = uk;
			break;
		case UserLanguage.Dutch:
			text = nl;
			break;
		case UserLanguage.Swedish:
			text = sv;
			break;
		case UserLanguage.German:
			text = de;
			break;
		default:
			Debug.LogWarning("! DID NOT SPECIFY LANGUAGE PREFIX FOR USER LANGUAGE " + userLanguage);
			text = en;
			break;
		}
		if (text == null)
		{
			text = "[X]" + en;
		}
		return text;
	}
}
