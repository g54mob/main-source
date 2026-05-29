using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class GameOverDialogues : MonoBehaviour
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		protected string _bankruptDialogue;

		private void Start()
		{
			DialogueManager.StopAllConversations();
			DialogueManager.StartConversation(_bankruptDialogue);
		}
	}
}
