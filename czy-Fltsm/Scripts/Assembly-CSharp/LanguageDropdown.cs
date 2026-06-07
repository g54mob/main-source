using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Debugs;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class LanguageDropdown : MonoBehaviour
{
	[Tooltip("Dropdown component for the language selection.")]
	[SerializeField]
	private TMP_Dropdown _languageDropdown;

	private List<string> _languages = new List<string>();

	private void Start()
	{
		_languageDropdown = GetComponentInChildren<TMP_Dropdown>();
		_languages = LocalizationManager.GetAllLanguages();
		_languageDropdown.ClearOptions();
		_languageDropdown.AddOptions(_languages);
		_languageDropdown.value = Settings.Instance.GameplayPlayerData.SelectedLanguageIndex;
	}

	public void SetLanguage(int languageIndex)
	{
		if (languageIndex != Settings.Instance.GameplayPlayerData.SelectedLanguageIndex)
		{
			LocalizationManager.CurrentLanguage = _languages[languageIndex];
			Settings.Instance.GameplayPlayerData.SelectedLanguageIndex = languageIndex;
			Debugger.Log($"Set language to {_languages[languageIndex]}");
			Settings.Instance.Save();
		}
	}
}
