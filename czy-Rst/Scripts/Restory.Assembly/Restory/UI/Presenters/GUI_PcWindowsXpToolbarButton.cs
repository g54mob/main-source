using System;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_PcWindowsXpToolbarButton : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private TMP_Text numberText;

		[SerializeField]
		private GameObject numberObject;

		[SerializeField]
		private GUI_BlinkingImage numberBlinkingBackground;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		public event Action<GUI_PcWindowsXpToolbarButton> OnClicked;

		private void OnEnable()
		{
			button.onClick.AddListener(ResolveButtonClicked);
		}

		private void OnDisable()
		{
			if (button.MonoShellExists())
			{
				button.onClick.RemoveListener(ResolveButtonClicked);
			}
		}

		public void SetState(bool isApplicationOpen)
		{
			presetSwitcher.ActivatePreset((!isApplicationOpen) ? PresetName.Normal : PresetName.Chosen);
			if (isApplicationOpen && (bool)numberBlinkingBackground && (bool)numberText)
			{
				numberBlinkingBackground.TurnBlinkingOff(string.IsNullOrEmpty(numberText.text) ? BlinkingImageStoppedModeColorOptions.UseInactiveColor : BlinkingImageStoppedModeColorOptions.UseActiveColor);
			}
		}

		public void SetAdditionalInfo(params IPcWindowsXpToolbarButtonAdditionalInfoArgument[] arguments)
		{
			if (!numberText || !numberObject)
			{
				return;
			}
			bool flag = true;
			bool flag2 = false;
			foreach (IPcWindowsXpToolbarButtonAdditionalInfoArgument pcWindowsXpToolbarButtonAdditionalInfoArgument in arguments)
			{
				if (!(pcWindowsXpToolbarButtonAdditionalInfoArgument is PcWindowsXpToolbarButtonAdditionalInfoNumber pcWindowsXpToolbarButtonAdditionalInfoNumber))
				{
					if (pcWindowsXpToolbarButtonAdditionalInfoArgument is PcWindowsXpToolbarButtonAdditionalInfoNeverBeforeOpened)
					{
						flag = false;
					}
				}
				else
				{
					numberText.text = $"({pcWindowsXpToolbarButtonAdditionalInfoNumber.Number})";
					flag2 = true;
				}
			}
			if (!flag2)
			{
				numberText.text = string.Empty;
				numberObject.SetActive(value: false);
				if ((bool)numberBlinkingBackground)
				{
					numberBlinkingBackground.TurnBlinkingOff();
				}
				return;
			}
			numberObject.SetActive(value: true);
			if ((bool)numberBlinkingBackground)
			{
				if (!flag)
				{
					numberBlinkingBackground.TurnBlinkingOn();
				}
				else
				{
					numberBlinkingBackground.TurnBlinkingOff(BlinkingImageStoppedModeColorOptions.UseActiveColor);
				}
			}
		}

		private void ResolveButtonClicked()
		{
			this.OnClicked?.Invoke(this);
		}
	}
}
