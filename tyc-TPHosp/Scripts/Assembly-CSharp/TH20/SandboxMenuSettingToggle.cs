using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class SandboxMenuSettingToggle : SandboxMenuSetting
	{
		[SerializeField]
		private ButtonAnimator Button;

		[SerializeField]
		private TMP_Text Label;

		private Func<int> _getValue;

		private SandboxToggleOption[] _options;

		private Localize _localize;

		public void Setup(LocalisedString settingName, LocalisedString settingTooltip, bool canBeEditedWhenPlayingLevel, Func<int> getValue, SandboxToggleOption[] options, Action<int> valueChanged)
		{
			_getValue = getValue;
			_options = options;
			Setup(settingName, settingTooltip, canBeEditedWhenPlayingLevel);
			int value = _getValue();
			_localize = Label.GetComponent<Localize>();
			SetLabel(_options[value]);
			Button.Button.onPrimaryDown.AddListener(delegate
			{
				value = _getValue() + 1;
				if (value >= _options.Length)
				{
					value = 0;
				}
				valueChanged.InvokeSafe(value);
				value = _getValue();
				SetLabel(_options[value]);
			});
			if (TooltipSetting != null)
			{
				TooltipSetting.SetDataProvider(delegate(Tooltip tooltip)
				{
					SandboxToggleOption sandboxToggleOption = _options[_getValue()];
					tooltip.Text = (sandboxToggleOption.Tooltip.IsNull() ? null : sandboxToggleOption.Tooltip.Translation);
				});
			}
		}

		public override void SetActive(bool active)
		{
			Button.CurrentState = ((!active) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
		}

		public override void OnSettingChanged()
		{
			SetLabel(_options[_getValue()]);
		}

		private void SetLabel(SandboxToggleOption option)
		{
			if (_localize != null)
			{
				_localize.Term = option.LocalisedName.Term;
			}
			else
			{
				Label.text = option.DisplayName;
			}
		}
	}
}
