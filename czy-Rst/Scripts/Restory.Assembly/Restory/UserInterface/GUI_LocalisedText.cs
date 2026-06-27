using System.Collections.Generic;
using Restory.Data.Localization;
using Restory.Gameplay.GameSettings.Observers;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_LocalisedText : SerializedMonoBehaviour
	{
		private static class Style
		{
			public const string TextComponentsGroup = "Text Components";
		}

		[Header("General settings")]
		[SerializeField]
		private Text targetText;

		[SerializeField]
		private TMP_Text textMeshProText;

		[SerializeField]
		[LocalizationKey]
		private string localisationID = string.Empty;

		[SerializeField]
		private bool isEnabled = true;

		[SerializeField]
		private bool forceUppercase;

		[OdinSerialize]
		private Dictionary<string, string> formatSubstrings = new Dictionary<string, string>();

		private LocalizationSystem localizationSystem;

		private GameSettingsLanguageChangeObserver gameSettingsManager;

		private Color defaultColor;

		public bool IsEnabled
		{
			get
			{
				return isEnabled;
			}
			set
			{
				isEnabled = value;
			}
		}

		public string LocalizationID
		{
			get
			{
				return localisationID;
			}
			set
			{
				localisationID = value;
				Refresh();
			}
		}

		private void Awake()
		{
			if (targetText == null)
			{
				TryGetComponent<Text>(out targetText);
			}
			if (formatSubstrings == null)
			{
				formatSubstrings = new Dictionary<string, string>();
			}
			if (textMeshProText != null)
			{
				defaultColor = textMeshProText.color;
			}
			else if (targetText != null)
			{
				defaultColor = targetText.color;
			}
		}

		[Inject]
		private void Construct(LocalizationSystem localizationSystem, GameSettingsLanguageChangeObserver gameSettingsManager)
		{
			this.localizationSystem = localizationSystem;
			this.gameSettingsManager = gameSettingsManager;
			if (base.isActiveAndEnabled)
			{
				gameSettingsManager.AddSubscriber(this, OnLocalisationChanged);
				TryUpdateText();
			}
		}

		private void OnEnable()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.AddSubscriber(this, OnLocalisationChanged);
			}
			TryUpdateText();
		}

		private void OnDisable()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.RemoveSubscriber(this);
			}
		}

		public void Refresh()
		{
			if (gameSettingsManager != null)
			{
				OnLocalisationChanged(gameSettingsManager.Localization);
			}
		}

		public void SetFormattedValue(string key, string newValue)
		{
			formatSubstrings[key] = newValue;
			Refresh();
		}

		public void SetTextColor(Color color)
		{
			if (textMeshProText != null)
			{
				textMeshProText.color = color;
			}
			else if (targetText != null)
			{
				targetText.color = color;
			}
		}

		public void SetDefaultColor()
		{
			SetTextColor(defaultColor);
		}

		private void OnLocalisationChanged(SystemLanguage newLanguage)
		{
			TryUpdateText();
		}

		private bool TryUpdateText()
		{
			if (!isEnabled)
			{
				return false;
			}
			UpdateText();
			return true;
		}

		private void UpdateText()
		{
			if (!(localizationSystem == null))
			{
				string text = localizationSystem.GetTranslation(localisationID);
				if (forceUppercase)
				{
					text = text.ToUpper();
				}
				SetDefaultText(text);
				SetTMProText(text);
			}
		}

		private void SetDefaultText(string value)
		{
			if (!(targetText == null))
			{
				targetText.text = FormatString(value);
			}
		}

		private void SetTMProText(string value)
		{
			if (!(textMeshProText == null))
			{
				textMeshProText.text = FormatString(value);
			}
		}

		private string FormatString(string targetString)
		{
			if (string.IsNullOrEmpty(targetString))
			{
				return string.Empty;
			}
			foreach (KeyValuePair<string, string> formatSubstring in formatSubstrings)
			{
				string key = formatSubstring.Key;
				string value = formatSubstring.Value;
				targetString = targetString.Replace(key, value);
			}
			return targetString;
		}
	}
}
