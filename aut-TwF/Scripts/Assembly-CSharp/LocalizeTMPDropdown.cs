using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[RequireComponent(typeof(TMP_Dropdown))]
public class LocalizeTMPDropdown : MonoBehaviour
{
	[SerializeField]
	private List<LocalizedString> localizedOptions;

	private TMP_Dropdown dropdown;

	private void Awake()
	{
		dropdown = GetComponent<TMP_Dropdown>();
	}

	private void Start()
	{
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
		UpdateDropdownOptions();
	}

	private void OnDestroy()
	{
		LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
	}

	private void OnLocaleChanged(Locale locale)
	{
		UpdateDropdownOptions();
	}

	private void UpdateDropdownOptions()
	{
		dropdown.options.Clear();
		foreach (LocalizedString localizedOption in localizedOptions)
		{
			dropdown.options.Add(new TMP_Dropdown.OptionData(localizedOption.GetLocalizedString()));
		}
		dropdown.RefreshShownValue();
	}
}
