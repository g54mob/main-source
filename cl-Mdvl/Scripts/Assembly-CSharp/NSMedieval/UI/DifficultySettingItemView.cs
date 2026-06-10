using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.GameEventSystem;
using NSMedieval.UI.Utils;
using NSMedieval.Weather;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class DifficultySettingItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text label;

		[SerializeField]
		private GameObject sliderContainer;

		[SerializeField]
		private CustomSlider slider;

		[SerializeField]
		private TMP_Text sliderValue;

		[SerializeField]
		private CustomToggle toggle;

		[SerializeField]
		private TMP_Dropdown dropdown;

		private string settingId;

		private UIElementType uiElementType;

		public Image Background => GetComponent<Image>();

		public void SetData(DifficultyOption difficultyOption, float value, UnityAction<string, float> onValueChangedCallback)
		{
			settingId = difficultyOption.GetID();
			if (difficultyOption.LocKeys == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\DifficultySettingItemView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(settingId);
					messageBuilder.AppendLiteral(" does not contain any loc keys");
				}
				Log.Error(messageBuilder);
			}
			label.SetText(LocKeyUtils.GetName(difficultyOption.LocKeys).ToLocalized());
			uiElementType = difficultyOption.UIElementType;
			switch (uiElementType)
			{
			case UIElementType.Slider:
				SetupSlider(difficultyOption, onValueChangedCallback);
				slider.SetValueWithoutNotify(value);
				SetSliderValueText(value);
				break;
			case UIElementType.Toggle:
				SetupToggle(onValueChangedCallback);
				toggle.isOn = value > 0.5f;
				break;
			case UIElementType.Dropdown:
				SetupDropdown(difficultyOption, onValueChangedCallback);
				dropdown.SetValueWithoutNotify(Mathf.RoundToInt(value));
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if ((object)base.TooltipNew == null)
			{
				return;
			}
			base.TooltipNew.ClearLines();
			base.TooltipNew.AppendLine(LocKeyUtils.GetName(difficultyOption.LocKeys).ToLocalized(), TooltipStyles.TooltipTitle);
			base.TooltipNew.AppendLine(LocKeyUtils.GetDescription(difficultyOption.LocKeys).ToLocalized(), TooltipStyles.TooltipDescriptionLine);
			if (!(difficultyOption.GetID() == "raidStrengthMultiplier"))
			{
				return;
			}
			foreach (DaysFromStartMultipliers allItem in Repository<DaysFromStartMultipliersRepository, DaysFromStartMultipliers>.Instance.GetAllItems())
			{
				base.TooltipNew.AppendLine(LocKeyUtils.GetName(allItem.LocKeys).ToLocalized(), TooltipStyles.TooltipDefault);
				base.TooltipNew.AppendLine(LocKeyUtils.GetDescription(allItem.LocKeys).ToLocalized(), TooltipStyles.TooltipDescriptionLine);
			}
		}

		private void SetupSlider(DifficultyOption difficultyOption, UnityAction<string, float> onValueChangedCallback)
		{
			sliderContainer.SetActive(value: true);
			toggle.gameObject.SetActive(value: false);
			dropdown.gameObject.SetActive(value: false);
			slider.minValue = difficultyOption.ValueRange.Min;
			slider.maxValue = difficultyOption.ValueRange.Max;
			slider.wholeNumbers = difficultyOption.WholeNumbers;
			slider.onValueChanged.RemoveAllListeners();
			slider.onValueChanged.AddListener(delegate(float value)
			{
				onValueChangedCallback(settingId, value);
				SetSliderValueText(value);
			});
		}

		private void SetupToggle(UnityAction<string, float> onValueChangedCallback)
		{
			toggle.gameObject.SetActive(value: true);
			sliderContainer.SetActive(value: false);
			dropdown.gameObject.SetActive(value: false);
			toggle.onValueChanged.RemoveAllListeners();
			toggle.onValueChanged.AddListener(delegate(bool isOn)
			{
				float arg = (isOn ? 1f : 0f);
				onValueChangedCallback(settingId, arg);
			});
		}

		private void SetupDropdown(DifficultyOption difficultyOption, UnityAction<string, float> onValueChangedCallback)
		{
			dropdown.gameObject.SetActive(value: true);
			toggle.gameObject.SetActive(value: false);
			sliderContainer.SetActive(value: false);
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (DaysFromStartMultipliers allItem in Repository<DaysFromStartMultipliersRepository, DaysFromStartMultipliers>.Instance.GetAllItems())
			{
				list.Add(new TMP_Dropdown.OptionData(LocKeyUtils.GetName(allItem.LocKeys).ToLocalized()));
			}
			dropdown.options = list;
			dropdown.onValueChanged.RemoveAllListeners();
			dropdown.onValueChanged.AddListener(delegate(int i)
			{
				onValueChangedCallback(settingId, i);
			});
		}

		private void SetSliderValueText(float value)
		{
			string sourceText = (slider.wholeNumbers ? $"{value}" : $"{value:P0}");
			sliderValue.SetText(sourceText);
		}
	}
}
