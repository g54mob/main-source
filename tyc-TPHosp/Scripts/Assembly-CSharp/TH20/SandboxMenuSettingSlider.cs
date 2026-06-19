using System;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SandboxMenuSettingSlider : SandboxMenuSetting
	{
		[SerializeField]
		private Slider Slider;

		[SerializeField]
		private TMP_Text Label;

		[SerializeField]
		private DynamicButton ButtonDecrement;

		[SerializeField]
		private DynamicButton ButtonIncrement;

		private Func<float> _getValue;

		private Func<float, string> _format;

		private ButtonAnimator _buttonAnimatorDecrement;

		private ButtonAnimator _buttonAnimatorIncrement;

		public void Setup(LocalisedString settingName, LocalisedString settingTooltip, bool canBeEditedWhenPlayingLevel, Func<float> getValue, SandboxSliderOption option, Action<float> valueChanged, Func<float, string> format)
		{
			_format = format;
			_getValue = getValue;
			Setup(settingName, settingTooltip, canBeEditedWhenPlayingLevel);
			Label.text = format(getValue());
			Slider.minValue = option.Min;
			Slider.maxValue = option.Max;
			Slider.value = getValue();
			Slider.onValueChanged.AddListener(delegate(float value)
			{
				if (option.Round > 0f)
				{
					value = Mathf.Ceil(value / option.Round) * option.Round;
				}
				Label.text = _format(value);
				valueChanged.InvokeSafe(value);
			});
			ButtonDecrement.onPrimaryDown.AddListener(delegate
			{
				Slider.value -= option.Round;
			});
			ButtonIncrement.onPrimaryDown.AddListener(delegate
			{
				Slider.value += option.Round;
			});
			_buttonAnimatorDecrement = ButtonDecrement.GetComponent<ButtonAnimator>();
			_buttonAnimatorIncrement = ButtonIncrement.GetComponent<ButtonAnimator>();
			if (TooltipSetting != null)
			{
				TooltipSetting.TooltipText = (option.Tooltip.IsNull() ? null : option.Tooltip.Translation);
			}
		}

		public override void SetActive(bool active)
		{
			Slider.interactable = active;
			ButtonDecrement.interactable = active;
			ButtonIncrement.interactable = active;
			if (_buttonAnimatorIncrement != null)
			{
				ButtonAnimator.State currentState = ((!active) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				_buttonAnimatorDecrement.CurrentState = currentState;
				_buttonAnimatorIncrement.CurrentState = currentState;
			}
		}

		public override void OnSettingChanged()
		{
			float num = _getValue();
			Slider.value = num;
			Label.text = _format(num);
		}
	}
}
