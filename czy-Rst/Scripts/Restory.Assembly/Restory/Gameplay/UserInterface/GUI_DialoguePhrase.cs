using TMPro;
using UnityEngine;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_DialoguePhrase : MonoBehaviour, IDialogueObject
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private TMP_Text phraseText;

		public GameObject GameObject => base.gameObject;

		public CanvasGroup CanvasGroup => canvasGroup;

		public void UpdateContent(string phrase)
		{
			phraseText.text = phrase;
		}
	}
}
