using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_DialogueAdditionalImages : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private CanvasGroup canvasGroup;

		public void Show(Sprite icon)
		{
			image.overrideSprite = icon;
			canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			canvasGroup.alpha = 0f;
		}
	}
}
