using UnityEngine;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_DialogueChoice : MonoBehaviour, IDialogueObject
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GUI_DialogueChoiceOption firstOption;

		[SerializeField]
		private GUI_DialogueChoiceOption secondOption;

		public GameObject GameObject => base.gameObject;

		public CanvasGroup CanvasGroup => canvasGroup;

		private void OnEnable()
		{
			firstOption.PointerEnter += ResolveFirstOptionSelected;
			secondOption.PointerEnter += ResolveSecondOptionSelected;
		}

		private void OnDisable()
		{
			firstOption.PointerEnter -= ResolveFirstOptionSelected;
			secondOption.PointerEnter -= ResolveSecondOptionSelected;
		}

		public void UpdateContent(string firstOptionContent, string secondOptionContent)
		{
			firstOption.UpdateContent(firstOptionContent);
			secondOption.UpdateContent(secondOptionContent);
			ResolveFirstOptionSelected();
		}

		private void ResolveFirstOptionSelected()
		{
			firstOption.Select();
			secondOption.Deselect();
		}

		private void ResolveSecondOptionSelected()
		{
			secondOption.Select();
			firstOption.Deselect();
		}
	}
}
