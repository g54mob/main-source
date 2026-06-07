using System;
using TMPro;
using UnityEngine;
using Utils.Enums;

namespace Events.UI.Overlays
{
	public class MenuModalDialogDto
	{
		public TextAlignmentOptions TextAlignment;

		private const string defaultSuccessButtonTextKey = "ModalGeneric.ProceedButton";

		private const string defaultCancelButtonTextKey = "ModalGeneric.CancelButton";

		private string _overrideSuccessButtonTextKey;

		private string _overrideCancelButtonTextKey;

		public Sizes ModalSize { get; private set; }

		public string Title { get; private set; }

		public string Text { get; set; }

		public string ExtraText { get; private set; }

		public Sprite ImageSprite { get; private set; }

		public string VideoName { get; private set; }

		public Action SuccessCallback { get; private set; }

		public bool ShowCancelButton { get; private set; }

		public Action CancelCallback { get; private set; }

		public Sizes TitleSize { get; set; }

		public Sizes TextSize { get; set; }

		public string OverrideSuccessButtonTextKey
		{
			private get
			{
				return _overrideSuccessButtonTextKey;
			}
			set
			{
				_overrideSuccessButtonTextKey = value;
			}
		}

		public string SuccessButtonText
		{
			get
			{
				if (!string.IsNullOrEmpty(_overrideSuccessButtonTextKey))
				{
					return LocalizationUtility.GetLocalizedText(_overrideSuccessButtonTextKey);
				}
				return LocalizationUtility.GetLocalizedText("ModalGeneric.ProceedButton");
			}
		}

		public string OverrideCancelButtonTextKey
		{
			private get
			{
				return _overrideCancelButtonTextKey;
			}
			set
			{
				_overrideCancelButtonTextKey = value;
			}
		}

		public string CancelButtonText
		{
			get
			{
				if (!string.IsNullOrEmpty(_overrideCancelButtonTextKey))
				{
					return LocalizationUtility.GetLocalizedText(_overrideCancelButtonTextKey);
				}
				return LocalizationUtility.GetLocalizedText("ModalGeneric.CancelButton");
			}
		}

		public MenuModalDialogDto(string textKey, Sizes modalSize = Sizes.M, Action successCallback = null, bool showCancelButton = false, Action cancelCallback = null, bool skipLocalization = false)
		{
			Text = (skipLocalization ? textKey : LocalizationUtility.GetLocalizedText(textKey));
			TextAlignment = TextAlignmentOptions.Center;
			ModalSize = modalSize;
			SuccessCallback = successCallback;
			ShowCancelButton = showCancelButton;
			CancelCallback = cancelCallback;
		}

		public MenuModalDialogDto(string titleKey, string textKey, Sizes modalSize = Sizes.M, Action successCallback = null, bool showCancelButton = false, Action cancelCallback = null)
		{
			Title = LocalizationUtility.GetLocalizedText(titleKey);
			Text = LocalizationUtility.GetLocalizedText(textKey);
			TextAlignment = TextAlignmentOptions.Center;
			ModalSize = modalSize;
			SuccessCallback = successCallback;
			ShowCancelButton = showCancelButton;
			CancelCallback = cancelCallback;
		}

		public MenuModalDialogDto(string titleKey, string textKey, Sprite imageSprite, string extraTextKey = "", Sizes modalSize = Sizes.M, Action successCallback = null, bool showCancelButton = false, Action cancelCallback = null)
		{
			Title = (string.IsNullOrEmpty(titleKey) ? "" : LocalizationUtility.GetLocalizedText(titleKey));
			Text = LocalizationUtility.GetLocalizedText(textKey);
			ImageSprite = imageSprite;
			ExtraText = (string.IsNullOrEmpty(extraTextKey) ? extraTextKey : LocalizationUtility.GetLocalizedText(extraTextKey));
			TextAlignment = TextAlignmentOptions.Center;
			ModalSize = modalSize;
			SuccessCallback = successCallback;
			ShowCancelButton = showCancelButton;
			CancelCallback = cancelCallback;
		}

		public MenuModalDialogDto(string titleKey, string textKey, string videoName, string extraTextKey = "", Sizes modalSize = Sizes.M, Action successCallback = null, bool showCancelButton = false, Action cancelCallback = null)
		{
			Title = (string.IsNullOrEmpty(titleKey) ? "" : LocalizationUtility.GetLocalizedText(titleKey));
			Text = LocalizationUtility.GetLocalizedText(textKey);
			VideoName = videoName;
			ImageSprite = null;
			ExtraText = (string.IsNullOrEmpty(extraTextKey) ? extraTextKey : LocalizationUtility.GetLocalizedText(extraTextKey));
			TextAlignment = TextAlignmentOptions.Center;
			ModalSize = modalSize;
			SuccessCallback = successCallback;
			ShowCancelButton = showCancelButton;
			CancelCallback = cancelCallback;
		}

		private void ResetValues()
		{
			Title = string.Empty;
			Text = string.Empty;
			VideoName = string.Empty;
			ImageSprite = null;
			ExtraText = string.Empty;
			TextAlignment = TextAlignmentOptions.Center;
			TitleSize = Sizes.M;
			TextSize = Sizes.M;
			SuccessCallback = null;
			ShowCancelButton = false;
			CancelCallback = null;
			OverrideSuccessButtonTextKey = "";
			OverrideCancelButtonTextKey = "";
		}
	}
}
