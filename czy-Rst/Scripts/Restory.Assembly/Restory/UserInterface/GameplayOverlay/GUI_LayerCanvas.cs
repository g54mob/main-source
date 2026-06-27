using UnityEngine;

namespace Restory.UserInterface.GameplayOverlay
{
	public class GUI_LayerCanvas : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		public void SwitchLayerActiveState(bool shouldBeActive)
		{
			if (shouldBeActive)
			{
				canvasGroup.alpha = 1f;
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
			}
			else
			{
				canvasGroup.alpha = 0f;
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
			}
		}
	}
}
