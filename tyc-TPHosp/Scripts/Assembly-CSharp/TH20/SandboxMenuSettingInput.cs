using System;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SandboxMenuSettingInput : SandboxMenuSetting
	{
		[SerializeField]
		private InputField InputField;

		private Func<string> _getValue;

		public void Setup(LocalisedString settingName, LocalisedString settingTooltip, bool canBeEditedWhenPlayingLevel, Func<string> getValue, int maxCharacters, Action<string> valueChanged)
		{
			_getValue = getValue;
			Setup(settingName, settingTooltip, canBeEditedWhenPlayingLevel);
			InputField.text = getValue();
			InputField.characterLimit = maxCharacters;
			InputField.onEndEdit.AddListener(valueChanged.InvokeSafe<string>);
		}

		public override void SetActive(bool active)
		{
			InputField.interactable = active;
		}

		public override void OnSettingChanged()
		{
			InputField.text = _getValue();
		}
	}
}
