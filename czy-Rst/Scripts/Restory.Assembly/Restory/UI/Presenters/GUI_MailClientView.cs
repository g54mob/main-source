using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Presenters
{
	public sealed class GUI_MailClientView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private CanvasGroup emptyFolderPageCanvasGroup;

		[SerializeField]
		private CanvasGroup noMessageSelectedPanelCanvasGroup;

		public void Show()
		{
			canvasGroup.blocksRaycasts = true;
			canvasGroup.interactable = true;
			canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
			canvasGroup.alpha = 0f;
		}

		public void SwitchEmptyFolderNotificationVisibility(bool shouldShowNotification)
		{
			SetCanvasGroupActiveState(emptyFolderPageCanvasGroup, shouldShowNotification);
		}

		public void SwitchNoMessageSelectedNotificationVisibility(bool shouldShowNotification)
		{
			SetCanvasGroupActiveState(noMessageSelectedPanelCanvasGroup, shouldShowNotification);
		}

		private void SetCanvasGroupActiveState(CanvasGroup targetCanvasGroup, bool shouldCanvasGroupBeActive)
		{
			if (shouldCanvasGroupBeActive)
			{
				targetCanvasGroup.blocksRaycasts = true;
				targetCanvasGroup.interactable = true;
				targetCanvasGroup.alpha = 1f;
			}
			else
			{
				targetCanvasGroup.blocksRaycasts = false;
				targetCanvasGroup.interactable = false;
				targetCanvasGroup.alpha = 0f;
			}
		}
	}
}
