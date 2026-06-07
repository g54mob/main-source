using TMPro;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
	[SerializeField]
	private TMP_Dropdown dropdown;

	public MicPickerDropdown micPicker;

	public KeybindsManager keybindsManager;

	private void Awake()
	{
		if (PlayerPrefs.HasKey("Language"))
		{
			string savedLang = PlayerPrefs.GetString("Language");
			int num = dropdown.options.FindIndex((TMP_Dropdown.OptionData o) => o.text == savedLang);
			if (num >= 0)
			{
				dropdown.value = num;
			}
		}
		else
		{
			PlayerPrefs.SetString("Language", "ENGLISH");
		}
		dropdown.onValueChanged.AddListener(OnLanguageChanged);
		OnLanguageChanged(dropdown.value);
	}

	private void OnLanguageChanged(int index)
	{
		string text = "";
		text = index switch
		{
			0 => "ENGLISH", 
			1 => "FRENCH", 
			2 => "RUSSIAN", 
			3 => "GERMAN", 
			4 => "SPANISH", 
			5 => "JAPANESE", 
			6 => "SIMPLIFIED CHINESE", 
			7 => "TRADITIONAL CHINESE", 
			8 => "BR PORTUGESE", 
			_ => "ENGLISH", 
		};
		PlayerPrefs.SetInt("CurLanguageInt", index);
		PlayerPrefs.SetString("Language", text);
		PlayerPrefs.Save();
		LanguageText[] array = Object.FindObjectsOfType<LanguageText>(includeInactive: true);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Start();
		}
		if ((bool)micPicker)
		{
			micPicker.UpdateAllLanguageChanges();
		}
		if ((bool)keybindsManager)
		{
			keybindsManager.UpdateAllLanguageChanges();
		}
	}
}
