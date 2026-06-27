using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Dialogue
{
	public class DialogueSystemTester : MonoBehaviour
	{
		[SerializeField]
		private DialogueSystemTrigger dialogueSystemTrigger;

		[SerializeField]
		[ConversationPopup(true, false)]
		private string conversation;

		private DialogueSystemController dialogueSystemController;

		[Inject]
		private void Construct(DialogueSystemController dialogueSystemController)
		{
			this.dialogueSystemController = dialogueSystemController;
		}

		private void StartConversation()
		{
			dialogueSystemController.StartConversation(conversation);
		}

		private void FireDialogueSystemTrigger()
		{
			dialogueSystemTrigger.OnUse();
		}
	}
}
