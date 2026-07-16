using MLCN_Localization;
using UnityEngine;
using UnityEngine.Events;

public class LocaleStringEvent : MonoBehaviour
{
	[SerializeField]
	private string key;

	[SerializeField]
	private LocalizationDataTable.Tables table;

	[SerializeField]
	private UnityEvent<string> OnUpdateLocaleString;

	private void Awake()
	{
		LocalizationManager.OnLanguageChange.AddListener(delegate(int language)
		{
			UpdateString(language);
		});
		if (!LocalizationManager.IsValidated())
		{
			LocalizationManager.OnInitComplete.AddListener(delegate(int language)
			{
				UpdateString(language);
			});
		}
		else
		{
			UpdateString(LocalizationManager.GetCurrentLanguage());
		}
	}

	private void OnEnable()
	{
		if (LocalizationManager.IsValidated())
		{
			UpdateString(LocalizationManager.GetCurrentLanguage());
		}
	}

	public string GetCurrentKey()
	{
		return key;
	}

	public void SetNewTable(LocalizationDataTable.Tables newTable)
	{
		table = newTable;
	}

	public void SetNewKey(string key)
	{
		this.key = key;
	}

	public void TryUpdate()
	{
		if (LocalizationManager.IsValidated())
		{
			int currentLanguage = LocalizationManager.GetCurrentLanguage();
			UpdateString(currentLanguage);
		}
	}

	private void UpdateString(int language)
	{
		string localizedString = LocalizationManager.GetLocalizedString(key, table, language);
		OnUpdateLocaleString.Invoke(localizedString);
	}
}
