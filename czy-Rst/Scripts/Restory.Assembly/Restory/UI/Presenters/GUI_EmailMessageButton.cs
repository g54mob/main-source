using System;
using Restory.Data.Localization;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_EmailMessageButton : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private GUI_PresetSwitcher wasReadStatusPresetSwitcher;

		[SerializeField]
		private GUI_PresetSwitcher selectionStatusPresetSwitcher;

		[SerializeField]
		private TMP_Text emailAddressText;

		[SerializeField]
		private TMP_Text emailSubjectText;

		private LocalizationSystem localizationSystem;

		public event Action<GUI_EmailMessageButton> OnClick;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

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

		public void SetUp(string emailAddress, string deviceNameLocalizationKey, string subjectLocalizationKey, bool wasMessageReadPreviously)
		{
			emailAddressText.text = emailAddress;
			emailSubjectText.text = localizationSystem.GetTranslation(deviceNameLocalizationKey) + " (" + localizationSystem.GetTranslation(subjectLocalizationKey) + ")";
			wasReadStatusPresetSwitcher.ActivatePreset(wasMessageReadPreviously ? PresetName.Normal : PresetName.Warning);
		}

		public void ChangeSelection(bool shouldBeSelected)
		{
			selectionStatusPresetSwitcher.ActivatePreset((!shouldBeSelected) ? PresetName.Normal : PresetName.Selected);
		}

		public void MarkAsRead()
		{
			wasReadStatusPresetSwitcher.ActivatePreset(PresetName.Normal);
		}

		private void ResolveButtonClicked()
		{
			this.OnClick?.Invoke(this);
		}
	}
}
