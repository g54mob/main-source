using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_SystemMessage : MonoBehaviour, IDialogueObject
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Button submitButton;

		[SerializeField]
		private TMP_Text messageText;

		public GameObject GameObject => base.gameObject;

		public CanvasGroup CanvasGroup => canvasGroup;

		public Button SubmitButton => submitButton;

		public void UpdateContent(string message)
		{
			messageText.text = message;
		}
	}
}
