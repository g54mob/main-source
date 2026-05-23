using System;
using Utils.Enums;

namespace Events.UI.Overlays
{
	public class ModalDialogDto
	{
		private const string defaultSuccessButtonTextKey = "ModalGeneric.ProceedButton";

		private const string defaultCancelButtonTextKey = "ModalGeneric.CancelButton";

		private string _overrideSuccessButtonTextKey;

		private string _overrideCancelButtonTextKey;

		public Sizes ModalSize { get; private set; }

		public ModalDialogContent[] DialogContent { get; private set; }

		public Action SuccessCallback { get; private set; }

		public bool ShowCancelButton { get; private set; }

		public bool AllowPageSkip { get; private set; }

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

		public void UpdateTexts()
		{
			for (int i = 0; i < DialogContent.Length; i++)
			{
				DialogContent[i].UpdateTexts();
			}
		}

		public ModalDialogDto(ModalDialogContent dialogContent, Sizes modalSize = Sizes.M, Action successCallback = null, bool showCancelButton = false, Action cancelCallback = null, bool allowPageSkip = false)
		{
			ResetValues();
			ModalSize = modalSize;
			DialogContent = new ModalDialogContent[1] { dialogContent };
			SuccessCallback = successCallback;
			ShowCancelButton = showCancelButton;
			CancelCallback = cancelCallback;
			AllowPageSkip = allowPageSkip;
		}

		public ModalDialogDto(ModalDialogContent[] dialogContent, Sizes modalSize = Sizes.M, Action successCallback = null, bool showCancelButton = false, Action cancelCallback = null, bool allowPageSkip = false)
		{
			ResetValues();
			ModalSize = modalSize;
			DialogContent = dialogContent;
			SuccessCallback = successCallback;
			ShowCancelButton = showCancelButton;
			CancelCallback = cancelCallback;
			AllowPageSkip = allowPageSkip;
		}

		private void ResetValues()
		{
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
