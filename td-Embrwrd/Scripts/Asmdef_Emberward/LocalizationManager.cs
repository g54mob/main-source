using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public class LocalizationManager : MonoBehaviour
{
	public static LocalizationManager Instance;

	private LocalizationSettings localizationSettings;

	[SerializeField]
	private LocalizedStringTable _localizedStringTable;

	private StringTable _currentStringTable;

	private SystemLanguage currentLanguage;

	[SerializeField]
	private LocalizedTmpFont localizedFont;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public string GetStringWithOriginalType(string tableName, string key, params object[] arg)
	{
		return null;
	}

	public string GetString(string tableName, string key, params object[] arg)
	{
		return null;
	}

	public bool HasString(string tableName, string key)
	{
		return false;
	}

	public void SetLanguage(SystemLanguage language)
	{
	}

	public SystemLanguage GetCurrentLanguage()
	{
		return default(SystemLanguage);
	}
}
