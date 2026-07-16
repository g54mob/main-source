using System.Collections.Generic;
using System.Linq;
using MLCN_Localization;
using UnityEngine;
using UnityEngine.Events;

public class LocaleStringListEvent : MonoBehaviour
{
	[SerializeField]
	private string[] keys;

	[SerializeField]
	private LocalizationDataTable.Tables table;

	[SerializeField]
	private UnityEvent<List<string>> OnUpdateLocaleString;

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

	private void UpdateString(int language)
	{
		List<string> localizedList = LocalizationManager.GetLocalizedList(keys.ToList(), table);
		OnUpdateLocaleString.Invoke(localizedList);
	}
}
