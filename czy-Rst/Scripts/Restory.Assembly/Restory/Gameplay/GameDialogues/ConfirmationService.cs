using System;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameDialogues
{
	public class ConfirmationService : IInitializable, IDisposable
	{
		private readonly VirtualCursorPresenter cursorPresenter;

		private readonly CursorIcons cursorIcons;

		private readonly GUI_GameDialogueCanvas gameDialogueCanvas;

		private readonly GUI_ConfirmationDialogue confirmationDialogue;

		private IConfirmationRequester activeRequester;

		[Inject]
		public ConfirmationService(VirtualCursorPresenter cursorPresenter, CursorIcons cursorIcons, GUI_GameDialogueCanvas gameDialogueCanvas)
		{
			this.cursorPresenter = cursorPresenter;
			this.cursorIcons = cursorIcons;
			this.gameDialogueCanvas = gameDialogueCanvas;
			confirmationDialogue = gameDialogueCanvas.ConfirmationDialogue;
		}

		public void Initialize()
		{
			confirmationDialogue.OnConfirmed += OnConfirmed;
			confirmationDialogue.OnCanceled += OnCanceled;
		}

		public void Dispose()
		{
			confirmationDialogue.OnConfirmed -= OnConfirmed;
			confirmationDialogue.OnCanceled -= OnCanceled;
		}

		public void RequestConfirmation(IConfirmationRequester requester)
		{
			if (activeRequester != null)
			{
				Debug.LogError(string.Format("{0} has active {1} requester already", "ConfirmationService", activeRequester.GetType()));
				requester.OnConfirmationResponse(isConfirmed: false);
			}
			else
			{
				gameDialogueCanvas.SetConfirmationTextToDefault();
				activeRequester = requester;
				ActivateConfirmationDialogue();
			}
		}

		public void RequestConfirmation(IConfirmationRequester requester, string confirmationTextLocalizationKey)
		{
			if (activeRequester != null)
			{
				Debug.LogError(string.Format("{0} has active {1} requester already", "ConfirmationService", activeRequester.GetType()));
				requester.OnConfirmationResponse(isConfirmed: false);
			}
			else
			{
				gameDialogueCanvas.SetConfirmationText(confirmationTextLocalizationKey);
				activeRequester = requester;
				ActivateConfirmationDialogue();
			}
		}

		private void ActivateConfirmationDialogue()
		{
			gameDialogueCanvas.ActivateConfirmationDialogue();
			cursorPresenter.SetIcon(cursorIcons.HoverCursor);
		}

		private void OnConfirmed()
		{
			ResponseToRequester(isConfirmed: true);
		}

		private void OnCanceled()
		{
			ResponseToRequester(isConfirmed: false);
		}

		private void ResponseToRequester(bool isConfirmed)
		{
			gameDialogueCanvas.Deactivate();
			if (activeRequester == null)
			{
				Debug.LogError("Confirmation requester was lost in ConfirmationService");
				return;
			}
			activeRequester.OnConfirmationResponse(isConfirmed);
			activeRequester = null;
		}
	}
}
