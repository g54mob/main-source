using System;
using System.Collections.Generic;
using Helpers.Extensions;
using Helpers.Ranges;
using Restory.Data.Devices;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Email;
using Restory.Data.Localization;
using Restory.TimeSystems;
using Restory.UserInterface;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_MailClientEmailContentsPanel : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text subjectText;

		[SerializeField]
		private TMP_Text senderNameText;

		[SerializeField]
		private GameObject senderNameSection;

		[SerializeField]
		private TMP_Text addressText;

		[SerializeField]
		private TMP_Text deviceNameText;

		[SerializeField]
		private TMP_Text workTypesText;

		[SerializeField]
		private TMP_Text priceText;

		[SerializeField]
		private TMP_Text messageBodyText;

		[SerializeField]
		private Button takeOrderButton;

		[FormerlySerializedAs("readButton")]
		[SerializeField]
		private Button okButton;

		[FormerlySerializedAs("readButtonLocalisedText")]
		[SerializeField]
		private GUI_LocalisedText okButtonLocalisedText;

		[SerializeField]
		private Button yesButton;

		[SerializeField]
		private GUI_LocalisedText yesButtonLocalisedText;

		[SerializeField]
		private Button noButton;

		[SerializeField]
		private GUI_LocalisedText noButtonLocalisedText;

		[Space]
		[Header("Slow Image Loader settings")]
		[SerializeField]
		private GUI_InternetSlowImageLoader slowImageLoader;

		[SerializeField]
		private GameObject slowImageLoaderSection;

		[SerializeField]
		private IntRange initialChunkSize;

		[SerializeField]
		private IntRange loadedChunkSize;

		[SerializeField]
		private FloatRange delayBetweenChunks;

		[Space]
		[Header("Day time presets")]
		[SerializeField]
		private GUI_PresetSwitcher dayTimePresetSwitcher;

		[SerializeField]
		private string dayPreset;

		[SerializeField]
		private string nightPreset;

		[Header("Letter type dependent text fields presets")]
		[SerializeField]
		private GUI_PresetSwitcher messageTextFieldsPresetSwitcher;

		[SerializeField]
		private string orderPreset;

		[SerializeField]
		private string noOrderPreset;

		[Header("Status presets")]
		[SerializeField]
		private GUI_PresetSwitcher statusPresetSwitcher;

		[SerializeField]
		private string messageWithoutOrderNoButtonsPreset;

		[SerializeField]
		private string messageWithoutOrderOkButtonNotPressedPreset;

		[SerializeField]
		private string messageWithoutOrderOkButtonPressedPreset;

		[SerializeField]
		private string messageWithoutOrderOkButtonDisabledPreset;

		[SerializeField]
		private string messageWithoutOrderYesNoButtonsNotPressedPreset;

		[SerializeField]
		private string messageWithoutOrderYesButtonPressedPreset;

		[SerializeField]
		private string messageWithoutOrderNoButtonPressedPreset;

		[SerializeField]
		private string messageWithoutOrderYesButtonDisabledPreset;

		[SerializeField]
		private string messageWithoutOrderNoButtonDisabledPreset;

		[SerializeField]
		private string messageWithoutOrderYesNoButtonsDisabledPreset;

		[SerializeField]
		private string messageOrderNotYetTakenPreset;

		[SerializeField]
		private string messageOrderAwaitingDeliveryPreset;

		[SerializeField]
		private string messageOrderTakenAndDeliveredPreset;

		private LocalizationSystem localizationSystem;

		private MainDayTimeSwitchingService mainDayTimeSwitchingService;

		public event Action OnTakeOrderButtonClicked;

		public event Action OnOkButtonClicked;

		public event Action OnYesButtonClicked;

		public event Action OnNoButtonClicked;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem, MainDayTimeSwitchingService mainDayTimeSwitchingService)
		{
			this.localizationSystem = localizationSystem;
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
		}

		public void Init()
		{
			takeOrderButton.onClick.AddListener(ResolveTakeOrderButtonClicked);
			okButton.onClick.AddListener(ResolveOkButtonClicked);
			yesButton.onClick.AddListener(ResolveYesButtonClicked);
			noButton.onClick.AddListener(ResolveNoButtonClicked);
			mainDayTimeSwitchingService.OnDayTimeChanged += ResolveDayTimeChanged;
		}

		public void Clear()
		{
			takeOrderButton.onClick.RemoveListener(ResolveTakeOrderButtonClicked);
			okButton.onClick.RemoveListener(ResolveOkButtonClicked);
			yesButton.onClick.RemoveListener(ResolveYesButtonClicked);
			noButton.onClick.RemoveListener(ResolveNoButtonClicked);
			mainDayTimeSwitchingService.OnDayTimeChanged -= ResolveDayTimeChanged;
			slowImageLoader.StopImageLoadingAnimation();
		}

		public void SetUpOrderMessage(string subjectNameLocalizationKey, string subjectLocalizationKey, string senderNameLocalizationKey, string emailAddress, string messageMainTextLocalizationKey, string deviceNameLocalizationKey, IEnumerable<DeviceWorkType> workTypes, int price, EmailOrderStates orderState = EmailOrderStates.None)
		{
			subjectText.text = localizationSystem.GetTranslation(subjectNameLocalizationKey) + " " + localizationSystem.GetTranslation(deviceNameLocalizationKey) + " (" + localizationSystem.GetTranslation(subjectLocalizationKey) + ")";
			string translation = localizationSystem.GetTranslation(senderNameLocalizationKey);
			senderNameSection.SetActive(!string.IsNullOrEmpty(translation));
			senderNameText.text = translation;
			addressText.text = emailAddress;
			deviceNameText.text = localizationSystem.GetTranslation(deviceNameLocalizationKey);
			messageBodyText.text = localizationSystem.GetTranslation(messageMainTextLocalizationKey);
			workTypesText.text = workTypes.GetTranslationForWholeCollection(localizationSystem);
			priceText.text = "¥ " + price.ToReadableString();
			ResolveDayTimeChanged();
			messageTextFieldsPresetSwitcher.ActivatePreset(orderPreset);
			slowImageLoaderSection.SetActive(value: false);
			switch (orderState)
			{
			case EmailOrderStates.None:
			case EmailOrderStates.Completed:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderNoButtonsPreset);
				break;
			case EmailOrderStates.CanBeTaken:
				statusPresetSwitcher.ActivatePreset(messageOrderNotYetTakenPreset);
				break;
			case EmailOrderStates.TakenAndAwaitingDelivery:
				statusPresetSwitcher.ActivatePreset(messageOrderAwaitingDeliveryPreset);
				break;
			case EmailOrderStates.TakenAndInWork:
				statusPresetSwitcher.ActivatePreset(messageOrderTakenAndDeliveredPreset);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void SetUpNonOrderMessage(string subjectNameLocalizationKey, string subjectLocalizationKey, string senderNameLocalizationKey, string emailAddress, string messageMainTextLocalizationKey, EmailButtonsStates buttons, EmailButtonsLocalisationKeys buttonsLocalisationKeys, EmailMessageImageAttachmentInfo attachedImage = null)
		{
			subjectText.text = localizationSystem.GetTranslation(subjectNameLocalizationKey) + " " + localizationSystem.GetTranslation(subjectLocalizationKey);
			senderNameText.text = localizationSystem.GetTranslation(senderNameLocalizationKey);
			addressText.text = emailAddress;
			messageBodyText.text = localizationSystem.GetTranslation(messageMainTextLocalizationKey);
			okButtonLocalisedText.LocalizationID = buttonsLocalisationKeys.OkButtonLocalisationKey;
			yesButtonLocalisedText.LocalizationID = buttonsLocalisationKeys.YesButtonLocalisationKey;
			noButtonLocalisedText.LocalizationID = buttonsLocalisationKeys.NoButtonLocalisationKey;
			messageTextFieldsPresetSwitcher.ActivatePreset(noOrderPreset);
			if ((bool)attachedImage)
			{
				slowImageLoaderSection.SetActive(value: true);
				slowImageLoader.StartImageLoadingAnimation(attachedImage.Icon, initialChunkSize, loadedChunkSize, delayBetweenChunks);
			}
			else
			{
				slowImageLoaderSection.SetActive(value: false);
			}
			switch (buttons)
			{
			case EmailButtonsStates.None:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderNoButtonsPreset);
				break;
			case EmailButtonsStates.OkButton_NotPressed:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderOkButtonNotPressedPreset);
				break;
			case EmailButtonsStates.OkButton_Pressed:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderOkButtonPressedPreset);
				break;
			case EmailButtonsStates.YesNoButtons_NotPressed:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderYesNoButtonsNotPressedPreset);
				break;
			case EmailButtonsStates.YesNoButtons_YesButtonPressed:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderYesButtonPressedPreset);
				break;
			case EmailButtonsStates.YesNoButtons_NoButtonPressed:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderNoButtonPressedPreset);
				break;
			case EmailButtonsStates.OkButton_Disabled:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderOkButtonDisabledPreset);
				break;
			case EmailButtonsStates.YesNoButtons_YesButtonDisabled:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderYesButtonDisabledPreset);
				break;
			case EmailButtonsStates.YesNoButtons_NoButtonDisabled:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderNoButtonDisabledPreset);
				break;
			case EmailButtonsStates.YesNoButtons_BothButtonsDisabled:
				statusPresetSwitcher.ActivatePreset(messageWithoutOrderYesNoButtonsDisabledPreset);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void SetNoMessageSelectedState()
		{
			messageTextFieldsPresetSwitcher.ActivatePreset(noOrderPreset);
			statusPresetSwitcher.ActivatePreset(messageWithoutOrderNoButtonsPreset);
		}

		private void ResolveTakeOrderButtonClicked()
		{
			this.OnTakeOrderButtonClicked?.Invoke();
		}

		private void ResolveOkButtonClicked()
		{
			this.OnOkButtonClicked?.Invoke();
		}

		private void ResolveYesButtonClicked()
		{
			this.OnYesButtonClicked?.Invoke();
		}

		private void ResolveNoButtonClicked()
		{
			this.OnNoButtonClicked?.Invoke();
		}

		private void ResolveDayTimeChanged()
		{
			dayTimePresetSwitcher.ActivatePreset((mainDayTimeSwitchingService.CurrentDayTime == MainDayTimes.AfterWork) ? nightPreset : dayPreset);
		}
	}
}
