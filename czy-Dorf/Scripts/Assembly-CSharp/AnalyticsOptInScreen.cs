using System.Collections.Generic;
using Dorfromantik;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Serialization;

public class AnalyticsOptInScreen : MainMenuScreen
{
	[FormerlySerializedAs("analyticsOptInText")]
	[SerializeField]
	private TextMeshProUGUI analyticsOptInLabel;

	[SerializeField]
	private Material highlightMaterial;

	[SerializeField]
	private TMP_Dropdown languageDropdown;

	private void Start()
	{
		if (PlayerPrefsAccessor.GetInt("AnalyticsOptInShown", 0) == 1)
		{
			if (PlayerPrefsAccessor.GetInt("AnalyticsEnabled", 1) == 0)
			{
				OptOutOfDataCollection();
			}
			else
			{
				OptIntoDataCollection();
			}
		}
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		foreach (Language availableLanguage in LocalizationManager.Instance.AvailableLanguages)
		{
			string text = (LocalizationManager.LanguageNameByLanguage.ContainsKey(availableLanguage) ? LocalizationManager.LanguageNameByLanguage[availableLanguage] : availableLanguage.ToString());
			list.Add(new TMP_Dropdown.OptionData(text));
		}
		languageDropdown.options = list;
		LocalizationManager.Instance.OnLanguageChanged += UpdateText;
		UpdateText();
	}

	private void UpdateText()
	{
		languageDropdown.SetValueWithoutNotify(LocalizationManager.Instance.AvailableLanguages.IndexOf(LocalizationManager.Instance.Language));
		string text = "<color=#" + ColorUtility.ToHtmlStringRGBA(highlightMaterial.color) + "><font=\"" + LocalizationManager.Instance.GetFont(LocalizedFontStyle.ExtraBold).name + "\">";
		string text2 = "</color></font>";
		string text3 = LocalizationManager.Instance.GetLocalizedValue("menu_analytics_optIn");
		if (string.IsNullOrWhiteSpace(text3))
		{
			text3 = analyticsOptInLabel.text;
		}
		string text4 = text + "<link=\"unity_privacy_policy\">";
		string text5 = "</link>" + text2;
		string text6 = text + "<link=\"toukana_privacy_policy\">";
		string text7 = "</link>" + text2;
		if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
		{
			text4 = StringUtility.Reverse(text4);
			text5 = StringUtility.Reverse(text5);
			string input = text6;
			text6 = StringUtility.Reverse(text7);
			text7 = StringUtility.Reverse(input);
		}
		text3 = text3.Replace("[LINK]", text4);
		text3 = text3.Replace("[/LINK]", text5);
		text3 = text3.Replace("[TOUKANA.COM]", text6 + "toukana.com" + text7);
		LocalizationManager.Instance.UpdateTextMesh(analyticsOptInLabel, LocalizedFontStyle.SemiBold, text3, HorizontalAlignmentOptions.Left);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void InitStepOne()
	{
		Analytics.initializeOnStartup = false;
	}

	public void OptIntoDataCollection()
	{
		Debug.Log("Opt Into Analytics");
		PlayerPrefsAccessor.SetInt("AnalyticsOptInShown", 1);
		PlayerPrefsAccessor.SetInt("AnalyticsEnabled", 1);
		Analytics.ResumeInitialization();
		Analytics.enabled = true;
		Analytics.deviceStatsEnabled = true;
		PerformanceReporting.enabled = true;
	}

	public void OptOutOfDataCollection()
	{
		Debug.Log("Opt Out of Analytics");
		PlayerPrefsAccessor.SetInt("AnalyticsOptInShown", 1);
		PlayerPrefsAccessor.SetInt("AnalyticsEnabled", 0);
		Analytics.enabled = false;
		Analytics.deviceStatsEnabled = false;
		PerformanceReporting.enabled = false;
	}
}
