using System;
using System.Collections.Generic;

public class LanguagesManager
{
	private static readonly LanguagesManager instance = new LanguagesManager();

	public const string LanguageId = "language.id";

	public const string LanguageName = "language.name";

	private List<Properties> languages;

	private List<KeyValuePair<string, string>> languagesConfig;

	private Properties currentLanguage;

	public static LanguagesManager Instance => instance;

	public event Action OnLanguageChangedEvent;

	private LanguagesManager()
	{
		languages = new List<Properties>();
		languagesConfig = new List<KeyValuePair<string, string>>();
	}

	public bool AddLanguage(Properties language)
	{
		if (!language.HasProperty("language.id"))
		{
			return false;
		}
		languages.Add(language);
		languagesConfig.Add(new KeyValuePair<string, string>(language.GetProperty("language.id"), language.GetProperty("language.name")));
		return true;
	}

	public bool SetCurrentLanguage(string languageName, bool shouldNotify = true)
	{
		Properties properties = languages.Find((Properties language) => language.GetProperty("language.id") == languageName);
		if (properties == null)
		{
			return false;
		}
		currentLanguage = properties;
		if (this.OnLanguageChangedEvent != null && shouldNotify)
		{
			this.OnLanguageChangedEvent();
		}
		return true;
	}

	public bool HasText(string id)
	{
		if (currentLanguage == null)
		{
			return false;
		}
		return currentLanguage.HasProperty(id);
	}

	public string GetText(string id, string defaultValue = "")
	{
		if (currentLanguage == null)
		{
			return "";
		}
		if (string.IsNullOrEmpty(defaultValue))
		{
			return currentLanguage.GetProperty(id, id);
		}
		return currentLanguage.GetProperty(id, defaultValue);
	}

	public IEnumerable<KeyValuePair<string, string>> GetLanguagesConfig()
	{
		return languagesConfig;
	}
}
