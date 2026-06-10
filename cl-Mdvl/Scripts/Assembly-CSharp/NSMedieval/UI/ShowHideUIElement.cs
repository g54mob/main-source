using UnityEngine;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class ShowHideUIElement : MonoBehaviour
	{
		private CanvasGroup canvasGroup;

		private bool defaultInteractable;

		private bool defaultBlockRaycast;

		private void Start()
		{
			canvasGroup = GetComponent<CanvasGroup>();
			defaultInteractable = canvasGroup.interactable;
			defaultBlockRaycast = canvasGroup.blocksRaycasts;
		}

		public void Show()
		{
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = defaultInteractable;
			canvasGroup.blocksRaycasts = defaultBlockRaycast;
		}

		public void Hide()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = !defaultInteractable;
			canvasGroup.blocksRaycasts = !defaultBlockRaycast;
		}
	}
}
