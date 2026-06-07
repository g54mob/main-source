using System;

namespace VoxelBusters.EssentialKit
{
	internal class RateMyAppPresenter
	{
		private INativeRateMyAppInterface m_nativeInterface;

		private RateMyAppConfirmationDialogSettings m_confirmationDialogSettings;

		private Action<RateMyAppConfirmationPromptActionType> m_onConfirmationPromptAction;

		private bool m_isShowingPrompt;

		private string m_storeId;

		public RateMyAppPresenter(string storeId, RateMyAppConfirmationDialogSettings settings, Action<RateMyAppConfirmationPromptActionType> onConfirmationPromptAction)
		{
		}

		public bool IsShowing()
		{
			return false;
		}

		public void Show(bool skipConfirmationPrompt)
		{
		}

		private void ShowReviewWindow()
		{
		}

		private void OnPromptButtonPressed(RateMyAppConfirmationPromptActionType selectedButtonType)
		{
		}
	}
}
