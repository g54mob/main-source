using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LocalizationController : MonoBehaviour
{
	public static LocalizationController Instance;

	private List<string> labels;

	[SerializeField]
	private Languages selectedLanguage;

	private int selectedLanguageIndex;

	[SerializeField]
	private TextMeshProUGUI selectedLanguageLabel;

	[SerializeField]
	private GameObject achievementsPanelMask;

	[SerializeField]
	private GameObject controlsPanelMask;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		selectedLanguageIndex = (PlayerPrefs.HasKey("languageIndex") ? PlayerPrefs.GetInt("languageIndex") : 0);
		UpdateLanguageIndex();
	}

	private void OnEnable()
	{
		string text = Resources.Load<TextAsset>("LanguageLabels").text;
		labels = text.Split("\n"[0]).ToList();
	}

	public string GetLabelTranslation(string label)
	{
		try
		{
			return labels.Find((string x) => x.Split(","[0])[0] == label).Split(",")[GetSelectedLanguageIndex() + 1].Replace(";", ",").Replace("\"", "");
		}
		catch
		{
			return "this translation has not been implemented yet";
		}
	}

	public Languages GetSelectedLanguage()
	{
		return selectedLanguage;
	}

	private int GetSelectedLanguageIndex()
	{
		return selectedLanguageIndex;
	}

	public void ChangeLanguageIndex(bool add)
	{
		selectedLanguageIndex += (add ? 1 : (-1));
		if (selectedLanguageIndex < 0)
		{
			selectedLanguageIndex = Enum.GetValues(typeof(Languages)).Length - 2;
		}
		if (selectedLanguageIndex >= Enum.GetValues(typeof(Languages)).Length - 1)
		{
			selectedLanguageIndex = 0;
		}
		if (selectedLanguageIndex == Enum.GetValues(typeof(Languages)).Length - 2)
		{
			achievementsPanelMask.gameObject.SetActive(value: false);
			controlsPanelMask.gameObject.SetActive(value: false);
			achievementsPanelMask.gameObject.SetActive(value: true);
			controlsPanelMask.gameObject.SetActive(value: true);
		}
		PlayerPrefs.SetInt("languageIndex", selectedLanguageIndex);
		UpdateLanguageIndex();
	}

	private void UpdateLanguageIndex()
	{
		_ = (Languages[])Enum.GetValues(typeof(Languages));
		UpdateAllLocalizationLabels();
	}

	private void UpdateAllLocalizationLabels()
	{
		TextLabelController[] array = UnityEngine.Object.FindObjectsOfType<TextLabelController>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetText();
		}
	}

	private void UpdateLanguageLabel(string language)
	{
		selectedLanguageLabel.text = char.ToUpper(language[0]) + language.Substring(1).ToLower();
	}
}
