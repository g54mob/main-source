using System;
using Dorfromantik.UI.Components;
using TMPro;
using UnityEngine;

namespace Dorfromantik
{
	public class CustomRuleSlider : MonoBehaviour
	{
		[SerializeField]
		public CustomRuleType customRuleType;

		[SerializeField]
		private bool turnTransparentIfZero = true;

		[SerializeField]
		private bool turnTransparentIfMinimum;

		[SerializeField]
		private string localizationKey;

		[SerializeField]
		private TextMeshProUGUI typeLabel;

		[SerializeField]
		private UiSlider probabilitySlider;

		[SerializeField]
		private CustomModeConfiguration configuration;

		private CustomModeConfigScreen customModeConfigScreen;

		private int currentValue;

		public event Action<CustomRuleType, int> OnValueChanged;

		private void Awake()
		{
			customModeConfigScreen = GetComponentInParent<CustomModeConfigScreen>();
			if (probabilitySlider == null)
			{
				probabilitySlider = GetComponentInChildren<UiSlider>();
			}
			probabilitySlider.onValueChanged.AddListener(ValueChanged);
			customModeConfigScreen.OnRuleUpdated += UpdateSlider;
		}

		private void Start()
		{
			LocalizationManager.Instance.OnLanguageChanged += UpdateUi;
			currentValue = Mathf.RoundToInt(probabilitySlider.value);
			UpdateUi();
		}

		private void UpdateSlider(CustomRuleType modifiedRule, int newLevel)
		{
			if (modifiedRule == customRuleType)
			{
				currentValue = newLevel;
				probabilitySlider.SetValueWithoutNotify(newLevel);
				UpdateUi();
			}
		}

		private void ValueChanged(float sliderValue)
		{
			currentValue = Mathf.RoundToInt(sliderValue);
			this.OnValueChanged?.Invoke(customRuleType, currentValue);
			UpdateUi();
		}

		private void UpdateUi()
		{
			if (turnTransparentIfZero)
			{
				typeLabel.color = ((configuration.GetProbabilityByLevel(customRuleType, currentValue) == 0f) ? Constants.UI.Colors.HoverWhite : Color.white);
			}
			else if (turnTransparentIfMinimum)
			{
				typeLabel.color = ((currentValue == 1) ? Constants.UI.Colors.HoverWhite : Color.white);
			}
			string text = "<size=70%>";
			if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text = "";
			}
			string input = LocalizationManager.Instance.GetLocalizedValue(localizationKey, useFallbackText: true) + " " + text + configuration.GetDisplayValue(customRuleType, currentValue);
			input = StringUtility.FirstCharToUpper(input);
			LocalizationManager.Instance.UpdateTextMesh(typeLabel, LocalizedFontStyle.Bold, input);
		}

		private void OnDestroy()
		{
			customModeConfigScreen.OnRuleUpdated -= UpdateSlider;
			if ((bool)LocalizationManager.Instance)
			{
				LocalizationManager.Instance.OnLanguageChanged -= UpdateUi;
			}
		}

		public void Randomize()
		{
			probabilitySlider.value = UnityEngine.Random.Range(probabilitySlider.minValue, probabilitySlider.maxValue + 1f);
		}

		public void Reset()
		{
			probabilitySlider.value = configuration.GetDefaultLevel(customRuleType);
		}
	}
}
