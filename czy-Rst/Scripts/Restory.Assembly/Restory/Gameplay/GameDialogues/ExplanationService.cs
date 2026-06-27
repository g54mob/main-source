using System;
using Restory.Gameplay.UserInterface;
using Zenject;

namespace Restory.Gameplay.GameDialogues
{
	public class ExplanationService : IInitializable, IDisposable
	{
		private readonly GUI_GameDialogueCanvas gameDialogueCanvas;

		private readonly GUI_ExplanationDialogue explanationDialogue;

		[Inject]
		public ExplanationService(GUI_GameDialogueCanvas gameDialogueCanvas)
		{
			this.gameDialogueCanvas = gameDialogueCanvas;
			explanationDialogue = gameDialogueCanvas.ExplanationDialogue;
		}

		public void Initialize()
		{
			explanationDialogue.OnViewed += OnViewed;
		}

		public void Dispose()
		{
			explanationDialogue.OnViewed -= OnViewed;
		}

		public void ShowExplanation()
		{
			gameDialogueCanvas.ActivateExplanationDialogue();
		}

		private void OnViewed()
		{
			gameDialogueCanvas.Deactivate();
		}
	}
}
