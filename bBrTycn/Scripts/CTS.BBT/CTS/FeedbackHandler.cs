using System.Collections;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class FeedbackHandler : MonoSingleton<FeedbackHandler>
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		protected string _feedbackDialogue;

		private DialogueEntry _dialogueEntry;

		private void OnEnable()
		{
			_dialogueEntry = DialogueManager.MasterDatabase.GetConversation(_feedbackDialogue).GetDialogueEntry(1);
		}

		public void ShowFeedback(string feedbackText)
		{
			StopAllCoroutines();
			DialogueManager.StopAllConversations();
			_dialogueEntry.currentDialogueText = feedbackText;
			DialogueManager.StartConversation(_feedbackDialogue);
		}

		public void ShowFeedback(string feedbackText, float duration)
		{
			ShowFeedback(feedbackText);
			StartCoroutine(FeedbackRoutine(duration));
		}

		private IEnumerator FeedbackRoutine(float duration)
		{
			yield return new WaitForSeconds(duration);
			HideFeedback();
		}

		public void HideFeedback()
		{
			DialogueManager.StopAllConversations();
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void SingletonAwake()
		{
		}
	}
}
