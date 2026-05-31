using TMPro;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
	[SerializeField]
	private TMP_Dropdown dropdown;

	public void ChangeLanguageTo(int languageIndex)
	{
		if (languageIndex == 0)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.EN);
		}
		if (languageIndex == 1)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.FR);
		}
		if (languageIndex == 2)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.IT);
		}
		if (languageIndex == 3)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.DE);
		}
		if (languageIndex == 4)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.ES);
		}
		if (languageIndex == 5)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.PTBR);
		}
		if (languageIndex == 6)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.JA);
		}
		if (languageIndex == 7)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.KO);
		}
		if (languageIndex == 8)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.SCH);
		}
		if (languageIndex == 9)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.TCH);
		}
		if (languageIndex == 10)
		{
			SaveData.ins.SetLanguageTo(LocalizationSystem.Language.EE);
		}
		SaveData.ins.overrideSteamLanguage = true;
	}

	public void SetDropdownTo(LocalizationSystem.Language language)
	{
		if (language == LocalizationSystem.Language.EN)
		{
			dropdown.value = 0;
		}
		if (language == LocalizationSystem.Language.FR)
		{
			dropdown.value = 1;
		}
		if (language == LocalizationSystem.Language.IT)
		{
			dropdown.value = 2;
		}
		if (language == LocalizationSystem.Language.DE)
		{
			dropdown.value = 3;
		}
		if (language == LocalizationSystem.Language.ES)
		{
			dropdown.value = 4;
		}
		if (language == LocalizationSystem.Language.PTBR)
		{
			dropdown.value = 5;
		}
		if (language == LocalizationSystem.Language.JA)
		{
			dropdown.value = 6;
		}
		if (language == LocalizationSystem.Language.KO)
		{
			dropdown.value = 7;
		}
		if (language == LocalizationSystem.Language.SCH)
		{
			dropdown.value = 8;
		}
		if (language == LocalizationSystem.Language.TCH)
		{
			dropdown.value = 9;
		}
		if (language == LocalizationSystem.Language.EE)
		{
			dropdown.value = 10;
		}
	}
}
