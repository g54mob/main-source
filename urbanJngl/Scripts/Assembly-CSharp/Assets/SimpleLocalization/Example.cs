using System;
using Infrastructure.Services.LocalizationService;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization
{
	public class Example : MonoBehaviour
	{
		public Text FormattedText;

		public void Awake()
		{
			LocalizationManager.Read();
			switch (Application.systemLanguage)
			{
			case SystemLanguage.German:
				LocalizationManager.Language = "German";
				break;
			case SystemLanguage.Russian:
				LocalizationManager.Language = "Russian";
				break;
			default:
				LocalizationManager.Language = "English";
				break;
			}
			FormattedText.text = LocalizationManager.Localize("Settings.Example.PlayTime", TimeSpan.FromHours(10.5).TotalHours);
			LocalizationManager.OnLocalizationChanged += delegate
			{
				FormattedText.text = LocalizationManager.Localize("Settings.Example.PlayTime", TimeSpan.FromHours(10.5).TotalHours);
			};
		}

		public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
		}

		public void Review()
		{
			Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/120113");
		}
	}
}
