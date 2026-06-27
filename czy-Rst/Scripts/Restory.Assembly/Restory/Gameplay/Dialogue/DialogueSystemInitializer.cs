using PixelCrushers.DialogueSystem;
using Zenject;

namespace Restory.Gameplay.Dialogue
{
	public class DialogueSystemInitializer : IInitializable
	{
		private DialogueSystemController dialogueSystemController;

		private IDialogueUI dialogueUI;

		public DialogueSystemInitializer(DialogueSystemController dialogueSystemController, IDialogueUI dialogueUI)
		{
			this.dialogueSystemController = dialogueSystemController;
			this.dialogueUI = dialogueUI;
		}

		public void Initialize()
		{
			dialogueSystemController.dialogueUI = dialogueUI;
		}
	}
}
