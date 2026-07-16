using MLCN_Localization;

namespace Game.General
{
	public class GeneralSettings
	{
		public static void SetCameraSensitivity(float cameraSensitivity)
		{
			if (GlobalReferences.IsValidated())
			{
				if (GlobalReferences.GetCameraController() != null)
				{
					GlobalReferences.GetCameraController().SetCameraSensitivity(cameraSensitivity);
				}
				if (GlobalReferences.GetDarkRoomCameraController() != null)
				{
					GlobalReferences.GetDarkRoomCameraController().SetCameraSensitivity(cameraSensitivity);
				}
			}
		}

		public static void SetLanguage(int language)
		{
			if (LocalizationManager.IsValidated())
			{
				LocalizationManager.ChangeLanguage((LocalizationManager.Language)language);
			}
		}

		public static void SetShowHintBoxes(bool showHintBoxes)
		{
			if (PopupMessageManager.IsValidated() && !(PopupMessageManager.GetPopHint() == null))
			{
				if (showHintBoxes)
				{
					PopupMessageManager.GetPopHint().EnableHints();
				}
				else
				{
					PopupMessageManager.GetPopHint().DisableHints();
				}
			}
		}

		public static void SetTutorialAvailable(bool available)
		{
			if (TutorialManager.IsValidated())
			{
				if (available)
				{
					TutorialManager.EnableTutorial();
				}
				else
				{
					TutorialManager.DisableTutorial();
				}
			}
		}

		public static void SetDialogAnimation(bool enable)
		{
			if (DialogManager.IsValidated())
			{
				DialogManager.SetTextAnimation(enable);
			}
		}

		public static void SetDialogTextSpeed(float dialogTextSpeed)
		{
			if (DialogManager.IsValidated())
			{
				DialogManager.SetTextAnimationSpeed(dialogTextSpeed);
			}
		}

		public static void SetDialogAutoplay(bool autoplay)
		{
			if (DialogManager.IsValidated())
			{
				DialogManager.SetDialogAutoplay(autoplay);
			}
		}

		public static void SetDialogStayDuration(float duration)
		{
			if (DialogManager.IsValidated())
			{
				DialogManager.SetDialogDuration(duration);
			}
		}
	}
}
