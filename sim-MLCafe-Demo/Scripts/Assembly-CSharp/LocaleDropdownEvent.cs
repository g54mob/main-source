using System.Collections.Generic;
using System.Linq;
using MLCN_Localization;
using TMPro;
using UnityEngine;

public class LocaleDropdownEvent : MonoBehaviour
{
	[SerializeField]
	private string[] keys;

	[SerializeField]
	private LocalizationDataTable.Tables table;

	[SerializeField]
	private TMP_Dropdown dropdown;

	private void Awake()
	{
		LocalizationManager.OnLanguageChange.AddListener(delegate
		{
			UpdateDropdown();
		});
		if (!LocalizationManager.IsValidated())
		{
			LocalizationManager.OnInitComplete.AddListener(delegate
			{
				UpdateDropdown();
			});
		}
		else
		{
			UpdateDropdown();
		}
	}

	private void OnEnable()
	{
		if (LocalizationManager.IsValidated())
		{
			UpdateDropdown();
		}
	}

	private void UpdateDropdown()
	{
		List<string> localizedList = LocalizationManager.GetLocalizedList(keys.ToList(), table);
		dropdown.ClearOptions();
		dropdown.AddOptions(localizedList);
	}
}
