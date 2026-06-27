using System;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.NPCs
{
	public class NpcDialogueInteractionService : MonoBehaviour
	{
		[SerializeField]
		private DialogueSystemTrigger dialogueSystemTrigger;

		private DialogueSystemController dialogueSystemController;

		private Action currentDialogueEndedCallback;

		private Coroutine activeDialogueValidationCoroutine;

		[Inject]
		private void Construct(DialogueSystemController dialogueSystemController)
		{
			this.dialogueSystemController = dialogueSystemController;
		}

		private void OnDisable()
		{
			if (activeDialogueValidationCoroutine != null)
			{
				StopCoroutine(activeDialogueValidationCoroutine);
				activeDialogueValidationCoroutine = null;
			}
		}

		public void StartDialogue(string conversationToStart, Action onDialogueEndedCallback)
		{
			currentDialogueEndedCallback = onDialogueEndedCallback;
			dialogueSystemTrigger.conversation = conversationToStart;
			dialogueSystemController.conversationEnded += ResolveConversationEnded;
			dialogueSystemTrigger.OnUse();
			if (activeDialogueValidationCoroutine != null)
			{
				StopCoroutine(activeDialogueValidationCoroutine);
			}
			activeDialogueValidationCoroutine = StartCoroutine(ActiveDialogueValidationCoroutine());
		}

		private void ResolveConversationEnded(Transform _)
		{
			dialogueSystemController.conversationEnded -= ResolveConversationEnded;
			currentDialogueEndedCallback?.Invoke();
			currentDialogueEndedCallback = null;
		}

		private IEnumerator ActiveDialogueValidationCoroutine()
		{
			yield return null;
			activeDialogueValidationCoroutine = null;
			if (!dialogueSystemController.isConversationActive)
			{
				Debug.LogError("Dialogue aborted when trying to start it - most probably due to no valid entries.");
				ResolveConversationEnded(null);
			}
		}
	}
}
